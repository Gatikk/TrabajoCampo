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
using SERVICIOS_502ag;

namespace GUI
{
    public partial class FormCargarCombustible_502ag : Form, IObserver_502ag
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

        private string noCombustibleParaSeleccionar_502ag, noCombustibleDisponible_502ag, confirmarSeleccionCombustible_502ag, seleccionarCombustible_502ag;
        private string ingreseCantidadValida_502ag, iniciandoCarga_502ag, msgCantidadActual_502ag, msgLitros_502ag, msgCargadoHastaElMomento_502ag;
        private string msgCargaFinalizada_502ag, msgTotalCargado_502ag, msgClienteNoEncontrado_502ag, msgNoHayFacturasIncompletas_502ag, msgNoExisteFactura_502ag;
        private string msgIdentifiqueCliente_502ag, msgCargaDetenida_502ag;
        private string msgEstadoPendienteCarga_502ag, msgEstadoCargaFinalizada_502ag, msgEstadoClienteIdentificado_502ag;

        BE_Factura_502ag facturaActual_502ag;
        public FormCargarCombustible_502ag(FormMenu_502ag formMenu_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            menu_502ag = formMenu_502ag;
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            EstadoActual_502ag();
            MostrarCombustibles_502ag(dgvCombustibles_502ag);
            MostrarFacturas_502ag(dgvFacturas_502ag);
            timerCarga_502ag.Interval = 1000; 
            timerCarga_502ag.Tick += TimerCarga_502ag_Tick;
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
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
                if (dgvCombustibles_502ag.Rows.Count <= 0) { throw new Exception(noCombustibleParaSeleccionar_502ag); }
                string codCombustible_502ag = dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString();
                combustibleSeleccionado_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(codCombustible_502ag);
                if(combustibleSeleccionado_502ag.CantDisponible_502ag <= 0) { throw new Exception(noCombustibleDisponible_502ag);}
                confirmarSeleccionCombustible_502ag = confirmarSeleccionCombustible_502ag.Replace("{combustibleSeleccionado_502ag.Nombre_502ag}", $"{combustibleSeleccionado_502ag.Nombre_502ag}");
                DialogResult dResult_502ag = MessageBox.Show(confirmarSeleccionCombustible_502ag, seleccionarCombustible_502ag, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                dgv_502ag.Rows.Add(combustible_502ag.CodCombustible_502ag, combustible_502ag.Nombre_502ag, combustible_502ag.CantDisponible_502ag+ msgLitros_502ag, combustible_502ag.PrecioPorLitro_502ag+"$");
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
                    estadoFacturaString_502ag = msgEstadoPendienteCarga_502ag;
                }
                if (factura_502ag.EstadoFactura_502ag == 2)
                {
                    estadoFacturaString_502ag = msgEstadoCargaFinalizada_502ag;
                }
                if (factura_502ag.EstadoFactura_502ag == 3)
                {
                    estadoFacturaString_502ag = msgEstadoClienteIdentificado_502ag;
                }
                dgv_502ag.Rows.Add(factura_502ag.CodFactura_502ag, factura_502ag.NombreCombustible_502ag, estadoFacturaString_502ag);
            }
        }

        private void buttonComenzarCarga_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reDecimal_502ag = new Regex(@"^\d+(\.\d{1,2})?$");
                if(!reDecimal_502ag.IsMatch(tBCantidad_502ag.Text) || tBCantidad_502ag.Text == ""){throw new Exception(ingreseCantidadValida_502ag); }
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
                rTBDetallesCarga_502ag.AppendText(iniciandoCarga_502ag+"\n");
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
                rTBDetallesCarga_502ag.AppendText(msgCantidadActual_502ag + $"{vehiculoActual_502ag.CantidadActual_502ag:F2}" + " / " +$" {vehiculoActual_502ag.CantidadMaxima_502ag:F2}" + msgLitros_502ag + "\n" + msgCargadoHastaElMomento_502ag + $"{totalCargado_502ag:F2}" + msgLitros_502ag);
                if (finalizado_502ag)
                {
                    timerCarga_502ag.Stop();
                    buttonFinalizarCarga_502ag.Enabled = true;
                    buttonDetenerCarga_502ag.Enabled = false;
                    rTBDetallesCarga_502ag.AppendText("\n" + msgCargaFinalizada_502ag+"\n"+msgTotalCargado_502ag + $"{totalCargado_502ag:F2}"+ msgLitros_502ag+"\n");
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
                    buttonRegistrarCliente_502ag.Enabled = true;
                    throw new Exception(msgClienteNoEncontrado_502ag);
                }
                else
                {
                    tBNombre_502ag.Enabled = true;
                    tBNombre_502ag.Text = cliente_502ag.Nombre_502ag;
                    tBApellido_502ag.Enabled = true;
                    tBApellido_502ag.Text = cliente_502ag.Apellido_502ag;
                    tBDNI_502ag.ReadOnly = true;
                    buttonIdentificarCliente_502ag.Enabled = false;
                    buttonCobrarCliente_502ag.Enabled = true;
                    buttonRegistrarCliente_502ag.Enabled = false;
                }

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
                SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
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
                SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
                this.Hide();
                menu_502ag.Show();            
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonSeleccionarFactura_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvFacturas_502ag.Rows.Count <= 0) { throw new Exception(msgNoHayFacturasIncompletas_502ag); }
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
                timerCarga_502ag.Stop();
                rBCantidad_502ag.Enabled = false;
                rBMonto_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = false;
                tBCodigo_502ag.Clear();
                tBCantidad_502ag.Enabled = false;
                tBCantidad_502ag.Clear();
                if (facturaActual_502ag == null) throw new Exception(msgNoExisteFactura_502ag);
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
                rTBDetallesCarga_502ag.AppendText(msgIdentifiqueCliente_502ag);
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
                rTBDetallesCarga_502ag.AppendText("\n"+msgCargaDetenida_502ag+"\n" + msgCargadoHastaElMomento_502ag+"\n");
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

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if(c_502ag is TextBox || c_502ag is RichTextBox)
                {
                }
                else
                {
                    c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);
                }
                if (c_502ag is DataGridView)
                {
                    DataGridView dgv_502ag = c_502ag as DataGridView;
                    foreach (DataGridViewColumn col_502ag in dgv_502ag.Columns)
                    {
                        col_502ag.HeaderText = traductor_502ag.Traducir_502ag(col_502ag.Name);
                    }
                }
                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
                noCombustibleParaSeleccionar_502ag = traductor_502ag.Traducir_502ag("noCombustibleParaSeleccionar_502ag");
                noCombustibleDisponible_502ag = traductor_502ag.Traducir_502ag("noCombustibleDisponible_502ag");
                confirmarSeleccionCombustible_502ag = traductor_502ag.Traducir_502ag("confirmarSeleccionCombustible_502ag");
                seleccionarCombustible_502ag = traductor_502ag.Traducir_502ag("seleccionarCombustible_502ag");
                ingreseCantidadValida_502ag = traductor_502ag.Traducir_502ag("ingreseCantidadValida_502ag");
                iniciandoCarga_502ag = traductor_502ag.Traducir_502ag("iniciandoCarga_502ag");
                msgCantidadActual_502ag = traductor_502ag.Traducir_502ag("msgCantidadActual_502ag");
                msgLitros_502ag = traductor_502ag.Traducir_502ag("msgLitros_502ag");
                msgCargadoHastaElMomento_502ag = traductor_502ag.Traducir_502ag("msgCargadoHastaElMomento_502ag");
                msgCargaFinalizada_502ag = traductor_502ag.Traducir_502ag("msgCargaFinalizada_502ag");
                msgTotalCargado_502ag = traductor_502ag.Traducir_502ag("msgTotalCargado_502ag");
                msgClienteNoEncontrado_502ag = traductor_502ag.Traducir_502ag("msgClienteNoEncontrado_502ag");
                msgNoHayFacturasIncompletas_502ag = traductor_502ag.Traducir_502ag("msgNoHayFacturasIncompletas_502ag");
                msgNoExisteFactura_502ag = traductor_502ag.Traducir_502ag("msgNoExisteFactura_502ag");
                msgIdentifiqueCliente_502ag = traductor_502ag.Traducir_502ag("msgIdentifiqueCliente_502ag");
                msgCargaDetenida_502ag = traductor_502ag.Traducir_502ag("msgCargaDetenida_502ag");
                msgEstadoPendienteCarga_502ag = traductor_502ag.Traducir_502ag("msgEstadoPendienteCarga_502ag");
                msgEstadoCargaFinalizada_502ag = traductor_502ag.Traducir_502ag("msgEstadoCargaFinalizada_502ag");
                msgEstadoClienteIdentificado_502ag = traductor_502ag.Traducir_502ag("msgEstadoClienteIdentificado_502ag");
            }
        }

    }
}
