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
    public partial class FormMaestrosRepuestos_502ag : Form
    {
        public string opcion_502ag = "Consulta";
        public FormMaestrosRepuestos_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Mostrar_502ag();
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled =false;
            tBCantidad_502ag.Enabled = false;
            tBDescripcion_502ag.Enabled = false;
            tBPrecio_502ag.Enabled = false;
        }

        private void buttonAltaRepuesto_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Alta";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaRepuesto_502ag.Enabled = false;
                buttonModificarRepuesto_502ag.Enabled = false;
                buttonBajaRepuesto_502ag.Enabled = false;
                tBDescripcion_502ag.Enabled = true;
                tBPrecio_502ag.Enabled = true;
                tBCantidad_502ag.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonModificarRepuesto_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRepuestos_502ag.Rows.Count <= 0) { throw new Exception("No hay repuestos para modificar"); }
                if (dgvRepuestos_502ag.SelectedRows.Count < 0) { throw new Exception("Debe seleccionar un repuesto para modificar"); }
                BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
                BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                opcion_502ag = "Modificar";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaRepuesto_502ag.Enabled = false;
                buttonModificarRepuesto_502ag.Enabled = false;
                buttonBajaRepuesto_502ag.Enabled = false;
                tBDescripcion_502ag.Enabled = true;
                tBPrecio_502ag.Enabled = true;
                tBCantidad_502ag.Enabled = true;
                tBDescripcion_502ag.Text = repuesto_502ag.Descripcion_502ag;
                tBPrecio_502ag.Text = repuesto_502ag.Precio_502ag.ToString();
                tBCantidad_502ag.Text = repuesto_502ag.CantidadDisponible_502ag.ToString();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonBajaRepuesto_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRepuestos_502ag.Rows.Count <= 0) { throw new Exception("No hay repuestos que eliminar"); }
                opcion_502ag = "Baja";
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAltaRepuesto_502ag.Enabled = false;
                buttonModificarRepuesto_502ag.Enabled = false;
                buttonBajaRepuesto_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBDescripcion_502ag.Enabled = false;
                tBPrecio_502ag.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
                if (opcion_502ag == "Alta")
                {
                    string descripcion_502ag = tBDescripcion_502ag.Text;
                    string precio_502ag = tBPrecio_502ag.Text;
                    string cantidad_502ag = tBCantidad_502ag.Text;
                    if (descripcion_502ag == "") { throw new Exception("Nombre en blanco"); }
                    if (!bllRepuesto_502ag.VerificarDecimalFormatoCorrecto_502ag(precio_502ag)) throw new Exception("Precio no válido");
                    if (!bllRepuesto_502ag.VerificarDecimalFormatoCorrecto_502ag(cantidad_502ag)) throw new Exception("Formato inválido");
                    decimal precioDec_502ag = decimal.Parse(precio_502ag);
                    if(precioDec_502ag <= 0) { throw new Exception("Precio no válido"); }
                    bllRepuesto_502ag.AltaRepuesto_502ag(descripcion_502ag, precioDec_502ag, int.Parse(cantidad_502ag));
                }
                if (opcion_502ag == "Modificar")
                {
                    BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                    string descripcion_502ag = tBDescripcion_502ag.Text;
                    string precio_502ag = tBPrecio_502ag.Text;
                    string cantidad_502ag = tBCantidad_502ag.Text;
                    if (descripcion_502ag == "") { throw new Exception("Nombre en blanco"); }
                    if (!bllRepuesto_502ag.VerificarDecimalFormatoCorrecto_502ag(precio_502ag)) throw new Exception("Precio no válido");
                    if (!bllRepuesto_502ag.VerificarDecimalFormatoCorrecto_502ag(cantidad_502ag)) throw new Exception("Formato inválido");
                    decimal precioDec_502ag = decimal.Parse(precio_502ag);
                    if (precioDec_502ag <= 0) { throw new Exception("Precio no válido"); }
                    bllRepuesto_502ag.ModificarRepuesto_502ag(repuesto_502ag, descripcion_502ag, decimal.Parse(precio_502ag), int.Parse(cantidad_502ag));
                }
                if (opcion_502ag == "Baja")
                {
                    BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                    bllRepuesto_502ag.BajaRepuesto_502ag(repuesto_502ag);
                }
                Mostrar_502ag();
                opcion_502ag = "Consulta";
                buttonAplicar_502ag.Enabled = false;
                buttonCancelar_502ag.Enabled = false;
                buttonAltaRepuesto_502ag.Enabled = true;
                buttonBajaRepuesto_502ag.Enabled = true;
                buttonModificarRepuesto_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBDescripcion_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBPrecio_502ag.Enabled = false;
                tBDescripcion_502ag.Clear();
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
                buttonAltaRepuesto_502ag.Enabled = true;
                buttonBajaRepuesto_502ag.Enabled = true;
                buttonModificarRepuesto_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = true;
                tBDescripcion_502ag.Enabled = false;
                tBCantidad_502ag.Enabled = false;
                tBPrecio_502ag.Enabled = false;
                tBDescripcion_502ag.Clear();
                tBCantidad_502ag.Clear();
                tBPrecio_502ag.Clear();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            FormMenu_502ag menu_502Ag = new FormMenu_502ag();
            this.Hide();
            menu_502Ag.Show();
        }

        private void Mostrar_502ag()
        {
            dgvRepuestos_502ag.Rows.Clear();
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
            foreach(BE_Repuesto_502ag repuesto_502ag in bllRepuesto_502ag.ObtenerListaRepuestos_502ag())
            {
                dgvRepuestos_502ag.Rows.Add(repuesto_502ag.Codigo_502ag, repuesto_502ag.Descripcion_502ag, repuesto_502ag.Precio_502ag, repuesto_502ag.CantidadDisponible_502ag);
            }
        }

        private void FormMaestrosRepuestos_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void dgvRepuestos_502ag_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRepuestos_502ag.SelectedRows.Count > 0 && dgvRepuestos_502ag.Rows.Count > 0)
                {
                    if (opcion_502ag == "Modificar")
                    {
                        BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();
                        BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(int.Parse(dgvRepuestos_502ag.SelectedRows[0].Cells[0].Value.ToString()));
                        tBDescripcion_502ag.Text = repuesto_502ag.Descripcion_502ag;
                        tBCantidad_502ag.Text = repuesto_502ag.CantidadDisponible_502ag.ToString();
                        tBPrecio_502ag.Text = repuesto_502ag.Precio_502ag.ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
