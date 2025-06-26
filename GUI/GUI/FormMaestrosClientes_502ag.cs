using BE_502ag;
using BLL_502ag;
using SE_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (dgvClientes_502ag.Rows.Count <= 0) { throw new Exception("No hay nada que modificar"); }
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
                tBDNI_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString();
                tBNombre_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[1].Value.ToString();
                tBApellido_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[2].Value.ToString();
                tBEmail_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[3].Value.ToString();
                tBDireccion_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[4].Value.ToString();
                tBTelefono_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[5].Value.ToString();
                if (bool.Parse(dgvClientes_502ag.SelectedRows[0].Cells[6].Value.ToString()) == false)
                {
                    buttonAplicar_502ag.Enabled = false;
                }
                else
                {
                    buttonAplicar_502ag.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonEliminarCliente_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes_502ag.Rows.Count <= 0) { throw new Exception("No hay nada que borrar"); }
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
                    if (!bllCliente_502ag.VerificarDatosIngresados_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag)) throw new Exception("Datos ingresados incorrectos");
                    if (!bllCliente_502ag.VerificarDNIYaRegistrado_502ag(dni_502ag)) throw new Exception("DNI ya utilizado");
                    if (!bllCliente_502ag.VerificarEmailYaRegistrado_502ag(email_502ag)) throw new Exception("Email ya utilizado");
                    if (!bllCliente_502ag.VerificarTelefonoYaRegistrado_502ag(telefono_502ag)) throw new Exception("Teléfono ya utilizado");
                    bllCliente_502ag.AltaCliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
                }
                if(opcion_502ag == "Modificar")
                {
                    BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    string email_502ag = tBEmail_502ag.Text;
                    string direccion_502ag = tBDireccion_502ag.Text;
                    string telefono_502ag = tBTelefono_502ag.Text;
                    if (bllCliente_502ag.VerificarDatosAModificar_502ag(email_502ag, direccion_502ag, telefono_502ag)) throw new Exception("Datos ingresados incorrectos");
                    bllCliente_502ag.ModificarCliente_502ag(cliente_502ag, email_502ag, direccion_502ag, telefono_502ag);
                }
                if(opcion_502ag == "Baja")
                {
                    BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    bllCliente_502ag.BajaCliente_502ag(cliente_502ag);
                    MessageBox.Show("Usuario dado de baja con éxito");
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
                tBDNI_502ag.Clear();
                tBNombre_502ag.Clear();
                tBApellido_502ag.Clear();
                tBEmail_502ag.Clear();
                tBDireccion_502ag.Clear();
                tBTelefono_502ag.Clear();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {
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
            tBDNI_502ag.Clear();
            tBNombre_502ag.Clear();
            tBApellido_502ag.Clear();
            tBEmail_502ag.Clear();
            tBDireccion_502ag.Clear();
            tBTelefono_502ag.Clear();
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
            
            if (rBActivos_502ag.Checked)
            {
                foreach (BE_Cliente_502ag cliente_502ag in bllCliente_502ag.ObtenerListaClientes_502ag().Where(x=>x.IsActivo_502ag == true))
                {
                    dgv_502ag.Rows.Add(cliente_502ag.DNI_502ag, cliente_502ag.Nombre_502ag, cliente_502ag.Apellido_502ag, cliente_502ag.Email_502ag, cliente_502ag.Direccion_502ag, cliente_502ag.Telefono_502ag, cliente_502ag.IsActivo_502ag);
                }
            }
            if (rBTodos_502ag.Checked)
            {
                foreach (BE_Cliente_502ag cliente_502ag in bllCliente_502ag.ObtenerListaClientes_502ag())
                {
                    dgv_502ag.Rows.Add(cliente_502ag.DNI_502ag, cliente_502ag.Nombre_502ag, cliente_502ag.Apellido_502ag, cliente_502ag.Email_502ag, cliente_502ag.Direccion_502ag, cliente_502ag.Telefono_502ag, cliente_502ag.IsActivo_502ag);
                }
            }
        }

        private void dgvClientes_502ag_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes_502ag.SelectedRows.Count > 0 && dgvClientes_502ag.Rows.Count > 0)
                { 
                    if (opcion_502ag == "Modificar")
                    {
                        tBDNI_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString();
                        tBNombre_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[1].Value.ToString();
                        tBApellido_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[2].Value.ToString();
                        tBEmail_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[3].Value.ToString();
                        tBDireccion_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[4].Value.ToString();
                        tBTelefono_502ag.Text = dgvClientes_502ag.SelectedRows[0].Cells[5].Value.ToString();
                        if (bool.Parse(dgvClientes_502ag.SelectedRows[0].Cells[6].Value.ToString()) == false)
                        {
                            buttonAplicar_502ag.Enabled = false;
                        }
                        else
                        {
                            buttonAplicar_502ag.Enabled = true;
                        }
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void rBTodos_502ag_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar_502ag(dgvClientes_502ag);
        }
    }
}
