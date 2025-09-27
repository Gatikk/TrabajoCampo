using BLLS_502ag;
using SE_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormBitacoraEventos_502ag : Form, IObserver_502ag
    {
        List<SE_Evento_502ag> listaEventos_502ag = new List<SE_Evento_502ag>();
        private string msgFechaDesdeNoMayorHasta_502ag, msgNadaParaImprimir_502ag, msgImpresionExitosa_502ag;
        public FormBitacoraEventos_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            dTPDesde_502ag.Enabled = false;
            dTPHasta_502ag.Enabled = false;
            cBCriticidad_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBEvento_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBModulo_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBUsuario_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            listaEventos_502ag = bllsEvento_502ag.ObtenerEventos_502ag();
            Mostrar_502ag(dgvBitacoraEventos_502ag, todosLosEventos_502ag());
            CargarComboBoxs_502ag();
            Mostrar_502ag(dgvBitacoraEventos_502ag, listaEventos_502ag);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private List<SE_Evento_502ag> todosLosEventos_502ag()
        {
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();   
            return bllsEvento_502ag.ObtenerTodosLosEventos_502ag();
        }

        public void Mostrar_502ag(DataGridView dgv_502ag, List<SE_Evento_502ag> eventos_502ag)
        {
            dgv_502ag.Rows.Clear();
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            foreach (SE_Evento_502ag evento_502ag in eventos_502ag)
            {
                dgv_502ag.Rows.Add(
                    evento_502ag.Usuario_502ag,
                    evento_502ag.Fecha_502ag.ToString("dd/MM/yyyy"),
                    evento_502ag.Hora_502ag.ToString(@"hh\:mm\:ss"),
                    evento_502ag.Modulo_502ag,
                    evento_502ag.Evento_502ag,
                    evento_502ag.Criticidad_502ag
                );
            }
        }

        private void dgvBitacoraEventos_502ag_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarUsuarioActualTB_502ag();
        }

        public void ActualizarUsuarioActualTB_502ag()
        {
            try
            {
                BLLS_Usuario_502ag bllsUsuario_502ag = new BLLS_Usuario_502ag();
                if(dgvBitacoraEventos_502ag.Rows.Count > 0)
                {
                    if(dgvBitacoraEventos_502ag.SelectedRows.Count > 0)
                    {
                        string nombreUsuario_502ag = dgvBitacoraEventos_502ag.SelectedRows[0].Cells[0].Value.ToString();
                        SE_Usuario_502ag usuario_502ag = bllsUsuario_502ag.ObtenerUsuarioPorNombreUsuario_502ag(nombreUsuario_502ag);
                        tBNombre_502ag.Text = usuario_502ag.Nombre_502ag;
                        tBApellido_502ag.Text = usuario_502ag.Apellido_502ag;
                    }
                } 
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void CargarComboBoxUsuario_502ag()
        {
            try
            {
                cBUsuario_502ag.Items.Clear();
                cBUsuario_502ag.Items.Add("");
                cBUsuario_502ag.SelectedIndex = 0;
                List<string> listaUsuariosString_502ag = new List<string>();
                foreach(DataGridViewRow row_502ag in dgvBitacoraEventos_502ag.Rows)
                {
                    if (row_502ag.Cells[0].Value != null)
                    {
                        string usu_502ag = row_502ag.Cells[0].Value.ToString();
                        if (!listaUsuariosString_502ag.Contains(usu_502ag))
                        {
                            listaUsuariosString_502ag.Add(usu_502ag);
                            cBUsuario_502ag.Items.Add(usu_502ag);
                        }
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void CargarComboBoxModulo_502ag()
        {
            try
            {
                cBModulo_502ag.Items.Clear();
                cBModulo_502ag.Items.Add("");
                cBModulo_502ag.SelectedIndex = 0;
                List<string> listaModulosString_502ag = new List<string>();
                foreach (DataGridViewRow row_502ag in dgvBitacoraEventos_502ag.Rows)
                {
                    if (row_502ag.Cells[3].Value != null)
                    {
                        string modulo_502ag = row_502ag.Cells[3].Value.ToString();
                        if (!listaModulosString_502ag.Contains(modulo_502ag))
                        {
                            listaModulosString_502ag.Add(modulo_502ag);
                            cBModulo_502ag.Items.Add(modulo_502ag);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void CargarComboBoxEvento_502ag()
        {
            try
            {
                cBEvento_502ag.Items.Clear();
                cBEvento_502ag.Items.Add("");
                cBEvento_502ag.SelectedIndex = 0;
                List<string> listaEventosString_502ag = new List<string>();
                foreach (DataGridViewRow row_502ag in dgvBitacoraEventos_502ag.Rows)
                {
                    if (row_502ag.Cells[4].Value != null)
                    {
                        string evento_502ag = row_502ag.Cells[4].Value.ToString();
                        if (!listaEventosString_502ag.Contains(evento_502ag))
                        {
                            listaEventosString_502ag.Add(evento_502ag);
                            cBEvento_502ag.Items.Add(evento_502ag);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void CargarComboBoxCriticidad_502ag()
        {
            try
            {
                cBCriticidad_502ag.Items.Clear();
                cBCriticidad_502ag.Items.Add("");
                cBCriticidad_502ag.SelectedIndex = 0;
                List<string> listaCriticidadString_502ag = new List<string>();
                foreach (DataGridViewRow row_502ag in dgvBitacoraEventos_502ag.Rows)
                {
                    if (row_502ag.Cells[5].Value != null)
                    {
                        string criticidad_502ag = row_502ag.Cells[5].Value.ToString();
                        if (!listaCriticidadString_502ag.Contains(criticidad_502ag))
                        {
                            listaCriticidadString_502ag.Add(criticidad_502ag);
                            cBCriticidad_502ag.Items.Add(criticidad_502ag);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void CargarComboBoxs_502ag()
        {
            CargarComboBoxUsuario_502ag();
            CargarComboBoxModulo_502ag();
            CargarComboBoxEvento_502ag();
            CargarComboBoxCriticidad_502ag();
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
                DateTime fechaDesde_502ag = dTPDesde_502ag.Value.Date;
                DateTime fechaHasta_502ag = dTPHasta_502ag.Value.Date;
                if (fechaDesde_502ag > fechaHasta_502ag && checkBoxFecha_502ag.Checked)
                {
                    dTPDesde_502ag.Value = DateTime.Now;
                    dTPHasta_502ag.Value = DateTime.Now;
                    throw new Exception($"{msgFechaDesdeNoMayorHasta_502ag}");
                }
                listaEventos_502ag = bllsEvento_502ag.ObtenerEventosFiltrado_502ag(
                    cBUsuario_502ag.Text,
                    fechaDesde_502ag,
                    fechaHasta_502ag,
                    cBModulo_502ag.Text,
                    cBEvento_502ag.Text,
                    cBCriticidad_502ag.Text,
                    checkBoxFecha_502ag.Checked
                );
                Mostrar_502ag(dgvBitacoraEventos_502ag, listaEventos_502ag);
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag menu_502ag = new FormMenu_502ag();
            menu_502ag.Show();
        }

        private void FormBitacoraEventos_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBoxFecha_502ag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha_502ag.Checked) 
            {
                dTPDesde_502ag.Enabled = true;
                dTPHasta_502ag.Enabled = true;
            }
            else
            {
                dTPDesde_502ag.Enabled = false;
                dTPHasta_502ag.Enabled = false;
            }
        }

        private void buttonImprimir_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaEventos_502ag.Count <= 0) throw new Exception("No hay nada para imprimir.");
                BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
                bllsEvento_502ag.ImprimirEventos_502ag(listaEventos_502ag);
                MessageBox.Show($"{msgImpresionExitosa_502ag}", $"{msgImpresionExitosa_502ag}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void cBModulo_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarComboBoxEventoFiltrado_502ag();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CargarComboBoxEventoFiltrado_502ag()
        {
            try
            {
                cBEvento_502ag.Items.Clear();
                cBEvento_502ag.Items.Add("");
                cBEvento_502ag.SelectedIndex = 0;
                BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
                List<string> listaEventosString_502ag = bllsEvento_502ag.EventosDelModulo_502ag(cBModulo_502ag.Text);
                foreach(string evento_502ag in listaEventosString_502ag)
                {
                    cBEvento_502ag.Items.Add(evento_502ag);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonResetearGrilla_502ag_Click(object sender, EventArgs e)
        {
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            listaEventos_502ag = bllsEvento_502ag.ObtenerEventos_502ag();
            Mostrar_502ag(dgvBitacoraEventos_502ag, listaEventos_502ag);
            checkBoxFecha_502ag.Checked = false;
            dTPDesde_502ag.Enabled = false;
            dTPHasta_502ag.Enabled = false;
            dTPDesde_502ag.Value = DateTime.Now;
            dTPHasta_502ag.Value = DateTime.Now;
            cBUsuario_502ag.SelectedIndex = 0;
            cBCriticidad_502ag.SelectedIndex = 0;
            cBEvento_502ag.SelectedIndex = 0;
            cBModulo_502ag.SelectedIndex = 0;
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if (c_502ag is TextBox || c_502ag is ListBox || c_502ag is DateTimePicker || c_502ag is ComboBox)
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
            msgFechaDesdeNoMayorHasta_502ag = traductor_502ag.Traducir_502ag("msgFechaDesdeNoMayorHasta_502ag");
            msgNadaParaImprimir_502ag = traductor_502ag.Traducir_502ag("msgNadaParaImprimir_502ag");
            msgImpresionExitosa_502ag = traductor_502ag.Traducir_502ag("msgImpresionExitosa_502ag");
        }
    }
}
