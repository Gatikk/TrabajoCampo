using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Bitacora_502ag
    {
        public List<BE_Bitacora_502ag> ObtenerBitacora_502ag()
        {
            List<BE_Bitacora_502ag> listaBitacora_502ag = new List<BE_Bitacora_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Bitacora_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_Bitacora_502ag bitacora_502ag = new BE_Bitacora_502ag(
                                int.Parse(dr_502ag["CodBitacora_502ag"].ToString()),
                                dr_502ag["NombreUsuario_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["Modulo_502ag"].ToString(),
                                dr_502ag["Descripcion_502ag"].ToString(),
                                int.Parse(dr_502ag["Criticidad_502ag"].ToString()));
                            listaBitacora_502ag.Add(bitacora_502ag);
                        }
                    }
                }
            }
            return listaBitacora_502ag;
        }

        public void AltaBitacora_502ag(BE_Bitacora_502ag bitacora_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Bitacora_502ag (NombreUsuario_502ag, Fecha_502ag, Hora_502ag, Modulo_502ag, Descripcion_502ag, Criticidad_502ag) " +
                    "VALUES (@NombreUsuario_502ag, @Fecha_502ag, @Hora_502ag, @Modulo_502ag, @Descripcion_502ag, @Criticidad_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@NombreUsuario_502ag", bitacora_502ag.NombreUsuario_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", bitacora_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", bitacora_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Modulo_502ag", bitacora_502ag.Modulo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Descripcion_502ag", bitacora_502ag.Descripcion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Criticidad_502ag", bitacora_502ag.Criticidad_502ag);
                    

                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }



    }
}
