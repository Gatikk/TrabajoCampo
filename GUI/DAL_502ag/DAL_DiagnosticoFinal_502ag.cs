using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_DiagnosticoFinal_502ag
    {
        public void GenerarDiagnosticoFinal_502ag(BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO DiagnosticoFinal_502ag (Codigo_502ag, DescripcionTecnica_502ag, CostoRepuestos_502ag, ManoObra_502ag) VALUES (@Codigo_502ag, @DescripcionTecnica_502ag, @CostoRepuestos_502ag, @ManoObra_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", diagnosticoFinal_502ag.CodDiagnosticoFinal_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DescripcionTecnica_502ag", diagnosticoFinal_502ag.Descripcion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CostoRepuestos_502ag", diagnosticoFinal_502ag.CostoRepuestos_502ag);
                    cmd_502ag.Parameters.AddWithValue("@ManoObra_502ag", diagnosticoFinal_502ag.CostoManoObra_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public BE_DiagnosticoFinal_502ag ObtenerDiagnosticoFinal_502ag(string codigo_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = "SELECT * FROM DiagnosticoFinal_502ag WHERE Codigo_502ag = @Codigo_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", codigo_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            string descripcion_502ag = dr_502ag["DescripcionTecnica_502ag"].ToString();
                            decimal costoRepuestos_502ag = decimal.Parse(dr_502ag["CostoRepuestos_502ag"].ToString());
                            decimal manoObra_502ag = decimal.Parse(dr_502ag["ManoObra_502ag"].ToString());
                            return new BE_DiagnosticoFinal_502ag(codigo_502ag, descripcion_502ag, manoObra_502ag, costoRepuestos_502ag);
                        }
                    }
                }
                return null;
            }
        }
    }
}
