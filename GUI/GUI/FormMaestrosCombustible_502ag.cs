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
    public partial class FormMaestrosCombustible_502ag : Form
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";
        public FormMaestrosCombustible_502ag(FormMenu_502ag formMenu_502ag)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
            tBCodigo_502ag.Enabled = false;
            tBNombre_502ag.Enabled = false;
            tBCantidad_502ag.Enabled = false;
            tBPrecio_502ag.Enabled = false;
            menu_502ag = formMenu_502ag;
            Mostrar_502ag(dgvCombustibles_502ag);
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu_502ag.Show();
        }

        private void FormMaestrosCombustible_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonAltaCombustible_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Alta";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaCombustible_502ag.Enabled = false;
                buttonModificarCombustible_502ag.Enabled = false;
                buttonBajaCombustible_502ag.Enabled = false;
                tBCodigo_502ag.Enabled = true;
                tBNombre_502ag.Enabled = true;
                tBCantidad_502ag.Enabled = true;
                tBPrecio_502ag.Enabled = true;
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonModificarCombustible_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvCombustibles_502ag.Rows.Count <= 0) { throw new Exception("No hay nada que modificar"); }
                BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                BE_Combustible_502ag combustible_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                opcion_502ag = "Modificar";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaCombustible_502ag.Enabled = false;
                buttonModificarCombustible_502ag.Enabled = false;
                buttonBajaCombustible_502ag.Enabled = false;
                tBNombre_502ag.Enabled = true;
                tBCantidad_502ag.Enabled = true;
                tBPrecio_502ag.Enabled = true;
                tBCodigo_502ag.Text = combustible_502ag.CodCombustible_502ag;
                tBNombre_502ag.Text = combustible_502ag.Nombre_502ag;
                tBCantidad_502ag.Text = combustible_502ag.CantDisponible_502ag.ToString();
                tBPrecio_502ag.Text = combustible_502ag.PrecioPorLitro_502ag.ToString();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonBajaCombustible_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCombustibles_502ag.Rows.Count <= 0) { throw new Exception("No hay nada que eliminar"); }
                opcion_502ag = "Baja";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaCombustible_502ag.Enabled = false;
                buttonModificarCombustible_502ag.Enabled = false;
                buttonBajaCombustible_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                if(opcion_502ag == "Alta")
                {
                    string codigo_502ag = tBCodigo_502ag.Text;
                    string nombre_502ag = tBNombre_502ag.Text;
                    string cantidad_502ag = tBCantidad_502ag.Text;
                    string precio_502ag = tBPrecio_502ag.Text;
                    if(!bllCombustible_502ag.VerificarDatosIngresadosAlta_502ag(codigo_502ag, nombre_502ag, cantidad_502ag, precio_502ag)) { throw new Exception("Datos ingresados incorrectos"); }
                    bllCombustible_502ag.AltaCombustible_502ag(codigo_502ag, nombre_502ag, decimal.Parse(cantidad_502ag), decimal.Parse(precio_502ag));
                }
                if(opcion_502ag == "Modificar")
                {
                    BE_Combustible_502ag combustible_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    string nombre_502ag = tBNombre_502ag.Text;
                    string cantidad_502ag = tBCantidad_502ag.Text;
                    string precio_502ag = tBPrecio_502ag.Text;
                    bllCombustible_502ag.ModificarCombustible_502ag(combustible_502ag, nombre_502ag, decimal.Parse(cantidad_502ag), decimal.Parse(precio_502ag));
                }
                if(opcion_502ag == "Baja")
                {
                    BE_Combustible_502ag combustible_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                    bllCombustible_502ag.BajaCombustible_502ag(combustible_502ag);
                }
                Mostrar_502ag(dgvCombustibles_502ag);
                opcion_502ag = "Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaCombustible_502ag.Enabled = true;
                buttonBajaCombustible_502ag.Enabled = true;
                buttonModificarCombustible_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBCodigo_502ag.Enabled = false;
                tBNombre_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBPrecio_502ag.Enabled = false;
                tBCodigo_502ag.Clear();
                tBNombre_502ag.Clear();
                tBCantidad_502ag.Clear();
                tBPrecio_502ag.Clear();
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
                buttonAltaCombustible_502ag.Enabled = true;
                buttonBajaCombustible_502ag.Enabled = true;
                buttonModificarCombustible_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBCodigo_502ag.Enabled = false;
                tBNombre_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBPrecio_502ag.Enabled = false;
                tBCodigo_502ag.Clear();
                tBNombre_502ag.Clear();
                tBCantidad_502ag.Clear();
                tBPrecio_502ag.Clear();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void Mostrar_502ag(DataGridView dgv_502ag)
        {
            BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
            dgv_502ag.Rows.Clear();
            foreach (BE_Combustible_502ag combustible_502ag in bllCombustible_502ag.ObtenerListaCombustibles_502ag())
            {
                dgv_502ag.Rows.Add(combustible_502ag.CodCombustible_502ag, combustible_502ag.Nombre_502ag, combustible_502ag.CantDisponible_502ag+" litros", combustible_502ag.PrecioPorLitro_502ag+"$");
            }
        }

        private void dgvCombustibles_502ag_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCombustibles_502ag.SelectedRows.Count > 0 && dgvCombustibles_502ag.Rows.Count > 0)
                {
                    if(opcion_502ag == "Modificar")
                    {
                        BLL_Combustible_502ag bllCombustible_502ag = new BLL_Combustible_502ag();
                        BE_Combustible_502ag combustible_502ag = bllCombustible_502ag.ObtenerCombustible_502ag(dgvCombustibles_502ag.SelectedRows[0].Cells[0].Value.ToString());
                        tBCodigo_502ag.Text = combustible_502ag.CodCombustible_502ag;
                        tBNombre_502ag.Text = combustible_502ag.Nombre_502ag;
                        tBCantidad_502ag.Text = combustible_502ag.CantDisponible_502ag.ToString();
                        tBPrecio_502ag.Text = combustible_502ag.PrecioPorLitro_502ag.ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
