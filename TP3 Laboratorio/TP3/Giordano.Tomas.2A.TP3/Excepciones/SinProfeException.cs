using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException:Exception
    {
        #region Metodos
        public SinProfesorException():base("No tiene profesor.")
        {

        }
        #endregion
    }
}
