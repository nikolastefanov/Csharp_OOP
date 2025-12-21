using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instrument.Contracts;
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
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy>0 && !dwarf.Instruments.Any())
            {
                IInstrument currentInstrument = 
                    dwarf.Instruments.First();

                while (!present.IsDone() && dwarf.Energy>0 && !currentInstrument.IsBroken())
                {
                    //namalqva energiata na dgudge
                    dwarf.Work();
                    //namalava energy na podaraka
                    present.GetCrafted();

                    // 
                    currentInstrument.Use();                  
                }

                if (currentInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currentInstrument);
                }

                if (present.IsDone())
                {
                    break;
                }

            }
        }
    }
}
