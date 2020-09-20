using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        static private string ValidarOperador(char operador)
        {
            string respuesta = "+";
            switch (operador)
            {
                case '-':
                    respuesta = "-";
                    break;
                case '*':
                    respuesta = "*";
                    break;
                case '/':
                    respuesta = "/";
                    break;
            }

            return respuesta;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string strOperador = ValidarOperador(operador.ToCharArray()[0]);
            
            switch (strOperador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            
            return resultado;
        }

    }
}
