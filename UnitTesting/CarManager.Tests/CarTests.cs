using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);

        }


        [Test]
        public void MakePropertiesShouldArgExpForInvalidValues()
        {

            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ModelPropertiesShouldArgExpForInvalidValues()
        {

            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionPropertiesShouldArgExpForBellowZero()
        {

            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -10;
            double fuelCapacity = 100;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionPropertiesShouldArgExpForZero()
        {

            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelCapacityPropertiesShouldArgExpBellowZero()
        {

            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = -100;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityPropertiesShouldArgExpForZero()
        {

            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 0;


            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void RefuelShouldNormaly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
            double expectedFuelAmount = 10;
            double actualyFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualyFuelAmount);
        }
        [Test]
        public void RefuelShouldTotalCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(150);
            double expectedFuelAmount = 100;
            double actualyFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualyFuelAmount);
        }
        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldArgExcIsBellowZero(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }
        [Test]
        public void ShouldDriveNormaly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void DriveInvalidOpExcFueiIsNotEnought()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }
    }
}