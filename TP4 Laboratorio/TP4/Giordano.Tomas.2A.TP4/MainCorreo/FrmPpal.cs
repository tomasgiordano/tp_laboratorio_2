using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Campos
        private Correo c;
        #endregion

        #region Metodos
        public FrmPpal()
        {
            InitializeComponent();
            this.StartPosition=FormStartPosition.CenterScreen;
            c = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                p.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                c += p;
                ActualizarEstados();
            }
            catch(TrackingIdRepetidoException f)
            {
                MessageBox.Show(f.Message,"Paquete Repetido",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in c.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }

        private void FrmPpal_FormClosing(object sender, EventArgs e)
        {
            c.FinEntregas();
            this.Close();
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.rtbMostrar.Clear();
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)c);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!elemento.Equals(null))
            {
                this.rtbMostrar.Text += elemento.MostrarDatos(elemento) + "\n";
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("salida.txt"))
                {
                    sw.Write(rtbMostrar.Text);          
                }
            }
        }
        #endregion
    }
}
