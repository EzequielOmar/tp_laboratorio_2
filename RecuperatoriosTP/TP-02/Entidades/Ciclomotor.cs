using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Llama al constructor base (en clase Vehiculo), e inicializa Etipo (variable propia)
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(marca,chasis,color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override sealed ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
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
            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n\r", this.Tamanio);
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
