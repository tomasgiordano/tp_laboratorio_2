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
        /// <summary>
        /// Constructor de correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Aborta todos los hilos de los paquetes existentes
        /// </summary>
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

        /// <summary>
        /// Devuelve la informacion de cada paquete
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>La informacion en string</returns>
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

        /// <summary>
        /// Suma un paquete a la lista del correo si es que sus TrackingID NO son iguales
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>El correo que se le pasa por parametro</returns>
        public static Correo operator + (Correo c, Paquete p)
        {          
            foreach(Paquete paq in c.Paquetes)
            {
                if (paq == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID "+p.TrackingID+" ya figura en la lista de envios.");
                }
            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            hilo.Start();
            c.mockPaquetes.Add(hilo);        
            
            return c;
        }
        #endregion
    }
}
