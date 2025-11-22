namespace GUI
{
    partial class FormBitacoraEventos_502ag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBitacoraEventos_502ag));
            this.dgvBitacoraEventos_502ag = new System.Windows.Forms.DataGridView();
            this.Usuario_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criticidad_502ag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBUsuario_502ag = new System.Windows.Forms.ComboBox();
            this.labelUsuario_502ag = new System.Windows.Forms.Label();
            this.labelModulo_502ag = new System.Windows.Forms.Label();
            this.cBModulo_502ag = new System.Windows.Forms.ComboBox();
            this.labelEvento_502ag = new System.Windows.Forms.Label();
            this.cBEvento_502ag = new System.Windows.Forms.ComboBox();
            this.labelCriticidad_502ag = new System.Windows.Forms.Label();
            this.cBCriticidad_502ag = new System.Windows.Forms.ComboBox();
            this.dTPDesde_502ag = new System.Windows.Forms.DateTimePicker();
            this.dTPHasta_502ag = new System.Windows.Forms.DateTimePicker();
            this.labelDesde_502ag = new System.Windows.Forms.Label();
            this.labelHasta_502ag = new System.Windows.Forms.Label();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.buttonAplicar_502ag = new System.Windows.Forms.Button();
            this.buttonResetearGrilla_502ag = new System.Windows.Forms.Button();
            this.tBNombre_502ag = new System.Windows.Forms.TextBox();
            this.tBApellido_502ag = new System.Windows.Forms.TextBox();
            this.labelNombre_502ag = new System.Windows.Forms.Label();
            this.labelApellido_502ag = new System.Windows.Forms.Label();
            this.checkBoxFecha_502ag = new System.Windows.Forms.CheckBox();
            this.buttonImprimir_502ag = new System.Windows.Forms.Button();
            this.buttonAyuda2_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoraEventos_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacoraEventos_502ag
            // 
            this.dgvBitacoraEventos_502ag.AllowUserToAddRows = false;
            this.dgvBitacoraEventos_502ag.AllowUserToDeleteRows = false;
            this.dgvBitacoraEventos_502ag.AllowUserToResizeColumns = false;
            this.dgvBitacoraEventos_502ag.AllowUserToResizeRows = false;
            this.dgvBitacoraEventos_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacoraEventos_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacoraEventos_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario_502ag,
            this.Fecha_502ag,
            this.Hora_502ag,
            this.Modulo_502ag,
            this.Evento_502ag,
            this.Criticidad_502ag});
            this.dgvBitacoraEventos_502ag.Location = new System.Drawing.Point(9, 14);
            this.dgvBitacoraEventos_502ag.MultiSelect = false;
            this.dgvBitacoraEventos_502ag.Name = "dgvBitacoraEventos_502ag";
            this.dgvBitacoraEventos_502ag.ReadOnly = true;
            this.dgvBitacoraEventos_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacoraEventos_502ag.Size = new System.Drawing.Size(760, 246);
            this.dgvBitacoraEventos_502ag.TabIndex = 1;
            this.dgvBitacoraEventos_502ag.SelectionChanged += new System.EventHandler(this.dgvBitacoraEventos_502ag_SelectionChanged);
            // 
            // Usuario_502ag
            // 
            this.Usuario_502ag.HeaderText = "Usuario";
            this.Usuario_502ag.Name = "Usuario_502ag";
            this.Usuario_502ag.ReadOnly = true;
            // 
            // Fecha_502ag
            // 
            this.Fecha_502ag.HeaderText = "Fecha";
            this.Fecha_502ag.Name = "Fecha_502ag";
            this.Fecha_502ag.ReadOnly = true;
            // 
            // Hora_502ag
            // 
            this.Hora_502ag.HeaderText = "Hora";
            this.Hora_502ag.Name = "Hora_502ag";
            this.Hora_502ag.ReadOnly = true;
            // 
            // Modulo_502ag
            // 
            this.Modulo_502ag.HeaderText = "Modulo";
            this.Modulo_502ag.Name = "Modulo_502ag";
            this.Modulo_502ag.ReadOnly = true;
            // 
            // Evento_502ag
            // 
            this.Evento_502ag.HeaderText = "Evento";
            this.Evento_502ag.Name = "Evento_502ag";
            this.Evento_502ag.ReadOnly = true;
            // 
            // Criticidad_502ag
            // 
            this.Criticidad_502ag.HeaderText = "Criticidad";
            this.Criticidad_502ag.Name = "Criticidad_502ag";
            this.Criticidad_502ag.ReadOnly = true;
            // 
            // cBUsuario_502ag
            // 
            this.cBUsuario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBUsuario_502ag.FormattingEnabled = true;
            this.cBUsuario_502ag.Location = new System.Drawing.Point(207, 306);
            this.cBUsuario_502ag.Name = "cBUsuario_502ag";
            this.cBUsuario_502ag.Size = new System.Drawing.Size(129, 24);
            this.cBUsuario_502ag.TabIndex = 2;
            // 
            // labelUsuario_502ag
            // 
            this.labelUsuario_502ag.AutoSize = true;
            this.labelUsuario_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUsuario_502ag.Location = new System.Drawing.Point(204, 286);
            this.labelUsuario_502ag.Name = "labelUsuario_502ag";
            this.labelUsuario_502ag.Size = new System.Drawing.Size(57, 17);
            this.labelUsuario_502ag.TabIndex = 3;
            this.labelUsuario_502ag.Text = "Usuario";
            // 
            // labelModulo_502ag
            // 
            this.labelModulo_502ag.AutoSize = true;
            this.labelModulo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelModulo_502ag.Location = new System.Drawing.Point(563, 287);
            this.labelModulo_502ag.Name = "labelModulo_502ag";
            this.labelModulo_502ag.Size = new System.Drawing.Size(54, 17);
            this.labelModulo_502ag.TabIndex = 5;
            this.labelModulo_502ag.Text = "Módulo";
            // 
            // cBModulo_502ag
            // 
            this.cBModulo_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBModulo_502ag.FormattingEnabled = true;
            this.cBModulo_502ag.Location = new System.Drawing.Point(566, 305);
            this.cBModulo_502ag.Name = "cBModulo_502ag";
            this.cBModulo_502ag.Size = new System.Drawing.Size(198, 24);
            this.cBModulo_502ag.TabIndex = 4;
            this.cBModulo_502ag.SelectedIndexChanged += new System.EventHandler(this.cBModulo_502ag_SelectedIndexChanged);
            // 
            // labelEvento_502ag
            // 
            this.labelEvento_502ag.AutoSize = true;
            this.labelEvento_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEvento_502ag.Location = new System.Drawing.Point(563, 332);
            this.labelEvento_502ag.Name = "labelEvento_502ag";
            this.labelEvento_502ag.Size = new System.Drawing.Size(52, 17);
            this.labelEvento_502ag.TabIndex = 7;
            this.labelEvento_502ag.Text = "Evento";
            // 
            // cBEvento_502ag
            // 
            this.cBEvento_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBEvento_502ag.FormattingEnabled = true;
            this.cBEvento_502ag.Location = new System.Drawing.Point(566, 350);
            this.cBEvento_502ag.Name = "cBEvento_502ag";
            this.cBEvento_502ag.Size = new System.Drawing.Size(198, 24);
            this.cBEvento_502ag.TabIndex = 6;
            // 
            // labelCriticidad_502ag
            // 
            this.labelCriticidad_502ag.AutoSize = true;
            this.labelCriticidad_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCriticidad_502ag.Location = new System.Drawing.Point(204, 332);
            this.labelCriticidad_502ag.Name = "labelCriticidad_502ag";
            this.labelCriticidad_502ag.Size = new System.Drawing.Size(66, 17);
            this.labelCriticidad_502ag.TabIndex = 9;
            this.labelCriticidad_502ag.Text = "Criticidad";
            // 
            // cBCriticidad_502ag
            // 
            this.cBCriticidad_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBCriticidad_502ag.FormattingEnabled = true;
            this.cBCriticidad_502ag.Location = new System.Drawing.Point(207, 352);
            this.cBCriticidad_502ag.Name = "cBCriticidad_502ag";
            this.cBCriticidad_502ag.Size = new System.Drawing.Size(129, 24);
            this.cBCriticidad_502ag.TabIndex = 8;
            // 
            // dTPDesde_502ag
            // 
            this.dTPDesde_502ag.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dTPDesde_502ag.Location = new System.Drawing.Point(353, 306);
            this.dTPDesde_502ag.Name = "dTPDesde_502ag";
            this.dTPDesde_502ag.Size = new System.Drawing.Size(201, 20);
            this.dTPDesde_502ag.TabIndex = 10;
            // 
            // dTPHasta_502ag
            // 
            this.dTPHasta_502ag.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dTPHasta_502ag.Location = new System.Drawing.Point(353, 351);
            this.dTPHasta_502ag.Name = "dTPHasta_502ag";
            this.dTPHasta_502ag.Size = new System.Drawing.Size(200, 20);
            this.dTPHasta_502ag.TabIndex = 11;
            // 
            // labelDesde_502ag
            // 
            this.labelDesde_502ag.AutoSize = true;
            this.labelDesde_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDesde_502ag.Location = new System.Drawing.Point(350, 287);
            this.labelDesde_502ag.Name = "labelDesde_502ag";
            this.labelDesde_502ag.Size = new System.Drawing.Size(49, 17);
            this.labelDesde_502ag.TabIndex = 12;
            this.labelDesde_502ag.Text = "Desde";
            // 
            // labelHasta_502ag
            // 
            this.labelHasta_502ag.AutoSize = true;
            this.labelHasta_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHasta_502ag.Location = new System.Drawing.Point(350, 333);
            this.labelHasta_502ag.Name = "labelHasta_502ag";
            this.labelHasta_502ag.Size = new System.Drawing.Size(45, 17);
            this.labelHasta_502ag.TabIndex = 13;
            this.labelHasta_502ag.Text = "Hasta";
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(659, 409);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(110, 40);
            this.buttonVolverAlMenu_502ag.TabIndex = 15;
            this.buttonVolverAlMenu_502ag.Text = "Volver al menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // buttonAplicar_502ag
            // 
            this.buttonAplicar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAplicar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAplicar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAplicar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAplicar_502ag.Location = new System.Drawing.Point(543, 409);
            this.buttonAplicar_502ag.Name = "buttonAplicar_502ag";
            this.buttonAplicar_502ag.Size = new System.Drawing.Size(110, 40);
            this.buttonAplicar_502ag.TabIndex = 14;
            this.buttonAplicar_502ag.Text = "Aplicar";
            this.buttonAplicar_502ag.UseVisualStyleBackColor = false;
            this.buttonAplicar_502ag.Click += new System.EventHandler(this.buttonAplicar_502ag_Click);
            // 
            // buttonResetearGrilla_502ag
            // 
            this.buttonResetearGrilla_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonResetearGrilla_502ag.FlatAppearance.BorderSize = 0;
            this.buttonResetearGrilla_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetearGrilla_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonResetearGrilla_502ag.Location = new System.Drawing.Point(427, 409);
            this.buttonResetearGrilla_502ag.Name = "buttonResetearGrilla_502ag";
            this.buttonResetearGrilla_502ag.Size = new System.Drawing.Size(110, 40);
            this.buttonResetearGrilla_502ag.TabIndex = 16;
            this.buttonResetearGrilla_502ag.Text = "Resetear Grilla";
            this.buttonResetearGrilla_502ag.UseVisualStyleBackColor = false;
            this.buttonResetearGrilla_502ag.Click += new System.EventHandler(this.buttonResetearGrilla_502ag_Click);
            // 
            // tBNombre_502ag
            // 
            this.tBNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre_502ag.Location = new System.Drawing.Point(54, 307);
            this.tBNombre_502ag.Name = "tBNombre_502ag";
            this.tBNombre_502ag.ReadOnly = true;
            this.tBNombre_502ag.Size = new System.Drawing.Size(116, 23);
            this.tBNombre_502ag.TabIndex = 17;
            // 
            // tBApellido_502ag
            // 
            this.tBApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBApellido_502ag.Location = new System.Drawing.Point(54, 353);
            this.tBApellido_502ag.Name = "tBApellido_502ag";
            this.tBApellido_502ag.ReadOnly = true;
            this.tBApellido_502ag.Size = new System.Drawing.Size(116, 23);
            this.tBApellido_502ag.TabIndex = 18;
            // 
            // labelNombre_502ag
            // 
            this.labelNombre_502ag.AutoSize = true;
            this.labelNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre_502ag.Location = new System.Drawing.Point(51, 287);
            this.labelNombre_502ag.Name = "labelNombre_502ag";
            this.labelNombre_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelNombre_502ag.TabIndex = 19;
            this.labelNombre_502ag.Text = "Nombre";
            // 
            // labelApellido_502ag
            // 
            this.labelApellido_502ag.AutoSize = true;
            this.labelApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido_502ag.Location = new System.Drawing.Point(51, 333);
            this.labelApellido_502ag.Name = "labelApellido_502ag";
            this.labelApellido_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelApellido_502ag.TabIndex = 20;
            this.labelApellido_502ag.Text = "Apellido";
            // 
            // checkBoxFecha_502ag
            // 
            this.checkBoxFecha_502ag.AutoSize = true;
            this.checkBoxFecha_502ag.Location = new System.Drawing.Point(414, 266);
            this.checkBoxFecha_502ag.Name = "checkBoxFecha_502ag";
            this.checkBoxFecha_502ag.Size = new System.Drawing.Size(102, 17);
            this.checkBoxFecha_502ag.TabIndex = 21;
            this.checkBoxFecha_502ag.Text = "Filtrar por Fecha";
            this.checkBoxFecha_502ag.UseVisualStyleBackColor = true;
            this.checkBoxFecha_502ag.CheckedChanged += new System.EventHandler(this.checkBoxFecha_502ag_CheckedChanged);
            // 
            // buttonImprimir_502ag
            // 
            this.buttonImprimir_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonImprimir_502ag.FlatAppearance.BorderSize = 0;
            this.buttonImprimir_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimir_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonImprimir_502ag.Location = new System.Drawing.Point(54, 409);
            this.buttonImprimir_502ag.Name = "buttonImprimir_502ag";
            this.buttonImprimir_502ag.Size = new System.Drawing.Size(110, 40);
            this.buttonImprimir_502ag.TabIndex = 22;
            this.buttonImprimir_502ag.Text = "Imprimir";
            this.buttonImprimir_502ag.UseVisualStyleBackColor = false;
            this.buttonImprimir_502ag.Click += new System.EventHandler(this.buttonImprimir_502ag_Click);
            // 
            // buttonAyuda2_502ag
            // 
            this.buttonAyuda2_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAyuda2_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAyuda2_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAyuda2_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAyuda2_502ag.Image = ((System.Drawing.Image)(resources.GetObject("buttonAyuda2_502ag.Image")));
            this.buttonAyuda2_502ag.Location = new System.Drawing.Point(3, 404);
            this.buttonAyuda2_502ag.Name = "buttonAyuda2_502ag";
            this.buttonAyuda2_502ag.Size = new System.Drawing.Size(45, 45);
            this.buttonAyuda2_502ag.TabIndex = 53;
            this.buttonAyuda2_502ag.UseVisualStyleBackColor = false;
            this.buttonAyuda2_502ag.Click += new System.EventHandler(this.buttonAyuda2_502ag_Click);
            // 
            // FormBitacoraEventos_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonAyuda2_502ag);
            this.Controls.Add(this.buttonImprimir_502ag);
            this.Controls.Add(this.checkBoxFecha_502ag);
            this.Controls.Add(this.labelApellido_502ag);
            this.Controls.Add(this.labelNombre_502ag);
            this.Controls.Add(this.tBApellido_502ag);
            this.Controls.Add(this.tBNombre_502ag);
            this.Controls.Add(this.buttonResetearGrilla_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.buttonAplicar_502ag);
            this.Controls.Add(this.labelHasta_502ag);
            this.Controls.Add(this.labelDesde_502ag);
            this.Controls.Add(this.dTPHasta_502ag);
            this.Controls.Add(this.dTPDesde_502ag);
            this.Controls.Add(this.labelCriticidad_502ag);
            this.Controls.Add(this.cBCriticidad_502ag);
            this.Controls.Add(this.labelEvento_502ag);
            this.Controls.Add(this.cBEvento_502ag);
            this.Controls.Add(this.labelModulo_502ag);
            this.Controls.Add(this.cBModulo_502ag);
            this.Controls.Add(this.labelUsuario_502ag);
            this.Controls.Add(this.cBUsuario_502ag);
            this.Controls.Add(this.dgvBitacoraEventos_502ag);
            this.Name = "FormBitacoraEventos_502ag";
            this.Text = "FormBitacoraEventos_502ag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBitacoraEventos_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacoraEventos_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacoraEventos_502ag;
        private System.Windows.Forms.ComboBox cBUsuario_502ag;
        private System.Windows.Forms.Label labelUsuario_502ag;
        private System.Windows.Forms.Label labelModulo_502ag;
        private System.Windows.Forms.ComboBox cBModulo_502ag;
        private System.Windows.Forms.Label labelEvento_502ag;
        private System.Windows.Forms.ComboBox cBEvento_502ag;
        private System.Windows.Forms.Label labelCriticidad_502ag;
        private System.Windows.Forms.ComboBox cBCriticidad_502ag;
        private System.Windows.Forms.DateTimePicker dTPDesde_502ag;
        private System.Windows.Forms.DateTimePicker dTPHasta_502ag;
        private System.Windows.Forms.Label labelDesde_502ag;
        private System.Windows.Forms.Label labelHasta_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Button buttonAplicar_502ag;
        private System.Windows.Forms.Button buttonResetearGrilla_502ag;
        private System.Windows.Forms.TextBox tBNombre_502ag;
        private System.Windows.Forms.TextBox tBApellido_502ag;
        private System.Windows.Forms.Label labelNombre_502ag;
        private System.Windows.Forms.Label labelApellido_502ag;
        private System.Windows.Forms.CheckBox checkBoxFecha_502ag;
        private System.Windows.Forms.Button buttonImprimir_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criticidad_502ag;
        private System.Windows.Forms.Button buttonAyuda2_502ag;
    }
}