using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerException):base("NO es posible recibir informacion del archivo.",innerException)
        {
            
        }
    }
}
