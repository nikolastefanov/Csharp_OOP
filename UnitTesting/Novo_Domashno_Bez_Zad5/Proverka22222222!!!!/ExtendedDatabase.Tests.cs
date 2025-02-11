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
            Person[] person = new Person[2];

         

            int actualCount = person.Length;

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void RangeAddIn()
        {
            Person[] data = new Person[15];

            int expectedLenght = 15;
            int actualLenght = data.Length;

            Assert.AreEqual(expectedLenght, actualLenght);
        }
        [Test]
        public void OutRangeAdd()
        {
            Person[] data = new Person[17];

            //Assert.Throws<ArgumentException>(() => data.Length);
        }
        [Test]
        public void ConstructorExtendedDB()
        {
            pesho=new Person(11223344,"Pesho")
                gosho = new Person(55667788."Gosho");

            var exp = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase(exp);
            Assert.IsNotNull(db);

        }
        [Test]
        public void TestAddRange()
        {
            var persons = new Person[16];
            Assert.Throws<ArgumentException>(() =>
            var db = new ExtendedDatabase.ExtendedDatabase(persons));
        }
        [Test]
        public void TestNormalCodition()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");

            var persons = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase.ExtendedDatabase(persons);
            int expCount = 2;

            assert.AreEqual(expCount, db.Count);
        }

        [Test]
        public void TestShouldAdd()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };

            var db new ExtendedDatabase.ExtendedDatabase(peersons);
            var newPerson = new Person(1234567, "Stamat");

            db.Add(new Person);
            int expCount = 3;
            Assert.AreEqual(expCount, db.Count);
        }

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);
            var newPerson = new Person(11223344, "Gosho");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }
        Test]
        public void AddSameIdShouldThrow()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);
            var newPerson = new Person(11223344, "Stamat");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemove()
        {

            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
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

            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
        var db = new ExtendedDatabase.ExtendedDatabase(persons);

        var expected = pesho;
        var actual = db.FindByUsername("Pesho");

        Assert.That(actual, Is.EqualTo(expected));
           }


        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {

            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {

            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }


        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindById(11223344);

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindById(123456789), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            pesho = new Person(11223344, "Pesho")
                gosho = new Person(55667788."Gosho");
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(() => db.FindById(-5), Throws.Exception);
        }
    }

}
