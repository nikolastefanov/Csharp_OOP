using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    class Backpack : IBag
    {
        public Backpack()
        {

        }
        public ICollection<string> Items { get; }
    }
}
