﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        #region Metodos
        public NacionalidadInvalidaException():this("La nacionalidad no se condice con el numero de DNI.")
        {

        }

        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {
            
        }
        #endregion
    }
}
