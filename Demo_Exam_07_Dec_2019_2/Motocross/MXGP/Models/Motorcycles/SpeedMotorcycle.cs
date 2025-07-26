
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, 125)
        {

        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set
            {
                if (value<50 && 69<value)
                {
                    throw new ArgumentException(
           string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                this.horsePower = value;
            }
        }
    }
}
