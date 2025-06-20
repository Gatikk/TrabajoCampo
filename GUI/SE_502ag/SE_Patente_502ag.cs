using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_502ag
{
    public class SE_Patente_502ag : SE_Perfil_502ag
    {
        public new string Nombre_502ag { get; set; }
        public SE_Patente_502ag(string pNombre_502ag) : base(pNombre_502ag)
        {
            Nombre_502ag = pNombre_502ag;
        }
    }
}
