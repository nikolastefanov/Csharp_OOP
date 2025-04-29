namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Meteorologist : Astronaut,IAstronaut
    {
        public Meteorologist(string name)
            :base(name,90)
        {

        }
    }
}
