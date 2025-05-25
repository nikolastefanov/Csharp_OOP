using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
       
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishs;

        protected Aquarium(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishs = new List<IFish>();
        }

        public string Name
        { 
            get { return this.name; }
             private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidAquariumName);
                 }
                   this.name = value;
            }
        }
        public int Capacity { get; }

        public int Comfort 
            => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations
            =>this.decorations.AsReadOnly();

        public ICollection<IFish> Fish 
            => this.fishs.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
           
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count>=this.Capacity)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NotEnoughCapacity);
            }
            fishs.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishs)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

           sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(this.Fish.Any()?string.Join(", ",this.Fish.Select(x=>x.Name)) : "none")}");
            sb.AppendLine($"Decorations: { decorations.Count}");
            sb.AppendLine($"Comfort: { this.Comfort}");
             



            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishs.Remove(fish);
        }
    }
}
