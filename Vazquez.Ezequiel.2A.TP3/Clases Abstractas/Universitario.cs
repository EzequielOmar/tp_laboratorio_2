using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region "Constructor"
    
        public Universitario()             //VALORES POR DEFECTO
            : this(0,"","","",ENacionalidad.Argentino)
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Metodos"
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
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool respuesta = false;
            if(pg1.GetType().Name == pg2.GetType().Name && pg1.legajo == pg2.legajo)
                respuesta = true;
            return respuesta;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
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
