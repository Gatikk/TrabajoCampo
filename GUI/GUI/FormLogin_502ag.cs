using BLL_502ag;
using BLLS_502ag;
using Microsoft.VisualBasic;
using SE_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//usuario hardcodeado: nombre: #admin@ contraseña: 123456787654321

namespace GUI
{
    public partial class FormLogin_502ag : Form
    {
        public FormLogin_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            MostrarContraseña_502ag();
        }
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
                BLLS_Usuario_502ag bllsUsuario_502ag = new BLLS_Usuario_502ag();
                string nombreUsuario_502ag = textBoxNombreUsuario.Text;
                string contraseña_502ag = textBoxContraseña.Text;

                SE_Usuario_502ag usuarioALogear_502ag = bllsUsuario_502ag.ObtenerUsuarioPorNombreUsuario_502ag(nombreUsuario_502ag);
                if (!SER_GestorSesion_502ag.GestorSesion_502ag.EstaLogeado_502ag()) throw new Exception("Ya hay una sesión iniciada");
                if (!bllsUsuario_502ag.VerificarExistenciaUsuario_502ag(usuarioALogear_502ag)) throw new Exception("Usuario o contraseña incorrectos");
                if (usuarioALogear_502ag.NombreUsuario_502ag == "#admin@")
                {
                    if (bllsUsuario_502ag.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag))
                    {
                        bllsUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);
                        if (bllDigitoVerificador_502ag.CompararDigitos())
                        {
                            FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                            this.Hide();
                            menuForm_502ag.Show();

                        }
                        else
                        {
                            FormDigitoVerificador_502ag digitoForm_502ag = new FormDigitoVerificador_502ag();
                            this.Hide();
                            digitoForm_502ag.Show();
                        }
                    }
                    else
                    {
                        throw new Exception("Usuario o contraseña incorrectos");
                    }
                }
                else
                {         
                    if (!bllsUsuario_502ag.VerificarUsuarioBloqueado_502ag(usuarioALogear_502ag)) throw new Exception("El usuario se encuentra bloqueado");
                    if (!bllsUsuario_502ag.VerificarUsuarioActivo_502ag(usuarioALogear_502ag)) throw new Exception("El usuario no se encuentra como activo");
                    if (!bllsUsuario_502ag.VerificarContraseña_502ag(usuarioALogear_502ag, contraseña_502ag)) 
                    {
                        if (bllsUsuario_502ag.VerificarUltimoLogin_502ag(usuarioALogear_502ag))
                        {
                            bllsUsuario_502ag.ReiniciarIntentos_502ag(usuarioALogear_502ag);
                        }
                        bllsUsuario_502ag.SesionFallida_502ag(usuarioALogear_502ag);
                        throw new Exception("Usuario o contraseña incorrectos");
                    }
                    if (bllsUsuario_502ag.VerificarContraseñaCambiada_502ag(usuarioALogear_502ag))
                    {
                        bllsUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);


                        if (bllDigitoVerificador_502ag.CompararDigitos())
                        {
                            FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                            this.Hide();
                            menuForm_502ag.Show();

                        }
                        else
                        {
                            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                            List<SE_Patente_502ag> listaPatentes_502ag = bllsPerfil_502ag.ObtenerPatentesDePerfil_502ag(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Rol_502ag);

                            if (listaPatentes_502ag.Find(x => x.Nombre_502ag == "Recalcular Digito") != null)
                            {
                                FormDigitoVerificador_502ag digitoForm_502ag = new FormDigitoVerificador_502ag();
                                this.Hide();
                                digitoForm_502ag.Show();
                            }
                            else
                            {
                                FormSistemaNoDisponible_502ag sistemaNoDisponibleForm_502ag = new FormSistemaNoDisponible_502ag();
                                this.Hide();
                                sistemaNoDisponibleForm_502ag.Show();
                            }
                        }
                    }
                    else
                    {
                        bllsUsuario_502ag.IniciarSesion_502ag(usuarioALogear_502ag);
                        FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                        FormCambiarContraseña_502ag cambiarContraseñaForm_502ag = new FormCambiarContraseña_502ag(menuForm_502ag);
                        this.Hide();
                        cambiarContraseñaForm_502ag.Show();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error"); }
        }

        private void MostrarContraseña_502ag()
        {
            if (cBMostrarContraseña_502ag.Checked)
            {
                textBoxContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContraseña.UseSystemPasswordChar = true;
            }
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            if (SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag == null)
            {
                Environment.Exit(0);
            }
            else
            {
                FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                this.Hide();
                menuForm_502ag.Show();
            }
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag == null)
            {
                Environment.Exit(0);
            }
            else
            {
                FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
                this.Hide();
                menuForm_502ag.Show();
            }
        }

        private void cBMostrarContraseña_502ag_CheckedChanged(object sender, EventArgs e)
        {
            MostrarContraseña_502ag();
        }
    }
}