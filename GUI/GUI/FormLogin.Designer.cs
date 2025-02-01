namespace GUI
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonIniciarSesion = new System.Windows.Forms.Button();
            this.textBoxNombreUsuario = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.labelNombreUsuario = new System.Windows.Forms.Label();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.buttonCerrarAplicacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonIniciarSesion
            // 
            this.buttonIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonIniciarSesion.Location = new System.Drawing.Point(300, 225);
            this.buttonIniciarSesion.Name = "buttonIniciarSesion";
            this.buttonIniciarSesion.Size = new System.Drawing.Size(125, 50);
            this.buttonIniciarSesion.TabIndex = 0;
            this.buttonIniciarSesion.Text = "Iniciar Sesión";
            this.buttonIniciarSesion.UseVisualStyleBackColor = true;
            this.buttonIniciarSesion.Click += new System.EventHandler(this.buttonIniciarSesion_Click);
            // 
            // textBoxNombreUsuario
            // 
            this.textBoxNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxNombreUsuario.Location = new System.Drawing.Point(250, 110);
            this.textBoxNombreUsuario.Name = "textBoxNombreUsuario";
            this.textBoxNombreUsuario.Size = new System.Drawing.Size(225, 29);
            this.textBoxNombreUsuario.TabIndex = 1;
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxContraseña.Location = new System.Drawing.Point(250, 170);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(225, 29);
            this.textBoxContraseña.TabIndex = 2;
            // 
            // labelNombreUsuario
            // 
            this.labelNombreUsuario.AutoSize = true;
            this.labelNombreUsuario.Location = new System.Drawing.Point(250, 90);
            this.labelNombreUsuario.Name = "labelNombreUsuario";
            this.labelNombreUsuario.Size = new System.Drawing.Size(98, 13);
            this.labelNombreUsuario.TabIndex = 3;
            this.labelNombreUsuario.Text = "Nombre de Usuario";
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(250, 150);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 4;
            this.labelContraseña.Text = "Contraseña";
            // 
            // buttonCerrarAplicacion
            // 
            this.buttonCerrarAplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCerrarAplicacion.Location = new System.Drawing.Point(640, 402);
            this.buttonCerrarAplicacion.Name = "buttonCerrarAplicacion";
            this.buttonCerrarAplicacion.Size = new System.Drawing.Size(132, 47);
            this.buttonCerrarAplicacion.TabIndex = 5;
            this.buttonCerrarAplicacion.Text = "Cerrar Aplicación";
            this.buttonCerrarAplicacion.UseVisualStyleBackColor = true;
            this.buttonCerrarAplicacion.Click += new System.EventHandler(this.buttonCerrarAplicacion_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonCerrarAplicacion);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.labelNombreUsuario);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.textBoxNombreUsuario);
            this.Controls.Add(this.buttonIniciarSesion);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIniciarSesion;
        private System.Windows.Forms.TextBox textBoxNombreUsuario;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Button buttonCerrarAplicacion;
    }
}

