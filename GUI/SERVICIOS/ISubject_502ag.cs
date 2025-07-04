using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS_502ag
{
    public interface ISubject_502ag
    {
        void Suscribir_502ag(IObserver_502ag observer_502ag);
        void Desuscribir_502ag(IObserver_502ag observer_502ag);
        void Notificar_502ag();
    }
}
