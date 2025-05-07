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
using SE_502ag;

namespace GUI
{
    public partial class FormCambiarContraseña_502ag : Form
    {
        SER_GestorUsuario_502ag serGestionUsuario_502ag;
        Encryptador_502ag cifrador_502ag;
        FormMenu_502ag menu_502ag;
        public FormCambiarContraseña_502ag(FormMenu_502ag menuOriginal_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            serGestionUsuario_502ag = new SER_GestorUsuario_502ag();
            cifrador_502ag = new Encryptador_502ag();
            buttonCambiarContraseña_502ag.Enabled = false;
            menu_502ag = menuOriginal_502ag;
            MostrarContraseña_502ag();
            MostrarConfirmarContraseña_502ag();
            MostrarContraseñaActual_502ag();
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu_502ag.Show();
        }

        private void FormCambiarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {

            Environment.Exit(0);
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseñaActual_502ag = textBoxContraseñaActual_502ag.Text;
                string contraseña_502ag = textBoxContraseña_502ag.Text;
                string confirmarContraseña_502ag = textBoxContraseñaConfirmar_502ag.Text;
                if(serGestionUsuario_502ag.VerificarCoincidencia_502ag(contraseña_502ag, confirmarContraseña_502ag))
                {
                    SE_Usuario_502ag usuario_502ag = SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag;

                    if (!serGestionUsuario_502ag.CompararContraseñaActualTextBox_502ag(contraseñaActual_502ag, usuario_502ag))
                    {
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                        textBoxContraseñaActual_502ag.Clear();
                        throw new Exception("No es tu contraseña actual");
                    }
                    if(!serGestionUsuario_502ag.VerificarContraseñaActual_502ag(contraseña_502ag, usuario_502ag))
                    {
                        serGestionUsuario_502ag.CambiarContraseña_502ag(contraseña_502ag, usuario_502ag);
                        textBoxContraseñaActual_502ag.Clear();
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                    }
                    else
                    {
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                        textBoxContraseñaActual_502ag.Clear();
                        throw new Exception("Esta es su contraseña actual");
                    }
                }
                else
                {
                    textBoxContraseña_502ag.Clear();
                    textBoxContraseñaConfirmar_502ag.Clear();
                    textBoxContraseñaActual_502ag.Clear();
                    throw new Exception("Contraseñas no coinciden");
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void MostrarContraseña_502ag()
        {
            if (cBMostrarContraseña_502ag.Checked)
            {
                textBoxContraseña_502ag.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContraseña_502ag.UseSystemPasswordChar = true;
            }
        }
        private void MostrarConfirmarContraseña_502ag()
        {
            if (cBMostrarConfirmarContraseña_502ag.Checked)
            {
                textBoxContraseñaConfirmar_502ag.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContraseñaConfirmar_502ag.UseSystemPasswordChar = true;
            }
        }

        private void MostrarContraseñaActual_502ag()
        {
            if (cBContraseñaActual_502ag.Checked)
            {
                textBoxContraseñaActual_502ag.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContraseñaActual_502ag.UseSystemPasswordChar = true;
            }
        }


        public void VerificarCambiarContraseña()
        {
            buttonCambiarContraseña_502ag.Enabled = !string.IsNullOrWhiteSpace(textBoxContraseña_502ag.Text) &&
                                                    !string.IsNullOrWhiteSpace(textBoxContraseñaConfirmar_502ag.Text)&&
                                                    !string.IsNullOrWhiteSpace(textBoxContraseñaActual_502ag.Text);
        }

        private void textBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            VerificarCambiarContraseña();
        }

        private void textBoxContraseñaConfirmar_TextChanged(object sender, EventArgs e)
        {
            VerificarCambiarContraseña();
        }
        private void textBoxContraseñaActual_502ag_TextChanged(object sender, EventArgs e)
        {
            VerificarCambiarContraseña();
        }

        private void cBMostrarContraseña_502ag_CheckedChanged(object sender, EventArgs e)
        {
            MostrarContraseña_502ag();
        }

        private void cBMostrarConfirmarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            MostrarConfirmarContraseña_502ag();
        }

        private void cBContraseñaActual_502ag_CheckedChanged(object sender, EventArgs e)
        {
            MostrarContraseñaActual_502ag();
        }
    }
}
