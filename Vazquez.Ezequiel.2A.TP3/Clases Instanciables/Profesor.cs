using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region "Constructor"
        /// <summary>
        /// inicializa el valor estatico random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Crea una instancia de Profesor : Universitario
        /// inicializa lista Queue claseDelDia
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
        /// <summary>
        /// Crea una instancia de Profesor : Universitario
        /// inicializa valores, inicializa lista Queue claseDelDia
        /// llama al metodo _randomClases()
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        #endregion

        #region "Mètodos"
        /// <summary>
        /// Metodo privado que asigna dos clases a un profesor de manera random
        /// acorde a la lista Enumerable Universidad.EClases.
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i < 2; i++)
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0,Enum.GetValues(typeof(Universidad.EClases)).Length));
        }
        /// <summary>
        /// Llama a base.MostrarDatos()
        /// Llama a ParticiparEnClase()
        /// retorna el string de los datos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Retorna el string de las clases asignadas a un profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DÍA:\n");
            foreach(Universidad.EClases clase in this.clasesDelDia)
                sb.AppendFormat("{0}\n", clase);
            return sb.ToString();
        }
        /// <summary>
        /// Llama a MostrarDatos() y retorna el string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Compara una instancia de Profesor con un valor enumerable del tipo Universidad.EClases
        /// retorna true si el profesor esta dando esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool respuesta = false;
            foreach(Universidad.EClases claseAux in i.clasesDelDia)
                if (claseAux.Equals(clase))
                    respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Compara una instancia de Profesor con un valor enumerable del tipo Universidad.EClases
        /// retorna true si el profesor no esta dando esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}