using BE_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Vehiculo_502ag
    {
        public bool SimulacionCarga_502ag(BE_Vehiculo_502ag vehiculo_502ag, decimal litrosPorCiclo_502ag, decimal litrosRestantes_502ag)
        {
            decimal litrosACargar_502ag = Math.Min(litrosPorCiclo_502ag, litrosRestantes_502ag);
            decimal espacioDisponible_502ag = vehiculo_502ag.CantidadMaxima_502ag - vehiculo_502ag.CantidadActual_502ag;
            litrosACargar_502ag = Math.Min(litrosACargar_502ag, espacioDisponible_502ag);

            vehiculo_502ag.CantidadActual_502ag += litrosACargar_502ag;
            litrosRestantes_502ag -= litrosACargar_502ag;

            return litrosRestantes_502ag <= 0 || vehiculo_502ag.CantidadActual_502ag >= vehiculo_502ag.CantidadMaxima_502ag;
        }
    }
}
