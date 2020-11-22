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
using manejadorSQL;

namespace Form_Libreria
{
    public partial class FormABM : Form
    {
        manejadorSql sql;
        FormPrincipal frmPrinc;
        public FormABM(FormPrincipal frmPrinc)
        {
            InitializeComponent();
            this.sql = new manejadorSql();
            this.frmPrinc = frmPrinc;
        }
        /// <summary>
        /// Evento del boton Agregar
        /// Muestra una instancia de formABMValues
        /// si retorna OK agrega la instancia Texto a la bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FormABMValues frm = new FormABMValues();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                if (this.sql.AgregarTexto(frm.Texto))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
  
        }
        /// <summary>
        /// Evento del boton Modificar
        /// Muestra una instancia de formABMValues
        /// si retorna OK modifica la instancia Texto en bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormABMValues frm = new FormABMValues(this.frmPrinc.SeleccionActualLibreria);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(this.sql.ModificarTexto(frm.Texto))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        /// <summary>
        /// Evento del boton Eliminar
        /// Muestra una instancia de formABMValues
        /// si retorna OK elimina la instancia Texto de bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            FormABMValues frm = new FormABMValues(this.frmPrinc.SeleccionActualLibreria);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(this.sql.EliminarTexto(frm.Texto))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
