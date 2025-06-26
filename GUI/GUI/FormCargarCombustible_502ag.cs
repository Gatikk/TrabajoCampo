using BE_502ag;
using BLL_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormCargarCombustible_502ag : Form
    {
        private FormMenu_502ag menu_502ag;
        private BE_Combustible_502ag combustibleSeleccionado_502ag;
        private BE_Vehiculo_502ag vehiculoActual_502ag;
        private Timer timerCarga_502ag = new Timer();
        private const decimal litrosPorCiclo_502ag = 2;
        private decimal litrosRestantes_502ag = 0;
        private decimal totalCargado_502ag = 0;
        private int estadoActual_502ag = 0;
        private bool estadoCargando_502ag = false;
        

        BE_Factura_502ag facturaActual_502ag;
        public FormCargarCombustible_502ag(FormMenu_502ag formMenu_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            menu_502ag = formMenu_502ag;
            InitializeComponent();
            EstadoActual_502ag();
            MostrarCombustibles_502ag(dgvCombustibles_502ag);
            MostrarFacturas_502ag(dgvFacturas_502ag);
            timerCarga_502ag.Interval = 1000; 
            timerCarga_502ag.Tick += TimerCarga_502ag_Tick;
        }


        private void FormCargarCombustible_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (estadoCargando_502ag)
                {
                    BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                    facturaActual_502ag.CantCargada_502ag = totalCargado_502ag;
                    facturaActual_502ag.Monto_502ag = totalCargado_502ag * combustibleSeleccionado_502ag.PrecioPorLitro_502ag;
                    facturaActual_502ag.EstadoFactura_502ag++;
                    bllFactura_502ag.ActualizarFacturaCargaFinalizada_502ag(facturaActual_502ag);
                }

                Environment.Exit(0);
                
            }catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonSeleccionarCombustible_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                BLL_Factura_502ag bllFactura_502ag  = new BLL_Factura_502ag();
                if (dgvCombustibles_502ag.Rows.Count <= 0) { throw new Exception("No hay combustibles para seleccionar"); }
                string codCombustible_502ag = dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString();
                combustibleSeleccionado_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(codCombustible_502ag);
                if(combustibleSeleccionado_502ag.CantDisponible_502ag <= 0) { throw new Exception("No hay combustible disponible");}
                DialogResult dResult_502ag = MessageBox.Show($"¿Seguro que desea seleccionar el combustible {combustibleSeleccionado_502ag.Nombre_502ag}?", "Seleccionar Combustible", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dResult_502ag == DialogResult.Yes)
                {
                    tBCodigo_502ag.Text = combustibleSeleccionado_502ag.CodCombustible_502ag;
                    tBCodigo_502ag.Enabled = true;
                    buttonSeleccionarCombustible_502ag.Enabled = false;
                    buttonComenzarCarga_502ag.Enabled = true;
                    rBCantidad_502ag.Enabled = true;
                    rBMonto_502ag.Enabled = true;
                    tBCantidad_502ag.Enabled = true;
                    buttonSeleccionarFactura_502ag.Enabled = false;
                    facturaActual_502ag = bllFactura_502ag.AltaFactura_502ag(combustibleSeleccionado_502ag.CodCombustible_502ag, combustibleSeleccionado_502ag.Nombre_502ag);
                    MostrarFacturas_502ag(dgvFacturas_502ag);
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void MostrarCombustibles_502ag(DataGridView dgv_502ag)
        {
            BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
            dgv_502ag.Rows.Clear();
            foreach (BE_Combustible_502ag combustible_502ag in bllCombustible_502ag.ObtenerListaCombustibles_502ag())
            {
                dgv_502ag.Rows.Add(combustible_502ag.CodCombustible_502ag, combustible_502ag.Nombre_502ag, combustible_502ag.CantDisponible_502ag+" litros", combustible_502ag.PrecioPorLitro_502ag+"$");
            }
        }

        private void MostrarFacturas_502ag(DataGridView dgv_502ag)
        {
            BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
            dgv_502ag.Rows.Clear();
            foreach (BE_Factura_502ag factura_502ag in bllFactura_502ag.ObtenerListaFacturasNoFacturadas_502ag())
            {
                string estadoFacturaString_502ag = ""; 
                if(factura_502ag.EstadoFactura_502ag == 1)
                {
                    estadoFacturaString_502ag = "Pendiente de carga";
                }
                if (factura_502ag.EstadoFactura_502ag == 2)
                {
                    estadoFacturaString_502ag = "Carga Finalizada";
                }
                if (factura_502ag.EstadoFactura_502ag == 3)
                {
                    estadoFacturaString_502ag = "Cliente identificado";
                }
                dgv_502ag.Rows.Add(factura_502ag.CodFactura_502ag, factura_502ag.NombreCombustible_502ag, estadoFacturaString_502ag);
            }
        }

        private void buttonComenzarCarga_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reDecimal_502ag = new Regex(@"^\d+(\.\d{1,2})?$");
                if(!reDecimal_502ag.IsMatch(tBCantidad_502ag.Text) || tBCantidad_502ag.Text == ""){throw new Exception("Ingrese una cantidad válida"); }
                totalCargado_502ag = 0;
                decimal cantidadACargar_502ag = 0;
                buttonComenzarCarga_502ag.Enabled = false;
                buttonDetenerCarga_502ag.Enabled = true;
                rTBDetallesCarga_502ag.Enabled = true;
                tBCodigo_502ag.Enabled = false;
                rBMonto_502ag.Enabled = false;
                rBCantidad_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = false;
                if (rBCantidad_502ag.Checked)
                {
                    cantidadACargar_502ag = decimal.Parse(tBCantidad_502ag.Text);
                }
                if (rBMonto_502ag.Checked)
                {
                    cantidadACargar_502ag = decimal.Parse(tBCantidad_502ag.Text) / combustibleSeleccionado_502ag.PrecioPorLitro_502ag;
                }
                vehiculoActual_502ag = new BE_Vehiculo_502ag();
                decimal espacioDisponible_502ag = vehiculoActual_502ag.CantidadMaxima_502ag - vehiculoActual_502ag.CantidadActual_502ag;
                litrosRestantes_502ag = Math.Min(cantidadACargar_502ag, Math.Min(espacioDisponible_502ag, combustibleSeleccionado_502ag.CantDisponible_502ag));
                rTBDetallesCarga_502ag.AppendText("Iniciando carga...\n");
                timerCarga_502ag.Start();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void TimerCarga_502ag_Tick(object sender, EventArgs e)
        {
            try
            {
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                bool finalizado_502ag = bllVehiculo_502ag.SimulacionCarga_502ag(vehiculoActual_502ag, litrosPorCiclo_502ag, litrosRestantes_502ag);
                decimal litrosACargar_502ag = Math.Min(litrosPorCiclo_502ag, Math.Min(litrosRestantes_502ag, vehiculoActual_502ag.CantidadMaxima_502ag - vehiculoActual_502ag.CantidadActual_502ag));

                estadoCargando_502ag = true;
                litrosRestantes_502ag -= litrosACargar_502ag;
                totalCargado_502ag += litrosACargar_502ag;

                if(combustibleSeleccionado_502ag != null)
                {
                    combustibleSeleccionado_502ag.CantDisponible_502ag -= litrosACargar_502ag;
                    bllCombustible_502ag.ActualizarExistenciaCombustible_502ag(combustibleSeleccionado_502ag);
                }
                MostrarCombustibles_502ag(dgvCombustibles_502ag);

                rTBDetallesCarga_502ag.Clear();
                rTBDetallesCarga_502ag.AppendText($"Cantidad actual: {vehiculoActual_502ag.CantidadActual_502ag:F2} / {vehiculoActual_502ag.CantidadMaxima_502ag:F2} litros\n" +
                    $"Cargado hasta el momento: {totalCargado_502ag:F2} litros");
                if (finalizado_502ag)
                {
                    timerCarga_502ag.Stop();
                    buttonFinalizarCarga_502ag.Enabled = true;
                    buttonDetenerCarga_502ag.Enabled = false;
                    rTBDetallesCarga_502ag.AppendText($"\nCarga finalizada.\nTotal cargado: {totalCargado_502ag:F2} litros\n");
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonRegistrarCliente_502ag_Click(object sender, EventArgs e)
        {
            FormRegistrarCliente_502ag registrarClienteForm_502ag = new FormRegistrarCliente_502ag();
            registrarClienteForm_502ag.Show();
        }

        private void buttonIdentificarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                string dni_502ag = tBDNI_502ag.Text;
                BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(dni_502ag);
                if(cliente_502ag == null) 
                {
                    tBNombre_502ag.Enabled = false;
                    tBApellido_502ag.Enabled = false;
                    tBNombre_502ag.Clear();
                    tBApellido_502ag.Clear();
                    buttonCobrarCliente_502ag.Enabled = false;
                    throw new Exception("Cliente no encontrado");
                }
                tBNombre_502ag.Enabled = true;
                tBNombre_502ag.Text = cliente_502ag.Nombre_502ag;
                tBApellido_502ag.Enabled = true;
                tBApellido_502ag.Text = cliente_502ag.Apellido_502ag;
                buttonCobrarCliente_502ag.Enabled = true;

            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCobrarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();

                facturaActual_502ag.DNICliente_502ag = tBDNI_502ag.Text;
                facturaActual_502ag.NombreCliente_502ag = tBNombre_502ag.Text;
                facturaActual_502ag.ApellidoCliente_502ag = tBApellido_502ag.Text;
                facturaActual_502ag.EstadoFactura_502ag++;
                facturaActual_502ag.Fecha_502ag = DateTime.Now.Date;
                facturaActual_502ag.Hora_502ag = DateTime.Now.TimeOfDay;
                bllFactura_502ag.ActualizarFacturaClienteIdentificado_502ag(facturaActual_502ag);
                FormCobrarCliente_502ag cobrarClienteForm_502ag = new FormCobrarCliente_502ag(facturaActual_502ag);
                this.Hide();
                cobrarClienteForm_502ag.Show();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void EstadoActual_502ag()
        {
            if(estadoActual_502ag == 0)
            {
                buttonSeleccionarCombustible_502ag.Enabled = true;
                buttonComenzarCarga_502ag.Enabled = false;
                buttonDetenerCarga_502ag.Enabled = false;
                buttonReanudarCarga_502ag.Enabled = false;
                buttonFinalizarCarga_502ag.Enabled = false;
                buttonIdentificarCliente_502ag.Enabled = false;
                buttonRegistrarCliente_502ag.Enabled = false;
                buttonCobrarCliente_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBDNI_502ag.Enabled = false;
                tBCodigo_502ag.ReadOnly = true;
                tBCodigo_502ag.Enabled = false;
                tBNombre_502ag.ReadOnly = true;
                tBNombre_502ag.Enabled = false;
                tBApellido_502ag.ReadOnly = true;
                tBApellido_502ag.Enabled = false;
                rTBDetallesCarga_502ag.ReadOnly = true;
                rTBDetallesCarga_502ag.Enabled = false;
                rBCantidad_502ag.Enabled = false;
                rBMonto_502ag.Enabled = false;
            }
            if(estadoActual_502ag == 1)
            {
                BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                buttonSeleccionarFactura_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = true;
                buttonSeleccionarCombustible_502ag.Enabled = false;
                buttonComenzarCarga_502ag.Enabled = true;
                rBCantidad_502ag.Enabled = true;
                rBMonto_502ag.Enabled = true;
                tBCantidad_502ag.Enabled = true;
                combustibleSeleccionado_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(facturaActual_502ag.CodCombustible_502ag.ToString());
                tBCodigo_502ag.Text = combustibleSeleccionado_502ag.CodCombustible_502ag;
            }
            if (estadoActual_502ag == 2) 
            {
                buttonSeleccionarCombustible_502ag.Enabled = false;
                buttonComenzarCarga_502ag.Enabled = false;
                buttonDetenerCarga_502ag.Enabled = false;
                buttonReanudarCarga_502ag.Enabled = false;
                buttonFinalizarCarga_502ag.Enabled = false;
                rBCantidad_502ag.Enabled = false;
                rBMonto_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                rTBDetallesCarga_502ag.Enabled = false;
                buttonSeleccionarFactura_502ag.Enabled = false;
                tBDNI_502ag.Enabled = true;
                buttonIdentificarCliente_502ag.Enabled = true;
                buttonRegistrarCliente_502ag.Enabled = true;
            }
            if(estadoActual_502ag == 3)
            {
                FormCobrarCliente_502ag cobrarClienteForm_502ag = new FormCobrarCliente_502ag(facturaActual_502ag);
                this.Hide();
                cobrarClienteForm_502ag.Show();
            }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                menu_502ag.Show();            
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonSeleccionarFactura_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvFacturas_502ag.Rows.Count <= 0) { throw new Exception("No hay facturas que se encuentren incompletas"); }
                BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                facturaActual_502ag = bllFactura_502ag.ObtenerFactura_502ag(int.Parse(dgvFacturas_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                estadoActual_502ag = facturaActual_502ag.EstadoFactura_502ag;
                EstadoActual_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonFinalizarCarga_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                rBCantidad_502ag.Enabled = false;
                rBMonto_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = false;
                tBCodigo_502ag.Clear();
                tBCantidad_502ag.Enabled = false;
                tBCantidad_502ag.Clear();
                if (facturaActual_502ag == null) throw new Exception("No existe una factura");
                facturaActual_502ag.CantCargada_502ag = totalCargado_502ag;
                facturaActual_502ag.Monto_502ag = totalCargado_502ag * combustibleSeleccionado_502ag.PrecioPorLitro_502ag;
                facturaActual_502ag.EstadoFactura_502ag ++;
                buttonFinalizarCarga_502ag.Enabled = false;
                buttonReanudarCarga_502ag.Enabled = false;
                buttonDetenerCarga_502ag.Enabled = false;
                bllFactura_502ag.ActualizarFacturaCargaFinalizada_502ag(facturaActual_502ag);
                tBDNI_502ag.Enabled = true;
                buttonIdentificarCliente_502ag.Enabled = true;
                buttonRegistrarCliente_502ag.Enabled = true;
                rTBDetallesCarga_502ag.AppendText($"Identifique al cliente");
                estadoCargando_502ag = false;
                MostrarFacturas_502ag(dgvFacturas_502ag);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        //activated = cabra = goat = lebron james
        private void FormCargarCombustible_502ag_Activated(object sender, EventArgs e)
        {
            MostrarCombustibles_502ag(dgvCombustibles_502ag);
            MostrarFacturas_502ag(dgvFacturas_502ag);
            BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
            if(combustibleSeleccionado_502ag != null)
            {
                if (bllCombustible_502ag.ObtenerCombustible_502ag(combustibleSeleccionado_502ag.CodCombustible_502ag) == null)
                {
                    combustibleSeleccionado_502ag = null;
                    facturaActual_502ag = null;
                    estadoActual_502ag = 0;
                    EstadoActual_502ag();
                    buttonSeleccionarFactura_502ag.Enabled = true;
                }
            }
        }

        private void buttonDetenerCarga_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                timerCarga_502ag.Stop();
                rTBDetallesCarga_502ag.AppendText($"Carga detenida.\nCargado hasta el momento: {totalCargado_502ag:F2} litros");
                buttonReanudarCarga_502ag.Enabled = true;
                buttonDetenerCarga_502ag.Enabled = false;
                buttonFinalizarCarga_502ag.Enabled = true;
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonReanudarCarga_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                timerCarga_502ag.Start();
                buttonDetenerCarga_502ag.Enabled = true;
                buttonReanudarCarga_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
