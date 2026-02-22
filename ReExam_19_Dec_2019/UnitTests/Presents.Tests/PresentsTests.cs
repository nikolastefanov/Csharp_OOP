namespace Present.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    [TestFixture]
    public class PresentsTests
    {
       
        [SetUp]
        public void SetUp()
        {
            Bag bag = new Bag();
        }
        [Test]
        public void TestPresentWorkCorrectly()
        {
            string expName = "Stick";
            double expMagic = 100;
            Present present = new Present("Stick", 100);
            Assert.AreEqual(expName, present.Name);
            Assert.AreEqual(expMagic, present.Magic);
        }
        [Test]
        public void TestBagWorksCorrectly()
        {
            Bag bag = new Bag();
            Assert.IsNotNull(bag.GetPresents());
        }
         [Test]
       public void CreateExceptionWithLikeNullPresent()
         {
            Bag bag = new Bag();
            Present present = null;
           Assert.Throws<ArgumentNullException>(() => { bag.Create(present); },"Present is null");
        }
        [Test]
        public void CreateThrowsExceptionWithExistingSamePresent()
        {
            Bag bag = new Bag();
            Present present = new Present("Stick", 100);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => { bag.Create(present); },
               "This present already exists!");
        }
       // [Test]
        //public void CreateThrowsExceptionWithExistingPresent()
       // {
       //     Bag bag = new Bag();
        //    Present p1 = new Present("Stick", 100);
        //    Present p2 = new Present("Stick", 100);
        //    bag.Create(p1);

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
         //       bag.Create(p2);
         //   }, "This present already exists!");
       // }

        [Test]
        public void CreatePhysicallyAddThePresent()
        {
            Bag bag = new Bag();
            string name = "Stick";
            double magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            IReadOnlyCollection<Present> exp = new List<Present>() { p1, p2 };
            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act);
        }
        [Test]
        public void CreateReturnCorrectMesaage()
        {
            Bag bag = new Bag();
            Present p = new Present("Stick", 100);
            string exp= "Successfully added present Stick.";

            string res = bag.Create(p);
                Assert.AreEqual(exp, res);
        }
        [Test]
        public void RemovePhisicallyRemoveThePresent()
        {
            Bag bag = new Bag();
            Present p1 = new Present("Stick", 100);
            Present p2 = new Present("Stick", 100);
            bag.Create(p1);
            bag.Create(p1);
            bool res = bag.Remove(p1);

            IReadOnlyCollection<Present> exp = new List<Present>() { p2 };
          
            IReadOnlyCollection<Present> act = bag.GetPresents();

            Assert.IsTrue(res);

            CollectionAssert.AreEqual(exp, act);

        }
        [Test]
        public void TryRemovingNonExistingPresentReturnFalse()
        {
            Bag bag = new Bag();
            Present p1 = new Present("Stick", 100);
            bool res = bag.Remove(p1);

            Assert.IsFalse(res);
        }
        [Test]
        public void GetPresentLastMagicWorkCorrectly()
        {
            Bag bag = new Bag();
            Present p1 = new Present("Stick", 100);
            Present p2 = new Present("Stick", 50);
            Present p3 = new Present("Stick", 20);

            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);

            Present act = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(p3, act);
        }
        [Test]
        public void GetPresentWithLastrMagic()
        {
            Bag bag = new Bag();
            Assert.Throws<InvalidOperationException>(() => { bag.GetPresentWithLeastMagic();});
        }
        [Test]
        public void GetPresentReturnCorrectPresentNoDuplicate()
        {
            Bag bag = new Bag();
            string expName = "Stick";
            Present exp = new Present(expName, 100);
            Present p2 = new Present("Another", 50);

            bag.Create(exp);
            bag.Create(p2);
            Present act = bag.GetPresent(expName);
            Assert.AreEqual(exp, act);
        }
        [Test]
        public void GetPresentReturnFirstPresentWhenDuplicate()
        {
            Bag bag = new Bag();
            Present p1 = new Present("Stick", 100);
            Present p2 = new Present("Stick", 100);
            bag.Create(p1);
            bag.Create(p2);

            Present act = bag.GetPresent("Stick");
            Assert.AreEqual(p1, act);

        }
        [Test]
        public void GetPresentReturnNullWhenNameNotExist()
        {
            Bag bag = new Bag();
            Present p1 = new Present("Stick", 100);
            Present p2 = new Present("Stick", 100);
            bag.Create(p1);
            bag.Create(p2);

            string inalidName= "Non existing name";
            Present act = bag.GetPresent(inalidName);
            Assert.IsNull(act);

        }
    }
}
