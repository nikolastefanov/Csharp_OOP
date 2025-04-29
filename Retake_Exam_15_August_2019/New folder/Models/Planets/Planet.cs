namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Planet : IPlanet
    {
        public Planet(string name)
        {
            this.Name = name;
           
        }
        public ICollection<string> Items { get; }
            

        public string Name
        {
            get { return this.Name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Invalid name!");
                }
                this.Name = value;
            }
        }
    }
}
