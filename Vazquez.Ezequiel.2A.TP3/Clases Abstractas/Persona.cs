using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad {Argentino,Extranjero}
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Constructor"
        /// <summary>
        /// Crea una instancia de Persona
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Crea una instancia de Persona
        /// inicializa nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Crea una instancia de Persona
        /// valida e inicializa dni tipo int
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Crea una instancia de Persona
        /// valida e inicializa dni tipo string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Propiedades"
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public int DNI
        {
            get{return this.dni;}
            set{this.dni = Persona.ValidarDni(this.Nacionalidad, value);}
        }
        public string StringToDNI
        {
            set{this.dni = Persona.ValidarDni(this.Nacionalidad, value);}
        }
        public string Nombre
        {
            get{return this.nombre;}
            set{this.nombre = Persona.ValidarNombreApellido(value);}
        }
        public string Apellido
        {
            get{return this.apellido;}
            set{this.apellido = Persona.ValidarNombreApellido(value);}
        }
        #endregion

        #region "Validadores"
        /// <summary>
        /// Valida que el dni argentino este entre 1 y 89999999
        /// o lanza NacionalidadInvalidaException
        /// Valida que el dni Extranjero este entre 89999999 y 99999999
        /// o lanza NacionalidadInvalidaException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
            }
            return dato;
        }
        /// <summary>
        /// Remueve puntos y comas.
        /// Valida que el string dato tenga entre 1 y 8 caracteres.
        /// o lanza DniInvalidoException
        /// convierte el dato string a int, de haber error lanza DniInvalidoException
        /// llama a ValidarDni()
        /// retorna int con dni validado
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroDni;
            dato = dato.Replace(".", "");
            dato = dato.Replace(",", "");
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato);
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato, e);
            }
            return Persona.ValidarDni(nacionalidad, numeroDni);
        }
        /// <summary>
        /// Valida que el string dato sea solo caracteres alfabeticos.
        /// o retorna el string vacio.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);
            if (match.Success)
                return match.Value;
            else
                return "";
        }
        #endregion

        #region "Mètodos"
        /// <summary>
        /// sobreescribe el metodo ToString()
        /// retorna datos nombre apellido y nacionalidad en un string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }
        #endregion
    }
}
