using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia , Deudor , Becado}
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Constructor"
        /// <summary>
        /// Crea una instancia de Alumno : Universitario
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Crea una instancia de Alumno : Universitario
        /// inicializa claseQueToma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Crea una instancia de Alumno : Universitario
        /// inicializa estadoCuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Mètodos"
        /// <summary>
        /// Llama a base.MostrarDatos()
        /// agrega estadoCuenta
        /// llama a ParticiparEnClase()
        /// retorna string con los datos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Retorna string con claseQueToma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this.claseQueToma + "\n";
        }
        /// <summary>
        /// Llama a MostrarDatos() y retorna string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Compara una instancia de Alumno con un valor de tipo enumerable Universidad.EClases
        /// retorna true si el alumno toma esa clase y su estado de cuenta es distinto de Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool respuesta = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Compara una instancia de Alumno con un valor de tipo enumerable Universidad.EClases
        /// retorna true si el alumno no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool respuesta = false;
            if (a.claseQueToma != clase)
                respuesta = true;
            return respuesta;
        }
        #endregion
    }
}