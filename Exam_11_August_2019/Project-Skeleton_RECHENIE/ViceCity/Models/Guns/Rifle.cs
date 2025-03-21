using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViceCity.Models.Guns.Contracts;

    public class Rifle : Gun
    {
      

        public Rifle(string name)
            :base(name,50,500)
        {
        }

        public override int Fire()
        {
           
            if (this.BulletsPerBarrel<5)
            {
                this.Reload(50);
            }
            int firedBullets = this.DecreaseBullets(5);
            return firedBullets;
        }
    }
}
