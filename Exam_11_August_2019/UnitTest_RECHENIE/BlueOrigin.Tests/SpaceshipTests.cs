namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
       [Test]
       public void CountShouldreturnCorrectRes()
        {
            Spaceship spaceship = new Spaceship("NameONe", 10);

            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void NameShouldReturnCorrectRes()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 10);

            Assert.AreEqual("Name ONe", spaceship.Name);
        }

        [Test]
        public void NameNullShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Spaceship(null, 10));
        }

        [Test]
        public void CapacityShoultReturnCorrectRes()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 10);

            Assert.AreEqual(10, spaceship.Capacity);
        }

        [Test]
        public void CapacityLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            new Spaceship("Name One", -10));
        }

        [Test]
        public void AddMethodWithoutCapacityShouldThrowException()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 1);
            spaceship.Add(new Astronaut("Name One", 10));

            Assert.Throws<InvalidOperationException>(() =>
            spaceship.Add(new Astronaut("Name One", 10)));
        }

        [Test]
        public void AddMethodAlreadyExistAstronaut()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 10);
            spaceship.Add(new Astronaut("Name One", 10));

            Assert.Throws<InvalidOperationException>(() =>
            spaceship.Add(new Astronaut("Name One", 10)));
        }

        [Test]
        public void AddMethodShouldSuccessfullyAddAstronaut()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);

            spaceship.Add(new Astronaut("name One", 10));

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void RemoveWithInvalidNameShouldReturnFalse()
        {
            Spaceship spaceship = new Spaceship("Name One", 10);
            spaceship.Add(new Astronaut("Name One", 10));

            Assert.False(spaceship.Remove("Name Two"));
        }
           
        [Test]
        public void RemoveWithInvalidNameShouldReturnTrue()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 10);

            spaceship.Add(new Astronaut("Name One", 10));

            Assert.True(spaceship.Remove("Name One"));
        }

        [Test]
        public void RemoveWithValidNameshouldSuccesffulyRemoveAstronaut()
        {
            Spaceship spaceship = new Spaceship("Name ONe", 10);
            spaceship.Add(new Astronaut("Name One", 10));

            spaceship.Remove("Name One");

            Assert.AreEqual(0, spaceship.Count);
        }
    }
}