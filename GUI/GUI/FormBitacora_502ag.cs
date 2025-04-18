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
    public partial class FormBitacora_502ag : Form
    {
        FormMenu_502ag menu;
        public FormBitacora_502ag(FormMenu_502ag menuOriginal)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            Mostrar(dgvBitacora);
            menu = menuOriginal;
        }

        private void FormBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormBitacora", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        public void Mostrar(DataGridView dgv)
        {
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            dgv.Rows.Clear();
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "NombreUsuario";
            dgv.Columns[2].HeaderText = "Fecha";
            dgv.Columns[3].HeaderText = "Hora";
            dgv.Columns[4].HeaderText = "Módulo";
            dgv.Columns[5].HeaderText = "Descripción";
            dgv.Columns[6].HeaderText = "Criticidad";

            foreach (BE_Bitacora_502ag bitacora in bllBitacora.DevolverListaBitacora())
            {
                dgv.Rows.Add(bitacora.ID_Bitacora, bitacora.NombreUsuario, bitacora.Fecha.ToShortDateString(), bitacora.Hora, bitacora.Modulo, bitacora.Descripcion, bitacora.Criticidad);
            }
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }
    }
}
