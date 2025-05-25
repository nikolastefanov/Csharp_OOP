using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        //        ⦁	decorations - DecorationRepository 
        //⦁	aquariums - collection of IAquarium

        private DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;


        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
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

            aquariums.Add(aquarium);

            return string.Format(
                OutputMessages.SuccessfullyAdded, aquariumType);
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

            decorations.Add(decoration);

            return string.Format(
                OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName,
            string fishType, string fishName, string fishSpecies, decimal price)
        {

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IFish fish = null;

            string result;

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

            //   if (fish.GetType()==typeof(FreshwaterAquarium) &&
            //       aquarium.GetType()==typeof(FreshwaterAquarium))
            //   {
            //       aquarium.AddFish(fish);
            //       result=string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName);
            //   }
            //   else if (fish.GetType() == typeof(SaltwaterAquarium) &&
            //       aquarium.GetType() == typeof(SaltwaterAquarium))
            //   {
            //       aquarium.AddFish(fish);
            //       result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            //   }
            //   else
            //   {
            //       
            //         result=OutputMessages.UnsuitableWater;
            //   }
            //
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
            IAquarium aquarium =
                aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal priceD = aquarium.Decorations.Sum(x => x.Price);
            decimal priceF = aquarium.Fish.Sum(x => x.Price);
            decimal res = priceD + priceF;

            return string.Format(OutputMessages.AquariumValue, aquariumName, res);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = 
                aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration==null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = aquariums.FirstOrDefault(
                x => x.Name == aquariumName);

            aquarium.AddDecoration(decoration);

            decorations.Remove(decoration);

            return string.Format(
                OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            //  "{aquariumName} ({aquariumType}):
            //  Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            //    Decorations: { decorationsCount}
            //  Comfort: { aquariumComfort}
            //  { aquariumName} ({ aquariumType}):
            //   Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            //  Decorations: { decorationsCount}
            //  Comfort: { aquariumComfort}

            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {

                sb.AppendLine(aquarium.GetInfo());

            }

            return sb.ToString().TrimEnd();

        }
    }
}
