using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        private string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
            
        }

        public static string BinarioDecimal(string strBinario)
        {
            int bin = 0;
            int exp = 0;
            int cantidad = strBinario.Length;
            string resultado;
            double num = 0;

            if (int.TryParse(strBinario, out bin))
            {
                for (int i = cantidad - 1; i >= 0; i--)
                {
                    if (strBinario[i] == '1')
                    {
                        num += Math.Pow(2, exp);
                    }
                    exp++;
                }
                resultado = num.ToString();
                return resultado;
            }
            else
            {
                return "Valor Inválido";
            }            
        }
        public static string DecimalBinario(double num)
        {
            double resto;
            string strResto = "";
            string resultado = "";
            int division = (int)num;

            if (num > 0)
            {
                while (division >= 2)
                {
                    resto = division % 2;
                    division = division / 2;

                    strResto = resto.ToString();
                    resultado = strResto + resultado;
                }
                resultado = "1"+resultado;
            }
            else
            {
                resultado = "0";
            }
            return resultado;
        }

        public static string DecimalBinario(string strNum)
        {
            double doubleNum;
            if(!(Double.TryParse(strNum,out doubleNum)))
            {
                return "Valor Inválido";
            }
            else
            {
                if(Convert.ToDouble(strNum)>0)
                {
                    return DecimalBinario(Convert.ToDouble(strNum));
                }
                else
                {
                    return "Valor inválido";
                }
            }
        }

        public Numero():this(0)
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public static double operator + (Numero n1, Numero n2)
        {
            return (double)(n1.numero+n2.numero);
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return (double)(n1.numero-n2.numero);
        }

        public static double operator * (Numero n1, Numero n2)
        {
            return (double)(n1.numero*n2.numero);
        }

        public static double operator / (Numero n1, Numero n2)
        {
            return (double)(n1.numero/n2.numero);
        }
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            else
            {
                numero = Convert.ToDouble(strNumero);
            }

            return numero;
        }
        public static bool EsCero(Numero num)
        {
            if(num.numero == 0)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
