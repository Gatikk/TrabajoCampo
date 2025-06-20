using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;
using DAL_502ag;

namespace SERVICIOS
{
    public class SER_Familia_502ag
    {
        public void AltaFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaPermiso_502ag = new DAL_FamiliaFamilia_502ag();

            dalFamilia_502ag.AltaFamilia_502ag(familia_502ag);
            dalFamiliaPatente_502ag.AltaFamiliaPatente_502ag(familia_502ag);
            dalFamiliaPermiso_502ag.AltaFamiliaFamilia_502ag(familia_502ag);
        }

        public List<SE_Familia_502ag> ObtenerListaFamiliasCompleta_502ag()
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            List<SE_Familia_502ag> listaFamilias_502ag = dalFamilia_502ag.ObtenerListaFamiliasCompleta_502ag();
            foreach (SE_Familia_502ag familia_502ag in listaFamilias_502ag)
            {
                CargarPatentesYFamiliasRecursiva_502ag(familia_502ag);
            }
            return listaFamilias_502ag;
        }

        private void CargarPatentesYFamiliasRecursiva_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            // Cargar patentes de la familia actual
            dalFamiliaPatente_502ag.ObtenerPatentesDeFamilia_502ag(familia_502ag);

            // Cargar subfamilias de la familia actual
            dalFamiliaFamilia_502ag.ObtenerFamiliasDeFamilia_502ag(familia_502ag);

            // Recursivamente cargar patentes y subfamilias de cada subfamilia
            foreach (SE_Perfil_502ag hijo_502ag in familia_502ag.lista_502ag)
            {
                if(hijo_502ag is SE_Familia_502ag familiaHijo_502ag)
                {
                    CargarPatentesYFamiliasRecursiva_502ag(familiaHijo_502ag);
                }
            }
        }

        public SE_Familia_502ag ObtenerFamiliaConcreta_502ag(SE_Familia_502ag familia_502ag)
        {
            SE_Familia_502ag familiaActual = familia_502ag;
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            dalFamilia_502ag.ObtenerFamiliaConcreta_502ag(familiaActual);
            
            CargarPatentesYFamiliasRecursiva_502ag(familiaActual);
            return familiaActual;
        }
        /*
        public bool FamiliaYaContieneFamilia_502ag(SE_Familia_502ag familiaPadre_502ag)
        {
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            bool yaContiene_502ag = false;

            foreach(SE_Perfil_502ag perfil_502ag in familiaPadre_502ag.lista_502ag)
            {
                if(perfil_502ag is SE_Familia_502ag familiaHijo_502ag)
                {
                    yaContiene_502ag = dalFamiliaFamilia_502ag.FamiliaEsHijo_502ag(familiaHijo_502ag, familiaPadre_502ag);
                }
            }
            return yaContiene_502ag;
        }*/

        /*
        public bool PatenteOFamiliaRepetido(SE_Familia_502ag familia, List<string> listaNombres)
        {
            bool esValido = true;
            
            foreach (SE_Perfil_502ag perfil in familia.lista_502ag)
            {
                if(perfil is SE_Patente_502ag patente)
                {
                    if (listaNombres.Contains(patente.Nombre_502ag)) return false;
                    listaNombres.Add(patente.Nombre_502ag);
                }         
                if (perfil is SE_Familia_502ag familiaARevisar)
                {
                    CargarPatentesYFamiliasRecursiva_502ag(familiaARevisar);
                    PatenteOFamiliaRepetido(familiaARevisar, listaNombres);
                }
            }
            return esValido;
        }      */

        public bool PatenteOFamiliaRepetido(SE_Familia_502ag familia, List<SE_Perfil_502ag> listaPerfiles)
        {
            foreach (SE_Perfil_502ag perfil in familia.lista_502ag)
            {
                if (perfil is SE_Patente_502ag patente)
                {
                    if (listaPerfiles.Any(x => x.Nombre_502ag == patente.Nombre_502ag)) return false;
                    listaPerfiles.Add(patente);
                }
                else if (perfil is SE_Familia_502ag familiaARevisar)
                {
                    if(!PatenteOFamiliaRepetido(familiaARevisar, listaPerfiles)) return false;
                }
            }
            return true;
        }
    }
}
