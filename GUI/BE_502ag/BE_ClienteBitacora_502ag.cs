using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_ClienteBitacora_502ag
    {

        public string DNI_502ag { get; set; }
        public DateTime FechaHora_502ag { get; set; }
        public string Nombre_502ag { get; set; }
        public string Apellido_502ag { get; set; }
        public string Email_502ag { get; set; }
        public string Direccion_502ag { get; set; }
        public string Telefono_502ag { get; set; }
        public bool IsClienteActivo_502ag { get; set; }
        public bool Activo_502ag { get; set; }

        public BE_ClienteBitacora_502ag(string pDNI_502ag, DateTime pFechaHora_502ag, string pNombre_502ag, string pApellido_502ag, string pEmail_502ag, string pDireccion_502ag, string pTelefono_502ag, bool pIsClienteActivo_502ag, bool pActivo_502ag)
        {
            DNI_502ag = pDNI_502ag;
            FechaHora_502ag = pFechaHora_502ag;
            Nombre_502ag = pNombre_502ag;
            Apellido_502ag = pApellido_502ag;
            Email_502ag = pEmail_502ag;
            Direccion_502ag = pDireccion_502ag;
            Telefono_502ag = pTelefono_502ag;
            IsClienteActivo_502ag = pIsClienteActivo_502ag;
            Activo_502ag = pActivo_502ag;
        }
    }
}
