namespace GUI
{
    partial class FormTraductor_502ag
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
            this.cBIdiomas_502ag = new System.Windows.Forms.ComboBox();
            this.buttonConfirmar_502ag = new System.Windows.Forms.Button();
            this.labelCambiarIdioma_502ag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBIdiomas_502ag
            // 
            this.cBIdiomas_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBIdiomas_502ag.FormattingEnabled = true;
            this.cBIdiomas_502ag.Location = new System.Drawing.Point(15, 59);
            this.cBIdiomas_502ag.Name = "cBIdiomas_502ag";
            this.cBIdiomas_502ag.Size = new System.Drawing.Size(195, 24);
            this.cBIdiomas_502ag.TabIndex = 0;
            // 
            // buttonConfirmar_502ag
            // 
            this.buttonConfirmar_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonConfirmar_502ag.FlatAppearance.BorderSize = 0;
            this.buttonConfirmar_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmar_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfirmar_502ag.Location = new System.Drawing.Point(46, 100);
            this.buttonConfirmar_502ag.Name = "buttonConfirmar_502ag";
            this.buttonConfirmar_502ag.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonConfirmar_502ag.Size = new System.Drawing.Size(126, 30);
            this.buttonConfirmar_502ag.TabIndex = 5;
            this.buttonConfirmar_502ag.Text = "Confirmar";
            this.buttonConfirmar_502ag.UseVisualStyleBackColor = false;
            this.buttonConfirmar_502ag.Click += new System.EventHandler(this.buttonConfirmar_502ag_Click);
            // 
            // labelCambiarIdioma_502ag
            // 
            this.labelCambiarIdioma_502ag.AutoSize = true;
            this.labelCambiarIdioma_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCambiarIdioma_502ag.Location = new System.Drawing.Point(42, 9);
            this.labelCambiarIdioma_502ag.Name = "labelCambiarIdioma_502ag";
            this.labelCambiarIdioma_502ag.Size = new System.Drawing.Size(141, 24);
            this.labelCambiarIdioma_502ag.TabIndex = 6;
            this.labelCambiarIdioma_502ag.Text = "Cambiar Idioma";
            // 
            // FormTraductor_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 154);
            this.Controls.Add(this.labelCambiarIdioma_502ag);
            this.Controls.Add(this.buttonConfirmar_502ag);
            this.Controls.Add(this.cBIdiomas_502ag);
            this.Name = "FormTraductor_502ag";
            this.Text = "FormTraductor_502ag";
            this.Activated += new System.EventHandler(this.FormTraductor_502ag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTraductor_502ag_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBIdiomas_502ag;
        private System.Windows.Forms.Button buttonConfirmar_502ag;
        private System.Windows.Forms.Label labelCambiarIdioma_502ag;
    }
}