namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database fullDatabase;
        private Database emptyDatabase;
        private int[] ints = Enumerable.Range(1,16).ToArray();

        [SetUp]
        public void StartUp()
        {
            emptyDatabase = new Database();
            fullDatabase = new Database(ints);
        }

        [Test]
        public void ConstructorEmptyDatabase()
        {
            Assert.NotNull(emptyDatabase);
            Assert.AreEqual(0, emptyDatabase.Count);
        }

        [Test]
        public void ConstructorFullDatabase()
        {
            Assert.AreEqual(16, fullDatabase.Count);
        }

        [Test]
        public void Count()
        {
            Assert.AreEqual(16, fullDatabase.Count);
        }

        [Test]
        public void Add()
        {
            emptyDatabase.Add(12);
            Assert.AreEqual(1, emptyDatabase.Count);
        }

        [Test]
        public void AddInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                fullDatabase.Add(17);
            });
        }

        [Test]
        public void Remove()
        {
            fullDatabase.Remove();
            Assert.AreEqual(15, fullDatabase.Count);
        }

        [Test]
        public void RemoveInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => { emptyDatabase.Remove(); });
        }

        [Test]
        public void Fetch()
        {
            int[] target = fullDatabase.Fetch();
            Assert.AreEqual(ints, target);
        }
    }
}
