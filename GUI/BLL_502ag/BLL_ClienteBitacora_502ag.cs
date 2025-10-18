using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_502ag;
using BE_502ag;

namespace BLL_502ag
{
    public class BLL_ClienteBitacora_502ag
    {
        public void ActivarCliente_502ag(BE_ClienteBitacora_502ag clienteBitacora_502ag)
        {
            DAL_BitacoraCambiosCliente_502ag dalBitacoraCambiosCliente_502ag = new DAL_BitacoraCambiosCliente_502ag();
            dalBitacoraCambiosCliente_502ag.ActivarCliente_502ag(clienteBitacora_502ag);
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoCliente_502ag(bllCliente_502ag.CalcularDVH_502ag(), bllCliente_502ag.CalcularDVV_502ag());
        }
        public List<BE_ClienteBitacora_502ag> ObtenerClientesBitacora_502ag()
        {
            DAL_BitacoraCambiosCliente_502ag dalBitacoraCambiosCliente_502ag = new DAL_BitacoraCambiosCliente_502ag();
            return dalBitacoraCambiosCliente_502ag.ObtenerClientesBitacora_502ag();
        }
        public BE_ClienteBitacora_502ag ObtenerClienteBitacora_502ag(DateTime fecha_502ag)
        {
            DAL_BitacoraCambiosCliente_502ag dalBitacoraCambiosCliente_502ag = new DAL_BitacoraCambiosCliente_502ag();
            return dalBitacoraCambiosCliente_502ag.ObtenerClienteBitacora_502ag(fecha_502ag);
        }
        public List<BE_ClienteBitacora_502ag> ObtenerClientesBitacoraFiltrado_502ag(string dni_502ag, string nombre_502ag, string apellido_502ag, DateTime fechaDesde_502ag, DateTime fechaHasta_502ag)
        {
            DAL_BitacoraCambiosCliente_502ag dalBitacoraCambiosCliente_502ag = new DAL_BitacoraCambiosCliente_502ag();
            return dalBitacoraCambiosCliente_502ag.ObtenerClientesBitacoraFiltrado_502ag(dni_502ag, nombre_502ag, apellido_502ag, fechaDesde_502ag, fechaHasta_502ag);
        }
        public List<string> NombresPorDNI_502ag(string dni_502ag)
        {
            DAL_BitacoraCambiosCliente_502ag dalBitacoraCambiosCliente_502ag = new DAL_BitacoraCambiosCliente_502ag();
            return dalBitacoraCambiosCliente_502ag.NombresPorDNI_502ag(dni_502ag);
        }

    }
}
