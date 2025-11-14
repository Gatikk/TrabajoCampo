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
    public partial class FormRegistrarVehiculo_502ag : Form
    {
        public FormRegistrarVehiculo_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void buttonRegistrarVehiculo_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Vehiculo_502ag bllVehiculo_502ag = new BLL_Vehiculo_502ag();
                string patente_502ag = tBPatente_502ag.Text;
                string marca_502ag = tBMarca_502ag.Text;
                string modelo_502ag = tBModelo_502ag.Text;
                string anio_502ag = tBAnio_502ag.Text;
                if (!bllVehiculo_502ag.VerificarPatenteYaRegistrada_502ag(patente_502ag)) throw new Exception("La patente ya está registrada.");
                if (!bllVehiculo_502ag.VerificarPatente_502ag(patente_502ag)) throw new Exception("Patente no válida");
                if (int.TryParse(anio_502ag, out int anioInt_502ag));
                if (!bllVehiculo_502ag.VerificarAnio_502ag(anioInt_502ag)) throw new Exception("Año no válido");
                if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(marca_502ag)) throw new Exception("Marca no válida");
                if (!bllVehiculo_502ag.VerificarMarcaModelo_502ag(modelo_502ag)) throw new Exception("Modelo no válido");
                bllVehiculo_502ag.AltaVehiculo_502ag(patente_502ag, marca_502ag, modelo_502ag, anioInt_502ag);
                MessageBox.Show("Vehículo registrado exitosamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
