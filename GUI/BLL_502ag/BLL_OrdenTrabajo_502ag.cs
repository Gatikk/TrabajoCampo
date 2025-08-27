using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_OrdenTrabajo_502ag
    {
        public void GenerarOrdenTrabajo_502ag(BE_Vehiculo_502ag vehiculo_502ag, BE_Cliente_502ag cliente_502ag, string observaciones)
        {
            DAL_OrdenTrabajo_502ag dalOrdenTrabajo_502ag = new DAL_OrdenTrabajo_502ag();
            string fecha_502ag = DateTime.Now.ToString("ddMMyy");
            string ultCodigo_502ag = dalOrdenTrabajo_502ag.ObtenerUltimoCodigoDelDia_502ag(fecha_502ag);
            int numero_502ag = 1;
            if (!string.IsNullOrEmpty(ultCodigo_502ag))
            {
                numero_502ag = int.Parse(ultCodigo_502ag.Substring(fecha_502ag.Length)) + 1;
            }
            string cod_502ag = fecha_502ag + numero_502ag.ToString("D4");
            BE_OrdenTrabajo_502ag ordenTrabajo_502ag = new BE_OrdenTrabajo_502ag(cod_502ag, cliente_502ag.DNI_502ag, vehiculo_502ag.Patente_502ag, "Abierta", observaciones);
            dalOrdenTrabajo_502ag.GenerarOrdenTrabajo_502ag(ordenTrabajo_502ag);

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Taller", "Generar OT", 3);
        }
    }
}
