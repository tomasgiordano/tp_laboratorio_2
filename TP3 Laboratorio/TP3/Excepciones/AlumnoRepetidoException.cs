using System;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        #region Metodos
        public AlumnoRepetidoException():base("Alumno repetido.")
        {

        }
        #endregion
    }
}
