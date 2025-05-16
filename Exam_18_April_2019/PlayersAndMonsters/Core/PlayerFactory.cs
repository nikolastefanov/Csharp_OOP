namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.Linq;
    using PlayersAndMonsters.Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = Assembly.GetCallingAssembly()
                .GetType()
                .FirstOrDefault(t => t.Name == type);

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType,
                new CardRepository(), username);

            return player;
        }
    }
}
