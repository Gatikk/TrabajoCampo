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
using BLLS_502ag;


namespace GUI
{
    public partial class FormMenu_502ag : Form, IObserver_502ag
    {
        private string messageBoxCerrarSesion_502ag, messageBoxCaptionCerrarSesion_502ag;

        public FormMenu_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            panelSubMenuAdmin_502ag.Visible = false;
            panelSubMenuUsuario_502ag.Visible = false;
            panelSubMenuMaestros_502ag.Visible = false;
            panelSubMenuVentas_502ag.Visible = false;
            panelSubMenuReportes_502ag.Visible = false;
            VerificarAdminSupremo();
            BloquearAccesos_502ag();

        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm_502ag = new FormLogin_502ag();
            DialogResult dResult_502ag = MessageBox.Show(messageBoxCerrarSesion_502ag, messageBoxCaptionCerrarSesion_502ag, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dResult_502ag == DialogResult.Yes)
            {
                BLLS_502ag.BLLS_Usuario_502ag bllsUsuario_502ag = new BLLS_502ag.BLLS_Usuario_502ag();
                bllsUsuario_502ag.ActualizarIdiomaCierreSesion_502ag();
                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                this.Hide();
                loginForm_502ag.Show();
            }
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLLS_502ag.BLLS_Usuario_502ag bllsUsuario_502ag = new BLLS_502ag.BLLS_Usuario_502ag();
            bllsUsuario_502ag.ActualizarIdiomaCierreSesion_502ag();
            Environment.Exit(0);
        }

        private void buttonABM_Click(object sender, EventArgs e)
        {
            FormABMUsuario_502ag abmForm_502ag = new FormABMUsuario_502ag(this);
            this.Hide();
            abmForm_502ag.Show();
        }

        private void VerificarAdminSupremo()
        {
            if (SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag == "#admin@")
            {
                buttonCambiarContraseña_502ag.Enabled = false;
            }
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña_502ag cambiarContraseñaForm_502ag = new FormCambiarContraseña_502ag(this);
            this.Hide();
            cambiarContraseñaForm_502ag.Show();
        }

        private void buttonMaestrosClientes_502ag_Click(object sender, EventArgs e)
        {
            FormMaestrosClientes_502ag maestrosClientesForm_502ag = new FormMaestrosClientes_502ag(this);
            this.Hide();
            maestrosClientesForm_502ag.Show();
        }
        private void buttonMaestrosCombustibles_502ag_Click(object sender, EventArgs e)
        {
            FormMaestrosCombustible_502ag maestrosCombustiblesForm_502ag = new FormMaestrosCombustible_502ag(this);
            this.Hide();
            maestrosCombustiblesForm_502ag.Show();
        }
        private void buttonCargarCombustible_502ag_Click(object sender, EventArgs e)
        {
            FormCargarCombustible_502ag cargarCombustibleForm_502ag = new FormCargarCombustible_502ag(this);
            this.Hide();
            cargarCombustibleForm_502ag.Show();
        }
        private void buttonVerFacturas_502ag_Click(object sender, EventArgs e)
        {
            FormVerFacturas_502ag verFacturasForm_502ag = new FormVerFacturas_502ag(this);
            this.Hide();
            verFacturasForm_502ag.Show();
        }
        private void esconderSubMenu_502ag()
        {
            if (panelSubMenuAdmin_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
            }
            if (panelSubMenuUsuario_502ag.Visible == true)
            {
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuAdmin_502ag.Visible = false;
            }
            if (panelSubMenuMaestros_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
            }
            if (panelSubMenuVentas_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
            }
            if (panelSubMenuReportes_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
            }
        }

        private void mostrarSubMenu_502ag(Panel subMenu_502ag)
        {
            if (subMenu_502ag.Visible == false)
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
                FormLogin_502ag frmLogin_502ag = new FormLogin_502ag();
                this.Hide();
                frmLogin_502ag.Show();
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

        private void buttonPerfiles_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPerfiles_502ag perfilesForm_502ag = new FormPerfiles_502ag(this);
            perfilesForm_502ag.Show();
        }

