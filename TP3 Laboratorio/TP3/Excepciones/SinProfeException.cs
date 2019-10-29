using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfeException:Exception
    {
        public SinProfeException():base("No tiene profesor.")
        {

        }
    }
}
