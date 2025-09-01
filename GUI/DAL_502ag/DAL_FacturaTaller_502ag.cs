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
        public void AltaFacturaTaller_502ag(BE_FacturaTaller_502ag factura_502ag)
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
    }
}
