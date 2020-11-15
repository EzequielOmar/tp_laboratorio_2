using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtencionCarrito 
    {
        public static Carrito<Texto> Add(this Carrito<Texto> c, Texto item)
        {
            int index = c.Items.FindIndex(x => x.Equals(item));
            if (index == -1)
            {
                c.Items.Add(item);
                c.CantItems++;
            }
            else
            {
                c.Items[index].Stock++;
            }
            return c;
        }
        public static Carrito<Texto> Subtract(this Carrito<Texto> c, Texto item)
        {
            int index = c.Items.FindIndex(x => x.Equals(item));
            if (index != -1)
            {
                c.Items[index].Stock -= - 1;
                if (c.Items[index].Stock == 0)
                {
                    c.Items.RemoveAt(index);
                }
            }
            return c;
        }
    }
}
