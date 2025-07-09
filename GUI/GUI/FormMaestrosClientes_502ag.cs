using BE_502ag;
using BLL_502ag;
using SE_502ag;
using SERVICIOS_502ag;
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
    public partial class FormMaestrosClientes_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";
        private string msgDNI_502ag, msgNombre_502ag, msgApellido_502ag, msgEmail_502ag, msgDireccion_502ag, msgTelefono_502ag;
        private string msgNoHayClientes_502ag, nadaQueModificar_502ag, msgNadaQueBorrar_502ag;
        private string msgDNIYaUtilizado_502ag, msgEmailYaUtilizado_502ag, msgTelefonoYaUtilizado_502ag, msgDNINoValido_502ag, msgNombreNoValido_502ag, msgApellidoNoValido_502ag, msgEmailNoValido_502ag, msgTelefonoNoValido_502ag, msgDireccionNoValida_502ag;
        public FormMaestrosClientes_502ag(FormMenu_502ag formMenu_502ag)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
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
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
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
                if (dgvClientes_502ag.Rows.Count <= 0) { throw new Exception(nadaQueModificar_502ag); }
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
                if (dgvClientes_502ag.Rows.Count <= 0) { throw new Exception(msgNadaQueBorrar_502ag); }
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
                }
                if(opcion_502ag == "Modificar")
                {
                    BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerClienteMaestros_502ag(dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    string email_502ag = tBEmail_502ag.Text;
                    string direccion_502ag = tBDireccion_502ag.Text;
                    string telefono_502ag = tBTelefono_502ag.Text;
                    if (email_502ag != cliente_502ag.Email_502ag)
                    {
                        if (!bllCliente_502ag.VerificarEmailYaRegistrado_502ag(email_502ag)) throw new Exception("Email ya registrado");
                    }
                    if(telefono_502ag != cliente_502ag.Telefono_502ag)
                    {
                        if (!bllCliente_502ag.VerificarTelefonoYaRegistrado_502ag(telefono_502ag)) throw new Exception("Teléfono ya registrado");
                    }
                    if (!bllCliente_502ag.VerificarEmail_502ag(email_502ag)) throw new Exception("Email no válido");
                    if (!bllCliente_502ag.VerificarTelefono_502ag(telefono_502ag)) throw new Exception("Teléfono no válido, siga el formato XX XXXX-XXXX");
                    if (!bllCliente_502ag.VerificarDireccion_502ag(direccion_502ag)) throw new Exception("Dirección no válida, siga el formato Calle XXXX");
                    bllCliente_502ag.ModificarCliente_502ag(cliente_502ag, email_502ag, direccion_502ag, telefono_502ag);
                }
                if(opcion_502ag == "Baja")
                {
                    BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerClienteMaestros_502ag(dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString());
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
            SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
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

        private void buttonVerInformacion_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                if (dgvClientes_502ag.Rows.Count <= 0) throw new Exception(msgNoHayClientes_502ag);
                string dni_502ag = dgvClientes_502ag.SelectedRows[0].Cells[0].Value.ToString();
                BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerClienteMaestros_502ag(dni_502ag);
                MessageBox.Show(
                        msgDNI_502ag + cliente_502ag.DNI_502ag + "\n" +
                        msgNombre_502ag + cliente_502ag.Nombre_502ag + "\n" +
                        msgApellido_502ag + cliente_502ag.Apellido_502ag + "\n" +
                        msgEmail_502ag + cliente_502ag.Email_502ag + "\n" +
                        msgDireccion_502ag + cliente_502ag.Direccion_502ag + "\n" +
                        msgTelefono_502ag + cliente_502ag.Telefono_502ag
                    );

            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void FormMaestrosClientes_502ag_Activated(object sender, EventArgs e)
        {
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if(c_502ag is TextBox)
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
            }
            msgDNI_502ag = traductor_502ag.Traducir_502ag("msgDNI_502ag");
            msgNombre_502ag = traductor_502ag.Traducir_502ag("msgNombre_502ag");
            msgApellido_502ag = traductor_502ag.Traducir_502ag("msgApellido_502ag");
            msgEmail_502ag = traductor_502ag.Traducir_502ag("msgEmail_502ag");
            msgDireccion_502ag = traductor_502ag.Traducir_502ag("msgDireccion_502ag");
            msgTelefono_502ag = traductor_502ag.Traducir_502ag("msgTelefono_502ag");
            msgNoHayClientes_502ag = traductor_502ag.Traducir_502ag("msgNoHayClientes_502ag");
            nadaQueModificar_502ag = traductor_502ag.Traducir_502ag("nadaQueModificar_502ag");
            msgNadaQueBorrar_502ag = traductor_502ag.Traducir_502ag("msgNadaQueBorrar_502ag");
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
