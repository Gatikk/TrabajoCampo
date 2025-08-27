using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_502ag;

namespace DAL_502ag
{
    public class DAL_OrdenTrabajo_502ag
    {

        public void GenerarOrdenTrabajo_502ag(BE_OrdenTrabajo_502ag ordenTrabajo_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO OrdenTrabajo_502ag (Codigo_502ag, DNICliente_502ag, PatenteVehiculo_502ag, Fecha_502ag, Hora_502ag, Estado_502ag, Observaciones_502ag) VALUES (@Codigo_502ag, @DNICliente_502ag, @PatenteVehiculo_502ag, @Fecha_502ag, @Hora_502ag, @Estado_502ag, @Observaciones_502ag)";
                using(SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", ordenTrabajo_502ag.CodOrdenTrabajo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DNICliente_502ag", ordenTrabajo_502ag.DNICliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@PatenteVehiculo_502ag", ordenTrabajo_502ag.PatenteVehiculo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", ordenTrabajo_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", ordenTrabajo_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Estado_502ag", ordenTrabajo_502ag.Estado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Observaciones_502ag", ordenTrabajo_502ag.Observaciones_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public string ObtenerUltimoCodigoDelDia_502ag(string fecha_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = @"SELECT TOP 1 Codigo_502ag FROM OrdenTrabajo_502ag WHERE LEFT(Codigo_502ag, @FechaLen_502ag) = @Fecha_502ag ORDER BY Codigo_502ag DESC";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@FechaLen_502ag", fecha_502ag.Length);
                    object result = cmd_502ag.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }


    }
}
