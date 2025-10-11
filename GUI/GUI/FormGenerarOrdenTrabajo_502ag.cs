using BE_502ag;
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
    public partial class FormGenerarOrdenTrabajo_502ag : Form
    {
        BE_Vehiculo_502ag vehiculoOT_502ag;
        BE_Cliente_502ag clienteOT_502ag;
        public FormGenerarOrdenTrabajo_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
        }

        private void buttonIdentificarVehiculo_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Vehiculo_502ag bllVehiculo = new BLL_Vehiculo_502ag();
                BE_Vehiculo_502ag vehiculo_502ag = bllVehiculo.ObtenerVehiculo_502ag(tBPatente_502ag.Text);
                if(vehiculo_502ag != null)
                {
                    tBMarca_502ag.Text = vehiculo_502ag.Marca_502ag;
                    tBModelo_502ag.Text = vehiculo_502ag.Modelo_502ag;
                    tBAnio_502ag.Text = vehiculo_502ag.Anio_502ag.ToString();
                    buttonIdentificarVehiculo_502ag.Enabled = false;
                    buttonRegistrarVehiculo_502ag.Enabled = false;
                    tBPatente_502ag.ReadOnly = true;
                    vehiculoOT_502ag = vehiculo_502ag;
                }
                else
                {
                    throw new Exception("Vehículo no encontrado o inactivo.");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonIdentificarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(tBDNI_502ag.Text);
                if (cliente_502ag != null)
                {
                    tBNombre_502ag.Text = cliente_502ag.Nombre_502ag;
                    tBApellido_502ag.Text = cliente_502ag.Apellido_502ag;
                    tBEmail_502ag.Text = cliente_502ag.Email_502ag;
                    tBDireccion_502ag.Text = cliente_502ag.Direccion_502ag;
                    tBTelefono_502ag.Text = cliente_502ag.Telefono_502ag;
                    
                    buttonIdentificarCliente_502ag.Enabled = false;
                    buttonRegistrarCliente_502ag.Enabled = false;
                    tBDNI_502ag.ReadOnly = true;

                    clienteOT_502ag = cliente_502ag;
                }
                else
                {
                    throw new Exception("Cliente no encontrado o inactivo.");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonRegistrarVehiculo_502ag_Click(object sender, EventArgs e)
        {
            FormRegistrarVehiculo_502ag registrarVehiculoForm_502ag = new FormRegistrarVehiculo_502ag();
            registrarVehiculoForm_502ag.Show();
        }

        private void buttonRegistrarCliente_502ag_Click(object sender, EventArgs e)
        {
            FormRegistrarCliente_502ag registrarClienteForm_502ag = new FormRegistrarCliente_502ag();
            registrarClienteForm_502ag.Show();
        }

        private void buttonGenerarOT_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(rTBObservaciones_502ag.Text.Length > 200) throw new Exception("Las observaciones no pueden superar los 200 caracteres.");
                if(string.IsNullOrEmpty(rTBObservaciones_502ag.Text)) throw new Exception("Las observaciones no pueden estar vacías.");
                if(vehiculoOT_502ag == null) throw new Exception("Debe identificar un vehículo.");
                if(clienteOT_502ag == null) throw new Exception("Debe identificar un cliente.");
                BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
                bllOrdenTrabajo_502ag.GenerarOrdenTrabajo_502ag(vehiculoOT_502ag, clienteOT_502ag, rTBObservaciones_502ag.Text);
                MessageBox.Show("Orden de Trabajo generada con éxito.");
                LimpiarPantalla_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }

        private void LimpiarPantalla_502ag()
        {
            tBPatente_502ag.Clear();
            tBMarca_502ag.Clear();
            tBModelo_502ag.Clear();
            tBAnio_502ag.Clear();
            tBDNI_502ag.Clear();
            tBNombre_502ag.Clear();
            tBApellido_502ag.Clear();
            tBEmail_502ag.Clear();
            tBDireccion_502ag.Clear();
            tBTelefono_502ag.Clear();
            rTBObservaciones_502ag.Clear();
            buttonIdentificarCliente_502ag.Enabled = true;
            buttonIdentificarVehiculo_502ag.Enabled = true;
            buttonRegistrarCliente_502ag.Enabled = true;
            buttonRegistrarVehiculo_502ag.Enabled = true;
            tBPatente_502ag.ReadOnly = false;
            tBDNI_502ag.ReadOnly = false;
            clienteOT_502ag = null;
            vehiculoOT_502ag = null;
            
        }
        private void buttonLimpiarPantalla_502ag_Click(object sender, EventArgs e)
        {
            LimpiarPantalla_502ag();
        }
    }
}
