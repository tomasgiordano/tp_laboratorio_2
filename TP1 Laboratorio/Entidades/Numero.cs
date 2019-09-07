using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public double SetNumero
        {
            set { this.numero = value; }
        }

        public string BinarioDecimal(string binario)
        {
           return (BitConverter.Int64BitsToDouble(Convert.ToInt64(binario, 2))).ToString();
        }
        public string DecimalBinario(double num)
        {
            long numBin = BitConverter.DoubleToInt64Bits(num);
            return Convert.ToString(numBin, 2);
        }
        public string DecimalBinario(string num)
        {
            Convert.ToDouble(num);
            return DecimalBinario(num);
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
            double.TryParse(strNumero, out this.numero);
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return (double)(n1+n2);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return (double)(n1-n2);
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return (double)(n1*n2);
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return (double)(n1/n2);
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
