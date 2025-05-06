using SE_502ag;
using SERVICIOS_502ag;
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
            SER_GestorBitacora_502ag bllBitacora = new SER_GestorBitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormBitacora", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        public void Mostrar(DataGridView dgv)
        {
            SER_GestorBitacora_502ag bllBitacora = new SER_GestorBitacora_502ag();
            dgv.Rows.Clear();
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "NombreUsuario";
            dgv.Columns[2].HeaderText = "Fecha";
            dgv.Columns[3].HeaderText = "Hora";
            dgv.Columns[4].HeaderText = "Módulo";
            dgv.Columns[5].HeaderText = "Descripción";
            dgv.Columns[6].HeaderText = "Criticidad";

            foreach (SE_Bitacora_502ag bitacora in bllBitacora.ObtenerBitacora_502ag())
            {
                dgv.Rows.Add(bitacora.CodBitacora_502ag, bitacora.NombreUsuario_502ag, bitacora.Fecha_502ag.ToShortDateString(), bitacora.Hora_502ag, bitacora.Modulo_502ag, bitacora.Descripcion_502ag, bitacora.Criticidad_502ag);
            }
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }
    }
}
