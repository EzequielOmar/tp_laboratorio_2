using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Texto
    {
        public enum EFormato { Digital, Fìsico };

        private Int32 _codigo;
        private string _titulo;
        private double _precio;
        private EFormato _formato;
        private string _stock;

        #region Propiedades
        public Int32 Stock
        {
            get
            {
                if (this._formato == EFormato.Fìsico)
                {
                    return Int32.Parse(this._stock);
                }
                else
                {
                    if (this._stock == "-")
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            set
            {
                if (this._formato == EFormato.Fìsico)
                {
                    this._stock = value.ToString();
                }
            }
        }
        public double Precio
        {
            get
            {
                return this._precio*this.Stock;
            }
        }
        #endregion

        #region Constructores
        private Texto(Int32 codigo, string titulo, double precio, EFormato formato)
        {
            this._codigo = codigo;
            this._titulo = titulo;
            this._precio = precio;
            this._formato = formato;
        }
        public Texto(Int32 codigo, string titulo, double precio, Int32 stock)
            :this(codigo,titulo,precio,EFormato.Fìsico)
        {
            this.Stock = stock;
        }
        public Texto(Int32 codigo, string titulo, double precio)
            :this(codigo,titulo,precio, EFormato.Digital)
        {
            this._stock = "-";
        }
        #endregion
        #region Sobrecargas
        public static bool operator ==(Texto t1,Texto t2)
        {
            bool rta = false;
            if(t1.GetType() == t2.GetType() && t1._codigo == t2._codigo)
            {
                rta = true;
            }
            return rta;
        }
        public static bool operator !=(Texto t1, Texto t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            return (Texto)obj == this;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(this.Stock > 1)
            {
                sb.AppendFormat("{0}  \"{1}\"  (${2})  ${3}\n", this._stock, this._titulo, this._precio, this.Precio);
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
