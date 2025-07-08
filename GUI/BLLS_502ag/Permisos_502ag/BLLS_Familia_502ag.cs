using DAL_502ag;
using SE_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS_502ag
{
    public class BLLS_Familia_502ag
    {
        public void AltaFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();

            dalFamilia_502ag.AltaFamilia_502ag(familia_502ag);
            dalFamiliaPatente_502ag.AltaFamiliaPatente_502ag(familia_502ag);
            dalFamiliaFamilia_502ag.AltaFamiliaFamilia_502ag(familia_502ag);
        }
        public void BorrarFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            dalFamiliaPatente_502ag.BorrarRelacionFamiliaPatente_502ag(familia_502ag);
            dalFamiliaFamilia_502ag.BorrarRelacionFamiliaFamilia_502ag(familia_502ag);
            dalFamilia_502ag.BorrarFamilia_502ag(familia_502ag);
            foreach (SE_Familia_502ag familiaRevisarVacia_502ag in ObtenerListaFamiliasCompleta_502ag())
            {
                if (familiaRevisarVacia_502ag.lista_502ag.Count == 0)
                {
                    BorrarFamilia_502ag(familiaRevisarVacia_502ag);
                }
            }
        }
        public void AsignarPermisosAFamilia_502ag(SE_Familia_502ag familiaAAsignar_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            foreach (SE_Perfil_502ag permiso_502ag in listaPermisos_502ag)
            {
                familiaAAsignar_502ag.lista_502ag.Add(permiso_502ag);
            }
            foreach (SE_Familia_502ag familia_502ag in ObtenerListaFamiliasCompleta_502ag())
            {
                EliminarRedundancia_502ag(familiaAAsignar_502ag, familia_502ag);
            }
            dalFamiliaFamilia_502ag.AsignarFamiliaHijoAFamilia_502ag(familiaAAsignar_502ag);
            dalFamiliaPatente_502ag.AsignarPatenteAFamilia_502ag(familiaAAsignar_502ag);
        }
        public void DesasignarPermisosAFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            dalFamiliaFamilia_502ag.DesasignarFamiliaHijoDeFamilia_502ag(familia_502ag);
            dalFamiliaPatente_502ag.DesasignarPatenteDeFamilia_502ag(familia_502ag);
        }
        public SE_Familia_502ag ObtenerListaProfundidadUno_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();

            dalFamiliaPatente_502ag.ObtenerPatentesDeFamilia_502ag(familia_502ag);
            dalFamiliaFamilia_502ag.ObtenerFamiliasDeFamilia_502ag(familia_502ag);
            return familia_502ag;
        }
        public List<SE_Familia_502ag> ObtenerListaFamiliasCompleta_502ag()
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            List<SE_Familia_502ag> listaFamilias_502ag = dalFamilia_502ag.ObtenerListaFamiliasCompleta_502ag();
            foreach (SE_Familia_502ag familia_502ag in listaFamilias_502ag)
            {
                CargarPatentesYFamiliasRecursiva_502ag(familia_502ag);
            }
            return listaFamilias_502ag;
        }
        public void CargarPatentesYFamiliasRecursiva_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();

            dalFamiliaPatente_502ag.ObtenerPatentesDeFamilia_502ag(familia_502ag);
            dalFamiliaFamilia_502ag.ObtenerFamiliasDeFamilia_502ag(familia_502ag);

            foreach (SE_Perfil_502ag hijo_502ag in familia_502ag.lista_502ag)
            {
                if (hijo_502ag is SE_Familia_502ag familiaHijo_502ag)
                {
                    CargarPatentesYFamiliasRecursiva_502ag(familiaHijo_502ag);
                }
            }
        }
        public bool PatenteRepetida_502ag(SE_Familia_502ag familia_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    if (listaPermisos_502ag.Any(x => x.Nombre_502ag == patente_502ag.Nombre_502ag)) return false;
                    listaPermisos_502ag.Add(patente_502ag);
                }
                else if (permiso_502ag is SE_Familia_502ag familiaARevisar_502ag)
                {

                    if (!PatenteRepetida_502ag(familiaARevisar_502ag, listaPermisos_502ag)) return false;
                }
            }
            return true;
        }
        public bool CompararFamiliaPadreEHijos_502ag(SE_Familia_502ag familiaPadreAAsignar_502ag, SE_Familia_502ag familiaHijoAAsignar_502ag)
        {
            if (familiaHijoAAsignar_502ag.Nombre_502ag == familiaPadreAAsignar_502ag.Nombre_502ag) return false;
            foreach (SE_Perfil_502ag permiso_502ag in familiaHijoAAsignar_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    if (!CompararFamiliaPadreEHijos_502ag(familiaPadreAAsignar_502ag, subFamilia_502ag)) return false;
                }
            }
            return true;

        }
        private void EliminarRedundancia_502ag(SE_Familia_502ag familiaEditada_502ag, SE_Familia_502ag familiaARevisar_502ag)
        {
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            if (ContieneSubfamilia_502ag(familiaARevisar_502ag, familiaEditada_502ag))
            {
                foreach (SE_Perfil_502ag permisoEditado_502ag in familiaEditada_502ag.lista_502ag)
                {
                    if (permisoEditado_502ag is SE_Patente_502ag patenteEditado_502ag)
                    {
                        SE_Patente_502ag patenteRepetida_502ag = familiaARevisar_502ag.lista_502ag.FirstOrDefault(x => x.Nombre_502ag == patenteEditado_502ag.Nombre_502ag) as SE_Patente_502ag;
                        if (patenteRepetida_502ag != null)
                        {
                            familiaARevisar_502ag.Eliminar_502ag(patenteRepetida_502ag.Nombre_502ag);
                            dalFamiliaPatente_502ag.EliminarPatenteDeFamilia_502ag(familiaARevisar_502ag, patenteEditado_502ag);

                        }
                    }
                }
            }
        }
        private bool ContieneSubfamilia_502ag(SE_Familia_502ag familiaARevisar_502ag, SE_Familia_502ag familiaEditada_502ag)
        {
            foreach (SE_Perfil_502ag permiso_502ag in familiaARevisar_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    if (subFamilia_502ag.Nombre_502ag == familiaEditada_502ag.Nombre_502ag)
                        return true;

                    if (ContieneSubfamilia_502ag(subFamilia_502ag, familiaEditada_502ag))
                        return true;
                }
            }
            return false;
        }
        public bool VerificarNombreCargado_502ag(string nombre_502ag)
        {
            bool noSeRepite_502ag = true;
            if (ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null) noSeRepite_502ag = false;
            return noSeRepite_502ag;
        }

        public List<SE_Patente_502ag> ObtenerListaPatentesDeFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            List<SE_Patente_502ag> listaPatentes_502ag = new List<SE_Patente_502ag>();
            foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    listaPatentes_502ag.Add(patente_502ag);
                }
                if(permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    listaPatentes_502ag.AddRange(ObtenerListaPatentesDeFamilia_502ag(subFamilia_502ag));
                }
            }
            return listaPatentes_502ag;
        }
    }
}
