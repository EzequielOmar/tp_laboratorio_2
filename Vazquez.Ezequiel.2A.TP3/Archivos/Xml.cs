using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region "Mètodos"
        /// <summary>
        /// Guarda los datos en formato xml en un archivo de texto
        /// lanza  ArchivosException en caso de error
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool respuesta = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer,datos);
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar archivo Xml.",e.InnerException);
            }
            return respuesta;
        }
        /// <summary>
        /// Intenta leer los datos en formato xml de un archivo de texto
        /// lanza  ArchivosException en caso de error
        /// guarda en la variable datos los datos leidos.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool respuesta = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer archivo Xml.",e);
            }
            return respuesta;
        }
        #endregion
    }
}
