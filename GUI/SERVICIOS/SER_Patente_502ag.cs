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

        public bool VerificarNombreCargado_502ag(string nombre_502ag)
        {
            bool noSeRepite_502ag = true;
            if (ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null) noSeRepite_502ag = false;
            return noSeRepite_502ag;
        }
    }
}
