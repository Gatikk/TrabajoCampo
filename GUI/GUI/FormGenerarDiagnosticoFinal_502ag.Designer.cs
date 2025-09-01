namespace GUI
{
    partial class FormGenerarDiagnosticoFinal_502ag
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGenerarDF_502ag = new System.Windows.Forms.Label();
            this.labelOrdenesAbiertas_502ag = new System.Windows.Forms.Label();
            this.dgvCombustibles_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaPatente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSeleccionarOrden_502ag = new System.Windows.Forms.Button();
            this.buttonVerObservacion_502ag = new System.Windows.Forms.Button();
            this.labelDetallesVehiculo_502ag = new System.Windows.Forms.Label();
            this.labelAnio_502ag = new System.Windows.Forms.Label();
            this.labelModelo_502ag = new System.Windows.Forms.Label();
            this.labelMarca_502ag = new System.Windows.Forms.Label();
            this.labelPatente_502ag = new System.Windows.Forms.Label();
            this.tBAnio_502ag = new System.Windows.Forms.TextBox();
            this.tBModelo_502ag = new System.Windows.Forms.TextBox();
            this.tBMarca_502ag = new System.Windows.Forms.TextBox();
            this.tBPatente_502ag = new System.Windows.Forms.TextBox();
            this.labelFormulario_502ag = new System.Windows.Forms.Label();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.labelDescripcionFinal_502ag = new System.Windows.Forms.Label();
            this.rTBDescripcionFinal_502ag = new System.Windows.Forms.RichTextBox();
            this.nUDHoras_502ag = new System.Windows.Forms.NumericUpDown();
            this.labelHoras_502ag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.buttonLimpiarPantalla_502ag = new System.Windows.Forms.Button();
            this.buttonGenerarDiagnosticoFinal_502ag = new System.Windows.Forms.Button();
            this.tBCostoPartes_502ag = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombustibles_502ag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHoras_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGenerarDF_502ag
            // 
            this.labelGenerarDF_502ag.AutoSize = true;
            this.labelGenerarDF_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelGenerarDF_502ag.Location = new System.Drawing.Point(12, 9);
            this.labelGenerarDF_502ag.Name = "labelGenerarDF_502ag";
            this.labelGenerarDF_502ag.Size = new System.Drawing.Size(228, 24);
            this.labelGenerarDF_502ag.TabIndex = 0;
            this.labelGenerarDF_502ag.Text = "Generar Diagnóstico Final";
            // 
            // labelOrdenesAbiertas_502ag
            // 
            this.labelOrdenesAbiertas_502ag.AutoSize = true;
            this.labelOrdenesAbiertas_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelOrdenesAbiertas_502ag.Location = new System.Drawing.Point(12, 43);
            this.labelOrdenesAbiertas_502ag.Name = "labelOrdenesAbiertas_502ag";
            this.labelOrdenesAbiertas_502ag.Size = new System.Drawing.Size(133, 20);
            this.labelOrdenesAbiertas_502ag.TabIndex = 1;
            this.labelOrdenesAbiertas_502ag.Text = "Órdenes Abiertas";
            // 
            // dgvCombustibles_502ag
            // 
            this.dgvCombustibles_502ag.AllowUserToAddRows = false;
            this.dgvCombustibles_502ag.AllowUserToDeleteRows = false;
            this.dgvCombustibles_502ag.AllowUserToResizeColumns = false;
            this.dgvCombustibles_502ag.AllowUserToResizeRows = false;
            this.dgvCombustibles_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCombustibles_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCombustibles_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaCodigo,
            this.ColumnaPatente,
            this.ColumnaFecha,
            this.ColumnaHora});
            this.dgvCombustibles_502ag.Location = new System.Drawing.Point(16, 66);
            this.dgvCombustibles_502ag.MultiSelect = false;
            this.dgvCombustibles_502ag.Name = "dgvCombustibles_502ag";
            this.dgvCombustibles_502ag.ReadOnly = true;
            this.dgvCombustibles_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCombustibles_502ag.Size = new System.Drawing.Size(332, 123);
            this.dgvCombustibles_502ag.TabIndex = 38;
            // 
            // ColumnaCodigo
            // 
            this.ColumnaCodigo.HeaderText = "Codigo";
            this.ColumnaCodigo.Name = "ColumnaCodigo";
            this.ColumnaCodigo.ReadOnly = true;
            // 
            // ColumnaPatente
            // 
            this.ColumnaPatente.HeaderText = "Patente";
            this.ColumnaPatente.Name = "ColumnaPatente";
            this.ColumnaPatente.ReadOnly = true;
            // 
            // ColumnaFecha
            // 
            this.ColumnaFecha.HeaderText = "Fecha";
            this.ColumnaFecha.Name = "ColumnaFecha";
            this.ColumnaFecha.ReadOnly = true;
            // 
            // ColumnaHora
            // 
            this.ColumnaHora.HeaderText = "Hora";
            this.ColumnaHora.Name = "ColumnaHora";
            this.ColumnaHora.ReadOnly = true;
            // 
            // buttonSeleccionarOrden_502ag
            // 
            this.buttonSeleccionarOrden_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSeleccionarOrden_502ag.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionarOrden_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionarOrden_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonSeleccionarOrden_502ag.Location = new System.Drawing.Point(16, 195);
            this.buttonSeleccionarOrden_502ag.Name = "buttonSeleccionarOrden_502ag";
            this.buttonSeleccionarOrden_502ag.Size = new System.Drawing.Size(129, 40);
            this.buttonSeleccionarOrden_502ag.TabIndex = 40;
            this.buttonSeleccionarOrden_502ag.Text = "Seleccionar Orden";
            this.buttonSeleccionarOrden_502ag.UseVisualStyleBackColor = false;
            this.buttonSeleccionarOrden_502ag.Click += new System.EventHandler(this.buttonSeleccionarOrden_502ag_Click);
            // 
            // buttonVerObservacion_502ag
            // 
            this.buttonVerObservacion_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVerObservacion_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVerObservacion_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerObservacion_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonVerObservacion_502ag.Location = new System.Drawing.Point(219, 195);
            this.buttonVerObservacion_502ag.Name = "buttonVerObservacion_502ag";
            this.buttonVerObservacion_502ag.Size = new System.Drawing.Size(129, 40);
            this.buttonVerObservacion_502ag.TabIndex = 41;
            this.buttonVerObservacion_502ag.Text = "Ver Observación";
            this.buttonVerObservacion_502ag.UseVisualStyleBackColor = false;
            this.buttonVerObservacion_502ag.Click += new System.EventHandler(this.buttonVerObservacion_502ag_Click);
            // 
            // labelDetallesVehiculo_502ag
            // 
            this.labelDetallesVehiculo_502ag.AutoSize = true;
            this.labelDetallesVehiculo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDetallesVehiculo_502ag.Location = new System.Drawing.Point(96, 256);
            this.labelDetallesVehiculo_502ag.Name = "labelDetallesVehiculo_502ag";
            this.labelDetallesVehiculo_502ag.Size = new System.Drawing.Size(157, 20);
            this.labelDetallesVehiculo_502ag.TabIndex = 42;
            this.labelDetallesVehiculo_502ag.Text = "Detalles del Vehículo";
            // 
            // labelAnio_502ag
            // 
            this.labelAnio_502ag.AutoSize = true;
            this.labelAnio_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAnio_502ag.Location = new System.Drawing.Point(97, 366);
            this.labelAnio_502ag.Name = "labelAnio_502ag";
            this.labelAnio_502ag.Size = new System.Drawing.Size(33, 17);
            this.labelAnio_502ag.TabIndex = 50;
            this.labelAnio_502ag.Text = "Año";
            // 
            // labelModelo_502ag
            // 
            this.labelModelo_502ag.AutoSize = true;
            this.labelModelo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelModelo_502ag.Location = new System.Drawing.Point(97, 338);
            this.labelModelo_502ag.Name = "labelModelo_502ag";
            this.labelModelo_502ag.Size = new System.Drawing.Size(54, 17);
            this.labelModelo_502ag.TabIndex = 49;
            this.labelModelo_502ag.Text = "Modelo";
            // 
            // labelMarca_502ag
            // 
            this.labelMarca_502ag.AutoSize = true;
            this.labelMarca_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelMarca_502ag.Location = new System.Drawing.Point(97, 310);
            this.labelMarca_502ag.Name = "labelMarca_502ag";
            this.labelMarca_502ag.Size = new System.Drawing.Size(47, 17);
            this.labelMarca_502ag.TabIndex = 48;
            this.labelMarca_502ag.Text = "Marca";
            // 
            // labelPatente_502ag
            // 
            this.labelPatente_502ag.AutoSize = true;
            this.labelPatente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPatente_502ag.Location = new System.Drawing.Point(97, 282);
            this.labelPatente_502ag.Name = "labelPatente_502ag";
            this.labelPatente_502ag.Size = new System.Drawing.Size(57, 17);
            this.labelPatente_502ag.TabIndex = 47;
            this.labelPatente_502ag.Text = "Patente";
            // 
            // tBAnio_502ag
            // 
            this.tBAnio_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBAnio_502ag.Location = new System.Drawing.Point(160, 363);
            this.tBAnio_502ag.Name = "tBAnio_502ag";
            this.tBAnio_502ag.ReadOnly = true;
            this.tBAnio_502ag.Size = new System.Drawing.Size(122, 23);
            this.tBAnio_502ag.TabIndex = 46;
            // 
            // tBModelo_502ag
            // 
            this.tBModelo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBModelo_502ag.Location = new System.Drawing.Point(160, 335);
            this.tBModelo_502ag.Name = "tBModelo_502ag";
            this.tBModelo_502ag.ReadOnly = true;
            this.tBModelo_502ag.Size = new System.Drawing.Size(122, 23);
            this.tBModelo_502ag.TabIndex = 45;
            // 
            // tBMarca_502ag
            // 
            this.tBMarca_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBMarca_502ag.Location = new System.Drawing.Point(160, 307);
            this.tBMarca_502ag.Name = "tBMarca_502ag";
            this.tBMarca_502ag.ReadOnly = true;
            this.tBMarca_502ag.Size = new System.Drawing.Size(122, 23);
            this.tBMarca_502ag.TabIndex = 44;
            // 
            // tBPatente_502ag
            // 
            this.tBPatente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBPatente_502ag.Location = new System.Drawing.Point(160, 279);
            this.tBPatente_502ag.Name = "tBPatente_502ag";
            this.tBPatente_502ag.ReadOnly = true;
            this.tBPatente_502ag.Size = new System.Drawing.Size(122, 23);
            this.tBPatente_502ag.TabIndex = 43;
            // 
            // labelFormulario_502ag
            // 
            this.labelFormulario_502ag.AutoSize = true;
            this.labelFormulario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFormulario_502ag.Location = new System.Drawing.Point(431, 43);
            this.labelFormulario_502ag.Name = "labelFormulario_502ag";
            this.labelFormulario_502ag.Size = new System.Drawing.Size(84, 20);
            this.labelFormulario_502ag.TabIndex = 51;
            this.labelFormulario_502ag.Text = "Formulario";
            // 
            // labelTiempo
            // 
            this.labelTiempo.AutoSize = true;
            this.labelTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTiempo.Location = new System.Drawing.Point(450, 208);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(210, 17);
            this.labelTiempo.TabIndex = 52;
            this.labelTiempo.Text = "Tiempo trabajado en el vehículo";
            // 
            // labelDescripcionFinal_502ag
            // 
            this.labelDescripcionFinal_502ag.AutoSize = true;
            this.labelDescripcionFinal_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDescripcionFinal_502ag.Location = new System.Drawing.Point(500, 66);
            this.labelDescripcionFinal_502ag.Name = "labelDescripcionFinal_502ag";
            this.labelDescripcionFinal_502ag.Size = new System.Drawing.Size(116, 17);
            this.labelDescripcionFinal_502ag.TabIndex = 53;
            this.labelDescripcionFinal_502ag.Text = "Descripción Final";
            // 
            // rTBDescripcionFinal_502ag
            // 
            this.rTBDescripcionFinal_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rTBDescripcionFinal_502ag.Location = new System.Drawing.Point(435, 86);
            this.rTBDescripcionFinal_502ag.Name = "rTBDescripcionFinal_502ag";
            this.rTBDescripcionFinal_502ag.Size = new System.Drawing.Size(255, 119);
            this.rTBDescripcionFinal_502ag.TabIndex = 54;
            this.rTBDescripcionFinal_502ag.Text = "";
            // 
            // nUDHoras_502ag
            // 
            this.nUDHoras_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nUDHoras_502ag.Location = new System.Drawing.Point(520, 228);
            this.nUDHoras_502ag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDHoras_502ag.Name = "nUDHoras_502ag";
            this.nUDHoras_502ag.ReadOnly = true;
            this.nUDHoras_502ag.Size = new System.Drawing.Size(44, 23);
            this.nUDHoras_502ag.TabIndex = 55;
            this.nUDHoras_502ag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelHoras_502ag
            // 
            this.labelHoras_502ag.AutoSize = true;
            this.labelHoras_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHoras_502ag.Location = new System.Drawing.Point(570, 230);
            this.labelHoras_502ag.Name = "labelHoras_502ag";
            this.labelHoras_502ag.Size = new System.Drawing.Size(46, 17);
            this.labelHoras_502ag.TabIndex = 56;
            this.labelHoras_502ag.Text = "Horas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(459, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Costo de partes";
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(568, 353);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(122, 40);
            this.buttonVolverAlMenu_502ag.TabIndex = 58;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // buttonLimpiarPantalla_502ag
            // 
            this.buttonLimpiarPantalla_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLimpiarPantalla_502ag.FlatAppearance.BorderSize = 0;
            this.buttonLimpiarPantalla_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpiarPantalla_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLimpiarPantalla_502ag.Location = new System.Drawing.Point(435, 353);
            this.buttonLimpiarPantalla_502ag.Name = "buttonLimpiarPantalla_502ag";
            this.buttonLimpiarPantalla_502ag.Size = new System.Drawing.Size(122, 40);
            this.buttonLimpiarPantalla_502ag.TabIndex = 59;
            this.buttonLimpiarPantalla_502ag.Text = "Limpiar Pantalla";
            this.buttonLimpiarPantalla_502ag.UseVisualStyleBackColor = false;
            this.buttonLimpiarPantalla_502ag.Click += new System.EventHandler(this.buttonLimpiarPantalla_502ag_Click);
            // 
            // buttonGenerarDiagnosticoFinal_502ag
            // 
            this.buttonGenerarDiagnosticoFinal_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonGenerarDiagnosticoFinal_502ag.FlatAppearance.BorderSize = 0;
            this.buttonGenerarDiagnosticoFinal_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarDiagnosticoFinal_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonGenerarDiagnosticoFinal_502ag.Location = new System.Drawing.Point(435, 279);
            this.buttonGenerarDiagnosticoFinal_502ag.Name = "buttonGenerarDiagnosticoFinal_502ag";
            this.buttonGenerarDiagnosticoFinal_502ag.Size = new System.Drawing.Size(254, 40);
            this.buttonGenerarDiagnosticoFinal_502ag.TabIndex = 60;
            this.buttonGenerarDiagnosticoFinal_502ag.Text = "Generar Diagnóstico Final";
            this.buttonGenerarDiagnosticoFinal_502ag.UseVisualStyleBackColor = false;
            this.buttonGenerarDiagnosticoFinal_502ag.Click += new System.EventHandler(this.buttonGenerarDiagnosticoFinal_502ag_Click);
            // 
            // tBCostoPartes_502ag
            // 
            this.tBCostoPartes_502ag.Location = new System.Drawing.Point(573, 252);
            this.tBCostoPartes_502ag.Name = "tBCostoPartes_502ag";
            this.tBCostoPartes_502ag.Size = new System.Drawing.Size(96, 20);
            this.tBCostoPartes_502ag.TabIndex = 61;
            // 
            // FormGenerarDiagnosticoFinal_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 404);
            this.Controls.Add(this.tBCostoPartes_502ag);
            this.Controls.Add(this.buttonGenerarDiagnosticoFinal_502ag);
            this.Controls.Add(this.buttonLimpiarPantalla_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHoras_502ag);
            this.Controls.Add(this.nUDHoras_502ag);
            this.Controls.Add(this.rTBDescripcionFinal_502ag);
            this.Controls.Add(this.labelDescripcionFinal_502ag);
            this.Controls.Add(this.labelTiempo);
            this.Controls.Add(this.labelFormulario_502ag);
            this.Controls.Add(this.labelAnio_502ag);
            this.Controls.Add(this.labelModelo_502ag);
            this.Controls.Add(this.labelMarca_502ag);
            this.Controls.Add(this.labelPatente_502ag);
            this.Controls.Add(this.tBAnio_502ag);
            this.Controls.Add(this.tBModelo_502ag);
            this.Controls.Add(this.tBMarca_502ag);
            this.Controls.Add(this.tBPatente_502ag);
            this.Controls.Add(this.labelDetallesVehiculo_502ag);
            this.Controls.Add(this.buttonVerObservacion_502ag);
            this.Controls.Add(this.buttonSeleccionarOrden_502ag);
            this.Controls.Add(this.dgvCombustibles_502ag);
            this.Controls.Add(this.labelOrdenesAbiertas_502ag);
            this.Controls.Add(this.labelGenerarDF_502ag);
            this.Name = "FormGenerarDiagnosticoFinal_502ag";
            this.Text = "FormGenerarDiagnosticoFinal_502ag";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombustibles_502ag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHoras_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGenerarDF_502ag;
        private System.Windows.Forms.Label labelOrdenesAbiertas_502ag;
        private System.Windows.Forms.DataGridView dgvCombustibles_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaPatente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaHora;
        private System.Windows.Forms.Button buttonSeleccionarOrden_502ag;
        private System.Windows.Forms.Button buttonVerObservacion_502ag;
        private System.Windows.Forms.Label labelDetallesVehiculo_502ag;
        private System.Windows.Forms.Label labelAnio_502ag;
        private System.Windows.Forms.Label labelModelo_502ag;
        private System.Windows.Forms.Label labelMarca_502ag;
        private System.Windows.Forms.Label labelPatente_502ag;
        private System.Windows.Forms.TextBox tBAnio_502ag;
        private System.Windows.Forms.TextBox tBModelo_502ag;
        private System.Windows.Forms.TextBox tBMarca_502ag;
        private System.Windows.Forms.TextBox tBPatente_502ag;
        private System.Windows.Forms.Label labelFormulario_502ag;
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.Label labelDescripcionFinal_502ag;
        private System.Windows.Forms.RichTextBox rTBDescripcionFinal_502ag;
        private System.Windows.Forms.NumericUpDown nUDHoras_502ag;
        private System.Windows.Forms.Label labelHoras_502ag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Button buttonLimpiarPantalla_502ag;
        private System.Windows.Forms.Button buttonGenerarDiagnosticoFinal_502ag;
        private System.Windows.Forms.TextBox tBCostoPartes_502ag;
    }
}