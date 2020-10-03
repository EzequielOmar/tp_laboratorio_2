using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Campos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor base. Inicializa con 3 paràmetros.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }
        #endregion

        #region Mètodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Devuelve un string mostrando datos del Vehiculo
        /// Pide por parámetro la instancia del Vehiculo
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CHASIS: {0}\n\r", p.chasis);
            sb.AppendFormat("MARCA : {0}\n\r", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\n\r", p.color.ToString());
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool respuesta = false;
            if((object)v1 == null && (object)v2 == null)
            {
                respuesta = true;
            }
            else
            {
                if((object)v1 != null && (object)v2 != null)
                {
                    if(v1.chasis.Substring(0,3) == v2.chasis.Substring(0, 3))
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        /// <summary>
        /// Sobrecarga del metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            bool respuesta = false;
            if (obj is Vehiculo)
            {
                respuesta = (Vehiculo)obj == this;
            }
            return respuesta;
        }
        /// <summary>
        /// Sobrecarga del metodo GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
