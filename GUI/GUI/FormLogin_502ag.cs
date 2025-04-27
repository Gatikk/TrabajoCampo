using BE_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_502ag;
using SERVICIOS;
using Microsoft.VisualBasic;

namespace GUI
{
    public partial class FormLogin_502ag : Form
    {
        public FormLogin_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);

        }
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario_502ag bllUsuario_502ag = new BLL_Usuario_502ag();
                string nombreUsuario_502ag = textBoxNombreUsuario.Text;
                string contraseña_502ag = textBoxContraseña.Text;

                SER_Usuario_502ag usuarioALogear_502ag = bllUsuario_502ag.DevolverUsuarioALogear_502ag(nombreUsuario_502ag);

                if (!SessionManager_502ag.GestorSessionManager_502ag.estaLogeado_502ag()) throw new Exception("Ya estas logeado");
                if (!bllUsuario_502ag.VerificarExistenciaUsuario_502ag(usuarioALogear_502ag))  throw new Exception("Usuario o contraseñas incorrectos");
                if (!bllUsuario_502ag.VerificarUsuarioBloqueado_502ag(usuarioALogear_502ag)) throw new Exception("Usuario bloqueado");
                if (!bllUsuario_502ag.VerificarUsuarioActivo_502ag(usuarioALogear_502ag)) throw new Exception("El usuario no se encuentra como activo");
                if (!bllUsuario_502ag.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag)) 
                {
                    bllUsuario_502ag.SesionFallida_502ag(usuarioALogear_502ag);
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                bllUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);
                MessageBox.Show("Inicio de sesión exitoso", "Éxito");

                BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                bllBitacora.AltaBitacora_502ag("FormLogin", "Inicio de sesión", 1);
                FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                this.Hide();
                menuForm_502ag.Show();

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error"); }
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