using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_502ag
{
    public abstract class SE_Perfil_502ag
    {
        public string Nombre_502ag { get; set; }

        public SE_Perfil_502ag(string pNombre_502ag)
        {
            Nombre_502ag = pNombre_502ag;
        }
        public virtual void Agregar_502ag(SE_Perfil_502ag perfil_502ag) { }
    }
}
