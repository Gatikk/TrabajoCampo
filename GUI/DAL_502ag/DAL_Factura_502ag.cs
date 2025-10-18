using BE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DAL_502ag
{
    public class DAL_Factura_502ag
    {

        public BE_Factura_502ag ObtenerFactura_502ag(int codFactura_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Factura_502ag WHERE CodFactura_502ag = @CodFactura_502ag", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodFactura_502ag", codFactura_502ag);
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        if (dr_502ag.Read())
                        {
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 1)
                            {
                                return new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    0, //monto
                                    0, //cantcargada
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                            }
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 2)
                            {
                                return new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                            }
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 3)
                            {
                                return new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                    dr_502ag["DNICliente_502ag"].ToString(),
                                    dr_502ag["NombreCliente_502ag"].ToString(),
                                    dr_502ag["ApellidoCliente_502ag"].ToString(),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                            }
                            return new BE_Factura_502ag(
                                int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                dr_502ag["DNICliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["MetodoPago_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                dr_502ag["NombreCliente_502ag"].ToString(),
                                dr_502ag["ApellidoCliente_502ag"].ToString(),
                                int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                dr_502ag["NombreCombustible_502ag"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public List<BE_Factura_502ag> ObtenerListaFacturasNoFacturadas_502ag()
        {
            List<BE_Factura_502ag> listaFacturasNoFacturadas_502ag = new List<BE_Factura_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Factura_502ag WHERE IsFacturado_502ag = 0", cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 1)
                            {
                                BE_Factura_502ag factura_502ag = new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                                listaFacturasNoFacturadas_502ag.Add(factura_502ag);
                            }
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 2)
                            {
                                BE_Factura_502ag factura_502ag = new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                                listaFacturasNoFacturadas_502ag.Add(factura_502ag);
                            }
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 3)
                            {
                                BE_Factura_502ag factura_502ag = new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                    dr_502ag["DNICliente_502ag"].ToString(),
                                    dr_502ag["NombreCliente_502ag"].ToString(),
                                    dr_502ag["ApellidoCliente_502ag"].ToString(),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                                listaFacturasNoFacturadas_502ag.Add(factura_502ag);
                            }
                            if (int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()) == 4)
                            {
                                BE_Factura_502ag factura_502ag = new BE_Factura_502ag(
                                    int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                    dr_502ag["DNICliente_502ag"].ToString(),
                                    DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                    TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                    dr_502ag["MetodoPago_502ag"].ToString(),
                                    decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                    dr_502ag["NombreCliente_502ag"].ToString(),
                                    dr_502ag["ApellidoCliente_502ag"].ToString(),
                                    int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                    decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                    bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                    int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                    dr_502ag["NombreCombustible_502ag"].ToString()
                                );
                                listaFacturasNoFacturadas_502ag.Add(factura_502ag);
                            }

                        }
                    }
                }
            }
            return listaFacturasNoFacturadas_502ag;
        }

        public List<BE_Factura_502ag> ObtenerListaFacturas_502ag()
        {
            List<BE_Factura_502ag> listaFacturas_502ag = new List<BE_Factura_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Factura_502ag WHERE IsFacturado_502ag = 1", cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            BE_Factura_502ag factura_502ag = new BE_Factura_502ag(

                                int.Parse(dr_502ag["CodFactura_502ag"].ToString()),
                                dr_502ag["DNICliente_502ag"].ToString(),
                                DateTime.Parse(dr_502ag["Fecha_502ag"].ToString()),
                                TimeSpan.Parse(dr_502ag["Hora_502ag"].ToString()),
                                dr_502ag["MetodoPago_502ag"].ToString(),
                                decimal.Parse(dr_502ag["Monto_502ag"].ToString()),
                                dr_502ag["NombreCliente_502ag"].ToString(),
                                dr_502ag["ApellidoCliente_502ag"].ToString(),
                                int.Parse(dr_502ag["CodCombustible_502ag"].ToString()),
                                decimal.Parse(dr_502ag["CantCargada_502ag"].ToString()),
                                bool.Parse(dr_502ag["IsFacturado_502ag"].ToString()),
                                int.Parse(dr_502ag["EstadoFactura_502ag"].ToString()),
                                dr_502ag["NombreCombustible_502ag"].ToString()
                            );
                            listaFacturas_502ag.Add(factura_502ag);
                        }
                    }
                }
            }
            return listaFacturas_502ag;
        }

        #region AltaFactura
        public BE_Factura_502ag AltaFactura_502ag(BE_Factura_502ag factura_502ag)
        {
            int cod_502ag = 0;
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string insertQuery_502ag = "INSERT INTO Factura_502ag (CodCombustible_502ag,IsFacturado_502ag, EstadoFactura_502ag, Fecha_502ag, Hora_502ag, NombreCombustible_502ag) " +
                    "VALUES (@CodCombustible_502ag,@IsFacturado_502ag, @EstadoFactura_502ag, @Fecha_502ag, @Hora_502ag, @NombreCombustible_502ag); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd_502ag = new SqlCommand(insertQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", factura_502ag.CodCombustible_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsFacturado_502ag", factura_502ag.IsFacturado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@EstadoFactura_502ag", factura_502ag.EstadoFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", factura_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", factura_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@NombreCombustible_502ag", factura_502ag.NombreCombustible_502ag);
                    object obtenerCodigo_502ag = cmd_502ag.ExecuteScalar();
                    cod_502ag = int.Parse(obtenerCodigo_502ag.ToString());
                    factura_502ag.CodFactura_502ag = cod_502ag;
                }
            }
            return factura_502ag;
        }
        #endregion


        #region ActualizarFactura
        public void ActualizarFacturaRecienCargada_502ag(BE_Factura_502ag factura_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Factura_502ag SET Monto_502ag = @Monto_502ag, " +
                    "CantCargada_502ag = @CantCargada_502ag, " +
                    "EstadoFactura_502ag = @EstadoFactura_502ag, Fecha_502ag = @Fecha_502ag, Hora_502ag = @Hora_502ag WHERE CodFactura_502ag = @CodFactura_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodFactura_502ag", factura_502ag.CodFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Monto_502ag", factura_502ag.Monto_502ag);
                    cmd_502ag.Parameters.AddWithValue("@CantCargada_502ag", factura_502ag.CantCargada_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", factura_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", factura_502ag.Hora_502ag);
                    cmd_502ag.Parameters.AddWithValue("@EstadoFactura_502ag", factura_502ag.EstadoFactura_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarFacturaClienteIdentificado_502ag(BE_Factura_502ag factura_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Factura_502ag SET DNICliente_502ag = @DNICliente_502ag, " +
                    "NombreCliente_502ag = @NombreCliente_502ag, " +
                    "ApellidoCliente_502ag = @ApellidoCliente_502ag, " +
                    "EstadoFactura_502ag = @EstadoFactura_502ag WHERE CodFactura_502ag = @CodFactura_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodFactura_502ag", factura_502ag.CodFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@DNICliente_502ag", factura_502ag.DNICliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@NombreCliente_502ag", factura_502ag.NombreCliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@ApellidoCliente_502ag", factura_502ag.ApellidoCliente_502ag);
                    cmd_502ag.Parameters.AddWithValue("@EstadoFactura_502ag", factura_502ag.EstadoFactura_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarFacturaFinalizada_502ag(BE_Factura_502ag factura_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string updateQuery_502ag = "UPDATE Factura_502ag SET MetodoPago_502ag = @MetodoPago_502ag, IsFacturado_502ag = @IsFacturado_502ag," +
                    "EstadoFactura_502ag = @EstadoFactura_502ag, Fecha_502ag = @Fecha_502ag, Hora_502ag = @Hora_502ag WHERE CodFactura_502ag = @CodFactura_502ag";
                using (SqlCommand cmd_502ag = new SqlCommand(updateQuery_502ag, cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodFactura_502ag", factura_502ag.CodFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@MetodoPago_502ag", factura_502ag.MetodoPago_502ag);
                    cmd_502ag.Parameters.AddWithValue("@IsFacturado_502ag", factura_502ag.IsFacturado_502ag);
                    cmd_502ag.Parameters.AddWithValue("@EstadoFactura_502ag", factura_502ag.EstadoFactura_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Fecha_502ag", factura_502ag.Fecha_502ag);
                    cmd_502ag.Parameters.AddWithValue("@Hora_502ag", factura_502ag.Hora_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }
        #endregion

        public void EliminarFacturasEstadoPendienteDeCarga_502ag(int codCombustible_502ag)
        {
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("DELETE FROM Factura_502ag WHERE CodCombustible_502ag = @CodCombustible_502ag AND EstadoFactura_502ag = 1", cx_502ag))
                {
                    cmd_502ag.Parameters.AddWithValue("@CodCombustible_502ag", codCombustible_502ag);
                    cmd_502ag.ExecuteNonQuery();
                }
            }
        }

        public List<Tuple<string, decimal>> FacturacionPorMes_502ag()
        {
            List<Tuple<string, decimal>> resultados_502ag = new List<Tuple<string, decimal>>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = @"SELECT FORMAT(Fecha_502ag, 'yyyy-MM') AS MesAnio_502ag, SUM(Monto_502ag) AS TotalMensual_502ag FROM Factura_502ag GROUP BY FORMAT(Fecha_502ag, 'yyyy-MM') ORDER BY MesAnio_502ag;";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {

                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string mesAnio_502ag = dr_502ag["MesAnio_502ag"].ToString();
                            decimal totalMensual_502ag = decimal.Parse(dr_502ag["TotalMensual_502ag"].ToString());
                            resultados_502ag.Add(new Tuple<string, decimal>(mesAnio_502ag, totalMensual_502ag));
                        }
                    }
                }
            }
            return resultados_502ag;
        }

        public List<Tuple<string, decimal>> VentasPorCombustible_502ag()
        {
                       List<Tuple<string, decimal>> resultados_502ag = new List<Tuple<string, decimal>>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = @"SELECT NombreCombustible_502ag, SUM(Monto_502ag) AS TotalVentas_502ag FROM Factura_502ag GROUP BY NombreCombustible_502ag ORDER BY TotalVentas_502ag DESC;";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string nombreCombustible_502ag = dr_502ag["NombreCombustible_502ag"].ToString();
                            decimal totalVentas_502ag = decimal.Parse(dr_502ag["TotalVentas_502ag"].ToString());
                            resultados_502ag.Add(new Tuple<string, decimal>(nombreCombustible_502ag, totalVentas_502ag));
                        }
                    }
                }
            }
            return resultados_502ag;
        }

        public List<Tuple<string, decimal>> CargasPorHora_502ag()
        {
            List<Tuple<string, decimal>> resultados_502ag = new List<Tuple<string, decimal>>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                string query_502ag = @"SELECT CASE
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 0 AND 5 THEN 'Madrugada (00-06)'
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 6 AND 11 THEN 'Mañana (06-12)'
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 12 AND 17 THEN 'Tarde (12-18)'
                        ELSE 'Noche (18-24)'
                    END AS RangoHorario_502ag,
                    COUNT(*) AS CantidadCargas_502ag
                FROM Factura_502ag
                GROUP BY
                    CASE
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 0 AND 5 THEN 'Madrugada (00-06)'
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 6 AND 11 THEN 'Mañana (06-12)'
                        WHEN DATEPART(hour, Hora_502ag) BETWEEN 12 AND 17 THEN 'Tarde (12-18)'
                        ELSE 'Noche (18-24)'
                    END
                ORDER BY
                    MIN(DATEPART(hour, Hora_502ag));";
                using (SqlCommand cmd_502ag = new SqlCommand(query_502ag, cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {
                        while (dr_502ag.Read())
                        {
                            string horario_502ag = dr_502ag["RangoHorario_502ag"].ToString();
                            decimal cantidadCargas_502ag = decimal.Parse(dr_502ag["CantidadCargas_502ag"].ToString());
                            resultados_502ag.Add(new Tuple<string, decimal>(horario_502ag, cantidadCargas_502ag));
                        }
                    }
                }
            }
            return resultados_502ag;
        }
    }
}

