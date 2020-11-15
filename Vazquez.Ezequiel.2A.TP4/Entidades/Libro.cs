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
        private string _autor;

        #region Constructores
        public Libro(Int32 codigo, string titulo, double precio, EGenerosLibro genero,string autor, Int32 stock)
            :base(codigo, titulo,precio,stock)    
        {
            this._genero = genero;
            this._autor = autor;
        }
        public Libro(Int32 codigo, string titulo, double precio, EGenerosLibro genero,string autor)
           : base(codigo, titulo, precio)
        {
            this._genero = genero;
            this._autor = autor;
        }
        #endregion
    }
}
