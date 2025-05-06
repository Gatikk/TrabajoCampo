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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormTraductor_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu;
        public FormTraductor_502ag(FormMenu_502ag menuOriginal)
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            LlenarComboBoxIdiomas();
            cBLenguajes.DropDownStyle = ComboBoxStyle.DropDownList;
            VerificarComboBox();
            menu = menuOriginal;
        }

        public void Actualizar_502ag(Traductor_502ag traductor)
        {
            RecorrerControles(this, traductor);
        }
        public void RecorrerControles(Control control, Traductor_502ag traductor)
        {
            foreach (Control c in control.Controls)
            {
                if(!(c is System.Windows.Forms.ComboBox))
                {
                    c.Text = traductor.Traducir_502ag(c.Name);
                }
                if (c.HasChildren)
                {
                    RecorrerControles(c, traductor);
                }
            }
        }

        private void buttonVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }

        private void buttonAceptarCambioIdioma_Click(object sender, EventArgs e)
        {
            SER_GestorUsuario_502ag serGestionUsuario_502ag = new SER_GestorUsuario_502ag();
            serGestionUsuario_502ag.CambiarIdioma_502ag(cBLenguajes.SelectedItem.ToString());
            cBLenguajes.Items.Clear();
            LlenarComboBoxIdiomas();
            VerificarComboBox();
            Actualizar_502ag(Traductor_502ag.GestorTraductor_502ag);
            Traductor_502ag.GestorTraductor_502ag.CambiarIdioma_502ag();
            SER_GestorBitacora_502ag bllBitacora = new SER_GestorBitacora_502ag();
            bllBitacora.AltaBitacora_502ag("FormTraductor", "Cambio Idioma", 1);
        }

        public void LlenarComboBoxIdiomas()
        {
            foreach(string idioma in Traductor_502ag.GestorTraductor_502ag.DevolverListaIdiomas_502ag())
            {
                if(!(cBLenguajes.Items.Contains(idioma)) && SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Idioma_502ag != idioma)
                {
                    cBLenguajes.Items.Add(idioma);
                }
            }
            cBLenguajes.SelectedIndex = 0;
        }

        private void VerificarComboBox()
        {
            if(cBLenguajes.Text == "")
            {
                buttonAceptarCambioIdioma.Enabled = false;
            }
            else
            {
                buttonAceptarCambioIdioma.Enabled=true;
            }
        }

        private void FormTraductor_FormClosed(object sender, FormClosedEventArgs e)
        {
            SER_GestorBitacora_502ag bllBitacora_502ag = new SER_GestorBitacora_502ag();
            bllBitacora_502ag.AltaBitacora_502ag("FormTraductor", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void cBLenguajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarComboBox();
        }
    }
}
