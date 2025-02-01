using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE;

namespace ORM
{
    public class ORM_Usuario
    {

        public static bool ValidarUsuario(string nombre, string contraseña)
        {
            bool esValido = false;

            DataRow dr = DAO_Usuario.DevolverDTUsuario().Rows.Find(nombre);

            if (dr[1].ToString() == contraseña)
            {
                esValido = true;
            }
            return esValido;
        }
    }
}
