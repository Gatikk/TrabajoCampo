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
using SERVICIOS_502ag;

namespace GUI
{
    public partial class FormRegistrarCliente_502ag : Form, IObserver_502ag
    {
        private string msgDNIYaUtilizado_502ag, msgEmailYaUtilizado_502ag, msgTelefonoYaUtilizado_502ag, msgDNINoValido_502ag, msgNombreNoValido_502ag, msgApellidoNoValido_502ag, msgEmailNoValido_502ag, msgTelefonoNoValido_502ag, msgDireccionNoValida_502ag;
        private string msgClienteRegistrado_502ag, capRegistroExitoso_502ag;
        public FormRegistrarCliente_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private void buttonRegistrarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                string dni_502ag = tBDNI_502ag.Text;
                string nombre_502ag = tBNombre_502ag.Text;
                string apellido_502ag = tBApellido_502ag.Text;
                string direccion_502ag = tBDireccion_502ag.Text;
                string telefono_502ag = tBTelefono_502ag.Text;
                string email_502ag = tBEmail_502ag.Text;
                if (!bllCliente_502ag.VerificarDNIYaRegistrado_502ag(dni_502ag)) throw new Exception(msgDNIYaUtilizado_502ag);
                if (!bllCliente_502ag.VerificarEmailYaRegistrado_502ag(email_502ag)) throw new Exception(msgEmailYaUtilizado_502ag);
                if (!bllCliente_502ag.VerificarTelefonoYaRegistrado_502ag(telefono_502ag)) throw new Exception(msgTelefonoYaUtilizado_502ag);
                if (!bllCliente_502ag.VerificarDNI_502ag(dni_502ag)) throw new Exception(msgDNINoValido_502ag);
                if (!bllCliente_502ag.VerificarNombre_502ag(nombre_502ag)) throw new Exception(msgNombreNoValido_502ag);
                if (!bllCliente_502ag.VerificarNombre_502ag(apellido_502ag)) throw new Exception(msgApellidoNoValido_502ag);
                if (!bllCliente_502ag.VerificarEmail_502ag(email_502ag)) throw new Exception(msgEmailNoValido_502ag);
                if (!bllCliente_502ag.VerificarTelefono_502ag(telefono_502ag)) throw new Exception(msgTelefonoNoValido_502ag);
                if (!bllCliente_502ag.VerificarDireccion_502ag(direccion_502ag)) throw new Exception(msgDireccionNoValida_502ag);
                bllCliente_502ag.AltaCliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
                MessageBox.Show("Cliente registrado exitosamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
                this.Hide();
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
                if (c_502ag is TextBox)
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
            msgDNIYaUtilizado_502ag = traductor_502ag.Traducir_502ag("msgDNIYaUtilizado_502ag");
            msgEmailYaUtilizado_502ag = traductor_502ag.Traducir_502ag("msgEmailYaUtilizado_502ag");
            msgTelefonoYaUtilizado_502ag = traductor_502ag.Traducir_502ag("msgTelefonoYaUtilizado_502ag");
            msgDNINoValido_502ag = traductor_502ag.Traducir_502ag("msgDNINoValido_502ag");
            msgNombreNoValido_502ag = traductor_502ag.Traducir_502ag("msgNombreNoValido_502ag");
            msgApellidoNoValido_502ag = traductor_502ag.Traducir_502ag("msgApellidoNoValido_502ag");
            msgEmailNoValido_502ag = traductor_502ag.Traducir_502ag("msgEmailNoValido_502ag");
            msgTelefonoNoValido_502ag = traductor_502ag.Traducir_502ag("msgTelefonoNoValido_502ag");
            msgDireccionNoValida_502ag = traductor_502ag.Traducir_502ag("msgDireccionNoValida_502ag");
        }
    }
}
