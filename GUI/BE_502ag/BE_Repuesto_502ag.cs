using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Repuesto_502ag
    {
        public int Codigo_502ag { get; set; }
        public string Descripcion_502ag { get; set; }   
        public decimal Precio_502ag { get; set; }   
        public int CantidadDisponible_502ag { get; set; }   
        public BE_Repuesto_502ag(int pCodigo_502ag, string pDescripcion_502ag, decimal pPrecio_502ag, int pCantidadDisponible_502ag)
        {
            Codigo_502ag = pCodigo_502ag;
            Descripcion_502ag = pDescripcion_502ag;
            Precio_502ag = pPrecio_502ag;
            CantidadDisponible_502ag = pCantidadDisponible_502ag;
        }   
        public BE_Repuesto_502ag(string pDescripcion_502ag, decimal pPrecio_502ag, int pCantidadDisponible_502ag)
        {
            Descripcion_502ag = pDescripcion_502ag;
            Precio_502ag = pPrecio_502ag;
            CantidadDisponible_502ag = pCantidadDisponible_502ag;
        }
    }
}
