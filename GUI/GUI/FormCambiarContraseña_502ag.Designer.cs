namespace GUI
{
    partial class FormCambiarContraseña_502ag
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
            this.labelConfirmarContraseña = new System.Windows.Forms.Label();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.textBoxContraseñaConfirmar = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.buttonCambiarContraseña = new System.Windows.Forms.Button();
            this.buttonVolverAlMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelConfirmarContraseña
            // 
            this.labelConfirmarContraseña.AutoSize = true;
            this.labelConfirmarContraseña.Location = new System.Drawing.Point(273, 179);
            this.labelConfirmarContraseña.Name = "labelConfirmarContraseña";
            this.labelConfirmarContraseña.Size = new System.Drawing.Size(121, 13);
            this.labelConfirmarContraseña.TabIndex = 8;
            this.labelConfirmarContraseña.Text = "Confirmar Contraseña_T";
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(273, 119);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(74, 13);
            this.labelContraseña.TabIndex = 7;
            this.labelContraseña.Text = "Contraseña_T";
            // 
            // textBoxContraseñaConfirmar
            // 
            this.textBoxContraseñaConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxContraseñaConfirmar.Location = new System.Drawing.Point(273, 199);
            this.textBoxContraseñaConfirmar.Name = "textBoxContraseñaConfirmar";
            this.textBoxContraseñaConfirmar.Size = new System.Drawing.Size(225, 29);
            this.textBoxContraseñaConfirmar.TabIndex = 6;
            this.textBoxContraseñaConfirmar.TextChanged += new System.EventHandler(this.textBoxContraseñaConfirmar_TextChanged);
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxContraseña.Location = new System.Drawing.Point(273, 139);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(225, 29);
            this.textBoxContraseña.TabIndex = 5;
            this.textBoxContraseña.TextChanged += new System.EventHandler(this.textBoxContraseña_TextChanged);
            // 
            // buttonCambiarContraseña
            // 
            this.buttonCambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCambiarContraseña.Location = new System.Drawing.Point(273, 234);
            this.buttonCambiarContraseña.Name = "buttonCambiarContraseña";
            this.buttonCambiarContraseña.Size = new System.Drawing.Size(132, 47);
            this.buttonCambiarContraseña.TabIndex = 24;
            this.buttonCambiarContraseña.Text = "Cambiar Contraseña";
            this.buttonCambiarContraseña.UseVisualStyleBackColor = true;
            this.buttonCambiarContraseña.Click += new System.EventHandler(this.buttonCambiarContraseña_Click);
            // 
            // buttonVolverAlMenu
            // 
            this.buttonVolverAlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu.Location = new System.Drawing.Point(640, 402);
            this.buttonVolverAlMenu.Name = "buttonVolverAlMenu";
            this.buttonVolverAlMenu.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu.TabIndex = 25;
            this.buttonVolverAlMenu.Text = "Volver al Menú";
            this.buttonVolverAlMenu.UseVisualStyleBackColor = true;
            this.buttonVolverAlMenu.Click += new System.EventHandler(this.buttonVolverAlMenu_Click);
            // 
            // FormCambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonVolverAlMenu);
            this.Controls.Add(this.buttonCambiarContraseña);
            this.Controls.Add(this.labelConfirmarContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.textBoxContraseñaConfirmar);
            this.Controls.Add(this.textBoxContraseña);
            this.Name = "FormCambiarContraseña";
            this.Text = "FormCambiarContraseña";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCambiarContraseña_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConfirmarContraseña;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.TextBox textBoxContraseñaConfirmar;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Button buttonCambiarContraseña;
        private System.Windows.Forms.Button buttonVolverAlMenu;
    }
}