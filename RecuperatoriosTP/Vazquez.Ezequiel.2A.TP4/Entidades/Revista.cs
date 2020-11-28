using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Revista : Texto
    {
        public enum EGenerosRevista { Deportiva,Interés,Teen,Comic,Animé }

        private EGenerosRevista _genero;

        #region Propiedades
        public override string Genero
        {
            get { return this._genero.ToString(); }
            set { this._genero = (EGenerosRevista)Enum.Parse(typeof(EGenerosRevista), value); }
        }
        #endregion

        #region Constructores
        public Revista()
        {
        }
        public Revista(Int32 codigo, string titulo, double precio, EGenerosRevista genero, Int32 stock)
            : base(codigo, titulo, precio, stock)
        {
            this._genero = genero;
        }
        #endregion
    }
}
