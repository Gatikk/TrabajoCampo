namespace GUI
{
    partial class FormABMUsuario_502ag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABMUsuario_502ag));
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.dgvUsuarios_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaBloqueado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonAltaUsuario_502ag = new System.Windows.Forms.Button();
            this.buttonModificarUsuario_502ag = new System.Windows.Forms.Button();
            this.tBNombre_502ag = new System.Windows.Forms.TextBox();
            this.tBApellido_502ag = new System.Windows.Forms.TextBox();
            this.tBDNI_502ag = new System.Windows.Forms.TextBox();
            this.tBEmail_502ag = new System.Windows.Forms.TextBox();
            this.labelRol_502ag = new System.Windows.Forms.Label();
            this.labelNombre_502ag = new System.Windows.Forms.Label();
            this.labelApellido_502ag = new System.Windows.Forms.Label();
            this.labelDNI_502ag = new System.Windows.Forms.Label();
            this.labelEmail_502ag = new System.Windows.Forms.Label();
            this.buttonDesbloquearUsuario_502ag = new System.Windows.Forms.Button();
            this.cBRol_502ag = new System.Windows.Forms.ComboBox();
            this.buttonAplicar_502ag = new System.Windows.Forms.Button();
            this.buttonCancelar_502ag = new System.Windows.Forms.Button();
            this.buttonActivarDesactivar_502ag = new System.Windows.Forms.Button();
            this.rBActivos_502ag = new System.Windows.Forms.RadioButton();
            this.rBTodos_502ag = new System.Windows.Forms.RadioButton();
            this.tBModoActual_502ag = new System.Windows.Forms.TextBox();
            this.buttonAyuda2_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_502ag)).BeginInit();
            this.SuspendLayout();
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
            this.buttonVolverAlMenu_502ag.TabIndex = 2;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_Click);
            // 
            // dgvUsuarios_502ag
            // 
            this.dgvUsuarios_502ag.AllowUserToAddRows = false;
            this.dgvUsuarios_502ag.AllowUserToDeleteRows = false;
            this.dgvUsuarios_502ag.AllowUserToResizeColumns = false;
            this.dgvUsuarios_502ag.AllowUserToResizeRows = false;
            this.dgvUsuarios_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaUsuario,
            this.ColumnaRol,
            this.ColumnaNombre,
            this.ColumnaApellido,
            this.ColumnaDNI,
            this.ColumnaEmail,
            this.ColumnaBloqueado,
            this.ColumnaActivo});
            this.dgvUsuarios_502ag.Location = new System.Drawing.Point(12, 53);
            this.dgvUsuarios_502ag.MultiSelect = false;
            this.dgvUsuarios_502ag.Name = "dgvUsuarios_502ag";
            this.dgvUsuarios_502ag.ReadOnly = true;
            this.dgvUsuarios_502ag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsuarios_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios_502ag.Size = new System.Drawing.Size(760, 210);
            this.dgvUsuarios_502ag.TabIndex = 3;
            this.dgvUsuarios_502ag.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // ColumnaUsuario
            // 
            this.ColumnaUsuario.HeaderText = "Usuario";
            this.ColumnaUsuario.Name = "ColumnaUsuario";
            this.ColumnaUsuario.ReadOnly = true;
            // 
            // ColumnaRol
            // 
            this.ColumnaRol.HeaderText = "Rol";
            this.ColumnaRol.Name = "ColumnaRol";
            this.ColumnaRol.ReadOnly = true;
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
            // ColumnaDNI
            // 
            this.ColumnaDNI.HeaderText = "DNI";
            this.ColumnaDNI.Name = "ColumnaDNI";
            this.ColumnaDNI.ReadOnly = true;
            // 
            // ColumnaEmail
            // 
            this.ColumnaEmail.HeaderText = "Email";
            this.ColumnaEmail.Name = "ColumnaEmail";
            this.ColumnaEmail.ReadOnly = true;
            this.ColumnaEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnaBloqueado
            // 
            this.ColumnaBloqueado.HeaderText = "isBloqueado";
            this.ColumnaBloqueado.Name = "ColumnaBloqueado";
            this.ColumnaBloqueado.ReadOnly = true;
            this.ColumnaBloqueado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaBloqueado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnaActivo
            // 
            this.ColumnaActivo.HeaderText = "isActivo";
            this.ColumnaActivo.Name = "ColumnaActivo";
            this.ColumnaActivo.ReadOnly = true;
            this.ColumnaActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonAltaUsuario_502ag
            // 
            this.buttonAltaUsuario_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAltaUsuario_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAltaUsuario_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAltaUsuario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAltaUsuario_502ag.Location = new System.Drawing.Point(12, 282);
            this.buttonAltaUsuario_502ag.Name = "buttonAltaUsuario_502ag";
            this.buttonAltaUsuario_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonAltaUsuario_502ag.TabIndex = 4;
            this.buttonAltaUsuario_502ag.Text = "Alta Usuario";
            this.buttonAltaUsuario_502ag.UseVisualStyleBackColor = false;
            this.buttonAltaUsuario_502ag.Click += new System.EventHandler(this.buttonAltaUsuario_502ag_Click);
            // 
            // buttonModificarUsuario_502ag
            // 
            this.buttonModificarUsuario_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonModificarUsuario_502ag.FlatAppearance.BorderSize = 0;
            this.buttonModificarUsuario_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificarUsuario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonModificarUsuario_502ag.Location = new System.Drawing.Point(161, 282);
            this.buttonModificarUsuario_502ag.Name = "buttonModificarUsuario_502ag";
            this.buttonModificarUsuario_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonModificarUsuario_502ag.TabIndex = 6;
            this.buttonModificarUsuario_502ag.Text = "Modificar Usuario";
            this.buttonModificarUsuario_502ag.UseVisualStyleBackColor = false;
            this.buttonModificarUsuario_502ag.Click += new System.EventHandler(this.buttonModificarUsuario_502ag_Click);
            // 
            // tBNombre_502ag
            // 
            this.tBNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre_502ag.Location = new System.Drawing.Point(444, 352);
            this.tBNombre_502ag.Name = "tBNombre_502ag";
            this.tBNombre_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBNombre_502ag.TabIndex = 3;
            // 
            // tBApellido_502ag
            // 
            this.tBApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBApellido_502ag.Location = new System.Drawing.Point(444, 381);
            this.tBApellido_502ag.Name = "tBApellido_502ag";
            this.tBApellido_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBApellido_502ag.TabIndex = 4;
            // 
            // tBDNI_502ag
            // 
            this.tBDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBDNI_502ag.Location = new System.Drawing.Point(444, 294);
            this.tBDNI_502ag.Name = "tBDNI_502ag";
            this.tBDNI_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBDNI_502ag.TabIndex = 1;
            // 
            // tBEmail_502ag
            // 
            this.tBEmail_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBEmail_502ag.Location = new System.Drawing.Point(444, 409);
            this.tBEmail_502ag.Name = "tBEmail_502ag";
            this.tBEmail_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBEmail_502ag.TabIndex = 5;
            // 
            // labelRol_502ag
            // 
            this.labelRol_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRol_502ag.AutoSize = true;
            this.labelRol_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRol_502ag.Location = new System.Drawing.Point(365, 326);
            this.labelRol_502ag.Name = "labelRol_502ag";
            this.labelRol_502ag.Size = new System.Drawing.Size(29, 17);
            this.labelRol_502ag.TabIndex = 17;
            this.labelRol_502ag.Text = "Rol";
            // 
            // labelNombre_502ag
            // 
            this.labelNombre_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre_502ag.AutoSize = true;
            this.labelNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre_502ag.Location = new System.Drawing.Point(365, 355);
            this.labelNombre_502ag.Name = "labelNombre_502ag";
            this.labelNombre_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelNombre_502ag.TabIndex = 18;
            this.labelNombre_502ag.Text = "Nombre";
            // 
            // labelApellido_502ag
            // 
            this.labelApellido_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelApellido_502ag.AutoSize = true;
            this.labelApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido_502ag.Location = new System.Drawing.Point(365, 384);
            this.labelApellido_502ag.Name = "labelApellido_502ag";
            this.labelApellido_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelApellido_502ag.TabIndex = 19;
            this.labelApellido_502ag.Text = "Apellido";
            // 
            // labelDNI_502ag
            // 
            this.labelDNI_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDNI_502ag.AutoSize = true;
            this.labelDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI_502ag.Location = new System.Drawing.Point(365, 297);
            this.labelDNI_502ag.Name = "labelDNI_502ag";
            this.labelDNI_502ag.Size = new System.Drawing.Size(31, 17);
            this.labelDNI_502ag.TabIndex = 20;
            this.labelDNI_502ag.Text = "DNI";
            // 
            // labelEmail_502ag
            // 
            this.labelEmail_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEmail_502ag.AutoSize = true;
            this.labelEmail_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEmail_502ag.Location = new System.Drawing.Point(365, 412);
            this.labelEmail_502ag.Name = "labelEmail_502ag";
            this.labelEmail_502ag.Size = new System.Drawing.Size(42, 17);
            this.labelEmail_502ag.TabIndex = 21;
            this.labelEmail_502ag.Text = "Email";
            // 
            // buttonDesbloquearUsuario_502ag
            // 
            this.buttonDesbloquearUsuario_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDesbloquearUsuario_502ag.FlatAppearance.BorderSize = 0;
            this.buttonDesbloquearUsuario_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesbloquearUsuario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDesbloquearUsuario_502ag.Location = new System.Drawing.Point(161, 343);
            this.buttonDesbloquearUsuario_502ag.Name = "buttonDesbloquearUsuario_502ag";
            this.buttonDesbloquearUsuario_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonDesbloquearUsuario_502ag.TabIndex = 24;
            this.buttonDesbloquearUsuario_502ag.Text = "Desbloquear Usuario";
            this.buttonDesbloquearUsuario_502ag.UseVisualStyleBackColor = false;
            this.buttonDesbloquearUsuario_502ag.Click += new System.EventHandler(this.buttonDesbloquear_502ag_Click);
            // 
            // cBRol_502ag
            // 
            this.cBRol_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBRol_502ag.FormattingEnabled = true;
            this.cBRol_502ag.Location = new System.Drawing.Point(444, 323);
            this.cBRol_502ag.Name = "cBRol_502ag";
            this.cBRol_502ag.Size = new System.Drawing.Size(175, 24);
            this.cBRol_502ag.TabIndex = 2;
            // 
            // buttonAplicar_502ag
            // 
            this.buttonAplicar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAplicar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAplicar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAplicar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAplicar_502ag.Location = new System.Drawing.Point(640, 282);
            this.buttonAplicar_502ag.Name = "buttonAplicar_502ag";
            this.buttonAplicar_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonAplicar_502ag.TabIndex = 26;
            this.buttonAplicar_502ag.Text = "Aplicar";
            this.buttonAplicar_502ag.UseVisualStyleBackColor = false;
            this.buttonAplicar_502ag.Click += new System.EventHandler(this.buttonAplicar_502ag_Click);
            // 
            // buttonCancelar_502ag
            // 
            this.buttonCancelar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCancelar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonCancelar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCancelar_502ag.Location = new System.Drawing.Point(640, 343);
            this.buttonCancelar_502ag.Name = "buttonCancelar_502ag";
            this.buttonCancelar_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonCancelar_502ag.TabIndex = 27;
            this.buttonCancelar_502ag.Text = "Cancelar";
            this.buttonCancelar_502ag.UseVisualStyleBackColor = false;
            this.buttonCancelar_502ag.Click += new System.EventHandler(this.buttonCancelar_502ag_Click);
            // 
            // buttonActivarDesactivar_502ag
            // 
            this.buttonActivarDesactivar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonActivarDesactivar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonActivarDesactivar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivarDesactivar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonActivarDesactivar_502ag.Location = new System.Drawing.Point(12, 343);
            this.buttonActivarDesactivar_502ag.Name = "buttonActivarDesactivar_502ag";
            this.buttonActivarDesactivar_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonActivarDesactivar_502ag.TabIndex = 28;
            this.buttonActivarDesactivar_502ag.Text = "Activar / Desactivar";
            this.buttonActivarDesactivar_502ag.UseVisualStyleBackColor = false;
            this.buttonActivarDesactivar_502ag.Click += new System.EventHandler(this.buttonActivarDesactivar_502ag_Click);
            // 
            // rBActivos_502ag
            // 
            this.rBActivos_502ag.AutoSize = true;
            this.rBActivos_502ag.Checked = true;
            this.rBActivos_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBActivos_502ag.Location = new System.Drawing.Point(492, 3);
            this.rBActivos_502ag.Name = "rBActivos_502ag";
            this.rBActivos_502ag.Size = new System.Drawing.Size(71, 21);
            this.rBActivos_502ag.TabIndex = 29;
            this.rBActivos_502ag.TabStop = true;
            this.rBActivos_502ag.Text = "Activos";
            this.rBActivos_502ag.UseVisualStyleBackColor = true;
            // 
            // rBTodos_502ag
            // 
            this.rBTodos_502ag.AutoSize = true;
            this.rBTodos_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBTodos_502ag.Location = new System.Drawing.Point(492, 26);
            this.rBTodos_502ag.Name = "rBTodos_502ag";
            this.rBTodos_502ag.Size = new System.Drawing.Size(66, 21);
            this.rBTodos_502ag.TabIndex = 30;
            this.rBTodos_502ag.Text = "Todos";
            this.rBTodos_502ag.UseVisualStyleBackColor = true;
            this.rBTodos_502ag.CheckedChanged += new System.EventHandler(this.rBTodos_502ag_CheckedChanged);
            // 
            // tBModoActual_502ag
            // 
            this.tBModoActual_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tBModoActual_502ag.Enabled = false;
            this.tBModoActual_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tBModoActual_502ag.Location = new System.Drawing.Point(12, 12);
            this.tBModoActual_502ag.Name = "tBModoActual_502ag";
            this.tBModoActual_502ag.Size = new System.Drawing.Size(159, 26);
            this.tBModoActual_502ag.TabIndex = 31;
            this.tBModoActual_502ag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAyuda2_502ag
            // 
            this.buttonAyuda2_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAyuda2_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAyuda2_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAyuda2_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAyuda2_502ag.Image = ((System.Drawing.Image)(resources.GetObject("buttonAyuda2_502ag.Image")));
            this.buttonAyuda2_502ag.Location = new System.Drawing.Point(727, 3);
            this.buttonAyuda2_502ag.Name = "buttonAyuda2_502ag";
            this.buttonAyuda2_502ag.Size = new System.Drawing.Size(45, 45);
            this.buttonAyuda2_502ag.TabIndex = 32;
            this.buttonAyuda2_502ag.UseVisualStyleBackColor = false;
            this.buttonAyuda2_502ag.Click += new System.EventHandler(this.buttonAyuda2_502ag_Click);
            // 
            // FormABMUsuario_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonAyuda2_502ag);
            this.Controls.Add(this.tBModoActual_502ag);
            this.Controls.Add(this.rBTodos_502ag);
            this.Controls.Add(this.rBActivos_502ag);
            this.Controls.Add(this.buttonActivarDesactivar_502ag);
            this.Controls.Add(this.buttonCancelar_502ag);
            this.Controls.Add(this.buttonAplicar_502ag);
            this.Controls.Add(this.cBRol_502ag);
            this.Controls.Add(this.buttonDesbloquearUsuario_502ag);
            this.Controls.Add(this.labelEmail_502ag);
            this.Controls.Add(this.labelDNI_502ag);
            this.Controls.Add(this.labelApellido_502ag);
            this.Controls.Add(this.labelNombre_502ag);
            this.Controls.Add(this.labelRol_502ag);
            this.Controls.Add(this.tBEmail_502ag);
            this.Controls.Add(this.tBDNI_502ag);
            this.Controls.Add(this.tBApellido_502ag);
            this.Controls.Add(this.tBNombre_502ag);
            this.Controls.Add(this.buttonModificarUsuario_502ag);
            this.Controls.Add(this.buttonAltaUsuario_502ag);
            this.Controls.Add(this.dgvUsuarios_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Name = "FormABMUsuario_502ag";
            this.Text = "FormABM";
            this.Activated += new System.EventHandler(this.FormABMUsuario_502ag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormABM_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.DataGridView dgvUsuarios_502ag;
        private System.Windows.Forms.Button buttonAltaUsuario_502ag;
        private System.Windows.Forms.Button buttonModificarUsuario_502ag;
        private System.Windows.Forms.TextBox tBNombre_502ag;
        private System.Windows.Forms.TextBox tBApellido_502ag;
        private System.Windows.Forms.TextBox tBDNI_502ag;
        private System.Windows.Forms.TextBox tBEmail_502ag;
        private System.Windows.Forms.Label labelRol_502ag;
        private System.Windows.Forms.Label labelNombre_502ag;
        private System.Windows.Forms.Label labelApellido_502ag;
        private System.Windows.Forms.Label labelDNI_502ag;
        private System.Windows.Forms.Label labelEmail_502ag;
        private System.Windows.Forms.Button buttonDesbloquearUsuario_502ag;
        private System.Windows.Forms.ComboBox cBRol_502ag;
        private System.Windows.Forms.Button buttonAplicar_502ag;
        private System.Windows.Forms.Button buttonCancelar_502ag;
        private System.Windows.Forms.Button buttonActivarDesactivar_502ag;
        private System.Windows.Forms.RadioButton rBActivos_502ag;
        private System.Windows.Forms.RadioButton rBTodos_502ag;
        private System.Windows.Forms.TextBox tBModoActual_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaBloqueado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaActivo;
        private System.Windows.Forms.Button buttonAyuda2_502ag;
    }
}