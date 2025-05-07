using SE_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SERVICIOS_502ag;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;


namespace GUI
{
    public partial class FormLogin_502ag : Form
    {
        public FormLogin_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            MostrarContraseña_502ag();
        }
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                SER_GestorUsuario_502ag serGestionUsuario_502ag = new SER_GestorUsuario_502ag();
                string nombreUsuario_502ag = textBoxNombreUsuario.Text;
                string contraseña_502ag = textBoxContraseña.Text;

                SE_Usuario_502ag usuarioALogear_502ag = serGestionUsuario_502ag.ObtenerUsuarioALogear_502ag(nombreUsuario_502ag);

                if (!SER_GestorSesion_502ag.GestorSesion_502ag.EstaLogeado_502ag()) throw new Exception("Ya estas logeado");
                if (!serGestionUsuario_502ag.VerificarExistenciaUsuario_502ag(usuarioALogear_502ag))  throw new Exception("Usuario o contraseñas incorrectos");
                if (!serGestionUsuario_502ag.VerificarUsuarioBloqueado_502ag(usuarioALogear_502ag)) throw new Exception("Usuario bloqueado");
                if (!serGestionUsuario_502ag.VerificarUsuarioActivo_502ag(usuarioALogear_502ag)) throw new Exception("El usuario no se encuentra como activo");
                if (!serGestionUsuario_502ag.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag)) 
                {
                    serGestionUsuario_502ag.SesionFallida_502ag(usuarioALogear_502ag);
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                serGestionUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);

                FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                this.Hide();
                menuForm_502ag.Show();

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error"); }
        }

        private void MostrarContraseña_502ag()
        {
            if (cBMostrarContraseña_502ag.Checked)
            {
                textBoxContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContraseña.UseSystemPasswordChar = true;
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

        private void cBMostrarContraseña_502ag_CheckedChanged(object sender, EventArgs e)
        {
            MostrarContraseña_502ag();
        }
    }
}