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
        BLL_Usuario_502ag bllUsuario_502ag;
        Cifrador_502ag cifrador_502ag;
        FormMenu_502ag menu_502ag;
        public FormCambiarContraseña_502ag(FormMenu_502ag menuOriginal_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            bllUsuario_502ag = new BLL_Usuario_502ag();
            cifrador_502ag = new Cifrador_502ag();
            buttonCambiarContraseña_502ag.Enabled = false;
            menu_502ag = menuOriginal_502ag;
            Actualizar_502ag(Traductor_502ag.GestorTraductor);
        }
        public void Actualizar_502ag(Traductor_502ag traductor)
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
            menu_502ag.Show();
        }

        private void FormCambiarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora_502ag = new BLL_Bitacora_502ag();
            bllBitacora_502ag.AltaBitacora_502ag("FormCambiarContraseña", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseña_502ag = textBoxContraseña_502ag.Text;
                string confirmarContraseña_502ag = textBoxContraseñaConfirmar_502ag.Text;
                if(bllUsuario_502ag.VerificarCoincidencia_502ag(contraseña_502ag, confirmarContraseña_502ag))
                {
                    string dni_502ag = SessionManager_502ag.GestorSessionManager_502ag.sesion_502ag.DNI_502ag;
                    BE_Usuario_502ag usuario_502ag = bllUsuario_502ag.DevolverUsuario_502ag(dni_502ag);
                    if(!bllUsuario_502ag.VerificarContraseñaActual_502ag(contraseña_502ag, usuario_502ag))
                    {
                        bllUsuario_502ag.CambiarContraseña_502ag(contraseña_502ag, usuario_502ag);
                        MessageBox.Show("Contraseña cambiada exitosamente");
                        BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                        bllBitacora.AltaBitacora_502ag("FormCambiarContraseña", "Cambio de contraseña", 3);
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Esta es su contraseña actual");
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden");
                    textBoxContraseña_502ag.Clear();
                    textBoxContraseñaConfirmar_502ag.Clear();
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        public void VerificarCambiarContraseña()
        {
            buttonCambiarContraseña_502ag.Enabled = !string.IsNullOrWhiteSpace(textBoxContraseña_502ag.Text) &&
                                              !string.IsNullOrWhiteSpace(textBoxContraseñaConfirmar_502ag.Text);
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
