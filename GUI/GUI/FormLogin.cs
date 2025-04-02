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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);

        }
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario bllUsuario = new BLL_Usuario();
                string nombre = textBoxNombreUsuario.Text;
                string contraseña = textBoxContraseña.Text;

                BE_Usuario usuarioALogear = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == nombre);
                if(usuarioALogear != null)
                {
                    if(usuarioALogear.isBloqueado != true)
                    {
                        if(bllUsuario.VerificarContraseña(usuarioALogear, contraseña))
                        {

                            bllUsuario.IniciarSesion(usuarioALogear);
                            BLL_Bitacora bllBitacora = new BLL_Bitacora();
                            bllBitacora.AltaBitacora("FormLogin", "Inicio de sesión", 1);
                            MessageBox.Show("Inicio de sesión exitoso", "Éxito");
                            FormMenu menuForm = new FormMenu();
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
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormLogin", "Cierre de sesión", 1);
            Environment.Exit(0);
        }
    }
}
