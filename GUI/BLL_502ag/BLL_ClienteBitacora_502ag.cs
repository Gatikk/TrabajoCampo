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

    }
}
