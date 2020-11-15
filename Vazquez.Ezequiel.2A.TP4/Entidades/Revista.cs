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
        private DateTime _fechaEdicion;

        #region Constructores
        public Revista(Int32 codigo, string titulo, double precio, EGenerosRevista genero,DateTime edicion, Int32 stock)
            : base(codigo, titulo, precio, stock)
        {
            this._genero = genero;
            this._fechaEdicion = edicion;
        }
        public Revista(Int32 codigo, string titulo, double precio, EGenerosRevista genero,DateTime edicion)
           : base(codigo, titulo, precio)
        {
            this._genero = genero;
            this._fechaEdicion = edicion;
        }
        #endregion
    }
}
