using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {

        private string name;
        private int capacity;
        private ICollection<IFish> fishs;
        private ICollection<IDecoration> decorations;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.fishs = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
            {
                get{return this.Decorations.Sum(c => c.Comfort);}
            }
        
    public ICollection<IDecoration> Decorations
    => this.decorations;

    public ICollection<IFish> Fish
    => this.fishs;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count==this.Capacity)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in fishs)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(this.Fish.Any()?string.Join(", ",this.Fish.Select(f=>f.Name)): "none")}");
            sb.AppendLine($"Decorations: { this.Decorations.Count}");
            sb.AppendLine($"Comfort: { this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishs.Remove(fish);
        }
    }
}
