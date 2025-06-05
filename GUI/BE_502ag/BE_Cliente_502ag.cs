using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_502ag
{
    public class BE_Cliente_502ag
    {
        public string DNI_502ag {  get; set; }
        public string Nombre_502ag { get; set; }    
        public string Apellido_502ag { get; set; }
        public string Email_502ag { get; set; } 
        public string Direccion_502ag { get; set; } 
        public string Telefono_502ag { get; set; }
        public bool IsActivo_502ag { get; set; }
        public BE_Cliente_502ag(string pDNI_502ag, string pNombre_502ag, string pApellido_502ag, string pEmail_502ag, string pDireccion_502ag, string pTelefono_502ag)
        {
            DNI_502ag = pDNI_502ag;
            Nombre_502ag = pNombre_502ag;
            Apellido_502ag = pApellido_502ag;
            Email_502ag = pEmail_502ag;
            Direccion_502ag = pDireccion_502ag;
            Telefono_502ag = pTelefono_502ag;
        }
        public BE_Cliente_502ag(string pDNI_502ag, string pNombre_502ag, string pApellido_502ag, string pEmail_502ag, string pDireccion_502ag, string pTelefono_502ag, bool pIsActivo_502ag)
        {
            DNI_502ag = pDNI_502ag;
            Nombre_502ag = pNombre_502ag;
            Apellido_502ag = pApellido_502ag;
            Email_502ag = pEmail_502ag;
            Direccion_502ag = pDireccion_502ag;
            Telefono_502ag = pTelefono_502ag;
            IsActivo_502ag = pIsActivo_502ag;
        }
    }
}
