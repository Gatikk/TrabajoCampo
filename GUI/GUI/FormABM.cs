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
    public partial class FormABM : Form
    {
        BLL_Usuario bllUsuario = new BLL_Usuario();
        ExpresionesRegulares re = new ExpresionesRegulares();   
        public FormABM()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            cBRol.SelectedIndex = 0;
            Mostrar(dgvUsuarios);
            labelNombreUsuario.Text = "Usuario";
            labelRol.Text = "Rol";
            labelNombre.Text = "Nombre";
            labelApellido.Text = "Apellido";
            labelDNI.Text = "DNI";
            labelEmail.Text = "Email";
            buttonBloquear.Enabled = false;
            buttonDesbloquear.Enabled = false;
            buttonAltaUsuario.Enabled = false;
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            FormMenu menuForm = new FormMenu();
            this.Hide();
            menuForm.Show();
        }

        private void FormABM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void Mostrar(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns[0].HeaderText = "Usuario";
            dgv.Columns[1].HeaderText = "Contraseña";
            dgv.Columns[2].HeaderText = "Rol";
            dgv.Columns[3].HeaderText = "Nombre";
            dgv.Columns[4].HeaderText = "Apellido";
            dgv.Columns[5].HeaderText = "DNI";
            dgv.Columns[6].HeaderText = "Email";
            dgv.Columns[7].HeaderText = "Bloqueado";
            dgv.Columns[8].HeaderText = "Intentos";

            foreach (BE_Usuario usuario in bllUsuario.DevolverListaUsuarios())
            {
                dgv.Rows.Add(usuario.NombreUsuario, usuario.Contraseña, usuario.Rol, usuario.Nombre, usuario.Apellido, usuario.DNI, usuario.Email, usuario.isBloqueado, usuario.Intentos);
            }
        }

        private void buttonAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = tBNombreUsuario.Text;
                string rol = cBRol.Text;
                string nombre = tBNombre.Text;
                string apellido = tBApellido.Text;
                string dni = tBDNI.Text;
                string email = tBEmail.Text;


                if (!re.reUsuario.IsMatch(nombreUsuario)) throw new Exception("Nombre de usuario no válido");
                if (!re.reNombreApellido.IsMatch(nombre)) throw new Exception("Nombre no válido");
                if (!re.reNombreApellido.IsMatch(apellido)) throw new Exception("Apellido no válido");
                if (!re.reDNI.IsMatch(dni)) throw new Exception("DNI no válido");
                if (!re.reEmail.IsMatch(email)) throw new Exception("Email no válido");


                BE_Usuario usuarioAlta = new BE_Usuario(nombreUsuario, "", rol, nombre, apellido, dni, email, false, 0);
                bllUsuario.Alta(usuarioAlta);
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
                DialogResult dResult = MessageBox.Show($"Dar de baja a @{usuarioSeleccionado.NombreUsuario}", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes) bllUsuario.Baja(usuarioSeleccionado);
                Mostrar(dgvUsuarios);
            }
            catch (Exception ex) { MessageBox.Show($"Error {ex.Message}"); }
        }
        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception("No hay nada que eliminar");
                BE_Usuario usuarioSeleccionado = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}");}
        }

        private void buttonBloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count <= 0) throw new Exception();
                var assad = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                BE_Usuario usuarioABloquear = bllUsuario.DevolverListaUsuarios().Find(x => x.NombreUsuario == dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                bllUsuario.Bloquear(usuarioABloquear);
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
                Mostrar(dgvUsuarios);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
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

        private void VerificarButtonBloquear()
        {
            if (dgvUsuarios.Rows.Count == 0) { throw new Exception(); }
            var asas = dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString();
            buttonBloquear.Enabled = !Convert.ToBoolean(dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString());
        }
        private void VerificarButtonDesbloquear()
        {
            if(dgvUsuarios.Rows.Count == 0) { throw new Exception(); }
            buttonDesbloquear.Enabled = Convert.ToBoolean(dgvUsuarios.SelectedRows[0].Cells[7].Value.ToString());
        }


        #region Eventos TextChanged y SelectionChanged
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvUsuarios.SelectedRows.Count > 0 && dgvUsuarios.Rows.Count > 0)
            {
                VerificarButtonBloquear();
                VerificarButtonDesbloquear();
            }
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
