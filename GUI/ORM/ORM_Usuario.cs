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

            if (dr != null) 
            {
                if (dr[1].ToString() == contraseña)
                {
                    esValido = true;
                }
            }
            return esValido;   
        }

        public List<BE_Usuario> DevolverListaUsuarios()
        {
            List<BE_Usuario> listaUsuarios = new List<BE_Usuario>();
            foreach(DataRow dr in DAO_Usuario.DevolverDTUsuario().Rows)
            {
                BE_Usuario usuario = new BE_Usuario(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), Convert.ToBoolean(dr[7].ToString()), int.Parse(dr[8].ToString()));
                listaUsuarios.Add(usuario);
            }
            return listaUsuarios;
        }


        public void Alta()
        {

        }
        public void Baja()
        {

        }
        public void Modificar()
        {

        }
    }
}
