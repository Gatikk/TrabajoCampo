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
    public partial class FormMenu : Form, IObserver
    {
        FormABM abmForm;
        FormCambiarContraseña cambiarContraseñaForm;
        FormTraductor traductorForm;
        public FormMenu()
        {
            InitializeComponent();
            SuscribirFormularios(Traductor.GestorTraductor);
            Traductor.GestorTraductor.CargarIdioma();
            Actualizar(Traductor.GestorTraductor);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
        }

        public void Actualizar(Traductor traductor)
        {
            RecorrerControles(this, traductor);
        }

        public void RecorrerControles(Control control, Traductor traductor)
        {
            foreach (Control c in control.Controls) 
            {
                c.Text = traductor.Traducir(c.Name);

                if(c.Name == labelBienvenida.Name)
                {
                    c.Text = c.Text.Replace("{SessionManager.GestorSessionManager.DevolverNombre()}", $"{SessionManager.GestorSessionManager.DevolverNombre()}");
                }

                if (c.HasChildren)
                {
                    RecorrerControles(c, traductor);
                }
            }
        }
        public void SuscribirFormularios(Traductor traductor)
        {
            abmForm = new FormABM(this);
            cambiarContraseñaForm = new FormCambiarContraseña(this);
            traductorForm = new FormTraductor(this);
            traductor.Suscribir(this);
            traductor.Suscribir(abmForm);
            traductor.Suscribir(cambiarContraseñaForm);
            traductor.Suscribir(traductorForm);
        }
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormMenu", "Cierre de sesión", 1);
            SessionManager.GestorSessionManager.CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormMenu", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
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
            FormBitacora bitacoraForm = new FormBitacora(this);
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
