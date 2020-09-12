using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            } 
        }

        public Numero()
        {
            this.SetNumero = "0";
        }
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
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
            int i,coma = 0, negativo = 0;

            for (i = 0; i < strNumero.Length; i++)
            {
                if (strNumero[i] == '-' && i == 0)
                {
                    negativo++;
                    continue;
                }
                if (char.IsDigit(strNumero[i]))
                {
                    continue;
                }
                else
                {
                    if (strNumero[i] == '.' || strNumero[i] == ',')
                    {
                        coma++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (i == strNumero.Length && coma < 2)
            {
                strNumero = strNumero.Replace(".",",");
                double.TryParse(strNumero, out numero);
            }

            return numero;
        }

        public static string BinarioDecimal(string binario)
        {
            string respuesta = "Valor inválido";
            int multiplicador = 1, entero = 0, aux, i;

            if (EsBinario(binario))
            {
                for (i = binario.Length - 1; i >= 0; i--)
                {
                    aux = Convert.ToInt32(binario.Substring(i, 1));
                    entero = entero + (aux * multiplicador);
                    multiplicador *= 2;
                }

                if (i == -1)
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

            Numero nm = new Numero(numero);

            if ( nm.numero > 0 && int.TryParse(nm.numero.ToString(), out int iNumero))
            {
                binario = "";
                resultado = iNumero;
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
            double respuesta;
            if(n2.numero == 0)
            {
                respuesta = double.MinValue;
            } else {
                respuesta = n1.numero / n2.numero;
            }
            return respuesta;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double respuesta = n1.numero * n2.numero;
            return respuesta;
        }
    }
}
