using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfEnergyInitialize = 50;
        private const int InitializeDecreaceEnergy = 5;
        public SleepyDwarf(string name) 
            : base(name, SleepyDwarfEnergyInitialize)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= InitializeDecreaceEnergy;
        }

    }
}
