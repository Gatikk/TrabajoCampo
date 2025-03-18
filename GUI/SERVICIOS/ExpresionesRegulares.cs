using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class ExpresionesRegulares
    {

        public Regex reDNI = new Regex(@"^\d{8}$");
        public Regex reUsuario = new Regex(@"^[a-zA-Z0-9]{3,20}$");
        public Regex reEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
        public Regex reNombreApellido = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{3,40}$");
    }
}
