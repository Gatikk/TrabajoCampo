namespace GUI
{
    partial class FormABM
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
            this.buttonVolverAlMenu = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.buttonAltaUsuario = new System.Windows.Forms.Button();
            this.buttonBajaUsuario = new System.Windows.Forms.Button();
            this.buttonModificarUsuario = new System.Windows.Forms.Button();
            this.tBNombreUsuario = new System.Windows.Forms.TextBox();
            this.tBNombre = new System.Windows.Forms.TextBox();
            this.tBApellido = new System.Windows.Forms.TextBox();
            this.tBDNI = new System.Windows.Forms.TextBox();
            this.tBEmail = new System.Windows.Forms.TextBox();
            this.labelNombreUsuario = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonBloquear = new System.Windows.Forms.Button();
            this.buttonDesbloquear = new System.Windows.Forms.Button();
            this.cBRol = new System.Windows.Forms.ComboBox();
            this.ColumnaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaContraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaBloqueado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaIntentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVolverAlMenu
            // 
            this.buttonVolverAlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu.Location = new System.Drawing.Point(640, 402);
            this.buttonVolverAlMenu.Name = "buttonVolverAlMenu";
            this.buttonVolverAlMenu.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu.TabIndex = 2;
            this.buttonVolverAlMenu.Text = "Volver al Menú";
            this.buttonVolverAlMenu.UseVisualStyleBackColor = true;
            this.buttonVolverAlMenu.Click += new System.EventHandler(this.buttonVolverAlMenu_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaUsuario,
            this.ColumnaContraseña,
            this.ColumnaRol,
            this.ColumnaNombre,
            this.ColumnaApellido,
            this.ColumnaDNI,
            this.ColumnaEmail,
            this.ColumnaBloqueado,
            this.ColumnaIntentos});
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 251);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // buttonAltaUsuario
            // 
            this.buttonAltaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAltaUsuario.Location = new System.Drawing.Point(12, 282);
            this.buttonAltaUsuario.Name = "buttonAltaUsuario";
            this.buttonAltaUsuario.Size = new System.Drawing.Size(132, 47);
            this.buttonAltaUsuario.TabIndex = 4;
            this.buttonAltaUsuario.Text = "Alta Usuario";
            this.buttonAltaUsuario.UseVisualStyleBackColor = true;
            this.buttonAltaUsuario.Click += new System.EventHandler(this.buttonAltaUsuario_Click);
            // 
            // buttonBajaUsuario
            // 
            this.buttonBajaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBajaUsuario.Location = new System.Drawing.Point(12, 345);
            this.buttonBajaUsuario.Name = "buttonBajaUsuario";
            this.buttonBajaUsuario.Size = new System.Drawing.Size(132, 47);
            this.buttonBajaUsuario.TabIndex = 5;
            this.buttonBajaUsuario.Text = "Baja Usuario";
            this.buttonBajaUsuario.UseVisualStyleBackColor = true;
            this.buttonBajaUsuario.Click += new System.EventHandler(this.buttonBajaUsuario_Click);
            // 
            // buttonModificarUsuario
            // 
            this.buttonModificarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonModificarUsuario.Location = new System.Drawing.Point(12, 405);
            this.buttonModificarUsuario.Name = "buttonModificarUsuario";
            this.buttonModificarUsuario.Size = new System.Drawing.Size(132, 47);
            this.buttonModificarUsuario.TabIndex = 6;
            this.buttonModificarUsuario.Text = "Modificar Usuario";
            this.buttonModificarUsuario.UseVisualStyleBackColor = true;
            this.buttonModificarUsuario.Click += new System.EventHandler(this.buttonModificarUsuario_Click);
            // 
            // tBNombreUsuario
            // 
            this.tBNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombreUsuario.Location = new System.Drawing.Point(342, 282);
            this.tBNombreUsuario.Name = "tBNombreUsuario";
            this.tBNombreUsuario.Size = new System.Drawing.Size(175, 23);
            this.tBNombreUsuario.TabIndex = 9;
            this.tBNombreUsuario.TextChanged += new System.EventHandler(this.tBNombreUsuario_TextChanged);
            // 
            // tBNombre
            // 
            this.tBNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre.Location = new System.Drawing.Point(342, 340);
            this.tBNombre.Name = "tBNombre";
            this.tBNombre.Size = new System.Drawing.Size(175, 23);
            this.tBNombre.TabIndex = 11;
            this.tBNombre.TextChanged += new System.EventHandler(this.tBNombre_TextChanged);
            // 
            // tBApellido
            // 
            this.tBApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBApellido.Location = new System.Drawing.Point(342, 369);
            this.tBApellido.Name = "tBApellido";
            this.tBApellido.Size = new System.Drawing.Size(175, 23);
            this.tBApellido.TabIndex = 12;
            this.tBApellido.TextChanged += new System.EventHandler(this.tBApellido_TextChanged);
            // 
            // tBDNI
            // 
            this.tBDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBDNI.Location = new System.Drawing.Point(342, 400);
            this.tBDNI.Name = "tBDNI";
            this.tBDNI.Size = new System.Drawing.Size(175, 23);
            this.tBDNI.TabIndex = 13;
            this.tBDNI.TextChanged += new System.EventHandler(this.tBDNI_TextChanged);
            // 
            // tBEmail
            // 
            this.tBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBEmail.Location = new System.Drawing.Point(342, 429);
            this.tBEmail.Name = "tBEmail";
            this.tBEmail.Size = new System.Drawing.Size(175, 23);
            this.tBEmail.TabIndex = 15;
            this.tBEmail.TextChanged += new System.EventHandler(this.tBEmail_TextChanged);
            // 
            // labelNombreUsuario
            // 
            this.labelNombreUsuario.AutoSize = true;
            this.labelNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombreUsuario.Location = new System.Drawing.Point(277, 285);
            this.labelNombreUsuario.Name = "labelNombreUsuario";
            this.labelNombreUsuario.Size = new System.Drawing.Size(74, 17);
            this.labelNombreUsuario.TabIndex = 16;
            this.labelNombreUsuario.Text = "Usuario_T";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRol.Location = new System.Drawing.Point(278, 314);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(46, 17);
            this.labelRol.TabIndex = 17;
            this.labelRol.Text = "Rol_T";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre.Location = new System.Drawing.Point(278, 343);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(75, 17);
            this.labelNombre.TabIndex = 18;
            this.labelNombre.Text = "Nombre_T";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido.Location = new System.Drawing.Point(278, 372);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(75, 17);
            this.labelApellido.TabIndex = 19;
            this.labelApellido.Text = "Apellido_T";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI.Location = new System.Drawing.Point(278, 403);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(48, 17);
            this.labelDNI.TabIndex = 20;
            this.labelDNI.Text = "DNI_T";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEmail.Location = new System.Drawing.Point(278, 432);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(59, 17);
            this.labelEmail.TabIndex = 21;
            this.labelEmail.Text = "Email_T";
            // 
            // buttonBloquear
            // 
            this.buttonBloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBloquear.Location = new System.Drawing.Point(640, 282);
            this.buttonBloquear.Name = "buttonBloquear";
            this.buttonBloquear.Size = new System.Drawing.Size(132, 47);
            this.buttonBloquear.TabIndex = 23;
            this.buttonBloquear.Text = "Bloquear Usuario";
            this.buttonBloquear.UseVisualStyleBackColor = true;
            this.buttonBloquear.Click += new System.EventHandler(this.buttonBloquear_Click);
            // 
            // buttonDesbloquear
            // 
            this.buttonDesbloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDesbloquear.Location = new System.Drawing.Point(640, 342);
            this.buttonDesbloquear.Name = "buttonDesbloquear";
            this.buttonDesbloquear.Size = new System.Drawing.Size(132, 47);
            this.buttonDesbloquear.TabIndex = 24;
            this.buttonDesbloquear.Text = "Desbloquear Usuario";
            this.buttonDesbloquear.UseVisualStyleBackColor = true;
            this.buttonDesbloquear.Click += new System.EventHandler(this.buttonDesbloquear_Click);
            // 
            // cBRol
            // 
            this.cBRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBRol.FormattingEnabled = true;
            this.cBRol.Items.AddRange(new object[] {
            "normal",
            "admin"});
            this.cBRol.Location = new System.Drawing.Point(342, 311);
            this.cBRol.Name = "cBRol";
            this.cBRol.Size = new System.Drawing.Size(175, 24);
            this.cBRol.TabIndex = 25;
            this.cBRol.SelectedIndexChanged += new System.EventHandler(this.cBRol_SelectedIndexChanged);
            // 
            // ColumnaUsuario
            // 
            this.ColumnaUsuario.HeaderText = "Usuario_T";
            this.ColumnaUsuario.Name = "ColumnaUsuario";
            this.ColumnaUsuario.ReadOnly = true;
            // 
            // ColumnaContraseña
            // 
            this.ColumnaContraseña.HeaderText = "Contraseña_T";
            this.ColumnaContraseña.Name = "ColumnaContraseña";
            this.ColumnaContraseña.ReadOnly = true;
            // 
            // ColumnaRol
            // 
            this.ColumnaRol.HeaderText = "Rol_T";
            this.ColumnaRol.Name = "ColumnaRol";
            this.ColumnaRol.ReadOnly = true;
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.HeaderText = "Nombre_T";
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // ColumnaApellido
            // 
            this.ColumnaApellido.HeaderText = "Apellido_T";
            this.ColumnaApellido.Name = "ColumnaApellido";
            this.ColumnaApellido.ReadOnly = true;
            // 
            // ColumnaDNI
            // 
            this.ColumnaDNI.HeaderText = "DNI_T";
            this.ColumnaDNI.Name = "ColumnaDNI";
            this.ColumnaDNI.ReadOnly = true;
            // 
            // ColumnaEmail
            // 
            this.ColumnaEmail.HeaderText = "Email_T";
            this.ColumnaEmail.Name = "ColumnaEmail";
            this.ColumnaEmail.ReadOnly = true;
            this.ColumnaEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnaBloqueado
            // 
            this.ColumnaBloqueado.HeaderText = "isBloqueado_T";
            this.ColumnaBloqueado.Name = "ColumnaBloqueado";
            this.ColumnaBloqueado.ReadOnly = true;
            this.ColumnaBloqueado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaBloqueado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnaIntentos
            // 
            this.ColumnaIntentos.HeaderText = "Intentos_T";
            this.ColumnaIntentos.Name = "ColumnaIntentos";
            this.ColumnaIntentos.ReadOnly = true;
            // 
            // FormABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 461);
            this.Controls.Add(this.cBRol);
            this.Controls.Add(this.buttonDesbloquear);
            this.Controls.Add(this.buttonBloquear);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.labelNombreUsuario);
            this.Controls.Add(this.tBEmail);
            this.Controls.Add(this.tBDNI);
            this.Controls.Add(this.tBApellido);
            this.Controls.Add(this.tBNombre);
            this.Controls.Add(this.tBNombreUsuario);
            this.Controls.Add(this.buttonModificarUsuario);
            this.Controls.Add(this.buttonBajaUsuario);
            this.Controls.Add(this.buttonAltaUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.buttonVolverAlMenu);
            this.Name = "FormABM";
            this.Text = "FormABM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormABM_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVolverAlMenu;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button buttonAltaUsuario;
        private System.Windows.Forms.Button buttonBajaUsuario;
        private System.Windows.Forms.Button buttonModificarUsuario;
        private System.Windows.Forms.TextBox tBNombreUsuario;
        private System.Windows.Forms.TextBox tBNombre;
        private System.Windows.Forms.TextBox tBApellido;
        private System.Windows.Forms.TextBox tBDNI;
        private System.Windows.Forms.TextBox tBEmail;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonBloquear;
        private System.Windows.Forms.Button buttonDesbloquear;
        private System.Windows.Forms.ComboBox cBRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaContraseña;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaBloqueado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaIntentos;
    }
}