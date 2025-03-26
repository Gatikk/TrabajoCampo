using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface ISubject
    {
        void Suscribir(IObserver observer); 
        void Desuscribir(IObserver observer);
        void Notificar();
    }
}
