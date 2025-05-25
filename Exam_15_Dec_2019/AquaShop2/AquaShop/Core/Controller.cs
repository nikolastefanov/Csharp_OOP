using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType=="FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType=="SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return String.Format(OutputMessages
                .EntityAddedToAquarium, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType== "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType=="Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages
                .SuccessfullyAdded, decorationType);
            
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType=="Freshwaterfish")
            {
                fish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            else if (fishType=="SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidFishType);
            }

            var aquarium = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            string result = string.Empty;
            if (fish.GetType()==typeof(FreshwaterFish) &&
                aquarium.GetType()==typeof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                result = String.Format(
                    OutputMessages.EntityAddedToAquarium
                    , fishType, aquariumName);
            }
            else if (fish.GetType()==typeof(SaltwaterAquarium) &&
                aquarium.GetType()==typeof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);

                result = String.Format(
                    OutputMessages.EntityAddedToAquarium
                    , fishType, aquariumName);
            }
            else
            {
                result = OutputMessages.UnsuitableWater;
                
            }

            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums
                 .FirstOrDefault(a => a.Name == aquariumName);

            decimal totalPrice = aquarium.Fish.Sum(p => p.Price) +
                aquarium.Decorations.Sum(p => p.Price);

            

            return string.Format(
                OutputMessages.AquariumValue
                , aquariumName, totalPrice);

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums
                .FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return String.Format(
                OutputMessages.FishFed
                , aquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            var decoration = this.decorations
                .FindByType(decorationType);

            if (decoration==null)
            {
                string excepMessage = string.Format(
                    ExceptionMessages.InexistentDecoration
                    , decorationType);

                throw new InvalidOperationException(excepMessage);
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            string outpMessage = string.Format(
                OutputMessages.EntityAddedToAquarium
                , decorationType, aquariumName);

            return outpMessage;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
