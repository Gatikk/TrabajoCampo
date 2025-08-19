using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;
using SERVICIOS_502ag;
using DAL_502ag;

namespace BLLS_502ag
{
    public class BLLS_Evento_502ag
    {

        public void AltaEvento_502ag(string modulo_502ag, string eventoDesc_502ag, int criticidad_502ag)
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            string fecha_502ag = DateTime.Now.ToString("ddMMyy");
            string ultCodigo_502ag = dalBitacoraEvento_502ag.ObtenerUltimoCodigoDelDia_502ag(fecha_502ag);
            int numero_502ag = 1;
            if(!string.IsNullOrEmpty(ultCodigo_502ag))
            {
                numero_502ag = int.Parse(ultCodigo_502ag.Substring(fecha_502ag.Length)) + 1;
            }
            string cod_502ag = fecha_502ag + numero_502ag.ToString("D4");
            SE_Evento_502ag evento_502ag = new SE_Evento_502ag
                (
                cod_502ag,
                SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag,
                DateTime.Now,
                DateTime.Now.TimeOfDay,
                modulo_502ag,
                eventoDesc_502ag,
                criticidad_502ag
                );         
            dalBitacoraEvento_502ag.AltaEvento_502ag(evento_502ag);
        }

        public List<SE_Evento_502ag> ObtenerEventos_502ag()
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            return dalBitacoraEvento_502ag.ObtenerEventos_502ag();
        }

        public List<SE_Evento_502ag> ObtenerEventosFiltrado_502ag(string usuario_502ag, DateTime fechaDesde_502ag, DateTime fechaHasta_502ag, string modulo_502ag, string eventoDesc_502ag, string criticidad_502ag, bool filtrarPorFecha_502ag)
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            return dalBitacoraEvento_502ag.ObtenerEventosFiltrado_502ag(usuario_502ag, fechaDesde_502ag, fechaHasta_502ag, modulo_502ag, eventoDesc_502ag, criticidad_502ag, filtrarPorFecha_502ag);
        }

    }
}
