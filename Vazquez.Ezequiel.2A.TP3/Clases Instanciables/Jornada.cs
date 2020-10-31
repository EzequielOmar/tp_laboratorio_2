using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region "Constructores"
        /// <summary>
        /// Inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Crea una instancia de Jornada
        /// inicializa valores clase e instructor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get{return this.alumnos;}
            set{this.alumnos = value;}
        }
        public Universidad.EClases Clase
        {
            get{return this.clase;}
            set{this.clase = value;}
        }
        public Profesor Instructor
        {
            get{return this.instructor;}
            set{this.instructor = value;}
        }
        #endregion

        #region "Mètodos Estàticos"
        /// <summary>
        /// Guarda datos de una jornada en el archivo "Jornada.txt"
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto tx = new Texto();
            return tx.Guardar("Jornada.txt",jornada.ToString());
        }
        /// <summary>
        /// Lee los datos de una jornada desde el archivo "Jornada.txt"
        /// retorna string con los datos.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datos;
            Texto tx = new Texto();
            if (!tx.Leer("Jornada.txt", out datos))
                datos = "";
            return datos;
        }
        #endregion

        #region "Mètodos"
        /// <summary>
        /// Sobreescribe el metodo ToString()
        /// retorna los datos de la jornada con el profesor, y el listado de alumnos que cursan la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR:\n",this.Clase);
            sb.Append(this.instructor.ToString());
            sb.Append("\nALUMNOS:\n");
            foreach(Alumno aux in this.Alumnos)
            {
                sb.AppendLine();
                sb.Append(aux.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Compara una instancia de Jornada con una instancia de Alumno
        /// retorna true si el alumno esta cursando la clase. 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
             return !(a != j.Clase);
        }
        /// <summary>
        /// Compara una instancia de Jornada con una instancia de Alumno
        /// retorna true si el alumno no esta cursando la clase. 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return a != j.Clase;
        }
        /// <summary>
        /// Chequea que el alumno no este en la lista de alumnos,
        /// luego agrega el alumno a la lista.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j.alumnos.FindIndex(x => x == a) == -1)
                j.alumnos.Add(a);
            return j;
        }
        #endregion
    }
}