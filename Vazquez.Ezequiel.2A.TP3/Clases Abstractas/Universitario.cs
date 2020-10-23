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
        public Universitario()
        {
            //si se llama este contructor automaticamente llama primero a Persona()
            //pasa al otro constructor inicializando por defecto?
            //inicializar legajo en 0?

            //this.legajo = 0;
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
            ///Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
            bool respuesta = false;
            //como era para saber que clase hija es y comparar? :O:O:O
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public override bool Equals(object obj)
        {
            bool respuesta = false;
            if (obj is Universitario)
            {
                respuesta = (Universitario)obj == this;
            }
            return respuesta;
        }
        #endregion
    }
}
