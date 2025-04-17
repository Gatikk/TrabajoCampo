using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface ISubject_502ag
    {
        void Suscribir(IObserver_502ag observer); 
        void Desuscribir(IObserver_502ag observer);
        void Notificar();
    }
}
