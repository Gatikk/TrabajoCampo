using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {
        public string Nombre { get; set; }    
       
        
        public BE_Usuario(string pNombre) 
        {
            Nombre = pNombre;
        }

        
    }
}
