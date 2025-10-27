namespace GUI
{
    partial class FormBitacoraCambios_502ag
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
            this.dgvBitacoraClientes_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaClienteActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonVerInformacion_502ag = new System.Windows.Forms.Button();
            this.cBDNI_502ag = new System.Windows.Forms.ComboBox();
            this.labelHasta_502ag = new System.Windows.Forms.Label();
            this.labelDesde_502ag = new System.Windows.Forms.Label();
            this.dTPHasta_502ag = new System.Windows.Forms.DateTimePicker();
            this.dTPDesde_502ag = new System.Windows.Forms.DateTimePicker();
            this.buttonLimpiar_502ag = new System.Windows.Forms.Button();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.buttonActivar_502ag = new System.Windows.Forms.Button();
            this.buttonAplicar_502ag = new System.Windows.Forms.Button();
            this.labelDNI_502ag = new System.Windows.Forms.Label();
            this.cBNombre_502ag = new System.Windows.Forms.ComboBox();
            this.labelNombre_502ag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoraClientes_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacoraClientes_502ag
            // 
            this.dgvBitacoraClientes_502ag.AllowUserToAddRows = false;
            this.dgvBitacoraClientes_502ag.AllowUserToDeleteRows = false;
            this.dgvBitacoraClientes_502ag.AllowUserToResizeColumns = false;
            this.dgvBitacoraClientes_502ag.AllowUserToResizeRows = false;
            this.dgvBitacoraClientes_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacoraClientes_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacoraClientes_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaDNI,
            this.ColumnaFecha,
            this.ColumnaHora,
            this.ColumnaNombre,
            this.ColumnaApellido,
            this.ColumnaEmail,
            this.ColumnaDireccion,
            this.ColumnaTelefono,
            this.ColumnaClienteActivo,
            this.ColumnaActivo,
            this.ColumnaFechaHora});
            this.dgvBitacoraClientes_502ag.Location = new System.Drawing.Point(12, 61);
            this.dgvBitacoraClientes_502ag.MultiSelect = false;
            this.dgvBitacoraClientes_502ag.Name = "dgvBitacoraClientes_502ag";
            this.dgvBitacoraClientes_502ag.ReadOnly = true;
            this.dgvBitacoraClientes_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacoraClientes_502ag.Size = new System.Drawing.Size(760, 210);
            this.dgvBitacoraClientes_502ag.TabIndex = 1;
            // 
            // ColumnaDNI
            // 
            this.ColumnaDNI.HeaderText = "DNI";
            this.ColumnaDNI.Name = "ColumnaDNI";
            this.ColumnaDNI.ReadOnly = true;
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
            // ColumnaNombre
            // 
            this.ColumnaNombre.HeaderText = "Nombre";
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // ColumnaApellido
            // 
            this.ColumnaApellido.HeaderText = "Apellido";
            this.ColumnaApellido.Name = "ColumnaApellido";
            this.ColumnaApellido.ReadOnly = true;
            // 
            // ColumnaEmail
            // 
            this.ColumnaEmail.HeaderText = "Email";
            this.ColumnaEmail.Name = "ColumnaEmail";
            this.ColumnaEmail.ReadOnly = true;
            // 
            // ColumnaDireccion
            // 
            this.ColumnaDireccion.HeaderText = "Dirección";
            this.ColumnaDireccion.Name = "ColumnaDireccion";
            this.ColumnaDireccion.ReadOnly = true;
            // 
            // ColumnaTelefono
            // 
            this.ColumnaTelefono.HeaderText = "Telefono";
            this.ColumnaTelefono.Name = "ColumnaTelefono";
            this.ColumnaTelefono.ReadOnly = true;
            this.ColumnaTelefono.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnaClienteActivo
            // 
            this.ColumnaClienteActivo.HeaderText = "Cliente Activo";
            this.ColumnaClienteActivo.Name = "ColumnaClienteActivo";
            this.ColumnaClienteActivo.ReadOnly = true;
            this.ColumnaClienteActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaClienteActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnaActivo
            // 
            this.ColumnaActivo.HeaderText = "Activo";
            this.ColumnaActivo.Name = "ColumnaActivo";
            this.ColumnaActivo.ReadOnly = true;
            this.ColumnaActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnaFechaHora
            // 
            this.ColumnaFechaHora.HeaderText = "FechaHora";
            this.ColumnaFechaHora.Name = "ColumnaFechaHora";
            this.ColumnaFechaHora.ReadOnly = true;
            this.ColumnaFechaHora.Visible = false;
            // 
            // buttonVerInformacion_502ag
            // 
            this.buttonVerInformacion_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVerInformacion_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVerInformacion_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerInformacion_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVerInformacion_502ag.Location = new System.Drawing.Point(640, 12);
            this.buttonVerInformacion_502ag.Name = "buttonVerInformacion_502ag";
            this.buttonVerInformacion_502ag.Size = new System.Drawing.Size(132, 39);
            this.buttonVerInformacion_502ag.TabIndex = 39;
            this.buttonVerInformacion_502ag.Text = "Ver Información";
            this.buttonVerInformacion_502ag.UseVisualStyleBackColor = false;
            this.buttonVerInformacion_502ag.Click += new System.EventHandler(this.buttonVerInformacion_502ag_Click);
            // 
            // cBDNI_502ag
            // 
            this.cBDNI_502ag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDNI_502ag.FormattingEnabled = true;
            this.cBDNI_502ag.Location = new System.Drawing.Point(61, 312);
            this.cBDNI_502ag.Name = "cBDNI_502ag";
            this.cBDNI_502ag.Size = new System.Drawing.Size(200, 21);
            this.cBDNI_502ag.TabIndex = 40;
            this.cBDNI_502ag.SelectedIndexChanged += new System.EventHandler(this.cBDNI_502ag_SelectedIndexChanged);
            // 
            // labelHasta_502ag
            // 
            this.labelHasta_502ag.AutoSize = true;
            this.labelHasta_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHasta_502ag.Location = new System.Drawing.Point(10, 405);
            this.labelHasta_502ag.Name = "labelHasta_502ag";
            this.labelHasta_502ag.Size = new System.Drawing.Size(45, 17);
            this.labelHasta_502ag.TabIndex = 45;
            this.labelHasta_502ag.Text = "Hasta";
            // 
            // labelDesde_502ag
            // 
            this.labelDesde_502ag.AutoSize = true;
            this.labelDesde_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDesde_502ag.Location = new System.Drawing.Point(10, 360);
            this.labelDesde_502ag.Name = "labelDesde_502ag";
            this.labelDesde_502ag.Size = new System.Drawing.Size(49, 17);
            this.labelDesde_502ag.TabIndex = 44;
            this.labelDesde_502ag.Text = "Desde";
            // 
            // dTPHasta_502ag
            // 
            this.dTPHasta_502ag.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dTPHasta_502ag.Location = new System.Drawing.Point(61, 405);
            this.dTPHasta_502ag.Name = "dTPHasta_502ag";
            this.dTPHasta_502ag.Size = new System.Drawing.Size(200, 20);
            this.dTPHasta_502ag.TabIndex = 43;
            this.dTPHasta_502ag.ValueChanged += new System.EventHandler(this.dTPHasta_502ag_ValueChanged);
            // 
            // dTPDesde_502ag
            // 
            this.dTPDesde_502ag.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dTPDesde_502ag.Location = new System.Drawing.Point(61, 360);
            this.dTPDesde_502ag.Name = "dTPDesde_502ag";
            this.dTPDesde_502ag.Size = new System.Drawing.Size(201, 20);
            this.dTPDesde_502ag.TabIndex = 42;
            this.dTPDesde_502ag.ValueChanged += new System.EventHandler(this.dTPDesde_502ag_ValueChanged);
            // 
            // buttonLimpiar_502ag
            // 
            this.buttonLimpiar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLimpiar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonLimpiar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpiar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLimpiar_502ag.Location = new System.Drawing.Point(382, 420);
            this.buttonLimpiar_502ag.Name = "buttonLimpiar_502ag";
            this.buttonLimpiar_502ag.Size = new System.Drawing.Size(200, 32);
            this.buttonLimpiar_502ag.TabIndex = 49;
            this.buttonLimpiar_502ag.Text = "Limpiar";
            this.buttonLimpiar_502ag.UseVisualStyleBackColor = false;
            this.buttonLimpiar_502ag.Click += new System.EventHandler(this.buttonLimpiar_502ag_Click);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(640, 405);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 48;
            this.buttonVolverAlMenu_502ag.Text = "Volver al menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // buttonActivar_502ag
            // 
            this.buttonActivar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonActivar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonActivar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonActivar_502ag.Location = new System.Drawing.Point(382, 344);
            this.buttonActivar_502ag.Name = "buttonActivar_502ag";
            this.buttonActivar_502ag.Size = new System.Drawing.Size(200, 32);
            this.buttonActivar_502ag.TabIndex = 47;
            this.buttonActivar_502ag.Text = "Activar";
            this.buttonActivar_502ag.UseVisualStyleBackColor = false;
            this.buttonActivar_502ag.Click += new System.EventHandler(this.buttonActivar_502ag_Click);
            // 
            // buttonAplicar_502ag
            // 
            this.buttonAplicar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAplicar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAplicar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAplicar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAplicar_502ag.Location = new System.Drawing.Point(382, 382);
            this.buttonAplicar_502ag.Name = "buttonAplicar_502ag";
            this.buttonAplicar_502ag.Size = new System.Drawing.Size(200, 32);
            this.buttonAplicar_502ag.TabIndex = 46;
            this.buttonAplicar_502ag.Text = "Aplicar";
            this.buttonAplicar_502ag.UseVisualStyleBackColor = false;
            this.buttonAplicar_502ag.Click += new System.EventHandler(this.buttonAplicar_502ag_Click);
            // 
            // labelDNI_502ag
            // 
            this.labelDNI_502ag.AutoSize = true;
            this.labelDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI_502ag.Location = new System.Drawing.Point(10, 312);
            this.labelDNI_502ag.Name = "labelDNI_502ag";
            this.labelDNI_502ag.Size = new System.Drawing.Size(31, 17);
            this.labelDNI_502ag.TabIndex = 50;
            this.labelDNI_502ag.Text = "DNI";
            // 
            // cBNombre_502ag
            // 
            this.cBNombre_502ag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBNombre_502ag.FormattingEnabled = true;
            this.cBNombre_502ag.Location = new System.Drawing.Point(382, 312);
            this.cBNombre_502ag.Name = "cBNombre_502ag";
            this.cBNombre_502ag.Size = new System.Drawing.Size(200, 21);
            this.cBNombre_502ag.TabIndex = 41;
            // 
            // labelNombre_502ag
            // 
            this.labelNombre_502ag.AutoSize = true;
            this.labelNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre_502ag.Location = new System.Drawing.Point(318, 312);
            this.labelNombre_502ag.Name = "labelNombre_502ag";
            this.labelNombre_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelNombre_502ag.TabIndex = 51;
            this.labelNombre_502ag.Text = "Nombre";
            // 
            // FormBitacoraCambios_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.labelNombre_502ag);
            this.Controls.Add(this.labelDNI_502ag);
            this.Controls.Add(this.buttonLimpiar_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.buttonActivar_502ag);
            this.Controls.Add(this.buttonAplicar_502ag);
            this.Controls.Add(this.labelHasta_502ag);
            this.Controls.Add(this.labelDesde_502ag);
            this.Controls.Add(this.dTPHasta_502ag);
            this.Controls.Add(this.dTPDesde_502ag);
            this.Controls.Add(this.cBNombre_502ag);
            this.Controls.Add(this.cBDNI_502ag);
            this.Controls.Add(this.buttonVerInformacion_502ag);
            this.Controls.Add(this.dgvBitacoraClientes_502ag);
            this.Name = "FormBitacoraCambios_502ag";
            this.Text = "FormBitacoraCambios_502ag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBitacoraCambios_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoraClientes_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacoraClientes_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTelefono;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaClienteActivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaActivo;
        private System.Windows.Forms.Button buttonVerInformacion_502ag;
        private System.Windows.Forms.ComboBox cBDNI_502ag;
        private System.Windows.Forms.Label labelHasta_502ag;
        private System.Windows.Forms.Label labelDesde_502ag;
        private System.Windows.Forms.DateTimePicker dTPHasta_502ag;
        private System.Windows.Forms.DateTimePicker dTPDesde_502ag;
        private System.Windows.Forms.Button buttonLimpiar_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Button buttonActivar_502ag;
        private System.Windows.Forms.Button buttonAplicar_502ag;
        private System.Windows.Forms.Label labelDNI_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaHora;
        private System.Windows.Forms.ComboBox cBNombre_502ag;
        private System.Windows.Forms.Label labelNombre_502ag;
    }
}