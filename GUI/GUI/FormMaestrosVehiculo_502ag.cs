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
    public partial class FormMaestrosVehiculo_502ag : Form
    {
        public string opcion_502ag = "Consulta";
        public FormMaestrosVehiculo_502ag()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Mostrar_502ag();
            tBPatente_502ag.Enabled = false;
            tBMarca_502ag.Enabled = false;
            tBModelo_502ag.Enabled = false;
            tBAnio_502ag.Enabled = false;
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            this.Hide();
            formMenu_502ag.Show();
        }

        private void buttonAltaVehiculo_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Alta";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaVehiculo_502ag.Enabled = false;
                buttonModificarVehiculo_502ag.Enabled = false;
                buttonBajaVehiculo_502ag.Enabled = false;
                tBPatente_502ag.Enabled = true;
                tBMarca_502ag.Enabled = true;
                tBModelo_502ag.Enabled = true;
                tBAnio_502ag.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonModificarVehiculo_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculos_502ag.Rows.Count <= 0) { throw new Exception("No hay vehículos para modificar"); }
                if (dgvVehiculos_502ag.SelectedRows.Count < 0) { throw new Exception("Debe seleccionar un vehículo para modificar"); }
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                BE_Vehiculo_502ag vehiculo_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(dgvVehiculos_502ag.SelectedRows[0].Cells[0].Value.ToString());
                opcion_502ag = "Modificar";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaVehiculo_502ag.Enabled = false;
                buttonModificarVehiculo_502ag.Enabled = false;
                buttonBajaVehiculo_502ag.Enabled = false;
                tBMarca_502ag.Enabled = true;
                tBModelo_502ag.Enabled = true;
                tBAnio_502ag.Enabled = true;
                tBPatente_502ag.Text = vehiculo_502ag.Patente_502ag;
                tBMarca_502ag.Text = vehiculo_502ag.Marca_502ag;
                tBModelo_502ag.Text = vehiculo_502ag.Modelo_502ag;
                tBAnio_502ag.Text = vehiculo_502ag.Anio_502ag.ToString();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonBajaVehiculo_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculos_502ag.Rows.Count <= 0) { throw new Exception("No hay vehículos que eliminar"); }
                opcion_502ag = "Baja";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaVehiculo_502ag.Enabled = false;
                buttonModificarVehiculo_502ag.Enabled = false;
                buttonBajaVehiculo_502ag.Enabled = false;
                tBPatente_502ag.Enabled = false;
                tBMarca_502ag.Enabled = false;
                tBModelo_502ag.Enabled = false;
                tBAnio_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                if (opcion_502ag == "Alta")
                {
                    string patente_502ag = tBPatente_502ag.Text;
                    string marca_502ag = tBMarca_502ag.Text;
                    string modelo_502ag = tBModelo_502ag.Text;
                    string anio_502ag = tBAnio_502ag.Text;
                    if (!bllVehiculo_502ag.VerificarPatenteYaRegistrada_502ag(patente_502ag)) throw new Exception("La patente ya está registrada.");
                    if (!bllVehiculo_502ag.VerificarPatente_502ag(patente_502ag)) throw new Exception("Patente no válida");
                    if (int.TryParse(anio_502ag, out int anioInt_502ag)) ;
                    if (!bllVehiculo_502ag.VerificarAnio_502ag(anioInt_502ag)) throw new Exception("Año no válido");
                    if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(marca_502ag)) throw new Exception("Marca no válida");
                    if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(modelo_502ag)) throw new Exception("Modelo no válido");
                    bllVehiculo_502ag.AltaVehiculo_502ag(patente_502ag, marca_502ag, modelo_502ag, anioInt_502ag);
                }
                if (opcion_502ag == "Modificar")
                {
                    BE_Vehiculo_502ag vehiculo_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(dgvVehiculos_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    string marca_502ag = tBMarca_502ag.Text;
                    string modelo_502ag = tBModelo_502ag.Text;
                    string anio_502ag = tBAnio_502ag.Text;
                    if (int.TryParse(anio_502ag, out int anioInt_502ag)) ;
                    if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(marca_502ag)) throw new Exception("Marca no válida");
                    if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(modelo_502ag)) throw new Exception("Modelo no válido");
                    if (!bllVehiculo_502ag.VerificarAnio_502ag(anioInt_502ag)) throw new Exception("Año no válido");
                    bllVehiculo_502ag.ModificarVehiculo_502ag(vehiculo_502ag, marca_502ag, modelo_502ag, anioInt_502ag);
                }
                if (opcion_502ag == "Baja")
                {
                    BE_Vehiculo_502ag vehiculo_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(dgvVehiculos_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    bllVehiculo_502ag.BajaVehiculo_502ag(vehiculo_502ag);
                }
                Mostrar_502ag();
                opcion_502ag = "Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaVehiculo_502ag.Enabled = true;
                buttonBajaVehiculo_502ag.Enabled = true;
                buttonModificarVehiculo_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBPatente_502ag.Enabled = false;
                tBMarca_502ag.Enabled = false;
                tBModelo_502ag.Enabled = false;
                tBAnio_502ag.Enabled = false;
                tBPatente_502ag.Clear();
                tBMarca_502ag.Clear();
                tBModelo_502ag.Clear();
                tBAnio_502ag.Clear();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaVehiculo_502ag.Enabled = true;
                buttonBajaVehiculo_502ag.Enabled = true;
                buttonModificarVehiculo_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBPatente_502ag.Enabled = false;
                tBMarca_502ag.Enabled = false;
                tBModelo_502ag.Enabled = false;
                tBAnio_502ag.Enabled = false;
                tBPatente_502ag.Clear();
                tBMarca_502ag.Clear();
                tBModelo_502ag.Clear();
                tBAnio_502ag.Clear();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void Mostrar_502ag()
        {
            dgvVehiculos_502ag.Rows.Clear();
            BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
            foreach (BE_Vehiculo_502ag vehiculo_502ag in bllVehiculo_502ag.ObtenerVehiculosActivos_502ag())
            {
                dgvVehiculos_502ag.Rows.Add(vehiculo_502ag.Patente_502ag, vehiculo_502ag.Marca_502ag, vehiculo_502ag.Modelo_502ag, vehiculo_502ag.Anio_502ag, vehiculo_502ag.IsActivo_502ag);
            }
        }

        private void FormMaestrosVehiculo_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void dgvVehiculos_502ag_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculos_502ag.SelectedRows.Count > 0 && dgvVehiculos_502ag.Rows.Count > 0)
                {
                    if (opcion_502ag == "Modificar")
                    {
                        BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                        BE_Vehiculo_502ag vehiculo_502ag = bllVehiculo_502ag.ObtenerVehiculo_502ag(dgvVehiculos_502ag.SelectedRows[0].Cells[0].Value.ToString());
                        tBPatente_502ag.Text = vehiculo_502ag.Patente_502ag;
                        tBMarca_502ag.Text = vehiculo_502ag.Marca_502ag;
                        tBModelo_502ag.Text = vehiculo_502ag.Modelo_502ag;
                        tBAnio_502ag.Text = vehiculo_502ag.Anio_502ag.ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAyuda2_502ag_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/1rBZ6yDeokVvQbplN_HHjHqQji06Q8fvfTm7zgQCy49w/edit?tab=t.0#heading=h.1v4doyl333ah");
        }
    }
}
