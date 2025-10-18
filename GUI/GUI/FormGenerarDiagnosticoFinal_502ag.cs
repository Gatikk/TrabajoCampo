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
using BE_502ag;
using BLLS_502ag;

namespace GUI
{
    public partial class FormGenerarDiagnosticoFinal_502ag : Form
    {
        BE_OrdenTrabajo_502ag ordenTrabajoActual_502ag;
        public FormGenerarDiagnosticoFinal_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            MostrarOrdenes_502ag();
            MostrarEnComboBox_502ag();
            if (cBRepuesto_502ag.Items.Count > 0) cBRepuesto_502ag.SelectedIndex = 0;
        }

        private void buttonSeleccionarOrden_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                if (dgvOrdenes_502ag.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una orden de trabajo.");
                ordenTrabajoActual_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(dgvOrdenes_502ag.SelectedRows[0].Cells[0].Value.ToString());
                buttonSeleccionarOrden_502ag.Enabled = false;
                dgvOrdenes_502ag.Enabled = false;
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                BE_Vehiculo_502ag vehiculoActual_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(ordenTrabajoActual_502ag.PatenteVehiculo_502ag);
                if (vehiculoActual_502ag != null)
                {
                    tBPatente_502ag.Text = vehiculoActual_502ag.Patente_502ag;
                    tBMarca_502ag.Text = vehiculoActual_502ag.Marca_502ag;
                    tBModelo_502ag.Text = vehiculoActual_502ag.Modelo_502ag;
                    tBAnio_502ag.Text = vehiculoActual_502ag.Anio_502ag.ToString();
                    BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOT_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
                    if (bllRepuestoOT_502ag.ObtenerDatosIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag).Count > 0)
                    {
                        MostrarRepuestos_502ag();
                    }
                }
                else
                {
                    ordenTrabajoActual_502ag = null;
                    buttonSeleccionarOrden_502ag.Enabled = true;
                    dgvOrdenes_502ag.Enabled = true;
                    throw new Exception("Vehículo no encontrado.");
                }

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVerObservacion_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenes_502ag.SelectedRows.Count == 0)
                {
                    throw new Exception("Debe seleccionar una orden de trabajo.");
                }
                else
                {
                    if (ordenTrabajoActual_502ag != null)
                    {
                        MessageBox.Show($"{ordenTrabajoActual_502ag.Observaciones_502ag}");
                    }
                    else
                    {
                        BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                        BE_OrdenTrabajo_502ag ordenTrabajoSeleccionado_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(dgvOrdenes_502ag.SelectedRows[0].Cells[0].Value.ToString());
                        MessageBox.Show($"{ordenTrabajoSeleccionado_502ag.Observaciones_502ag}");
                    }
                }

            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonGenerarDiagnosticoFinal_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
                if (ordenTrabajoActual_502ag == null) throw new Exception("Debe seleccionar una orden de trabajo.");
                if (string.IsNullOrEmpty(rTBDescripcionFinal_502ag.Text)) throw new Exception("Debe ingresar una descripción final.");
                if (rTBDescripcionFinal_502ag.Text.Length > 200) throw new Exception("La descripción final no puede superar los 200 caracteres.");
                string manoObraString_502ag = nUDHoras_502ag.Text.Trim();
                decimal.TryParse(manoObraString_502ag, out decimal manoObra_502ag);
                if (manoObra_502ag < 0) throw new Exception("La cantidad de horas de mano de obra no puede ser negativa.");
                decimal costoPartes_502ag = 0;
                foreach (DataGridViewRow row in dgvRepuestos_502ag.Rows)
                {
                    decimal precioUnitario_502ag = decimal.Parse(row.Cells[2].Value.ToString());
                    int cantidad_502ag = int.Parse(row.Cells[3].Value.ToString());
                    costoPartes_502ag += precioUnitario_502ag * cantidad_502ag;
                }

                bllDiagnosticoFinal_502ag.GenerarDiagnosticoFinal_502ag(ordenTrabajoActual_502ag, rTBDescripcionFinal_502ag.Text, manoObra_502ag, costoPartes_502ag);
                MessageBox.Show("Diagnóstico final generado con éxito.");
                LimpiarPantalla_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void MostrarOrdenes_502ag()
        {
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            dgvOrdenes_502ag.Rows.Clear();
            List<BE_OrdenTrabajo_502ag> listaOrdenesAbiertas_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoAbierta_502ag();
            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in listaOrdenesAbiertas_502ag)
            {
                dgvOrdenes_502ag.Rows.Add(ordenTrabajo_502ag.CodOrdenTrabajo_502ag, ordenTrabajo_502ag.PatenteVehiculo_502ag, ordenTrabajo_502ag.Fecha_502ag.ToString("dd/MM/yyyy"), ordenTrabajo_502ag.Hora_502ag.ToString(@"hh\:mm"));
            }
        }

        private void buttonLimpiarPantalla_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarPantalla_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void LimpiarPantalla_502ag()
        {
            MostrarOrdenes_502ag();
            ordenTrabajoActual_502ag = null;
            dgvOrdenes_502ag.Enabled = true;
            buttonSeleccionarOrden_502ag.Enabled = true;
            tBPatente_502ag.Clear();
            tBMarca_502ag.Clear();
            tBModelo_502ag.Clear();
            tBAnio_502ag.Clear();
            rTBDescripcionFinal_502ag.Clear();
            dgvRepuestos_502ag.Rows.Clear();
            nUDRepuesto_502ag.Value = 0;
            nUDHoras_502ag.Value = 1;
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }

        private void buttonAgregar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (ordenTrabajoActual_502ag == null) throw new Exception("Debe haber una orden de trabajo seleccionada");
                if (nUDRepuesto_502ag.Value <= 0) throw new Exception("La cantidad de repuestos debe ser mayor a 0.");
                if (cBRepuesto_502ag.SelectedItem == null || string.IsNullOrWhiteSpace(cBRepuesto_502ag.SelectedItem.ToString()))throw new Exception("Debe seleccionar un repuesto.");
                int codRepuesto_502ag = int.Parse(cBRepuesto_502ag.SelectedItem.ToString().Split(',')[0]);
                BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOT_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
                List<BE_RepuestoOrdenTrabajo_502ag> repuestosOT_502ag = bllRepuestoOT_502ag.ObtenerDatosIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag);
                if (repuestosOT_502ag.Find(x => x.CodigoRepuesto_502ag == codRepuesto_502ag) == null)
                {
                    bllRepuestoOT_502ag.AltaIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag, codRepuesto_502ag, int.Parse(nUDRepuesto_502ag.Value.ToString()));      
                }
                else
                 {
                    BE_RepuestoOrdenTrabajo_502ag repuestoOT_502ag = repuestosOT_502ag.FirstOrDefault(x => x.CodigoRepuesto_502ag == codRepuesto_502ag && x.CodigoOT_502ag == ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag);
                    bllRepuestoOT_502ag.ModificarIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag, codRepuesto_502ag, int.Parse(nUDRepuesto_502ag.Value.ToString()), repuestoOT_502ag.Cantidad_502ag);
                }
                MostrarEnComboBox_502ag();
                MostrarRepuestos_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        public void MostrarEnComboBox_502ag()
        {
            cBRepuesto_502ag.Items.Clear();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            List<BE_Repuesto_502ag> listaRepuestos_502ag = bllRepuesto_502ag.ObtenerListaRepuestos_502ag();
            foreach (BE_Repuesto_502ag repuesto_502ag in listaRepuestos_502ag)
            {
                cBRepuesto_502ag.Items.Add(repuesto_502ag.Codigo_502ag + ", " + repuesto_502ag.Descripcion_502ag + ", x" + repuesto_502ag.CantidadDisponible_502ag);
            }
        }

        private void cBRepuesto_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nUDRepuesto_502ag.Value = 0;
                BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
                BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(int.Parse(cBRepuesto_502ag.SelectedItem.ToString().Split(',')[0]));
                nUDRepuesto_502ag.Maximum = repuesto_502ag.CantidadDisponible_502ag;

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

        }

        private void MostrarRepuestos_502ag()
        {
            dgvRepuestos_502ag.Rows.Clear();
            BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOT_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            foreach (BE_RepuestoOrdenTrabajo_502ag repuestoOT_502ag in bllRepuestoOT_502ag.ObtenerDatosIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag))
            {
                BE_Repuesto_502ag repuestoDatos_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(repuestoOT_502ag.CodigoRepuesto_502ag);
                dgvRepuestos_502ag.Rows.Add(repuestoDatos_502ag.Codigo_502ag, repuestoDatos_502ag.Descripcion_502ag, repuestoDatos_502ag.Precio_502ag, repuestoOT_502ag.Cantidad_502ag);
            }
        }

        private void buttonBajaRepuesto_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOT_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
                if(dgvRepuestos_502ag.Rows.Count <= 0) throw new Exception("No hay repuestos para eliminar.");
                if(dgvRepuestos_502ag.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un repuesto para eliminar.");
                bllRepuestoOT_502ag.BajaIntermedia_502ag(ordenTrabajoActual_502ag.CodOrdenTrabajo_502ag, int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[3].Value.ToString()));
                MostrarEnComboBox_502ag();
                MostrarRepuestos_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void FormGenerarDiagnosticoFinal_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
