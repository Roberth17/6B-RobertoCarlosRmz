using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSB;
using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    class UnitTestBaseDeDatos
    {
        public UnitTestBaseDeDatos()
        {

        }

        private TestContext testInstance;
        public TestContext testContext
        {
            get { return testInstance; }
            set { testInstance = value; }
        }

        [TestMethod]
        public void TestInsertar()
        {
            BaseDeDatos basedatos = new BaseDeDatos();
            Assert.IsNull(basedatos.Exception);
        }

        [TestMethod]
        public void TestInsertar()
        {
            BaseDeDatos basedatos = new BaseDeDatos();
            Assert.
        }
    }
}
