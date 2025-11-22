namespace GUI
{
    partial class FormCargarCombustible_502ag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargarCombustible_502ag));
            this.dgvCombustibles_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSeleccionarCombustible_502ag = new System.Windows.Forms.Button();
            this.labelCodigo_502ag = new System.Windows.Forms.Label();
            this.tBCodigo_502ag = new System.Windows.Forms.TextBox();
            this.labelCantidad_502ag = new System.Windows.Forms.Label();
            this.tBCantidad_502ag = new System.Windows.Forms.TextBox();
            this.buttonComenzarCarga_502ag = new System.Windows.Forms.Button();
            this.rBCantidad_502ag = new System.Windows.Forms.RadioButton();
            this.rBMonto_502ag = new System.Windows.Forms.RadioButton();
            this.rTBDetallesCarga_502ag = new System.Windows.Forms.RichTextBox();
            this.buttonDetenerCarga_502ag = new System.Windows.Forms.Button();
            this.buttonReanudarCarga_502ag = new System.Windows.Forms.Button();
            this.buttonFinalizarCarga_502ag = new System.Windows.Forms.Button();
            this.tBDNI_502ag = new System.Windows.Forms.TextBox();
            this.labelDNI_502ag = new System.Windows.Forms.Label();
            this.buttonIdentificarCliente_502ag = new System.Windows.Forms.Button();
            this.buttonRegistrarCliente_502ag = new System.Windows.Forms.Button();
            this.labelSeleccionarCombustible_502ag = new System.Windows.Forms.Label();
            this.labelCargarCombustible_502ag = new System.Windows.Forms.Label();
            this.labelIdentificarCliente_502ag = new System.Windows.Forms.Label();
            this.tBNombre_502ag = new System.Windows.Forms.TextBox();
            this.tBApellido_502ag = new System.Windows.Forms.TextBox();
            this.labelNombre_502ag = new System.Windows.Forms.Label();
            this.labelApellido_502ag = new System.Windows.Forms.Label();
            this.buttonCobrarCliente_502ag = new System.Windows.Forms.Button();
            this.dgvFacturas_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaCodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSeleccionarFactura_502ag = new System.Windows.Forms.Button();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.labelFacturaIncompleta_502ag = new System.Windows.Forms.Label();
            this.buttonAyuda2_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombustibles_502ag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas_502ag)).BeginInit();
            this.SuspendLayout();
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
            this.ColumnaNombreCombustible,
            this.ColumnaCantidad,
            this.ColumnaPrecio});
            this.dgvCombustibles_502ag.Location = new System.Drawing.Point(12, 39);
            this.dgvCombustibles_502ag.MultiSelect = false;
            this.dgvCombustibles_502ag.Name = "dgvCombustibles_502ag";
            this.dgvCombustibles_502ag.ReadOnly = true;
            this.dgvCombustibles_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCombustibles_502ag.Size = new System.Drawing.Size(368, 123);
            this.dgvCombustibles_502ag.TabIndex = 37;
            // 
            // ColumnaCodigo
            // 
            this.ColumnaCodigo.HeaderText = "Codigo";
            this.ColumnaCodigo.Name = "ColumnaCodigo";
            this.ColumnaCodigo.ReadOnly = true;
            // 
            // ColumnaNombreCombustible
            // 
            this.ColumnaNombreCombustible.HeaderText = "Nombre";
            this.ColumnaNombreCombustible.Name = "ColumnaNombreCombustible";
            this.ColumnaNombreCombustible.ReadOnly = true;
            // 
            // ColumnaCantidad
            // 
            this.ColumnaCantidad.HeaderText = "Cantidad";
            this.ColumnaCantidad.Name = "ColumnaCantidad";
            this.ColumnaCantidad.ReadOnly = true;
            // 
            // ColumnaPrecio
            // 
            this.ColumnaPrecio.HeaderText = "Precio";
            this.ColumnaPrecio.Name = "ColumnaPrecio";
            this.ColumnaPrecio.ReadOnly = true;
            // 
            // buttonSeleccionarCombustible_502ag
            // 
            this.buttonSeleccionarCombustible_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSeleccionarCombustible_502ag.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionarCombustible_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionarCombustible_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSeleccionarCombustible_502ag.Location = new System.Drawing.Point(12, 168);
            this.buttonSeleccionarCombustible_502ag.Name = "buttonSeleccionarCombustible_502ag";
            this.buttonSeleccionarCombustible_502ag.Size = new System.Drawing.Size(177, 40);
            this.buttonSeleccionarCombustible_502ag.TabIndex = 38;
            this.buttonSeleccionarCombustible_502ag.Text = "Seleccionar Combustible";
            this.buttonSeleccionarCombustible_502ag.UseVisualStyleBackColor = false;
            this.buttonSeleccionarCombustible_502ag.Click += new System.EventHandler(this.buttonSeleccionarCombustible_502ag_Click);
            // 
            // labelCodigo_502ag
            // 
            this.labelCodigo_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCodigo_502ag.AutoSize = true;
            this.labelCodigo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCodigo_502ag.Location = new System.Drawing.Point(12, 343);
            this.labelCodigo_502ag.Name = "labelCodigo_502ag";
            this.labelCodigo_502ag.Size = new System.Drawing.Size(52, 17);
            this.labelCodigo_502ag.TabIndex = 53;
            this.labelCodigo_502ag.Text = "Código";
            // 
            // tBCodigo_502ag
            // 
            this.tBCodigo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBCodigo_502ag.Location = new System.Drawing.Point(83, 340);
            this.tBCodigo_502ag.Name = "tBCodigo_502ag";
            this.tBCodigo_502ag.Size = new System.Drawing.Size(78, 23);
            this.tBCodigo_502ag.TabIndex = 52;
            // 
            // labelCantidad_502ag
            // 
            this.labelCantidad_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCantidad_502ag.AutoSize = true;
            this.labelCantidad_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCantidad_502ag.Location = new System.Drawing.Point(12, 376);
            this.labelCantidad_502ag.Name = "labelCantidad_502ag";
            this.labelCantidad_502ag.Size = new System.Drawing.Size(64, 17);
            this.labelCantidad_502ag.TabIndex = 55;
            this.labelCantidad_502ag.Text = "Cantidad";
            // 
            // tBCantidad_502ag
            // 
            this.tBCantidad_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBCantidad_502ag.Location = new System.Drawing.Point(83, 373);
            this.tBCantidad_502ag.Name = "tBCantidad_502ag";
            this.tBCantidad_502ag.Size = new System.Drawing.Size(78, 23);
            this.tBCantidad_502ag.TabIndex = 54;
            // 
            // buttonComenzarCarga_502ag
            // 
            this.buttonComenzarCarga_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonComenzarCarga_502ag.FlatAppearance.BorderSize = 0;
            this.buttonComenzarCarga_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComenzarCarga_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonComenzarCarga_502ag.Location = new System.Drawing.Point(15, 402);
            this.buttonComenzarCarga_502ag.Name = "buttonComenzarCarga_502ag";
            this.buttonComenzarCarga_502ag.Size = new System.Drawing.Size(146, 36);
            this.buttonComenzarCarga_502ag.TabIndex = 58;
            this.buttonComenzarCarga_502ag.Text = "Comenzar Carga";
            this.buttonComenzarCarga_502ag.UseVisualStyleBackColor = false;
            this.buttonComenzarCarga_502ag.Click += new System.EventHandler(this.buttonComenzarCarga_502ag_Click);
            // 
            // rBCantidad_502ag
            // 
            this.rBCantidad_502ag.AutoSize = true;
            this.rBCantidad_502ag.Checked = true;
            this.rBCantidad_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBCantidad_502ag.Location = new System.Drawing.Point(17, 283);
            this.rBCantidad_502ag.Name = "rBCantidad_502ag";
            this.rBCantidad_502ag.Size = new System.Drawing.Size(108, 21);
            this.rBCantidad_502ag.TabIndex = 56;
            this.rBCantidad_502ag.TabStop = true;
            this.rBCantidad_502ag.Text = "Por Cantidad";
            this.rBCantidad_502ag.UseVisualStyleBackColor = true;
            // 
            // rBMonto_502ag
            // 
            this.rBMonto_502ag.AutoSize = true;
            this.rBMonto_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBMonto_502ag.Location = new System.Drawing.Point(17, 310);
            this.rBMonto_502ag.Name = "rBMonto_502ag";
            this.rBMonto_502ag.Size = new System.Drawing.Size(91, 21);
            this.rBMonto_502ag.TabIndex = 57;
            this.rBMonto_502ag.Text = "Por Monto";
            this.rBMonto_502ag.UseVisualStyleBackColor = true;
            // 
            // rTBDetallesCarga_502ag
            // 
            this.rTBDetallesCarga_502ag.Location = new System.Drawing.Point(179, 267);
            this.rTBDetallesCarga_502ag.Name = "rTBDetallesCarga_502ag";
            this.rTBDetallesCarga_502ag.Size = new System.Drawing.Size(201, 85);
            this.rTBDetallesCarga_502ag.TabIndex = 59;
            this.rTBDetallesCarga_502ag.Text = "";
            // 
            // buttonDetenerCarga_502ag
            // 
            this.buttonDetenerCarga_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDetenerCarga_502ag.FlatAppearance.BorderSize = 0;
            this.buttonDetenerCarga_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetenerCarga_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDetenerCarga_502ag.Location = new System.Drawing.Point(179, 358);
            this.buttonDetenerCarga_502ag.Name = "buttonDetenerCarga_502ag";
            this.buttonDetenerCarga_502ag.Size = new System.Drawing.Size(90, 35);
            this.buttonDetenerCarga_502ag.TabIndex = 60;
            this.buttonDetenerCarga_502ag.Text = "Detener";
            this.buttonDetenerCarga_502ag.UseVisualStyleBackColor = false;
            this.buttonDetenerCarga_502ag.Click += new System.EventHandler(this.buttonDetenerCarga_502ag_Click);
            // 
            // buttonReanudarCarga_502ag
            // 
            this.buttonReanudarCarga_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonReanudarCarga_502ag.FlatAppearance.BorderSize = 0;
            this.buttonReanudarCarga_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReanudarCarga_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonReanudarCarga_502ag.Location = new System.Drawing.Point(290, 358);
            this.buttonReanudarCarga_502ag.Name = "buttonReanudarCarga_502ag";
            this.buttonReanudarCarga_502ag.Size = new System.Drawing.Size(90, 35);
            this.buttonReanudarCarga_502ag.TabIndex = 61;
            this.buttonReanudarCarga_502ag.Text = "Reanudar";
            this.buttonReanudarCarga_502ag.UseVisualStyleBackColor = false;
            this.buttonReanudarCarga_502ag.Click += new System.EventHandler(this.buttonReanudarCarga_502ag_Click);
            // 
            // buttonFinalizarCarga_502ag
            // 
            this.buttonFinalizarCarga_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonFinalizarCarga_502ag.FlatAppearance.BorderSize = 0;
            this.buttonFinalizarCarga_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinalizarCarga_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonFinalizarCarga_502ag.Location = new System.Drawing.Point(179, 402);
            this.buttonFinalizarCarga_502ag.Name = "buttonFinalizarCarga_502ag";
            this.buttonFinalizarCarga_502ag.Size = new System.Drawing.Size(201, 36);
            this.buttonFinalizarCarga_502ag.TabIndex = 62;
            this.buttonFinalizarCarga_502ag.Text = "Finalizar";
            this.buttonFinalizarCarga_502ag.UseVisualStyleBackColor = false;
            this.buttonFinalizarCarga_502ag.Click += new System.EventHandler(this.buttonFinalizarCarga_502ag_Click);
            // 
            // tBDNI_502ag
            // 
            this.tBDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBDNI_502ag.Location = new System.Drawing.Point(466, 39);
            this.tBDNI_502ag.Name = "tBDNI_502ag";
            this.tBDNI_502ag.Size = new System.Drawing.Size(174, 23);
            this.tBDNI_502ag.TabIndex = 63;
            // 
            // labelDNI_502ag
            // 
            this.labelDNI_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDNI_502ag.AutoSize = true;
            this.labelDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI_502ag.Location = new System.Drawing.Point(428, 45);
            this.labelDNI_502ag.Name = "labelDNI_502ag";
            this.labelDNI_502ag.Size = new System.Drawing.Size(31, 17);
            this.labelDNI_502ag.TabIndex = 64;
            this.labelDNI_502ag.Text = "DNI";
            // 
            // buttonIdentificarCliente_502ag
            // 
            this.buttonIdentificarCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonIdentificarCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonIdentificarCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIdentificarCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonIdentificarCliente_502ag.Location = new System.Drawing.Point(431, 68);
            this.buttonIdentificarCliente_502ag.Name = "buttonIdentificarCliente_502ag";
            this.buttonIdentificarCliente_502ag.Size = new System.Drawing.Size(96, 38);
            this.buttonIdentificarCliente_502ag.TabIndex = 65;
            this.buttonIdentificarCliente_502ag.Text = "Identificar";
            this.buttonIdentificarCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonIdentificarCliente_502ag.Click += new System.EventHandler(this.buttonIdentificarCliente_502ag_Click);
            // 
            // buttonRegistrarCliente_502ag
            // 
            this.buttonRegistrarCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRegistrarCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonRegistrarCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistrarCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonRegistrarCliente_502ag.Location = new System.Drawing.Point(544, 68);
            this.buttonRegistrarCliente_502ag.Name = "buttonRegistrarCliente_502ag";
            this.buttonRegistrarCliente_502ag.Size = new System.Drawing.Size(96, 38);
            this.buttonRegistrarCliente_502ag.TabIndex = 66;
            this.buttonRegistrarCliente_502ag.Text = "Registrar";
            this.buttonRegistrarCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonRegistrarCliente_502ag.Click += new System.EventHandler(this.buttonRegistrarCliente_502ag_Click);
            // 
            // labelSeleccionarCombustible_502ag
            // 
            this.labelSeleccionarCombustible_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSeleccionarCombustible_502ag.AutoSize = true;
            this.labelSeleccionarCombustible_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSeleccionarCombustible_502ag.Location = new System.Drawing.Point(12, 13);
            this.labelSeleccionarCombustible_502ag.Name = "labelSeleccionarCombustible_502ag";
            this.labelSeleccionarCombustible_502ag.Size = new System.Drawing.Size(163, 17);
            this.labelSeleccionarCombustible_502ag.TabIndex = 67;
            this.labelSeleccionarCombustible_502ag.Text = "Seleccionar Combustible";
            // 
            // labelCargarCombustible_502ag
            // 
            this.labelCargarCombustible_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCargarCombustible_502ag.AutoSize = true;
            this.labelCargarCombustible_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCargarCombustible_502ag.Location = new System.Drawing.Point(14, 245);
            this.labelCargarCombustible_502ag.Name = "labelCargarCombustible_502ag";
            this.labelCargarCombustible_502ag.Size = new System.Drawing.Size(132, 17);
            this.labelCargarCombustible_502ag.TabIndex = 68;
            this.labelCargarCombustible_502ag.Text = "Cargar Combustible";
            // 
            // labelIdentificarCliente_502ag
            // 
            this.labelIdentificarCliente_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIdentificarCliente_502ag.AutoSize = true;
            this.labelIdentificarCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelIdentificarCliente_502ag.Location = new System.Drawing.Point(428, 19);
            this.labelIdentificarCliente_502ag.Name = "labelIdentificarCliente_502ag";
            this.labelIdentificarCliente_502ag.Size = new System.Drawing.Size(116, 17);
            this.labelIdentificarCliente_502ag.TabIndex = 69;
            this.labelIdentificarCliente_502ag.Text = "Identificar Cliente";
            // 
            // tBNombre_502ag
            // 
            this.tBNombre_502ag.Enabled = false;
            this.tBNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre_502ag.Location = new System.Drawing.Point(514, 112);
            this.tBNombre_502ag.Name = "tBNombre_502ag";
            this.tBNombre_502ag.Size = new System.Drawing.Size(126, 23);
            this.tBNombre_502ag.TabIndex = 70;
            // 
            // tBApellido_502ag
            // 
            this.tBApellido_502ag.Enabled = false;
            this.tBApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBApellido_502ag.Location = new System.Drawing.Point(514, 141);
            this.tBApellido_502ag.Name = "tBApellido_502ag";
            this.tBApellido_502ag.Size = new System.Drawing.Size(126, 23);
            this.tBApellido_502ag.TabIndex = 71;
            // 
            // labelNombre_502ag
            // 
            this.labelNombre_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre_502ag.AutoSize = true;
            this.labelNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre_502ag.Location = new System.Drawing.Point(428, 115);
            this.labelNombre_502ag.Name = "labelNombre_502ag";
            this.labelNombre_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelNombre_502ag.TabIndex = 72;
            this.labelNombre_502ag.Text = "Nombre";
            // 
            // labelApellido_502ag
            // 
            this.labelApellido_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelApellido_502ag.AutoSize = true;
            this.labelApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido_502ag.Location = new System.Drawing.Point(429, 144);
            this.labelApellido_502ag.Name = "labelApellido_502ag";
            this.labelApellido_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelApellido_502ag.TabIndex = 73;
            this.labelApellido_502ag.Text = "Apellido";
            // 
            // buttonCobrarCliente_502ag
            // 
            this.buttonCobrarCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCobrarCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonCobrarCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCobrarCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCobrarCliente_502ag.Location = new System.Drawing.Point(431, 170);
            this.buttonCobrarCliente_502ag.Name = "buttonCobrarCliente_502ag";
            this.buttonCobrarCliente_502ag.Size = new System.Drawing.Size(209, 40);
            this.buttonCobrarCliente_502ag.TabIndex = 74;
            this.buttonCobrarCliente_502ag.Text = "Cobrar Cliente";
            this.buttonCobrarCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonCobrarCliente_502ag.Click += new System.EventHandler(this.buttonCobrarCliente_502ag_Click);
            // 
            // dgvFacturas_502ag
            // 
            this.dgvFacturas_502ag.AllowUserToAddRows = false;
            this.dgvFacturas_502ag.AllowUserToDeleteRows = false;
            this.dgvFacturas_502ag.AllowUserToResizeColumns = false;
            this.dgvFacturas_502ag.AllowUserToResizeRows = false;
            this.dgvFacturas_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaCodigoFactura,
            this.ColumnaCombustible,
            this.ColumnaEstado});
            this.dgvFacturas_502ag.Location = new System.Drawing.Point(431, 267);
            this.dgvFacturas_502ag.MultiSelect = false;
            this.dgvFacturas_502ag.Name = "dgvFacturas_502ag";
            this.dgvFacturas_502ag.ReadOnly = true;
            this.dgvFacturas_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas_502ag.Size = new System.Drawing.Size(341, 129);
            this.dgvFacturas_502ag.TabIndex = 75;
            // 
            // ColumnaCodigoFactura
            // 
            this.ColumnaCodigoFactura.FillWeight = 50F;
            this.ColumnaCodigoFactura.HeaderText = "Codigo";
            this.ColumnaCodigoFactura.Name = "ColumnaCodigoFactura";
            this.ColumnaCodigoFactura.ReadOnly = true;
            // 
            // ColumnaCombustible
            // 
            this.ColumnaCombustible.HeaderText = "Combustible";
            this.ColumnaCombustible.Name = "ColumnaCombustible";
            this.ColumnaCombustible.ReadOnly = true;
            // 
            // ColumnaEstado
            // 
            this.ColumnaEstado.HeaderText = "Estado";
            this.ColumnaEstado.Name = "ColumnaEstado";
            this.ColumnaEstado.ReadOnly = true;
            // 
            // buttonSeleccionarFactura_502ag
            // 
            this.buttonSeleccionarFactura_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSeleccionarFactura_502ag.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionarFactura_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionarFactura_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSeleccionarFactura_502ag.Location = new System.Drawing.Point(432, 402);
            this.buttonSeleccionarFactura_502ag.Name = "buttonSeleccionarFactura_502ag";
            this.buttonSeleccionarFactura_502ag.Size = new System.Drawing.Size(168, 36);
            this.buttonSeleccionarFactura_502ag.TabIndex = 76;
            this.buttonSeleccionarFactura_502ag.Text = "Seleccionar Factura";
            this.buttonSeleccionarFactura_502ag.UseVisualStyleBackColor = false;
            this.buttonSeleccionarFactura_502ag.Click += new System.EventHandler(this.buttonSeleccionarFactura_502ag_Click);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(604, 402);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(168, 36);
            this.buttonVolverAlMenu_502ag.TabIndex = 77;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // labelFacturaIncompleta_502ag
            // 
            this.labelFacturaIncompleta_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFacturaIncompleta_502ag.AutoSize = true;
            this.labelFacturaIncompleta_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelFacturaIncompleta_502ag.Location = new System.Drawing.Point(428, 245);
            this.labelFacturaIncompleta_502ag.Name = "labelFacturaIncompleta_502ag";
            this.labelFacturaIncompleta_502ag.Size = new System.Drawing.Size(206, 17);
            this.labelFacturaIncompleta_502ag.TabIndex = 78;
            this.labelFacturaIncompleta_502ag.Text = "Seleccionar Factura Incompleta";
            // 
            // buttonAyuda2_502ag
            // 
            this.buttonAyuda2_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAyuda2_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAyuda2_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAyuda2_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAyuda2_502ag.Image = ((System.Drawing.Image)(resources.GetObject("buttonAyuda2_502ag.Image")));
            this.buttonAyuda2_502ag.Location = new System.Drawing.Point(727, 12);
            this.buttonAyuda2_502ag.Name = "buttonAyuda2_502ag";
            this.buttonAyuda2_502ag.Size = new System.Drawing.Size(45, 45);
            this.buttonAyuda2_502ag.TabIndex = 79;
            this.buttonAyuda2_502ag.UseVisualStyleBackColor = false;
            this.buttonAyuda2_502ag.Click += new System.EventHandler(this.buttonAyuda2_502ag_Click);
            // 
            // FormCargarCombustible_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 446);
            this.Controls.Add(this.buttonAyuda2_502ag);
            this.Controls.Add(this.labelFacturaIncompleta_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.buttonSeleccionarFactura_502ag);
            this.Controls.Add(this.dgvFacturas_502ag);
            this.Controls.Add(this.buttonCobrarCliente_502ag);
            this.Controls.Add(this.labelApellido_502ag);
            this.Controls.Add(this.labelNombre_502ag);
            this.Controls.Add(this.tBApellido_502ag);
            this.Controls.Add(this.tBNombre_502ag);
            this.Controls.Add(this.labelIdentificarCliente_502ag);
            this.Controls.Add(this.labelCargarCombustible_502ag);
            this.Controls.Add(this.labelSeleccionarCombustible_502ag);
            this.Controls.Add(this.buttonRegistrarCliente_502ag);
            this.Controls.Add(this.buttonIdentificarCliente_502ag);
            this.Controls.Add(this.labelDNI_502ag);
            this.Controls.Add(this.tBDNI_502ag);
            this.Controls.Add(this.buttonFinalizarCarga_502ag);
            this.Controls.Add(this.buttonReanudarCarga_502ag);
            this.Controls.Add(this.buttonDetenerCarga_502ag);
            this.Controls.Add(this.rTBDetallesCarga_502ag);
            this.Controls.Add(this.buttonComenzarCarga_502ag);
            this.Controls.Add(this.rBMonto_502ag);
            this.Controls.Add(this.rBCantidad_502ag);
            this.Controls.Add(this.labelCantidad_502ag);
            this.Controls.Add(this.tBCantidad_502ag);
            this.Controls.Add(this.labelCodigo_502ag);
            this.Controls.Add(this.tBCodigo_502ag);
            this.Controls.Add(this.buttonSeleccionarCombustible_502ag);
            this.Controls.Add(this.dgvCombustibles_502ag);
            this.Name = "FormCargarCombustible_502ag";
            this.Text = "FormCargarCombustible_502ag";
            this.Activated += new System.EventHandler(this.FormCargarCombustible_502ag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCargarCombustible_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombustibles_502ag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCombustibles_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaPrecio;
        private System.Windows.Forms.Button buttonSeleccionarCombustible_502ag;
        private System.Windows.Forms.Label labelCodigo_502ag;
        private System.Windows.Forms.TextBox tBCodigo_502ag;
        private System.Windows.Forms.Label labelCantidad_502ag;
        private System.Windows.Forms.TextBox tBCantidad_502ag;
        private System.Windows.Forms.Button buttonComenzarCarga_502ag;
        private System.Windows.Forms.RadioButton rBCantidad_502ag;
        private System.Windows.Forms.RadioButton rBMonto_502ag;
        private System.Windows.Forms.RichTextBox rTBDetallesCarga_502ag;
        private System.Windows.Forms.Button buttonDetenerCarga_502ag;
        private System.Windows.Forms.Button buttonReanudarCarga_502ag;
        private System.Windows.Forms.Button buttonFinalizarCarga_502ag;
        private System.Windows.Forms.TextBox tBDNI_502ag;
        private System.Windows.Forms.Label labelDNI_502ag;
        private System.Windows.Forms.Button buttonIdentificarCliente_502ag;
        private System.Windows.Forms.Button buttonRegistrarCliente_502ag;
        private System.Windows.Forms.Label labelSeleccionarCombustible_502ag;
        private System.Windows.Forms.Label labelCargarCombustible_502ag;
        private System.Windows.Forms.Label labelIdentificarCliente_502ag;
        private System.Windows.Forms.TextBox tBNombre_502ag;
        private System.Windows.Forms.TextBox tBApellido_502ag;
        private System.Windows.Forms.Label labelNombre_502ag;
        private System.Windows.Forms.Label labelApellido_502ag;
        private System.Windows.Forms.Button buttonCobrarCliente_502ag;
        private System.Windows.Forms.DataGridView dgvFacturas_502ag;
        private System.Windows.Forms.Button buttonSeleccionarFactura_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Label labelFacturaIncompleta_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEstado;
        private System.Windows.Forms.Button buttonAyuda2_502ag;
    }
}