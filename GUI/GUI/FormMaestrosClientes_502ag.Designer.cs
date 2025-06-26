namespace GUI
{
    partial class FormMaestrosClientes_502ag
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
            this.dgvClientes_502ag = new System.Windows.Forms.DataGridView();
            this.ColumnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonModificarCliente_502ag = new System.Windows.Forms.Button();
            this.buttonAltaCliente_502ag = new System.Windows.Forms.Button();
            this.buttonBajaCliente_502ag = new System.Windows.Forms.Button();
            this.buttonCancelar_502ag = new System.Windows.Forms.Button();
            this.buttonAplicar_502ag = new System.Windows.Forms.Button();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.labelEmail_502ag = new System.Windows.Forms.Label();
            this.labelDNI_502ag = new System.Windows.Forms.Label();
            this.labelApellido_502ag = new System.Windows.Forms.Label();
            this.labelNombre_502ag = new System.Windows.Forms.Label();
            this.tBEmail_502ag = new System.Windows.Forms.TextBox();
            this.tBDNI_502ag = new System.Windows.Forms.TextBox();
            this.tBApellido_502ag = new System.Windows.Forms.TextBox();
            this.tBNombre_502ag = new System.Windows.Forms.TextBox();
            this.tBTelefono_502ag = new System.Windows.Forms.TextBox();
            this.tBDireccion_502ag = new System.Windows.Forms.TextBox();
            this.labelTelefono_502ag = new System.Windows.Forms.Label();
            this.labelDireccion_502ag = new System.Windows.Forms.Label();
            this.rBTodos_502ag = new System.Windows.Forms.RadioButton();
            this.rBActivos_502ag = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes_502ag
            // 
            this.dgvClientes_502ag.AllowUserToAddRows = false;
            this.dgvClientes_502ag.AllowUserToDeleteRows = false;
            this.dgvClientes_502ag.AllowUserToResizeColumns = false;
            this.dgvClientes_502ag.AllowUserToResizeRows = false;
            this.dgvClientes_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaDNI,
            this.ColumnaNombre,
            this.ColumnaApellido,
            this.ColumnaEmail,
            this.ColumnaDireccion,
            this.ColumnaTelefono,
            this.ColumnaActivo});
            this.dgvClientes_502ag.Location = new System.Drawing.Point(12, 57);
            this.dgvClientes_502ag.MultiSelect = false;
            this.dgvClientes_502ag.Name = "dgvClientes_502ag";
            this.dgvClientes_502ag.ReadOnly = true;
            this.dgvClientes_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes_502ag.Size = new System.Drawing.Size(760, 210);
            this.dgvClientes_502ag.TabIndex = 0;
            this.dgvClientes_502ag.SelectionChanged += new System.EventHandler(this.dgvClientes_502ag_SelectionChanged);
            // 
            // ColumnaDNI
            // 
            this.ColumnaDNI.HeaderText = "DNI";
            this.ColumnaDNI.Name = "ColumnaDNI";
            this.ColumnaDNI.ReadOnly = true;
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
            // ColumnaActivo
            // 
            this.ColumnaActivo.HeaderText = "Activo";
            this.ColumnaActivo.Name = "ColumnaActivo";
            this.ColumnaActivo.ReadOnly = true;
            this.ColumnaActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonModificarCliente_502ag
            // 
            this.buttonModificarCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonModificarCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonModificarCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificarCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonModificarCliente_502ag.Location = new System.Drawing.Point(12, 326);
            this.buttonModificarCliente_502ag.Name = "buttonModificarCliente_502ag";
            this.buttonModificarCliente_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonModificarCliente_502ag.TabIndex = 2;
            this.buttonModificarCliente_502ag.Text = "Modificar Cliente";
            this.buttonModificarCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonModificarCliente_502ag.Click += new System.EventHandler(this.buttonModificarCliente_502ag_Click);
            // 
            // buttonAltaCliente_502ag
            // 
            this.buttonAltaCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAltaCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAltaCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAltaCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAltaCliente_502ag.Location = new System.Drawing.Point(12, 273);
            this.buttonAltaCliente_502ag.Name = "buttonAltaCliente_502ag";
            this.buttonAltaCliente_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonAltaCliente_502ag.TabIndex = 1;
            this.buttonAltaCliente_502ag.Text = "Añadir Cliente";
            this.buttonAltaCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonAltaCliente_502ag.Click += new System.EventHandler(this.buttonAltaCliente_502ag_Click);
            // 
            // buttonBajaCliente_502ag
            // 
            this.buttonBajaCliente_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonBajaCliente_502ag.FlatAppearance.BorderSize = 0;
            this.buttonBajaCliente_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBajaCliente_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBajaCliente_502ag.Location = new System.Drawing.Point(12, 379);
            this.buttonBajaCliente_502ag.Name = "buttonBajaCliente_502ag";
            this.buttonBajaCliente_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonBajaCliente_502ag.TabIndex = 3;
            this.buttonBajaCliente_502ag.Text = "Eliminar Cliente";
            this.buttonBajaCliente_502ag.UseVisualStyleBackColor = false;
            this.buttonBajaCliente_502ag.Click += new System.EventHandler(this.buttonEliminarCliente_502ag_Click);
            // 
            // buttonCancelar_502ag
            // 
            this.buttonCancelar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCancelar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonCancelar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCancelar_502ag.Location = new System.Drawing.Point(640, 326);
            this.buttonCancelar_502ag.Name = "buttonCancelar_502ag";
            this.buttonCancelar_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonCancelar_502ag.TabIndex = 11;
            this.buttonCancelar_502ag.Text = "Cancelar";
            this.buttonCancelar_502ag.UseVisualStyleBackColor = false;
            this.buttonCancelar_502ag.Click += new System.EventHandler(this.buttonCancelar_502ag_Click);
            // 
            // buttonAplicar_502ag
            // 
            this.buttonAplicar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAplicar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAplicar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAplicar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAplicar_502ag.Location = new System.Drawing.Point(640, 273);
            this.buttonAplicar_502ag.Name = "buttonAplicar_502ag";
            this.buttonAplicar_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonAplicar_502ag.TabIndex = 10;
            this.buttonAplicar_502ag.Text = "Aplicar";
            this.buttonAplicar_502ag.UseVisualStyleBackColor = false;
            this.buttonAplicar_502ag.Click += new System.EventHandler(this.buttonAplicar_502ag_Click);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(640, 379);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 12;
            this.buttonVolverAlMenu_502ag.Text = "Volver al menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // labelEmail_502ag
            // 
            this.labelEmail_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEmail_502ag.AutoSize = true;
            this.labelEmail_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelEmail_502ag.Location = new System.Drawing.Point(264, 363);
            this.labelEmail_502ag.Name = "labelEmail_502ag";
            this.labelEmail_502ag.Size = new System.Drawing.Size(42, 17);
            this.labelEmail_502ag.TabIndex = 31;
            this.labelEmail_502ag.Text = "Email";
            // 
            // labelDNI_502ag
            // 
            this.labelDNI_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDNI_502ag.AutoSize = true;
            this.labelDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDNI_502ag.Location = new System.Drawing.Point(264, 276);
            this.labelDNI_502ag.Name = "labelDNI_502ag";
            this.labelDNI_502ag.Size = new System.Drawing.Size(31, 17);
            this.labelDNI_502ag.TabIndex = 30;
            this.labelDNI_502ag.Text = "DNI";
            // 
            // labelApellido_502ag
            // 
            this.labelApellido_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelApellido_502ag.AutoSize = true;
            this.labelApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelApellido_502ag.Location = new System.Drawing.Point(264, 334);
            this.labelApellido_502ag.Name = "labelApellido_502ag";
            this.labelApellido_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelApellido_502ag.TabIndex = 29;
            this.labelApellido_502ag.Text = "Apellido";
            // 
            // labelNombre_502ag
            // 
            this.labelNombre_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre_502ag.AutoSize = true;
            this.labelNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNombre_502ag.Location = new System.Drawing.Point(264, 305);
            this.labelNombre_502ag.Name = "labelNombre_502ag";
            this.labelNombre_502ag.Size = new System.Drawing.Size(58, 17);
            this.labelNombre_502ag.TabIndex = 28;
            this.labelNombre_502ag.Text = "Nombre";
            // 
            // tBEmail_502ag
            // 
            this.tBEmail_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBEmail_502ag.Location = new System.Drawing.Point(343, 360);
            this.tBEmail_502ag.Name = "tBEmail_502ag";
            this.tBEmail_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBEmail_502ag.TabIndex = 7;
            // 
            // tBDNI_502ag
            // 
            this.tBDNI_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBDNI_502ag.Location = new System.Drawing.Point(343, 273);
            this.tBDNI_502ag.Name = "tBDNI_502ag";
            this.tBDNI_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBDNI_502ag.TabIndex = 4;
            // 
            // tBApellido_502ag
            // 
            this.tBApellido_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBApellido_502ag.Location = new System.Drawing.Point(343, 331);
            this.tBApellido_502ag.Name = "tBApellido_502ag";
            this.tBApellido_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBApellido_502ag.TabIndex = 6;
            // 
            // tBNombre_502ag
            // 
            this.tBNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre_502ag.Location = new System.Drawing.Point(343, 302);
            this.tBNombre_502ag.Name = "tBNombre_502ag";
            this.tBNombre_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBNombre_502ag.TabIndex = 5;
            // 
            // tBTelefono_502ag
            // 
            this.tBTelefono_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBTelefono_502ag.Location = new System.Drawing.Point(343, 418);
            this.tBTelefono_502ag.Name = "tBTelefono_502ag";
            this.tBTelefono_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBTelefono_502ag.TabIndex = 9;
            // 
            // tBDireccion_502ag
            // 
            this.tBDireccion_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBDireccion_502ag.Location = new System.Drawing.Point(343, 389);
            this.tBDireccion_502ag.Name = "tBDireccion_502ag";
            this.tBDireccion_502ag.Size = new System.Drawing.Size(175, 23);
            this.tBDireccion_502ag.TabIndex = 8;
            // 
            // labelTelefono_502ag
            // 
            this.labelTelefono_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTelefono_502ag.AutoSize = true;
            this.labelTelefono_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTelefono_502ag.Location = new System.Drawing.Point(264, 421);
            this.labelTelefono_502ag.Name = "labelTelefono_502ag";
            this.labelTelefono_502ag.Size = new System.Drawing.Size(64, 17);
            this.labelTelefono_502ag.TabIndex = 35;
            this.labelTelefono_502ag.Text = "Telefono";
            // 
            // labelDireccion_502ag
            // 
            this.labelDireccion_502ag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDireccion_502ag.AutoSize = true;
            this.labelDireccion_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDireccion_502ag.Location = new System.Drawing.Point(264, 392);
            this.labelDireccion_502ag.Name = "labelDireccion_502ag";
            this.labelDireccion_502ag.Size = new System.Drawing.Size(67, 17);
            this.labelDireccion_502ag.TabIndex = 34;
            this.labelDireccion_502ag.Text = "Dirección";
            // 
            // rBTodos_502ag
            // 
            this.rBTodos_502ag.AutoSize = true;
            this.rBTodos_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBTodos_502ag.Location = new System.Drawing.Point(12, 35);
            this.rBTodos_502ag.Name = "rBTodos_502ag";
            this.rBTodos_502ag.Size = new System.Drawing.Size(66, 21);
            this.rBTodos_502ag.TabIndex = 37;
            this.rBTodos_502ag.Text = "Todos";
            this.rBTodos_502ag.UseVisualStyleBackColor = true;
            this.rBTodos_502ag.CheckedChanged += new System.EventHandler(this.rBTodos_502ag_CheckedChanged);
            // 
            // rBActivos_502ag
            // 
            this.rBActivos_502ag.AutoSize = true;
            this.rBActivos_502ag.Checked = true;
            this.rBActivos_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBActivos_502ag.Location = new System.Drawing.Point(12, 12);
            this.rBActivos_502ag.Name = "rBActivos_502ag";
            this.rBActivos_502ag.Size = new System.Drawing.Size(71, 21);
            this.rBActivos_502ag.TabIndex = 36;
            this.rBActivos_502ag.TabStop = true;
            this.rBActivos_502ag.Text = "Activos";
            this.rBActivos_502ag.UseVisualStyleBackColor = true;
            // 
            // FormMaestrosClientes_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.rBTodos_502ag);
            this.Controls.Add(this.rBActivos_502ag);
            this.Controls.Add(this.labelTelefono_502ag);
            this.Controls.Add(this.labelDireccion_502ag);
            this.Controls.Add(this.tBTelefono_502ag);
            this.Controls.Add(this.tBDireccion_502ag);
            this.Controls.Add(this.labelEmail_502ag);
            this.Controls.Add(this.labelDNI_502ag);
            this.Controls.Add(this.labelApellido_502ag);
            this.Controls.Add(this.labelNombre_502ag);
            this.Controls.Add(this.tBEmail_502ag);
            this.Controls.Add(this.tBDNI_502ag);
            this.Controls.Add(this.tBApellido_502ag);
            this.Controls.Add(this.tBNombre_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.buttonCancelar_502ag);
            this.Controls.Add(this.buttonAplicar_502ag);
            this.Controls.Add(this.buttonBajaCliente_502ag);
            this.Controls.Add(this.buttonModificarCliente_502ag);
            this.Controls.Add(this.buttonAltaCliente_502ag);
            this.Controls.Add(this.dgvClientes_502ag);
            this.Name = "FormMaestrosClientes_502ag";
            this.Text = "FormMaestrosClientes_502ag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMaestrosClientes_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes_502ag;
        private System.Windows.Forms.Button buttonModificarCliente_502ag;
        private System.Windows.Forms.Button buttonAltaCliente_502ag;
        private System.Windows.Forms.Button buttonBajaCliente_502ag;
        private System.Windows.Forms.Button buttonCancelar_502ag;
        private System.Windows.Forms.Button buttonAplicar_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Label labelEmail_502ag;
        private System.Windows.Forms.Label labelDNI_502ag;
        private System.Windows.Forms.Label labelApellido_502ag;
        private System.Windows.Forms.Label labelNombre_502ag;
        private System.Windows.Forms.TextBox tBEmail_502ag;
        private System.Windows.Forms.TextBox tBDNI_502ag;
        private System.Windows.Forms.TextBox tBApellido_502ag;
        private System.Windows.Forms.TextBox tBNombre_502ag;
        private System.Windows.Forms.TextBox tBTelefono_502ag;
        private System.Windows.Forms.TextBox tBDireccion_502ag;
        private System.Windows.Forms.Label labelTelefono_502ag;
        private System.Windows.Forms.Label labelDireccion_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTelefono;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaActivo;
        private System.Windows.Forms.RadioButton rBTodos_502ag;
        private System.Windows.Forms.RadioButton rBActivos_502ag;
    }
}