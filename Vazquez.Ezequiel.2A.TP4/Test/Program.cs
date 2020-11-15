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
            
            Libro l1 = new Libro(1, "Las andanzas del capitán buscapina.", 250.5, Libro.EGenerosLibro.Novela, "El indio.",3);
            Libro l2 = new Libro(2, "Eche Homo", 100.75, Libro.EGenerosLibro.Biográfico, "Nieztche");

            Revista r1 = new Revista(3, "Mad", 25.5, Revista.EGenerosRevista.Interés, DateTime.Now);
            Revista r2 = new Revista(4, "X-Men", 75.5, Revista.EGenerosRevista.Interés, DateTime.Now,1);

            Enciclopedia e1 = new Enciclopedia(5, "Matematicas: La venganza de los nùmeros.", 450.85, Enciclopedia.EGenerosEnciclopedia.Naturales, 2, 2);
            Enciclopedia e2 = new Enciclopedia(6, "Atlas del mundo.", 115.4, Enciclopedia.EGenerosEnciclopedia.Geografía, 1);

            carrito.Add(l1);
            carrito.Add(l1);
            carrito.Add(l1);
            carrito.Subtract(l1);

            carrito.Add(l2);
            carrito.Add(r1);
            carrito.Add(r2);
            carrito.Add(e1);
            carrito.Add(e2);
            carrito.Add(e2);
            carrito.Subtract(r1);

            Console.WriteLine(carrito.RealizarVenta());

            carrito.MedioDePago = ETipoMedioDePago.Crédito;
            carrito.DescuentoCredito = 7.5;
            carrito.DescuentoDebito = 5;
            carrito.DescuentoEfectivo = 10; 
            carrito.DescuentoMercadoPago = 0;

            Console.WriteLine(carrito.RealizarVenta());
        }
    }
}
