using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSB;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Insertar()
        {
           
            bool resultadoEsperado = true;

            Productos producto = new Productos();

            var result = producto.Agregar("Pepsi", "Pepsi Normal", "refresco");

            Assert.IsTrue(resultadoEsperado, result.ToString());
        }

        [TestMethod]
        public void Modificar()
        {

            bool resultadoEsperado = true;

            Productos producto = new Productos();

            var result = producto.Actualizar(1, "Coca Coola","Coca Cola lite","refresco");

            Assert.IsTrue(resultadoEsperado, result.ToString());
        }

        [TestMethod]
        public void Eliminar()
        {

            bool resultadoEsperado = true;

            Productos producto = new Productos();

            var result = producto.Eliminar(1);

            Assert.IsTrue(resultadoEsperado, result.ToString());
        }
    }
}
