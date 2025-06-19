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
    public partial class FormCobrarCliente_502ag : Form
    {
        private BE_Factura_502ag facturaACobrar_502ag;
        public FormCobrarCliente_502ag(BE_Factura_502ag factura_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            rTBFacturaDatos_502ag.ReadOnly = true;
            facturaACobrar_502ag = factura_502ag;
            CompletarRTB_502ag();
            rBCredito_502ag.Checked = true;
        }

        private void buttonRealizarPago_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Pago_502ag bllPago_502ag = new BLL_Pago_502ag();
                BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                FormMenu_502ag menu_502ag = new FormMenu_502ag();
                Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
                string numTarjeta_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBNumero_502ag.Text);
                string codSeguridad_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBCodigoSeguridad_502ag.Text);
                string fechaCad_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBFechaCaducidad_502ag.Text);
                string titular_502ag = cifrador_502ag.EncryptadorReversible_502ag(tBTitular_502ag.Text);
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
                if (!bllPago_502ag.ValidarPago_502ag(tarjeta_502ag)) { throw new Exception("Pago rechazado");}
                facturaACobrar_502ag.EstadoFactura_502ag++;
                    facturaACobrar_502ag.IsFacturado_502ag = true;
                facturaACobrar_502ag.Fecha_502ag = DateTime.Now.Date;
                facturaACobrar_502ag.Hora_502ag = DateTime.Now.TimeOfDay;
                facturaACobrar_502ag.MetodoPago_502ag = cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.Tipo_502ag);
                bllFactura_502ag.ActualizarFacturaFinalizada_502ag(facturaACobrar_502ag);
                MessageBox.Show("Pago realizado exitosamente", "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                menu_502ag.Show();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}");}
        }

        private void CompletarRTB_502ag()
        {
            try
            {
                rTBFacturaDatos_502ag.Clear();
                rTBFacturaDatos_502ag.AppendText($"Apellido: {facturaACobrar_502ag.ApellidoCliente_502ag}\nNombre: {facturaACobrar_502ag.NombreCliente_502ag}" +
                    $"\nCombustible: {facturaACobrar_502ag.NombreCombustible_502ag}" +
                    $"\nCantidad Cargada: {facturaACobrar_502ag.CantCargada_502ag:F2} litros\nMonto: {facturaACobrar_502ag.Monto_502ag:F2}$\nFecha: {facturaACobrar_502ag.Fecha_502ag.ToShortDateString()}" +
                    $"\nHora: {facturaACobrar_502ag.Hora_502ag.ToString(@"hh\:mm\:ss")}");
            } catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void FormCobrarCliente_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
