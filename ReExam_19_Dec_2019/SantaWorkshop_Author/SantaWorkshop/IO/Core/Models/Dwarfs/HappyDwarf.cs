﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int INIT_ENERGY = 100;
        public HappyDwarf(string name):base(name,INIT_ENERGY)
        {

        }
    }
}
