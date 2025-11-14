using SERVICIOS_502ag;
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
    public partial class FormTraductor_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu_502ag;
        private string msgNadaSeleccionado_502ag, msgIdiomaCambiado_502ag;
        public FormTraductor_502ag(FormMenu_502ag formMenu_502ag)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            menu_502ag = formMenu_502ag;
            CargarIdiomasEnComboBox_502ag();
            cBIdiomas_502ag.SelectedIndex = 0; 
            cBIdiomas_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private void FormTraductor_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
            this.Hide();
            menu_502ag.Show();
        }

        private void buttonConfirmar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBIdiomas_502ag.SelectedItem == null) throw new Exception(msgNadaSeleccionado_502ag);
                SERVICIOS_502ag.SER_GestorSesion_502ag.GestorSesion_502ag.CambiarIdioma_502ag(cBIdiomas_502ag.SelectedItem.ToString());
                SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
                Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
                MessageBox.Show(msgIdiomaCambiado_502ag + $"{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Idioma_502ag}");
                SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
                this.Hide();
                menu_502ag.Show();
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}");}
        }

        private void CargarIdiomasEnComboBox_502ag()
        {
            cBIdiomas_502ag.Items.Clear();
            foreach (var idioma in SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.DevolverListaIdiomas_502ag())
            {
                if(idioma.ToString() == SERVICIOS_502ag.SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Idioma_502ag)
                {
                    continue;
                }
                cBIdiomas_502ag.Items.Add(idioma);
            }
        }

        private void FormTraductor_502ag_Activated(object sender, EventArgs e)
        {
            CargarIdiomasEnComboBox_502ag();
            cBIdiomas_502ag.SelectedIndex = 0;
            cBIdiomas_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            
            TraducirControles_502ag(this, traductor_502ag);
        }
        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);

                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
            }
            msgNadaSeleccionado_502ag = traductor_502ag.Traducir_502ag("msgNadaSeleccionado_502ag");
            msgIdiomaCambiado_502ag = traductor_502ag.Traducir_502ag("msgIdiomaCambiado_502ag");
        }
    }
}
