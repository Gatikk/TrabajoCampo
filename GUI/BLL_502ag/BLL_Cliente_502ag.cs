using BE_502ag;
using DAL_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_Cliente_502ag
    {
        public BE_Cliente_502ag ObtenerCliente_502ag(string dni_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            BE_Cliente_502ag cliente_502ag = dalCliente_502ag.ObtenerCliente_502ag(dni_502ag);
            if(cliente_502ag != null)
            {
                cliente_502ag.Email_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Email_502ag);
                cliente_502ag.Direccion_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Direccion_502ag);
                cliente_502ag.Telefono_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Telefono_502ag);
            }
            if(cliente_502ag != null)
            {
                if (cliente_502ag.IsActivo_502ag == true)
                {
                    return cliente_502ag;
                }
            }
            return null;
            
        }

        public List<BE_Cliente_502ag> ObtenerListaClientes_502ag()
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            List<BE_Cliente_502ag> listaClientes_502ag = dalCliente_502ag.ObtenerListaClientes_502ag();
            foreach (BE_Cliente_502ag cliente_502ag in listaClientes_502ag)
            {
                cliente_502ag.Email_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Email_502ag);
                cliente_502ag.Direccion_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Direccion_502ag);
                cliente_502ag.Telefono_502ag = cifrador_502ag.DesencryptadorReversible_502ag(cliente_502ag.Telefono_502ag);
            }
            return listaClientes_502ag;
        }

        #region AltaCliente     
        public void AltaCliente_502ag(string dni_502ag, string nombre_502ag, string apellido_502ag, string email_502ag, string direccion_502ag, string telefono_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            BE_Cliente_502ag cliente_502ag = new BE_Cliente_502ag(dni_502ag, nombre_502ag, apellido_502ag, email_502ag, direccion_502ag, telefono_502ag);
            cliente_502ag.Email_502ag = cifrador_502ag.EncryptadorReversible_502ag(cliente_502ag.Email_502ag);
            cliente_502ag.Direccion_502ag = cifrador_502ag.EncryptadorReversible_502ag(cliente_502ag.Direccion_502ag);
            cliente_502ag.Telefono_502ag = cifrador_502ag.EncryptadorReversible_502ag(cliente_502ag.Telefono_502ag);
            cliente_502ag.IsActivo_502ag = true;
            dalCliente_502ag.AltaCliente_502ag(cliente_502ag);
        }
        #endregion

        #region BajaCliente
        public void BajaCliente_502ag(BE_Cliente_502ag cliente_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            cliente_502ag.IsActivo_502ag = false;
            dalCliente_502ag.BajaCliente_502ag(cliente_502ag);
        }
        #endregion

        #region ModificarCliente
        public void ModificarCliente_502ag(BE_Cliente_502ag cliente_502ag, string email_502ag, string direccion_502ag, string telefono_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            cliente_502ag.Email_502ag = cifrador_502ag.EncryptadorReversible_502ag(email_502ag);
            cliente_502ag.Direccion_502ag = cifrador_502ag.EncryptadorReversible_502ag(direccion_502ag);
            cliente_502ag.Telefono_502ag = cifrador_502ag.EncryptadorReversible_502ag(telefono_502ag);
            dalCliente_502ag.ModificarCliente_502ag(cliente_502ag);
        }
        #endregion
        public bool VerificarDNIYaRegistrado_502ag(string dni_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            List<BE_Cliente_502ag> listaClientes_502ag = dalCliente_502ag.ObtenerListaClientes_502ag();
            if (listaClientes_502ag.Find(x => x.DNI_502ag == dni_502ag) != null) { return false; }
            return true;
        }
        public bool VerificarEmailYaRegistrado_502ag(string email_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            List<BE_Cliente_502ag> listaClientes_502ag = dalCliente_502ag.ObtenerListaClientes_502ag();
            if (listaClientes_502ag.Find(x => x.Email_502ag == cifrador_502ag.EncryptadorReversible_502ag(email_502ag)) != null) { return false; }
            return true;
        }
        public bool VerificarTelefonoYaRegistrado_502ag(string telefono_502ag)
        {
            DAL_Cliente_502ag dalCliente_502ag = new DAL_Cliente_502ag();
            Encryptador_502ag cifrador_502ag = new Encryptador_502ag();
            List<BE_Cliente_502ag> listaClientes_502ag = dalCliente_502ag.ObtenerListaClientes_502ag();
            if (listaClientes_502ag.Find(x => x.Telefono_502ag == cifrador_502ag.EncryptadorReversible_502ag(telefono_502ag)) != null) { return false; }
            return true;
        }
        public bool VerificarDNI_502ag(string dni_502ag)
        {
            Regex reDNI_502ag = new Regex(@"^\d{8}$");
            if (!reDNI_502ag.IsMatch(dni_502ag)) return false;
            return true;
        }
        public bool VerificarEmail_502ag(string email_502ag)
        {
            Regex reEmail_502ag = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,40}$");
            if (!reEmail_502ag.IsMatch(email_502ag)) return false;
            return true;
        }

        public bool VerificarDireccion_502ag(string direccion_502ag)
        {
            Regex reDireccion_502ag = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s]+ \d{1,5}$");
            if (!reDireccion_502ag.IsMatch(direccion_502ag)) return false;
            return true;
        }

        public bool VerificarTelefono_502ag(string telefono_502ag)
        {
            Regex reTelefono_502ag = new Regex(@"^\d{2} \d{4}-\d{4}$");
            if (!reTelefono_502ag.IsMatch(telefono_502ag)) return false;
            return true;
        }
        public bool VerificarNombre_502ag(string nombre_502ag)
        {
            Regex reNombreApellido_502ag = new Regex(@"^[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{2,18}(\s[A-Z][a-zÁÉÍÓÚáéíóúÑñ]{2,18})?$");
            if (!reNombreApellido_502ag.IsMatch(nombre_502ag)) return false;
            return true;
        }


    }
}
