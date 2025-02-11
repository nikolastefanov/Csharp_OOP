//using ExtendedDatabase;
using NUnit.Framework;
//using System.Linq;
//using System;
namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            long id = 1234567;
            string userName = "Pesho";

            Person person = new Person(id, userName);

            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(userName, person.UserName);
        }
        [Test]
        public void DatabaseExtended()
        {

            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");


            Person[] persons = new Person[] { pesho, gosho };

            Assert.IsNotNull(persons);

        }


        [Test]
        public void RangeAddIn15()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                new ExtendedDatabase.ExtendedDatabase(persons);
            });
        }
        [Test]
        public void RangeAddNormalCondituons()
        {

            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };

            int expectedCount = 2;

            Assert.AreEqual(expectedCount,
            (new ExtendedDatabase.ExtendedDatabase(persons)).Count);
        }
        [Test]
        public void AddPerson()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            Person[] persons = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            var newPerson = new Person(123456789, "Stamat");

            db.Add(newPerson);
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, db.Count);
        }
        [Test]
        public void AddSameUsernameShouldThrow()
        {

            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            Person[] persons = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            var newPerson = new Person(55667788, "Gosho");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }


        [Test]
        public void AddSameIdShouldThrow()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);
            var newPerson = new Person(11223344, "Stamat");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemove()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            db.Remove();

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, db.Count);
        }


        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var persons = new Person[] { };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {

            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }


        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindById(11223344);

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindById(123456789), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {

            Person pesho = new Person(11223344, "Pesho");
            Person gosho = new Person(55667788, "Gosho");

            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindById(-5), Throws.Exception);
        }
    }
}
    
