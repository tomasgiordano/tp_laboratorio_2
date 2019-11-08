using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class  DniInvalidoException:Exception
    {
        #region Atributos
        private static string mensajeBase= "DNI Inválido.";
        #endregion

        #region Metodos
        public DniInvalidoException():base(DniInvalidoException.mensajeBase)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje,e)
        {

        }

        public DniInvalidoException(Exception e) : this(DniInvalidoException.mensajeBase, e)
        {

        }

        public DniInvalidoException(string mensaje) : this(mensaje,null)
        {

        }
        #endregion

    }
}
