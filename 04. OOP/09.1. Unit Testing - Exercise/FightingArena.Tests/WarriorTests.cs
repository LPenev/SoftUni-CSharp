namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;

        Arena commonArena;
        Warrior warrior1;
        Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            commonArena = new Arena();
            warrior1 = new("Warrior1", 10, 100);
            warrior2 = new("Warrior2", 8, 120);
            commonArena.Enroll(warrior1);
            commonArena.Enroll(warrior2);
        }

        [Test]
        public void Constructor_Initialization()
        {
            Warrior warrior = new("Warrior", 10, 100);

            Assert.NotNull(warrior);
            Assert.AreEqual("Warrior", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("  ")]
        public void Name_IsNullOrWhiteSpace_ThrowsException(string input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior(input, 10, 100));
            Assert.That(ae.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Damage_ZeroOrNegative_ThrowsException(int input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior("Warrior", input, 100));
            Assert.That(ae.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HP_Negative_ThrowsException()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior("Warrior", 10, -1));
            Assert.That(ae.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Attack_SuccessfulAction_NoKill()
        {
            int hpLeftAttacker = warrior1.HP - warrior2.Damage;
            int hpLeftDefender = warrior2.HP - warrior1.Damage;
            warrior1.Attack(warrior2);

            Assert.That(warrior1.HP, Is.EqualTo(hpLeftAttacker));
            Assert.That(warrior2.HP, Is.EqualTo(hpLeftDefender));
        }

        [Test]
        public void Attack_SuccessfulAction_Kill()
        {
            Warrior warrior = new("Warrior", 200, 1000);
            commonArena.Enroll(warrior);

            int hpLeftAttacker = warrior.HP - warrior2.Damage;

            warrior.Attack(warrior2);

            Assert.That(warrior.HP, Is.EqualTo(hpLeftAttacker));
            Assert.That(warrior2.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_AttackerHpIsTooLow_ThrowsException()
        {
            Warrior warrior = new("Warrior", 200, 25);
            commonArena.Enroll(warrior);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => warrior.Attack(warrior2));
            Assert.That(ioe.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Attack_DefenderHpIsTooLow_ThrowsException()
        {
            Warrior warrior = new("Warrior", 200, 25);
            commonArena.Enroll(warrior);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => warrior1.Attack(warrior));
            Assert.That(ioe.Message, Is.EqualTo($"Enemy HP must be greater than {MinAttackHp} in order to attack him!"));
        }

        [Test]
        public void Attack_TooStrongDefender_ThrowsException()
        {
            Warrior warrior = new("Warrior", 150, 2000);
            commonArena.Enroll(warrior);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => warrior1.Attack(warrior));
            Assert.That(ioe.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}