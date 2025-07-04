namespace GUI
{
    partial class FormVerFacturas_502ag
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
            this.dgvFacturas_502ag = new System.Windows.Forms.DataGridView();
            this.columnaCodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaCantCargada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.rBASC_502ag = new System.Windows.Forms.RadioButton();
            this.rBDESC_502ag = new System.Windows.Forms.RadioButton();
            this.cBOrdenarPor_502ag = new System.Windows.Forms.ComboBox();
            this.labelOrdenarPor_502ag = new System.Windows.Forms.Label();
            this.cBFecha_502ag = new System.Windows.Forms.ComboBox();
            this.labelFechas_502ag = new System.Windows.Forms.Label();
            this.buttonImprimirFactura_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas_502ag)).BeginInit();
            this.SuspendLayout();
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
            this.columnaCodigoFactura,
            this.columnaDNI,
            this.columnaNombre,
            this.columnaMetodoPago,
            this.columnaFecha,
            this.columnaHora,
            this.columnaCombustible,
            this.columnaMonto,
            this.columnaCantCargada});
            this.dgvFacturas_502ag.Location = new System.Drawing.Point(12, 12);
            this.dgvFacturas_502ag.MultiSelect = false;
            this.dgvFacturas_502ag.Name = "dgvFacturas_502ag";
            this.dgvFacturas_502ag.ReadOnly = true;
            this.dgvFacturas_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas_502ag.Size = new System.Drawing.Size(760, 237);
            this.dgvFacturas_502ag.TabIndex = 76;
            // 
            // columnaCodigoFactura
            // 
            this.columnaCodigoFactura.FillWeight = 50F;
            this.columnaCodigoFactura.HeaderText = "Codigo";
            this.columnaCodigoFactura.Name = "columnaCodigoFactura";
            this.columnaCodigoFactura.ReadOnly = true;
            this.columnaCodigoFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaDNI
            // 
            this.columnaDNI.FillWeight = 79.94923F;
            this.columnaDNI.HeaderText = "DNI";
            this.columnaDNI.Name = "columnaDNI";
            this.columnaDNI.ReadOnly = true;
            this.columnaDNI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaNombre
            // 
            this.columnaNombre.FillWeight = 90F;
            this.columnaNombre.HeaderText = "Nombre";
            this.columnaNombre.Name = "columnaNombre";
            this.columnaNombre.ReadOnly = true;
            this.columnaNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaMetodoPago
            // 
            this.columnaMetodoPago.FillWeight = 79.94923F;
            this.columnaMetodoPago.HeaderText = "Método Pago";
            this.columnaMetodoPago.Name = "columnaMetodoPago";
            this.columnaMetodoPago.ReadOnly = true;
            this.columnaMetodoPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaFecha
            // 
            this.columnaFecha.FillWeight = 60F;
            this.columnaFecha.HeaderText = "Fecha";
            this.columnaFecha.Name = "columnaFecha";
            this.columnaFecha.ReadOnly = true;
            this.columnaFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaHora
            // 
            this.columnaHora.FillWeight = 50F;
            this.columnaHora.HeaderText = "Hora";
            this.columnaHora.Name = "columnaHora";
            this.columnaHora.ReadOnly = true;
            this.columnaHora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaCombustible
            // 
            this.columnaCombustible.FillWeight = 70F;
            this.columnaCombustible.HeaderText = "Combustible";
            this.columnaCombustible.Name = "columnaCombustible";
            this.columnaCombustible.ReadOnly = true;
            this.columnaCombustible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaMonto
            // 
            this.columnaMonto.FillWeight = 60F;
            this.columnaMonto.HeaderText = "Monto";
            this.columnaMonto.Name = "columnaMonto";
            this.columnaMonto.ReadOnly = true;
            this.columnaMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnaCantCargada
            // 
            this.columnaCantCargada.FillWeight = 70F;
            this.columnaCantCargada.HeaderText = "Cargado";
            this.columnaCantCargada.Name = "columnaCantCargada";
            this.columnaCantCargada.ReadOnly = true;
            this.columnaCantCargada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(640, 402);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 77;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // rBASC_502ag
            // 
            this.rBASC_502ag.AutoSize = true;
            this.rBASC_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBASC_502ag.Location = new System.Drawing.Point(12, 302);
            this.rBASC_502ag.Name = "rBASC_502ag";
            this.rBASC_502ag.Size = new System.Drawing.Size(101, 21);
            this.rBASC_502ag.TabIndex = 78;
            this.rBASC_502ag.Text = "Ascendente";
            this.rBASC_502ag.UseVisualStyleBackColor = true;
            this.rBASC_502ag.CheckedChanged += new System.EventHandler(this.rBASC_502ag_CheckedChanged);
            // 
            // rBDESC_502ag
            // 
            this.rBDESC_502ag.AutoSize = true;
            this.rBDESC_502ag.Checked = true;
            this.rBDESC_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBDESC_502ag.Location = new System.Drawing.Point(12, 325);
            this.rBDESC_502ag.Name = "rBDESC_502ag";
            this.rBDESC_502ag.Size = new System.Drawing.Size(110, 21);
            this.rBDESC_502ag.TabIndex = 79;
            this.rBDESC_502ag.TabStop = true;
            this.rBDESC_502ag.Text = "Descendente";
            this.rBDESC_502ag.UseVisualStyleBackColor = true;
            this.rBDESC_502ag.CheckedChanged += new System.EventHandler(this.rBDESC_502ag_CheckedChanged);
            // 
            // cBOrdenarPor_502ag
            // 
            this.cBOrdenarPor_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBOrdenarPor_502ag.FormattingEnabled = true;
            this.cBOrdenarPor_502ag.Location = new System.Drawing.Point(12, 272);
            this.cBOrdenarPor_502ag.Name = "cBOrdenarPor_502ag";
            this.cBOrdenarPor_502ag.Size = new System.Drawing.Size(155, 24);
            this.cBOrdenarPor_502ag.TabIndex = 80;
            this.cBOrdenarPor_502ag.SelectedIndexChanged += new System.EventHandler(this.cBOrdenarPor_502ag_SelectedIndexChanged);
            // 
            // labelOrdenarPor_502ag
            // 
            this.labelOrdenarPor_502ag.AutoSize = true;
            this.labelOrdenarPor_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelOrdenarPor_502ag.Location = new System.Drawing.Point(12, 252);
            this.labelOrdenarPor_502ag.Name = "labelOrdenarPor_502ag";
            this.labelOrdenarPor_502ag.Size = new System.Drawing.Size(86, 17);
            this.labelOrdenarPor_502ag.TabIndex = 81;
            this.labelOrdenarPor_502ag.Text = "Ordenar por";
            // 
            // cBFecha_502ag
            // 
            this.cBFecha_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBFecha_502ag.FormattingEnabled = true;
            this.cBFecha_502ag.Location = new System.Drawing.Point(12, 369);
            this.cBFecha_502ag.Name = "cBFecha_502ag";
            this.cBFecha_502ag.Size = new System.Drawing.Size(155, 24);
            this.cBFecha_502ag.TabIndex = 82;
            this.cBFecha_502ag.SelectedIndexChanged += new System.EventHandler(this.cBFecha_502ag_SelectedIndexChanged);
            // 
            // labelFechas_502ag
            // 
            this.labelFechas_502ag.AutoSize = true;
            this.labelFechas_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelFechas_502ag.Location = new System.Drawing.Point(9, 349);
            this.labelFechas_502ag.Name = "labelFechas_502ag";
            this.labelFechas_502ag.Size = new System.Drawing.Size(69, 17);
            this.labelFechas_502ag.TabIndex = 83;
            this.labelFechas_502ag.Text = "Filtrar por";
            // 
            // buttonImprimirFactura_502ag
            // 
            this.buttonImprimirFactura_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonImprimirFactura_502ag.FlatAppearance.BorderSize = 0;
            this.buttonImprimirFactura_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirFactura_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonImprimirFactura_502ag.Location = new System.Drawing.Point(12, 402);
            this.buttonImprimirFactura_502ag.Name = "buttonImprimirFactura_502ag";
            this.buttonImprimirFactura_502ag.Size = new System.Drawing.Size(155, 47);
            this.buttonImprimirFactura_502ag.TabIndex = 84;
            this.buttonImprimirFactura_502ag.Text = "Imprimir Factura";
            this.buttonImprimirFactura_502ag.UseVisualStyleBackColor = false;
            this.buttonImprimirFactura_502ag.Click += new System.EventHandler(this.buttonImprimirFactura_502ag_Click);
            // 
            // FormVerFacturas_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonImprimirFactura_502ag);
            this.Controls.Add(this.labelFechas_502ag);
            this.Controls.Add(this.cBFecha_502ag);
            this.Controls.Add(this.labelOrdenarPor_502ag);
            this.Controls.Add(this.cBOrdenarPor_502ag);
            this.Controls.Add(this.rBDESC_502ag);
            this.Controls.Add(this.rBASC_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.dgvFacturas_502ag);
            this.Name = "FormVerFacturas_502ag";
            this.Text = "FormVerFacturas_502ag";
            this.Activated += new System.EventHandler(this.FormVerFacturas_502ag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVerFacturas_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturas_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.RadioButton rBASC_502ag;
        private System.Windows.Forms.RadioButton rBDESC_502ag;
        private System.Windows.Forms.ComboBox cBOrdenarPor_502ag;
        private System.Windows.Forms.Label labelOrdenarPor_502ag;
        private System.Windows.Forms.ComboBox cBFecha_502ag;
        private System.Windows.Forms.Label labelFechas_502ag;
        private System.Windows.Forms.Button buttonImprimirFactura_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCantCargada;
    }
}