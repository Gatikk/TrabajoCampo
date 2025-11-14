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
    public partial class FormVerFacturasTaller_502ag : Form
    {
        List<BE_FacturaTaller_502ag> listaFacturas_502ag = new List<BE_FacturaTaller_502ag>();
        public FormVerFacturasTaller_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            AgregarElementosACBOrdenarPor_502ag();
            AgregarElementosACBFiltrarPor_502ag();
            cBOrdenarPor_502ag.SelectedIndex = 0;
            cBFecha_502ag.SelectedIndex = 0;
            rBDESC_502ag.Checked = true;
            CargarFacturas_502ag();
            MostrarFacturas_502ag(listaFacturas_502ag);
            ActualizarGrilla_502ag();
        }

        private void CargarFacturas_502ag()
        {
            BLL_FacturaTaller_502ag bllFacturaTaller_502ag = new BLL_FacturaTaller_502ag();
            listaFacturas_502ag = bllFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
        }

        private void buttonImprimirFactura_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_FacturaTaller_502ag bllFactura_502ag = new BLL_FacturaTaller_502ag();
                if (dgvFacturasTaller_502ag.Rows.Count <= 0) throw new Exception("No hay nada para imprimir");
                bllFactura_502ag.GenerarFacturaTallerPDF_502ag(dgvFacturasTaller_502ag.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("Factura imprimida con éxito");
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag menuForm_502ag = new FormMenu_502ag();
            menuForm_502ag.Show();
        }

        private void MostrarFacturas_502ag(List<BE_FacturaTaller_502ag> listaFacturas_502ag)
        {
            try
            {
                BLL_FacturaTaller_502ag bllFactura_502ag = new BLL_FacturaTaller_502ag();
                dgvFacturasTaller_502ag.Rows.Clear();
                foreach (BE_FacturaTaller_502ag facturaTaller_502ag in listaFacturas_502ag)
                {
                    dgvFacturasTaller_502ag.Rows.Add(facturaTaller_502ag.CodFactura_502ag, facturaTaller_502ag.DNICliente_502ag, $"{facturaTaller_502ag.NombreCliente_502ag} {facturaTaller_502ag.ApellidoCliente_502ag}", facturaTaller_502ag.MetodoPago_502ag, facturaTaller_502ag.Fecha_502ag.ToShortDateString(), facturaTaller_502ag.Hora_502ag.ToString(@"hh\:mm\:ss"), facturaTaller_502ag.Monto_502ag+"$");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void AgregarElementosACBOrdenarPor_502ag()
        {
            cBOrdenarPor_502ag.Items.Clear();
            cBOrdenarPor_502ag.Items.Add("DNI");
            cBOrdenarPor_502ag.Items.Add("Monto");
        }

        private void AgregarElementosACBFiltrarPor_502ag()
        {
            cBFecha_502ag.Items.Clear();
            cBFecha_502ag.Items.Add("Todos");
            cBFecha_502ag.Items.Add("Última Semana");
            cBFecha_502ag.Items.Add("Hoy");
        }


        private void FormVerFacturasTaller_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void rBASC_502ag_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void rBDESC_502ag_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void ActualizarGrilla_502ag()
        {
            if (cBOrdenarPor_502ag.SelectedIndex == 0)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(listaFacturas_502ag.OrderBy(x => x.DNICliente_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(listaFacturas_502ag.OrderByDescending(x => x.DNICliente_502ag).ToList());
                }
            }
            if (cBOrdenarPor_502ag.SelectedIndex == 1)
            {
                if (rBASC_502ag.Checked)
                {
                    MostrarFacturas_502ag(listaFacturas_502ag.OrderBy(x => x.Monto_502ag).ToList());
                }
                if (rBDESC_502ag.Checked)
                {
                    MostrarFacturas_502ag(listaFacturas_502ag.OrderByDescending(x => x.Monto_502ag).ToList());
                }
            }
        }

        private void cBOrdenarPor_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_502ag();
        }

        private void cBFecha_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL_FacturaTaller_502ag bllFacturaTaller_502ag = new BLL_FacturaTaller_502ag();
            listaFacturas_502ag = bllFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
            if (cBFecha_502ag.SelectedIndex == 0)
            {
                ActualizarGrilla_502ag();
            }
            if (cBFecha_502ag.SelectedIndex == 1)
            {
                listaFacturas_502ag = listaFacturas_502ag.Where(x => x.Fecha_502ag.Date >= DateTime.Now.AddDays(-7).Date).ToList();
                ActualizarGrilla_502ag();

            }
            if (cBFecha_502ag.SelectedIndex == 2)
            {
                listaFacturas_502ag = listaFacturas_502ag.Where(x => x.Fecha_502ag.Date >= DateTime.Now.Date).ToList();
                ActualizarGrilla_502ag();
            }
        }
    }
}
