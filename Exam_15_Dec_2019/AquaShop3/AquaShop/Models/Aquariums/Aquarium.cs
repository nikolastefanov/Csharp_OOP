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
       

            this.decorations = new List<IDecoration>();
            this.fishs = new List<IFish>();
        }

        public  string Name
        { get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
            => this.Decorations.Sum(x => x.Comfort);
        


    public ICollection<IDecoration> Decorations
    => this.decorations;
    public ICollection<IFish> Fish
    => this.fishs;

        public  void AddDecoration(IDecoration decoration);
        public  void AddFish(IFish fish);
        public  void Feed();
        public  string GetInfo();
        public  bool RemoveFish(IFish fish);
    }
}
