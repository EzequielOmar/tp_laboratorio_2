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
        public FormCalculadora()
        {
            InitializeComponent();

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            this.lblResultado.Text = Calculadora.Operar(numero1, numero2, this.cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string binario = Numero.DecimalBinario(this.lblResultado.Text);
            if(double.TryParse(binario,out _))
            {
                this.lblResultado.Text = binario;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string nDecimal = Numero.BinarioDecimal(this.lblResultado.Text);
            //if (double.TryParse(nDecimal, out _))
            //{
                this.lblResultado.Text = nDecimal;
            //}
        }
    }
}
