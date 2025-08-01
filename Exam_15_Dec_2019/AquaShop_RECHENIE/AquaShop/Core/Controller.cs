﻿using AquaShop.Core.Contracts;
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

            if (aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType== "SaltwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            string result = string.Format(OutputMessages.SuccessfullyAdded
                , aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType== "Plant")
            {
                decoration = new Plant();
            }
            else if (decorationType== "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);

            string result = string.Format(OutputMessages
                .SuccessfullyAdded, decorationType);

            return result;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            //if (fishType==nameof(FreshwaterAquarium))
            if (fishType =="FreshwaterAquarium")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType=="SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidFishName);
            }

            var aquarium = this.aquariums
                .FirstOrDefault(x => x.Name == aquariumName);
            string result;

            if (fish.GetType() == typeof(FreshwaterAquarium) &&
                aquarium.GetType() == typeof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                 result = string.Format(OutputMessages
                    .EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fish.GetType() == typeof(SaltwaterAquarium) &&
                aquarium.GetType() == typeof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                 result = string.Format(OutputMessages
                    .EntityAddedToAquarium, fishType, aquariumName);
            }
            else 
            {
                result = OutputMessages.UnsuitableWater;
             }
            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(
                x => x.Name==aquariumName);
            var totalPrice = aquarium.Fish.Sum(p => p.Price) +
                aquarium.Decorations.Sum(p => p.Price);

            string result = string.Format(OutputMessages
                .AquariumValue, aquariumName, totalPrice);
            return result;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium=this.aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
               
            }
            string result = string.Format(OutputMessages
                    .FishFed, aquarium.Fish.Count);
            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations
                .FindByType(decorationType);

            var aquarium = this.aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            if (decoration==null)
            {
                string exceptionMassege = String.Format(ExceptionMessages
                    .InexistentDecoration, decorationType);
                throw new InvalidOperationException(exceptionMassege);
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            string result = String.Format(OutputMessages
                .EntityAddedToAquarium, decorationType, aquariumName);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
