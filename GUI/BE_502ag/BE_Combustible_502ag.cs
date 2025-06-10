using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Combustible_502ag
    {
        public string CodCombustible_502ag {  get; set; }
        public string Nombre_502ag { get; set; }
        public decimal CantDisponible_502ag { get; set; }
        public decimal PrecioPorLitro_502ag { get; set; }

        public BE_Combustible_502ag(string pCodCombustible_502ag, string pNombre_502ag, decimal pCantDisponible_502ag, decimal pPrecioPorLitro_502ag)
        {
            CodCombustible_502ag = pCodCombustible_502ag;
            Nombre_502ag = pNombre_502ag;
            CantDisponible_502ag = pCantDisponible_502ag;
            PrecioPorLitro_502ag = pPrecioPorLitro_502ag;
        }
    }
}
