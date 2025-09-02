using BLLS_502ag;
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
    public partial class FormBackupRestore_502ag : Form
    {
        public FormBackupRestore_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
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

                MessageBox.Show($"Se guardó con éxito en {carpeta_502ag}");
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonRealizarRestore_502ag_Click(object sender, EventArgs e)
        {
            string carpeta_502ag = @"C:\Backup_502ag";
            if (!Directory.Exists(carpeta_502ag)) { carpeta_502ag = @"C:"; }
            using (OpenFileDialog oFD_502ag = new OpenFileDialog())
            {
                oFD_502ag.Title = "Seleccionar archivo de backup para restaurar";
                oFD_502ag.InitialDirectory = carpeta_502ag;
                oFD_502ag.Filter = "Archivo de backup (*.bak) |*.bak";
                oFD_502ag.FilterIndex = 0;
                oFD_502ag.RestoreDirectory = true;
                oFD_502ag.CheckFileExists = true;
                oFD_502ag.CheckPathExists = true;

                if (oFD_502ag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DialogResult confirmar_502ag = MessageBox.Show($"Seguro que desea restaurar la base de datos desde :\n{oFD_502ag.FileName}?","Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(confirmar_502ag == DialogResult.Yes)
                        {
                            string ruta_502ag = oFD_502ag.FileName;
                            BLLS_BackupRestore_502ag bllsBackupRestore_502ag = new BLLS_BackupRestore_502ag();
                            if (bllsBackupRestore_502ag.RealizarRestore_502ag(ruta_502ag))
                            {
                                MessageBox.Show($"Restauración completada con éxito");
                            }
                            else
                            {
                                throw new Exception("El archivo seleccionado no es un backup válido de esta base de datos.");
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
