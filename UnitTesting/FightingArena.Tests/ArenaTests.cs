using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void CostructorCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(warrior));

        }

        [Test]
        public void EnrollingExistingwarrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void CountCorrectly()
        {
            int expCount = 1;

            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expCount, this.arena.Count);
        }

        [Test]
        public void FightWorksCorrectly()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Gosho",5, 50);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight(attacker.Name, deffender.Name);

            int expAttHp = 95;
            //Pesho
            int expDefHp = 40;
            //Gosho

            Assert.AreEqual(expAttHp, attacker.HP);
            Assert.AreEqual(expDefHp, deffender.HP);
        }

        [Test]
        public void FightingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, deffender.Name);
            });
        }
    }
}
