namespace GUI
{
    partial class FormSistemaNoDisponible_502ag
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
            this.labelBackupRestore_502ag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk_502ag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBackupRestore_502ag
            // 
            this.labelBackupRestore_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelBackupRestore_502ag.Location = new System.Drawing.Point(27, 9);
            this.labelBackupRestore_502ag.Name = "labelBackupRestore_502ag";
            this.labelBackupRestore_502ag.Size = new System.Drawing.Size(226, 50);
            this.labelBackupRestore_502ag.TabIndex = 36;
            this.labelBackupRestore_502ag.Text = "El sistema no se encuentra disponible en estos momentos.";
            this.labelBackupRestore_502ag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 35);
            this.label1.TabIndex = 37;
            this.label1.Text = "Contacte al administrador.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOk_502ag
            // 
            this.buttonOk_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonOk_502ag.FlatAppearance.BorderSize = 0;
            this.buttonOk_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonOk_502ag.Location = new System.Drawing.Point(86, 117);
            this.buttonOk_502ag.Name = "buttonOk_502ag";
            this.buttonOk_502ag.Size = new System.Drawing.Size(92, 47);
            this.buttonOk_502ag.TabIndex = 38;
            this.buttonOk_502ag.Text = "OK";
            this.buttonOk_502ag.UseVisualStyleBackColor = false;
            this.buttonOk_502ag.Click += new System.EventHandler(this.buttonOk_502ag_Click);
            // 
            // FormSistemaNoDisponible_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 210);
            this.Controls.Add(this.buttonOk_502ag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBackupRestore_502ag);
            this.Name = "FormSistemaNoDisponible_502ag";
            this.Text = "FormSistemaNoDisponible_502ag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBackupRestore_502ag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk_502ag;
    }
}