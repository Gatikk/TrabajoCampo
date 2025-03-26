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
    public partial class FormABM : Form, IObserver
    {
        BLL_Usuario bllUsuario = new BLL_Usuario();
        ExpresionesRegulares re = new ExpresionesRegulares();
        FormMenu menu;
        public FormABM(FormMenu menuOriginal)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            Mostrar(dgvUsuarios);
            cBRol.SelectedIndex = 0;
            cBRol.DropDownStyle = ComboBoxStyle.DropDownList;
            buttonBloquear.Enabled = false;
            buttonDesbloquear.Enabled = false;
            buttonAltaUsuario.Enabled = false;
            buttonBajaUsuario.Enabled = false;
            TextosPorFilaSeleccionada();
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
                if(!(c is ComboBox) && !(c is TextBox))
                {
                    c.Text = traductor.Traducir(c.Name);
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
            menu.Show();
        }

        private void FormABM_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora bllBitacora = new BLL_Bitacora();
            bllBitacora.AltaBitacora("FormABM", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        public void Mostrar(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (BE_Usuario usuario in bllUsuario.DevolverListaUsuarios())
            {
                dgv.Rows.Add(usuario.NombreUsuario, usuario.Contraseña, usuario.Rol, usuario.Nombre, usuario.Apellido, usuario.DNI, usuario.Email, usuario.isBloqueado, usuario.Intentos);
            }
        }


        #region ABM
        private void buttonAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!re.reUsuario.IsMatch(tBNombreUsuario.Text)) throw new Exception("Nombre de usuario no válido");
                if (!re.reNombreApellido.IsMatch(tBNombre.Text)) throw new Exception("Nombre no válido");
                if (!re.reNombreApellido.IsMatch(tBApellido.Text)) throw new Exception("Apellido no válido");
                if (!re.reDNI.IsMatch(tBDNI.Text)) throw new Exception("DNI no válido");
                if (!re.reEmail.IsMatch(tBEmail.Text)) throw new Exception("Email no válido");
                BE_Usuario usuarioAlta = new BE_Usuario(tBNombreUsuario.Text, "", cBRol.Text, tBNombre.Text, tBApellido.Text, tBDNI.Text, tBEmail.Text, false, 0,"");
                bllUsuario.Alta(usuarioAlta);
                BLL_Bitacora bllBitacora = new BLL_Bitacora();
                bllBitacora.AltaBitacora("FormABM", "Alta Usuario", 4);
                Mostrar(dgvUsuarios);

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception("No hay nada que eliminar");
                BE_Usuario usuarioSeleccionado = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult dResult = MessageBox.Show($"¿Dar de baja a @{usuarioSeleccionado.NombreUsuario}?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes) bllUsuario.Baja(usuarioSeleccionado);
                BLL_Bitacora bllBitacora = new BLL_Bitacora();
                bllBitacora.AltaBitacora("FormABM", "Baja Usuario", 4);
                Mostrar(dgvUsuarios);
            }
            catch (Exception ex) { MessageBox.Show($"Error {ex.Message}"); }
        }
        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception("No hay nada que modificar");
                BE_Usuario usuarioSeleccionado = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult dResult = MessageBox.Show($"¿Modificar a @{usuarioSeleccionado.NombreUsuario}?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (!re.reNombreApellido.IsMatch(tBNombre.Text)) throw new Exception("Nombre no válido");
                if (!re.reNombreApellido.IsMatch(tBApellido.Text)) throw new Exception("Apellido no válido");
                if (!re.reDNI.IsMatch(tBDNI.Text)) throw new Exception("DNI no válido");
                if (!re.reEmail.IsMatch(tBEmail.Text)) throw new Exception("Email no válido");
                usuarioSeleccionado.Rol = cBRol.Text;
                usuarioSeleccionado.Nombre = tBNombre.Text;
                usuarioSeleccionado.Apellido = tBApellido.Text;
                usuarioSeleccionado.DNI = tBDNI.Text;   
                usuarioSeleccionado.Email = tBEmail.Text;
                if (dResult == DialogResult.Yes) bllUsuario.Modificar(usuarioSeleccionado);
                BLL_Bitacora bllBitacora = new BLL_Bitacora();
                bllBitacora.AltaBitacora("FormABM", "Modificación Usuario", 4);
                Mostrar(dgvUsuarios);
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}");}
        }
        #endregion

        private void buttonBloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception();        
                BE_Usuario usuarioABloquear = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                bllUsuario.Bloquear(usuarioABloquear);
                BLL_Bitacora bllBitacora = new BLL_Bitacora();
                bllBitacora.AltaBitacora("FormABM", "Bloqueo de usuario", 4);
                Mostrar(dgvUsuarios);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception();
                BE_Usuario usuarioADesbloquear = bllUsuario.DevolverListaUsuarios().Find(x=>x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                bllUsuario.Desbloquear(usuarioADesbloquear);
                BLL_Bitacora bllBitacora = new BLL_Bitacora();
                bllBitacora.AltaBitacora("FormABM", "Desbloqueo de usuario", 4);
                Mostrar(dgvUsuarios);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void VerificarButtonBloquear()
        {
            if (dgvUsuarios.Rows.Count == 0) throw new Exception();
            buttonBloquear.Enabled = !Convert.ToBoolean(dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString());
        }
        private void VerificarButtonDesbloquear()
        {
            if(dgvUsuarios.Rows.Count == 0) { throw new Exception(); }
            buttonDesbloquear.Enabled = Convert.ToBoolean(dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString());
        }
        public void VerificarButtonAlta()
        {
            buttonAltaUsuario.Enabled = !string.IsNullOrWhiteSpace(tBNombreUsuario.Text) &&
                                        !string.IsNullOrWhiteSpace(cBRol.Text) &&
                                        !string.IsNullOrWhiteSpace(tBNombre.Text) &&
                                        !string.IsNullOrWhiteSpace(tBApellido.Text)&&
                                        !string.IsNullOrWhiteSpace(tBDNI.Text)&&
                                        !string.IsNullOrWhiteSpace(tBEmail.Text);
        }
        private void VerificarButtonBaja()
        {
            if(dgvUsuarios.Rows.Count == 0) throw new Exception();
            if (SessionManager.GestorSessionManager.DevolverNombre() == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString())
            {
                buttonBajaUsuario.Enabled = false;
            }
            else
            {
                buttonBajaUsuario.Enabled = true;
            }
        }

        private void TextosPorFilaSeleccionada()
        {
            if (dgvUsuarios.SelectedRows.Count > 0 && dgvUsuarios.Rows.Count > 0)
            {
                cBRol.Text = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                tBNombre.Text = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                tBApellido.Text = dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                tBDNI.Text = dgvUsuarios.SelectedRows[0].Cells[5].Value.ToString();
                tBEmail.Text = dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        #region Eventos TextChanged y SelectionChanged
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvUsuarios.SelectedRows.Count > 0 && dgvUsuarios.Rows.Count > 0)
            {
                VerificarButtonBloquear();
                VerificarButtonDesbloquear();
                VerificarButtonBaja();
            }
            TextosPorFilaSeleccionada();    
        }

        private void tBNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }

        private void cBRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }

        private void tBNombre_TextChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }

        private void tBApellido_TextChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }

        private void tBDNI_TextChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }

        private void tBEmail_TextChanged(object sender, EventArgs e)
        {
            VerificarButtonAlta();
        }
        #endregion

    }
}
