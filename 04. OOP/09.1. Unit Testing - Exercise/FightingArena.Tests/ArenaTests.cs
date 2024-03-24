namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena commonArena;
        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            commonArena = new Arena();
            warrior1 = new("Warrior1", 10, 100);
            warrior2 = new("Warrior2", 8, 120);
        }

        [Test]
        public void Constructor_Initialization()
        {
            Arena arena = new();
            Assert.NotNull(arena.Warriors);
        }

        [Test]
        public void Enroll_ValidData_ShouldAddWarrior()
        {
            commonArena.Enroll(warrior1);

            Assert.AreEqual(1, commonArena.Count);
        }

        [Test]
        public void Enroll_DuplicatedWarrior_ThrowsException()
        {
            commonArena.Enroll(warrior1);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => commonArena.Enroll(warrior1));
            Assert.AreEqual("Warrior is already enrolled for the fights!", ioe.Message);
        }

        [Test]
        public void Fight_ValidData_WarriorsShouldFight()
        {
            commonArena.Enroll(warrior1);
            commonArena.Enroll(warrior2);

            int hpAfterAttack = warrior1.HP - warrior2.Damage;
            commonArena.Fight("Warrior1", "Warrior2");

            Assert.AreEqual(hpAfterAttack, warrior1.HP);
        }

        [Test]
        public void Fight_AttackerDoesNotExists_ThrowsException()
        {
            commonArena.Enroll(warrior1);

            string missingName = "Warrior2";

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => commonArena.Fight(missingName, "Warrior1"));
            Assert.AreEqual($"There is no fighter with name {missingName} enrolled for the fights!", ioe.Message);
        }

        [Test]
        public void Fight_DefenderDoesNotExists_ThrowsException()
        {
            commonArena.Enroll(warrior1);

            string missingName = "Warrior2";

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => commonArena.Fight(warrior1.Name, missingName));
            Assert.AreEqual($"There is no fighter with name {missingName} enrolled for the fights!", ioe.Message);
        }
    }
}
