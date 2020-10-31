using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        #region "Unit-Test"
        /// <summary>
        /// Testea que al cargar el mismo alumno dos veces, el programa lance una Excepcion del tipo AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void Alumno_Repetido()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                uni += a1;
                uni += a1;
                Assert.Fail("Sin excepción en Alumno_Repetido.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Testea que al solicitar un profesor para una clase, cuando no hay un profesor cargado en la lista,
        /// se lance una Excepcion del tipo SinProfesorException.
        /// </summary>
        [TestMethod]
        public void Sin_Profesor()
        {
            try
            {
                Universidad uni = new Universidad();
                uni += Universidad.EClases.SPD;
                Profesor prof = uni == Universidad.EClases.SPD;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
        /// <summary>
        /// Comprueba que la lista jornadas sea una instancia del tipo List<Jornada>
        /// </summary>
        [TestMethod]
        public void Coleccion_De_Jornadas()
        {
            Universidad uni = new Universidad();
            Assert.IsInstanceOfType(uni.Jornadas,typeof(List<Jornada>));
        }
        #endregion
    }
}
