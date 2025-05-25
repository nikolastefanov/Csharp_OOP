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
        private int capacity;
            private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fishs;

        protected Aquarium(string name, int capacity)
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
   
        public int Capacity { get;  private set; }


        public int Comfort
            => this.decorations.Sum(c => c.Comfort);

        public ICollection<IDecoration> Decorations
            => this.decorations;

        public ICollection<IFish> Fish
            =>this.fishs;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }
    
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count==this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fishs.Add(fish);
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
            sb.AppendLine($"Fish: {(this.Fish.Any()?string.Join(", ",this.Fish.Select(x=>x.Name)):"none")}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            
            return sb.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishs.Remove(fish);
        }
    }
}
