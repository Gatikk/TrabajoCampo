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
    public partial class FormCobrarCliente_502ag : Form, IObserver_502ag
    {
        private BE_Factura_502ag facturaACobrar_502ag;
        private string msgTitularIncorrecto_502ag, msgTarjetaIncorrecta_502ag, msgCodigoIncorrecto_502ag, msgCaducidadIncorrecta_502ag;
        private string msgCredito_502ag, msgDebito_502ag, msgPagoRechazado_502ag, msgPagoRealizado_502ag, capPagoExitoso_502ag;
        private string msgApellido_502ag, msgNombre_502ag, msgCombustible_502ag, msgCantidadCargada_502ag, msgMonto_502ag, msgFecha_502ag, msgHora_502ag, msgLitros_502ag;
        public FormCobrarCliente_502ag(BE_Factura_502ag factura_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            rTBFacturaDatos_502ag.ReadOnly = true;
            facturaACobrar_502ag = factura_502ag;
            rBCredito_502ag.Checked = true;
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
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

                if (!bllPago_502ag.VerificarTitular_502ag(titular_502ag)) { throw new Exception(msgTitularIncorrecto_502ag); }
                if (!bllPago_502ag.VerificarNumero_502ag(numTarjeta_502ag)) throw new Exception(msgTarjetaIncorrecta_502ag);
                if (!bllPago_502ag.VerificarCodigo_502ag(codSeguridad_502ag)) throw new Exception(msgCodigoIncorrecto_502ag);
                if (!bllPago_502ag.VerificarFechaCaducidad_502ag(fechaCad_502ag)) throw new Exception(msgCaducidadIncorrecta_502ag);

                string metodo_502ag = "";
                if (rBCredito_502ag.Checked)
                {
                    metodo_502ag = cifrador_502ag.EncryptadorReversible_502ag(msgCredito_502ag);
                }
                else
                {
                    metodo_502ag = cifrador_502ag.EncryptadorReversible_502ag(msgDebito_502ag);
                }
                BE_Tarjeta_502ag tarjeta_502ag = new BE_Tarjeta_502ag(metodo_502ag, numTarjeta_502ag, codSeguridad_502ag, fechaCad_502ag, titular_502ag);
                if (!bllPago_502ag.ValidarPago_502ag(tarjeta_502ag)) { throw new Exception(msgPagoRechazado_502ag);}
                facturaACobrar_502ag.EstadoFactura_502ag++;
                    facturaACobrar_502ag.IsFacturado_502ag = true;
                facturaACobrar_502ag.Fecha_502ag = DateTime.Now.Date;
                facturaACobrar_502ag.Hora_502ag = DateTime.Now.TimeOfDay;
                facturaACobrar_502ag.MetodoPago_502ag = cifrador_502ag.DesencryptadorReversible_502ag(tarjeta_502ag.Tipo_502ag);
                bllFactura_502ag.ActualizarFacturaFinalizada_502ag(facturaACobrar_502ag);
                MessageBox.Show(msgPagoRealizado_502ag, capPagoExitoso_502ag, MessageBoxButtons.OK, MessageBoxIcon.Information);
                bllFactura_502ag.GenerarFactura_502ag(facturaACobrar_502ag);
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
                rTBFacturaDatos_502ag.AppendText(
                    msgApellido_502ag + $"{facturaACobrar_502ag.ApellidoCliente_502ag}" + "\n" +
                    msgNombre_502ag + $"{facturaACobrar_502ag.NombreCliente_502ag}" + "\n" +
                    msgCombustible_502ag + $"{facturaACobrar_502ag.NombreCombustible_502ag}" + "\n" +
                    msgCantidadCargada_502ag + $"{facturaACobrar_502ag.CantCargada_502ag:F2}" + msgLitros_502ag +"\n" +
                    msgMonto_502ag + $"{facturaACobrar_502ag.Monto_502ag:F2}" + "$\n" +
                    msgFecha_502ag + $"{facturaACobrar_502ag.Fecha_502ag.ToShortDateString()}" + "\n" +
                    msgHora_502ag + $"{facturaACobrar_502ag.Hora_502ag.ToString(@"hh\:mm\:ss")}" + "\n"

                    );
            } catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void FormCobrarCliente_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
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

                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
            }
            msgTitularIncorrecto_502ag = traductor_502ag.Traducir_502ag("msgTitularIncorrecto_502ag");
            msgTarjetaIncorrecta_502ag = traductor_502ag.Traducir_502ag("msgTarjetaIncorrecta_502ag");
            msgCodigoIncorrecto_502ag = traductor_502ag.Traducir_502ag("msgCodigoIncorrecto_502ag");
            msgCaducidadIncorrecta_502ag = traductor_502ag.Traducir_502ag("msgCaducidadIncorrecta_502ag");
            msgCredito_502ag = traductor_502ag.Traducir_502ag("msgCredito_502ag");
            msgDebito_502ag = traductor_502ag.Traducir_502ag("msgDebito_502ag");
            msgPagoRechazado_502ag = traductor_502ag.Traducir_502ag("msgPagoRechazado_502ag");
            msgPagoRealizado_502ag = traductor_502ag.Traducir_502ag("msgPagoRealizado_502ag");
            capPagoExitoso_502ag = traductor_502ag.Traducir_502ag("capPagoExitoso_502ag");
            msgApellido_502ag = traductor_502ag.Traducir_502ag("msgApellido_502ag");
            msgNombre_502ag = traductor_502ag.Traducir_502ag("msgNombre_502ag");
            msgCombustible_502ag = traductor_502ag.Traducir_502ag("msgCombustible_502ag");
            msgCantidadCargada_502ag = traductor_502ag.Traducir_502ag("msgCantidadCargada_502ag");
            msgMonto_502ag = traductor_502ag.Traducir_502ag("msgMonto_502ag");
            msgFecha_502ag = traductor_502ag.Traducir_502ag("msgFecha_502ag");
            msgHora_502ag = traductor_502ag.Traducir_502ag("msgHora_502ag");
            msgLitros_502ag = traductor_502ag.Traducir_502ag("msgLitros_502ag");

        }

        private void FormCobrarCliente_502ag_Activated(object sender, EventArgs e)
        {
            CompletarRTB_502ag();
        }
    }
}
