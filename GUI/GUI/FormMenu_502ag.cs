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
        private string messageBoxCerrarSesion_502ag, messageBoxCaptionCerrarSesion_502ag;
        
        public FormMenu_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            panelSubMenuAdmin_502ag.Visible = false;
            panelSubMenuUsuario_502ag.Visible= false;
            panelSubMenuMaestros_502ag.Visible= false;
            panelSubMenuVentas_502ag.Visible= false;
            panelSubMenuReportes_502ag.Visible= false;
            VerificarAdminSupremo();
            
        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm_502ag = new FormLogin_502ag();
            DialogResult dResult_502ag = MessageBox.Show(messageBoxCerrarSesion_502ag, messageBoxCaptionCerrarSesion_502ag, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dResult_502ag == DialogResult.Yes) 
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
            if(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag == "#admin@")
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
            if(panelSubMenuAdmin_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible=false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
            }
            if(panelSubMenuUsuario_502ag.Visible == true)
            {
                panelSubMenuUsuario_502ag.Visible=false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuAdmin_502ag.Visible = false;
            }
            if(panelSubMenuMaestros_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
            }
            if(panelSubMenuVentas_502ag.Visible == true)
            {
                panelSubMenuAdmin_502ag.Visible = false;
                panelSubMenuUsuario_502ag.Visible = false;
                panelSubMenuMaestros_502ag.Visible = false;
                panelSubMenuReportes_502ag.Visible = false;
                panelSubMenuVentas_502ag.Visible = false;
            }
            if(panelSubMenuReportes_502ag.Visible == true)
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
            FormTraductor_502ag formTraductor_502Ag = new FormTraductor_502ag(this);
            formTraductor_502Ag.Show();
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void FormMenu_502ag_Activated(object sender, EventArgs e)
        {
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag();
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
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
    }
}
