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

namespace Form_Libreria
{
    public partial class FormABMValues : Form
    {
        private Texto tx;
        public Texto Texto
        {
            get { return this.tx; }
        }
        public FormABMValues()
        {
            InitializeComponent();
            this.comboBoxTipo.Items.Add("Libro");
            this.comboBoxTipo.Items.Add("Revista");
            this.comboBoxTipo.Items.Add("Enciclopedia");
        }
        public FormABMValues(Texto t)
            : this()
        {
            this.tx = t;
            this.labelCodigoValor.Text = t.Codigo.ToString();
            this.textBoxTitulo.Text = t.Titulo;
            this.comboBoxTipo.SelectedItem = t.Tipo;
            this.comboBoxGenero.SelectedItem = t.Genero;
            this.textBoxPrecio.Text = t.Precio.ToString();
            this.textBoxStock.Text = t.Stock.ToString();
        }
        /// <summary>
        /// Evento del boton aceptar
        /// toma los datos del form y los almacena en una instancia de tipo Texto privada interna
        /// setea el dialogResult en OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            string codigo = this.labelCodigoValor.Text;
            codigo = codigo == "" ? "0" : codigo;
            switch (this.comboBoxTipo.SelectedIndex)
            {
                case 0:
                    this.tx = new Libro();
                    tx.Genero = this.comboBoxGenero.SelectedItem.ToString();
                    break;
                case 1:
                    this.tx = new Revista();
                    tx.Genero = this.comboBoxGenero.SelectedItem.ToString();
                    break;
                case 2:
                    this.tx = new Enciclopedia();
                    tx.Genero = this.comboBoxGenero.SelectedItem.ToString();
                    break;
            }
            this.tx.Codigo = Int32.Parse(codigo);
            this.tx.Titulo = this.textBoxTitulo.Text;
            this.tx.Precio = double.Parse(this.textBoxPrecio.Text.Replace(".",","));
            this.tx.Stock = Int32.Parse(this.textBoxStock.Text);
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Evento del boton cancelar
        /// setea el dialogResult en Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Evento de cambio de item en el comboBox
        /// cambia los valores del comboBoxGenero segun el valor del comboBox tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxTipo.SelectedIndex)
            {
                case 0:
                    this.comboBoxGenero.DataSource = Enum.GetValues(typeof(Libro.EGenerosLibro));
                    break;
                case 1:
                    this.comboBoxGenero.DataSource = Enum.GetValues(typeof(Revista.EGenerosRevista));
                    break;
                case 2:
                    this.comboBoxGenero.DataSource = Enum.GetValues(typeof(Enciclopedia.EGenerosEnciclopedia));
                    break;
            }
        }
    }
}
