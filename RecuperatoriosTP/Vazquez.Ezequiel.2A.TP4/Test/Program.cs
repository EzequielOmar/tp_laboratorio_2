using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Carrito<Texto> carrito = new Carrito<Texto>();

            Libro l1 = new Libro(1, "Las Andanzas del capitan buscapina", 850.75, Libro.EGenerosLibro.Novela, 1);
            Libro l2 = new Libro(2, "Eche Homo", 150.75, Libro.EGenerosLibro.Biográfico, 3);
            Revista r1 = new Revista(3, "Mad", 125.5, Revista.EGenerosRevista.Interés, 4);
            Revista r2 = new Revista(4, "X-Men", 75.3, Revista.EGenerosRevista.Comic, 6);
            Enciclopedia e1 = new Enciclopedia(5, "Atlas: Geografìa del mundo.", 750.85, Enciclopedia.EGenerosEnciclopedia.Geografía, 1);
            Enciclopedia e2 = new Enciclopedia(6, "Matematicas: La venganza de los nùmeros.", 1050.2, Enciclopedia.EGenerosEnciclopedia.Naturales, 2);

            carrito.Agregar(l1);
            carrito.Agregar(l2);
            carrito.Agregar(r1);
            carrito.Agregar(r2);
            carrito.Agregar(e1);
            carrito.Agregar(e2);

            carrito.MedioDePago = ETipoMedioDePago.Efectivo;
            carrito.DescuentoCredito = 7.5;
            carrito.DescuentoDebito = 5;
            carrito.DescuentoEfectivo = 10;
            carrito.DescuentoMercadoPago = 0;

            Console.WriteLine(carrito.RealizarVenta());


            carrito.MedioDePago = ETipoMedioDePago.Crédito;
            carrito.Agregar(l1);
            carrito.Sustraer(l2);
            carrito.Sustraer(e1);

            Console.WriteLine(carrito.RealizarVenta());
        }
    }
}
