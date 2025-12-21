using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instrument.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;

        protected Dwarf(string name,int energy)
        {
            this.Name = name;
            this.energy = energy;
            this.Instruments = new List<IInstrument>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }


        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if (value<=0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }

        public ICollection<IInstrument> Instruments { get; }
      

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public virtual void Work()
        {
            if (this.Energy-10<=0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 10;
            }
        }
    }
}
