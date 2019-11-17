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
        /// <summary>
        /// Ciclo de vida de un paquete
        /// </summary>
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

        /// <summary>
        /// Muestra los datos de el paquete que se le pase como parametro 
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Informacion en string</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Se fija si los dos paquetes que se pasan como parametros son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si tienen el mismo TrackingID</returns>
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

        /// <summary>
        /// Se fija si los dos paquetes que se pasan como parametros sean distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si tienen distintos TrackingID</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Constructor Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;           
        }

        /// <summary>
        /// Sobreescritura del ToString de Paquete
        /// </summary>
        /// <returns>Devuelve el Mostrar datos de esta clase</returns>
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
