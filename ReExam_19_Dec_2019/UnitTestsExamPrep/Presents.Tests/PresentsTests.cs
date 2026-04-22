namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {

        [SetUp]
      public void SetUp()
        {

        }

        [Test]
        public void PresentCorrect()
        {
            Present pr = new Present("Stack", 10);

            Assert.AreEqual(pr.Name, "Stack");

            Assert.AreEqual(pr.Magic, 10);
        }

        [Test]
        public void CorrectAddPresent()
        {
            Present pr = new Present("Stack", 10);

            Bag b = new Bag();

            b.Create(pr);

            Assert.IsNotNull(b.GetPresents());
        }
        [Test]
        public void AddPresentNullPresent()
        {
            Present pr = null;

            Bag b = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                b.Create(pr);
            });
        }

        [Test]
        public void AddPresentExistPresent()
        {
            Present pr = new Present("Stack",100);

            Bag b = new Bag();

            b.Create(pr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                b.Create(pr);
            });
        }

        [Test]
        public void Remove()
        {
            Present pr1 = new Present("Stack", 100);
            Present pr2 = new Present("Ball", 50);
            Bag b = new Bag();

            b.Create(pr1);
            b.Create(pr2);

            bool res=b.Remove(pr2);

            Assert.AreEqual(res, true);

        }

        [Test]
        public void Magic()
        {

        }
    }
}
