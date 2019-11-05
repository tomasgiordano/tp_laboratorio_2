using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerException):base("No se puede leer o escribir el archivo.",innerException)
        {
            
        }
    }
}
