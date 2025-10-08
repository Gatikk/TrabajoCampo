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
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.buttonLimpiarPantalla_502ag = new System.Windows.Forms.Button();
            this.buttonGenerarDiagnosticoFinal_502ag = new System.Windows.Forms.Button();
            this.labelRepuestosAAgregar_502ag = new System.Windows.Forms.Label();
            this.dgvRepuestos_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaCodigoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBRepuesto_502ag = new System.Windows.Forms.ComboBox();
            this.nUDRepuesto_502ag = new System.Windows.Forms.NumericUpDown();
            this.labelAgregarRepuesto_502ag = new System.Windows.Forms.Label();
            this.buttonAgregar_502ag = new System.Windows.Forms.Button();
            this.buttonBajaRepuesto_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombustibles_502ag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHoras_502ag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos_502ag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRepuesto_502ag)).BeginInit();
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
            this.labelTiempo.Location = new System.Drawing.Point(718, 66);
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
            this.nUDHoras_502ag.Location = new System.Drawing.Point(771, 87);
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
            this.labelHoras_502ag.Location = new System.Drawing.Point(821, 89);
            this.labelHoras_502ag.Name = "labelHoras_502ag";
            this.labelHoras_502ag.Size = new System.Drawing.Size(46, 17);
            this.labelHoras_502ag.TabIndex = 56;
            this.labelHoras_502ag.Text = "Horas";
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(982, 408);
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
            this.buttonLimpiarPantalla_502ag.Location = new System.Drawing.Point(849, 408);
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
            this.buttonGenerarDiagnosticoFinal_502ag.Location = new System.Drawing.Point(850, 353);
            this.buttonGenerarDiagnosticoFinal_502ag.Name = "buttonGenerarDiagnosticoFinal_502ag";
            this.buttonGenerarDiagnosticoFinal_502ag.Size = new System.Drawing.Size(254, 40);
            this.buttonGenerarDiagnosticoFinal_502ag.TabIndex = 60;
            this.buttonGenerarDiagnosticoFinal_502ag.Text = "Generar Diagnóstico Final";
            this.buttonGenerarDiagnosticoFinal_502ag.UseVisualStyleBackColor = false;
            this.buttonGenerarDiagnosticoFinal_502ag.Click += new System.EventHandler(this.buttonGenerarDiagnosticoFinal_502ag_Click);
            // 
            // labelRepuestosAAgregar_502ag
            // 
            this.labelRepuestosAAgregar_502ag.AutoSize = true;
            this.labelRepuestosAAgregar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRepuestosAAgregar_502ag.Location = new System.Drawing.Point(431, 233);
            this.labelRepuestosAAgregar_502ag.Name = "labelRepuestosAAgregar_502ag";
            this.labelRepuestosAAgregar_502ag.Size = new System.Drawing.Size(161, 20);
            this.labelRepuestosAAgregar_502ag.TabIndex = 61;
            this.labelRepuestosAAgregar_502ag.Text = "Repuestos a Agregar";
            // 
            // dgvRepuestos_502ag
            // 
            this.dgvRepuestos_502ag.AllowUserToAddRows = false;
            this.dgvRepuestos_502ag.AllowUserToDeleteRows = false;
            this.dgvRepuestos_502ag.AllowUserToResizeColumns = false;
            this.dgvRepuestos_502ag.AllowUserToResizeRows = false;
            this.dgvRepuestos_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRepuestos_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepuestos_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaCodigoR,
            this.ColumnaDescripcion,
            this.Columna,
            this.ColumnaCantidad});
            this.dgvRepuestos_502ag.Location = new System.Drawing.Point(435, 256);
            this.dgvRepuestos_502ag.MultiSelect = false;
            this.dgvRepuestos_502ag.Name = "dgvRepuestos_502ag";
            this.dgvRepuestos_502ag.ReadOnly = true;
            this.dgvRepuestos_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepuestos_502ag.Size = new System.Drawing.Size(366, 137);
            this.dgvRepuestos_502ag.TabIndex = 62;
            // 
            // ColumnaCodigoR
            // 
            this.ColumnaCodigoR.HeaderText = "CodRepuesto";
            this.ColumnaCodigoR.Name = "ColumnaCodigoR";
            this.ColumnaCodigoR.ReadOnly = true;
            // 
            // ColumnaDescripcion
            // 
            this.ColumnaDescripcion.HeaderText = "Descripcion";
            this.ColumnaDescripcion.Name = "ColumnaDescripcion";
            this.ColumnaDescripcion.ReadOnly = true;
            // 
            // Columna
            // 
            this.Columna.HeaderText = "PrecioUnitario";
            this.Columna.Name = "Columna";
            this.Columna.ReadOnly = true;
            // 
            // ColumnaCantidad
            // 
            this.ColumnaCantidad.HeaderText = "Cantidad";
            this.ColumnaCantidad.Name = "ColumnaCantidad";
            this.ColumnaCantidad.ReadOnly = true;
            // 
            // cBRepuesto_502ag
            // 
            this.cBRepuesto_502ag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBRepuesto_502ag.FormattingEnabled = true;
            this.cBRepuesto_502ag.Location = new System.Drawing.Point(720, 152);
            this.cBRepuesto_502ag.Name = "cBRepuesto_502ag";
            this.cBRepuesto_502ag.Size = new System.Drawing.Size(165, 21);
            this.cBRepuesto_502ag.TabIndex = 63;
            this.cBRepuesto_502ag.SelectedIndexChanged += new System.EventHandler(this.cBRepuesto_502ag_SelectedIndexChanged);
            // 
            // nUDRepuesto_502ag
            // 
            this.nUDRepuesto_502ag.Location = new System.Drawing.Point(891, 152);
            this.nUDRepuesto_502ag.Name = "nUDRepuesto_502ag";
            this.nUDRepuesto_502ag.ReadOnly = true;
            this.nUDRepuesto_502ag.Size = new System.Drawing.Size(37, 20);
            this.nUDRepuesto_502ag.TabIndex = 64;
            this.nUDRepuesto_502ag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAgregarRepuesto_502ag
            // 
            this.labelAgregarRepuesto_502ag.AutoSize = true;
            this.labelAgregarRepuesto_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAgregarRepuesto_502ag.Location = new System.Drawing.Point(743, 132);
            this.labelAgregarRepuesto_502ag.Name = "labelAgregarRepuesto_502ag";
            this.labelAgregarRepuesto_502ag.Size = new System.Drawing.Size(124, 17);
            this.labelAgregarRepuesto_502ag.TabIndex = 65;
            this.labelAgregarRepuesto_502ag.Text = "Agregar Repuesto";
            // 
            // buttonAgregar_502ag
            // 
            this.buttonAgregar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAgregar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAgregar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAgregar_502ag.Location = new System.Drawing.Point(755, 179);
            this.buttonAgregar_502ag.Name = "buttonAgregar_502ag";
            this.buttonAgregar_502ag.Size = new System.Drawing.Size(99, 30);
            this.buttonAgregar_502ag.TabIndex = 66;
            this.buttonAgregar_502ag.Text = "Agregar";
            this.buttonAgregar_502ag.UseVisualStyleBackColor = false;
            this.buttonAgregar_502ag.Click += new System.EventHandler(this.buttonAgregar_502ag_Click);
            // 
            // buttonBajaRepuesto_502ag
            // 
            this.buttonBajaRepuesto_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonBajaRepuesto_502ag.FlatAppearance.BorderSize = 0;
            this.buttonBajaRepuesto_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBajaRepuesto_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBajaRepuesto_502ag.Location = new System.Drawing.Point(435, 399);
            this.buttonBajaRepuesto_502ag.Name = "buttonBajaRepuesto_502ag";
            this.buttonBajaRepuesto_502ag.Size = new System.Drawing.Size(99, 30);
            this.buttonBajaRepuesto_502ag.TabIndex = 67;
            this.buttonBajaRepuesto_502ag.Text = "Baja";
            this.buttonBajaRepuesto_502ag.UseVisualStyleBackColor = false;
            this.buttonBajaRepuesto_502ag.Click += new System.EventHandler(this.buttonBajaRepuesto_502ag_Click);
            // 
            // FormGenerarDiagnosticoFinal_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 457);
            this.Controls.Add(this.buttonBajaRepuesto_502ag);
            this.Controls.Add(this.buttonAgregar_502ag);
            this.Controls.Add(this.labelAgregarRepuesto_502ag);
            this.Controls.Add(this.nUDRepuesto_502ag);
            this.Controls.Add(this.cBRepuesto_502ag);
            this.Controls.Add(this.dgvRepuestos_502ag);
            this.Controls.Add(this.labelRepuestosAAgregar_502ag);
            this.Controls.Add(this.buttonGenerarDiagnosticoFinal_502ag);
            this.Controls.Add(this.buttonLimpiarPantalla_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos_502ag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRepuesto_502ag)).EndInit();
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
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Button buttonLimpiarPantalla_502ag;
        private System.Windows.Forms.Button buttonGenerarDiagnosticoFinal_502ag;
        private System.Windows.Forms.Label labelRepuestosAAgregar_502ag;
        private System.Windows.Forms.DataGridView dgvRepuestos_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCodigoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCantidad;
        private System.Windows.Forms.ComboBox cBRepuesto_502ag;
        private System.Windows.Forms.NumericUpDown nUDRepuesto_502ag;
        private System.Windows.Forms.Label labelAgregarRepuesto_502ag;
        private System.Windows.Forms.Button buttonAgregar_502ag;
        private System.Windows.Forms.Button buttonBajaRepuesto_502ag;
    }
}