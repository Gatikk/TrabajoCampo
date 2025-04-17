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
                string nombreUsuario = textBoxNombreUsuario.Text;
                string contraseña = textBoxContraseña.Text;

                BE_Usuario_502ag usuarioALogear = bllUsuario.DevolverUsuario_502ag(nombreUsuario);
                
                if(usuarioALogear != null)
                {
                    if(usuarioALogear.isBloqueado != true)
                    {
                        if(bllUsuario.VerificarContraseña(usuarioALogear, contraseña))
                        {

                            bllUsuario.IniciarSesion(usuarioALogear);
                            MessageBox.Show("Inicio de sesión exitoso", "Éxito");
                            
                            
                            
                            
                            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                            bllBitacora.AltaBitacora("FormLogin", "Inicio de sesión", 1);
                            FormMenu_502ag menuForm = new FormMenu_502ag();
                            this.Hide();
                            menuForm.Show();
                        }
                        else
                        {
                            bllUsuario.SesionFallida(usuarioALogear);
                            MessageBox.Show("Usuario o contraseña incorrectos", "Error");
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
            bllBitacora.AltaBitacora("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
    }
}
