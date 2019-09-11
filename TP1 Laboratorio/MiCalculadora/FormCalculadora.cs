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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        bool flag = true;
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text=="")
            {
                lblResultado.Text = "Valor Inválido";
            }
            else
            {
                if(flag)
                {
                    lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                    lblBinDec.Text = "BIN";
                    flag = false;
                }               
            }          
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            flag = true;
            lblBinDec.Text = "DEC";
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text=="")
            {
                lblResultado.Text = "Valor Inválido";
            }
            else
            {
                if (flag == false)
                {
                    lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                    lblBinDec.Text = "DEC";
                    flag = true;
                }
            }           
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
            lblBinDec.Text = "DEC";
        }

        private double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero (numero2);
            return Calculadora.Operar(num1,num2,operador);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            lblBinDec.Text = "DEC";
        }

    }
}
