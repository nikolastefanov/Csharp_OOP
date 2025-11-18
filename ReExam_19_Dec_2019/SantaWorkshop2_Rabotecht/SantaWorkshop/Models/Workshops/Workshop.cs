using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            //by this loop iterate instruments

            while (dwarf.Energy > 0 && dwarf.Instruments.Any())
            {
                IInstrument currInstrument = dwarf.Instruments.First();

                //by this.loop we are crafting the present

                while (!present.IsDone() && dwarf.Energy > 0 && !currInstrument.IsBroken())
                {
                    //decrease dwarf'energy
                    dwarf.Work();
                    //decrease present's requiredEnergy
                    present.GetCrafted();
                    //decrease instrument's healt
                    currInstrument.Use();

                }

                //the instrument isBroken and needs to be removed

                if (currInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currInstrument);
                }

                //present is crafted sowe don't need to craft any more
                if (present.IsDone())
                {
                    //za vanchnia while
                    break;
                }
            }
        }
    }
}
