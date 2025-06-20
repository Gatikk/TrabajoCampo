using SE_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_502ag;

namespace SERVICIOS
{
    public class SER_Patente_502ag
    {
        public List<SE_Patente_502ag> ObtenerListaPatentes_502ag()
        {
            DAL_Patente_502ag dalPatente_502ag = new DAL_Patente_502ag();
            return dalPatente_502ag.ObtenerListaPatentes_502ag();
        }
    }
}
