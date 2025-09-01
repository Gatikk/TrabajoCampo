using BLL_502ag;
using BE_502ag;
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
    public partial class FormCobrarClienteTaller_502ag : Form
    {
        public FormCobrarClienteTaller_502ag()
        {
            InitializeComponent();
            Mostrar_502ag();
        }


        private void Mostrar_502ag()
        {
            dgvOrdenesTrabajo_502ag.Rows.Clear();
            BLL_OrdenTrabajo_502ag bllOrdenTrabajo_502ag = new BLL_OrdenTrabajo_502ag();
            List<BE_OrdenTrabajo_502ag> listaOrdenesTrabajo_502ag = bllOrdenTrabajo_502ag.ObtenerOrdenesDeTrabajoPendienteDePago_502ag();
            foreach (BE_OrdenTrabajo_502ag ordenTrabajo_502ag in listaOrdenesTrabajo_502ag)
            {
                dgvOrdenesTrabajo_502ag.Rows.Add(ordenTrabajo_502ag.CodOrdenTrabajo_502ag, ordenTrabajo_502ag.DNICliente_502ag, ordenTrabajo_502ag.PatenteVehiculo_502ag, ordenTrabajo_502ag.Fecha_502ag.ToString("dd/MM/yyyy"), ordenTrabajo_502ag.Hora_502ag.ToString(@"hh\:mm"));
            }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }

        private void buttonRealizarPago_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonSeleccionarOrden_502ag_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiarOrden_502ag_Click(object sender, EventArgs e)
        {

        }
    }
}
