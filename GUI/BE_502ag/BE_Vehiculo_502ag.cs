using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Vehiculo_502ag
    {
        //simulación carga
        public decimal CantidadActual_502ag { get; set; }
        public decimal CantidadMaxima_502ag { get; set; }
        private Random random_502ag = new Random();
        public BE_Vehiculo_502ag()
        {
            CantidadActual_502ag = random_502ag.Next(1, 21);
            CantidadMaxima_502ag = random_502ag.Next(45, 61);
        }

        //taller mecánico
        public string Patente_502ag { get; set; }
        public string Marca_502ag { get; set; }
        public string Modelo_502ag { get; set; }
        public int Anio_502ag { get; set; }
        public bool IsActivo_502ag { get; set; } 
        public BE_Vehiculo_502ag(string pPatente_502ag, string pMarca_502ag, string pModelo_502ag, int pAnio_502ag, bool pIsActivo_502ag)
        {
            Patente_502ag = pPatente_502ag;
            Marca_502ag = pMarca_502ag;
            Modelo_502ag = pModelo_502ag;
            Anio_502ag = pAnio_502ag;
            IsActivo_502ag = pIsActivo_502ag;
        }
    }
}
