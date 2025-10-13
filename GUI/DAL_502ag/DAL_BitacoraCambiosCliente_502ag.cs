using BE_502ag;
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
            //DESACTIVAR TRIGGER
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string desactivarTrigger_502ag = "DISABLE TRIGGER Trigger_BitacoraCambiosCliente_502ag ON Cliente_502ag";
                using(SqlCommand cmd_502ag = new SqlCommand(desactivarTrigger_502ag, cx_502ag))
                {
                    cmd_502ag.ExecuteNonQuery();
                }
            }   
            //MODIFICAR CLIENTE
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
            //MODIFICAR BITACORA
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
            //ACTIVAR TRIGGER
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
    }
}
