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
    public class DAL_BitacoraCambiosCliente_502ag
    {
        public void ActivarCliente_502ag(BE_ClienteBitacora_502ag clienteBitacora_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string desactivarTrigger_502ag = "DISABLE TRIGGER Trigger_BitacoraCambiosCliente_502ag ON Cliente_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(desactivarTrigger_502ag, cx_502ag))
                {
                    cmd_502ag.ExecuteNonQuery();
                }
            }   
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            BE_Cliente_502ag cliente_502ag = new BE_Cliente_502ag(
                clienteBitacora_502ag.DNI_502ag,
                clienteBitacora_502ag.Nombre_502ag,
                clienteBitacora_502ag.Apellido_502ag,
                clienteBitacora_502ag.Email_502ag,
                clienteBitacora_502ag.Direccion_502ag,
                clienteBitacora_502ag.Telefono_502ag,
                clienteBitacora_502ag.IsClienteActivo_502ag
            );
            dalCliente_502ag.ModificarCliente_502ag(cliente_502ag);
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateBitacora_502ag = "UPDATE BitacoraCambiosCliente_502ag SET Activo_502ag = CASE WHEN FechaHora_502ag = @FechaHora_502ag THEN 1 ELSE 0 END WHERE DNICliente_502ag = @DNI_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(updateBitacora_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@FechaHora_502ag", clienteBitacora_502ag.FechaHora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", clienteBitacora_502ag.DNI_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string desactivarTrigger_502ag = "ENABLE TRIGGER Trigger_BitacoraCambiosCliente_502ag ON Cliente_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(desactivarTrigger_502ag, cx_502ag))
                {
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        
        public List<BE_ClienteBitacora_502ag> ObtenerClientesBitacora_502ag()
        {
            List<BE_ClienteBitacora_502ag> clientes_502ag = new List<BE_ClienteBitacora_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = $"SELECT * FROM BitacoraCambiosCliente_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    using(SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_ClienteBitacora_502ag cliente_502ag = new BE_ClienteBitacora_502ag(
                                dr_502ag["DNICliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["FechaHora_502ag"].ToString()),
                                dr_502ag["Nombre_502ag"].ToString(),
                                dr_502ag["Apellido_502ag"].ToString(),
                                dr_502ag["Email_502ag"].ToString(),
                                dr_502ag["Direccion_502ag"].ToString(),
                                dr_502ag["Telefono_502ag"].ToString(),
                                bool.Parse(dr_502ag["IsActivoCliente_502ag"].ToString()),
                                bool.Parse(dr_502ag["Activo_502ag"].ToString())
                                );
                            clientes_502ag.Add(cliente_502ag);
                        }
                    }
                }
            }
            return clientes_502ag;
        }

        public BE_ClienteBitacora_502ag ObtenerClienteBitacora_502ag(DateTime fecha_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = $"SELECT * FROM BitacoraCambiosCliente_502ag WHERE FechaHora_502ag = @FechaHora_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@FechaHora_502ag", fecha_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            return new BE_ClienteBitacora_502ag(
                                dr_502ag["DNICliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["FechaHora_502ag"].ToString()),
                                dr_502ag["Nombre_502ag"].ToString(),
                                dr_502ag["Apellido_502ag"].ToString(),
                                dr_502ag["Email_502ag"].ToString(),
                                dr_502ag["Direccion_502ag"].ToString(),
                                dr_502ag["Telefono_502ag"].ToString(),
                                bool.Parse(dr_502ag["IsActivoCliente_502ag"].ToString()),
                                bool.Parse(dr_502ag["Activo_502ag"].ToString())
                                );
                        }
                    }
                }
            }
            return null;
        }

        public List<BE_ClienteBitacora_502ag> ObtenerClientesBitacoraFiltrado_502ag(string dni_502ag, string nombre_502ag, string apellido_502ag, DateTime fechaDesde_502ag, DateTime fechaHasta_502ag)
        {
            List<BE_ClienteBitacora_502ag> clientesBitacoraFiltrados_502ag = new List<BE_ClienteBitacora_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = "SELECT * FROM BitacoraCambiosCliente_502ag WHERE 1=1";
                DateTime fechaHastaConHora_502ag = fechaHasta_502ag.Date.AddDays(1).AddSeconds(-1);
                SqlCommand cmd_502ag = new SqlCommand();
                cmd_502ag.Connection = cx_502ag;
                if (!string.IsNullOrEmpty(dni_502ag))
                {
                    query_502ag += " AND DNICliente_502ag = @DNI_502ag";
                    cmd_502ag.Parameters.AddWithValue("@DNI_502ag", dni_502ag);
                }
                if (!string.IsNullOrEmpty(nombre_502ag))
                {
                    query_502ag += " AND Nombre_502ag = @Nombre_502ag";
                    cmd_502ag.Parameters.AddWithValue("@Nombre_502ag", nombre_502ag);
                }
                if (!string.IsNullOrEmpty(apellido_502ag))
                {
                    query_502ag += " AND Apellido_502ag = @Apellido_502ag";
                    cmd_502ag.Parameters.AddWithValue("@Apellido_502ag", apellido_502ag);
                }
                query_502ag += " AND FechaHora_502ag >= @FechaDesde";
                cmd_502ag.Parameters.AddWithValue("@FechaDesde", fechaDesde_502ag);
                query_502ag += " AND FechaHora_502ag <= @FechaHasta";
                cmd_502ag.Parameters.AddWithValue("@FechaHasta", fechaHastaConHora_502ag);
                
                query_502ag += " ORDER BY FechaHora_502ag DESC";

                cmd_502ag.CommandText = query_502ag;

                using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                {
                    while (dr_502ag.Read())
                    {
                        var clienteBitacora_502ag = new BE_ClienteBitacora_502ag(
                            dr_502ag["DNICliente_502ag"].ToString(),
                            DateTime.Parse(dr_502ag["FechaHora_502ag"].ToString()),
                            dr_502ag["Nombre_502ag"].ToString(),
                            dr_502ag["Apellido_502ag"].ToString(),
                            dr_502ag["Email_502ag"].ToString(),
                            dr_502ag["Direccion_502ag"].ToString(),
                            dr_502ag["Telefono_502ag"].ToString(),
                            bool.Parse(dr_502ag["IsActivoCliente_502ag"].ToString()),
                            bool.Parse(dr_502ag["Activo_502ag"].ToString())
                        );
                        clientesBitacoraFiltrados_502ag.Add(clienteBitacora_502ag);
                    }
                }
                return clientesBitacoraFiltrados_502ag;
            }
        }

        public List<string> NombresPorDNI_502ag(string dni_502ag)
        {
            List<string> nombres_502ag = new List<string>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                if (dni_502ag != "")
                {
                    string query_502ag = "SELECT DISTINCT CONCAT(Apellido_502ag, ', ', Nombre_502ag) AS NombreCompleto_502ag FROM BitacoraCambiosCliente_502ag WHERE DNICliente_502ag = @DNICliente_502ag";
                    using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                    {
                        cmd_502ag.Parameters.AddWithValue("@DNICliente_502ag", dni_502ag);
                        using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                        {
                            while (dr_502ag.Read())
                            {
                                nombres_502ag.Add(dr_502ag["NombreCompleto_502ag"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    string query_502ag = "SELECT DISTINCT CONCAT(Apellido_502ag, ', ', Nombre_502ag) AS NombreCompleto_502ag FROM BitacoraCambiosCliente_502ag";
                    using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                    {
                        using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                        {
                            while (dr_502ag.Read())
                            {
                                nombres_502ag.Add(dr_502ag["NombreCompleto_502ag"].ToString());
                            }
                        }
                    }
                }
            }
            return nombres_502ag;
        }
    }
}
