using BLL_502ag;
using BLLS_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDigitoVerificador_502ag : Form, IObserver_502ag
    {
        public bool yaSePregunto_502ag = false;
        private string digitoVerificadorRecalculado_502ag, errorCalcularDigito_502ag, seleccionarArchivoBAK_502ag, archivoBak_502ag;
        private string seguroRestaurar_502ag, restauracionCompleta_502ag, bdNoCorresponde_502ag, buttonConfirmar_502ag, inconsistenciaDetectada_502ag;
        public FormDigitoVerificador_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private void buttonRecalcularDigito_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
                bllDigitoVerificador_502ag.ActualizarDigitos_502ag();
                MessageBox.Show(digitoVerificadorRecalculado_502ag);
                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                FormLogin_502ag formLogin_502ag = new FormLogin_502ag();
                this.Hide();
                formLogin_502ag.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorCalcularDigito_502ag + ex.Message);
            }
        }

        private void buttonRealizarRestore_502ag_Click(object sender, EventArgs e)
        {
            string carpeta_502ag = @"C:\Backup_502ag";
            if (!Directory.Exists(carpeta_502ag)) { carpeta_502ag = @"C:"; }
            using (OpenFileDialog oFD_502ag = new OpenFileDialog())
            {
                oFD_502ag.Title = seleccionarArchivoBAK_502ag;
                oFD_502ag.InitialDirectory = carpeta_502ag;
                oFD_502ag.Filter = archivoBak_502ag;
                oFD_502ag.FilterIndex = 0;
                oFD_502ag.RestoreDirectory = true;
                oFD_502ag.CheckFileExists = true;
                oFD_502ag.CheckPathExists = true;

                if (oFD_502ag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DialogResult confirmar_502ag = MessageBox.Show(seguroRestaurar_502ag+$"\n{oFD_502ag.FileName}?", buttonConfirmar_502ag, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirmar_502ag == DialogResult.Yes)
                        {
                            string ruta_502ag = oFD_502ag.FileName;
                            BLLS_BackupRestore_502ag bllsBackupRestore_502ag = new BLLS_BackupRestore_502ag();
                            if (bllsBackupRestore_502ag.RealizarRestoreCorreccionDV_502ag(ruta_502ag))
                            {
                                MessageBox.Show(restauracionCompleta_502ag);
                                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                                FormLogin_502ag formLogin_502ag = new FormLogin_502ag();
                                this.Hide();
                                formLogin_502ag.Show();
                            }
                            else
                            {
                                throw new Exception(bdNoCorresponde_502ag);
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            }
        }

        private void buttonSalir_502ag_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonVerInconsistencias_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
                string mensajeInconsistencia = inconsistenciaDetectada_502ag;
                inconsistenciaDetectada_502ag += bllDigitoVerificador_502ag.DetectarInconsistencias_502ag(yaSePregunto_502ag);
                yaSePregunto_502ag = true;
                MessageBox.Show(inconsistenciaDetectada_502ag);

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }


        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if (c_502ag is TextBox || c_502ag is ListBox || c_502ag is RichTextBox)
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
                digitoVerificadorRecalculado_502ag = traductor_502ag.Traducir_502ag("digitoVerificadorRecalculado_502ag");
                errorCalcularDigito_502ag = traductor_502ag.Traducir_502ag("errorCalcularDigito_502ag");
                seleccionarArchivoBAK_502ag = traductor_502ag.Traducir_502ag("seleccionarArchivoBAK_502ag");
                archivoBak_502ag = traductor_502ag.Traducir_502ag("archivoBak_502ag");
                seguroRestaurar_502ag = traductor_502ag.Traducir_502ag("seguroRestaurar_502ag");
                restauracionCompleta_502ag = traductor_502ag.Traducir_502ag("restauracionCompleta_502ag");
                bdNoCorresponde_502ag = traductor_502ag.Traducir_502ag("bdNoCorresponde_502ag");
                buttonConfirmar_502ag = traductor_502ag.Traducir_502ag("buttonConfirmar_502ag");
                inconsistenciaDetectada_502ag = traductor_502ag.Traducir_502ag("inconsistenciaDetectada_502ag");
            }
        }
    }
}
