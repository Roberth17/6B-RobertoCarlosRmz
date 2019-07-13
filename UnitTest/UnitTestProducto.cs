using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSB;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTestProductos
    {
        public UnitTestProductos()
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
            Producto producto = new Producto("Sabritas" , "Saladas" , "Frituras");
            Assert.IsTrue(producto.Agregar());
            Assert.IsNull(producto.Exception);
        }

        [TestMethod]
        public void TestModificar()
        {
            Producto producto = new Producto(1,"Sabritas" , "Saladas" , "Frituras");
            Assert.IsTrue(producto.Actualizar());
            Assert.IsNull(producto.Exception);
        }

        [TestMethod]
        public void TestEliminar()
        {
            Producto producto = new Producto(4);
            Assert.IsTrue(producto.Eliminar());
            Assert.IsNull(producto.Exception);
        }

        [TestMethod]
        public void TestConstructorUnParametros()
        {
            string nombre = "sabritas";
            string descripcion = "fritas";
            string categoria = "frituras";
            Producto producto = new Producto(nombre, descripcion, categoria);
            Assert.AreEqual(producto.IdProducto, 0);
            Assert.AreEqual(producto.Nombre, nombre);
            Assert.AreEqual(producto.Descripcion, descripcion);
            Assert.AreEqual(producto.Categoria, categoria);
        }

        [TestMethod]
        public void TestConstructorDosParametros()
        {
            int id = 1;
            string nombre = "sabritas";
            string descripcion = "fritas";
            string categoria = "frituras";
            Producto producto = new Producto(id, nombre,descripcion,categoria);
            Assert.AreEqual(producto.IdProducto, id);
            Assert.AreEqual(producto.Nombre, nombre);
            Assert.AreEqual(producto.Descripcion, descripcion);
            Assert.AreEqual(producto.Categoria, categoria);
        }

        [TestMethod]
        public void TestConstructorTresParametros()
        {
            int id = 1;
            Producto producto = new Producto(id);
            Assert.AreEqual(producto.IdProducto, id);
        }

        [TestMethod]
        public void TestRegistro()
        {
            Producto producto = new Producto("cheetos" , "queso" , "frituras");
            Assert.IsTrue(producto.GuardarDatos());
        }

        [TestMethod]
        public void TestObtenerTodo()
        {
            List<Producto> producto = Producto.ObtenerTodo();
            Assert.IsTrue(producto.Count > 0);
        }

        [TestMethod]
        public void TestLLenarTablaBaseDatos()
        {
            Producto producto = new Producto();
            Assert.IsTrue(producto.MostrarTodasTablas());
        }

        [TestMethod]
        public void TestObtenerDatosBuscarBaseDatosNombre()
        {
            Producto producto = new Producto();
            Assert.IsTrue(producto.ObtenerDatosBuscarPorNombre("sabritas"));
        }

        [TestMethod]
        public void TestObtenerDatosBuscarBaseDatosCategoria()
        {
            Producto producto = new Producto();
            Assert.IsTrue(producto.ObtenerDatosBuscarPorCategoria("frituras"));
        }

        [TestMethod]
        public void TestObtenerDatosBuscarEliminar()
        {
            Producto producto = new Producto();
            Assert.IsTrue(producto.ObtenerDatosBuscarEliminarPorNombre("sabritas"));
        }
    }
}
