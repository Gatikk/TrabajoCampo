using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormSistemaNoDisponible_502ag : Form
    {
        public FormSistemaNoDisponible_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void buttonOk_502ag_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
