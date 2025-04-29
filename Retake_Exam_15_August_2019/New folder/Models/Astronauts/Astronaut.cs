using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }
        
        public string Name
        { get { return this.name; }
            private set
              {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Astronaut name cannot be null or empty.");
                }
                this.name = value;
              }
         }

        public double Oxygen
        {
            get { return this.oxygen; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(
                        "Cannot create Astronaut with negative oxygen!");

                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
            => this.Oxygen <= 0;

        public IBag Bag { get; }

        public void Breath()
        {
            if (this.Oxygen-10>=0)
            {
                this.Oxygen -= 10;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
