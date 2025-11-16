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
    public partial class FormDigitoVerificador_502ag : Form
    {
        public FormDigitoVerificador_502ag()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void buttonRecalcularDigito_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
                bllDigitoVerificador_502ag.ActualizarDigitos_502ag();
                MessageBox.Show("Dígito verificador recalculado");
                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                FormLogin_502ag formLogin_502ag = new FormLogin_502ag();
                this.Hide();
                formLogin_502ag.Show();
            }
            catch(Exception ex) { MessageBox.Show("Error al recalcular dígito verificador: " + ex.Message);
            }
        }

        private void buttonRealizarRestore_502ag_Click(object sender, EventArgs e)
        {
            string carpeta_502ag = @"C:\Backup_502ag";
            if (!Directory.Exists(carpeta_502ag)) { carpeta_502ag = @"C:"; }
            using (OpenFileDialog oFD_502ag = new OpenFileDialog())
            {
                oFD_502ag.Title = $"Seleccionar archivo .bak";
                oFD_502ag.InitialDirectory = carpeta_502ag;
                oFD_502ag.Filter = $"Archivo de backup (*.bak) |*.bak";
                oFD_502ag.FilterIndex = 0;
                oFD_502ag.RestoreDirectory = true;
                oFD_502ag.CheckFileExists = true;
                oFD_502ag.CheckPathExists = true;

                if (oFD_502ag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DialogResult confirmar_502ag = MessageBox.Show($"¿Seguro que desea restaurar\n{oFD_502ag.FileName}?", $"Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirmar_502ag == DialogResult.Yes)
                        {
                            string ruta_502ag = oFD_502ag.FileName;
                            BLLS_BackupRestore_502ag bllsBackupRestore_502ag = new BLLS_BackupRestore_502ag();
                            if (bllsBackupRestore_502ag.RealizarRestoreCorreccionDV_502ag(ruta_502ag))
                            {
                                MessageBox.Show($"Restauración completada");
                                SER_GestorSesion_502ag.GestorSesion_502ag.CerrarSesion_502ag();
                                FormLogin_502ag formLogin_502ag = new FormLogin_502ag();
                                this.Hide();
                                formLogin_502ag.Show();
                            }
                            else
                            {
                                throw new Exception($"La BD no corresponde a BD_502ag");
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
                MessageBox.Show(bllDigitoVerificador_502ag.DetectarInconsistencias_502ag());
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
    }
}
