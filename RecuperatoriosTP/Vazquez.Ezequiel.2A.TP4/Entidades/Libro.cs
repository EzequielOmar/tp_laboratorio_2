using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Texto
    {
        public enum EGenerosLibro { Policial,Novela,Ficción,Biográfico }

        private EGenerosLibro _genero;

        #region Propiedades
        public override string Genero
        {
            get { return this._genero.ToString(); }
            set { this._genero = (EGenerosLibro)Enum.Parse(typeof(EGenerosLibro), value); }
        }
        #endregion

        #region Constructores
        public Libro()
        {
        }
        public Libro(Int32 codigo, string titulo, double precio, EGenerosLibro genero,Int32 stock)
            :base(codigo,titulo,precio,stock)    
        {
            this._genero = genero;
        }
        #endregion
    }
}
