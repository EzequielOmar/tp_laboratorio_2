using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtencionCarrito 
    {
        /// <summary>
        /// Metodo de extension de clase Carrito<>
        /// Agrega un item de tipo Texto a la lista de la instancia actual de Carrito<Texto>.
        /// Si la instancia Texto ya existe en la lista, suma 1 a su stock.
        /// </summary>
        /// <param name="c">parametro interno que representa la instancia de Carrito de la cual se llama a este metodo.</param>
        /// <param name="item">instancia del tipo texto</param>
        /// <returns></returns>
        public static Carrito<Texto> Agregar(this Carrito<Texto> c, Texto item)
        {
            int index = c.Items.FindIndex(x => x.Equals(item));
            if (index == -1)
            {

                c.Items.Add(item);
            }
            else
            {
                c.Items[index].Stock++;
            }
            return c;
        }
        /// <summary>
        /// Metodo de extension de clase Carrito<>
        /// Si la instancia Texto ya existe en la lista, resta 1 a su stock.
        /// Elimina la instancia de tipo Texto de la lista  si su stock es igual a 0.
        /// </summary>
        /// <param name="c">parametro interno que representa la instancia de Carrito de la cual se llama a este metodo.</param>
        /// <param name="item">instancia del tipo texto</param>
        /// <returns></returns>
        public static Carrito<Texto> Sustraer(this Carrito<Texto> c, Texto item)
        {
            int index = c.Items.FindIndex(x => x.Equals(item));
            if (index != -1)
            {
                c.Items[index].Stock -= 1;
                if (c.Items[index].Stock == 0)
                {
                    c.Items.RemoveAt(index);
                }
            }
            return c;
        }
        /// <summary>
        /// Metodo de extension de clase Carrito<>
        /// Genera y retora una instancia de tipo Texto igual a la ingresada por parametro, con un stock igual a 1.
        /// El retorno representa una unidad del libro que se ingresa por parametro.
        /// </summary>
        /// <param name="c">parametro interno que representa la instancia de Carrito de la cual se llama a este metodo.</param>
        /// <param name="item">instancia del tipo texto </param>
        /// <returns></returns>
        public static Texto ObtenerUnaCopia(this Carrito<Texto> c, Texto item)
        {
            Texto tx = null;
            switch (item.Tipo)
            {
                case "Libro":
                    tx = new Libro(item.Codigo,item.Titulo,item.Precio,(Libro.EGenerosLibro)Enum.Parse(typeof(Libro.EGenerosLibro),item.Genero),1);
                    break;
                case "Revista":
                    tx = new Revista(item.Codigo, item.Titulo, item.Precio, (Revista.EGenerosRevista)Enum.Parse(typeof(Revista.EGenerosRevista), item.Genero), 1);
                    break;
                case "Enciclopedia":
                    tx = new Enciclopedia(item.Codigo, item.Titulo, item.Precio, (Enciclopedia.EGenerosEnciclopedia)Enum.Parse(typeof(Enciclopedia.EGenerosEnciclopedia), item.Genero), 1);
                    break;
            }
            return tx;
        }
    }
}
