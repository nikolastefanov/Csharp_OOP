namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }
        public int Count 
            => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards
            => this.cardsByName.Values;


        public void Add(ICard card)
        {
            if (card==null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }
            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.CardAlreadyExists,
                        card.Name));
            }
            this.cardsByName.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }
            return card;
        }

        public bool Remove(ICard card)
        {
            if (card==null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }

            bool hasRemoved = this.cardsByName.Remove(card.Name);
            return hasRemoved;
        }
    }
}
