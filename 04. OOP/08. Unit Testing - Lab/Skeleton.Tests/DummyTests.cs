using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy target;

        [SetUp]
        public void SetUp()
        {
            target = new Dummy(10,10);
        }

        [Test]
        public void DummyHealthIsSetCorrectly()
        {
            Assert.AreEqual(10, target.Health);
        }

        [Test]
        [TestCase(5)]
        public void DummyHealthAttacked(int attachPoints)
        {
            target.TakeAttack(attachPoints);
            Assert.AreEqual(5, target.Health);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void DeadDummyThrowsExceptionIfAttacked(int attackPoints)
        {
            target.TakeAttack(attackPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                target.TakeAttack(attackPoints);
            });
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            target.TakeAttack(10);

            Assert.AreEqual(target.GiveExperience(), 10);
        }

        [Test]
        public void AliveDummyCannotGiveXp()
        {
            target.TakeAttack(8);

            Assert.Throws<InvalidOperationException>(() =>
            {
                target.GiveExperience();
            });
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void TestIsDeadMethod(int attackPoints)
        {
            target.TakeAttack(attackPoints);

            Assert.IsTrue(target.IsDead());
        }
    }
}