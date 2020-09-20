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

        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
        }
        private double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero N1 = new Numero(numero1);
            Numero N2 = new Numero(numero2);
            resultado = Calculadora.Operar(N1, N2, this.cmbOperador.Text);
            return resultado;
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:0.000}", this.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text));
            this.lblResultado.Text = sb.ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = true;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = true;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = true;
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }
    }
}
