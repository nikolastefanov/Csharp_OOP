namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViceCity.Models.Guns.Contracts;

    public class Pistol : Gun
    {
        private static int bulletsPerBarrel;
        private static int totalBullets;

        public Pistol(string name)
            : base(name, 10, 100)
        {
          
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel<1)
            {
                this.Reload(10);
            }
            int firedBullets = this.DecreaseBullets(1);
            return firedBullets;
        }
    }
}
