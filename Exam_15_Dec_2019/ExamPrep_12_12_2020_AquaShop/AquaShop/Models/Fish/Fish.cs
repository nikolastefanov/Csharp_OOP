﻿using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }
      
        public string Species
        {
            get { return this.species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }

      

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidFishPrice);
                }
                this.price = value;
            }

        }

        public int Size { get; protected set; }

        public abstract void Eat();
       
    }
}
