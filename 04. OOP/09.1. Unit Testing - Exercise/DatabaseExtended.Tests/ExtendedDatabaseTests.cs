namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database emptyDatabase;
        private Database fullDatabase;
        private Person[] personsMax;
        private Person[] personsUpperMax;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            emptyDatabase = new Database();
            personsMax = new Person[16];
            personsUpperMax = new Person[17];

            for(int i = 0; i < 16; i++)
            {
                personsMax[i] = new Person( i, $"User{i}");
                personsUpperMax[i] = new Person( i, $"User{i}");
            }

            fullDatabase = new Database(personsMax);
            personsUpperMax[16] = new Person(16, "User16"); 

            person = personsUpperMax[16];
        }

        [Test]
        public void ConstructorDatabaseNotNull()
        {
            Assert.NotNull(emptyDatabase);
        }

        [Test]
        public void ConstructorDatabaseFull() 
        {
            int count = fullDatabase.Count;
            Assert.AreEqual(16, count);
        }

        [Test]
        public void ConstructorArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                emptyDatabase = new Database(personsUpperMax);
            });
        }

        [Test]
        public void AddPersonShoudBeOnePersonAdded()
        {
            emptyDatabase.Add(person);
            Assert.AreEqual(1, emptyDatabase.Count);
        }

        [Test]
        public void AddPersonIntoFullDatabaseInvalidOperationException()
        {

            Assert.Throws<InvalidOperationException>(() => 
            {
                fullDatabase.Add(person);
            });
        }

        [Test]
        public void AddPersonAlreadyExistInvalidOperationException()
        {
            emptyDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDatabase.Add(person);
            });
        }

        [Test]
        public void AddPersonAlreadyIDExistInvalidOperationException()
        {
            emptyDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDatabase.Add(new Person(16,"User16"));
            });
        }

        [Test]
        public void RemovePersonFromEmptyDatabaseInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDatabase.Remove();
            });
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            fullDatabase.Remove();
            Assert.AreEqual(15, fullDatabase.Count);
        }

        [Test]
        public void FindByUsernameWennUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                fullDatabase.FindByUsername("");
            });
        }

        [Test]
        public void FindByUsernameWennUsernameNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                fullDatabase.FindByUsername("User");
            });
        }

        [Test]
        public void FindByUsernameShoudBeValid()
        {
            emptyDatabase.Add(person);
            Assert.AreEqual(person, emptyDatabase.FindByUsername("User16"));
        }

        [Test]
        public void FindByIdArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                fullDatabase.FindById(-1);
            });
        }

        [Test]
        public void FindByIdInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                fullDatabase.FindById(11001);
            });
        }

        [Test]
        public void FindByIdShoudBeValid()
        {
            emptyDatabase.Add(person);
            Assert.AreEqual(person, emptyDatabase.FindById(16));
        }
    }
}