using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Vehiculo_502ag
    {
        public void AltaVehiculo_502ag(BE_Vehiculo_502ag vehiculo_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Vehiculo_502ag (Patente_502ag, Marca_502ag, Modelo_502ag, Anio_502ag, IsActivo_502ag) VALUES (@Patente_502ag, @Marca_502ag, @Modelo_502ag, @Anio_502ag, @IsActivo_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Patente_502ag", vehiculo_502ag.Patente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Marca_502ag", vehiculo_502ag.Marca_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Modelo_502ag", vehiculo_502ag.Modelo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Anio_502ag", vehiculo_502ag.Anio_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", vehiculo_502ag.IsActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void ModificarVehiculo_502ag(BE_Vehiculo_502ag vehiculo_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Vehiculo_502ag SET Marca_502ag = @Marca_502ag, Modelo_502ag = @Modelo_502ag, Anio_502ag = @Anio_502ag WHERE Patente_502ag = @Patente_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Patente_502ag", vehiculo_502ag.Patente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Marca_502ag", vehiculo_502ag.Marca_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Modelo_502ag", vehiculo_502ag.Modelo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Anio_502ag", vehiculo_502ag.Anio_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public void BajaVehiculo_502ag(BE_Vehiculo_502ag vehiculo_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Vehiculo_502ag SET IsActivo_502ag = @IsActivo_502ag WHERE Patente_502ag = @Patente_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Patente_502ag", vehiculo_502ag.Patente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", vehiculo_502ag.IsActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        public BE_Vehiculo_502ag ObtenerVehiculo_502ag(string patente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = "SELECT * FROM Vehiculo_502ag WHERE Patente_502ag = @Patente_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Patente_502ag", patente_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            string marca_502ag = dr_502ag["Marca_502ag"].ToString();
                            string modelo_502ag = dr_502ag["Modelo_502ag"].ToString();
                            int anio_502ag = int.Parse(dr_502ag["Anio_502ag"].ToString());
                            bool isActivo_502ag = bool.Parse(dr_502ag["IsActivo_502ag"].ToString());
                            return new BE_Vehiculo_502ag(patente_502ag, marca_502ag, modelo_502ag, anio_502ag, isActivo_502ag);
                        }
                    }
                }
                return null;
            }
        }
        public List<BE_Vehiculo_502ag> ObtenerVehiculos_502ag()
        {
            List<BE_Vehiculo_502ag> vehiculos_502ag = new List<BE_Vehiculo_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = "SELECT * FROM Vehiculo_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    using(SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while(dr_502ag.Read())
                        {
                            string patente_502ag = dr_502ag["Patente_502ag"].ToString();
                            string marca_502ag = dr_502ag["Marca_502ag"].ToString();
                            string modelo_502ag = dr_502ag["Modelo_502ag"].ToString();
                            int anio_502ag = int.Parse(dr_502ag["Anio_502ag"].ToString());
                            bool isActivo_502ag = bool.Parse(dr_502ag["IsActivo_502ag"].ToString());
                            BE_Vehiculo_502ag vehiculo_502ag = new BE_Vehiculo_502ag(patente_502ag, marca_502ag, modelo_502ag, anio_502ag, isActivo_502ag);
                            vehiculos_502ag.Add(vehiculo_502ag);
                        }
                        return vehiculos_502ag;
                    }
                }
            }
        }


    }
}
