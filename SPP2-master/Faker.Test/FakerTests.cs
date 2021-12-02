using System;
using System.Collections.Generic;
using System.Linq;
using CustomGenerator;
using Faker.Test.TestClasses;
using NUnit.Framework;
using SPP2_Faker.Faker;

namespace Faker.Test
{
    public class FakerTests
    {
        private readonly Faker _faker = new();

        [Test]
        public void TestGenerateImplementedPrimitive()
        {
            var primitiveOne = _faker.Create<float>();
            var primitiveTwo = _faker.Create<int>();
            Assert.AreEqual(typeof(float), primitiveOne.GetType());
            Assert.AreEqual(typeof(int), primitiveTwo.GetType());

        }
        
        [Test]
        public void TestGenerateNotImplementedPrimitive()
        {
            var primitive = _faker.Create<sbyte>();
            Assert.AreEqual(typeof(sbyte), primitive.GetType());
          
        }
        
        [Test]
        public void TestGenerateImplementedSystemType()
        {
            var system = _faker.Create<DateTime>();
            Assert.AreEqual(typeof(DateTime), system.GetType());
           
        }

        [Test]
        public void TestCycleDependencyResolver()
        {
            var generatedClass = _faker.Create<CycleDependencyExampleClass>();

            Assert.AreEqual(default, generatedClass.One.List[0].OneTwo.One);
            Assert.AreEqual(default, generatedClass.One.List[1].OneTwo.One);
            Assert.AreEqual(default, generatedClass.One.List[2].OneTwo.One);
        }

        [Test]
        public void TestGenerateNotImplementedSystemType()
        {
            var system = _faker.Create<Guid>();
            Assert.AreEqual(typeof(Guid), system.GetType());
          
        }
        
        [Test]
        public void TestGenerateListWithPrimitive()
        {
            var list = _faker.Create<List<ulong>>();
            Assert.AreEqual(typeof(List<ulong>), list.GetType());
            Assert.AreEqual(typeof(ulong), list.GetType().GetGenericArguments().Single());
            Assert.True(list.Count > 0);
        }
        
        [Test]
        public void TestGenerateListWithSystemType()
        {
            var list = _faker.Create<List<DateTime>>();
            Assert.AreEqual(typeof(List<DateTime>), list.GetType());
            Assert.AreEqual(typeof(DateTime), list.GetType().GetGenericArguments().Single());
            Assert.True(list.Count > 0);
        }
        
        [Test]
        public void TestGenerateClass()
        {
            var generatedClass = _faker.Create<ExampleClass>();

            Assert.AreNotEqual(default(DateTime), generatedClass.DateTime);

            Assert.AreNotEqual(default(char), generatedClass.Char);
            Assert.AreNotEqual(default(string), generatedClass.String);
            Assert.AreNotEqual(default(decimal), generatedClass.Decimal);
            Assert.AreNotEqual(default(int), generatedClass.Int);
            Assert.AreNotEqual(default(long), generatedClass.Long);
            Assert.AreNotEqual(default(ulong), generatedClass.Ulong);
           

        }
        
       
               

    }
}