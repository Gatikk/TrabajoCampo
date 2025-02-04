using BE;
using BLL;
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
        public FormABM()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            cBRol.SelectedIndex = 0;
            Mostrar(dgvUsuarios);
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
                string contraseña = dni+apellido;

                BE_Usuario usuarioAlta = new BE_Usuario(nombreUsuario, contraseña, rol, nombre, apellido, dni, email, false, 0);
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
                BE_Usuario usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as BE_Usuario;

                DialogResult dr = MessageBox.Show($"Dar de baja a @{usuarioSeleccionado.NombreUsuario}", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bllUsuario.Baja(usuarioSeleccionado);
                }
                Mostrar(dgvUsuarios);
            }
            catch (Exception ex) { MessageBox.Show($"Error {ex.Message}"); }
        }
    }
}
