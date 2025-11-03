namespace GUI
{
    partial class FormDigitoVerificador_502ag
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
            this.buttonSalir_502ag = new System.Windows.Forms.Button();
            this.buttonRealizarRestore_502ag = new System.Windows.Forms.Button();
            this.buttonRecalcularDigito_502ag = new System.Windows.Forms.Button();
            this.labelInconsistencia_502ag = new System.Windows.Forms.Label();
            this.buttonVerInconsistencias_502ag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSalir_502ag
            // 
            this.buttonSalir_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSalir_502ag.FlatAppearance.BorderSize = 0;
            this.buttonSalir_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalir_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSalir_502ag.Location = new System.Drawing.Point(78, 199);
            this.buttonSalir_502ag.Name = "buttonSalir_502ag";
            this.buttonSalir_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonSalir_502ag.TabIndex = 34;
            this.buttonSalir_502ag.Text = "Salir";
            this.buttonSalir_502ag.UseVisualStyleBackColor = false;
            this.buttonSalir_502ag.Click += new System.EventHandler(this.buttonSalir_502ag_Click);
            // 
            // buttonRealizarRestore_502ag
            // 
            this.buttonRealizarRestore_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRealizarRestore_502ag.FlatAppearance.BorderSize = 0;
            this.buttonRealizarRestore_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRealizarRestore_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonRealizarRestore_502ag.Location = new System.Drawing.Point(78, 93);
            this.buttonRealizarRestore_502ag.Name = "buttonRealizarRestore_502ag";
            this.buttonRealizarRestore_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonRealizarRestore_502ag.TabIndex = 33;
            this.buttonRealizarRestore_502ag.Text = "Realizar Restore";
            this.buttonRealizarRestore_502ag.UseVisualStyleBackColor = false;
            this.buttonRealizarRestore_502ag.Click += new System.EventHandler(this.buttonRealizarRestore_502ag_Click);
            // 
            // buttonRecalcularDigito_502ag
            // 
            this.buttonRecalcularDigito_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRecalcularDigito_502ag.FlatAppearance.BorderSize = 0;
            this.buttonRecalcularDigito_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecalcularDigito_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonRecalcularDigito_502ag.Location = new System.Drawing.Point(78, 40);
            this.buttonRecalcularDigito_502ag.Name = "buttonRecalcularDigito_502ag";
            this.buttonRecalcularDigito_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonRecalcularDigito_502ag.TabIndex = 32;
            this.buttonRecalcularDigito_502ag.Text = "Recalcular Dígito";
            this.buttonRecalcularDigito_502ag.UseVisualStyleBackColor = false;
            this.buttonRecalcularDigito_502ag.Click += new System.EventHandler(this.buttonRecalcularDigito_502ag_Click);
            // 
            // labelInconsistencia_502ag
            // 
            this.labelInconsistencia_502ag.AutoSize = true;
            this.labelInconsistencia_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelInconsistencia_502ag.Location = new System.Drawing.Point(12, 9);
            this.labelInconsistencia_502ag.Name = "labelInconsistencia_502ag";
            this.labelInconsistencia_502ag.Size = new System.Drawing.Size(292, 18);
            this.labelInconsistencia_502ag.TabIndex = 35;
            this.labelInconsistencia_502ag.Text = "INCONSISTENCIA PRESENTE EN LA BD.";
            // 
            // buttonVerInconsistencias_502ag
            // 
            this.buttonVerInconsistencias_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVerInconsistencias_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVerInconsistencias_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerInconsistencias_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVerInconsistencias_502ag.Location = new System.Drawing.Point(78, 146);
            this.buttonVerInconsistencias_502ag.Name = "buttonVerInconsistencias_502ag";
            this.buttonVerInconsistencias_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVerInconsistencias_502ag.TabIndex = 36;
            this.buttonVerInconsistencias_502ag.Text = "Ver Inconsitencias";
            this.buttonVerInconsistencias_502ag.UseVisualStyleBackColor = false;
            this.buttonVerInconsistencias_502ag.Click += new System.EventHandler(this.buttonVerInconsistencias_502ag_Click);
            // 
            // FormDigitoVerificador_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 257);
            this.Controls.Add(this.buttonVerInconsistencias_502ag);
            this.Controls.Add(this.labelInconsistencia_502ag);
            this.Controls.Add(this.buttonSalir_502ag);
            this.Controls.Add(this.buttonRealizarRestore_502ag);
            this.Controls.Add(this.buttonRecalcularDigito_502ag);
            this.Name = "FormDigitoVerificador_502ag";
            this.Text = "FormDigitoVerificador_502ag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalir_502ag;
        private System.Windows.Forms.Button buttonRealizarRestore_502ag;
        private System.Windows.Forms.Button buttonRecalcularDigito_502ag;
        private System.Windows.Forms.Label labelInconsistencia_502ag;
        private System.Windows.Forms.Button buttonVerInconsistencias_502ag;
    }
}