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
using BLL;
using System.Deployment.Internal;
using Microsoft.VisualBasic;

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
            SuscribirFormularios(Traductor_502ag.GestorTraductor);
            Traductor_502ag.GestorTraductor.CargarIdioma();
            Actualizar(Traductor_502ag.GestorTraductor);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
        }

        public void Actualizar(Traductor_502ag traductor)
        {
            RecorrerControles(this, traductor);
        }

        public void RecorrerControles(Control control, Traductor_502ag traductor)
        {
            foreach (Control c in control.Controls) 
            {
                c.Text = traductor.Traducir(c.Name);

                if(c.Name == labelBienvenida.Name)
                {
                    c.Text = c.Text.Replace("{SessionManager.GestorSessionManager.sesion.NombreUsuario}", $"{SessionManager_502ag.GestorSessionManager.sesion.NombreUsuario}");
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
            traductor.Suscribir(this);
            traductor.Suscribir(abmForm);
            traductor.Suscribir(cambiarContraseñaForm);
            traductor.Suscribir(traductorForm);
        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin_502ag loginForm = new FormLogin_502ag();
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormMenu", "Cierre de sesión", 1);
            SessionManager_502ag.GestorSessionManager.CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormMenu", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormMenu", "Cierre de sesión", 1);
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

    }
}
