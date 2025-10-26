using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {

            while (dwarf.Energy>0 && dwarf.Instruments.Any())
            {
                IInstrument currInsrument = dwarf.Instruments.First();

                while (!present.IsDone() && dwarf.Energy>0 && !currInsrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();

                    currInsrument.Use();
                }

                if (currInsrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currInsrument);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
            
        }
    }
}
