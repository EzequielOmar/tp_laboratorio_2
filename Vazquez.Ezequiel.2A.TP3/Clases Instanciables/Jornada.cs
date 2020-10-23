using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.Eclases clase;
        private Profesor instructor;

        #region "Constructores"
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.Eclases clase, Profesor instructor)
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
        public Universidad.Eclases Clase
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
        //guardar y leer
        #endregion

        #region "Mètodos"
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR:\n",this.Clase);
            sb.Append(this.instructor.ToString());
            sb.Append("\nALUMNOS:\n");
            foreach(Alumno aux in this.Alumnos)
            {
                sb.Append(aux.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"

        #endregion
    }
}

/*
 * Atributos Profesor, Clase y Alumnos que toman dicha clase.
• Se inicializará la lista de alumnos en el constructor por defecto.
• Una Jornada será igual a un Alumno si el mismo participa de la clase.
• Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
• ToString mostrará todos los datos de la Jornada.
• Guardar de clase guardará los datos de la Jornada en un archivo de texto.
• Leer de clase retornará los datos de la Jornada como texto.
 * */
