using DAL_502ag;
using SE_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS_502ag
{
    public class BLLS_Perfil_502ag
    {
        public void AltaPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();

            dalPerfil_502ag.AltaPerfil_502ag(perfil_502ag);
            dalPerfilFamilia_502ag.AltaPerfilFamilia_502ag(perfil_502ag);
            dalPerfilPatente_502ag.AltaPerfilPatente_502ag(perfil_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Admin", "Crear perfil", 1);
        }
        public void BorrarPerfil_502ag(SE_Familia_502ag familia_502ag)
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            dalPerfilPatente_502ag.BorrarRelacionPerfilPatente_502ag(familia_502ag);
            dalPerfilFamilia_502ag.BorrarRelacionPerfilFamilia_502ag(familia_502ag);
            dalPerfil_502ag.BorrarPerfil_502ag(familia_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Admin", "Borrar perfil", 1);
        }
        public List<SE_Familia_502ag> ObtenerListaPerfiles_502ag()
        {
            DAL_Perfil_502ag dalPerfil_502ag = new DAL_Perfil_502ag();
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
            List<SE_Familia_502ag> listaPerfiles_502ag = dalPerfil_502ag.ObtenerListaPerfiles_502ag();
            foreach (SE_Familia_502ag perfil_502ag in listaPerfiles_502ag)
            {
                CargarPatentesYFamilias_502ag(perfil_502ag);
            }
            foreach (SE_Familia_502ag perfil_502ag in listaPerfiles_502ag)
            {
                if (perfil_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    bllsFamilia_502ag.CargarPatentesYFamiliasRecursiva_502ag(subFamilia_502ag);
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
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Admin", "Asignar a perfil", 1);
        }
        public void DesasignarPermisosAPerfil_502ag(SE_Familia_502ag perfil_502ag)
        {
            DAL_PerfilFamilia_502ag dalPerfilFamilia_502ag = new DAL_PerfilFamilia_502ag();
            DAL_PerfilPatente_502ag dalPerfilPatente_502ag = new DAL_PerfilPatente_502ag();
            dalPerfilFamilia_502ag.DesasignarFamiliaDePerfil_502ag(perfil_502ag);
            dalPerfilPatente_502ag.DesasignarPatenteDePerfil_502ag(perfil_502ag);
            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Admin", "Desasignar a perfil", 1);
        }
        public bool EvitarPermisosRepetidosEntreFamiliasQueCompartenPerfil_502ag(SE_Familia_502ag familiaQueSeModifica_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            List<SE_Perfil_502ag> patentesAAsignar_502ag = new List<SE_Perfil_502ag>();
            foreach (SE_Perfil_502ag permiso_502ag in listaPermisos_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    patentesAAsignar_502ag.Add(patente_502ag);
                }
                else if (permiso_502ag is SE_Familia_502ag familia_502ag)
                {
                    patentesAAsignar_502ag.AddRange(ObtenerPermisosDeFamiliaConcreta_502ag(familia_502ag));
                }
            }
            foreach (SE_Familia_502ag perfil_502ag in ObtenerListaPerfiles_502ag())
            {
                if (RecorrerSubFamiliasRecursiva_502ag(perfil_502ag, familiaQueSeModifica_502ag))
                {
                    List<SE_Perfil_502ag> patentesExistentes_502ag = ObtenerListaPatentesRecursiva_502ag(perfil_502ag);
                    foreach (SE_Perfil_502ag nuevoPermiso_502ag in patentesAAsignar_502ag)
                    {
                        if (nuevoPermiso_502ag is SE_Patente_502ag nuevaPatente_502ag)
                        {
                            if (patentesExistentes_502ag.Any(x => x.Nombre_502ag == nuevaPatente_502ag.Nombre_502ag))
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
            foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    listaPatentes_502ag.Add(patente_502ag);
                }
                if (permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    listaPatentes_502ag.Add(subFamilia_502ag);
                    listaPatentes_502ag.AddRange(ObtenerListaPatentesRecursiva_502ag(subFamilia_502ag));
                }
            }
            return listaPatentes_502ag;
        }
        public bool EvitarFamiliasConPermisosRepetidos_502ag(SE_Familia_502ag perfilSeleccionado_502ag, List<SE_Perfil_502ag> listaPermisos_502ag)
        {
            List<SE_Perfil_502ag> patentesExistentes_502ag = ObtenerListaPatentesRecursiva_502ag(perfilSeleccionado_502ag);
            List<SE_Perfil_502ag> patentesNuevas_502ag = new List<SE_Perfil_502ag>();
            foreach (SE_Perfil_502ag permiso_502ag in listaPermisos_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    if (patentesNuevas_502ag.Exists(x => x.Nombre_502ag == patente_502ag.Nombre_502ag))
                        return false;

                    patentesNuevas_502ag.Add(patente_502ag);
                }
                else if (permiso_502ag is SE_Familia_502ag familia_502ag)
                {
                    var patentesDeFamilia = ObtenerPermisosDeFamiliaConcreta_502ag(familia_502ag);
                    foreach (var patente in patentesDeFamilia)
                    {
                        if (patentesNuevas_502ag.Exists(x => x.Nombre_502ag == patente.Nombre_502ag))
                            return false;
                    }

                    patentesNuevas_502ag.AddRange(patentesDeFamilia);
                }
            }
            foreach (SE_Perfil_502ag permiso_502ag in patentesNuevas_502ag)
            {
                if (patentesExistentes_502ag.Exists(x => x.Nombre_502ag == permiso_502ag.Nombre_502ag))
                    return false;
            }

            return true;
        }
        public List<SE_Perfil_502ag> ObtenerPermisosDeFamiliaConcreta_502ag(SE_Familia_502ag familia_502ag)
        {
            List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();

            foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    listaPermisos_502ag.Add(patente_502ag);
                }
                if (permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    listaPermisos_502ag.Add(subFamilia_502ag);
                    listaPermisos_502ag.AddRange(ObtenerPermisosDeFamiliaConcreta_502ag(subFamilia_502ag));
                }
            }
            return listaPermisos_502ag;
        }
        public bool VerificarSiPerteneceAFamilia_502ag(SE_Familia_502ag familiaAEditar_502ag)
        {
            bool seRepite_502ag = false;
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
            foreach (SE_Familia_502ag perfil_502ag in ObtenerListaPerfiles_502ag())
            {
                if (RecorrerSubFamiliasRecursiva_502ag(perfil_502ag, familiaAEditar_502ag))
                    seRepite_502ag = true;
            }
            foreach (SE_Familia_502ag familia_502ag in bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                if (familia_502ag.Nombre_502ag == familiaAEditar_502ag.Nombre_502ag)
                    continue;
                if (RecorrerSubFamiliasRecursiva_502ag(familia_502ag, familiaAEditar_502ag))
                {
                    seRepite_502ag = true;
                }
            }
            return seRepite_502ag;
        }
        private bool RecorrerSubFamiliasRecursiva_502ag(SE_Familia_502ag familiaARecorrer_502ag, SE_Familia_502ag familiaAEditar_502ag)
        {
            foreach (SE_Perfil_502ag permiso_502ag in familiaARecorrer_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Familia_502ag familia_502ag)
                {
                    if (familia_502ag.Nombre_502ag == familiaAEditar_502ag.Nombre_502ag)
                    {
                        return true;
                    }

                    if (RecorrerSubFamiliasRecursiva_502ag(familia_502ag, familiaAEditar_502ag))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool VerificarNombreCargado_502ag(string nombre_502ag)
        {
            bool noSeRepite_502ag = true;
            if (ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null) noSeRepite_502ag = false;
            return noSeRepite_502ag;
        }
        public bool VerificarSiPerfilEsActivo_502ag(SE_Familia_502ag perfil_502ag)
        {
            BLLS_Usuario_502ag bllsUsuario_502ag = new BLLS_Usuario_502ag();
            bool esActivo_502ag = true;
            esActivo_502ag = bllsUsuario_502ag.ObtenerUsuarioPorRol_502ag(perfil_502ag.Nombre_502ag);
            return esActivo_502ag;
        }
        public List<SE_Patente_502ag> ObtenerPatentesDePerfil_502ag(string nombrePerfil_502ag)
        {
            List<SE_Patente_502ag> listaPatentes_502ag = new List<SE_Patente_502ag>();
            SE_Familia_502ag perfil_502ag = ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == nombrePerfil_502ag);
            foreach (SE_Perfil_502ag permiso_502ag in perfil_502ag.lista_502ag)
            {
                if (permiso_502ag is SE_Patente_502ag patente_502ag)
                {
                    listaPatentes_502ag.Add(patente_502ag);
                }
                if (permiso_502ag is SE_Familia_502ag subFamilia_502ag)
                {
                    BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                    listaPatentes_502ag.AddRange(bllsFamilia_502ag.ObtenerListaPatentesDeFamilia_502ag(subFamilia_502ag));
                }
            }
            return listaPatentes_502ag;
        }

    }
}
