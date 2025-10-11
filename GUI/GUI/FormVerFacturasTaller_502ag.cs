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
        public FormVerFacturasTaller_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            MostrarFacturas_502ag();
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

        private void MostrarFacturas_502ag()
        {
            try
            {
                BLL_FacturaTaller_502ag bllFactura_502ag = new BLL_FacturaTaller_502ag();
                List<BE_FacturaTaller_502ag> facturasTaller_502ag = bllFactura_502ag.ObtenerFacturasTaller_502ag();
                dgvFacturasTaller_502ag.Rows.Clear();
                foreach (BE_FacturaTaller_502ag facturaTaller_502ag in facturasTaller_502ag)
                {
                    dgvFacturasTaller_502ag.Rows.Add(facturaTaller_502ag.CodFactura_502ag, facturaTaller_502ag.DNICliente_502ag, $"{facturaTaller_502ag.NombreCliente_502ag} {facturaTaller_502ag.ApellidoCliente_502ag}", facturaTaller_502ag.MetodoPago_502ag, facturaTaller_502ag.Fecha_502ag.ToShortDateString(), facturaTaller_502ag.Hora_502ag.ToString(@"hh\:mm\:ss"), facturaTaller_502ag.Monto_502ag+"$");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void FormVerFacturasTaller_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
