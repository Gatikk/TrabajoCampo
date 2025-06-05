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
using BLL_502ag;

namespace GUI
{
    public partial class FormMaestrosClientes_502ag : Form
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";
        public FormMaestrosClientes_502ag(FormMenu_502ag formMenu_502ag)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
            tBDNI_502ag.Enabled = false;
            tBNombre_502ag.Enabled = false;
            tBApellido_502ag.Enabled = false;
            tBEmail_502ag.Enabled = false;
            tBDireccion_502ag.Enabled = false;
            tBTelefono_502ag.Enabled = false;
            menu_502ag = formMenu_502ag;
            Mostrar_502ag(dgvClientes_502ag);
            
        }

        private void FormMaestrosClientes_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonAltaCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Alta";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaCliente_502ag.Enabled = false;
                buttonModificarCliente_502ag.Enabled = false;
                buttonBajaCliente_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                tBDNI_502ag.Enabled = true;
                tBNombre_502ag.Enabled = true;
                tBApellido_502ag.Enabled = true;
                tBEmail_502ag.Enabled = true;
                tBDireccion_502ag.Enabled = true;
                tBTelefono_502ag.Enabled = true;
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

        }

        private void buttonModificarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Modificar";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaCliente_502ag.Enabled = false;
                buttonModificarCliente_502ag.Enabled = false;
                buttonBajaCliente_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                tBEmail_502ag.Enabled = true;
                tBDireccion_502ag.Enabled = true;
                tBTelefono_502ag.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonEliminarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Baja";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonAltaCliente_502ag.Enabled = false;
                buttonModificarCliente_502ag.Enabled = false;
                buttonBajaCliente_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                if (opcion_502ag == "Alta")
                {
                    string dni_502ag = tBDNI_502ag.Text;
                    string nombre_502ag = tBNombre_502ag.Text;
                    string apellido_502ag = tBApellido_502ag.Text;
                    string email_502ag = tBEmail_502ag.Text;
                    string direccion_502ag = tBDireccion_502ag.Text;
                    string telefono_502ag = tBTelefono_502ag.Text;
                    if (bllCliente_502ag.VerificarDatosIngresados_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag)) throw new Exception("Datos ingresados incorrectos");
                    bllCliente_502ag.AltaCliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
                    tBDNI_502ag.Clear();
                    tBNombre_502ag.Clear();
                    tBApellido_502ag.Clear();
                    tBEmail_502ag.Clear();
                    tBDireccion_502ag.Clear();
                    tBTelefono_502ag.Clear();
                }
                if(opcion_502ag == "Modificar")
                {

                }
                if(opcion_502ag == "Baja")
                {

                }
                Mostrar_502ag(dgvClientes_502ag);
                opcion_502ag = "Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaCliente_502ag.Enabled = true;
                buttonModificarCliente_502ag.Enabled = true;
                buttonBajaCliente_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBDNI_502ag.Enabled = false;
                tBNombre_502ag.Enabled = false;
                tBApellido_502ag.Enabled = false;
                tBEmail_502ag.Enabled = false;
                tBDireccion_502ag.Enabled = false;
                tBTelefono_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu_502ag.Show();
        }

        private void Mostrar_502ag(DataGridView dgv_502ag)
        {
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            dgv_502ag.Rows.Clear();
            foreach(BE_Cliente_502ag cliente_502ag in bllCliente_502ag.ObtenerListaClientes())
            {
                dgv_502ag.Rows.Add(cliente_502ag.DNI_502ag, cliente_502ag.Nombre_502ag, cliente_502ag.Apellido_502ag, cliente_502ag.Email_502ag, cliente_502ag.Direccion_502ag, cliente_502ag.Telefono_502ag, cliente_502ag.IsActivo_502ag);
            }
        }
    }
}
