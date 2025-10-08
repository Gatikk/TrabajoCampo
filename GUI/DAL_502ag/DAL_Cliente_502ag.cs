using BE_502ag;
using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Cliente_502ag
    {
        public List<BE_Cliente_502ag> ObtenerListaClientes_502ag()
        {
            List<BE_Cliente_502ag> listaClientes_502ag = new List<BE_Cliente_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Cliente_502ag", cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader()) 
                    {
                        while (dr_502ag.Read())
                        {
                            BE_Cliente_502ag cliente_502ag = new BE_Cliente_502ag(
                                dr_502ag["DNI_502ag"].ToString(),
                                dr_502ag["Nombre_502ag"].ToString(),
                                dr_502ag["Apellido_502ag"].ToString(),
                                dr_502ag["Email_502ag"].ToString(),
                                dr_502ag["Direccion_502ag"].ToString(),
                                dr_502ag["Telefono_502ag"].ToString(),
                                bool.Parse(dr_502ag["IsActivo_502ag"].ToString())
                                );
                            listaClientes_502ag.Add(cliente_502ag);              
                        }
                    }
                }
            }
            return listaClientes_502ag;
        }
        public BE_Cliente_502ag ObtenerCliente_502ag(string dni_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Cliente_502ag WHERE DNI_502ag = @DNI_502ag ", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", dni_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new BE_Cliente_502ag(
                               dr_502ag["DNI_502ag"].ToString(),
                               dr_502ag["Nombre_502ag"].ToString(),
                               dr_502ag["Apellido_502ag"].ToString(),
                               dr_502ag["Email_502ag"].ToString(),
                               dr_502ag["Direccion_502ag"].ToString(),
                               dr_502ag["Telefono_502ag"].ToString(),
                               bool.Parse(dr_502ag["IsActivo_502ag"].ToString())
                            );
                        }
                    }
                }
            }
            return null;
        }

        #region AltaCliente
        public void AltaCliente_502ag(BE_Cliente_502ag cliente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Cliente_502ag (DNI_502ag, Nombre_502ag, Apellido_502ag, Email_502ag," +
                    "Direccion_502ag, Telefono_502ag, IsActivo_502ag) " +
                    "VALUES (@DNI_502ag, @Nombre_502ag, @Apellido_502ag, @Email_502ag," +
                    "@Direccion_502ag, @Telefono_502ag, @IsActivo_502ag)";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", cliente_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", cliente_502ag.Nombre_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Apellido_502ag", cliente_502ag.Apellido_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Email_502ag", cliente_502ag.Email_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Direccion_502ag", cliente_502ag.Direccion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Telefono_502ag", cliente_502ag.Telefono_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", cliente_502ag.IsActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region ModificarCliente
        public void ModificarCliente_502ag(BE_Cliente_502ag cliente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Cliente_502ag SET Email_502ag = @Email_502ag, Direccion_502ag = @Direccion_502ag, Telefono_502ag = @Telefono_502ag, IsActivo_502ag = @IsActivo_502ag WHERE DNI_502ag = @DNI_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Cliente_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", cliente_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Email_502ag", cliente_502ag.Email_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Direccion_502ag", cliente_502ag.Direccion_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Telefono_502ag", cliente_502ag.Telefono_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", cliente_502ag.IsActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region BajaCliente
        public void BajaCliente_502ag(BE_Cliente_502ag cliente_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Cliente_502ag SET IsActivo_502ag = @IsActivo_502ag WHERE DNI_502ag = @DNI_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Cliente_502ag", cx_502ag))
                {
                    cmd_502ag.CommandText = updateQuery_502ag;
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", cliente_502ag.DNI_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsActivo_502ag", cliente_502ag.IsActivo_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

    }
}
