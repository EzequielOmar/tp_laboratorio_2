using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia , Deudor , Becario}

        private Universidad.Eclases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Constructor"
        public Alumno()
        {
            //si se llama este contructor automaticamente llama primero a Universitario(), y este a Persona()
            //inicializar atributos?
            //pasa al otro constructor inicializando por defecto?
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.Eclases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.Eclases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Mètodos"
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}", this.estadoCuenta);
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this.claseQueToma;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecargas"
        public static bool operator ==(Alumno a, Universidad.Eclases clase)
        {
            bool respuesta = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public static bool operator !=(Alumno a, Universidad.Eclases clase)
        {
            bool respuesta = false;
            if (a.claseQueToma != clase)
            {
                respuesta = true;
            }
            return respuesta;
        }
        #endregion
    }
}