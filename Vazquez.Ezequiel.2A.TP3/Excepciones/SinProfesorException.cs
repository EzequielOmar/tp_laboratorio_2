using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Crea una instancia de SinProfesorException : Exception
        /// mensaje por fdefecto: "No hay Profesor para la clase."
        /// </summary>
        public SinProfesorException()
            :this("No hay Profesor para la clase.")
        {
        }
        /// <summary>
        /// Crea una instancia de SinProfesorException : Exception
        /// Pide el mensaje a lanzar.
        /// </summary>
        /// <param name="mensaje"></param>
        public SinProfesorException(string mensaje)
            :base(mensaje)
        {
        }
    }
}
