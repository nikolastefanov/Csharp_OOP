namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Geodesist : Astronaut,IAstronaut
    {
        public Geodesist(string name)
            :base(name,50)
        {

        }
    }
}
