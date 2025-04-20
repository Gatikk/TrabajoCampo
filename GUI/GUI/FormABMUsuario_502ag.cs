using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormABMUsuario_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";
        public FormABMUsuario_502ag(FormMenu_502ag menuOriginal_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            Mostrar_502ag(dgvUsuarios_502ag);
            cBRol_502ag.SelectedIndex = 0;
            cBRol_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            tBModoActual_502ag.Text = "Modo Consulta";
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
            tBNombreUsuario_502ag.Enabled = false;
            tBNombre_502ag.Enabled = false;
            tBApellido_502ag.Enabled = false;
            tBDNI_502ag.Enabled = false;
            tBEmail_502ag.Enabled = false;
            cBRol_502ag.Enabled =false;

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
                if(!(c is ComboBox) && !(c is TextBox))
                {
                    c.Text = traductor.Traducir(c.Name);
                }
                if(c is DataGridView)
                {
                    DataGridView cDGV = c as DataGridView;
                    foreach (DataGridViewColumn columna in cDGV.Columns) 
                    {
                        columna.HeaderText = traductor.Traducir(columna.Name);
                    }
                }
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

        private void FormABM_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora_502ag = new BLL_Bitacora_502ag();
            bllBitacora_502ag.AltaBitacora_502ag("FormABM", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        public void Mostrar_502ag(DataGridView dgv_502ag)
        {
            BLL_Usuario_502ag bllUsuario_502ag = new BLL_Usuario_502ag();
            dgv_502ag.Rows.Clear();

            if (rBActivos_502ag.Checked)
            {
                foreach(BE_Usuario_502ag usuario_502ag in bllUsuario_502ag.DevolverListaUsuarios_502ag().Where(x => x.isActivo_502ag == true))
                {
                    dgv_502ag.Rows.Add(usuario_502ag.NombreUsuario_502ag, usuario_502ag.Rol_502ag, usuario_502ag.Nombre_502ag, usuario_502ag.Apellido_502ag, usuario_502ag.DNI_502ag, usuario_502ag.Email_502ag, usuario_502ag.isBloqueado_502ag, usuario_502ag.isActivo_502ag);
                }
            }
            if (rBTodos_502ag.Checked)
            {
                foreach (BE_Usuario_502ag usuario_502ag in bllUsuario_502ag.DevolverListaUsuarios_502ag())
                {
                    dgv_502ag.Rows.Add(usuario_502ag.NombreUsuario_502ag, usuario_502ag.Rol_502ag, usuario_502ag.Nombre_502ag, usuario_502ag.Apellido_502ag, usuario_502ag.DNI_502ag, usuario_502ag.Email_502ag, usuario_502ag.isBloqueado_502ag, usuario_502ag.isActivo_502ag);
                }
            }
        }


        #region ABM
        private void buttonAltaUsuario_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Alta";
                tBModoActual_502ag.Text = "Modo Alta";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaUsuario_502ag.Enabled = false;
                buttonModificarUsuario_502ag.Enabled = false;
                buttonDesbloquear_502ag.Enabled = false;
                buttonBloquear_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonActivarDesactivar_502ag.Enabled = false;
                tBNombreUsuario_502ag.Enabled = true;
                tBNombre_502ag.Enabled = true;
                tBApellido_502ag.Enabled = true;
                tBDNI_502ag.Enabled = true;
                tBEmail_502ag.Enabled = true;
                cBRol_502ag.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonModificarUsuario_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Modificar";
                tBModoActual_502ag.Text = "Modo Modificar";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaUsuario_502ag.Enabled = false;
                buttonModificarUsuario_502ag.Enabled = false;
                buttonDesbloquear_502ag.Enabled = false;
                buttonBloquear_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonActivarDesactivar_502ag.Enabled = false;
                tBNombre_502ag.Enabled = true;
                tBApellido_502ag.Enabled = true;
                tBEmail_502ag.Enabled = true;
                cBRol_502ag.Enabled = true;

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}");}
        }
        #endregion
        private void buttonBloquear_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Bloquear";
                tBModoActual_502ag.Text = "Modo Bloquear";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaUsuario_502ag.Enabled = false;
                buttonModificarUsuario_502ag.Enabled = false;
                buttonDesbloquear_502ag.Enabled = false;
                buttonBloquear_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonActivarDesactivar_502ag.Enabled = false;
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonDesbloquear_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Desbloquear";
                tBModoActual_502ag.Text = "Modo Desbloquear";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaUsuario_502ag.Enabled = false;
                buttonModificarUsuario_502ag.Enabled = false;
                buttonDesbloquear_502ag.Enabled = false;
                buttonBloquear_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonActivarDesactivar_502ag.Enabled = false;
                if (Convert.ToBoolean(dgvUsuarios_502ag.SelectedRows[0].Cells[6].Value.ToString()) == true) { buttonAplicar_502ag.Enabled = true; }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario_502ag bllUsuario_502ag = new BLL_Usuario_502ag();
                if(opcion_502ag == "Alta")
                {
                    if (!bllUsuario_502ag.VerificarAltaUsuario_502ag(tBNombreUsuario_502ag.Text, tBNombre_502ag.Text, tBApellido_502ag.Text, tBDNI_502ag.Text, tBEmail_502ag.Text)) throw new Exception("Dato/s ingresados incorrectos");
                    if (!bllUsuario_502ag.VerificarExistenciaUsuario_502ag(tBNombreUsuario_502ag.Text, tBDNI_502ag.Text)) throw new Exception("Nombre de usuario o DNI ya existen");
                    bllUsuario_502ag.AltaUsuario_502ag(tBNombreUsuario_502ag.Text, cBRol_502ag.Text, tBNombre_502ag.Text, tBApellido_502ag.Text, tBDNI_502ag.Text, tBEmail_502ag.Text);
                    BLL_Bitacora_502ag bllBitacora_502ag = new BLL_Bitacora_502ag();
                    bllBitacora_502ag.AltaBitacora_502ag("FormABM", "Alta Usuario", 4);
                    Mostrar_502ag(dgvUsuarios_502ag);
                    tBNombreUsuario_502ag.Clear();
                    tBApellido_502ag.Clear();
                    tBNombre_502ag.Clear();
                    tBDNI_502ag.Clear();
                    tBEmail_502ag.Clear();
                }
                if(opcion_502ag == "Modificar")
                {
                    string dni_502ag = dgvUsuarios_502ag.SelectedRows[0].Cells[4].Value.ToString();
                    BE_Usuario_502ag usuarioAModificar_502ag = bllUsuario_502ag.DevolverUsuario_502ag(dni_502ag);
                    usuarioAModificar_502ag.Rol_502ag = cBRol_502ag.Text;
                    usuarioAModificar_502ag.Nombre_502ag = tBNombre_502ag.Text;
                    usuarioAModificar_502ag.Apellido_502ag = tBApellido_502ag.Text;
                    usuarioAModificar_502ag.DNI_502ag = tBDNI_502ag.Text;
                    usuarioAModificar_502ag.Email_502ag = tBEmail_502ag.Text;
                    if (!bllUsuario_502ag.VerificarModificarUsuario_502ag(usuarioAModificar_502ag)) throw new Exception("Dato/s ingresados incorrectos");
                    DialogResult dResult_502ag = MessageBox.Show($"¿Modificar a @{usuarioAModificar_502ag.NombreUsuario_502ag}?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult_502ag == DialogResult.Yes) bllUsuario_502ag.ModificarUsuario_502ag(usuarioAModificar_502ag);
                    BLL_Bitacora_502ag bllBitacora_502ag = new BLL_Bitacora_502ag();
                    bllBitacora_502ag.AltaBitacora_502ag("FormABM", "Modificación Usuario", 4);
                    Mostrar_502ag(dgvUsuarios_502ag);
                }
                if(opcion_502ag == "Desbloquear")
                {
                    if (dgvUsuarios_502ag.Rows.Count <= 0) throw new Exception();
                    string dni_502ag = dgvUsuarios_502ag.SelectedRows[0].Cells[4].Value.ToString();
                    BE_Usuario_502ag usuarioADesbloquear_502ag = bllUsuario_502ag.DevolverUsuario_502ag(dni_502ag);
                    bllUsuario_502ag.Desbloquear_502ag(usuarioADesbloquear_502ag);
                    BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                    bllBitacora.AltaBitacora_502ag("FormABM", "Desbloqueo de usuario", 4);
                    Mostrar_502ag(dgvUsuarios_502ag);
                }
                if(opcion_502ag == "Bloquear")
                {
                    if (dgvUsuarios_502ag.Rows.Count <= 0) throw new Exception();
                    BE_Usuario_502ag usuarioABloquear = bllUsuario_502ag.DevolverListaUsuarios_502ag().Find(x => x.NombreUsuario_502ag == dgvUsuarios_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    bllUsuario_502ag.Bloquear(usuarioABloquear);
                    BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                    bllBitacora.AltaBitacora_502ag("FormABM", "Bloqueo de usuario", 4);
                    Mostrar_502ag(dgvUsuarios_502ag);
                }
                opcion_502ag = "Consulta";
                tBModoActual_502ag.Text = "Modo Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaUsuario_502ag.Enabled = true;
                buttonModificarUsuario_502ag.Enabled = true;
                buttonBloquear_502ag.Enabled = true;
                buttonDesbloquear_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                buttonActivarDesactivar_502ag.Enabled = true;
                tBNombreUsuario_502ag.Enabled = false;
                tBNombre_502ag.Enabled = false;
                tBApellido_502ag.Enabled = false;
                tBDNI_502ag.Enabled = false;
                tBEmail_502ag.Enabled = false;
                cBRol_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Consulta";
                tBModoActual_502ag.Text = "Modo Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaUsuario_502ag.Enabled = true;
                buttonModificarUsuario_502ag.Enabled = true;
                buttonBloquear_502ag.Enabled = true;
                buttonDesbloquear_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                buttonActivarDesactivar_502ag.Enabled = true;
                tBNombreUsuario_502ag.Enabled = false;
                tBNombre_502ag.Enabled = false;
                tBApellido_502ag.Enabled = false;
                tBDNI_502ag.Enabled = false;
                tBEmail_502ag.Enabled = false;
                cBRol_502ag.Enabled = false;
                tBNombreUsuario_502ag.Clear();
                tBApellido_502ag.Clear();
                tBNombre_502ag.Clear();
                tBDNI_502ag.Clear();
                tBEmail_502ag.Clear();
                
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonActivarDesactivar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario_502ag bllUsuario_502ag = new BLL_Usuario_502ag();
                string dni_502ag = dgvUsuarios_502ag.SelectedRows[0].Cells[4].Value.ToString();
                BE_Usuario_502ag usuario_502ag = bllUsuario_502ag.DevolverUsuario_502ag(dni_502ag);
                if (!bllUsuario_502ag.VerificarRol_502ag(usuario_502ag))
                {
                    bllUsuario_502ag.ActivarDesactivar_502ag(usuario_502ag);
                    BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
                    bllBitacora.AltaBitacora_502ag("FormABM", "Activar/Desactivar Usuario", 4);
                    Mostrar_502ag(dgvUsuarios_502ag);
                }
                else
                {
                    throw new Exception($"El usuario que queres modificar es {$"{dgvUsuarios_502ag.SelectedRows[0].Cells[1].Value.ToString()}"}");
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        #region SelectionChanged
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvUsuarios_502ag.SelectedRows.Count > 0 && dgvUsuarios_502ag.Rows.Count > 0)
                {
                    if(opcion_502ag == "Desbloquear")
                    {
                        if (dgvUsuarios_502ag.Rows.Count == 0) { throw new Exception(); }
                        buttonAplicar_502ag.Enabled = Convert.ToBoolean(dgvUsuarios_502ag.SelectedRows[0].Cells[6].Value.ToString());
                    }
                    if(opcion_502ag == "Bloquear")
                    {
                        if (dgvUsuarios_502ag.Rows.Count == 0) { throw new Exception(); }
                        buttonAplicar_502ag.Enabled = !Convert.ToBoolean(dgvUsuarios_502ag.SelectedRows[0].Cells[6].Value.ToString());
                    }
                    if (opcion_502ag == "Modificar")
                    {
                        if (dgvUsuarios_502ag.SelectedRows.Count > 0 && dgvUsuarios_502ag.Rows.Count > 0)
                        {
                            tBNombreUsuario_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[0].Value.ToString();
                            cBRol_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[1].Value.ToString();
                            tBNombre_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[2].Value.ToString();
                            tBApellido_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[3].Value.ToString();
                            tBDNI_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[4].Value.ToString();
                            tBEmail_502ag.Text = dgvUsuarios_502ag.SelectedRows[0].Cells[5].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void rBTodos_502ag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Mostrar_502ag(dgvUsuarios_502ag);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        #endregion

    }
}
