using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad {Argentina,Extranjera}

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Constructor"
        public Persona()
        {
            //inicializar atributos?
            //pasa al otro constructor inicializando por defecto?

            //this.Nombre = "";
            //this.Apellido = "";
            //this.Nacionalidad = ENacionalidad.Argentina;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Propiedades"
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
        public ENacionalidad Nacionalidad
        {
            get{return this.nacionalidad;}
            set{this.nacionalidad = value;}
        }
        #endregion

        #region "Validadores"
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentina:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjera:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }
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
