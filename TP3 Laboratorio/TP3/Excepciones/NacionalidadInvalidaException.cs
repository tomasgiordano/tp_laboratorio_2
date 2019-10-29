using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        public NacionalidadInvalidaException():this("Nacionalidad Inválida.")
        {

        }

        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {
            
        }
    }
}
