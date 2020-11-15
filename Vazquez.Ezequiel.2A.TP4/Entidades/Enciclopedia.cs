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
        private Int32 _tomo;

        #region Constructores
        public Enciclopedia(Int32 codigo, string titulo, double precio, EGenerosEnciclopedia genero, Int32 tomo, Int32 stock)
            : base(codigo, titulo, precio, stock)
        {
            this._genero = genero;
            this._tomo = tomo;
        }
        public Enciclopedia(Int32 codigo, string titulo, double precio, EGenerosEnciclopedia genero,Int32 tomo)
           : base(codigo, titulo, precio)
        {
            this._genero = genero;
            this._tomo = tomo;
        }
        #endregion
    }
}
