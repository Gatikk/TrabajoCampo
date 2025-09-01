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
            Mostrar_502ag();       
        }

        private void buttonSeleccionarOrden_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                if(dgvCombustibles_502ag.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una orden de trabajo.");
                ordenTrabajoActual_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                buttonSeleccionarOrden_502ag.Enabled = false;
                dgvCombustibles_502ag.Enabled = false;
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                BE_Vehiculo_502ag vehiculoActual_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(ordenTrabajoActual_502ag.PatenteVehiculo_502ag);
                if(vehiculoActual_502ag != null)
                {
                    tBPatente_502ag.Text = vehiculoActual_502ag.Patente_502ag;
                    tBMarca_502ag.Text = vehiculoActual_502ag.Marca_502ag;
                    tBModelo_502ag.Text = vehiculoActual_502ag.Modelo_502ag;
                    tBAnio_502ag.Text = vehiculoActual_502ag.Anio_502ag.ToString();
                }
                else
                {
                    ordenTrabajoActual_502ag = null;
                    buttonSeleccionarOrden_502ag.Enabled = true;
                    dgvCombustibles_502ag.Enabled = true;
                    throw new Exception("Vehículo no encontrado.");
                }

            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVerObservacion_502ag_Click(object sender, EventArgs e)
        {
            if(ordenTrabajoActual_502ag != null)
            {
                MessageBox.Show($"{ordenTrabajoActual_502ag.Observaciones_502ag}");
            }
            else
            {
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                BE_OrdenTrabajo_502ag ordenTrabajoSeleccionado_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show($"{ordenTrabajoSeleccionado_502ag.Observaciones_502ag}");
            }
        }

        private void buttonGenerarDiagnosticoFinal_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
                if(ordenTrabajoActual_502ag == null) throw new Exception("Debe seleccionar una orden de trabajo.");
                if(string.IsNullOrEmpty(rTBDescripcionFinal_502ag.Text)) throw new Exception("Debe ingresar una descripción final.");
                if(rTBDescripcionFinal_502ag.Text.Length > 200) throw new Exception("La descripción final no puede superar los 200 caracteres.");
                string costoPartesString_502ag = tBCostoPartes_502ag.Text.Trim();
                decimal.TryParse(costoPartesString_502ag, out decimal costoPartes_502ag);
                string manoObraString_502ag = nUDHoras_502ag.Text.Trim();
                decimal.TryParse(manoObraString_502ag, out decimal manoObra_502ag);
                if(costoPartes_502ag < 0) throw new Exception("El costo de partes no puede ser negativo.");
                if(manoObra_502ag < 0) throw new Exception("La cantidad de horas de mano de obra no puede ser negativa.");
                bllDiagnosticoFinal_502ag.GenerarDiagnosticoFinal_502ag(ordenTrabajoActual_502ag, rTBDescripcionFinal_502ag.Text, manoObra_502ag, costoPartes_502ag);
                MessageBox.Show("Diagnóstico final generado con éxito.");
                LimpiarPantalla_502ag();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void Mostrar_502ag()
        {
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            dgvCombustibles_502ag.Rows.Clear();
            List<BE_OrdenTrabajo_502ag> listaOrdenesAbiertas_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoAbierta_502ag();
            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in listaOrdenesAbiertas_502ag)
            {
                dgvCombustibles_502ag.Rows.Add(ordenTrabajo_502ag.CodOrdenTrabajo_502ag, ordenTrabajo_502ag.PatenteVehiculo_502ag, ordenTrabajo_502ag.Fecha_502ag.ToString("dd/MM/yyyy"), ordenTrabajo_502ag.Hora_502ag.ToString(@"hh\:mm"));
            }
        }

        private void buttonLimpiarPantalla_502ag_Click(object sender, EventArgs e)
        {
            try 
            {
                LimpiarPantalla_502ag();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }    
        }

        private void LimpiarPantalla_502ag()
        {
            Mostrar_502ag();
            ordenTrabajoActual_502ag = null;
            dgvCombustibles_502ag.Enabled = true;
            buttonSeleccionarOrden_502ag.Enabled = true;
            tBPatente_502ag.Clear();
            tBMarca_502ag.Clear();
            tBModelo_502ag.Clear();
            tBAnio_502ag.Clear();
            rTBDescripcionFinal_502ag.Clear();
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }
    }
}
