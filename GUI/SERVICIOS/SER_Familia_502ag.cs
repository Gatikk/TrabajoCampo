using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_502ag;
using DAL_502ag;
using System.Xml.Linq;

namespace SERVICIOS
{
    public class SER_Familia_502ag
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

        public void BorrarFamilia_502ag (SE_Familia_502ag familia_502ag)
        {
            DAL_Familia_502ag dalFamilia_502ag = new DAL_Familia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            dalFamiliaPatente_502ag.BorrarRelacionFamiliaPatente_502ag(familia_502ag);
            dalFamiliaFamilia_502ag.BorrarRelacionFamiliaFamilia_502ag(familia_502ag);
            dalFamilia_502ag.BorrarFamilia_502ag(familia_502ag);
            foreach(SE_Familia_502ag familiaRevisarVacia_502ag in ObtenerListaFamiliasCompleta_502ag())
            {
                if(familiaRevisarVacia_502ag.lista_502ag.Count == 0)
                {
                    BorrarFamilia_502ag(familiaRevisarVacia_502ag);
                }
            }
            serPerfil_502ag.BorrarFamiliaRecienBorradaDePerfil_502ag(familia_502ag);
        }

        public void AsignarPermisosAFamilia_502ag(SE_Familia_502ag familia_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            //elimino posibles redundancias

            //serPerfil_502ag.AsignarPermisosAPerfil_502ag(familia_502ag);
            foreach (SE_Perfil_502ag permiso_502ag in listaPermisos_502ag)
            {
                familia_502ag.lista_502ag.Add(permiso_502ag);
            }

            foreach(SE_Familia_502ag familia in ObtenerListaFamiliasCompleta_502ag())
            {
                EliminarRedundancia(familia_502ag, familia);
            }


            //asigno nuevos permisos 
            dalFamiliaFamilia_502ag.AsignarFamiliaHijoAFamilia(familia_502ag);
            dalFamiliaPatente_502ag.AsignarPatenteAFamilia(familia_502ag);
        }

        public void DesasignarPermisosAFamilia_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_FamiliaFamilia_502ag dalFamiliaFamilia_502ag = new DAL_FamiliaFamilia_502ag();
            DAL_FamiliaPatente_502ag dalFamiliaPatente_502ag = new DAL_FamiliaPatente_502ag();
            dalFamiliaFamilia_502ag.DesasignarFamiliaHijoDeFamilia(familia_502ag);
            dalFamiliaPatente_502ag.DesasignarPatenteDeFamilia(familia_502ag);
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

        public bool PatenteRepetida_502ag(SE_Familia_502ag familia, List<SE_Perfil_502ag> listaPermisos_502ag)
        {          
            foreach (SE_Perfil_502ag permiso_502ag in familia.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente)
                {
                    if (listaPermisos_502ag.Any(x => x.Nombre_502ag == patente.Nombre_502ag)) return false;
                    listaPermisos_502ag.Add(patente);
                }
                else if (permiso_502ag is SE_Familia_502ag familiaARevisar)
                {

                    if(!PatenteRepetida_502ag(familiaARevisar, listaPermisos_502ag)) return false;
                }
            }
            return true;
        }



        public bool CompararFamiliaPadreEHijos(SE_Familia_502ag familiaPadreAAsignar, SE_Familia_502ag familiaHijoAAsignar)
        {
            //familia padre a asignar mantendrá el mismo valor en todo momento ya que hay que confirmar que no aparezca en ninguna familia hija

            if (familiaHijoAAsignar.Nombre_502ag == familiaPadreAAsignar.Nombre_502ag) return false;
            foreach(SE_Perfil_502ag permiso in familiaHijoAAsignar.lista_502ag)
            {
                if(permiso is SE_Familia_502ag subFamilia)
                {
                    if (!CompararFamiliaPadreEHijos(familiaPadreAAsignar, subFamilia)) return false;
                }
            }
            return true;

        }

        private void EliminarRedundancia(SE_Familia_502ag familiaEditada, SE_Familia_502ag familiaARevisar)
        {
            DAL_FamiliaPatente_502ag dalFamiliaPatente = new DAL_FamiliaPatente_502ag();
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            if (ContieneSubfamilia(familiaARevisar, familiaEditada))
            {
                foreach (SE_Perfil_502ag permisoEditado in familiaEditada.lista_502ag)
                {
                    if(permisoEditado is SE_Patente_502ag patenteEditado)
                    {
                        SE_Patente_502ag patenteRepetida = familiaARevisar.lista_502ag.FirstOrDefault(p => p.Nombre_502ag == patenteEditado.Nombre_502ag) as SE_Patente_502ag;
                        if (patenteRepetida != null)
                        {
                            familiaARevisar.Eliminar_502ag(patenteRepetida.Nombre_502ag);
                            dalFamiliaPatente.EliminarPatenteDeFamilia_502ag(familiaARevisar, patenteEditado);

                        }
                    }
                }
            }
        }
        private bool ContieneSubfamilia(SE_Familia_502ag familiaARevisar, SE_Familia_502ag familiaEditada)
        {
            foreach (SE_Perfil_502ag permiso in familiaARevisar.lista_502ag)
            {
                if (permiso is SE_Familia_502ag subFamilia)
                {
                    if (subFamilia.Nombre_502ag == familiaEditada.Nombre_502ag)
                        return true;

                    if (ContieneSubfamilia(subFamilia, familiaEditada))
                        return true;
                }
            }
            return false;
        }
    }
}
