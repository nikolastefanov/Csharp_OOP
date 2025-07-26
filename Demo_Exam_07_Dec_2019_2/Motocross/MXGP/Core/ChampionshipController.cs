using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riders;
        readonly MotorcycleRepository motorcycles;
        readonly RaceRepository races;
            
        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();

        }


      
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riders.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(
      string.Format(ExceptionMessages.RiderExists, riderName));
            }

            if (motorcycles.GetByName(motorcycleModel)==null)
            {
                throw new InvalidOperationException(
       String.Format(ExceptionMessages.MotorcycleNotFound,motorcycleModel));
            }

            IRider rider = riders.GetByName(riderName);

            Motorcycle motorcycle = (Motorcycle)motorcycles.GetByName(motorcycleModel);

            rider.AddMotorcycle(motorcycle);

            return String.Format(
           OutputMessages.MotorcycleAdded,riderName,motorcycleModel);
          
        }

        public string AddRiderToRace(string raceName, string riderName)
        {

            if (races.GetByName(raceName)==null)
            {
                throw new InvalidOperationException(
               string.Format(ExceptionMessages.RaceNotFound,raceName));
            }
            if (riders.GetByName(riderName) == null)
            {
                throw new ArgumentException(
      string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = this.riders.GetByName(riderName);

            IRace race = this.races.GetByName(raceName);

            race.AddRider(rider);

            return String.Format(OutputMessages.RiderAdded,riderName,raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycles.GetByName(model)==null)
            {
                throw new ArgumentException(
          string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle;
            string msg;

            if (nameof(type)==type)
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
                msg = string.Format(OutputMessages.MotorcycleCreated, type);
            }
            else if (true)
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
                msg = string.Format(OutputMessages.MotorcycleCreated, type);
            }

            motorcycles.Add(motorcycle);

            return msg;
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name)!=null)
            {
                throw new ArgumentException(
     string.Format(ExceptionMessages.RaceExists,name));
            }

            IRace race = new Race(name, laps);

            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {

            if (riders.GetByName(riderName)==null)
            {
                throw new ArgumentException(
      string.Format(ExceptionMessages.RiderExists,riderName));
            }

            IRider rider = new Rider(riderName);

            riders.Add(rider);
         return string.Format(OutputMessages.RiderCreated,riderName);

         
        }

        public string StartRace(string raceName)
        {

            if (races.GetByName(raceName)==null)
            {
                throw new InvalidOperationException(
          string.Format(ExceptionMessages.RiderNotFound,raceName));
            }

            if (races.GetAll().Count<3)
            {
                throw new InvalidOperationException(
            string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IRace race = races.GetByName(raceName);

            var colection =
                race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints);

                
       
            races.Remove(race);

            string first = colection[0].Name;
            string second= colection[1].Name;
            string third= colection[2].Name;

            StringBuilder sb = new StringBuilder();
            
              sb.AppendLine($"Rider {first} wins {raceName} race.");
              sb.AppendLine($"Rider {second} is second in {raceName} race.");
              sb.AppendLine($"Rider {third} is third in {raceName} race.");
          



            throw new NotImplementedException();
        }
    }
}
