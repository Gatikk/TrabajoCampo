﻿namespace GUI
{
    partial class FormBackupRestore_502ag
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
            this.buttonRealizarRestore_502ag = new System.Windows.Forms.Button();
            this.buttonRealizarBackup_502ag = new System.Windows.Forms.Button();
            this.buttonVolverAlMenu_502ag = new System.Windows.Forms.Button();
            this.labelBackupRestore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRealizarRestore_502ag
            // 
            this.buttonRealizarRestore_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRealizarRestore_502ag.FlatAppearance.BorderSize = 0;
            this.buttonRealizarRestore_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRealizarRestore_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonRealizarRestore_502ag.Location = new System.Drawing.Point(94, 108);
            this.buttonRealizarRestore_502ag.Name = "buttonRealizarRestore_502ag";
            this.buttonRealizarRestore_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonRealizarRestore_502ag.TabIndex = 30;
            this.buttonRealizarRestore_502ag.Text = "Realizar Restore";
            this.buttonRealizarRestore_502ag.UseVisualStyleBackColor = false;
            this.buttonRealizarRestore_502ag.Click += new System.EventHandler(this.buttonRealizarRestore_502ag_Click);
            // 
            // buttonRealizarBackup_502ag
            // 
            this.buttonRealizarBackup_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRealizarBackup_502ag.FlatAppearance.BorderSize = 0;
            this.buttonRealizarBackup_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRealizarBackup_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonRealizarBackup_502ag.Location = new System.Drawing.Point(94, 45);
            this.buttonRealizarBackup_502ag.Name = "buttonRealizarBackup_502ag";
            this.buttonRealizarBackup_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonRealizarBackup_502ag.TabIndex = 29;
            this.buttonRealizarBackup_502ag.Text = "Realizar Backup";
            this.buttonRealizarBackup_502ag.UseVisualStyleBackColor = false;
            this.buttonRealizarBackup_502ag.Click += new System.EventHandler(this.buttonRealizarBackup_502ag_Click);
            // 
            // buttonVolverAlMenu_502ag
            // 
            this.buttonVolverAlMenu_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVolverAlMenu_502ag.FlatAppearance.BorderSize = 0;
            this.buttonVolverAlMenu_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolverAlMenu_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVolverAlMenu_502ag.Location = new System.Drawing.Point(94, 170);
            this.buttonVolverAlMenu_502ag.Name = "buttonVolverAlMenu_502ag";
            this.buttonVolverAlMenu_502ag.Size = new System.Drawing.Size(132, 47);
            this.buttonVolverAlMenu_502ag.TabIndex = 31;
            this.buttonVolverAlMenu_502ag.Text = "Volver al Menú";
            this.buttonVolverAlMenu_502ag.UseVisualStyleBackColor = false;
            this.buttonVolverAlMenu_502ag.Click += new System.EventHandler(this.buttonVolverAlMenu_502ag_Click);
            // 
            // labelBackupRestore
            // 
            this.labelBackupRestore.AutoSize = true;
            this.labelBackupRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelBackupRestore.Location = new System.Drawing.Point(80, 9);
            this.labelBackupRestore.Name = "labelBackupRestore";
            this.labelBackupRestore.Size = new System.Drawing.Size(157, 24);
            this.labelBackupRestore.TabIndex = 32;
            this.labelBackupRestore.Text = "Backup y Restore";
            // 
            // FormBackupRestore_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 241);
            this.Controls.Add(this.labelBackupRestore);
            this.Controls.Add(this.buttonVolverAlMenu_502ag);
            this.Controls.Add(this.buttonRealizarRestore_502ag);
            this.Controls.Add(this.buttonRealizarBackup_502ag);
            this.Name = "FormBackupRestore_502ag";
            this.Text = "FormBackupRestore_502ag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRealizarRestore_502ag;
        private System.Windows.Forms.Button buttonRealizarBackup_502ag;
        private System.Windows.Forms.Button buttonVolverAlMenu_502ag;
        private System.Windows.Forms.Label labelBackupRestore;
    }
}