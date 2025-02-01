using BE;
using SERVICIOS;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
            labelBienvenida.Text = $"Bienvenido @{SERVICIOS.SessionManager.DevolverNombre()}";
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            SERVICIOS.SessionManager.CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
