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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormCobrarClienteTaller_502ag : Form
    {
        public FormCobrarClienteTaller_502ag()
        {
            InitializeComponent();
            tBTitular_502ag.ReadOnly = true;
            rBCredito_502ag.Checked = true;
            rTBFacturaDatos_502ag.ReadOnly = true;
            Limpiar_502ag();
            Mostrar_502ag();
        }
        BE_OrdenTrabajo_502ag ordenTrabajo_502ag;

        private void Mostrar_502ag()
        {
            dgvOrdenesTrabajo_502ag.Rows.Clear();
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            List<BE_OrdenTrabajo_502ag> listaOrdenesTrabajo_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoPendienteDePago_502ag();
            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in listaOrdenesTrabajo_502ag)
            {
                dgvOrdenesTrabajo_502ag.Rows.Add(ordenTrabajo_502ag.CodOrdenTrabajo_502ag, ordenTrabajo_502ag.DNICliente_502ag, ordenTrabajo_502ag.PatenteVehiculo_502ag, ordenTrabajo_502ag.Fecha_502ag.ToString("dd/MM/yyyy"), ordenTrabajo_502ag.Hora_502ag.ToString(@"hh\:mm"));
            }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }

        private void buttonRealizarPago_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(ordenTrabajo_502ag == null) { throw new Exception("Debe seleccionar una orden de trabajo"); }
                //comprobaciones del metodo de pago
                BLL_Pago_502ag bllPago_502ag = new BLL_Pago_502ag();
                Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
                string numTarjeta_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBNumero_502ag.Text);
                string codSeguridad_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBCodigoSeguridad_502ag.Text);
                string fechaCad_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBFechaCaducidad_502ag.Text);
                string titular_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBTitular_502ag.Text);

                if (!bllPago_502ag.VerificarTitular_502ag(titular_502ag)) { throw new Exception("Titular no válido"); }
                if (!bllPago_502ag.VerificarNumero_502ag(numTarjeta_502ag)) throw new Exception("Número no válido");
                if (!bllPago_502ag.VerificarCodigo_502ag(codSeguridad_502ag)) throw new Exception("Código no válido");
                if (!bllPago_502ag.VerificarFechaCaducidad_502ag(fechaCad_502ag)) throw new Exception("Fecha no válida");

                string metodo_502ag = "";
                if (rBCredito_502ag.Checked)
                {
                    metodo_502ag = cifrador_502ag.EncryptadorReversible_502ag("Crédito");
                }
                else
                {
                    metodo_502ag = cifrador_502ag.EncryptadorReversible_502ag("Débito");
                }

                BE_Tarjeta_502ag tarjeta_502ag = new BE_Tarjeta_502ag(metodo_502ag, numTarjeta_502ag, codSeguridad_502ag, fechaCad_502ag, titular_502ag);
                if (!bllPago_502ag.ValidarPago_502ag(tarjeta_502ag)) { throw new Exception("Pago rechazado"); }

                //se actualiza el estado de la orden de trabajo a cerrada
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                bllOrdenTrabajo_502ag.ActualizarEstadoOrdenTrabajoACerrada_502ag(ordenTrabajo_502ag);

                //una vez que se cobra, se genera la factura
                BLL_FacturaTaller_502ag bllFacturaTaller_502ag = new BLL_FacturaTaller_502ag();
                string metodoPago_502ag = cifrador_502ag.DesencryptadorReversible_502ag(metodo_502ag);
                bllFacturaTaller_502ag.GenerarFacturaTaller_502ag(ordenTrabajo_502ag, metodoPago_502ag);

                //se actualiza la interfaz
                Limpiar_502ag();
                Mostrar_502ag();

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonSeleccionarOrden_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvOrdenesTrabajo_502ag.SelectedRows.Count == 0) { throw new Exception("Debe seleccionar una orden de trabajo"); }
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                ordenTrabajo_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenDeTrabajo_502ag(dgvOrdenesTrabajo_502ag.SelectedRows[0].Cells[0].Value.ToString());
                if(ordenTrabajo_502ag == null) { throw new Exception("No se pudo obtener la orden de trabajo seleccionada"); }
                buttonSeleccionarOrden_502ag.Enabled = false;
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(ordenTrabajo_502ag.DNICliente_502ag);
                if(cliente_502ag != null)
                {
                    tBTitular_502ag.Enabled = true;
                    tBNumero_502ag.Enabled = true;
                    tBCodigoSeguridad_502ag.Enabled = true;
                    tBFechaCaducidad_502ag.Enabled = true;
                    rBCredito_502ag.Enabled = true;
                    rBDebito_502ag.Enabled = true;
                    dgvOrdenesTrabajo_502ag.Enabled = false;
                    rTBFacturaDatos_502ag.Enabled = true;
                    buttonSeleccionarOrden_502ag.Enabled = false;
                    buttonRealizarPago_502ag.Enabled = true;
                    tBTitular_502ag.Text = $"{cliente_502ag.Nombre_502ag} {cliente_502ag.Apellido_502ag}";
                    CompletarRTB_502ag();
                }
                else
                {
                    Limpiar_502ag();
                    throw new Exception("No se pudo obtener el cliente asociado a la orden de trabajo");
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonLimpiarSeleccion_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_502ag();
            }
            catch (Exception ex){ MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void CompletarRTB_502ag()
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(ordenTrabajo_502ag.DNICliente_502ag);
                BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
                BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag = bllDiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(ordenTrabajo_502ag.CodOrdenTrabajo_502ag);

                rTBFacturaDatos_502ag.Clear();
                rTBFacturaDatos_502ag.AppendText(
                    "Apellido: " + $"{cliente_502ag.Apellido_502ag}" + "\n" +
                    "Nombre: " + $"{cliente_502ag.Nombre_502ag}" + "\n" +
                    "Descripción: " + $"{diagnosticoFinal_502ag.Descripcion_502ag}" + "\n" +
                    "-----------------------------------------------------------------------------" + "\n" +
                    "\n" +
                    "Costo Mano de Obra: "+ $"{diagnosticoFinal_502ag.CostoManoObra_502ag:F2}" + "$\n" +
                    "Costo Repuestos: " + $"{diagnosticoFinal_502ag.CostoRepuestos_502ag:F2}" + "$\n" +
                    "Monto Total: " + $"{(diagnosticoFinal_502ag.CostoManoObra_502ag + diagnosticoFinal_502ag.CostoRepuestos_502ag):F2}" + "$\n"
                    );
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void Limpiar_502ag()
        {
            ordenTrabajo_502ag = null;  
            tBTitular_502ag.Enabled = false;
            tBNumero_502ag.Enabled = false;
            tBCodigoSeguridad_502ag.Enabled = false;
            tBFechaCaducidad_502ag.Enabled = false;
            buttonRealizarPago_502ag.Enabled = false;
            rBCredito_502ag.Enabled = false;
            rBDebito_502ag.Enabled = false;
            dgvOrdenesTrabajo_502ag.Enabled = true;
            rTBFacturaDatos_502ag.Enabled = false;
            buttonSeleccionarOrden_502ag.Enabled = true;
            tBTitular_502ag.Clear();
            tBNumero_502ag.Clear();
            tBCodigoSeguridad_502ag.Clear();
            tBFechaCaducidad_502ag.Clear();
            rTBFacturaDatos_502ag.Clear();
        }
    }
}
