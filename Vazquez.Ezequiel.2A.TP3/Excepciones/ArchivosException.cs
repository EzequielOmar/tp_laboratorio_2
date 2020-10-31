using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Crea una instancia de ArchivosException : Exception
        /// pide la instancia de Exception para usar de mensaje
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            :base(innerException.ToString())
        {
        }
        /// <summary>
        /// Crea una instancia de ArchivosException : Exception
        /// pide un mensaje para poner por defecto.
        /// pide la instancia de Exception.
        /// mensaje por defecto: mensaje + innerException.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public ArchivosException(string mensaje,Exception innerException)
            : base(mensaje + innerException.ToString())
        {
        }
    }
}
