using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Crea una instancia de AlumnoRepetidoException : Exception
        /// mensaje por defecto: "Alumno repetido."
        /// </summary>
        public AlumnoRepetidoException()
            :this("Alumno repetido.")
        {
        }
        /// <summary>
        /// Crea una instancia de AlumnoRepetidoException : Exception
        /// pide un string de mensaje para usar por defecto.
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
