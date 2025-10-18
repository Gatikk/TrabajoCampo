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
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            Mostrar_502ag();
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            this.Hide();
            formMenu_502ag.Show();
        }

        private void buttonAltaVehiculo_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificarVehiculo_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonBajaVehiculo_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {

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
    }
}
