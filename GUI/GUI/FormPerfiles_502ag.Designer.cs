namespace GUI
{
    partial class FormPerfiles_502ag
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
            this.tVFamilias_502ag = new System.Windows.Forms.TreeView();
            this.cLBPermisos_502ag = new System.Windows.Forms.CheckedListBox();
            this.tBNombre_502ag = new System.Windows.Forms.TextBox();
            this.rBFamilia_502ag = new System.Windows.Forms.RadioButton();
            this.rBPerfil_502ag = new System.Windows.Forms.RadioButton();
            this.buttonCrear_502ag = new System.Windows.Forms.Button();
            this.cBFamilia_502ag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tVFamilias_502ag
            // 
            this.tVFamilias_502ag.Location = new System.Drawing.Point(321, 54);
            this.tVFamilias_502ag.Name = "tVFamilias_502ag";
            this.tVFamilias_502ag.Size = new System.Drawing.Size(169, 289);
            this.tVFamilias_502ag.TabIndex = 0;
            // 
            // cLBPermisos_502ag
            // 
            this.cLBPermisos_502ag.FormattingEnabled = true;
            this.cLBPermisos_502ag.Location = new System.Drawing.Point(146, 54);
            this.cLBPermisos_502ag.Name = "cLBPermisos_502ag";
            this.cLBPermisos_502ag.Size = new System.Drawing.Size(169, 289);
            this.cLBPermisos_502ag.TabIndex = 1;
            // 
            // tBNombre_502ag
            // 
            this.tBNombre_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBNombre_502ag.Location = new System.Drawing.Point(7, 389);
            this.tBNombre_502ag.Name = "tBNombre_502ag";
            this.tBNombre_502ag.Size = new System.Drawing.Size(138, 23);
            this.tBNombre_502ag.TabIndex = 2;
            // 
            // rBFamilia_502ag
            // 
            this.rBFamilia_502ag.AutoSize = true;
            this.rBFamilia_502ag.Checked = true;
            this.rBFamilia_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBFamilia_502ag.Location = new System.Drawing.Point(7, 335);
            this.rBFamilia_502ag.Name = "rBFamilia_502ag";
            this.rBFamilia_502ag.Size = new System.Drawing.Size(70, 21);
            this.rBFamilia_502ag.TabIndex = 3;
            this.rBFamilia_502ag.TabStop = true;
            this.rBFamilia_502ag.Text = "Familia";
            this.rBFamilia_502ag.UseVisualStyleBackColor = true;
            // 
            // rBPerfil_502ag
            // 
            this.rBPerfil_502ag.AutoSize = true;
            this.rBPerfil_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rBPerfil_502ag.Location = new System.Drawing.Point(7, 362);
            this.rBPerfil_502ag.Name = "rBPerfil_502ag";
            this.rBPerfil_502ag.Size = new System.Drawing.Size(58, 21);
            this.rBPerfil_502ag.TabIndex = 4;
            this.rBPerfil_502ag.Text = "Perfil";
            this.rBPerfil_502ag.UseVisualStyleBackColor = true;
            // 
            // buttonCrear_502ag
            // 
            this.buttonCrear_502ag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCrear_502ag.FlatAppearance.BorderSize = 0;
            this.buttonCrear_502ag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrear_502ag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCrear_502ag.Location = new System.Drawing.Point(7, 414);
            this.buttonCrear_502ag.Name = "buttonCrear_502ag";
            this.buttonCrear_502ag.Size = new System.Drawing.Size(138, 35);
            this.buttonCrear_502ag.TabIndex = 61;
            this.buttonCrear_502ag.Text = "Crear";
            this.buttonCrear_502ag.UseVisualStyleBackColor = false;
            this.buttonCrear_502ag.Click += new System.EventHandler(this.buttonCrear_502ag_Click);
            // 
            // cBFamilia_502ag
            // 
            this.cBFamilia_502ag.FormattingEnabled = true;
            this.cBFamilia_502ag.Location = new System.Drawing.Point(321, 27);
            this.cBFamilia_502ag.Name = "cBFamilia_502ag";
            this.cBFamilia_502ag.Size = new System.Drawing.Size(169, 21);
            this.cBFamilia_502ag.TabIndex = 62;
            this.cBFamilia_502ag.SelectedIndexChanged += new System.EventHandler(this.cBFamilia_502ag_SelectedIndexChanged);
            // 
            // FormPerfiles_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.cBFamilia_502ag);
            this.Controls.Add(this.buttonCrear_502ag);
            this.Controls.Add(this.rBPerfil_502ag);
            this.Controls.Add(this.rBFamilia_502ag);
            this.Controls.Add(this.tBNombre_502ag);
            this.Controls.Add(this.cLBPermisos_502ag);
            this.Controls.Add(this.tVFamilias_502ag);
            this.Name = "FormPerfiles_502ag";
            this.Text = "FormPerfiles_502ag";
            this.Activated += new System.EventHandler(this.FormPerfiles_502ag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPerfiles_502ag_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tVFamilias_502ag;
        private System.Windows.Forms.CheckedListBox cLBPermisos_502ag;
        private System.Windows.Forms.TextBox tBNombre_502ag;
        private System.Windows.Forms.RadioButton rBFamilia_502ag;
        private System.Windows.Forms.RadioButton rBPerfil_502ag;
        private System.Windows.Forms.Button buttonCrear_502ag;
        private System.Windows.Forms.ComboBox cBFamilia_502ag;
    }
}