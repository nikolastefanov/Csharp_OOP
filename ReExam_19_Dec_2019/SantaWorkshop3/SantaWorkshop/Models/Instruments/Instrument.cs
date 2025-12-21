using SantaWorkshop.Models.Instrument.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;
        private const int DesckreasePowerInitialize = 10;

        public Instrument(int power)
        {
            this.Power = power;
           
        }

        public int Power
        {
            get { return this.power; }
            private set
            {
                this.power=value > 0 ? value : 0;
            }
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power = Power - 10 > 0 ? Power-10 : 0;
        }
    }
}
