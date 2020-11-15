using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETipoMedioDePago { Efectivo, Crédito, Débito, MercadoPago };
    public interface IDescuentoMedioDePago
    {
        ETipoMedioDePago MedioDePago { get; set; }
        double DescuentoEfectivo { get; set; }
        double DescuentoCredito { get; set; }
        double DescuentoDebito { get; set; }
        double DescuentoMercadoPago { get; set; }

        double CalcularDescuentoMedioDePago();
    }
}
