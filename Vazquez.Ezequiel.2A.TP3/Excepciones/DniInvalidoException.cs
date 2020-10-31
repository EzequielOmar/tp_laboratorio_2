using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Crea una instancia de DniInvalidoException : Exception
        /// mensaje por defecto: "El DNI ingresado no es un número válido."
        /// </summary>
        public DniInvalidoException()
            : base("El DNI ingresado no es un número válido.")
        {
        }
        /// <summary>
        /// Crea una instancia de DniInvalidoException : Exception
        /// mensaje por defecto: "El DNI ingresado no es un número válido."
        /// pide la instancia de Exception
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : base("El DNI ingresado no es un número válido.", e)
        {
        }
        /// <summary>
        /// Crea una instancia de DniInvalidoException : Exception
        /// pide string de mensaje para agregar al por defecto.
        /// mensaje por defecto: "El DNI ingresado no es un número válido: " + message
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            : this(message, null)
        {
        }
        /// <summary>
        /// Crea una instancia de DniInvalidoException : Exception
        /// pide string de mensaje para agregar al por defecto.
        /// pide la instancia de Exception
        /// mensaje por defecto: "El DNI ingresado no es un número válido: " + message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base("El DNI ingresado no es un número válido: " + message, e)
        {
        }
    }
}
