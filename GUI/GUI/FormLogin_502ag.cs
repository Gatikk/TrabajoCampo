using BE;
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

namespace GUI
{
    public partial class FormLogin_502ag : Form
    {
        public FormLogin_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);

        }
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario_502ag bllUsuario = new BLL_Usuario_502ag();
                string nombreUsuario_502ag = textBoxNombreUsuario.Text;
                string contraseña_502ag = textBoxContraseña.Text;

                BE_Usuario_502ag usuarioALogear_502ag = bllUsuario.DevolverUsuarioALogear_502ag(nombreUsuario_502ag);
                

                if(bllUsuario.VerificarExistenciaUsuario_502ag(usuarioALogear_502ag))
                {
                    if(bllUsuario.VerificarUsuarioBloqueado_502ag(usuarioALogear_502ag))
                    {
                        if (bllUsuario.VerificarUsuarioActivo_502ag(usuarioALogear_502ag))
                        {
                            if(bllUsuario.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag))
                            {
                                bllUsuario.IniciarSesion_502ag(usuarioALogear_502ag);
                                MessageBox.Show("Inicio de sesión exitoso", "Éxito");
                                                                                 
                            
                                BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                                bllBitacora.AltaBitacora_502ag("FormLogin", "Inicio de sesión", 1);
                                FormMenu_502ag menuForm = new FormMenu_502ag();
                                this.Hide();
                                menuForm.Show();
                            }
                            else
                            {
                                bllUsuario.SesionFallida_502ag(usuarioALogear_502ag);
                                MessageBox.Show("Usuario o contraseña incorrectos", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no se encuentra como activo", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario bloqueado", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error");
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
    }
}
