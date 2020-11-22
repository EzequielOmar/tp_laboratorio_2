using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using manejadorSQL;
using Entidades;

namespace Form_Libreria
{

    public delegate void DelegadoActualizar();

    public partial class FormPrincipal : Form
    {
        private manejadorSql sql;
        private Carrito<Texto> carrito;
        private Carrito<Texto> libreria;

        protected Thread hilo;
        public event DelegadoActualizar ActualizarLista;

        #region Propiedades
        public Texto SeleccionActualLibreria
        {
            get { return this.libreria.Items[this.dataGridViewLibreria.CurrentRow.Index]; }
        }
        #endregion

        #region Constructor
        public FormPrincipal()
        {
            InitializeComponent();
            this.sql = new manejadorSql();
            this.ActualizarLista += new DelegadoActualizar(this.ActualizarLibreria);
            this.ConfigurarDataGridViewLibreria();
            this.ConfigurarDataGridViewCarrito();
            this.comboBox1.DataSource = Enum.GetValues(typeof(ETipoMedioDePago));
        }
        #endregion

        #region Manejadores de evento FormPrincipal
        /// <summary>
        /// Manejador de evento click en un row de la lista libreria
        /// obtiene una unidad del texto presionado, lo resta a libreria (reflejando en base de datos) y 
        /// lo suma en carrito.
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewLibreria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Texto aux = this.libreria.ObtenerUnaCopia(this.libreria.Items[e.RowIndex]);
            this.carrito.Agregar(aux);
            this.sql.SustraerBD(this.libreria.Items[e.RowIndex]);
            this.ActualizarLista.Invoke();
        }
        /// <summary>
        /// Manejador de evento click en un row de la lista carrito
        /// obtiene una unidad del texto presionado, lo agrega a libreria (reflejando en base de datos) y 
        /// lo resta en carrito.
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Texto aux = this.carrito.ObtenerUnaCopia(this.carrito.Items[e.RowIndex]);
            this.sql.AgregarBD(aux);
            this.carrito.Sustraer(aux);
            this.ActualizarLista.Invoke();
        }
        /// <summary>
        /// Manejador de evento del boton +
        /// obtiene una unidad del texto seleccionado en el listado de carrito,
        /// lo resta de libreria (reflejando en base de datos) y lo agrega a carrito
        /// *Lanza excepcion si no hay ningun item en carrito*
        /// *Lanza excepcion si no hay mas items en la libreria*
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMas_Click(object sender, EventArgs e)
        {
            try
            {
                Texto aux = this.libreria.ObtenerUnaCopia(this.carrito.Items[this.dataGridViewCarrito.CurrentRow.Index]);
                if (this.libreria.Items.Exists(x => x == aux))
                {
                    this.sql.SustraerBD(aux);
                    this.carrito.Agregar(aux);
                }
                else
                {
                    MessageBox.Show("¡Lo Sentimos! No hay mas stock de este texto.");
                }
                this.sql.SustraerBD(aux);
                this.ActualizarLista.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("Agregue un producto al carrito.\n Haga click en un texto de la lista a su derecha.");
            }
        }
        /// <summary>
        /// Manejador de evento del boton -
        /// obtiene una unidad del texto seleccionado en el listado de carrito,
        /// lo agrega a libreria (reflejando en base de datos) y lo resta de carrito
        /// *Lanza excepcion si no hay ningun item en carrito*
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMenos_Click(object sender, EventArgs e)
        {
            try
            {
                Texto aux = this.carrito.ObtenerUnaCopia(this.carrito.Items[this.dataGridViewCarrito.CurrentRow.Index]);
                this.sql.AgregarBD(aux);
                this.carrito.Sustraer(aux);
                this.ActualizarLista.Invoke();
            }
            catch (Exception)
            {
                MessageBox.Show("Agregue un producto al carrito haciendo doble click en el item de la lista a su derecha.");
            }
        }
        /// <summary>
        /// Manejador de evento del boton Comprar
        /// Llama al metodo this.ImprimirTicket()
        /// *Lanza excepcion si existe algun error en la salida del archivo de texto*
        /// limpia la lista de carrito
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComprar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImprimirTicket();
                MessageBox.Show("¡Gracias por su compra!\n\nSu ticket se imprimió correctamente.");
                this.carrito.Items.Clear();
                this.ActualizarLista.Invoke();
            }
            catch(Exception)
            {
                MessageBox.Show("Lo siento, sin papel en la ticketeadora.\n   ¡Gracias por su compra!");
            }

        }
        /// <summary>
        /// Manejador de evento del boton Limpiar
        /// Si existen items en carrito, los añade a libreria (reflejando en BD)
        /// limpia la lista de carrito
        /// *Invoca al evento ActualizarLista* 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            if(this.carrito.Items.Count > 0)
            {
                foreach(Texto aux in this.carrito.Items)
                {
                    this.sql.AgregarBD(aux);
                }
            }
            this.carrito.Items.Clear();
            this.ActualizarLista.Invoke();
        }
        /// <summary>
        /// Manejador de evento del boton Solo Empleados
        /// Asigna el manejador this.ABMForm a this.hilo 
        /// (Encargado de correr formulario ABM)
        /// Corre el hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSoloEmpleados_Click(object sender, EventArgs e)
        {
            this.hilo = new Thread(this.ABMForm);
            this.hilo.Start();
        }
        /// <summary>
        /// Evento de cambio de item en combobox medio de pago
        /// Actualiza los valores de la cuenta del carrito conforme cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.carrito.MedioDePago = (ETipoMedioDePago)this.comboBox1.SelectedItem;
            this.labelPtjeDes.Text = this.carrito.DescuentoUsado + "%";
            this.dataGridViewCarrito.DataSource = null;
            this.dataGridViewCarrito.DataSource = this.carrito.Items;
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// *Manejador del evento ActualizarLista*
        /// Obtiene los datos de la base de datos
        /// Actualiza la vista de las listas y labels
        /// </summary>
        private void ActualizarLibreria()
        {
            try
            {
                this.libreria = this.sql.Libreria;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.dataGridViewLibreria.DataSource = null;
            this.dataGridViewLibreria.DataSource = this.libreria.Items;
            this.dataGridViewCarrito.DataSource = null;
            this.dataGridViewCarrito.DataSource = this.carrito.Items;
            //labels
            this.labelParcialValor.Text = this.carrito.PrecioParcial.ToString();
            this.labelParcialDtoValor.Text = this.carrito.CalcularDescuentoMedioDePago().ToString();
            this.labelTotalValor.Text = this.carrito.PrecioFinal.ToString();
        }
        /// <summary>
        /// Obtiene los datos de la base de datos
        /// Configura las columnas de la lista libreria
        /// </summary>
        private void ConfigurarDataGridViewLibreria()
        {
            try
            {
                this.libreria = this.sql.Libreria;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.dataGridViewLibreria.AutoGenerateColumns = false;
            this.dataGridViewLibreria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLibreria.Columns.Add("Codigo", "Codigo");
            this.dataGridViewLibreria.Columns.Add("Titulo", "Titulo");
            this.dataGridViewLibreria.Columns.Add("Tipo", "Tipo");
            this.dataGridViewLibreria.Columns.Add("Genero", "Genero");
            this.dataGridViewLibreria.Columns.Add("Precio", "Precio");
            this.dataGridViewLibreria.Columns.Add("Stock", "Stock");
            this.dataGridViewLibreria.Columns["Codigo"].DataPropertyName = "Codigo";
            this.dataGridViewLibreria.Columns["Titulo"].DataPropertyName = "Titulo";
            this.dataGridViewLibreria.Columns["Tipo"].DataPropertyName = "Tipo";
            this.dataGridViewLibreria.Columns["Genero"].DataPropertyName = "Genero";
            this.dataGridViewLibreria.Columns["Precio"].DataPropertyName = "Precio";
            this.dataGridViewLibreria.Columns["Stock"].DataPropertyName = "Stock";
            this.dataGridViewLibreria.DataSource = this.libreria.Items;
        }
        /// <summary>
        /// Configura las columnas de la lista carrito
        /// </summary>
        private void ConfigurarDataGridViewCarrito()
        {
            this.carrito = new Carrito<Texto>();
            Libro aux = new Libro(1, "asd", 15, Libro.EGenerosLibro.Biográfico, 1);
            this.carrito.Agregar(aux);
            this.carrito.DescuentoCredito = 10;
            this.carrito.DescuentoDebito = 5;
            this.carrito.DescuentoEfectivo = 15;
            this.carrito.DescuentoMercadoPago = 0;
            this.dataGridViewCarrito.AutoGenerateColumns = false;
            this.dataGridViewCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCarrito.Columns.Add("Un.", "Un.");
            this.dataGridViewCarrito.Columns.Add("Titulo", "Titulo");
            this.dataGridViewCarrito.Columns.Add("Precio", "Precio");
            this.dataGridViewCarrito.Columns["Titulo"].DataPropertyName = "Titulo";
            this.dataGridViewCarrito.Columns["Precio"].DataPropertyName = "Precio";
            this.dataGridViewCarrito.Columns["Un."].DataPropertyName = "Stock";
            this.dataGridViewCarrito.DataSource = this.carrito.Items;
            this.carrito.Sustraer(aux);

        }
        /// <summary>
        /// *Imprime archivo de texto*
        /// imprime el ticket al presionar el boton comprar.
        /// guarda archivo ticket.log en carpeta por defecto.
        /// de existir archivo previo se sobreescriben los datos
        /// </summary>
        private void ImprimirTicket()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("ticket.log",false))
                {
                    sw.WriteLine(this.carrito.RealizarVenta());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// *Manejador del hilo*
        /// genera y muestra instancia de FormABM
        /// si resultado es OK actualiza datos desde la base de datos
        /// *Invoca al evento ActualizarLista* 
        /// Aborta el proceso del hilo, invalida la excepcion ThreadAbortException.
        /// Lanza excepcion en caso de error.
        /// </summary>
        private void ABMForm()
        {
            FormABM formAbm = new FormABM(this);
            try
            {
                if(formAbm.ShowDialog() == DialogResult.OK)
                {
                    this.libreria = this.sql.Libreria;
                    this.ActualizarLista.Invoke();
                }
                this.hilo.Abort();
            }
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException)) 
                {
                    MessageBox.Show("Hubo un error al mostrar el formulario.\n"+ex.Message); 
                }
            }
        }
        #endregion
    }
}
