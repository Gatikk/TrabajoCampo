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
using SERVICIOS_502ag;

namespace GUI
{
    public partial class FormBitacoraCambios_502ag : Form
    {
        public FormBitacoraCambios_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            Mostrar_502ag();
        }

        private void buttonVerInformacion_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
                if (dgvBitacoraClientes_502ag.SelectedRows.Count <= 0) throw new Exception($"No hay nada seleccionado");
                if (dgvBitacoraClientes_502ag.Rows.Count <= 0) throw new Exception("No hay clientes para seleccionar");
                string dni_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[0].Value.ToString();
                string nombre_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[3].Value.ToString();
                string apellido_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[4].Value.ToString();
                string email_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[5].Value.ToString();
                string direccion_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[6].Value.ToString();
                string telefono_502ag = dgvBitacoraClientes_502ag.SelectedRows[0].Cells[7].Value.ToString();
                BE_Cliente_502ag cliente_502ag = new BE_Cliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
                Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
                cliente_502ag.Email_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Email_502ag);
                cliente_502ag.Direccion_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Direccion_502ag);
                cliente_502ag.Telefono_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Telefono_502ag);
                MessageBox.Show(
                        "DNI: " + cliente_502ag.DNI_502ag + "\n" +
                        "Nombre: " + cliente_502ag.Nombre_502ag + "\n" +
                        "Apellido: " + cliente_502ag.Apellido_502ag + "\n" +
                        "Email: " + cliente_502ag.Email_502ag + "\n" +
                        "Dirección: " + cliente_502ag.Direccion_502ag + "\n" +
                        "Teléfono: " + cliente_502ag.Telefono_502ag
                    );

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonActivar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_ClienteBitacora_502ag bllClienteBitacora_502ag = new BLL_ClienteBitacora_502ag();
                if (dgvBitacoraClientes_502ag.SelectedRows.Count <= 0) throw new Exception($"No hay nada seleccionado");
                if (dgvBitacoraClientes_502ag.Rows.Count <= 0) throw new Exception("No hay nada para seleccionar");
                DateTime fechaHora_502ag = DateTime.Parse(dgvBitacoraClientes_502ag.SelectedRows[0].Cells[10].Value.ToString());
                BE_ClienteBitacora_502ag clienteSeleccionado_502ag = bllClienteBitacora_502ag.ObtenerClienteBitacora_502ag(fechaHora_502ag);
                bllClienteBitacora_502ag.ActivarCliente_502ag(clienteSeleccionado_502ag);
                Mostrar_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }
        private void Mostrar_502ag()
        {
            BLL_ClienteBitacora_502ag bllClienteBitacora_502ag = new BLL_ClienteBitacora_502ag();
            dgvBitacoraClientes_502ag.Rows.Clear();

            foreach (BE_ClienteBitacora_502ag cliente_502ag in bllClienteBitacora_502ag.ObtenerClientesBitacora_502ag())
            {
                dgvBitacoraClientes_502ag.Rows.Add(cliente_502ag.DNI_502ag,cliente_502ag.FechaHora_502ag.ToString("dd/MM/yyyy"), cliente_502ag.FechaHora_502ag.ToString(@"HH\:mm\:ss"),cliente_502ag.Nombre_502ag, cliente_502ag.Apellido_502ag, cliente_502ag.Email_502ag, cliente_502ag.Direccion_502ag, cliente_502ag.Telefono_502ag, cliente_502ag.IsClienteActivo_502ag, cliente_502ag.Activo_502ag, cliente_502ag.FechaHora_502ag);
            }

        }

        private void FormBitacoraCambios_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
