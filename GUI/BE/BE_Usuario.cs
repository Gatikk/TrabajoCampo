using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {
        public string NombreUsuario { get; set; }    
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public string DNI {  get; set; }    
        public string Email {  get; set; }  
        public bool isBloqueado {  get; set; }  
        public int Intentos { get; set; }
        
        public BE_Usuario(string pNombreUsuario)
        {
            NombreUsuario = pNombreUsuario;
        }
        public BE_Usuario(string pNombreUsuario, string pContraseña, string pRol, string pNombre,string pApellido, string pDNI, string pEmail, bool pIsBloqueado, int pIntentos) 
        {
            NombreUsuario = pNombreUsuario;
            Contraseña = pContraseña;
            Rol = pRol;
            Nombre = pNombre;
            Apellido = pApellido;
            DNI = pDNI;
            Email = pEmail;
            isBloqueado = pIsBloqueado;
            Intentos = pIntentos;
        }        
    }
}
