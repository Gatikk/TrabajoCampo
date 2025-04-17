using BE;
using BLL;
using SERVICIOS;
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

        public void Actualizar(Traductor_502ag traductor)
        {
            RecorrerControles(this, traductor);
        }
        public void RecorrerControles(Control control, Traductor_502ag traductor)
        {
            foreach (Control c in control.Controls)
            {
                if(!(c is System.Windows.Forms.ComboBox))
                {
                    c.Text = traductor.Traducir(c.Name);
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
            BLL_Usuario_502ag usuarioBLL = new BLL_Usuario_502ag();
            usuarioBLL.CambiarIdioma(cBLenguajes.SelectedItem.ToString());
            cBLenguajes.Items.Clear();
            LlenarComboBoxIdiomas();
            VerificarComboBox();
            Actualizar(Traductor_502ag.GestorTraductor);
            Traductor_502ag.GestorTraductor.CambiarIdioma();
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormTraductor", "Cambio Idioma", 1);
        }

        public void LlenarComboBoxIdiomas()
        {
            foreach(string idioma in Traductor_502ag.GestorTraductor.DevolverListaIdiomas())
            {
                if(!(cBLenguajes.Items.Contains(idioma)) && SessionManager_502ag.GestorSessionManager.sesion.Idioma != idioma)
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
            BLL_Bitacora_502ag bllBitacora = new BLL_Bitacora_502ag();
            bllBitacora.AltaBitacora("FormABM", "Cierre de sesión", 1);
            Environment.Exit(0);
        }

        private void cBLenguajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarComboBox();
        }
    }
}
