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
            this.cBLenguajes = new System.Windows.Forms.ComboBox();
            this.buttonVolverAlMenu = new System.Windows.Forms.Button();
            this.buttonAceptarCambioIdioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cBLenguajes
            // 
            this.cBLenguajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cBLenguajes.FormattingEnabled = true;
            this.cBLenguajes.Location = new System.Drawing.Point(244, 167);
            this.cBLenguajes.Name = "cBLenguajes";
            this.cBLenguajes.Size = new System.Drawing.Size(202, 24);
            this.cBLenguajes.TabIndex = 0;
            this.cBLenguajes.SelectedIndexChanged += new System.EventHandler(this.cBLenguajes_SelectedIndexChanged);
            // 
            // buttonVolverAlMenu
            // 
            this.buttonVolverAlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu.Location = new System.Drawing.Point(640, 402);
            this.buttonVolverAlMenu.Name = "buttonVolverAlMenu";
            this.buttonVolverAlMenu.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu.TabIndex = 3;
            this.buttonVolverAlMenu.Text = "Volver al Menú";
            this.buttonVolverAlMenu.UseVisualStyleBackColor = true;
            this.buttonVolverAlMenu.Click += new System.EventHandler(this.buttonVolverAlMenu_Click);
            // 
            // buttonAceptarCambioIdioma
            // 
            this.buttonAceptarCambioIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAceptarCambioIdioma.Location = new System.Drawing.Point(280, 197);
            this.buttonAceptarCambioIdioma.Name = "buttonAceptarCambioIdioma";
            this.buttonAceptarCambioIdioma.Size = new System.Drawing.Size(132, 47);
            this.buttonAceptarCambioIdioma.TabIndex = 4;
            this.buttonAceptarCambioIdioma.Text = "Aceptar";
            this.buttonAceptarCambioIdioma.UseVisualStyleBackColor = true;
            this.buttonAceptarCambioIdioma.Click += new System.EventHandler(this.buttonAceptarCambioIdioma_Click);
            // 
            // FormTraductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonAceptarCambioIdioma);
            this.Controls.Add(this.buttonVolverAlMenu);
            this.Controls.Add(this.cBLenguajes);
            this.Name = "FormTraductor";
            this.Text = "FormTraductor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTraductor_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBLenguajes;
        private System.Windows.Forms.Button buttonVolverAlMenu;
        private System.Windows.Forms.Button buttonAceptarCambioIdioma;
    }
}