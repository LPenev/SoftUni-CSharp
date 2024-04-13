namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;

    public class Tests
    {
        private RailwayStation station;
        private const string CurrentStation = "Sofia";
        private string trainInfo = "Sofia-Varna";
        private string falseTrainInfo = "Pleven-Varna";

        [SetUp]
        public void Setup()
        {
            station = new RailwayStation(CurrentStation);
        }

        [Test]
        public void Constructor_CorrectParameter()
        {
            Assert.AreEqual(CurrentStation, station.Name);
            Assert.AreEqual(0,station.DepartureTrains.Count);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Constructor_Name_ArgumentException(string testStation)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(()
                => station = new RailwayStation(testStation));
            Assert.That(ae.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [Test]
        public void Method_NewArrivalOnBoard()
        {
            station.NewArrivalOnBoard(CurrentStation);
            Assert.AreEqual(1, station.ArrivalTrains.Count());
            Assert.AreEqual(CurrentStation, station.ArrivalTrains.Dequeue());
        }

        [Test]
        public void TrainHasArrived_TrainNotFound()
        {
            station.ArrivalTrains.Enqueue(falseTrainInfo);
            string result = station.TrainHasArrived(trainInfo);
            Assert.AreEqual($"There are other trains to arrive before {trainInfo}.", result);
        }

        [Test]
        public void TrainHasArrived_CorrectTrain()
        {
            station.ArrivalTrains.Enqueue(trainInfo);
            string result = station.TrainHasArrived(trainInfo);
            Assert.AreEqual($"{trainInfo} is on the platform and will leave in 5 minutes.", result);
            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual(trainInfo, station.DepartureTrains.Peek());
            Assert.AreEqual(0,station.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasLeft_CorrectTrain()
        {
            station.DepartureTrains.Enqueue(trainInfo);
            bool result = station.TrainHasLeft(trainInfo);
            Assert.AreEqual(true, result);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasLeft_TrainNotFound()
        {
            station.DepartureTrains.Enqueue(trainInfo);
            bool result = station.TrainHasLeft(falseTrainInfo);
            Assert.AreEqual(false, result);
        }
    }
}