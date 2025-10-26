using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private readonly List<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.instruments = new List<IInstrument>();
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
                this.energy=value > 0 ? value : 0;
            }
        }

        public ICollection<IInstrument> Instruments
            => this.instruments.AsReadOnly();

        public void AddInstrument(IInstrument instrument)
        {
            instruments.Add(instrument);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }
    }
}
