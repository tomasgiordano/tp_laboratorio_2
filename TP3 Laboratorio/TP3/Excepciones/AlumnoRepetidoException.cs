using System;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        #region Metodos
        public AlumnoRepetidoException():base("El alumno esta REPETIDO")
        {

        }
        #endregion
    }
}
