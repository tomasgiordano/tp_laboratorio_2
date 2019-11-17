using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        #region Campos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Metodos
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (!hilo.Equals(null) && hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Paquete p in this.Paquetes)
            {
                if(!p.Equals(null))
                {
                    sb.AppendLine(p.ToString()+"("+p.Estado.ToString()+")");
                }
            }
            return sb.ToString();
        }

        public static Correo operator + (Correo c, Paquete p)
        {
            if(!p.Equals(null)&&!c.Equals(null))
            {
                foreach(Paquete paq in c.Paquetes)
                {
                    if (paq.TrackingID == p.TrackingID)
                    {
                        throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " ya figura en la lista de envios.");
                    }
                }
                c.paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                hilo.Start();
                c.mockPaquetes.Add(hilo);
            }
            return c;
        }
        #endregion
    }
}
