using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;

        public  Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
            this.Motorcycle = Motorcycle;
            this.NumberOfWins = NumberOfWins;
        }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.MotorcycleInvalid);
                }
                this.name = value;
            }
        }

        public Motorcycle Motorcycle { get; set; }
        

        public int NumberOfWins { get; set; }

        public bool CanParticipate { get; private set; }

     

        public void AddMotorcycle(Motorcycle motorcycle)
        {
            if (motorcycle==null)
            {
                throw new ArgumentNullException(
                    ExceptionMessages.MotorcycleInvalid);
            }
            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
            
        }

     

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
