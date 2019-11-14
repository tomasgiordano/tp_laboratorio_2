using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string traquingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega=value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.traquingID; }
            set { this.traquingID = value; }
        }
        #endregion

        #region Metodos
        public void MockCicloDeVida()
        {

        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return "";
        }

        //public static bool operator ==(Paquete p1, Paquete p2)
        //{
            
        //}

        //public static bool operator !=(Paquete p1, Paquete p2)
        //{
            
        //}

        public Paquete(string direccionEntrega, string trackingID)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Tipos anidados
        public delegate void DelegadoEstado();

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }
        #endregion
    }
}
