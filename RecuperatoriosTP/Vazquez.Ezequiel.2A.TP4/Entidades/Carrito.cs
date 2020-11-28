using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Entidades
{
    public class Carrito<T> : IDescuentoMedioDePago where T : Texto
    {
        private List<T> _items;

        #region Propiedades
        public List<T> Items
        {
            get { return this._items; }
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
        }
        #endregion

        #region Metodos de instancia publicos
        /// <summary>
        /// Retorna un string que representa el ticket de la transaccion de compra.
        /// Detallando sumas parciales, y descuento por medio de pago.
        /// </summary>
        /// <returns></returns>
        public string RealizarVenta()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("******** LIBRERIA -EL OLIMPO- ********\n");
            sb.Append("La habana, 3314 - CABA \n");
            sb.AppendFormat("Fecha: {0}\n", DateTime.Now);
            sb.Append("**************************************\n");
            sb.Append("Un.       Título       ($)Total\n");
            sb.Append("--------------------------------------\n");
            foreach (T aux in this._items)
            {
                sb.Append(aux.ToString());
            }
            sb.AppendFormat("\nSubtotal:                          ${0:0.00}\n", this.PrecioParcial);
            sb.AppendFormat("Dnto. p/medio de pago:  {0}%        ${1:0.00}\n", this.DescuentoUsado, CalcularDescuentoMedioDePago());
            sb.AppendFormat("\nTotal:                             ${0:0.00}\n", this.PrecioFinal);
            return sb.ToString();
        }
        #endregion

        #region Metodos de instancia privados
        /// <summary>
        /// Calcula el precio parcial de los items en el carrito
        /// Retorna double la suma de items.precio * item.stock
        /// </summary>
        /// <returns></returns>
        private double CalcularPrecioParcial()
        {
            double contador = 0;
            foreach (T aux in this._items)
            {
                contador += (aux.Precio*aux.Stock);
            }
            return contador;
        }
        /// <summary>
        /// Calcula el precio final restandole el descuento por medio de pago al precio parcial
        /// </summary>
        /// <returns></returns>
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
        public double DescuentoUsado
        {
            get
            {
                double aux = 0;
                switch (this.MedioDePago)
                {
                    case ETipoMedioDePago.Efectivo:
                        aux =  this.DescuentoEfectivo;
                        break;
                    case ETipoMedioDePago.Crédito:
                        aux = this.DescuentoCredito;
                        break;
                    case ETipoMedioDePago.Débito:
                        aux = this.DescuentoDebito;
                        break;
                    case ETipoMedioDePago.MercadoPago:
                        aux = this.DescuentoMercadoPago;
                        break;
                }
                return aux;
            }
        }
        /// <summary>
        /// Calcula el valor en pesos del descuento por medio de pago
        /// this.PrecioParcial * (this.DescuentoUsado / 100)
        /// </summary>
        /// <returns></returns>
        public double CalcularDescuentoMedioDePago()
        {
            return this.PrecioParcial * (this.DescuentoUsado / 100);
        }
        #endregion

    }
}
