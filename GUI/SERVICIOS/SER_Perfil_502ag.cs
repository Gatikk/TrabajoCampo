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
            dalPerfilFamilia_502ag.AltaPerfilFamilia_502ag(perfil_502ag);
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
        private void CargarPatentesYFamilias_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.ObtenerFamiliasDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.ObtenerPatentesDePerfil_502ag(perfil_502ag);
        }

        public SE_Familia_502ag ObtenerListaPerfilProfundidadUno_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.ObtenerFamiliasDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.ObtenerPatentesDePerfil_502ag(perfil_502ag);
            return perfil_502ag;

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
        public void DesasignarPermisosAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.DesasignarFamiliaDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.DesasignarPatenteDePerfil_502ag(perfil_502ag);
        }

        public bool EvitarPermisosRepetidosEntreFamiliasQueCompartenPerfil_502ag(SE_Familia_502ag familiaQueSeModifica_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            List<SE_Perfil_502ag> patentesAAsignar_502ag = new List<SE_Perfil_502ag>();
            foreach (SE_Perfil_502ag permiso in listaPermisos_502ag)
            {
                if (permiso is SE_Patente_502ag patente)
                {
                    patentesAAsignar_502ag.Add(patente);
                }
                else if (permiso is SE_Familia_502ag familia)
                {
                    patentesAAsignar_502ag.AddRange(ObtenerPermisosDeFamiliaConcreta_502ag(familia));
                }
            }
            foreach (SE_Familia_502ag perfil in ObtenerListaPerfiles_502ag())
            {
                if (RecorrerSubFamiliasRecursiva_502ag(perfil, familiaQueSeModifica_502ag))
                {
                    List<SE_Perfil_502ag> patentesExistentes_502ag = ObtenerListaPatentesRecursiva_502ag(perfil);

                    foreach (SE_Perfil_502ag nueva in patentesAAsignar_502ag)
                    {
                        if (nueva is SE_Patente_502ag nuevaPatente)
                        {
                            if (patentesExistentes_502ag.Any(x => x.Nombre_502ag == nuevaPatente.Nombre_502ag))
                            {
                                return true; 
                            }
                        }
                    }
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
                if (permiso is SE_Patente_502ag patente)
                {
                    patentesNuevas.Add(patente);
                }
                if (permiso is SE_Familia_502ag familia)
                {
                    patentesNuevas.AddRange(ObtenerPermisosDeFamiliaConcreta_502ag(familia));
                }

            }
            foreach (SE_Perfil_502ag permiso in patentesNuevas)
            {
                if (permiso is SE_Patente_502ag patente)
                {
                    if (patentesExistentes.Find(x => x.Nombre_502ag == patente.Nombre_502ag) != null) { return false; }
                }
            }
            return true;
        }

        public List<SE_Perfil_502ag> ObtenerPermisosDeFamiliaConcreta_502ag(SE_Familia_502ag familia_502ag)
        {
            List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();

            foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente)
                {
                    listaPermisos_502ag.Add(patente);
                }
                if (permiso_502ag is SE_Familia_502ag familia)
                {
                    listaPermisos_502ag.Add(familia);
                    listaPermisos_502ag.AddRange(ObtenerPermisosDeFamiliaConcreta_502ag(familia));
                }
            }
            return listaPermisos_502ag;
        }
        public bool VerificarSiPerteneceAFamilia_502ag(SE_Familia_502ag familiaAEditar_502ag)
        {
            bool seRepite_502ag = false;
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            foreach (SE_Familia_502ag perfil in ObtenerListaPerfiles_502ag())
            {
                if (RecorrerSubFamiliasRecursiva_502ag(perfil, familiaAEditar_502ag))
                    seRepite_502ag = true;
            }
            foreach (SE_Familia_502ag familia in serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                if (familia.Nombre_502ag == familiaAEditar_502ag.Nombre_502ag)
                    continue;
                if (RecorrerSubFamiliasRecursiva_502ag(familia, familiaAEditar_502ag))
                {
                    seRepite_502ag = true;
                }
            }
            return seRepite_502ag;
        }

        private bool RecorrerSubFamiliasRecursiva_502ag(SE_Familia_502ag familiaARecorrer, SE_Familia_502ag familiaAEditar)
        {
            foreach (SE_Perfil_502ag permiso in familiaARecorrer.lista_502ag)
            {
                if (permiso is SE_Familia_502ag familia)
                {
                    if (familia.Nombre_502ag == familiaAEditar.Nombre_502ag)
                    {
                        return true;
                    }

                    if (RecorrerSubFamiliasRecursiva_502ag(familia, familiaAEditar))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
    }
}
