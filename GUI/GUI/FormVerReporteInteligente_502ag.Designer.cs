namespace GUI
{
    partial class FormVerReporteInteligente_502ag
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFacturasCombustible_502ag = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rBFacturacionMensualPorCombustible_502ag = new System.Windows.Forms.RadioButton();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.rBGanaciaPorCombustible_502ag = new System.Windows.Forms.RadioButton();
            this.buttonImprimirReporte_502ag = new System.Windows.Forms.Button();
            this.rBCargasPorHora_502ag = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartFacturasCombustible_502ag)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFacturasCombustible_502ag
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFacturasCombustible_502ag.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFacturasCombustible_502ag.Legends.Add(legend1);
            this.chartFacturasCombustible_502ag.Location = new System.Drawing.Point(12, 12);
            this.chartFacturasCombustible_502ag.Name = "chartFacturasCombustible_502ag";
            this.chartFacturasCombustible_502ag.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFacturasCombustible_502ag.Series.Add(series1);
            this.chartFacturasCombustible_502ag.Size = new System.Drawing.Size(526, 300);
            this.chartFacturasCombustible_502ag.TabIndex = 0;
            // 
            // rBFacturacionMensualPorCombustible_502ag
            // 
            this.rBFacturacionMensualPorCombustible_502ag.AutoSize = true;
            this.rBFacturacionMensualPorCombustible_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBFacturacionMensualPorCombustible_502ag.Location = new System.Drawing.Point(12, 350);
            this.rBFacturacionMensualPorCombustible_502ag.Name = "rBFacturacionMensualPorCombustible_502ag";
            this.rBFacturacionMensualPorCombustible_502ag.Size = new System.Drawing.Size(224, 21);
            this.rBFacturacionMensualPorCombustible_502ag.TabIndex = 1;
            this.rBFacturacionMensualPorCombustible_502ag.TabStop = true;
            this.rBFacturacionMensualPorCombustible_502ag.Text = "Facturación Mensual por Carga";
            this.rBFacturacionMensualPorCombustible_502ag.UseVisualStyleBackColor = true;
            this.rBFacturacionMensualPorCombustible_502ag.CheckedChanged += new System.EventHandler(this.rBFacturacionMensualPorCombustible_502ag_CheckedChanged);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(406, 402);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 13;
            this.buttonVolverAlMenu_502ag.Text = "Volver al menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // rBGanaciaPorCombustible_502ag
            // 
            this.rBGanaciaPorCombustible_502ag.AutoSize = true;
            this.rBGanaciaPorCombustible_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBGanaciaPorCombustible_502ag.Location = new System.Drawing.Point(12, 377);
            this.rBGanaciaPorCombustible_502ag.Name = "rBGanaciaPorCombustible_502ag";
            this.rBGanaciaPorCombustible_502ag.Size = new System.Drawing.Size(193, 21);
            this.rBGanaciaPorCombustible_502ag.TabIndex = 14;
            this.rBGanaciaPorCombustible_502ag.TabStop = true;
            this.rBGanaciaPorCombustible_502ag.Text = "Ganancia por Combustible";
            this.rBGanaciaPorCombustible_502ag.UseVisualStyleBackColor = true;
            this.rBGanaciaPorCombustible_502ag.CheckedChanged += new System.EventHandler(this.rBGanaciaPorCombustible_502ag_CheckedChanged);
            // 
            // buttonImprimirReporte_502ag
            // 
            this.buttonImprimirReporte_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonImprimirReporte_502ag.FlatAppearance.BorderSize = 0;
            this.buttonImprimirReporte_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirReporte_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonImprimirReporte_502ag.Location = new System.Drawing.Point(268, 402);
            this.buttonImprimirReporte_502ag.Name = "buttonImprimirReporte_502ag";
            this.buttonImprimirReporte_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonImprimirReporte_502ag.TabIndex = 15;
            this.buttonImprimirReporte_502ag.Text = "Imprimir Reporte";
            this.buttonImprimirReporte_502ag.UseVisualStyleBackColor = false;
            this.buttonImprimirReporte_502ag.Click += new System.EventHandler(this.buttonImprimirReporte_502ag_Click);
            // 
            // rBCargasPorHora_502ag
            // 
            this.rBCargasPorHora_502ag.AutoSize = true;
            this.rBCargasPorHora_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBCargasPorHora_502ag.Location = new System.Drawing.Point(12, 404);
            this.rBCargasPorHora_502ag.Name = "rBCargasPorHora_502ag";
            this.rBCargasPorHora_502ag.Size = new System.Drawing.Size(131, 21);
            this.rBCargasPorHora_502ag.TabIndex = 16;
            this.rBCargasPorHora_502ag.TabStop = true;
            this.rBCargasPorHora_502ag.Text = "Cargas por Hora";
            this.rBCargasPorHora_502ag.UseVisualStyleBackColor = true;
            this.rBCargasPorHora_502ag.CheckedChanged += new System.EventHandler(this.rBCargasPorHora_502ag_CheckedChanged);
            // 
            // FormVerReporteInteligente_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 461);
            this.Controls.Add(this.rBCargasPorHora_502ag);
            this.Controls.Add(this.buttonImprimirReporte_502ag);
            this.Controls.Add(this.rBGanaciaPorCombustible_502ag);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.rBFacturacionMensualPorCombustible_502ag);
            this.Controls.Add(this.chartFacturasCombustible_502ag);
            this.Name = "FormVerReporteInteligente_502ag";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVerReporteInteligente_502ag_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chartFacturasCombustible_502ag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFacturasCombustible_502ag;
        private System.Windows.Forms.RadioButton rBFacturacionMensualPorCombustible_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.RadioButton rBGanaciaPorCombustible_502ag;
        private System.Windows.Forms.Button buttonImprimirReporte_502ag;
        private System.Windows.Forms.RadioButton rBCargasPorHora_502ag;
    }
}