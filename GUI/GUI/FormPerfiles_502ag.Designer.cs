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
            this.tVPermisos_502ag = new System.Windows.Forms.TreeView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // tVPermisos_502ag
            // 
            this.tVPermisos_502ag.Location = new System.Drawing.Point(484, 53);
            this.tVPermisos_502ag.Name = "tVPermisos_502ag";
            this.tVPermisos_502ag.Size = new System.Drawing.Size(217, 290);
            this.tVPermisos_502ag.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(215, 53);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(217, 289);
            this.checkedListBox1.TabIndex = 1;
            // 
            // FormPerfiles_502ag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.tVPermisos_502ag);
            this.Name = "FormPerfiles_502ag";
            this.Text = "FormPerfiles_502ag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tVPermisos_502ag;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}