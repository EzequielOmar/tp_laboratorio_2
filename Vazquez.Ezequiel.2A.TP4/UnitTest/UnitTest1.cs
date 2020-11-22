using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using manejadorSQL;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// *Testea el metodo AgregarTexto de la clase manejadorQL.manejadorSql*
        /// </summary>
        [TestMethod]
        public void Test_AgregarTexto()
        {
            //Arrange
            manejadorSql sql = new manejadorSql();
            Libro l1 = new Libro(1, "Agregado de unitTest->Test_AgregarTexto", 420, Libro.EGenerosLibro.Ficción, 5);

            //Act y Assert
            Assert.AreEqual(true, sql.AgregarTexto(l1));
        }
        /// <summary>
        /// *Testea el metodo ModificarTexto de la clase manejadorQL.manejadorSql*
        /// </summary>
        [TestMethod]
        public void Test_ModificarTexto()
        {
            //Arrange
            manejadorSql sql = new manejadorSql();
            Carrito<Texto> carrito = sql.Libreria;
            carrito.Items[carrito.Items.Count-1].Titulo = "Modif de unitTest->Test_ModificarTexto";

            //Act y Assert
            Assert.AreEqual(true, sql.ModificarTexto(carrito.Items[carrito.Items.Count - 1]));
        }
        /// <summary>
        /// *Testea el metodo EliminarTexto de la clase manejadorQL.manejadorSql*
        /// </summary>
        [TestMethod]
        public void Test_EliminarTexto()
        {
            //Arrange
            manejadorSql sql = new manejadorSql();
            Carrito<Texto> carrito = sql.Libreria;

            //Act y Assert
            Assert.AreEqual(true, sql.EliminarTexto(carrito.Items[carrito.Items.Count - 1]));
        }
    }
}
