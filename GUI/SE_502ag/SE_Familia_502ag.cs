using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_502ag
{
    public class SE_Familia_502ag : SE_Perfil_502ag
    {
        public new string Nombre_502ag { get; set; }
        public List<SE_Perfil_502ag> lista_502ag { get; set; }
        public SE_Familia_502ag(string pNombre_502ag) : base (pNombre_502ag)
        {
            Nombre_502ag = pNombre_502ag;
            lista_502ag = new List<SE_Perfil_502ag>();
        }
        public override void Agregar_502ag(SE_Perfil_502ag perfil_502ag)
        {
            lista_502ag.Add(perfil_502ag);
        }
    }
}
