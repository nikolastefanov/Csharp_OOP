using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitMotorcycleKonstuctor()
        {
            UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);

            Assert.AreEqual("M", um.Model);
            Assert.AreEqual(10, um.HorsePower);
            Assert.AreEqual(150, um.CubicCentimeters);
        }

        [Test]
        public void UnitRiderKonstrCorrectly()
        {
            UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);

            UnitRider ur = new UnitRider("R1", um);

            Assert.AreEqual("R1", ur.Name);
            Assert.AreEqual(um, ur.Motorcycle);

        }

        [Test]
        public void UnitRiderNullName()
        {
            UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);

            //    Assert.Throws<ArgumentNullException>(() =>
            //    new UnitRider("", um));
            //      Assert.Throws<ArgumentNullException>(() =>
            //      new UnitRider(" ", um));
            Assert.Throws<ArgumentNullException>(() =>
          new UnitRider(null, um));
            //        Assert.Throws<ArgumentNullException>(() =>
            // new UnitRider(string.Empty, um));

        }

        [Test]
        public void KonstuctorRaceEntry()
        {
            RaceEntry re = new RaceEntry();

            UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);

            UnitRider ur = new UnitRider("R1", um);

            re.AddRider(ur);

            Assert.AreEqual(1, re.Counter);

        }

        [Test]
        public void RaceEntryNullName()
        {
            //  UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);
            RaceEntry re = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            re.AddRider(null));

        }

        [Test]
        public void RaceEntryExistName()
        {
            //  UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);
            RaceEntry re = new RaceEntry();

            UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);

            UnitRider ur = new UnitRider("R1", um);

            re.AddRider(ur);

            Assert.Throws<InvalidOperationException>(() =>
            re.AddRider(ur));

        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            //  UnitMotorcycle um = new UnitMotorcycle("M", 10, 150);
            RaceEntry re = new RaceEntry();

            UnitMotorcycle um1 = new UnitMotorcycle("M1", 10, 150);

            UnitRider ur1 = new UnitRider("R1", um1);


            UnitMotorcycle um2 = new UnitMotorcycle("M2", 20, 150);

            UnitRider ur2 = new UnitRider("R2", um2);

            UnitMotorcycle um3 = new UnitMotorcycle("M3", 30, 150);

            UnitRider ur3 = new UnitRider("R3", um3);


            re.AddRider(ur1);
            re.AddRider(ur2);
            re.AddRider(ur3);

            Assert.AreEqual(20, re.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerLessTwoRider()
        {
          
            RaceEntry re = new RaceEntry();

            UnitMotorcycle um1 = new UnitMotorcycle("M1", 10, 150);

            UnitRider ur1 = new UnitRider("R1", um1);


          //  UnitMotorcycle um2 = new UnitMotorcycle("M2", 20, 150);
          //
          //  UnitRider ur2 = new UnitRider("R2", um2);

           


            re.AddRider(ur1);
          //  re.AddRider(ur2);
            

            Assert.Throws<InvalidOperationException>(()=>
            re.CalculateAverageHorsePower());
        }


    }
}