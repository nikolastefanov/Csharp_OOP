namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {
        [Test]
        public void ConstrPresent()
        {
            Present p = new Present("p1", 1);

            Assert.AreEqual(1, p.Magic);
            Assert.AreEqual("p1", p.Name);
        }

        [Test]
        public void CreatePresentBag()
        {
            Present p = new Present("p1", 1);

            Bag b = new Bag();



            Assert.AreEqual("Successfully added present p1.", b.Create(p));

        }

        [Test]
        public void CreatePresentBagNull()
        {
            Present p = new Present("p1", 1);

            Bag b = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            b.Create(null));

        }
        [Test]
        public void CreatePresentBagExist()
        {
            Present p = new Present("p1", 1);

            Bag b = new Bag();
            b.Create(p);

            Assert.Throws<InvalidOperationException>(() =>
            b.Create(p));


        }
        [Test]
        public void Remove()
        {
            Present p = new Present("p1", 1);

            Bag b = new Bag();
            b.Create(p);

            Assert.AreEqual(true, b.Remove(p));
        }

        [Test]
        public void LastMagic()
        {
            Present p1 = new Present("p1", 1);
            Present p2 = new Present("p2", 1);
            Bag b = new Bag();
            b.Create(p1);
            b.Create(p2);

            Assert.AreEqual(p1, b.GetPresentWithLeastMagic());
        }
        [Test]
        public void ByName()
        {
            Present p1 = new Present("p1", 1);
            Present p2 = new Present("p2", 1);
            Bag b = new Bag();
            b.Create(p1);
            b.Create(p2);

            Assert.AreEqual(p1, b.GetPresent("p1"));
        }

        [Test]
        public void AssertCollection()
        {
            Present p1 = new Present("p1", 1);
            Present p2 = new Present("p2", 1);
            Bag b = new Bag();
            b.Create(p1);
            b.Create(p2);

         //  ICollection<Present> exp= (p1, p2);
         //
         // CollectionAssert.AreEqual({p1,p2},b.GetPresents());
        }
    }
}
