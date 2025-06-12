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
        FormMaestrosClientes_502ag maestrosClientesForm_502ag;
        FormMaestrosCombustible_502ag maestrosCombustiblesForm_502ag;
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
            maestrosClientesForm_502ag = new FormMaestrosClientes_502ag(this);
            maestrosCombustiblesForm_502ag = new FormMaestrosCombustible_502ag(this);
            VerificarAdminSupremo();
        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm = new FormLogin_502ag();

            DialogResult dResult_502ag = MessageBox.Show($"¿Seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dResult_502ag == DialogResult.Yes) 
            { 
                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag(); 
                this.Hide();
                loginForm.Show();       
            }          
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

        private void VerificarAdminSupremo()
        {
            if(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag == "#admin@")
            {
                buttonCambiarContraseña_502ag.Enabled = false;
            }
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            this.Hide();
            cambiarContraseñaForm.Show();
        }

        private void buttonMaestrosClientes_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            maestrosClientesForm_502ag.Show();
        }
        private void buttonMaestrosCombustibles_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            maestrosCombustiblesForm_502ag.Show();
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
    }
}
