using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FormLogin : Form
    {
        BLL_Usuario bllUsuario;
        public FormLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            bllUsuario = new BLL_Usuario();
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombreUsuario.Text;
            string contraseña = textBoxContraseña.Text;

            if (bllUsuario.IniciarSesion(nombre, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito");

                FormMenu menuForm = new FormMenu();
                this.Hide();
                menuForm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error");
            }  
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
