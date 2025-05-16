namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.Linq;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly.GetCallingAssembly()
                .GetType()
                .FirstOrDefault(t => t.Name.StartWith(type));

            ICard card =(ICard)Activator.CreateInstance(
                cardType, name);

            return card;
        }
    }
}
