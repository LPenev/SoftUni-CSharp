using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int Attack = 10;
        private const int DurabilityPoints = 10;
        private const int Health = 10;
        private const int Experience = 10;

        [Test]
        public void Test1()
        {
            Axe axe = new Axe(Attack, DurabilityPoints);
            Dummy dummy = new Dummy(Health, Experience);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe drability doesn't change after attack.");
        }
    }
}