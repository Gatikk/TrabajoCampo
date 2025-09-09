using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_FacturaTaller_502ag
    {
        public void GenerarFacturaTaller_502ag(BE_FacturaTaller_502ag factura_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {

                string insertQuery_502ag = "INSERT INTO FacturaTaller_502ag (Codigo_502ag, DNICliente_502ag, NombreCliente_502ag, ApellidoCliente_502ag, Fecha_502ag, Hora_502ag, MetodoPago_502ag, Monto_502ag, DescripcionFinal_502ag) VALUES (@Codigo_502ag, @DNICliente_502ag, @NombreCliente_502ag, @ApellidoCliente_502ag, @Fecha_502ag, @Hora_502ag, @MetodoPago_502ag, @Monto_502ag, @DescripcionFinal_502ag)";
                cx_502ag.Open();
                using(SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", factura_502ag.CodFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DNICliente_502ag", factura_502ag.DNICliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@NombreCliente_502ag", factura_502ag.NombreCliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@ApellidoCliente_502ag", factura_502ag.ApellidoCliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", factura_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", factura_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@MetodoPago_502ag", factura_502ag.MetodoPago_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Monto_502ag", factura_502ag.Monto_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DescripcionFinal_502ag", factura_502ag.DescripcionFinal_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<BE_FacturaTaller_502ag> ObtenerFacturasTaller_502ag()
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                List<BE_FacturaTaller_502ag> listaFacturas_502ag = new List<BE_FacturaTaller_502ag>();
                string selectQuery_502ag = "SELECT * FROM FacturaTaller_502ag";
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_FacturaTaller_502ag factura_502ag = new BE_FacturaTaller_502ag(
                                dr_502ag["Codigo_502ag"].ToString(),
                                dr_502ag["DNICliente_502ag"].ToString(),
                                dr_502ag["NombreCliente_502ag"].ToString(),
                                dr_502ag["ApellidoCliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["MetodoPago_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                dr_502ag["DescripcionFinal_502ag"].ToString()
                                );
                            listaFacturas_502ag.Add(factura_502ag);
                        }
                    }
                }
                return listaFacturas_502ag;
            }
        }

        public BE_FacturaTaller_502ag ObtenerFactura_502ag(string codigo_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string selectQuery_502ag = "SELECT * FROM FacturaTaller_502ag WHERE Codigo_502ag = @Codigo_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(selectQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@Codigo_502ag", codigo_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            BE_FacturaTaller_502ag factura_502ag = new BE_FacturaTaller_502ag(
                                dr_502ag["Codigo_502ag"].ToString(),
                                dr_502ag["DNICliente_502ag"].ToString(),
                                dr_502ag["NombreCliente_502ag"].ToString(),
                                dr_502ag["ApellidoCliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["MetodoPago_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                dr_502ag["DescripcionFinal_502ag"].ToString()
                                );
                            return factura_502ag;
                        }
                    }
                }
                return null;
            }
        }
    }
}
