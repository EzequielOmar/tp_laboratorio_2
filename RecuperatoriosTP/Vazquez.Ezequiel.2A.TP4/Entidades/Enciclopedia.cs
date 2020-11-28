using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Enciclopedia : Texto
    {
        public enum EGenerosEnciclopedia { Geografía,Naturales,Sociales }

        private EGenerosEnciclopedia _genero;

        #region Propiedades
        public override string Genero
        {
            get { return this._genero.ToString(); }
            set { this._genero = (EGenerosEnciclopedia)Enum.Parse(typeof(EGenerosEnciclopedia), value); }
        }
        #endregion

        #region Constructores
        public Enciclopedia()
        {
        }
        public Enciclopedia(Int32 codigo, string titulo, double precio, EGenerosEnciclopedia genero,Int32 stock)
            : base(codigo, titulo, precio, stock)
        {
            this._genero = genero;
        }
        #endregion
    }
}
