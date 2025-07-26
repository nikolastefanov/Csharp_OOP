using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, 450)
        {
            this.HorsePower = horsePower;
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set
            {
                if(value<70 && 100<value)
                {
                    throw new ArgumentException(
             string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                this.horsePower = value;
            }
        }
    }
}
