using LoginSB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTestLogin
    {
        public UnitTestLogin()
        {

        }

        private TestContext testInstance;
        public TestContext testContext
        {
            get { return testInstance; }
            set { testInstance = value; }
        }

        //LOGIN
        [TestMethod]
        public void TestConsultarLogin()
        {
            Login login = new Login();
            string usuario = "admin";
            string contraseña = "1234";
            Assert.IsTrue(login.ValidarLogin(usuario, contraseña));
        }
    }
}
