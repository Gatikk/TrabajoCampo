namespace GUI
{
    partial class FormVerFacturasTaller_502ag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerFacturasTaller_502ag));
            this.buttonImprimirFactura_502ag = new System.Windows.Forms.Button();
            this.labelFechas_502ag = new System.Windows.Forms.Label();
            this.cBFecha_502ag = new System.Windows.Forms.ComboBox();
            this.labelOrdenarPor_502ag = new System.Windows.Forms.Label();
            this.cBOrdenarPor_502ag = new System.Windows.Forms.ComboBox();
            this.rBDESC_502ag = new System.Windows.Forms.RadioButton();
            this.rBASC_502ag = new System.Windows.Forms.RadioButton();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.dgvFacturasTaller_502ag = new System.Windows.Forms.DataGridView();
            this.columnaCodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAyuda2_502ag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasTaller_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImprimirFactura_502ag
            // 
            this.buttonImprimirFactura_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonImprimirFactura_502ag.FlatAppearance.BorderSize = 0;
            this.buttonImprimirFactura_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirFactura_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonImprimirFactura_502ag.Location = new System.Drawing.Point(14, 402);
            this.buttonImprimirFactura_502ag.Name = "buttonImprimirFactura_502ag";
            this.buttonImprimirFactura_502ag.Size = new System.Drawing.Size(155, 47);
            this.buttonImprimirFactura_502ag.TabIndex = 93;
            this.buttonImprimirFactura_502ag.Text = "Imprimir Factura";
            this.buttonImprimirFactura_502ag.UseVisualStyleBackColor = false;
            this.buttonImprimirFactura_502ag.Click += new System.EventHandler(this.buttonImprimirFactura_502ag_Click);
            // 
            // labelFechas_502ag
            // 
            this.labelFechas_502ag.AutoSize = true;
            this.labelFechas_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelFechas_502ag.Location = new System.Drawing.Point(11, 349);
            this.labelFechas_502ag.Name = "labelFechas_502ag";
            this.labelFechas_502ag.Size = new System.Drawing.Size(69, 17);
            this.labelFechas_502ag.TabIndex = 92;
            this.labelFechas_502ag.Text = "Filtrar por";
            // 
            // cBFecha_502ag
            // 
            this.cBFecha_502ag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBFecha_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBFecha_502ag.FormattingEnabled = true;
            this.cBFecha_502ag.Location = new System.Drawing.Point(14, 369);
            this.cBFecha_502ag.Name = "cBFecha_502ag";
            this.cBFecha_502ag.Size = new System.Drawing.Size(155, 24);
            this.cBFecha_502ag.TabIndex = 91;
            this.cBFecha_502ag.SelectedIndexChanged += new System.EventHandler(this.cBFecha_502ag_SelectedIndexChanged);
            // 
            // labelOrdenarPor_502ag
            // 
            this.labelOrdenarPor_502ag.AutoSize = true;
            this.labelOrdenarPor_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelOrdenarPor_502ag.Location = new System.Drawing.Point(14, 252);
            this.labelOrdenarPor_502ag.Name = "labelOrdenarPor_502ag";
            this.labelOrdenarPor_502ag.Size = new System.Drawing.Size(86, 17);
            this.labelOrdenarPor_502ag.TabIndex = 90;
            this.labelOrdenarPor_502ag.Text = "Ordenar por";
            // 
            // cBOrdenarPor_502ag
            // 
            this.cBOrdenarPor_502ag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBOrdenarPor_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBOrdenarPor_502ag.FormattingEnabled = true;
            this.cBOrdenarPor_502ag.Location = new System.Drawing.Point(14, 272);
            this.cBOrdenarPor_502ag.Name = "cBOrdenarPor_502ag";
            this.cBOrdenarPor_502ag.Size = new System.Drawing.Size(155, 24);
            this.cBOrdenarPor_502ag.TabIndex = 89;
            this.cBOrdenarPor_502ag.SelectedIndexChanged += new System.EventHandler(this.cBOrdenarPor_502ag_SelectedIndexChanged);
            // 
            // rBDESC_502ag
            // 
            this.rBDESC_502ag.AutoSize = true;
            this.rBDESC_502ag.Checked = true;
            this.rBDESC_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBDESC_502ag.Location = new System.Drawing.Point(14, 325);
            this.rBDESC_502ag.Name = "rBDESC_502ag";
            this.rBDESC_502ag.Size = new System.Drawing.Size(110, 21);
            this.rBDESC_502ag.TabIndex = 88;
            this.rBDESC_502ag.TabStop = true;
            this.rBDESC_502ag.Text = "Descendente";
            this.rBDESC_502ag.UseVisualStyleBackColor = true;
            this.rBDESC_502ag.CheckedChanged += new System.EventHandler(this.rBDESC_502ag_CheckedChanged);
            // 
            // rBASC_502ag
            // 
            this.rBASC_502ag.AutoSize = true;
            this.rBASC_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBASC_502ag.Location = new System.Drawing.Point(14, 302);
            this.rBASC_502ag.Name = "rBASC_502ag";
            this.rBASC_502ag.Size = new System.Drawing.Size(101, 21);
            this.rBASC_502ag.TabIndex = 87;
            this.rBASC_502ag.Text = "Ascendente";
            this.rBASC_502ag.UseVisualStyleBackColor = true;
            this.rBASC_502ag.CheckedChanged += new System.EventHandler(this.rBASC_502ag_CheckedChanged);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(642, 402);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 86;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // dgvFacturasTaller_502ag
            // 
            this.dgvFacturasTaller_502ag.AllowUserToAddRows = false;
            this.dgvFacturasTaller_502ag.AllowUserToDeleteRows = false;
            this.dgvFacturasTaller_502ag.AllowUserToResizeColumns = false;
            this.dgvFacturasTaller_502ag.AllowUserToResizeRows = false;
            this.dgvFacturasTaller_502ag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturasTaller_502ag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasTaller_502ag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaCodigoFactura,
            this.columnaDNI,
            this.columnaNombre,
            this.columnaMetodoPago,
            this.columnaFecha,
            this.columnaHora,
            this.columnaMonto});
            this.dgvFacturasTaller_502ag.Location = new System.Drawing.Point(14, 12);
            this.dgvFacturasTaller_502ag.MultiSelect = false;
            this.dgvFacturasTaller_502ag.Name = "dgvFacturasTaller_502ag";
            this.dgvFacturasTaller_502ag.ReadOnly = true;
            this.dgvFacturasTaller_502ag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasTaller_502ag.Size = new System.Drawing.Size(760, 237);
            this.dgvFacturasTaller_502ag.TabIndex = 85;
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
            // columnaMonto
            // 
            this.columnaMonto.FillWeight = 60F;
            this.columnaMonto.HeaderText = "Monto";
            this.columnaMonto.Name = "columnaMonto";
            this.columnaMonto.ReadOnly = true;
            this.columnaMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonAyuda2_502ag
            // 
            this.buttonAyuda2_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAyuda2_502ag.FlatAppearance.BorderSize = 0;
            this.buttonAyuda2_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAyuda2_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAyuda2_502ag.Image = ((System.Drawing.Image)(resources.GetObject("buttonAyuda2_502ag.Image")));
            this.buttonAyuda2_502ag.Location = new System.Drawing.Point(729, 348);
            this.buttonAyuda2_502ag.Name = "buttonAyuda2_502ag";
            this.buttonAyuda2_502ag.Size = new System.Drawing.Size(45, 45);
            this.buttonAyuda2_502ag.TabIndex = 94;
            this.buttonAyuda2_502ag.UseVisualStyleBackColor = false;
            this.buttonAyuda2_502ag.Click += new System.EventHandler(this.buttonAyuda2_502ag_Click);
            // 
            // FormVerFacturasTaller_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonAyuda2_502ag);
            this.Controls.Add(this.buttonImprimirFactura_502ag);
            this.Controls.Add(this.labelFechas_502ag);
            this.Controls.Add(this.cBFecha_502ag);
            this.Controls.Add(this.labelOrdenarPor_502ag);
            this.Controls.Add(this.cBOrdenarPor_502ag);
            this.Controls.Add(this.rBDESC_502ag);
            this.Controls.Add(this.rBASC_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.dgvFacturasTaller_502ag);
            this.Name = "FormVerFacturasTaller_502ag";
            this.Text = "FormVerFacturasTaller_502ag";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVerFacturasTaller_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasTaller_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimirFactura_502ag;
        private System.Windows.Forms.Label labelFechas_502ag;
        private System.Windows.Forms.ComboBox cBFecha_502ag;
        private System.Windows.Forms.Label labelOrdenarPor_502ag;
        private System.Windows.Forms.ComboBox cBOrdenarPor_502ag;
        private System.Windows.Forms.RadioButton rBDESC_502ag;
        private System.Windows.Forms.RadioButton rBASC_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.DataGridView dgvFacturasTaller_502ag;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaMonto;
        private System.Windows.Forms.Button buttonAyuda2_502ag;
    }
}