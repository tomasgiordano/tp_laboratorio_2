using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if((operador!="+")&&(operador!="-")&&(operador!="*")&&(operador!="/"))
            {
                operador = "+";
            }
            return operador;
        }

        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado=0;

            operador=ValidarOperador(operador);

            switch(operador)
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
                    if(!(Numero.EsCero(num2)))
                    {
                        resultado = num1/num2;                      
                    }          
                    else
                    {
                        resultado = double.MinValue;
                    }
                    break;
                default:
                    break;
            }
            return resultado;
        }
    }
}
