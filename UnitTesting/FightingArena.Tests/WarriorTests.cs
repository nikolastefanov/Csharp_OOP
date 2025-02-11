using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            string expName = "Pesho";
            int expDmg = 15;
            int expHp = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual(expName, warrior.Name);
            Assert.AreEqual(expDmg, warrior.Damage);
            Assert.AreEqual(expHp, warrior.HP);

        }

        [Test]
        public void TestWithEmtyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("", 25, 100);
            });
        }

        [Test]
        public void TestWithNullName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(" ", 25, 100);
            });
        }
            [Test]
            public void TestWithNullDmg()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior("Pesho ", 0, 100);
                });

            }
        [Test]
        public void TestWithNullHp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho ", 25, -10);
            });

        }
        [Test]
        public void TestWithLessNullDmg()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho ",-25, 100);
            });

        }

        [Test]
        public void TestAttackCorretly()
        {
            int expAttHp = 95;
            int expDefHp = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Gosho", 5, 90);

            attacker.Attack(deffender);

            Assert.AreEqual(expAttHp, attacker.HP);
            Assert.AreEqual(expDefHp, deffender.HP);
        }

        [Test]
        public void TestWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior deffender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackingEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior deffender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }
        [Test]
        public void AttakingstongerEnemy()
        {
            Warrior attcker = new Warrior("Pesho", 10, 35);
           Warrior deffender = new Warrior("Gosho",40,100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attcker.Attack(deffender);
            });
        }
        [Test]
        public void TestKillingEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior deffender = new Warrior("Gosho", 45, 40);

            int expAttHp = 55;
            //100-45
            int expDefHp = 0;

            attacker.Attack(deffender);

            Assert.AreEqual(expAttHp, attacker.HP);
            Assert.AreEqual(expDefHp, deffender.HP);
        }
    }
}