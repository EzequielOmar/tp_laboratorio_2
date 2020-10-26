using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum Eclases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region "Constructores"
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
                /*                                                         NO FUNCIONA, ERROR MAS ABAJO
                else if (indice == this.jornada.Count)
                    this.jornada.Add(value);
                */
            }
        }
        #endregion

        #region "Mètodos Estàticos"
        //guardar 
        // leer
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada aux in uni.jornada)
            {
                sb.Append("JORNADA:\n");
                sb.Append(aux.ToString());
                sb.Append("\n<------------------------------------------------->\n");
            }
            return sb.ToString();        
        }
        #endregion

        #region "Mètodos"
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region "Sobrecargas"
        public static Universidad operator +(Universidad uni, Eclases clases) 
        {
            /*Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase,
            un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la toman(todos los que
            coincidan en su campo ClaseQueToma).
            */
            int index = uni.jornada.FindIndex(x => x.Clase == clases);
            if (index == -1)
            {
                //uni.jornada[uni.jornada.Count] = new Jornada(clases, uni == clases); ERROR EN EJECUCION OBJECT NULL
                uni.jornada.Add(new Jornada(clases, uni == clases));
                foreach (Alumno aux in uni.alumnos)
                    if(!(aux != clases))
                        uni.jornada[uni.jornada.Count - 1].Alumnos.Add(aux);
            }
            return uni;
        }
        public static Universidad operator +(Universidad uni, Profesor i)
        {
            if (uni.profesores.FindIndex(x => x == i) == -1)
                uni.profesores.Add(i);
            return uni;
        }
        public static Universidad operator +(Universidad uni, Alumno a)
        {
            if (uni.alumnos.FindIndex(x => x == a) == -1)
                uni.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return uni;
        }
        public static Profesor operator ==(Universidad uni, Eclases clases)
        {
            int index = uni.profesores.FindIndex(x => x == clases);
            if (index != -1)
                return uni.profesores.ElementAt(index);
            else
                throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad uni, Eclases clases)
        {
            int index = uni.profesores.FindIndex(x => x != clases);        
            if (index != -1)
                return uni.profesores.ElementAt(index);
            else
                throw new SinProfesorException();
        }
        public static bool operator ==(Universidad uni, Profesor i)
        {
            return uni.profesores.Contains(i);
        }
        public static bool operator !=(Universidad uni, Profesor i)
        {
            return !(uni == i);
        }
        public static bool operator ==(Universidad uni, Alumno a)
        {
            return uni.alumnos.Contains(a);
        }
        public static bool operator !=(Universidad uni, Alumno a)
        {
            return !(uni == a);
        }
        #endregion
    }
}

/*
• Se accederá a una Jornada específica a través de un indexador.
• Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase,
un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que
coincidan en su campo ClaseQueToma).
• Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
• Leer de clase retornará un Universidad con todos los datos previamente serializados.
 * */
