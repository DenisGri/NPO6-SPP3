using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using AssemblyBrowserLib;
using AssemblyBrowserLib.Data;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AssemblyBrowserLibTests
{
    public class Tests
    {
        private AssemblyBrowser _assemblyBrowser;

        private List<DataContainer> _namespaces;
        private Assembly _lib;

        [SetUp]
        public void Init()
        {
            _assemblyBrowser = new AssemblyBrowser();
            _lib = Assembly.Load("TestableLib");
            _namespaces = _assemblyBrowser.GetAssemblyInfo(_lib.Location);
        }

        
        [Test]
        public void MembersCountTest()
        {
            var expectedCount = _lib.GetTypes().Length;
            Assert.AreEqual(_namespaces[0].Members.Count, expectedCount);
        }

        [Test]
        public void IsMockObjectRunMethod()
        {
            var mock = new Mock<IAssemblyBrowser>();
            mock.Setup(ab => ab.GetAssemblyContainersMock(It.IsAny<string>()));

            var mockAssemblyBrowser = new AssemblyBrowser(mock.Object);
            mockAssemblyBrowser.GetAssemblyContainersMock(_lib.Location);

            mock.Verify();
        }

        [Test]
        public void MemberCountMockObjectTest()
        {
            var mock = new Mock<AssemblyBrowser>();
            var mockAssemblyBrowser = new AssemblyBrowser(mock.Object);
            mockAssemblyBrowser.StartGetAssemblyInfo(_lib.Location);
            var assemblyBMockCount = mockAssemblyBrowser.GetAssemblyContainersMock(_lib.Location).Count;
            var assemblyBCount = _assemblyBrowser.GetAssemblyInfo(_lib.Location).Count;
            Assert.AreEqual(assemblyBMockCount, assemblyBCount);
        }

        [Test]
        public void NamespacesNameTest()
        {
            foreach (var @namespace in _namespaces.Where(@namespace => @namespace.Signature != "TestableLib" &&
                                                                       @namespace.Signature != "System"))
            {
                Assert.Fail($"Error in namespace name {@namespace.Signature}");
            }
        }

        [Test]
        public void ExtensionMethodName()
        {
            var types = _namespaces[0].Members;
            foreach (var type in types)
            {
                if (type.Signature == "ExtClass")
                {
                    bool flag = false;
                    foreach (var member in ((DataContainer)type).Members)
                    {
                        if (member.Signature == "CharCount")
                        {
                            flag = true;
                        }
                    }

                    Assert.IsTrue(flag);
                }
            }
        }

        [Test]
        public void ClassesNamesTest()
        {
            var types = _namespaces[0].Members;
            foreach (var type in types)
            {
                if (type.Signature != "public static class  ExtClass" && type.Signature != "public  class  TestClass1" && type.Signature != "private   class  TestClass2" && type.Signature != "public abstract class  TestClass3")
                {
                    Assert.Fail($"Error in type name {type.Signature}");
                }

            }
        }

        [Test]
        public void FieldNameTest()
        {
            var type = _namespaces[0].Members[1];
            if (type.Signature == "TestClass1")
            {
                Assert.AreEqual(((DataContainer)type).Members[0], "private int foo");
            }
        }
    }
}