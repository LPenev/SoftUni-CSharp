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
            Assert.AreEqual(0, emptyDatabase.Count);
        }

        [Test]
        public void ConstructorDatabaseFull() 
        {
            int count = fullDatabase.Count;
            Assert.NotNull(fullDatabase);
            Assert.AreEqual(16, count);
        }

        [Test]
        public void AddRange_ArgumentException()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Database(personsUpperMax));
            Assert.That(ae.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void AddPerson_ShoudBeOnePersonAdded()
        {
            emptyDatabase.Add(person);
            Assert.AreEqual(1, emptyDatabase.Count);
        }

        [Test]
        public void AddPersonIntoFullDatabaseInvalidOperationException()
        {

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            fullDatabase.Add(person));
            Assert.That(ioe.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddPersonAlreadyExistInvalidOperationException()
        {
            emptyDatabase.Add(person);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            emptyDatabase.Add(person));
            Assert.That(ioe.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddPersonAlreadyIDExistInvalidOperationException()
        {
            emptyDatabase.Add(person);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => emptyDatabase.Add(new Person(16, "User116")));
            Assert.That(ioe.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemovePersonFromEmptyDatabaseInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => emptyDatabase.Remove());
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            fullDatabase.Remove();
            Assert.AreEqual(15, fullDatabase.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameWennUsernameIsNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                fullDatabase.FindByUsername(input);
            });
        }

        [Test]
        public void FindByUsernameWennUsernameNotExist()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => fullDatabase.FindByUsername("noExist"));
            Assert.That(ioe.Message, Is.EqualTo("No user is present by this username!"));
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
            ArgumentOutOfRangeException FindByIdOutOfRangeEx = Assert.Throws<ArgumentOutOfRangeException>(() 
                => fullDatabase.FindById(-1));
            Assert.That(FindByIdOutOfRangeEx.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdInvalidOperationException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() 
                => fullDatabase.FindById(333));
            Assert.That(ioe.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdShoudBeValid()
        {
            emptyDatabase.Add(person);
            Assert.AreEqual(person, emptyDatabase.FindById(16));
        }
    }
}