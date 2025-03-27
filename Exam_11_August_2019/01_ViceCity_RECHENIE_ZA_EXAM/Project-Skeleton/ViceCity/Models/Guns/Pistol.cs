namespace ViceCity.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    public class Pistol : Gun
    {
        private const int InitializeBulletsPerBarrel = 10;
        private const int IniatializeTotalBullets = 100;
        private const int BulletsPerFire = 1;
        public Pistol(string name)
            : base(name, InitializeBulletsPerBarrel, IniatializeTotalBullets)
        {
          
        }
        public override int Fire()
        {
            if (this.BulletsPerBarrel<BulletsPerFire)
            {
                this.Reload(InitializeBulletsPerBarrel);
            }
            int firedBullets = this.DecreaseBullets(BulletsPerFire);

            return firedBullets;
        }

        protected void Reload(int barelCapacity)
        {
            if (this.TotalBullets>=barelCapacity)
            {
                this.BulletsPerBarrel = BulletsPerBarrel;

                this.TotalBullets -= barelCapacity;
            }
        }

        protected int DecreaseBullets(int bullets)
        {
            //bullets=1;

            int firedBullets = 0;

            if (this.BulletsPerBarrel-bullets>=0)
            {
                this.BulletsPerBarrel -= bullets;
                firedBullets = bullets;
            }

            return firedBullets;
        }

    }
}
