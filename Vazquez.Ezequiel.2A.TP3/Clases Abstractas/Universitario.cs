using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region "Constructor"
        /// <summary>
        /// Crea una instancia de Universitario : Persona
        /// </summary>
        public Universitario()             
        {
        }
        /// <summary>
        /// Crea una instancia de Universitario : Persona
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Llama a base.ToString(), agrega el valor de legajo, y devuelve el string de los datos
        /// </summary>
        /// <returns></returns>
        virtual protected string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NùMERO: {0}\n",this.legajo);
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Compara dos instancias de Universitario
        /// retorna true si los legajo son iguales, y son instancias de la misma clase
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool respuesta = false;
            if(pg1.GetType().Name == pg2.GetType().Name && pg1.legajo == pg2.legajo)
                respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Compara dos instancias de Universitario
        /// retorna true si los legajo son distintos, o son instancias de distinta clase 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Llama internamente a la sobre carga ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;
            if (obj is Universitario)
                respuesta = (Universitario)obj == this;
            return respuesta;
        }
        #endregion
    }
}
