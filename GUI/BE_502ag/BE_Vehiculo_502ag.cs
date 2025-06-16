using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Vehiculo_502ag
    {
        public decimal CantidadActual_502ag { get; set; }
        public decimal CantidadMaxima_502ag { get; set; }
        private Random random_502ag = new Random();
        public BE_Vehiculo_502ag()
        {
            CantidadActual_502ag = random_502ag.Next(1, 21);
            CantidadMaxima_502ag = random_502ag.Next(45, 61);   
        }
    }
}
