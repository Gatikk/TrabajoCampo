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
using BLLS_502ag;

namespace GUI
{
    public partial class FormCambiarContraseña_502ag : Form, IObserver_502ag
    {
        BLLS_Usuario_502ag bllsUsuario_502ag;
        FormMenu_502ag menu_502ag;
        //strings excepciones
        private string noContraseñaActual_502ag, contraseñaCambiada_502ag, siContraseñaActual_502ag, contraseñaNoCoincide_502ag;
        public FormCambiarContraseña_502ag(FormMenu_502ag menuOriginal_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            bllsUsuario_502ag = new BLLS_Usuario_502ag();
            buttonCambiarContraseña_502ag.Enabled = false;
            menu_502ag = menuOriginal_502ag;
            VerificarUsuarioContraseñaCambiada_502ag();
            MostrarContraseña_502ag();
            MostrarConfirmarContraseña_502ag();
            MostrarContraseñaActual_502ag();
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        public void VerificarUsuarioContraseñaCambiada_502ag()
        {
            if(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.ContraseñaCambiada_502ag == true)
            {
                buttonVolverAlMenu_502ag.Enabled = true;
            }
            else
            {
                buttonVolverAlMenu_502ag.Enabled = false;
            }
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {

            SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
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
                if(bllsUsuario_502ag.VerificarCoincidencia_502ag(contraseña_502ag, confirmarContraseña_502ag))
                {
                    SE_Usuario_502ag usuario_502ag = SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag;

                    if (!bllsUsuario_502ag.CompararContraseñaActualTextBox_502ag(contraseñaActual_502ag, usuario_502ag))
                    {
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                        textBoxContraseñaActual_502ag.Clear();
                        throw new Exception(noContraseñaActual_502ag);
                    }
                    if(!bllsUsuario_502ag.VerificarContraseñaActual_502ag(contraseña_502ag, usuario_502ag))
                    {

                        bllsUsuario_502ag.CambiarContraseña_502ag(contraseña_502ag, usuario_502ag);
                        SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                        MessageBox.Show(contraseñaCambiada_502ag);
                        FormLogin_502ag loginForm_502ag = new FormLogin_502ag();
                        SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
                        this.Hide();
                        loginForm_502ag.Show();
                    }
                    else
                    {
                        textBoxContraseña_502ag.Clear();
                        textBoxContraseñaConfirmar_502ag.Clear();
                        textBoxContraseñaActual_502ag.Clear();
                        throw new Exception(siContraseñaActual_502ag);
                    }
                }
                else
                {
                    textBoxContraseña_502ag.Clear();
                    textBoxContraseñaConfirmar_502ag.Clear();
                    textBoxContraseñaActual_502ag.Clear();
                    throw new Exception(contraseñaNoCoincide_502ag);
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

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }
        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if(c_502ag is TextBox)
                {

                }
                else
                {
                    c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);
                }
                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
            }
            noContraseñaActual_502ag = traductor_502ag.Traducir_502ag("noContraseñaActual_502ag");
            contraseñaCambiada_502ag = traductor_502ag.Traducir_502ag("contraseñaCambiada_502ag");
            siContraseñaActual_502ag = traductor_502ag.Traducir_502ag("siContraseñaActual_502ag");
            contraseñaNoCoincide_502ag = traductor_502ag.Traducir_502ag("contraseñaNoCoincide_502ag");
        }
        private void FormCambiarContraseña_502ag_Activated(object sender, EventArgs e)
        {
           
        }
    }
}
