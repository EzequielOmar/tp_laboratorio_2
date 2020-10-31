
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Crea una instancia de NacionalidadInvalidaException : Exception
        /// mensaje por defecto : "La nacionalidad no se condice con el número de DNI"
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI")
        {
        }
        /// <summary>
        /// Crea una instancia de NacionalidadInvalidaException : Exception
        /// pide string de mensaje a agregar.
        /// mensaje por defecto : "La nacionalidad no se condice con el número de DNI: "  + message
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message)
            : base("La nacionalidad no se condice con el número de DNI: " + message)
        {
        }
    }
}
