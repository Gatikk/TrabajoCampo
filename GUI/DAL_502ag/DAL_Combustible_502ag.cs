using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Combustible_502ag
    {
        public List<BE_Combustible_502ag> ObtenerListaCombustibles_502ag()
        {
            List<BE_Combustible_502ag> listaCombustibles_502ag = new List<BE_Combustible_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Combustible_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_Combustible_502ag combustible_502ag = new BE_Combustible_502ag(
                                dr_502ag["CodCombustible_502ag"].ToString(),
                                dr_502ag["Nombre_502ag"].ToString(),
                                decimal.Parse(dr_502ag["CantDisponible_502ag"].ToString()),
                                decimal.Parse(dr_502ag["PrecioPorLitro_502ag"].ToString())                                
                                );
                            listaCombustibles_502ag.Add(combustible_502ag);
                        }
                    }
                }
            }
            return listaCombustibles_502ag;
        }

        public BE_Combustible_502ag ObtenerCombustible_502ag(string codCombustible_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Combustible_502ag WHERE CodCombustible_502ag = @CodCombustible_502ag", cx_502ag))
                {
                    cx_502ag.Open();
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", codCombustible_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new BE_Combustible_502ag(
                                dr_502ag["CodCombustible_502ag"].ToString(),
                                dr_502ag["Nombre_502ag"].ToString(),
                                decimal.Parse(dr_502ag["CantDisponible_502ag"].ToString()),
                                decimal.Parse(dr_502ag["PrecioPorLitro_502ag"].ToString())
                            );
                        }
                    }
                }
            }
            return null;
        }

        #region AltaCombustible
        public void AltaCombustible_502ag(BE_Combustible_502ag combustible_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Combustible_502ag (CodCombustible_502ag, Nombre_502ag, CantDisponible_502ag, PrecioPorLitro_502ag)" +
                    "VALUES (@CodCombustible_502ag, @Nombre_502ag, @CantDisponible_502ag, @PrecioPorLitro_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", combustible_502ag.CodCombustible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", combustible_502ag.Nombre_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantDisponible_502ag", combustible_502ag.CantDisponible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@PrecioPorLitro_502ag", combustible_502ag.PrecioPorLitro_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ModificarCombustible
        public void ModificarCombustible_502ag(BE_Combustible_502ag combustible_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Combustible_502ag SET Nombre_502ag = @Nombre_502ag, CantDisponible_502ag = @CantDisponible_502ag, " +
                    "PrecioPorLitro_502ag = @PrecioPorLitro_502ag WHERE CodCombustible_502ag = @CodCombustible_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", combustible_502ag.CodCombustible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", combustible_502ag.Nombre_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantDisponible_502ag", combustible_502ag.CantDisponible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@PrecioPorLitro_502ag", combustible_502ag.PrecioPorLitro_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        } 
        #endregion

        #region BajaCombustible
        public void BajaCombustible_520ag (BE_Combustible_502ag combustible_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string deleteQuery_502ag = "DELETE FROM Combustible_502ag WHERE CodCombustible_502ag = @CodCombustible_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(deleteQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", combustible_502ag.CodCombustible_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ActualizarExistenciaCombustible
        public void ActualizarExistenciaCombustible_502ag(BE_Combustible_502ag combustible_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Combustible_502ag SET CantDisponible_502ag = @CantDisponible_502ag WHERE CodCombustible_502ag = @CodCombustible_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", combustible_502ag.CodCombustible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantDisponible_502ag", combustible_502ag.CantDisponible_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

    }
}
