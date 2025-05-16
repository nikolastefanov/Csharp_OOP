namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Advanced : Player,IPlayer
    {
        public const int AdvancedPlayerInitialHaelth = 250;
        public Advanced(ICardRepository cardRepository,string username)
            :base(cardRepository,username, AdvancedPlayerInitialHaelth)
        {

        }
    }
}
