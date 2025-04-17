using BE;
using BLL;
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

namespace GUI
{
    public partial class FormCambiarContraseña_502ag : Form, IObserver_502ag
    {
        BLL_Usuario_502ag bllUsuario;
        Cifrador_502ag cifrador;
        FormMenu_502ag menu;
        public FormCambiarContraseña_502ag(FormMenu_502ag menuOriginal)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            bllUsuario = new BLL_Usuario_502ag();
            cifrador = new Cifrador_502ag();
            buttonCambiarContraseña.Enabled = false;
            menu = menuOriginal;
            Actualizar(Traductor_502ag.GestorTraductor);
        }
        public void Actualizar(Traductor_502ag traductor)
        {
            RecorrerControles(this, traductor);
        }

        public void RecorrerControles(Control control, Traductor_502ag traductor)
        {
            foreach (Control c in control.Controls)
            {
                if(!(c is TextBox))
                c.Text = traductor.Traducir(c.Name);
                if (c.HasChildren)
                {
                    RecorrerControles(c, traductor);
                }
            }
        }
        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }

        private void FormCambiarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormCambiarContraseña", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxContraseña.Text == textBoxContraseñaConfirmar.Text)
                {
                    BE_Usuario_502ag entidad = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == SessionManager_502ag.GestorSessionManager.sesion.NombreUsuario);
                    if(entidad.Contraseña != cifrador.CifradorIrreversible(textBoxContraseña.Text))
                    {
                        bllUsuario.CambiarContraseña(textBoxContraseña.Text, entidad);
                        MessageBox.Show("Contraseña cambiada exitosamente");
                        BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                        bllBitacora.AltaBitacora("FormCambiarContraseña", "Cambio de contraseña", 3);
                        textBoxContraseña.Clear();
                        textBoxContraseñaConfirmar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Esta es su contraseña actual");
                        textBoxContraseña.Clear();
                        textBoxContraseñaConfirmar.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden");
                    textBoxContraseña.Clear();
                    textBoxContraseñaConfirmar.Clear();
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        public void VerificarCambiarContraseña()
        {
            buttonCambiarContraseña.Enabled = !string.IsNullOrWhiteSpace(textBoxContraseña.Text) &&
                                              !string.IsNullOrWhiteSpace(textBoxContraseñaConfirmar.Text);
        }

        private void textBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            VerificarCambiarContraseña();
        }

        private void textBoxContraseñaConfirmar_TextChanged(object sender, EventArgs e)
        {
            VerificarCambiarContraseña();
        }
    }
}
