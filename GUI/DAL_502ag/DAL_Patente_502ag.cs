using SE_502ag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_502ag
{
    public class DAL_Patente_502ag
    {
        public List<SE_Patente_502ag> ObtenerListaPatentes_502ag()
        {
            List<SE_Patente_502ag> listaPatentes_502ag = new List<SE_Patente_502ag>();
            using (SqlConnection cx_502ag = DAL_Conexion_502ag.ObtenerConexion_502ag())
            {
                cx_502ag.Open();
                using (SqlCommand cmd_502ag = new SqlCommand("SELECT * FROM Patente_502ag", cx_502ag))
                {
                    using (SqlDataReader dr_502ag = cmd_502ag.ExecuteReader())
                    {               
                        while (dr_502ag.Read())
                        {
                            string nombrePatente_502ag = dr_502ag["NombrePatente_502ag"].ToString();
                            SE_Patente_502ag patente_502ag = new SE_Patente_502ag(nombrePatente_502ag);
                            listaPatentes_502ag.Add(patente_502ag);
                        }
                    }
                }
            }
            return listaPatentes_502ag;
        }
    }
}
