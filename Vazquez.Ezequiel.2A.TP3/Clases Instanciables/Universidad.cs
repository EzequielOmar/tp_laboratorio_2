using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region "Constructores"
        /// <summary>
        /// Crea una instancia de Universidad
        /// inicializa valores alumnos, jornada, profesores
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int indice]
        {
            get
            {
                if (indice >= this.jornada.Count || indice < 0)
                    return null;
                else
                    return this.jornada[indice];
            }
            set
            {
                if (indice >= 0 && indice < this.jornada.Count)
                    this.jornada[indice] = value;
            }
        }
        #endregion

        #region "Mètodos Estàticos"
        /// <summary>
        /// Guarda los datos de una instancia del tipo Universidad
        /// en un archivo formato Xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool respuesta = false;
            Xml < Universidad > xmlUni= new Xml<Universidad>();
            if (xmlUni.Guardar("Universidad.xml", uni))
                respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Lee los datos de una instancia del tipo Universidad
        /// desde un archivo en formato Xml.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {

            Universidad uni = new Universidad();
            Xml<Universidad> xmlUni = new Xml<Universidad>();
            xmlUni.Leer("Universidad.xml", out uni);
            return uni;
        }
        /// <summary>
        /// Retorna un string con los datos de todas las jornadas
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada aux in uni.jornada)
            {
                sb.Append("<------------------------------------------------->\n");
                sb.Append("JORNADA:\n");
                sb.Append(aux.ToString());
                sb.Append("<------------------------------------------------->\n");
            }
            return sb.ToString();        
        }
        #endregion

        #region "Mètodos"
        /// <summary>
        /// sobreescribe el metodo ToString()
        /// llama al metodo MostrarDatos y retorna string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Comprueba que el valor del tipo Eclases NO exista en ninguna de las jornadas
        /// cargadas en la Universidad, de ser asi, crea la jornada con esa clase,
        /// la agrega a la lista de jornadas, agrega a un profesor de haber disponible,
        /// y agrega a todos los alumnos que vallan a cursar esa clase
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, EClases clases) 
        {
            int index = uni.jornada.FindIndex(x => x.Clase == clases);
            if (index == -1)
            {
                uni.jornada.Add(new Jornada(clases, uni == clases));
                foreach (Alumno aux in uni.alumnos)
                    if (!(aux != clases))
                        uni.jornada[uni.jornada.Count - 1] += aux;
            }
            return uni;
        }
        /// <summary>
        /// Comprueba que el profesor NO exista en la lista de profesores,
        /// de ser asi, lo agrega a la lista.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, Profesor i)
        {
            if (uni.profesores.FindIndex(x => x == i) == -1)
                uni.profesores.Add(i);
            return uni;
        }
        /// <summary>
        /// Comprueba que el alumno NO exista en la lista de alumnos,
        /// de ser asi, lo agrega a la lista.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, Alumno a)
        {
            if (uni.alumnos.FindIndex(x => x == a || x.DNI == a.DNI) == -1)
                uni.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return uni;
        }
        /// <summary>
        /// Compara una instancia de Universidad y un valor del tipo EClases
        /// retorna true si existe un profesor disponible para dar esa clase
        /// caso contrario lanza SinProfesorException
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad uni, EClases clases)
        {
            int index = uni.profesores.FindIndex(x => x == clases );
            if (index != -1)
                return uni.profesores.ElementAt(index);
            else
                throw new SinProfesorException();
        }
        /// <summary>
        /// Compara una instancia de Universidad y un valor del tipo EClases
        /// retorna true si NO existe un profesor disponible para dar esa clase
        /// caso contrario lanza SinProfesorException.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad uni, EClases clases)
        {
            int index = uni.profesores.FindIndex(x => x != clases);        
            if (index != -1)
                return uni.profesores.ElementAt(index);
            else
                throw new SinProfesorException("No hay profesor que no pueda dar la clase.");
        }
        /// <summary>
        /// Compara una instancia de Universidad y una instancia de Profesor
        /// retorna true si el profesor esta en la lista de profesores.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad uni, Profesor i)
        {
            return uni.profesores.Contains(i);
        }
        /// <summary>
        /// Compara una instancia de Universidad y una instancia de Profesor
        /// retorna true si el profesor NO esta en la lista de profesores.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad uni, Profesor i)
        {
            return !(uni == i);
        }
        /// <summary>
        /// Compara una instancia de Universidad y una instancia de Alumno
        /// retorna true si el Alumno esta en la lista de Alumnos.
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad uni, Alumno a)
        {
            return uni.alumnos.Contains(a);
        }
        /// <summary>
        /// Compara una instancia de Universidad y una instancia de Alumno
        /// retorna true si el Alumno NO esta en la lista de Alumnos.
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad uni, Alumno a)
        {
            return !(uni == a);
        }
        #endregion
    }
}