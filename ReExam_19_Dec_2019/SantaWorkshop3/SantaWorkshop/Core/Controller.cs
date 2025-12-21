using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instrument.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private const int EnergyLevel = 50;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType== "SleepyDwarf")
            {
                 dwarf = new SleepyDwarf(dwarfName);
            }
            else if (dwarfType== "HappyDwarf")
            {
                 dwarf = new HappyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return String.Format(OutputMessages
                .DwarfAdded
                , dwarfType
                , dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {

            IDwarf dwarf = dwarfs.FindByName(dwarfName);

            if (dwarf==null)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            return String.Format(OutputMessages
                .InstrumentAdded
                , power
                , dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            return String.Format(OutputMessages
                .PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            string output = string.Empty;

            Workshop workshop = new Workshop();

            IPresent present = this.presents.FindByName(presentName);

            ICollection<IDwarf> dwarves = this.dwarfs.Models
                .Where(d => d.Energy >= EnergyLevel)
                .OrderByDescending(d => d.Energy)
                .ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(
                    ExceptionMessages.DwarfsNotReady);
            }

            while (dwarves.Any())
            {
                IDwarf currentDwarf = dwarves.First();

                workshop.Craft(present, currentDwarf);

                if (currentDwarf.Energy==0)
                {
                    dwarves.Remove(currentDwarf);
                    dwarfs.Remove(currentDwarf);
                }

                if (!currentDwarf.Instruments.Any())
                {
                    dwarfs.Remove(currentDwarf);
                }

                if (present.IsDone())
                {
                    break;
                }

            }

            if (!present.IsDone())
            {
                output = String.Format(OutputMessages
                    .PresentIsNotDone
                    , presentName);
            }
            else
            {
                output = String.Format(OutputMessages
                    .PresentIsDone, presentName);
            }

            return output;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int countCraftedPresents = this.presents
                .Models
                .Count(p => p.IsDone());

            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (IDwarf dwarf in this.dwarfs.Models)
            {
                int countInstruments = dwarf
                    .Instruments
                    .Count(i => i.IsBroken());

                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
