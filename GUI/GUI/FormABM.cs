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
        public FormABM()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            cBRol.SelectedIndex = 0;
            BLL_Usuario bllUsuario = new BLL_Usuario();
            Mostrar(dgvUsuarios, bllUsuario.DevolverListaUsuarios());
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

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        public void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }
    }
}
