using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        public static SqlCommand comando;
        public static SqlConnection conexion;
        #endregion

        #region Metodos
        //public static bool Insertar(Paquete p)
       // {

        //}

        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            comando = new SqlCommand(); 
        }
        #endregion
    }
}
