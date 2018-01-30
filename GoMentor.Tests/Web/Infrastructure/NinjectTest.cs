using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Reflection;
using System.Linq;

namespace GoMentor.Tests.Web.Infrastructure
{
    /// <summary>
    /// Test Ninjects Bindings
    /// </summary>
    [TestClass]
    public class NinjectTest
    {
      
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestBindings()
        {
            //Create Kernel and Load Assembly GoMentor.Web
            var kernel = new StandardKernel();
            kernel.Load(new Assembly[] { Assembly.Load("GoMentor.Web") });

            var query = from types in Assembly.Load("GoMentor.Domain").GetExportedTypes()
                        where types.IsInterface
                        where types.Namespace.StartsWith("GoMentor.Domain.Interfaces")
                        select types;

            foreach(var type in query.ToList())
            {
                kernel.Get(type);
            }



        }
    }
}
