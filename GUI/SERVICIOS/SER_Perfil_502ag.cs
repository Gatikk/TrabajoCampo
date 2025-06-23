using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
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
                if (perfil_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    serFamilia_502ag.CargarPatentesYFamiliasRecursiva_502ag(subFamilia_502ag);
                }
            }
            return listaPerfiles_502ag;
        }

        public SE_Familia_502ag ObtenerListaPerfilProfundidadUno_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.ObtenerFamiliasDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.ObtenerPatentesDePerfil_502ag(perfil_502ag);
            return perfil_502ag;

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


        public void AsignarPermisosAPerfil_502ag(SE_Familia_502ag perfil_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();

            foreach (SE_Perfil_502ag permiso_502ag in listaPermisos_502ag)
            {
                perfil_502ag.lista_502ag.Add(permiso_502ag);
            }

            dalPerfilFamilia_502ag.AsignarFamiliaAPerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.AsignarPatenteAPerfil_502ag(perfil_502ag);
        }



        //se llama desde servicios
        public void BorrarFamiliaRecienBorradaDePerfil_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            dalPerfilFamilia_502ag.BorrarFamiliaRecienBorradaDePerfil_502ag(familia_502ag);
            foreach (SE_Familia_502ag perfil_502ag in ObtenerListaPerfiles_502ag())
            {
                if (perfil_502ag.lista_502ag.Count == 0)
                {
                    DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
                    dalPerfil_502ag.BorrarPerfil_502ag(perfil_502ag);
                }
            }
        }

        public bool EvitarPermisosRepetidosEntreFamiliasQueCompartenPerfil_502ag(SE_Familia_502ag familiaQueSeModifica_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            foreach (SE_Familia_502ag perfil_502ag in ObtenerListaPerfiles_502ag())
            {
                foreach (SE_Perfil_502ag permiso in perfil_502ag.lista_502ag)
                {
                    if (permiso is SE_Familia_502ag subFamilia)
                    {
                        if (SeEncontroFamiliaQueSeModifica(perfil_502ag, familiaQueSeModifica_502ag))
                        {
                            List<SE_Perfil_502ag> listaPatentes_502ag = ObtenerListaPatentesRecursiva_502ag(perfil_502ag);
                            foreach (SE_Perfil_502ag patente in listaPermisos_502ag)
                            {
                                if (listaPatentes_502ag.Find(x => x.Nombre_502ag == patente.Nombre_502ag) != null)
                                {
                                    return true;
                                }
                            }
                        }

                    }
                }
            }
            return false;
        }



        public bool SeEncontroFamiliaQueSeModifica(SE_Familia_502ag familiaQueSeRecorre_502ag, SE_Familia_502ag familiaQueSeModifica_502ag)
        {

            if (familiaQueSeRecorre_502ag.Nombre_502ag == familiaQueSeModifica_502ag.Nombre_502ag)
            {
                return true;
            }

            foreach (SE_Perfil_502ag permiso in familiaQueSeRecorre_502ag.lista_502ag)
            {
                if (permiso is SE_Familia_502ag subFamilia)
                {
                    if (SeEncontroFamiliaQueSeModifica(subFamilia, familiaQueSeModifica_502ag)) return true;
                }
            }
            return false;
        }

        public List<SE_Perfil_502ag> ObtenerListaPatentesRecursiva_502ag(SE_Familia_502ag familia_502ag)
        {
            List<SE_Perfil_502ag> listaPatentes_502ag = new List<SE_Perfil_502ag>();
            foreach (SE_Perfil_502ag permiso in familia_502ag.lista_502ag)
            {
                if (permiso is SE_Patente_502ag patente_502ag)
                {
                    listaPatentes_502ag.Add(patente_502ag);
                }
                if (permiso is SE_Familia_502ag subFamilia_502ag)
                {
                    listaPatentes_502ag.Add(subFamilia_502ag);
                    listaPatentes_502ag.AddRange(ObtenerListaPatentesRecursiva_502ag(subFamilia_502ag));
                }
            }
            return listaPatentes_502ag;
        }

        public bool Verificacion(SE_Familia_502ag perfilSeleccionado_502ag, List<SE_Perfil_502ag> listaPermisos_502ag) 
        {
            List<SE_Perfil_502ag> patentesExistentes = ObtenerListaPatentesRecursiva_502ag(perfilSeleccionado_502ag);
            List<SE_Perfil_502ag> patentesNuevas = new List<SE_Perfil_502ag>();
            foreach (SE_Perfil_502ag permiso in listaPermisos_502ag)
            {
                if(permiso is SE_Patente_502ag patente)
                {
                    patentesNuevas.Add(patente);
                }
                if(permiso is SE_Familia_502ag familia)
                {
                    patentesNuevas.AddRange(ObtenerPatentesDeListaPermisos_502ag(familia));
                }

            }
            foreach(SE_Perfil_502ag permiso in patentesNuevas)
            {
                if(permiso is SE_Patente_502ag patente)
                {
                    if (patentesExistentes.Find(x=>x.Nombre_502ag == patente.Nombre_502ag)!= null) { return false; }
                }
            }
            return true;
        }

        public List<SE_Perfil_502ag> ObtenerPatentesDeListaPermisos_502ag(SE_Familia_502ag perfil)
        {
            List<SE_Perfil_502ag> permisos = new List<SE_Perfil_502ag>();
            
            foreach (SE_Perfil_502ag permiso in perfil.lista_502ag)
            {
                if(permiso is SE_Patente_502ag patente)
                {
                    permisos.Add(patente);
                }
                if( permiso is SE_Familia_502ag familia)
                {
                    permisos.Add(familia);
                    permisos.AddRange(ObtenerPatentesDeListaPermisos_502ag(familia));
                }
            }
            return permisos;
        }
    }
}
