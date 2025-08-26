using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS_502ag
{
    public class BLLS_BackupRestore_502ag
    {
        public void RealizarBackup_502ag(string backupUbicacion_502ag)
        {
            DAL_BackupRestore_502ag dalBackupRestore_502ag = new DAL_BackupRestore_502ag();
            dalBackupRestore_502ag.RealizarBackup_502ag(backupUbicacion_502ag);
        }

        public void RealizarRestore_502ag(string restoreUbicacion_502ag) 
        {
            DAL_BackupRestore_502ag dalBackupRestore_502ag = new DAL_BackupRestore_502ag();
            dalBackupRestore_502ag.RealizarRestore_502ag(restoreUbicacion_502ag);
        }
    }
}
