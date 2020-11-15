using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito<T> : IDescuentoMedioDePago where T : Texto
    {
        private Int32 _cantItems;
        private List<T> _items;

        #region Propiedades
        public List<T> Items
        {
            get { return this._items; }
        }
        public Int32 CantItems
        {
            get { return this._cantItems; }
            set { this._cantItems = value; }
        }
        public double PrecioParcial
        {
            get { return this.CalcularPrecioParcial(); }
        }
        public double PrecioFinal
        {
            get { return this.CalcularPrecioFinal(); }
        }
        #endregion

        #region Constructores
        public Carrito()
        {
            this._items = new List<T>();
            this._cantItems = 0;
        }
        #endregion

        #region Metodos de instancia publicos
        public string RealizarVenta()
        {
            //CalcularDescuentoMedioDePago();
            StringBuilder sb = new StringBuilder();
            sb.Append("******** LIBRERIA -EL OLIMPO- ********\n");
            sb.Append("La habana, 3314 - CABA \n");
            sb.AppendFormat("Fecha: {0}\n\n", DateTime.Now);
            sb.Append("**************************************\n");
            sb.Append("Un.  Título       ($)Total\n");
            foreach(T aux in this._items)
            {
                sb.Append(aux.ToString());
            }
            sb.AppendFormat("\nSubtotal: ${0}\n", this.PrecioParcial);
            double descuento = CalcularDescuentoMedioDePago();
            ///
            /// VER PORQUE ESTO ES UN CHOTASO
            ///
            switch (this.MedioDePago)
            {
                case ETipoMedioDePago.Efectivo:
                    sb.AppendFormat("\nDescuento por medio de pago: {0}%  ${1}\n", this.DescuentoEfectivo, descuento);
                    break;
                case ETipoMedioDePago.Crédito:
                    sb.AppendFormat("\nDescuento por medio de pago: {0}%  ${1}\n", this.DescuentoCredito, descuento);
                    break;
                case ETipoMedioDePago.Débito:
                    sb.AppendFormat("\nDescuento por medio de pago: {0}%  ${1}\n", this.DescuentoDebito, descuento);
                    break;
                case ETipoMedioDePago.MercadoPago:
                    sb.AppendFormat("\nDescuento por medio de pago: {0}%  ${1}\n", this.DescuentoMercadoPago, descuento);
                    break;
            }
            sb.AppendFormat("\nTotal: ${0}\n", this.PrecioFinal);
            return sb.ToString();
        }
        #endregion

        #region Metodos de instancia privados
        private double CalcularPrecioParcial()
        {
            double contador = 0;
            foreach (T aux in this._items)
            {
                contador += aux.Precio;
            }
            return contador;
        }
        private double CalcularPrecioFinal()
        {

            return this.PrecioParcial - CalcularDescuentoMedioDePago();
        }
        #endregion

        #region IDescuentoMedioDePago
        public ETipoMedioDePago MedioDePago { get; set; }
        public double DescuentoEfectivo { get; set; }
        public double DescuentoCredito { get; set; }
        public double DescuentoDebito { get; set; }
        public double DescuentoMercadoPago { get; set; }

        public double CalcularDescuentoMedioDePago()
        {
            double aux = 0;
            switch (this.MedioDePago)
            {
                case ETipoMedioDePago.Efectivo:
                    aux = this.PrecioParcial * (this.DescuentoEfectivo/100);
                    break;
                case ETipoMedioDePago.Crédito:
                    aux = this.PrecioParcial * (this.DescuentoCredito / 100);
                    break;
                case ETipoMedioDePago.Débito:
                    aux = this.PrecioParcial * (this.DescuentoDebito / 100);
                    break;
                case ETipoMedioDePago.MercadoPago:
                    aux = this.PrecioParcial * (this.DescuentoMercadoPago / 100);
                    break;
            }
            return aux;
        }
        #endregion

    }
}
