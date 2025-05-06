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
    public partial class FormMenu_502ag : Form, IObserver_502ag
    {
        FormABMUsuario_502ag abmForm;
        FormCambiarContraseña_502ag cambiarContraseñaForm;
        FormTraductor_502ag traductorForm;
        public FormMenu_502ag()
        {
            InitializeComponent();
            SuscribirFormularios(Traductor_502ag.GestorTraductor_502ag);
            Traductor_502ag.GestorTraductor_502ag.CargarIdioma_502ag();
            Actualizar_502ag(Traductor_502ag.GestorTraductor_502ag);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
            panelSubMenuAdmin_502ag.Visible = false;
            panelSubMenuUsuario_502ag.Visible=false;
            panelSubMenuMaestros_502ag.Visible=false;
            panelSubMenuVentas_502ag.Visible=false;
            panelSubMenuReportes_502ag.Visible=false;     
        }

        public void Actualizar_502ag(Traductor_502ag traductor)
        {
            RecorrerControles(this, traductor);
        }

        public void RecorrerControles(Control control, Traductor_502ag traductor)
        {
            foreach (Control c in control.Controls) 
            {
                c.Text = traductor.Traducir_502ag(c.Name);

                if(c.Name == labelBienvenida.Name)
                {
                    c.Text = c.Text.Replace("{SessionManager.GestorSessionManager.sesion.NombreUsuario}", $"{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag}");
                }

                if (c.HasChildren)
                {
                    RecorrerControles(c, traductor);
                }
            }
        }
        public void SuscribirFormularios(Traductor_502ag traductor)
        {
            abmForm = new FormABMUsuario_502ag(this);
            cambiarContraseñaForm = new FormCambiarContraseña_502ag(this);
            traductorForm = new FormTraductor_502ag(this);
            traductor.Suscribir_502ag(this);
            traductor.Suscribir_502ag(abmForm);
            traductor.Suscribir_502ag(cambiarContraseñaForm);
            traductor.Suscribir_502ag(traductorForm);
        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm = new FormLogin_502ag();
            SER_GestorBitacora_502ag bllBitacora = new SER_GestorBitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormMenu", "Cierre de sesión", 1);
            SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SER_GestorBitacora_502ag bllBitacora_502ag = new SER_GestorBitacora_502ag();
            bllBitacora_502ag.AltaBitacora_502ag("FormMenu", "Cierre de sesión", 1);
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
            FormBitacora_502ag bitacoraForm = new FormBitacora_502ag(this);
            this.Hide();
            bitacoraForm.Show();
        }

        private void buttonCambiarIdioma_Click(object sender, EventArgs e)
        {
            this.Hide();
            traductorForm.Show();
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

                SER_GestorBitacora_502ag bllBitacora = new SER_GestorBitacora_502ag();
                bllBitacora.AltaBitacora_502ag("FormLogin", "Inicio de sesión", 1);
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
