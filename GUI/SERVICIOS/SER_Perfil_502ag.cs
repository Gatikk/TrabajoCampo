using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_502ag;
using SE_502ag;

namespace SERVICIOS
{
    public class SER_Perfil_502ag
    {
        public void AltaPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();

            dalPerfil_502ag.AltaPerfil_502ag(perfil_502ag);
            dalPerfilFamilia_502ag.AltaPerfilPatente_502ag(perfil_502ag);
            dalPerfilPatente_502ag.AltaPerfilPatente_502ag(perfil_502ag);
        }

        public void BorrarPerfil_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            dalPerfilPatente_502ag.BorrarRelacionPerfilPatente_502ag(familia_502ag);
            dalPerfilFamilia_502ag.BorrarRelacionPerfilFamilia_502ag(familia_502ag);
            dalPerfil_502ag.BorrarPerfil_502ag(familia_502ag);
        }

        public List<SE_Familia_502ag> ObtenerListaPerfiles_502ag()
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            List<SE_Familia_502ag> listaPerfiles_502ag = dalPerfil_502ag.ObtenerListaPerfiles_502ag();
            foreach (SE_Familia_502ag perfil_502ag in listaPerfiles_502ag)
            {
                CargarPatentesYFamilias_502ag(perfil_502ag);
            }
            foreach (SE_Familia_502ag perfil_502ag in listaPerfiles_502ag)
            {
                if(perfil_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    serFamilia_502ag.CargarPatentesYFamiliasRecursiva_502ag(subFamilia_502ag);
                }
            }
            return listaPerfiles_502ag;
        }
        private void CargarPatentesYFamilias_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.ObtenerFamiliasDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.ObtenerPatentesDePerfil_502ag(perfil_502ag);
        }

        public void DesasignarPermisosAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.DesasignarFamiliaDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.DesasignarPatenteDePerfil_502ag(perfil_502ag);
        }

        public void AsignarPermisosAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            //elimino posibles redundancias

            foreach (SE_Familia_502ag familia in ObtenerListaPerfiles_502ag())
            {
                EliminarRedundancia_502ag(perfil_502ag, familia);
            }

            //asigno nuevos permisos 
            dalPerfilFamilia_502ag.AsignarFamiliaAPerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.AsignarPatenteAPerfil_502ag(perfil_502ag);
        }
        private void EliminarRedundancia_502ag(SE_Familia_502ag perfilEditado_502ag, SE_Familia_502ag familiaARevisar_502ag)
        {
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            if (ContieneSubfamilia_502ag(perfilEditado_502ag, familiaARevisar_502ag))
            {
                foreach (SE_Perfil_502ag permisoEditado in perfilEditado_502ag.lista_502ag)
                {
                    if (permisoEditado is SE_Patente_502ag patenteEditado)
                    {
                        SE_Patente_502ag patenteRepetida = familiaARevisar_502ag.lista_502ag.FirstOrDefault(p => p.Nombre_502ag == patenteEditado.Nombre_502ag) as SE_Patente_502ag;
                        if (patenteRepetida != null)
                        {
                            familiaARevisar_502ag.Eliminar_502ag(patenteRepetida.Nombre_502ag);
                            //dalFamiliaPatente.EliminarPatenteDeFamilia_502ag(familiaARevisar, patenteEditado);
                        }
                    }
                }
            }
        }
        private bool ContieneSubfamilia_502ag(SE_Familia_502ag perfilEditado,SE_Familia_502ag familiaARevisar)
        {
            foreach (SE_Perfil_502ag permiso in familiaARevisar.lista_502ag)
            {
                if (permiso is SE_Familia_502ag subFamilia)
                {
                    if (subFamilia.Nombre_502ag == perfilEditado.Nombre_502ag)
                        return true;

                    if (ContieneSubfamilia_502ag(subFamilia, perfilEditado))
                        return true;
                }
            }
            return false;
        }
    }
}
