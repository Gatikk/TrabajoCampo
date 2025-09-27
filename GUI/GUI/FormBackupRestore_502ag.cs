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
    public partial class FormBackupRestore_502ag : Form, IObserver_502ag
    {
        private string messageSeGuardoConExito_502ag, messageRestauracionCompletada_502ag, messageBackupNoCorrespondeABD_502ag, messageSeleccionarArchivoBackup_502ag, messageSeguroRestaurar_502ag, messageArchivoDeBackup_502ag, messageConfirmarRestauracion_502ag;

        private void FormBackupRestore_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public FormBackupRestore_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
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
            messageSeGuardoConExito_502ag = traductor_502ag.Traducir_502ag("messageSeGuardoConExito_502ag");
            messageRestauracionCompletada_502ag = traductor_502ag.Traducir_502ag("messageRestauracionCompletada_502ag");
            messageBackupNoCorrespondeABD_502ag = traductor_502ag.Traducir_502ag("messageBackupNoCorrespondeABD_502ag");
            messageSeleccionarArchivoBackup_502ag = traductor_502ag.Traducir_502ag("messageSeleccionarArchivoBackup_502ag");
            messageSeguroRestaurar_502ag = traductor_502ag.Traducir_502ag("messageSeguroRestaurar_502ag");
            messageArchivoDeBackup_502ag = traductor_502ag.Traducir_502ag("messageArchivoDeBackup_502ag");
            messageConfirmarRestauracion_502ag = traductor_502ag.Traducir_502ag("messageConfirmarRestauracion_502ag");
        }


        private void buttonRealizarBackup_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                //string carpeta_502ag = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backup_502ag");
                string carpeta_502ag = @"C:\Backup_502ag";
                if (!Directory.Exists(carpeta_502ag)) { Directory.CreateDirectory(carpeta_502ag); }
                
                BLLS_BackupRestore_502ag bllsBackupRestore_502ag = new BLLS_BackupRestore_502ag();
                bllsBackupRestore_502ag.RealizarBackup_502ag(carpeta_502ag);

                MessageBox.Show($"{messageSeGuardoConExito_502ag} {carpeta_502ag}");
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonRealizarRestore_502ag_Click(object sender, EventArgs e)
        {
            string carpeta_502ag = @"C:\Backup_502ag";
            if (!Directory.Exists(carpeta_502ag)) { carpeta_502ag = @"C:"; }
            using (OpenFileDialog oFD_502ag = new OpenFileDialog())
            {
                oFD_502ag.Title = $"{messageSeleccionarArchivoBackup_502ag}";
                oFD_502ag.InitialDirectory = carpeta_502ag;
                oFD_502ag.Filter = $"{messageArchivoDeBackup_502ag} (*.bak) |*.bak";
                oFD_502ag.FilterIndex = 0;
                oFD_502ag.RestoreDirectory = true;
                oFD_502ag.CheckFileExists = true;
                oFD_502ag.CheckPathExists = true;

                if (oFD_502ag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DialogResult confirmar_502ag = MessageBox.Show($"{messageSeguroRestaurar_502ag}\n{oFD_502ag.FileName}?",$"{messageConfirmarRestauracion_502ag}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(confirmar_502ag == DialogResult.Yes)
                        {
                            string ruta_502ag = oFD_502ag.FileName;
                            BLLS_BackupRestore_502ag bllsBackupRestore_502ag = new BLLS_BackupRestore_502ag();
                            if (bllsBackupRestore_502ag.RealizarRestore_502ag(ruta_502ag))
                            {
                                MessageBox.Show($"{messageRestauracionCompletada_502ag}");
                            }
                            else
                            {
                                throw new Exception($"{messageBackupNoCorrespondeABD_502ag}");
                            }
                            
                        }
                    
                    }catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            formMenu_502ag.Show();
        }
    }
}
