using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_BitacoraEvento_502ag
    {
        public void AltaEvento_502ag(SE_Evento_502ag evento_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO BitacoraEvento_502ag (Codigo_502ag, Usuario_502ag, Fecha_502ag, Hora_502ag, Modulo_502ag, Evento_502ag, Criticidad_502ag) " +
                    "VALUES (@Codigo_502ag, @Usuario_502ag, @Fecha_502ag, @Hora_502ag, @Modulo_502ag, @Evento_502ag, @Criticidad_502ag)";
                using(SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", evento_502ag.Codigo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Usuario_502ag", evento_502ag.Usuario_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", evento_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", evento_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Modulo_502ag", evento_502ag.Modulo_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Evento_502ag", evento_502ag.Evento_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Criticidad_502ag", evento_502ag.Criticidad_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<SE_Evento_502ag> ObtenerEventos_502ag()
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = "SELECT * FROM BitacoraEvento_502ag WHERE Fecha_502ag >= DATEADD(DAY, -3, GETDATE()) ORDER BY Fecha_502ag DESC, Hora_502ag DESC";
                using(SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    using(SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        List<SE_Evento_502ag> eventos_502ag = new List<SE_Evento_502ag>();
                        while (dr_502ag.Read())
                        {
                            SE_Evento_502ag evento_502ag = new SE_Evento_502ag(
                                dr_502ag["Codigo_502ag"].ToString(),
                                dr_502ag["Usuario_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["Modulo_502ag"].ToString(),
                                dr_502ag["Evento_502ag"].ToString(),
                                Convert.ToInt32(dr_502ag["Criticidad_502ag"])
                            );
                            eventos_502ag.Add(evento_502ag);
                        }
                        return eventos_502ag;
                    }
                }
            }
        }
        public List<SE_Evento_502ag> ObtenerTodosLosEventos_502ag()
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = "SELECT * FROM BitacoraEvento_502ag ";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        List<SE_Evento_502ag> eventos_502ag = new List<SE_Evento_502ag>();
                        while (dr_502ag.Read())
                        {
                            SE_Evento_502ag evento_502ag = new SE_Evento_502ag(
                                dr_502ag["Codigo_502ag"].ToString(),
                                dr_502ag["Usuario_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["Modulo_502ag"].ToString(),
                                dr_502ag["Evento_502ag"].ToString(),
                                Convert.ToInt32(dr_502ag["Criticidad_502ag"])
                            );
                            eventos_502ag.Add(evento_502ag);
                        }
                        return eventos_502ag;
                    }
                }
            }
        }

        public string ObtenerUltimoCodigoDelDia_502ag(string fecha_502ag)
        {
            using(SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = @"SELECT TOP 1 Codigo_502ag FROM BitacoraEvento_502ag WHERE LEFT(Codigo_502ag, @FechaLen_502ag) = @Fecha_502ag ORDER BY Codigo_502ag DESC";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@FechaLen_502ag", fecha_502ag.Length);
                    object result = cmd_502ag.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public List<SE_Evento_502ag> ObtenerEventosFiltrado_502ag(string usuario_502ag, DateTime fechaDesde_502ag, DateTime fechaHasta_502ag, string modulo_502ag, string eventoDesc_502ag, string criticidad_502ag, bool filtrarPorFecha_502ag)
        {
            List<SE_Evento_502ag> eventosFiltrados_502ag = new List<SE_Evento_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = "SELECT * FROM BitacoraEvento_502ag WHERE 1=1";
                SqlCommand cmd_502ag = new SqlCommand();
                cmd_502ag.Connection = cx_502ag;

                if (!string.IsNullOrEmpty(usuario_502ag))
                {
                    query_502ag += " AND Usuario_502ag = @Usuario_502ag";
                    cmd_502ag.Parameters.AddWithValue("@Usuario_502ag", usuario_502ag);
                }

                if(!string.IsNullOrEmpty(modulo_502ag))
                {
                    query_502ag += " AND Modulo_502ag = @Modulo_502ag";
                    cmd_502ag.Parameters.AddWithValue("@Modulo_502ag", modulo_502ag);
                }

                if(!string.IsNullOrEmpty(eventoDesc_502ag))
                {
                    query_502ag += " AND Evento_502ag = @EventoDesc_502ag";
                    cmd_502ag.Parameters.AddWithValue("@EventoDesc_502ag", eventoDesc_502ag);
                }   

                if(!string.IsNullOrEmpty(criticidad_502ag))
                {
                    query_502ag += " AND Criticidad_502ag = @Criticidad_502ag";
                    cmd_502ag.Parameters.AddWithValue("@Criticidad_502ag", criticidad_502ag);
                }

                if (filtrarPorFecha_502ag)
                {
                    query_502ag += " AND Fecha_502ag >= @FechaDesde";
                    cmd_502ag.Parameters.AddWithValue("@FechaDesde", fechaDesde_502ag);

                    query_502ag += " AND Fecha_502ag <= @FechaHasta";
                    cmd_502ag.Parameters.AddWithValue("@FechaHasta", fechaHasta_502ag);
                }

                query_502ag += " ORDER BY Fecha_502ag DESC, Hora_502ag DESC";

                cmd_502ag.CommandText = query_502ag;

                using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                {
                    while (dr_502ag.Read())
                    {
                        var evento_502ag = new SE_Evento_502ag(
                            dr_502ag["Codigo_502ag"].ToString(),
                            dr_502ag["Usuario_502ag"].ToString(),
                            DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                            TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                            dr_502ag["Modulo_502ag"].ToString(),
                            dr_502ag["Evento_502ag"].ToString(),
                            Convert.ToInt32(dr_502ag["Criticidad_502ag"])
                        );
                        eventosFiltrados_502ag.Add(evento_502ag);
                    }
                }
                return eventosFiltrados_502ag;
            }
        }
    }
}
