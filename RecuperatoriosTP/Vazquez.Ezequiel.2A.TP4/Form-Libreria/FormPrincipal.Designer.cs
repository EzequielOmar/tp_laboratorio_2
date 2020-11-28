
namespace Form_Libreria
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.dataGridViewCarrito = new System.Windows.Forms.DataGridView();
            this.dataGridViewLibreria = new System.Windows.Forms.DataGridView();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonMenos = new System.Windows.Forms.Button();
            this.buttonMas = new System.Windows.Forms.Button();
            this.buttonSoloEmpleados = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelParcial = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelParcialValor = new System.Windows.Forms.Label();
            this.labelTotalValor = new System.Windows.Forms.Label();
            this.labelDtoMedioPago = new System.Windows.Forms.Label();
            this.labelPtjeDes = new System.Windows.Forms.Label();
            this.labelParcialDtoValor = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibreria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCarrito
            // 
            this.dataGridViewCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCarrito.Location = new System.Drawing.Point(12, 81);
            this.dataGridViewCarrito.Name = "dataGridViewCarrito";
            this.dataGridViewCarrito.Size = new System.Drawing.Size(343, 266);
            this.dataGridViewCarrito.TabIndex = 0;
            this.dataGridViewCarrito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCarrito_CellContentClick);
            // 
            // dataGridViewLibreria
            // 
            this.dataGridViewLibreria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibreria.Location = new System.Drawing.Point(436, 81);
            this.dataGridViewLibreria.Name = "dataGridViewLibreria";
            this.dataGridViewLibreria.Size = new System.Drawing.Size(648, 546);
            this.dataGridViewLibreria.TabIndex = 1;
            this.dataGridViewLibreria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLibreria_CellClick);
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(15, 516);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(112, 42);
            this.buttonComprar.TabIndex = 2;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(15, 585);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(112, 42);
            this.buttonLimpiar.TabIndex = 3;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonMenos
            // 
            this.buttonMenos.Location = new System.Drawing.Point(213, 507);
            this.buttonMenos.Name = "buttonMenos";
            this.buttonMenos.Size = new System.Drawing.Size(25, 30);
            this.buttonMenos.TabIndex = 4;
            this.buttonMenos.Text = "-";
            this.buttonMenos.UseVisualStyleBackColor = true;
            this.buttonMenos.Click += new System.EventHandler(this.buttonMenos_Click);
            // 
            // buttonMas
            // 
            this.buttonMas.Location = new System.Drawing.Point(164, 507);
            this.buttonMas.Name = "buttonMas";
            this.buttonMas.Size = new System.Drawing.Size(25, 30);
            this.buttonMas.TabIndex = 5;
            this.buttonMas.Text = "+";
            this.buttonMas.UseVisualStyleBackColor = true;
            this.buttonMas.Click += new System.EventHandler(this.buttonMas_Click);
            // 
            // buttonSoloEmpleados
            // 
            this.buttonSoloEmpleados.Location = new System.Drawing.Point(965, 642);
            this.buttonSoloEmpleados.Name = "buttonSoloEmpleados";
            this.buttonSoloEmpleados.Size = new System.Drawing.Size(112, 42);
            this.buttonSoloEmpleados.TabIndex = 6;
            this.buttonSoloEmpleados.Text = "Solo Empleados";
            this.buttonSoloEmpleados.UseVisualStyleBackColor = true;
            this.buttonSoloEmpleados.Click += new System.EventHandler(this.buttonSoloEmpleados_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(274, 516);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelParcial
            // 
            this.labelParcial.AutoSize = true;
            this.labelParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParcial.Location = new System.Drawing.Point(12, 370);
            this.labelParcial.Name = "labelParcial";
            this.labelParcial.Size = new System.Drawing.Size(95, 17);
            this.labelParcial.TabIndex = 8;
            this.labelParcial.Text = "Precio Parcial";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(12, 445);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(92, 20);
            this.labelTotal.TabIndex = 9;
            this.labelTotal.Text = "Precio Total";
            // 
            // labelParcialValor
            // 
            this.labelParcialValor.AutoSize = true;
            this.labelParcialValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParcialValor.Location = new System.Drawing.Point(327, 370);
            this.labelParcialValor.Name = "labelParcialValor";
            this.labelParcialValor.Size = new System.Drawing.Size(0, 17);
            this.labelParcialValor.TabIndex = 10;
            // 
            // labelTotalValor
            // 
            this.labelTotalValor.AutoSize = true;
            this.labelTotalValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalValor.Location = new System.Drawing.Point(327, 443);
            this.labelTotalValor.Name = "labelTotalValor";
            this.labelTotalValor.Size = new System.Drawing.Size(0, 22);
            this.labelTotalValor.TabIndex = 11;
            // 
            // labelDtoMedioPago
            // 
            this.labelDtoMedioPago.AutoSize = true;
            this.labelDtoMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDtoMedioPago.Location = new System.Drawing.Point(12, 400);
            this.labelDtoMedioPago.Name = "labelDtoMedioPago";
            this.labelDtoMedioPago.Size = new System.Drawing.Size(140, 15);
            this.labelDtoMedioPago.TabIndex = 12;
            this.labelDtoMedioPago.Text = "Dto. por  Medio de Pago";
            // 
            // labelPtjeDes
            // 
            this.labelPtjeDes.AutoSize = true;
            this.labelPtjeDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPtjeDes.Location = new System.Drawing.Point(175, 400);
            this.labelPtjeDes.Name = "labelPtjeDes";
            this.labelPtjeDes.Size = new System.Drawing.Size(25, 15);
            this.labelPtjeDes.TabIndex = 13;
            this.labelPtjeDes.Text = "0%";
            // 
            // labelParcialDtoValor
            // 
            this.labelParcialDtoValor.AutoSize = true;
            this.labelParcialDtoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParcialDtoValor.Location = new System.Drawing.Point(327, 400);
            this.labelParcialDtoValor.Name = "labelParcialDtoValor";
            this.labelParcialDtoValor.Size = new System.Drawing.Size(0, 17);
            this.labelParcialDtoValor.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(164, 553);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 74);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(984, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 74);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "** Haga click en el libro que desee **";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 706);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelParcialDtoValor);
            this.Controls.Add(this.labelPtjeDes);
            this.Controls.Add(this.labelDtoMedioPago);
            this.Controls.Add(this.labelTotalValor);
            this.Controls.Add(this.labelParcialValor);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelParcial);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSoloEmpleados);
            this.Controls.Add(this.buttonMas);
            this.Controls.Add(this.buttonMenos);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.dataGridViewLibreria);
            this.Controls.Add(this.dataGridViewCarrito);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¡Bienvenides!     - LIBRERIA  - EL OLIMPO -";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibreria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCarrito;
        protected System.Windows.Forms.DataGridView dataGridViewLibreria;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonMenos;
        private System.Windows.Forms.Button buttonMas;
        private System.Windows.Forms.Button buttonSoloEmpleados;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelParcial;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelParcialValor;
        private System.Windows.Forms.Label labelTotalValor;
        private System.Windows.Forms.Label labelDtoMedioPago;
        private System.Windows.Forms.Label labelPtjeDes;
        private System.Windows.Forms.Label labelParcialDtoValor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}

