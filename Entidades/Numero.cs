using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string Double
        {
            set
            {
                numero = ValidarNumero(value);
            } 
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                this.numero = numero;
            }
        }

        private static bool EsBinario(string numero)
        {
            bool respuesta = true;
            string aux;

            for (int i = 0; i < numero.Length; i++)
            {
                aux = numero.Substring(i, 1);
                if (aux != "0" && aux != "1")
                {
                    respuesta = false;
                    break;
                }
            }

            return respuesta;
        }

        private static double ValidarNumero(string strNumero)
        {
            double numero = 0;
            int i;

            for (i = 0; i < strNumero.Length; i++)
            {
                if (!double.TryParse(strNumero.Substring(i, 1), out _))
                {
                    break;
                }
            }

            if (i == strNumero.Length)
            {
                double.TryParse(strNumero, out numero);
            }

            return numero;
        }

        public static string BinarioDecimal(string binario)
        {
            string respuesta = "Valor invàlido";
            int multiplicador = 1, entero = 0, aux, i;

            if (EsBinario(binario))
            {
                for (i = binario.Length - 1; i >= 0; i--)
                {
                    aux = Convert.ToInt32(binario.Substring(i, 1));
                    entero = entero + (aux * multiplicador);
                    multiplicador *= 2;
                }

                if (i == 0)
                {
                    respuesta = entero.ToString();
                }
            }

            return respuesta;
        }

        public static string DecimalBinario(string numero)
        {
            string binario = "Valor inválido";
            int resto, resultado;

            if (double.TryParse(numero, out double dNumero))
            {
                binario = "";
                resultado = (int)dNumero;
                do
                {
                    resto = resultado % 2;
                    resultado = resultado / 2;
                    binario = resto.ToString() + binario;
                } while (resultado > 0);
            }

            return binario;
        }

        public static string DecimalBinario(double numero)
        {
            string binario;
            binario = DecimalBinario(numero.ToString());
            return binario;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double respuesta = n1.numero + n2.numero;
            return respuesta;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            double respuesta = n1.numero - n2.numero;
            return respuesta;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double respuesta = n1.numero / n2.numero;
            return respuesta;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double respuesta = n1.numero * n2.numero;
            return respuesta;
        }
    }
}
