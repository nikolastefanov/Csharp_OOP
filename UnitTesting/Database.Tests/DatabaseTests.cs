
using NUnit.Framework;


namespace Tests
{
    using System;
    using System.Linq;
    using Database;


    [TestFixture]
    public class DatabaseTests
    { 

        [SetUp]
        public void Setup()
        {
         
        }

        [Test]
        public void AddArray()
        {

            int[] arr = new int[16];

            Database database = new Database(arr);

            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddElement()
        {
            int[] arr = new int[2];
            Database database = new Database(arr);

           int expectedCount = 3;
            
            database.Add(3);

            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void InvalidCountInput()
        {
            //InvalidOperationException("Array's capacity must be exactly 16 integers!");

            int[] arr = new int[16];

            for (int i = 0; i < 16; i++)
            {
                arr[i] = i;
            }
            Database database = new Database(arr);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(17));

        }
        [Test]
        public void RemovedElement()
        {
            int[] arr = new int[3];
            Database database = new Database(arr);

            int expectedCount = 2;

            database.Remove();

            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RemovedAllElement()
        {
            // InvalidOperationException
            int[] arr = new int[1];

            Database database = new Database(arr);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
                                   database.Remove());
                
        }
        [Test]
        public void CopyArray()
        {
            // Fetch()

            int[] arr = new int[16];

            for (int i = 0; i < 16; i++)
            {
                arr[i] = i;
            }
            Database database = new Database(arr);


            int[] expectedArr = new int[16];

            for (int i = 0; i < 16; i++)
            {
                expectedArr[i] = i;
            }

            CollectionAssert.AreEqual(expectedArr, database.Fetch());
        }
    }
}