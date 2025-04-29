using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut,IAstronaut
    {
        public Biologist(string name)
             :base(name, 70)
            {
            }
        public void Breath()
        {
            //this.Oxygen -= 5;
        }
    }
}
