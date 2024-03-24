namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Audi";
        private const string Model = "A8";
        private const double FuelConsumption = 8.5;
        private const double FuelCapacity = 80;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void ConstructorTest()
        {
            Car car = new(Make, Model, FuelConsumption, FuelCapacity);
            Assert.IsNotNull(car);
            Assert.AreEqual(Make, car.Make);
            Assert.AreEqual(Model, car.Model);
            Assert.AreEqual(FuelConsumption, car.FuelConsumption);
            Assert.AreEqual(FuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Make_ArgumentException(string make)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => new Car(make, Model, FuelConsumption, FuelCapacity));
            Assert.That(ae.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Model_ArgumentException(string model)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => new Car(Make, model, FuelConsumption, FuelCapacity));
            Assert.That(ae.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void FuelConsumption_ArgumentException(double fuelConsumption)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => new Car(Make, Model, fuelConsumption, FuelCapacity));
            Assert.That(ae.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void FuelCapacity_ArgumentException(double fuelCapacity)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => new Car(Make, Model, FuelConsumption, fuelCapacity));
            Assert.That(ae.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ArgumentException(double fuelAmount)
        {
            Car auto = new Car(Make, Model, FuelConsumption, FuelCapacity);

            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => auto.Refuel(fuelAmount));
            Assert.That(ae.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(80)]
        public void Refuel_CarIsRefueled(double fuelAmount)
        {
            Car auto = new Car(Make, Model, FuelConsumption, FuelCapacity);
            auto.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, auto.FuelAmount);
        }

        [Test]
        [TestCase(81)]
        [TestCase(120)]
        public void Refuel_MoreCapacityRefueled_ShoudBe_MaxFuelCapaciry(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.AreEqual(FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void Drive_InvalidOperationException()
        {
            car.Refuel(67);
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(()
                => car.Drive(800));
            Assert.That(ioe.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void Drive_ShoudBeValid()
        {
            car.Refuel(68);
            car.Drive(800);
            Assert.AreEqual(0, car.FuelAmount);
        }
    }
}