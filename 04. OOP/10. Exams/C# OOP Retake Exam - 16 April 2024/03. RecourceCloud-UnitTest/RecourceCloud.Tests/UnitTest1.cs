using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud department = null;
        private string[] args = new string[] { "1", "TestLabel", "TestName" };

        [SetUp]
        public void Setup()
        {
            department = new DepartmentCloud();
        }

        [Test]
        public void ConstructorInitLists()
        {
            Assert.AreEqual(0, department.Tasks.Count);
            Assert.AreEqual(0, department.Resources.Count);
        }

        [Test]
        public void LogTaskArgsLengthNotCorrectLength()
        {
            string[] argsFalseLength2 = { "1", "2" };
            string[] argsFalseLength4 = { "1", "2", "3", "4" };
            Assert.Throws<ArgumentException>(() => department.LogTask(argsFalseLength2));
            Assert.Throws<ArgumentException>(() => department.LogTask(argsFalseLength4));
            Assert.AreEqual(0, department.Tasks.Count);
        }

        [Test]
        public void LogTaskArgsNull()
        {
            string[] argsNull = { "1", "2", null };
            Assert.Throws<ArgumentException>(() => department.LogTask(argsNull));
            Assert.AreEqual(0, department.Tasks.Count);
        }

        [Test]
        public void LogTaskAlreadyLoged()
        {
            department.LogTask(args);
            Assert.AreEqual("TestName is already logged.", department.LogTask(args));
            Assert.AreEqual(1, department.Tasks.Count);
        }

        [Test]
        public void LogTaskNormal()
        {
            Assert.AreEqual("Task logged successfully.", department.LogTask(args));
            Assert.AreEqual(1, department.Tasks.Count);
            Assert.IsNotNull(department.Tasks.FirstOrDefault(x => x.ResourceName == "TestName"));
        }

        [Test]
        public void CreateResourceWhenNull()
        {
            Assert.IsFalse(department.CreateResource());
            Assert.AreEqual(0, department.Resources.Count);
        }

        [Test]
        public void CreateResourceSuccessfull()
        {
            string[] args1 = new string[] { "2", "TestLabel2", "TestName2" };

            department.LogTask(args);
            department.LogTask(args1);
            var createResource = department.CreateResource();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createResource);
                Assert.AreEqual(1, department.Resources.Count);
                Assert.AreEqual(1, department.Tasks.Count);
            });
        }

        [Test]
        public void TestResourceNotFound()
        {
            Assert.IsNull(department.TestResource("NoName"));
        }

        [Test]
        public void TestResourceValidName()
        {
            department.LogTask(args);
            department.CreateResource();

            var resource = department.Resources.First();
            Assert.AreEqual(resource, department.TestResource("TestName"));
            Assert.IsTrue(resource.IsTested);
        }
    }
}