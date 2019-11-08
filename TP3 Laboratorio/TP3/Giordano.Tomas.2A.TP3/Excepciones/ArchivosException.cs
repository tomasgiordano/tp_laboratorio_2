using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        #region Metodos
        public ArchivosException(Exception innerException):base("No se puede leer o escribir el archivo.",innerException)
        {
            
        }
        #endregion
    }
}
