using SE_502ag;
using BLLS_502ag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SERVICIOS_502ag;

namespace GUI
{
    public partial class FormPerfiles_502ag : Form, IObserver_502ag
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";

        private string msgExisteFamiliaConEseNombre_502ag, msgExistePatenteConEseNombre_502ag, msgExistePerfilConEseNombre_502ag;
        private string msgNombreFamiliaVacio_502ag, msgNoAltaFamiliaSinPermisos_502ag, msgNoAltaPatentesRepetidas_502ag, msgNombrePerfilVacio_502ag, msgNoAltaPerfilSinPermisos_502ag;
        private string msgFamiliaCreada_502ag, msgPerfilCreado_502ag;
        private string msgNadaSeleccionadoParaBorrar_502ag, msgFamiliaNoEncontrada_502ag, msgNoBajaJerarquia_502ag, msgFamiliaBorrada_502ag;
        private string msgPerfilNoEncontrado_502ag, msgNoBajaPerfilConUsuarios_502ag, msgPerfilBorrado_502ag, msgNadaSeleccionado_502ag;
        private string msgMinUnPermiso_502ag, msgFamiliaEncontradaEnOtraJerarquia_502ag, msgFamiliaTieneRelacion_502ag, msgNoAsignarPermisosRepetidos_502ag;
        private string msgPermisosAsignados_502ag, msgJerarquiaRota_502ag, msgNoDesasignarTodo_502ag, msgPermisosDesasignados_502ag;
        public FormPerfiles_502ag(FormMenu_502ag formMenu_502ag)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SERVICIOS_502ag.SER_Traductor_502ag.GestorTraductor_502ag.Suscribir_502ag(this);
            MostrarPermisos_502ag(cLBPermisos_502ag);
            MostrarFamilias_502ag();
            MostrarPerfiles_502ag();
            ActualizarComboBox_502ag();
            menu_502ag = formMenu_502ag;
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
            cBFamilia_502ag.Enabled = false;
            cBPerfil_502ag.Enabled = false;
            cLBPermisos_502ag.Enabled = false;
            rBFamilia_502ag.Enabled = false;
            rBPerfil_502ag.Enabled = false;
            tBNombre_502ag.Enabled = false;
            SER_Traductor_502ag.GestorTraductor_502ag.CargarTraducciones_502ag(this);
            Actualizar_502ag(SER_Traductor_502ag.GestorTraductor_502ag);
        }

        private void MostrarPermisos_502ag(CheckedListBox clb_502ag)
        {
            clb_502ag.Items.Clear();
            BLLS_Patente_502ag bllsPatente_502ag = new BLLS_Patente_502ag();
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();

            foreach (SE_Patente_502ag patente_502ag in bllsPatente_502ag.ObtenerListaPatentes_502ag())
            {
                clb_502ag.Items.Add(patente_502ag.Nombre_502ag, false);
            }
            foreach (SE_Familia_502ag familia_502ag in bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                clb_502ag.Items.Add(familia_502ag.Nombre_502ag, false);
            }
        }

        private void MostrarPermisosADesasignarFamilia_502ag(string familia_502ag)
        {
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
            if (opcion_502ag == "Desasignar")
            {
                cLBPermisos_502ag.Items.Clear();
                SE_Familia_502ag familiaADesasignar_502ag = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == familia_502ag);
                foreach (SE_Perfil_502ag permiso_502ag in familiaADesasignar_502ag.lista_502ag)
                {
                    cLBPermisos_502ag.Items.Add(permiso_502ag.Nombre_502ag, true);
                }
            }
        }

        private void MostrarPermisosADesasignarPerfil_502ag(string perfil_502ag)
        {
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            if (opcion_502ag == "Desasignar")
            {
                cLBPermisos_502ag.Items.Clear();
                SE_Familia_502ag perfilADesasignar_502ag = bllsPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == perfil_502ag);
                foreach (SE_Perfil_502ag permiso_502ag in perfilADesasignar_502ag.lista_502ag)
                {
                    cLBPermisos_502ag.Items.Add(permiso_502ag.Nombre_502ag, true);
                }
            }
        }
        private void MostrarFamilias_502ag()
        {
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
            tVFamilias_502ag.Nodes.Clear();
            foreach (SE_Familia_502ag familia_502ag in bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                JerarquiaNodos_502ag(familia_502ag, tVFamilias_502ag.Nodes);
            }
        }
        private void MostrarPerfiles_502ag()
        {
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            tVPerfiles_502ag.Nodes.Clear();
            foreach (SE_Familia_502ag perfil_502ag in bllsPerfil_502ag.ObtenerListaPerfiles_502ag())
            {
                JerarquiaNodos_502ag(perfil_502ag, tVPerfiles_502ag.Nodes);
            }
        }

        private void buttonAyuda2_502ag_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/1rBZ6yDeokVvQbplN_HHjHqQji06Q8fvfTm7zgQCy49w/edit?tab=t.0#heading=h.rmexyb40ol17");
        }

        private void JerarquiaNodos_502ag(SE_Perfil_502ag permiso_502ag, TreeNodeCollection nodos_502ag)
        {
            TreeNode nodo_502ag;
            if (permiso_502ag is SE_Patente_502ag)
            {
                nodo_502ag = new TreeNode(permiso_502ag.Nombre_502ag);
            }
            else if (permiso_502ag is SE_Familia_502ag familia_502ag)
            {
                nodo_502ag = new TreeNode(permiso_502ag.Nombre_502ag);
                foreach (SE_Perfil_502ag hijo_502ag in familia_502ag.lista_502ag)
                {
                    JerarquiaNodos_502ag(hijo_502ag, nodo_502ag.Nodes);
                }
            }
            else
            {
                nodo_502ag = null;
            }
            if (nodos_502ag != null)
            {
                nodos_502ag.Add(nodo_502ag);
            }
        }
        private void FormPerfiles_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void ActualizarComboBox_502ag()
        {
            BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
            BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
            cBFamilia_502ag.Items.Clear();
            cBPerfil_502ag.Items.Clear();
            foreach (SE_Familia_502ag familia_502ag in bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                cBFamilia_502ag.Items.Add(familia_502ag.Nombre_502ag);
            }
            foreach (SE_Familia_502ag perfil_502ag in bllsPerfil_502ag.ObtenerListaPerfiles_502ag())
            {
                cBPerfil_502ag.Items.Add(perfil_502ag.Nombre_502ag);
            }
            cBFamilia_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPerfil_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void FormPerfiles_502ag_Activated(object sender, EventArgs e)
        {

        }
        private void buttonCrear_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Crear";
                tBNombre_502ag.Enabled = true;
                rBFamilia_502ag.Enabled = true;
                rBPerfil_502ag.Enabled = true;
                cLBPermisos_502ag.Enabled = true;
                buttonCrear_502ag.Enabled = false;
                buttonBorrar_502ag.Enabled = false;
                buttonAsignar_502ag.Enabled = false;
                buttonDesasignar_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonAsignar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Asignar";
                rBFamilia_502ag.Enabled = true;
                rBPerfil_502ag.Enabled = true;
                buttonCrear_502ag.Enabled = false;
                buttonBorrar_502ag.Enabled = false;
                buttonAsignar_502ag.Enabled = false;
                buttonDesasignar_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                cLBPermisos_502ag.Enabled = true;
                ActualizarComboBoxSegunOpcion_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonDesasignar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Desasignar";
                rBFamilia_502ag.Enabled = true;
                rBPerfil_502ag.Enabled = true;
                buttonCrear_502ag.Enabled = false;
                buttonBorrar_502ag.Enabled = false;
                buttonAsignar_502ag.Enabled = false;
                buttonDesasignar_502ag.Enabled = false;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                cLBPermisos_502ag.Enabled = true;
                ActualizarComboBoxSegunOpcion_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void buttonBorrar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                opcion_502ag = "Borrar";
                rBFamilia_502ag.Enabled = true;
                rBPerfil_502ag.Enabled = true;
                buttonAplicar_502ag.Enabled = true;
                buttonCancelar_502ag.Enabled = true;
                buttonVolverAlMenu_502ag.Enabled = false;
                buttonCrear_502ag.Enabled = false;
                buttonBorrar_502ag.Enabled = false;
                buttonAsignar_502ag.Enabled = false;
                buttonDesasignar_502ag.Enabled = false;
                ActualizarComboBoxSegunOpcion_502ag();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void cBFamilia_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(opcion_502ag != "Desasignar")
            {
                for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
                {
                    cLBPermisos_502ag.SetItemChecked(i, false);
                }
                BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                SE_Familia_502ag familiaComboBox_502ag = new SE_Familia_502ag(cBFamilia_502ag.Text);
                familiaComboBox_502ag = bllsFamilia_502ag.ObtenerListaProfundidadUno_502ag(familiaComboBox_502ag);
                RellenarCheckedListBox_502ag(familiaComboBox_502ag);
            }
            else
            {
                MostrarPermisosADesasignarFamilia_502ag(cBFamilia_502ag.Text);
            }
        }
        private void cBPerfil_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(opcion_502ag != "Desasignar")
            {
                for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
                {
                    cLBPermisos_502ag.SetItemChecked(i, false);
                }
                BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                SE_Familia_502ag perfilComboBox_502ag = new SE_Familia_502ag(cBPerfil_502ag.Text);
                perfilComboBox_502ag = bllsPerfil_502ag.ObtenerListaPerfilProfundidadUno_502ag(perfilComboBox_502ag);
                RellenarCheckedListBox_502ag(perfilComboBox_502ag);
            }
            else
            {
                MostrarPermisosADesasignarPerfil_502ag(cBPerfil_502ag.Text);
            }
        }
        private void RellenarCheckedListBox_502ag(SE_Familia_502ag familia_502ag)
        {
            try
            {
                foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
                {
                    if (permiso_502ag is SE_Patente_502ag patente)
                    {
                        int index = BuscarIndiceCLB_502ag(patente);
                        if (index != -1)
                        {
                            cLBPermisos_502ag.SetItemChecked(index, true);
                        }
                    }
                    if (permiso_502ag is SE_Familia_502ag familia)
                    {
                        RellenarCheckedListBox_502ag(familia);
                        int index = BuscarIndiceCLB_502ag(familia);
                        if (index != -1)
                        {
                            cLBPermisos_502ag.SetItemChecked(index, true);
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private int BuscarIndiceCLB_502ag(SE_Perfil_502ag permiso_502ag)
        {
            for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
            {
                if (cLBPermisos_502ag.Items[i].ToString().Equals(permiso_502ag.Nombre_502ag))
                {
                    return i;
                }
            }
            return -1;
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            SER_Traductor_502ag.GestorTraductor_502ag.Desuscribir_502ag(this);
            this.Hide();
            menu_502ag.Show();
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (opcion_502ag == "Crear")
                {
                    BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                    BLLS_Patente_502ag bllsPatente_502ag = new BLLS_Patente_502ag();
                    BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                    if (!bllsFamilia_502ag.VerificarNombreCargado_502ag(tBNombre_502ag.Text)) throw new Exception(msgExisteFamiliaConEseNombre_502ag);
                    if (!bllsPatente_502ag.VerificarNombreCargado_502ag(tBNombre_502ag.Text)) throw new Exception(msgExistePatenteConEseNombre_502ag);
                    if (!bllsPerfil_502ag.VerificarNombreCargado_502ag(tBNombre_502ag.Text)) throw new Exception(msgExistePerfilConEseNombre_502ag);
                    if (rBFamilia_502ag.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(tBNombre_502ag.Text)) { throw new Exception(msgNombreFamiliaVacio_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgNoAltaFamiliaSinPermisos_502ag); }
                        SE_Familia_502ag nuevaFamilia_502ag = new SE_Familia_502ag(tBNombre_502ag.Text);
                        foreach (var item_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = item_502ag.ToString();
                            if (bllsPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                nuevaFamilia_502ag.Agregar_502ag(patente_502ag);
                            }
                            if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia_502ag = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (subFamilia_502ag != null) { nuevaFamilia_502ag.Agregar_502ag(subFamilia_502ag); }
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();
                        if (!bllsFamilia_502ag.PatenteRepetida_502ag(nuevaFamilia_502ag, listaPermisos_502ag)) { throw new Exception(msgNoAltaPatentesRepetidas_502ag); }
                        bllsFamilia_502ag.AltaFamilia_502ag(nuevaFamilia_502ag);
                        MessageBox.Show(msgFamiliaCreada_502ag);
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(tBNombre_502ag.Text)) { throw new Exception(msgNombrePerfilVacio_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgNoAltaPerfilSinPermisos_502ag); }

                        SE_Familia_502ag nuevoPerfil_502ag = new SE_Familia_502ag(tBNombre_502ag.Text);
                        foreach (var item_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = item_502ag.ToString();
                            if (bllsPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                nuevoPerfil_502ag.Agregar_502ag(patente_502ag);
                            }
                            if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia_502ag = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (subFamilia_502ag != null) { nuevoPerfil_502ag.Agregar_502ag(subFamilia_502ag); }
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();
                        if (!bllsFamilia_502ag.PatenteRepetida_502ag(nuevoPerfil_502ag, listaPermisos_502ag)) { throw new Exception(msgNoAltaPatentesRepetidas_502ag); }

                        bllsPerfil_502ag.AltaPerfil_502ag(nuevoPerfil_502ag);
                        MessageBox.Show(msgPerfilCreado_502ag);

                    }
                    opcion_502ag = "Consulta";
                    tBNombre_502ag.Clear();
                    tBNombre_502ag.Enabled = false;
                    cLBPermisos_502ag.Enabled = false;
                    rBFamilia_502ag.Enabled = false;
                    rBPerfil_502ag.Enabled = false;
                    buttonAplicar_502ag.Enabled = false;
                    buttonCancelar_502ag.Enabled = false;
                    buttonVolverAlMenu_502ag.Enabled = true;
                    buttonCrear_502ag.Enabled = true;
                    buttonBorrar_502ag.Enabled = true;
                    buttonAsignar_502ag.Enabled = true;
                    buttonDesasignar_502ag.Enabled = true;
                }
                if (opcion_502ag == "Borrar")
                {
                    BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                    BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                    if (rBFamilia_502ag.Checked)
                    {
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionadoParaBorrar_502ag); }
                        if (!bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Any(x => x.Nombre_502ag == cBFamilia_502ag.Text)) throw new Exception(msgFamiliaNoEncontrada_502ag);
                        SE_Familia_502ag familiaSeleccionada = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());

                        if (bllsPerfil_502ag.VerificarSiPerteneceAFamilia_502ag(familiaSeleccionada)) { throw new Exception(msgNoBajaJerarquia_502ag); }

                        bllsFamilia_502ag.BorrarFamilia_502ag(familiaSeleccionada);
                        cBFamilia_502ag.SelectedItem = null;
                        MessageBox.Show(msgFamiliaBorrada_502ag);
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionadoParaBorrar_502ag); }
                        if (!bllsPerfil_502ag.ObtenerListaPerfiles_502ag().Any(x => x.Nombre_502ag == cBPerfil_502ag.Text)) throw new Exception(msgPerfilNoEncontrado_502ag);
                        SE_Familia_502ag perfilSeleccionado_502ag = bllsPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());
                        if (bllsPerfil_502ag.VerificarSiPerfilEsActivo_502ag(perfilSeleccionado_502ag)) throw new Exception(msgNoBajaPerfilConUsuarios_502ag);
                        bllsPerfil_502ag.BorrarPerfil_502ag(perfilSeleccionado_502ag);
                        cBPerfil_502ag.SelectedItem = null;
                        MessageBox.Show(msgPerfilBorrado_502ag);
                    }
                    opcion_502ag = "Consulta";
                    rBFamilia_502ag.Enabled = false;
                    cBFamilia_502ag.Enabled = false;
                    rBPerfil_502ag.Enabled = false;
                    cBFamilia_502ag.Enabled = false;
                    buttonAplicar_502ag.Enabled = false;
                    buttonCancelar_502ag.Enabled = false;
                    buttonVolverAlMenu_502ag.Enabled = true;
                    buttonCrear_502ag.Enabled = true;
                    buttonBorrar_502ag.Enabled = true;
                    buttonAsignar_502ag.Enabled = true;
                    buttonDesasignar_502ag.Enabled = true;
                }
                if (opcion_502ag == "Asignar")
                {
                    BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                    BLLS_Patente_502ag bllsPatente_502ag = new BLLS_Patente_502ag();
                    BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                    if (rBFamilia_502ag.Checked)
                    {
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionado_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgMinUnPermiso_502ag); }
                        SE_Familia_502ag familiaSeleccionada = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());
                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = itemchecked_502ag.ToString();
                            if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (!bllsFamilia_502ag.CompararFamiliaPadreEHijos_502ag(familiaSeleccionada, subFamilia)) throw new Exception(msgFamiliaEncontradaEnOtraJerarquia_502ag);
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisosAAgregar_502ag = new List<SE_Perfil_502ag>();
                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            if (!familiaSeleccionada.lista_502ag.Any(x => x.Nombre_502ag == itemchecked_502ag.ToString()))
                            {
                                string nombre_502ag = itemchecked_502ag.ToString();
                                if (bllsPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                    listaPermisosAAgregar_502ag.Add(patente_502ag);
                                }
                                if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Familia_502ag familia_502ag = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                    if (familia_502ag != null) { listaPermisosAAgregar_502ag.Add(familia_502ag); }
                                }
                            }
                        }
                        if (bllsPerfil_502ag.EvitarPermisosRepetidosEntreFamiliasQueCompartenPerfil_502ag(familiaSeleccionada, listaPermisosAAgregar_502ag)) throw new Exception(msgFamiliaTieneRelacion_502ag);
                        List<SE_Perfil_502ag> listaPermisosAAgregarAux_502ag = new List<SE_Perfil_502ag>(listaPermisosAAgregar_502ag);
                        if (!bllsPerfil_502ag.EvitarFamiliasConPermisosRepetidos_502ag(familiaSeleccionada, listaPermisosAAgregarAux_502ag)) throw new Exception(msgNoAsignarPermisosRepetidos_502ag);
                        if (!bllsFamilia_502ag.PatenteRepetida_502ag(familiaSeleccionada, listaPermisosAAgregarAux_502ag)) { throw new Exception(msgNoAsignarPermisosRepetidos_502ag); }

                        bllsFamilia_502ag.AsignarPermisosAFamilia_502ag(familiaSeleccionada, listaPermisosAAgregar_502ag);
                        MessageBox.Show(msgPermisosAsignados_502ag);
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionado_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgMinUnPermiso_502ag); }
                        SE_Familia_502ag perfilSeleccionado_502ag = bllsPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());

                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = itemchecked_502ag.ToString();
                            if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (!bllsFamilia_502ag.CompararFamiliaPadreEHijos_502ag(perfilSeleccionado_502ag, subFamilia)) throw new Exception(msgJerarquiaRota_502ag);
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisosAAgregar_502ag = new List<SE_Perfil_502ag>();
                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            if (!perfilSeleccionado_502ag.lista_502ag.Any(x => x.Nombre_502ag == itemchecked_502ag.ToString()))
                            {
                                string nombre_502ag = itemchecked_502ag.ToString();
                                if (bllsPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                    listaPermisosAAgregar_502ag.Add(patente_502ag);
                                }
                                if (bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Familia_502ag familia_502ag = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                    if (familia_502ag != null) { listaPermisosAAgregar_502ag.Add(familia_502ag); }
                                }
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisosAAgregarAux_502ag = new List<SE_Perfil_502ag>(listaPermisosAAgregar_502ag);
                        if (!bllsPerfil_502ag.EvitarFamiliasConPermisosRepetidos_502ag(perfilSeleccionado_502ag, listaPermisosAAgregarAux_502ag)) throw new Exception(msgNoAsignarPermisosRepetidos_502ag);

                        bllsPerfil_502ag.AsignarPermisosAPerfil_502ag(perfilSeleccionado_502ag, listaPermisosAAgregar_502ag);
                        MessageBox.Show(msgPermisosAsignados_502ag);
                    }
                    opcion_502ag = "Consulta";
                    buttonAplicar_502ag.Enabled = false;
                    buttonCancelar_502ag.Enabled = false;
                    rBFamilia_502ag.Enabled = false;
                    rBPerfil_502ag.Enabled = false;
                    cBFamilia_502ag.Enabled = false;
                    cBPerfil_502ag.Enabled = false;
                    cLBPermisos_502ag.Enabled = false;
                    buttonCrear_502ag.Enabled = true;
                    buttonBorrar_502ag.Enabled = true;
                    buttonAsignar_502ag.Enabled = true;
                    buttonDesasignar_502ag.Enabled = true;
                    buttonVolverAlMenu_502ag.Enabled = true;
                }
                if (opcion_502ag == "Desasignar")
                {
                    if (rBFamilia_502ag.Checked)
                    {
                        BLLS_Familia_502ag bllsFamilia_502ag = new BLLS_Familia_502ag();
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionado_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgNoDesasignarTodo_502ag); }
                        SE_Familia_502ag familiaSeleccionada = bllsFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());
                        for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
                        {
                            if (!cLBPermisos_502ag.GetItemChecked(i))
                            {
                                string nombre_502ag = cLBPermisos_502ag.Items[i].ToString();
                                if (familiaSeleccionada.lista_502ag.Any(x => x.Nombre_502ag == nombre_502ag))
                                {
                                    familiaSeleccionada.Eliminar_502ag(nombre_502ag);
                                }
                            }
                        }
                        bllsFamilia_502ag.DesasignarPermisosAFamilia_502ag(familiaSeleccionada);
                        MessageBox.Show(msgPermisosDesasignados_502ag);
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        BLLS_Perfil_502ag bllsPerfil_502ag = new BLLS_Perfil_502ag();
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception(msgNadaSeleccionado_502ag); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception(msgNoDesasignarTodo_502ag); }
                        SE_Familia_502ag perfilSeleccionado_502ag = bllsPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());
                        for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
                        {
                            if (!cLBPermisos_502ag.GetItemChecked(i))
                            {
                                string nombre_502ag = cLBPermisos_502ag.Items[i].ToString();
                                if (perfilSeleccionado_502ag.lista_502ag.Any(x => x.Nombre_502ag == nombre_502ag))
                                {
                                    perfilSeleccionado_502ag.Eliminar_502ag(nombre_502ag);
                                }
                            }
                        }
                        bllsPerfil_502ag.DesasignarPermisosAPerfil_502ag(perfilSeleccionado_502ag);
                        MessageBox.Show(msgPermisosDesasignados_502ag);
                    }
                    opcion_502ag = "Consulta";
                    buttonAplicar_502ag.Enabled = false;
                    buttonCancelar_502ag.Enabled = false;
                    rBFamilia_502ag.Enabled = false;
                    rBPerfil_502ag.Enabled = false;
                    cBFamilia_502ag.Enabled = false;
                    cBPerfil_502ag.Enabled = false;
                    cLBPermisos_502ag.Enabled = false;
                    buttonCrear_502ag.Enabled = true;
                    buttonBorrar_502ag.Enabled = true;
                    buttonAsignar_502ag.Enabled = true;
                    buttonDesasignar_502ag.Enabled = true;
                    buttonVolverAlMenu_502ag.Enabled = true;
                }
                cBFamilia_502ag.SelectedItem = null;
                cBPerfil_502ag.SelectedItem = null;
                MostrarPermisos_502ag(cLBPermisos_502ag);
                MostrarFamilias_502ag();
                MostrarPerfiles_502ag();
                ActualizarComboBox_502ag();
                for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
                {
                    cLBPermisos_502ag.SetItemChecked(i, false);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

        }

        private void buttonCancelar_502ag_Click(object sender, EventArgs e)
        {
            opcion_502ag = "Consulta";
            buttonAplicar_502ag.Enabled = false;
            buttonCancelar_502ag.Enabled = false;
            cBFamilia_502ag.Enabled = false;
            cBPerfil_502ag.Enabled = false;
            cLBPermisos_502ag.Enabled = false;
            rBFamilia_502ag.Enabled = false;
            rBPerfil_502ag.Enabled = false;
            tBNombre_502ag.Enabled = false;
            buttonCrear_502ag.Enabled = true;
            buttonBorrar_502ag.Enabled = true;
            buttonAsignar_502ag.Enabled = true;
            buttonDesasignar_502ag.Enabled = true;
            buttonVolverAlMenu_502ag.Enabled = true;
            cBFamilia_502ag.SelectedItem = null;
            cBPerfil_502ag.SelectedItem = null;
            MostrarPermisos_502ag(cLBPermisos_502ag);

            for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
            {
                cLBPermisos_502ag.SetItemChecked(i, false);
            }
        }

        private void ActualizarComboBoxSegunOpcion_502ag()
        {
            if (opcion_502ag == "Borrar")
            {
                if (rBFamilia_502ag.Checked)
                {
                    cBFamilia_502ag.Enabled = true;
                    cBPerfil_502ag.Enabled = false;
                }
                if (rBPerfil_502ag.Checked)
                {
                    cBPerfil_502ag.Enabled = true;
                    cBFamilia_502ag.Enabled = false;
                }
            }
            if (opcion_502ag == "Desasignar")
            {
                if (rBFamilia_502ag.Checked)
                {
                    cBFamilia_502ag.Enabled = true;
                    cBPerfil_502ag.Enabled = false;
                }
                if (rBPerfil_502ag.Checked)
                {
                    cBPerfil_502ag.Enabled = true;
                    cBFamilia_502ag.Enabled = false;
                }
            }
            if (opcion_502ag == "Asignar")
            {
                if (rBFamilia_502ag.Checked)
                {
                    cBFamilia_502ag.Enabled = true;
                    cBPerfil_502ag.Enabled = false;
                }
                if (rBPerfil_502ag.Checked)
                {
                    cBPerfil_502ag.Enabled = true;
                    cBFamilia_502ag.Enabled = false;
                }
            }
        }

        private void rBFamilia_502ag_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarComboBoxSegunOpcion_502ag();
        }

        public void Actualizar_502ag(SER_Traductor_502ag traductor_502ag)
        {
            TraducirControles_502ag(this, traductor_502ag);
        }

        private void TraducirControles_502ag(Control control_502ag, SER_Traductor_502ag traductor_502ag)
        {
            foreach (Control c_502ag in control_502ag.Controls)
            {
                if(c_502ag is TextBox)
                {

                }
                else
                {
                    c_502ag.Text = traductor_502ag.Traducir_502ag(c_502ag.Name);
                }
                if (control_502ag.HasChildren)
                {
                    TraducirControles_502ag(c_502ag, traductor_502ag);
                }
            }
            msgExisteFamiliaConEseNombre_502ag = traductor_502ag.Traducir_502ag("msgExisteFamiliaConEseNombre_502ag");
            msgExistePatenteConEseNombre_502ag = traductor_502ag.Traducir_502ag("msgExistePatenteConEseNombre_502ag");
            msgExistePerfilConEseNombre_502ag = traductor_502ag.Traducir_502ag("msgExistePerfilConEseNombre_502ag");
            msgNombreFamiliaVacio_502ag = traductor_502ag.Traducir_502ag("msgNombreFamiliaVacio_502ag");
            msgNoAltaFamiliaSinPermisos_502ag = traductor_502ag.Traducir_502ag("msgNoAltaFamiliaSinPermisos_502ag");
            msgNoAltaPatentesRepetidas_502ag = traductor_502ag.Traducir_502ag("msgNoAltaPatentesRepetidas_502ag");
            msgNombrePerfilVacio_502ag = traductor_502ag.Traducir_502ag("msgNombrePerfilVacio_502ag");
            msgNoAltaPerfilSinPermisos_502ag = traductor_502ag.Traducir_502ag("msgNoAltaPerfilSinPermisos_502ag");
            msgFamiliaCreada_502ag = traductor_502ag.Traducir_502ag("msgFamiliaCreada_502ag");
            msgPerfilCreado_502ag = traductor_502ag.Traducir_502ag("msgPerfilCreado_502ag");
            msgNadaSeleccionadoParaBorrar_502ag = traductor_502ag.Traducir_502ag("msgNadaSeleccionadoParaBorrar_502ag");
            msgFamiliaNoEncontrada_502ag = traductor_502ag.Traducir_502ag("msgFamiliaNoEncontrada_502ag");
            msgNoBajaJerarquia_502ag = traductor_502ag.Traducir_502ag("msgNoBajaJerarquia_502ag");
            msgFamiliaBorrada_502ag = traductor_502ag.Traducir_502ag("msgFamiliaBorrada_502ag");
            msgPerfilNoEncontrado_502ag = traductor_502ag.Traducir_502ag("msgPerfilNoEncontrado_502ag");
            msgNoBajaPerfilConUsuarios_502ag = traductor_502ag.Traducir_502ag("msgNoBajaPerfilConUsuarios_502ag");
            msgPerfilBorrado_502ag = traductor_502ag.Traducir_502ag("msgPerfilBorrado_502ag");
            msgNadaSeleccionado_502ag = traductor_502ag.Traducir_502ag("msgNadaSeleccionado_502ag");
            msgMinUnPermiso_502ag = traductor_502ag.Traducir_502ag("msgMinUnPermiso_502ag");
            msgFamiliaEncontradaEnOtraJerarquia_502ag = traductor_502ag.Traducir_502ag("msgFamiliaEncontradaEnOtraJerarquia_502ag");
            msgFamiliaTieneRelacion_502ag = traductor_502ag.Traducir_502ag("msgFamiliaTieneRelacion_502ag");
            msgNoAsignarPermisosRepetidos_502ag = traductor_502ag.Traducir_502ag("msgNoAsignarPermisosRepetidos_502ag");
            msgPermisosAsignados_502ag = traductor_502ag.Traducir_502ag("msgPermisosAsignados_502ag");
            msgJerarquiaRota_502ag = traductor_502ag.Traducir_502ag("msgJerarquiaRota_502ag");
            msgNoDesasignarTodo_502ag = traductor_502ag.Traducir_502ag("msgNoDesasignarTodo_502ag");
            msgPermisosDesasignados_502ag = traductor_502ag.Traducir_502ag("msgPermisosDesasignados_502ag");
        }
    }
}
