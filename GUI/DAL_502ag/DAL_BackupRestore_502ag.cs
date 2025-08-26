using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_BackupRestore_502ag
    {
        public void RealizarBackup_502ag(string backupUbicacion_502ag)
        {
            string nombreArchivo_502ag = $"{DateTime.Now:ddMMyyHHmm}_PetroStop_502ag.bak";
            string ruta_502ag = System.IO.Path.Combine(backupUbicacion_502ag, nombreArchivo_502ag);
            string queryBackup_502ag = $"BACKUP DATABASE BD_502ag TO DISK ='{ruta_502ag}'";
            
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand(queryBackup_502ag, cx_502ag))
                {
                    cmd_502ag.ExecuteNonQuery();
                }
            }     
        }

        public void RealizarRestore_502ag(string restoreUbicacion_502ag)
        {
                using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
                {
                    cx_502ag.Open();
                    using (SqlCommand cmd_502ag = new SqlCommand("USE master", cx_502ag))
                    {
                        cmd_502ag.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd_502ag = new SqlCommand("ALTER DATABASE BD_502ag SET SINGLE_USER WITH ROLLBACK IMMEDIATE", cx_502ag))
                    {
                        cmd_502ag.ExecuteNonQuery();
                    }
                    string query_502ag = $"RESTORE DATABASE BD_502ag FROM DISK = '{restoreUbicacion_502ag}' WITH REPLACE";
                    using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                    {
                        cmd_502ag.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd_502ag = new SqlCommand("ALTER DATABASE BD_502ag SET MULTI_USER;", cx_502ag))
                    {
                        cmd_502ag.ExecuteNonQuery();
                    }
                }
            
        }
    }
}