        private void buttonCambiarIdioma_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTraductor_502ag traductorForm_502ag = new FormTraductor_502ag(this);
            traductorForm_502ag.Show();
        }

        private void buttonBitacoraEventos_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBitacoraEventos_502ag bitacoraEventosForm_502ag = new FormBitacoraEventos_502ag();
            bitacoraEventosForm_502ag.Show();

        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void FormMenu_502ag_Activated(object sender, EventArgs e)
        {
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
            ValidadPermisos_502ag(this);
            ActivarBotonesSubMenu_502ag();
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);

                if (c_502ag.Name == labelBienvenida_502ag.Name)
                {
                    c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name) + $"{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag}";
                }

                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
            }
            messageBoxCerrarSesion_502ag = traductor_502ag.Traducir_502ag("messageBoxCerrarSesion_502ag");
            messageBoxCaptionCerrarSesion_502ag = traductor_502ag.Traducir_502ag("messageBoxCaptionCerrarSesion_502ag");
        }

        private void BloquearAccesos_502ag()
        {
            buttonABM_502ag.Enabled = false;
            buttonPerfiles_502ag.Enabled = false;
            buttonCerrarSesion_502ag.Enabled = false;
            buttonIniciarSesion_502ag.Enabled = false;
            buttonCambiarContraseña_502ag.Enabled = false;
            buttonCambiarIdioma_502ag.Enabled = false;
            buttonMaestrosClientes_502ag.Enabled = false;
            buttonMaestrosCombustibles_502ag.Enabled = false;
            buttonCargarCombustible_502ag.Enabled = false;
            buttonVerFacturas_502ag.Enabled = false;
        }

        private void ValidadPermisos_502ag(Control control_502ag)
        {
            try
            {
                if (SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag != "#admin@")
                {
                    BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                    List<SE_Patente_502ag> listaPatentes_502ag = bllsPerfil_502ag.ObtenerPatentesDePerfil_502ag(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Rol_502ag);
                    foreach (Control c_502ag in control_502ag.Controls)
                    {
                        if (c_502ag.Tag != null && c_502ag.Tag is string patenteABuscar)
                        {
                            if (patenteABuscar == "Iniciar Sesion" || patenteABuscar == "Cerrar Sesion" || patenteABuscar == "Cambiar Contraseña" || patenteABuscar == "Cambiar Idioma")
                            {
                                c_502ag.Enabled = true;

                            }
                            else
                            {
                                c_502ag.Enabled = listaPatentes_502ag.Any(p => p.Nombre_502ag == patenteABuscar);
                            }
                        }
                        if (c_502ag.HasChildren)
                        {
                            ValidadPermisos_502ag(c_502ag);
                        }
                    }
                }
                else
                {
                    buttonABM_502ag.Enabled = true;
                    buttonPerfiles_502ag.Enabled = true;
                    buttonCerrarSesion_502ag.Enabled = true;
                    buttonIniciarSesion_502ag.Enabled = true;
                    buttonCambiarContraseña_502ag.Enabled = true;
                    buttonCambiarIdioma_502ag.Enabled = true;
                    buttonMaestrosClientes_502ag.Enabled = true;
                    buttonMaestrosCombustibles_502ag.Enabled = true;
                    buttonCargarCombustible_502ag.Enabled = true;
                    buttonVerFacturas_502ag.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void buttonRespaldos_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBackupRestore_502ag formBackupRestore_502ag = new FormBackupRestore_502ag();
            formBackupRestore_502ag.Show();
        }

        private void ActivarBotonesSubMenu_502ag()
        {
            if(buttonABM_502ag.Enabled || buttonPerfiles_502ag.Enabled)
            {
                buttonAdmin_502ag.Enabled = true;
            }
            else
            {
                buttonAdmin_502ag.Enabled = false;
            }
            if (buttonCerrarSesion_502ag.Enabled || buttonIniciarSesion_502ag.Enabled || buttonCambiarContraseña_502ag.Enabled || buttonCambiarIdioma_502ag.Enabled)
            {
                buttonUsuario_502ag.Enabled = true;
            }
            else
            {
                buttonUsuario_502ag.Enabled = false;
            }
            if (buttonMaestrosClientes_502ag.Enabled || buttonMaestrosCombustibles_502ag.Enabled)
            {
                buttonMaestros_502ag.Enabled = true;
            }
            else
            {
                buttonMaestros_502ag.Enabled = false;
            }
            if (buttonCargarCombustible_502ag.Enabled)
            {
                buttonVentas_502ag.Enabled = true;
            }
            else
            {
                buttonVentas_502ag.Enabled = false;
            }
            if (buttonVerFacturas_502ag.Enabled)
            {
                buttonReportes_502ag.Enabled = true;
            }
            else
            {
                buttonReportes_502ag.Enabled = false;
            }
        }
    }
}
