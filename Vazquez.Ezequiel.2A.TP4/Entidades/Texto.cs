using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Texto
    {
        private Int32 _codigo;
        private string _titulo;
        private double _precio;
        private Int32 _stock;

        #region Propiedades
        public Int32 Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public string Titulo
        {
            get { return this._titulo; }
            set { this._titulo = value; }
        }
        public string Tipo
        {
            get { return this.GetType().ToString().Replace("Entidades.", ""); }
        }
        public abstract string Genero { get; set; }
        public double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
        public Int32 Stock
        {
            get { return this._stock; }
            set { this._stock = value; }
        }
        #endregion

        #region Constructores
        public Texto()
        {
        }
        public Texto(Int32 codigo, string titulo, double precio, Int32 stock)
        {
            this._codigo = codigo;
            this._titulo = titulo;
            this._precio = precio;
            this.Stock = stock;
        }
        #endregion
        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador ==
        /// retorna true si el tipo y el codigo entre las instancias de Texto son iguales.
        /// </summary>
        /// <param name="t1">Instancia de Texto</param>
        /// <param name="t2">Instancia de Texto</param>
        /// <returns></returns>
        public static bool operator ==(Texto t1,Texto t2)
        {
            bool rta = false;
            if(t1.GetType() == t2.GetType() && t1._codigo == t2._codigo)
            {
                rta = true;
            }
            return rta;
        }
        /// <summary>
        /// Sobrecarga del operador ==
        /// retorna true si el tipo o el codigo entre las instancias de Texto son distintos.
        /// </summary>
        /// <param name="t1">Instancia de Texto</param>
        /// <param name="t2">Instancia de Texto</param>
        /// <returns></returns>
        public static bool operator !=(Texto t1, Texto t2)
        {
            return !(t1 == t2);
        }
        /// <summary>
        /// Sobrecarga del operador Equals
        /// retorna true si el tipo y el codigo entre las instancias de Texto son iguales.
        /// utiliza sobrecarga del == interna de clase Texto
        /// </summary>
        /// <param name="t1">Instancia de Texto</param>
        /// <param name="t2">Instancia de Texto</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (Texto)obj == this;
        }
        /// <summary>
        /// override del metodo ToString()
        /// retorna el elemento en formato un.  titulo  (precio unitario) precio final.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(this.Stock > 1)
            {
                sb.AppendFormat("{0}  \"{1}\"  (${2})  ${3}\n", this._stock, this._titulo, this._precio, this._precio*this.Stock);
            }
            else
            {
                sb.AppendFormat("{0}  \"{1}\"         ${2}\n", this._stock, this._titulo, this._precio);
            }
            return sb.ToString();
        }
        #endregion
    }
}
