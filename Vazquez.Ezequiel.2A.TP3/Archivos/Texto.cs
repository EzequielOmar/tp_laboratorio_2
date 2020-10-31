using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region "Mètodos"
        /// <summary>
        /// Guarda los datos en formato de texto plano en un archivo.
        /// lanza ArchivosException en caso de error
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool respuesta = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo,false, Encoding.UTF8))
                {
                    sw.WriteLine(datos);
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar archivo de texto.",e.InnerException);
            }
            return respuesta;
        }
        /// <summary>
        /// Intenta leer los datos en formato de texto plano desde un archivo.
        /// lanza ArchivosException en caso de error
        /// guarda un string de los datos leidos en la variable datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool respuesta = false;
            StringBuilder sbAux = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(archivo, Encoding.UTF8))
                {
                    while ((datos = sr.ReadLine()) != null)
                        sbAux.Append(datos);
                    datos = sbAux.ToString();
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer archivo de texto.", e.InnerException);
            }
            return respuesta;
        }
        #endregion
    }
}
