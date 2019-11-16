﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException:Exception
    {
        #region Metodos
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }

        public TrackingIdRepetidoException(string mensaje,Exception inner):this(mensaje+"\n"+inner.Message)
        {

        }    
        #endregion
    }
}