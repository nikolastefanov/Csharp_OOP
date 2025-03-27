namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Runtime.CompilerServices;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {

        private readonly IPlayer mainPlayers;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayers = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Pistol)==type)
            {
                gun = new Pistol(name);
            }
            else if (nameof(Rifle)==type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }
            this.guns.Add(gun);
            return $"Successfully added { name} of type: { type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count==0)
            {
                return "There are no guns in the queue!";
            }

            IPlayer civilPlayer = this.civilPlayers
                .FirstOrDefault(p => p.Name == name);

            string message = string.Empty;

            IGun gun = this.guns.FirstOrDefault();

            if (name== "Vercetti")
            {
                this.mainPlayers.GunRepository.Add(gun);

                message = $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayer!=null)
            {
                civilPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Civil Player: {name}";
            }
            else
            {
                return "Civil player with that name doesn't exists!";

            }
            this.guns.Remove(gun);
            return message;
            
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int totalSumLifePoints = this.civilPlayers
                .Sum(p => p.LifePoints);

            int aliveCivilPlayersCount = this.civilPlayers
                .Count(p => p.IsAlive);

            string message = string.Empty;

            int mainPlayerLifePoints = this.mainPlayers.LifePoints;

            this.gangNeighbourhood.Action(
                this.mainPlayers, this.civilPlayers);

            int mainPlayerLifePointsAfterFight =
                this.mainPlayers.LifePoints;

            int totalSumLifePointsAfterFight =
                this.civilPlayers.Sum(p => p.LifePoints);

            if (mainPlayerLifePoints==mainPlayerLifePointsAfterFight&&
                totalSumLifePoints==aliveCivilPlayersCount)
            {
                message = "Everything is okay!";

            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {this.mainPlayers.LifePoints}!" + Environment.NewLine;
                message += $"Tommy has killed: {this.civilPlayers.Count-aliveCivilPlayersCount} players!" + Environment.NewLine;
                message += $"Left Civil Players: {aliveCivilPlayersCount}!";
            }
            throw new NotImplementedException();
        }
    }
}
