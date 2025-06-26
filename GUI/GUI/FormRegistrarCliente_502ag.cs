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
    public partial class FormRegistrarCliente_502ag : Form
    {
        public FormRegistrarCliente_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
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
                if (!bllCliente_502ag.VerificarDNIYaRegistrado_502ag(dni_502ag)) throw new Exception("DNI ya utilizado");
                if (!bllCliente_502ag.VerificarEmailYaRegistrado_502ag(email_502ag)) throw new Exception("Email ya utilizado");
                if (!bllCliente_502ag.VerificarTelefonoYaRegistrado_502ag(telefono_502ag)) throw new Exception("Teléfono ya utilizado");
                if (!bllCliente_502ag.VerificarDNI_502ag(dni_502ag)) throw new Exception("DNI no válido");
                if (!bllCliente_502ag.VerificarNombre_502ag(nombre_502ag)) throw new Exception("Nombre no válido");
                if (!bllCliente_502ag.VerificarNombre_502ag(apellido_502ag)) throw new Exception("Apellido no válido");
                if (!bllCliente_502ag.VerificarEmail_502ag(email_502ag)) throw new Exception("Email no válido");
                if (!bllCliente_502ag.VerificarTelefono_502ag(telefono_502ag)) throw new Exception("Teléfono no válido, siga el formato XX XXXX-XXXX");
                if (!bllCliente_502ag.VerificarDireccion_502ag(direccion_502ag)) throw new Exception("Dirección no válida, siga el formato Calle XXXX");
                bllCliente_502ag.AltaCliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
                MessageBox.Show("Cliente registrado exitosamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
