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
            this.labelRol = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonBloquear_502ag = new System.Windows.Forms.Button();
            this.buttonDesbloquear_502ag = new System.Windows.Forms.Button();
            this.cBRol_502ag = new System.Windows.Forms.ComboBox();
            this.buttonAplicar_502ag = new System.Windows.Forms.Button();
            this.buttonCancelar_502ag = new System.Windows.Forms.Button();
            this.buttonActivarDesactivar_502ag = new System.Windows.Forms.Button();
            this.rBActivos_502ag = new System.Windows.Forms.RadioButton();
            this.rBTodos_502ag = new System.Windows.Forms.RadioButton();
            this.tBModoActual_502ag = new System.Windows.Forms.TextBox();
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
            // labelRol
            // 
            this.labelRol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRol.Location = new System.Drawing.Point(365, 326);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(29, 17);
            this.labelRol.TabIndex = 17;
            this.labelRol.Text = "Rol";
            // 
            // labelNombre
            // 
            this.labelNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre.Location = new System.Drawing.Point(365, 355);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(58, 17);
            this.labelNombre.TabIndex = 18;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido.Location = new System.Drawing.Point(365, 384);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(58, 17);
            this.labelApellido.TabIndex = 19;
            this.labelApellido.Text = "Apellido";
            // 
            // labelDNI
            // 
            this.labelDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI.Location = new System.Drawing.Point(365, 297);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(31, 17);
            this.labelDNI.TabIndex = 20;
            this.labelDNI.Text = "DNI";
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEmail.Location = new System.Drawing.Point(365, 412);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(42, 17);
            this.labelEmail.TabIndex = 21;
            this.labelEmail.Text = "Email";
            // 
            // buttonBloquear_502ag
            // 
            this.buttonBloquear_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonBloquear_502ag.FlatAppearance.BorderSize = 0;
            this.buttonBloquear_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBloquear_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBloquear_502ag.Location = new System.Drawing.Point(12, 403);
            this.buttonBloquear_502ag.Name = "buttonBloquear_502ag";
            this.buttonBloquear_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonBloquear_502ag.TabIndex = 23;
            this.buttonBloquear_502ag.Text = "Bloquear Usuario";
            this.buttonBloquear_502ag.UseVisualStyleBackColor = false;
            this.buttonBloquear_502ag.Click += new System.EventHandler(this.buttonBloquear_502ag_Click);
            // 
            // buttonDesbloquear_502ag
            // 
            this.buttonDesbloquear_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDesbloquear_502ag.FlatAppearance.BorderSize = 0;
            this.buttonDesbloquear_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesbloquear_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDesbloquear_502ag.Location = new System.Drawing.Point(161, 343);
            this.buttonDesbloquear_502ag.Name = "buttonDesbloquear_502ag";
            this.buttonDesbloquear_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonDesbloquear_502ag.TabIndex = 24;
            this.buttonDesbloquear_502ag.Text = "Desbloquear Usuario";
            this.buttonDesbloquear_502ag.UseVisualStyleBackColor = false;
            this.buttonDesbloquear_502ag.Click += new System.EventHandler(this.buttonDesbloquear_502ag_Click);
            // 
            // cBRol_502ag
            // 
            this.cBRol_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBRol_502ag.FormattingEnabled = true;
            this.cBRol_502ag.Items.AddRange(new object[] {
            "normal",
            "admin"});
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
            // FormABMUsuario_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 461);
            this.Controls.Add(this.tBModoActual_502ag);
            this.Controls.Add(this.rBTodos_502ag);
            this.Controls.Add(this.rBActivos_502ag);
            this.Controls.Add(this.buttonActivarDesactivar_502ag);
            this.Controls.Add(this.buttonCancelar_502ag);
            this.Controls.Add(this.buttonAplicar_502ag);
            this.Controls.Add(this.cBRol_502ag);
            this.Controls.Add(this.buttonDesbloquear_502ag);
            this.Controls.Add(this.buttonBloquear_502ag);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelRol);
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
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonBloquear_502ag;
        private System.Windows.Forms.Button buttonDesbloquear_502ag;
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
    }
}