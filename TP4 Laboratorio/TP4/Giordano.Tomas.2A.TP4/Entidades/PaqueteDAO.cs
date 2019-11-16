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
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Metodos
        public static bool Insertar(Paquete p)
        {
            bool aux=false;

            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Tomas Giordano')";
                PaqueteDAO.comando.ExecuteNonQuery();
                PaqueteDAO.conexion.Close();
                aux = true;
            }
            catch(Exception e)
            {
                throw new Exception("ERROR con la carga de datos.");
            }

            return aux;
        }

        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            comando = new SqlCommand(); 
        }
        #endregion
    }
}
