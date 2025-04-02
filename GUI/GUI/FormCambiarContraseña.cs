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
    public partial class FormCambiarContraseña : Form, IObserver
    {
        BLL_Usuario bllUsuario;
        Cifrador cifrador;
        FormMenu menu;
        public FormCambiarContraseña(FormMenu menuOriginal)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            bllUsuario = new BLL_Usuario();
            cifrador = new Cifrador();
            buttonCambiarContraseña.Enabled = false;
            menu = menuOriginal;
            Actualizar(Traductor.GestorTraductor);
        }
        public void Actualizar(Traductor traductor)
        {
            RecorrerControles(this, traductor);
        }

        public void RecorrerControles(Control control, Traductor traductor)
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
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormCambiarContraseña", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxContraseña.Text == textBoxContraseñaConfirmar.Text)
                {
                    BE_Usuario entidad = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == SessionManager.GestorSessionManager.DevolverNombre());
                    if(entidad.Contraseña != cifrador.CifradorIrreversible(textBoxContraseña.Text))
                    {
                        bllUsuario.CambiarContraseña(textBoxContraseña.Text, entidad);
                        MessageBox.Show("Contraseña cambiada exitosamente");
                        BLL_Bitacora bllBitacora = new BLL_Bitacora();
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
