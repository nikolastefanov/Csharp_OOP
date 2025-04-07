namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;
    using BlueOrigin;
    using System.Linq;
    using System.Collections.Generic;
   
    public class SpaceshipTests
    {
        [Test]
        public void ConstructorInitialzy()
        {
            string name = "Pesho";
            int oxygenInPercentage = 50;

            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            string expName = "Pesho";
            int expOxygen = 50;

            Assert.AreEqual(expName, astronaut.Name);
            Assert.AreEqual(expOxygen, astronaut.OxygenInPercentage);
        }
        [Test]
        public void SpaceShipConstructorInitialize()
        {
            string name = "Salut";
            int capacity = 50;

            Spaceship spaceship = new Spaceship(name, capacity);

            string expName = "Salut";
            int expcapacity = 50;

            Assert.AreEqual(expName, spaceship.Name);
            Assert.AreEqual(expcapacity, spaceship.Capacity);
        }
        [Test]
        public void SpaceShipNullName()
        {
            string name =null;
            int capacity = 50;

            Assert.Throws<ArgumentNullException>(() =>new Spaceship(name, capacity));
        }
        [Test]
        public void SpaceShipEmptyName()
        {
            string name = string.Empty;
            int capacity = 50;

            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }
        [Test]
        public void SpaceShipCapacity()
        {
            string name = "Salut";
            int capacity = -10;

            Assert.Throws<ArgumentException>(() => new Spaceship(name, capacity));

        }
        [Test]
        public void SpaceShipMoreCount()
        {

            Astronaut astronaut = new Astronaut("Pesho",50);
            //Astronaut gosho = new Astronaut("Gosho", 40);

            //List<Astronaut> astronauts = new List<Astronaut>();
            //astronauts.Add(pesho);
            //astronauts.Add(gosho);

            Spaceship spaceship = new Spaceship("Salut", 1);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Gosho", 40)));
        }
        [Test]
        public void SpaceShipExisting()
        {

            Astronaut astronaut = new Astronaut("Pesho", 50);
            

            Spaceship spaceship = new Spaceship("Salut", 2);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void TestRemoved()
        {
            Astronaut astronaut = new Astronaut("Pesho", 50);
            Spaceship spaceship = new Spaceship("Salut", 1);
            //List<Astronaut> astronauts = new List<Astronaut>();
            spaceship.Add(astronaut);

            spaceship.Remove(astronaut.Name);

        }
        [Test]
        public void TestCount()
        {
            int expCount = 1;
            Astronaut astronaut = new Astronaut("Pesho", 50);

            Spaceship spaceship = new Spaceship("Salut", 2);

            spaceship.Add(astronaut);

            int actCount = spaceship.Count;

            Assert.AreEqual(expCount, actCount);
        }
    }
}