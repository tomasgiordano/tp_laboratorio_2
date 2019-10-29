using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class  DniInvalidoException:Exception
    {
        public DniInvalidoException():base("DNI Inválido.")
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }

        public DniInvalidoException(Exception e):this("DNI Inválido.",e)
        {

        }

        public DniInvalidoException(string mensaje):this("DNI Inválido.",null)
        {

        }

        
    }
}
