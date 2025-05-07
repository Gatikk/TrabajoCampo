using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Internal;
using Microsoft.VisualBasic;
using SE_502ag;


namespace GUI
{
    public partial class FormMenu_502ag : Form
    {
        FormABMUsuario_502ag abmForm;
        FormCambiarContraseña_502ag cambiarContraseñaForm;
        public FormMenu_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
            panelSubMenuAdmin_502ag.Visible = false;
            panelSubMenuUsuario_502ag.Visible=false;
            panelSubMenuMaestros_502ag.Visible=false;
            panelSubMenuVentas_502ag.Visible=false;
            panelSubMenuReportes_502ag.Visible=false;
            labelBienvenida.Text = $"Bienvenido @{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag}";
            abmForm = new FormABMUsuario_502ag(this);
            cambiarContraseñaForm = new FormCambiarContraseña_502ag(this);
        }



        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm = new FormLogin_502ag();

            SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

            Environment.Exit(0);
        }

        private void buttonABM_Click(object sender, EventArgs e)
        {
            this.Hide();
            abmForm.Show(); 
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            this.Hide();
            cambiarContraseñaForm.Show();
        }
        private void buttonBitacora_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCambiarIdioma_Click(object sender, EventArgs e)
        {
        }

        private void esconderSubMenu_502ag()
        {
            if(panelSubMenuAdmin_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible=false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
            }
            if(panelSubMenuUsuario_502ag.Visible == true)
            {
                panelSubMenuUsuario_502ag.Visible=false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
            }
            if(panelSubMenuMaestros_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
            }
            if(panelSubMenuVentas_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
            }
            if(panelSubMenuReportes_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
            }
        }

        private void mostrarSubMenu_502ag(Panel subMenu_502ag)
        {
            if(subMenu_502ag.Visible == false)
            {
                esconderSubMenu_502ag();
                subMenu_502ag.Visible = true;
            }
            else
            {
                subMenu_502ag.Visible = false;
            }
        }

        private void buttonAdmin_502ag_Click(object sender, EventArgs e)
        {
            mostrarSubMenu_502ag(panelSubMenuAdmin_502ag);
        }

        private void buttonUsuario_502ag_Click(object sender, EventArgs e)
        {
            mostrarSubMenu_502ag(panelSubMenuUsuario_502ag);
        }

        private void buttonIniciarSesion_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                SER_GestorUsuario_502ag serGestionUsuario_502ag = new SER_GestorUsuario_502ag();
                string nombreUsuario_502ag = Interaction.InputBox("Nombre: ");
                string contraseña_502ag = Interaction.InputBox("Contraseña: ");

                SE_Usuario_502ag usuarioALogear_502ag = serGestionUsuario_502ag.ObtenerUsuarioALogear_502ag(nombreUsuario_502ag);

                if (!SER_GestorSesion_502ag.GestorSesion_502ag.EstaLogeado_502ag()) throw new Exception("Ya estas logeado");
                if (!serGestionUsuario_502ag.VerificarExistenciaUsuario_502ag(usuarioALogear_502ag)) throw new Exception("Usuario o contraseñas incorrectos");
                if (!serGestionUsuario_502ag.VerificarUsuarioBloqueado_502ag(usuarioALogear_502ag)) throw new Exception("Usuario bloqueado");
                if (!serGestionUsuario_502ag.VerificarUsuarioActivo_502ag(usuarioALogear_502ag)) throw new Exception("El usuario no se encuentra como activo");
                if (!serGestionUsuario_502ag.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag))
                {
                    serGestionUsuario_502ag.SesionFallida_502ag(usuarioALogear_502ag);
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                serGestionUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);
                MessageBox.Show("Inicio de sesión exitoso", "Éxito");

                FormMenu_502ag menuForm = new FormMenu_502ag();
                this.Hide();
                menuForm.Show();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonMaestros_502ag_Click(object sender, EventArgs e)
        {
            mostrarSubMenu_502ag(panelSubMenuMaestros_502ag);
        }

        private void buttonVentas_502ag_Click(object sender, EventArgs e)
        {
            mostrarSubMenu_502ag(panelSubMenuVentas_502ag);
        }

        private void buttonReportes_502ag_Click(object sender, EventArgs e)
        {
            mostrarSubMenu_502ag(panelSubMenuReportes_502ag);
        }
    }
}
