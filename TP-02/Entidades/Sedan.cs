using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerables
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region Campos
        ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Llama al constructor base (en clase Vehiculo), e inicializa Etipo (variable propia).
        /// Pide por parámetro Etipo tipo.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(marca,chasis,color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// Llama al constructor base (en clase Sedan), inicializa Etipo por defecto.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            :this(marca, chasis, color,ETipo.CuatroPuertas)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override sealed ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Mètodos
        /// <summary>
        /// Reformula el mètodo Mostrar() de vehiculo
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n\r", this.Tamanio);
            sb.AppendFormat("TIPO : {0}\n\r", this.tipo);
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
