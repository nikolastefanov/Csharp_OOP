using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using System.Linq;

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

            if (aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType== "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            string result = string.Format(
                OutputMessages.SuccessfullyAdded, aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            string result = string.Format(
                OutputMessages.SuccessfullyAdded, decorationType);

            return result;
        }

        public string AddFish(string aquariumName, 
            string fishType, string fishName
            , string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType== "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType== "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            string result;

            if (fish.GetType()==typeof(FreshwaterAquarium) &&
                aquarium.GetType()==typeof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                result = string.Format(
                    OutputMessages.EntityAddedToAquarium, fishType,aquariumName);
            }
            else if (fish.GetType() == typeof(SaltwaterAquarium) &&
                 aquarium.GetType() == typeof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                result = string.Format(
                    OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                result = OutputMessages.UnsuitableWater;
            }

            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string FeedFish(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string InsertDecoration(
            string aquariumName, string decorationType)
        {
            var decoration = this.decorations
                .FindByType(decorationType);

            var aquarium = this.aquariums
                .FirstOrDefault(x => x.Name==aquariumName);

            if (decoration==null)
            {

                string msg = string.Format(
                    ExceptionMessages.InexistentDecoration, decorationType);

                throw new InvalidOperationException(msg);
            }

            aquarium.AddDecoration(decoration);

            decorations.Remove(decoration);

            string result = string.Format(
                OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

            return result;
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
