using System;

namespace GUI
{
    partial class FormMenu_502ag
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
            this.buttonCerrarSesion = new System.Windows.Forms.Button();
            this.buttonCerrarAplicacion = new System.Windows.Forms.Button();
            this.labelBienvenida = new System.Windows.Forms.Label();
            this.buttonABM = new System.Windows.Forms.Button();
            this.buttonCambiarContraseña = new System.Windows.Forms.Button();
            this.buttonBitacora = new System.Windows.Forms.Button();
            this.buttonCambiarIdioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCerrarSesion
            // 
            this.buttonCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCerrarSesion.Location = new System.Drawing.Point(640, 349);
            this.buttonCerrarSesion.Name = "buttonCerrarSesion";
            this.buttonCerrarSesion.Size = new System.Drawing.Size(132, 47);
            this.buttonCerrarSesion.TabIndex = 1;
            this.buttonCerrarSesion.Text = "Cerrar Sesión";
            this.buttonCerrarSesion.UseVisualStyleBackColor = true;
            this.buttonCerrarSesion.Click += new System.EventHandler(this.buttonCerrarSesion_Click);
            // 
            // buttonCerrarAplicacion
            // 
            this.buttonCerrarAplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCerrarAplicacion.Location = new System.Drawing.Point(640, 402);
            this.buttonCerrarAplicacion.Name = "buttonCerrarAplicacion";
            this.buttonCerrarAplicacion.Size = new System.Drawing.Size(132, 47);
            this.buttonCerrarAplicacion.TabIndex = 2;
            this.buttonCerrarAplicacion.Text = "Cerrar Aplicación";
            this.buttonCerrarAplicacion.UseVisualStyleBackColor = true;
            this.buttonCerrarAplicacion.Click += new System.EventHandler(this.buttonCerrarAplicacion_Click);
            // 
            // labelBienvenida
            // 
            this.labelBienvenida.AutoSize = true;
            this.labelBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelBienvenida.Location = new System.Drawing.Point(12, 9);
            this.labelBienvenida.Name = "labelBienvenida";
            this.labelBienvenida.Size = new System.Drawing.Size(129, 24);
            this.labelBienvenida.TabIndex = 3;
            this.labelBienvenida.Text = "Bienvenido @";
            // 
            // buttonABM
            // 
            this.buttonABM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonABM.Location = new System.Drawing.Point(316, 128);
            this.buttonABM.Name = "buttonABM";
            this.buttonABM.Size = new System.Drawing.Size(132, 47);
            this.buttonABM.TabIndex = 4;
            this.buttonABM.Text = "ABM";
            this.buttonABM.UseVisualStyleBackColor = true;
            this.buttonABM.Click += new System.EventHandler(this.buttonABM_Click);
            // 
            // buttonCambiarContraseña
            // 
            this.buttonCambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCambiarContraseña.Location = new System.Drawing.Point(316, 181);
            this.buttonCambiarContraseña.Name = "buttonCambiarContraseña";
            this.buttonCambiarContraseña.Size = new System.Drawing.Size(132, 47);
            this.buttonCambiarContraseña.TabIndex = 5;
            this.buttonCambiarContraseña.Text = "Cambiar Contraseña";
            this.buttonCambiarContraseña.UseVisualStyleBackColor = true;
            this.buttonCambiarContraseña.Click += new System.EventHandler(this.buttonCambiarContraseña_Click);
            // 
            // buttonBitacora
            // 
            this.buttonBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBitacora.Location = new System.Drawing.Point(316, 234);
            this.buttonBitacora.Name = "buttonBitacora";
            this.buttonBitacora.Size = new System.Drawing.Size(132, 47);
            this.buttonBitacora.TabIndex = 6;
            this.buttonBitacora.Text = "Bitácora";
            this.buttonBitacora.UseVisualStyleBackColor = true;
            this.buttonBitacora.Click += new System.EventHandler(this.buttonBitacora_Click);
            // 
            // buttonCambiarIdioma
            // 
            this.buttonCambiarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCambiarIdioma.Location = new System.Drawing.Point(316, 287);
            this.buttonCambiarIdioma.Name = "buttonCambiarIdioma";
            this.buttonCambiarIdioma.Size = new System.Drawing.Size(132, 47);
            this.buttonCambiarIdioma.TabIndex = 7;
            this.buttonCambiarIdioma.Text = "Cambiar Idioma";
            this.buttonCambiarIdioma.UseVisualStyleBackColor = true;
            this.buttonCambiarIdioma.Click += new System.EventHandler(this.buttonCambiarIdioma_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonCambiarIdioma);
            this.Controls.Add(this.buttonBitacora);
            this.Controls.Add(this.buttonCambiarContraseña);
            this.Controls.Add(this.buttonABM);
            this.Controls.Add(this.labelBienvenida);
            this.Controls.Add(this.buttonCerrarAplicacion);
            this.Controls.Add(this.buttonCerrarSesion);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button buttonCerrarSesion;
        private System.Windows.Forms.Button buttonCerrarAplicacion;
        private System.Windows.Forms.Label labelBienvenida;
        private System.Windows.Forms.Button buttonABM;
        private System.Windows.Forms.Button buttonCambiarContraseña;
        private System.Windows.Forms.Button buttonBitacora;
        private System.Windows.Forms.Button buttonCambiarIdioma;
    }
}