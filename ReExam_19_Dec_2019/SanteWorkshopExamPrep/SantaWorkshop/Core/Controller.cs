using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType== "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return String.Format(
                OutputMessages.DwarfAdded, dwarfType, dwarfName);


        
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf==null)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            return String.Format(
                OutputMessages.InstrumentAdded, power, dwarfName);

        }

        public string AddPresent(string presentName, int energyRequired)
        {

            IPresent present = 
                new Present(presentName, energyRequired);

            return String.Format(
                OutputMessages.PresentAdded, presentName);
          
        }

        public string CraftPresent(string presentName)
        {

            Workshop workshop = new Workshop();

            IPresent present = 
                presents.FindByName(presentName);

            ICollection<IDwarf> dwarves = this.dwarfs.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(
                    ExceptionMessages.DwarfsNotReady);
            }

            while (dwarves.Any())
            {
                IDwarf currDwarf = dwarves.First();

                workshop.Craft(present, currDwarf);

                if (currDwarf.Energy==0)
                {
                    dwarves.Remove(currDwarf);
                    this.dwarfs.Remove(currDwarf);
                }
                if (!currDwarf.Instruments.Any())
                {
                    dwarves.Remove(currDwarf);
                }
                if (present.IsDone())
                {
                    break;
                }

            }
            string result;

            if (present.IsDone())
            {
                result = String.Format(
                    OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                result = String.Format(
                    OutputMessages.PresentIsNotDone, presentName);
            }

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int countCraftedPresents =
                this.presents.Models.Count(x => x.IsDone());

            sb.AppendLine($"{countCraftedPresents} presents are done!");

            sb.AppendLine("Dwarfs info:");

            foreach (IDwarf dwarf in dwarfs.Models)
            {
                int countInstruments = 
                    dwarf.Instruments.Count(x => x.IsBroken());

                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
