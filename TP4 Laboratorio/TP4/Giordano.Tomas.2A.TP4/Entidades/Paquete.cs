using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(TimeSpan.FromSeconds(4));
                this.Estado = this.Estado + 1;
                this.InformaEstado(this, new EventArgs());
            }

            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(!object.Equals(p1,null)&&!object.Equals(p2,null))
            {
                if(p1.TrackingID==p2.TrackingID)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;           
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Tipos anidados
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }
        #endregion
    }
}
