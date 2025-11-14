using BE_502ag;
using BLL_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormVerFacturas_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu_502ag;
        List<BE_Factura_502ag> listaFactura_502ag;
        private string msgNadaQueImprimir_502ag, msgFacturaImprimida_502ag;
        private string msgCBCodigo_502ag, msgCBCombustible_502ag, msgCBMonto_502ag, msgCBCantidadCargada_502ag;
        private string msgCBTodos_502ag, msgCBUltimaSemana_502ag, msgCBHoy_502ag;

        public FormVerFacturas_502ag(FormMenu_502ag formMenu_502ag)
        {
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            menu_502ag = formMenu_502ag;
            listaFactura_502ag = bllFactura_502ag.ObtenerListaFacturas_502ag();
            MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag);
            cBOrdenarPor_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBFecha_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
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

        private void AgregarElementosACBOrdenarPor_502ag()
        {
            cBOrdenarPor_502ag.Items.Clear();
            cBOrdenarPor_502ag.Items.Add(msgCBCodigo_502ag);
            cBOrdenarPor_502ag.Items.Add(msgCBCombustible_502ag);
            cBOrdenarPor_502ag.Items.Add(msgCBMonto_502ag);
            cBOrdenarPor_502ag.Items.Add(msgCBCantidadCargada_502ag);
        }

        private void AgregarElementosACBFiltrarPor_502ag()
        {
            cBFecha_502ag.Items.Clear();
            cBFecha_502ag.Items.Add(msgCBTodos_502ag);
            cBFecha_502ag.Items.Add(msgCBUltimaSemana_502ag);
            cBFecha_502ag.Items.Add(msgCBHoy_502ag);
        }
        private void FormVerFacturas_502ag_Activated(object sender, EventArgs e)
        {
            AgregarElementosACBOrdenarPor_502ag();
            AgregarElementosACBFiltrarPor_502ag();
            cBOrdenarPor_502ag.SelectedIndex = 0;
            cBFecha_502ag.SelectedIndex = 0;
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            listaFactura_502ag = bllFactura_502ag.ObtenerListaFacturas_502ag();
            MostrarFacturas_502ag(dgvFacturas_502ag, listaFactura_502ag);
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
                if (dgvFacturas_502ag.Rows.Count <= 0) throw new Exception(msgNadaQueImprimir_502ag);
                BE_Factura_502ag factura_502ag = bllFactura_502ag.ObtenerFactura_502ag(int.Parse(dgvFacturas_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                bllFactura_502ag.GenerarFactura_502ag(factura_502ag);
                MessageBox.Show(msgFacturaImprimida_502ag);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);

                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
                if (c_502ag is DataGridView)
                {
                    DataGridView dgv_502ag = c_502ag as DataGridView;
                    foreach (DataGridViewColumn col_502ag in dgv_502ag.Columns)
                    {
                        col_502ag.HeaderText = traductor_502ag.Traducir_502ag(col_502ag.Name);
                    }
                }
            }
            msgNadaQueImprimir_502ag = traductor_502ag.Traducir_502ag("msgNadaQueImprimir_502ag");
            msgFacturaImprimida_502ag = traductor_502ag.Traducir_502ag("msgFacturaImprimida_502ag");
            msgCBCodigo_502ag = traductor_502ag.Traducir_502ag("msgCBCodigo_502ag");
            msgCBCombustible_502ag = traductor_502ag.Traducir_502ag("msgCBCombustible_502ag");
            msgCBMonto_502ag = traductor_502ag.Traducir_502ag("msgCBMonto_502ag");
            msgCBCantidadCargada_502ag = traductor_502ag.Traducir_502ag("msgCBCantidadCargada_502ag");
            msgCBTodos_502ag = traductor_502ag.Traducir_502ag("msgCBTodos_502ag");
            msgCBUltimaSemana_502ag = traductor_502ag.Traducir_502ag("msgCBUltimaSemana_502ag");
            msgCBHoy_502ag = traductor_502ag.Traducir_502ag("msgCBHoy_502ag");


        }
    }
}
