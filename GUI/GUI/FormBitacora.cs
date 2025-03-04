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
    public partial class FormBitacora : Form
    {
        BLL_Bitacora bllBitacora;
        public FormBitacora()
        {
            InitializeComponent();
            bllBitacora = new BLL_Bitacora();
            Mostrar(dgvBitacora);
        }

        private void FormBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void Mostrar(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "NombreUsuario";
            dgv.Columns[2].HeaderText = "Fecha";
            dgv.Columns[3].HeaderText = "Hora";
            dgv.Columns[4].HeaderText = "Módulo";
            dgv.Columns[5].HeaderText = "Descripción";
            dgv.Columns[6].HeaderText = "Criticidad";

            foreach (BE_Bitacora bitacora in bllBitacora.DevolverListaBitacora())
            {
                dgv.Rows.Add(bitacora.ID_Bitacora, bitacora.NombreUsuario, bitacora.Fecha, bitacora.Hora, bitacora.Modulo, bitacora.Descripcion, bitacora.Criticidad);
            }
        }
    }
}
