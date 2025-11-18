using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {

        private const int INIT_ENERGY = 50;
        private const int ADD_WORK_ENERGY_DECR = 5;
        public SleepyDwarf(string name) : base(name, INIT_ENERGY)
        {

        }

        public override void Work()
        {
            //Will decrease Energy by 10 units
            base.Work();
            this.Energy -= ADD_WORK_ENERGY_DECR;
        }
    }
}
