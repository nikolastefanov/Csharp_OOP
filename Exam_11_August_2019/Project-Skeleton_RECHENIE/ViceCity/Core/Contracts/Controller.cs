namespace ViceCity.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count==0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.guns.FirstOrDefault();

            string message = string.Empty;

            IPlayer civilPlayer = this.civilPlayers
                .FirstOrDefault(p => p.Name == name);

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

            int mainPlayerLifePoints =
                this.mainPlayers.LifePoints;

            int totalSumLifePoints =
                this.civilPlayers.Sum(p => p.LifePoints);

            this.gangNeighbourhood.Action(
                this.mainPlayers, this.civilPlayers);

            int mainPlayerLifePointsAfterFight = 
                this.mainPlayers.LifePoints;

            int totalSumPointsAfterFight =
                this.civilPlayers.Sum(p => p.LifePoints);

            int aveleCivilPlayersCount =
                this.civilPlayers
                .Where(p => p.IsAlive)
                .Count();

            string message = string.Empty;

            if (mainPlayerLifePoints==mainPlayerLifePointsAfterFight
                && this.civilPlayers.Count==aveleCivilPlayersCount)
            {
                message = "Everything is okay!";
            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;

                message += $"Tommy live points: {this.mainPlayers.LifePoints}!" + Environment.NewLine;

                message += $"Tommy has killed: {this.civilPlayers.Count - aveleCivilPlayersCount} players!" +
                    Environment.NewLine;

                message += $"Left Civil Players: {aveleCivilPlayersCount}!";

            }

            return message;
        }
    }
}
