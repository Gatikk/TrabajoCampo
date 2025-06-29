using BE_502ag;
using BLL_502ag;
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
    public partial class FormVerFacturas_502ag : Form
    {
        FormMenu_502ag menu_502ag;
        List<BE_Factura_502ag> listaFactura_502ag;
        public FormVerFacturas_502ag(FormMenu_502ag formMenu_502ag)
        {
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            menu_502ag = formMenu_502ag;
            listaFactura_502ag = bllFactura_502ag.ObtenerListaFacturas_502ag();
            MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag);
            cBOrdenarPor_502ag.SelectedIndex = 0;
            cBOrdenarPor_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBFecha_502ag.SelectedIndex = 0;
            cBFecha_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu_502ag.Show();
        }

        private void FormVerFacturas_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MostrarFacturas_502ag(DataGridView dgv_502ag, List<BE_Factura_502ag> listaFactura_502ag)
        {
            dgv_502ag.Rows.Clear();

            foreach (BE_Factura_502ag factura_502ag in listaFactura_502ag)
            {
                dgv_502ag.Rows.Add(factura_502ag.CodFactura_502ag, factura_502ag.DNICliente_502ag, factura_502ag.NombreCliente_502ag + " " + factura_502ag.ApellidoCliente_502ag, factura_502ag.MetodoPago_502ag, factura_502ag.Fecha_502ag.ToShortDateString(), factura_502ag.Hora_502ag.ToString(@"hh\:mm\:ss"), factura_502ag.NombreCombustible_502ag, factura_502ag.Monto_502ag + "$", factura_502ag.CantCargada_502ag + $" litros");
            }
        }

        private void FormVerFacturas_502ag_Activated(object sender, EventArgs e)
        {
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            listaFactura_502ag = bllFactura_502ag.ObtenerListaFacturas_502ag();
            MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag);
            cBOrdenarPor_502ag.SelectedIndex = 0;
            cBFecha_502ag.SelectedIndex = 0;
            rBDESC_502ag.Checked = true;
            ActualizarGrilla_502ag();
        }

        private void rBASC_502ag_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void rBDESC_502ag_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void cBOrdenarPor_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void cBFecha_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            listaFactura_502ag = bllFactura_502ag.ObtenerListaFacturas_502ag();
            if(cBFecha_502ag.SelectedIndex == 0)
            {
                ActualizarGrilla_502ag();
            }
            if (cBFecha_502ag.SelectedIndex == 1)
            {
                listaFactura_502ag = listaFactura_502ag.Where(x => x.Fecha_502ag.Date >= DateTime.Now.AddDays(-7).Date).ToList();
                ActualizarGrilla_502ag();

            }
            if (cBFecha_502ag.SelectedIndex == 2)
            {
                listaFactura_502ag = listaFactura_502ag.Where(x => x.Fecha_502ag.Date >= DateTime.Now.Date).ToList();
                ActualizarGrilla_502ag();
            }
        }


        private void ActualizarGrilla_502ag()
        {
            if (cBOrdenarPor_502ag.SelectedIndex == 0)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderBy(x => x.CodFactura_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderByDescending(x => x.CodFactura_502ag).ToList());
                }
            }
            if (cBOrdenarPor_502ag.SelectedIndex == 1)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderBy(x => x.NombreCombustible_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderByDescending(x => x.NombreCombustible_502ag).ToList());
                }
            }
            if (cBOrdenarPor_502ag.SelectedIndex == 2)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderBy(x => x.Monto_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderByDescending(x => x.Monto_502ag).ToList());
                }
            }
            if (cBOrdenarPor_502ag.SelectedIndex == 3)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderBy(x => x.CantCargada_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag.OrderByDescending(x => x.CantCargada_502ag).ToList());
                }
            }
        }

        private void buttonImprimirFactura_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                if (dgvFacturas_502ag.Rows.Count <= 0) throw new Exception("No hay nada para imprimir");
                BE_Factura_502ag factura_502ag = bllFactura_502ag.ObtenerFactura_502ag(int.Parse(dgvFacturas_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                bllFactura_502ag.GenerarFactura_502ag(factura_502ag);
                MessageBox.Show("Factura imprimida");
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
