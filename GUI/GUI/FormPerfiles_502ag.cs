using SE_502ag;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPerfiles_502ag : Form
    {
        FormMenu_502ag menu_502ag;
        public string opcion_502ag = "Consulta";
        public FormPerfiles_502ag(FormMenu_502ag formMenu_502ag)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
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
        }

        private void MostrarPermisos_502ag(CheckedListBox clb_502ag)
        {
            clb_502ag.Items.Clear();
            SER_Patente_502ag serPatente_502ag = new SER_Patente_502ag();
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            foreach (SE_Patente_502ag patente_502ag in serPatente_502ag.ObtenerListaPatentes_502ag())
            {
                clb_502ag.Items.Add(patente_502ag.Nombre_502ag, false);
            }
            foreach (SE_Familia_502ag familia_502ag in serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                clb_502ag.Items.Add(familia_502ag.Nombre_502ag, false);
            }
        }

        private void MostrarFamilias_502ag()
        {
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            tVFamilias_502ag.Nodes.Clear();
            foreach (SE_Familia_502ag familia_502ag in serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                JerarquiaNodos_502ag(familia_502ag, tVFamilias_502ag.Nodes);
            }
        }
        private void MostrarPerfiles_502ag()
        {
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            tVPerfiles_502ag.Nodes.Clear();
            foreach(SE_Familia_502ag perfil_502ag in serPerfil_502ag.ObtenerListaPerfiles_502ag())
            {
                JerarquiaNodos_502ag(perfil_502ag, tVPerfiles_502ag.Nodes);
            }
        }

        private void JerarquiaNodos_502ag(SE_Perfil_502ag permiso_502ag, TreeNodeCollection nodos_502ag)
        {
            TreeNode nodo_502ag;
            if(permiso_502ag is SE_Patente_502ag)
            {
                nodo_502ag = new TreeNode(permiso_502ag.Nombre_502ag);
            }
            else if(permiso_502ag is SE_Familia_502ag familia_502ag)
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
            if(nodos_502ag != null)
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
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            cBFamilia_502ag.Items.Clear();
            cBPerfil_502ag.Items.Clear();
            foreach (SE_Familia_502ag familia_502ag in serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                cBFamilia_502ag.Items.Add(familia_502ag.Nombre_502ag);
            }
            foreach (SE_Familia_502ag perfil_502ag in serPerfil_502ag.ObtenerListaPerfiles_502ag())
            {
                cBPerfil_502ag.Items.Add(perfil_502ag.Nombre_502ag);
            }
            cBFamilia_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPerfil_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormPerfiles_502ag_Activated(object sender, EventArgs e)
        {
            //ActualizarComboBox_502ag();            
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
            catch(Exception ex) {MessageBox.Show($"Error: {ex.Message}");}
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
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }
        private void cBFamilia_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
            {
                cLBPermisos_502ag.SetItemChecked(i, false);
            }
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            SE_Familia_502ag familiaComboBox_502ag = new SE_Familia_502ag(cBFamilia_502ag.Text);
            familiaComboBox_502ag = serFamilia_502ag.ObtenerListaProfundidadUno_502ag(familiaComboBox_502ag);
            RellenarCheckedListBox(familiaComboBox_502ag);
            
        }
        private void cBPerfil_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
            {
                cLBPermisos_502ag.SetItemChecked(i, false);
            }
            SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
            SE_Familia_502ag perfilComboBox_502ag = new SE_Familia_502ag(cBPerfil_502ag.Text);
            perfilComboBox_502ag = serPerfil_502ag.ObtenerListaPerfilProfundidadUno_502ag(perfilComboBox_502ag);

            RellenarCheckedListBox(perfilComboBox_502ag);
        }
        private void RellenarCheckedListBox(SE_Familia_502ag familia_502ag)
        {
            try
            {
                foreach (SE_Perfil_502ag permiso_502ag in familia_502ag.lista_502ag)
                {
                    if (permiso_502ag is SE_Patente_502ag patente)
                    {
                        int index = BuscarIndice(patente);
                        if(index != -1)
                        {
                            cLBPermisos_502ag.SetItemChecked(index, true);
                        }
                    }
                    if(permiso_502ag is SE_Familia_502ag familia)
                    {
                        RellenarCheckedListBox(familia);
                        int index = BuscarIndice(familia);
                        if (index != -1)
                        {
                            cLBPermisos_502ag.SetItemChecked(index, true);
                        }
                    }
                }
                
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private int BuscarIndice(SE_Perfil_502ag permiso_502ag)
        {
            for (int i = 0; i < cLBPermisos_502ag.Items.Count; i++)
            {
                if (cLBPermisos_502ag.Items[i].ToString().Equals(permiso_502ag.Nombre_502ag)){
                    return i;
                }
            }
            return -1;
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
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
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
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu_502ag.Show();
        }

        private void buttonAplicar_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                if (opcion_502ag == "Crear")
                {
                    SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
                    SER_Patente_502ag serPatente_502ag = new SER_Patente_502ag();
                    SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
                    if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == tBNombre_502ag.Text) != null) throw new Exception("Ya existe una familia con ese nombre");
                    if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == tBNombre_502ag.Text) != null) throw new Exception("Ya existe un permiso con ese nombre");
                    if (serPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == tBNombre_502ag.Text) != null) throw new Exception("Ya existe un perfil con ese nombre");
                    if (rBFamilia_502ag.Checked)
                    {
                        //familia no puede estar vacía
                        if (string.IsNullOrWhiteSpace(tBNombre_502ag.Text)) { throw new Exception("El nombre de la familia no puede estar vacío"); }
                        //familia con ese nombre = rip
                        //familia sin patentes ni familias = rip
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("No se puede dar de alta una familia sin permisos asignados"); }
                        SE_Familia_502ag nuevaFamilia_502ag = new SE_Familia_502ag(tBNombre_502ag.Text);
                        //discriminador de familias y patentes
                        foreach (var item_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = item_502ag.ToString();
                            //se corrobora si el item checkeado es patente 
                            if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                //agrega patentes dentro de la familia
                                nuevaFamilia_502ag.Agregar_502ag(patente_502ag);
                            }
                            //se corrobora si el item checkeado es familia
                            if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia_502ag = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (subFamilia_502ag != null) { nuevaFamilia_502ag.Agregar_502ag(subFamilia_502ag); }
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();
                        listaPermisos_502ag.Clear();
                        if (!serFamilia_502ag.PatenteRepetida_502ag(nuevaFamilia_502ag, listaPermisos_502ag)) { throw new Exception("No se puede dar de alta, hay patentes repetidas"); }
                        //se da de alta la familia con sus patentes y familias correspondientes
                        serFamilia_502ag.AltaFamilia_502ag(nuevaFamilia_502ag);
                        MessageBox.Show("Familia creada");
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(tBNombre_502ag.Text)) { throw new Exception("El nombre del perfil no puede estar vacío"); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("No se puede dar de alta un perfil sin permisos asignados"); }

                        SE_Familia_502ag nuevoPerfil_502ag = new SE_Familia_502ag(tBNombre_502ag.Text);
                        foreach (var item_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = item_502ag.ToString();
                            //se corrobora si el item checkeado es patente 
                            if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                //agrega patentes dentro de la familia
                                nuevoPerfil_502ag.Agregar_502ag(patente_502ag);
                            }
                            //se corrobora si el item checkeado es familia
                            if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia_502ag = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (subFamilia_502ag != null) { nuevoPerfil_502ag.Agregar_502ag(subFamilia_502ag); }
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisos_502ag = new List<SE_Perfil_502ag>();
                        listaPermisos_502ag.Clear();
                        if (!serFamilia_502ag.PatenteRepetida_502ag(nuevoPerfil_502ag, listaPermisos_502ag)) { throw new Exception("No se puede dar de alta, hay patentes repetidas"); }

                        serPerfil_502ag.AltaPerfil_502ag(nuevoPerfil_502ag);
                        MessageBox.Show("Perfil creado");

                    }
                    MostrarPermisos_502ag(cLBPermisos_502ag);
                    MostrarFamilias_502ag();
                    MostrarPerfiles_502ag();
                    ActualizarComboBox_502ag();
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
                    SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
                    SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
                    if (rBFamilia_502ag.Checked)
                    {
                        
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado para borrar"); }
                        if (!serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Any(x => x.Nombre_502ag == cBFamilia_502ag.Text)) throw new Exception("Familia no encontrada");
                        SE_Familia_502ag familiaSeleccionada = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());

                        //verificar que sea una familia independiente
                        if (serPerfil_502ag.PerteneceAFamilia_502ag(familiaSeleccionada)){ throw new Exception("No se puede borrar porque se encuentra dentro de una jerarquía"); }

                        serFamilia_502ag.BorrarFamilia_502ag(familiaSeleccionada);
                        cBFamilia_502ag.SelectedItem = null;
                        MessageBox.Show("Familia borrada con éxito");
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado para borrar"); }
                        if (!serPerfil_502ag.ObtenerListaPerfiles_502ag().Any(x => x.Nombre_502ag == cBPerfil_502ag.Text)) throw new Exception("Perfil no encontrado");
                        SE_Familia_502ag perfilSeleccionado_502ag = serPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());
                        serPerfil_502ag.BorrarPerfil_502ag(perfilSeleccionado_502ag);
                        cBPerfil_502ag.SelectedItem = null;
                        MessageBox.Show("Perfil borrado con éxito");
                    }
                    MostrarPermisos_502ag(cLBPermisos_502ag);
                    MostrarFamilias_502ag();
                    MostrarPerfiles_502ag();
                    ActualizarComboBox_502ag();
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
                    SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
                    SER_Patente_502ag serPatente_502ag = new SER_Patente_502ag();
                    SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
                    if (rBFamilia_502ag.Checked)
                    {
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado"); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("Sí o sí tiene que tener por lo menos un permiso"); }
                        SE_Familia_502ag familiaSeleccionada = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());
                        //verificar que la familia seleccionada no perteneza a ninguna de las subfamilias marcadas
                        foreach (var itemchecked in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = itemchecked.ToString();
                            if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (!serFamilia_502ag.CompararFamiliaPadreEHijos(familiaSeleccionada, subFamilia)) throw new Exception("Tu familia seleccionada ya se encuentra en la jerarquía de otra familia que tenes marcada");
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisosAAgregar_502ag = new List<SE_Perfil_502ag>();
                        foreach (var itemcheck in cLBPermisos_502ag.CheckedItems)
                        {
                            if (!familiaSeleccionada.lista_502ag.Any(x => x.Nombre_502ag == itemcheck.ToString()))
                            {
                                string nombre_502ag = itemcheck.ToString();
                                if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                    listaPermisosAAgregar_502ag.Add(patente_502ag);
                                }
                                if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Familia_502ag familia_502ag = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                    if (familia_502ag != null) { listaPermisosAAgregar_502ag.Add(familia_502ag); }
                                }
                            }
                        }

                        //evitar que 2 familias que no tienen relacion entre sí pero ambas pertenecen a un perfil compartan patente
                        if (serPerfil_502ag.EvitarPermisosRepetidosEntreFamiliasQueCompartenPerfil_502ag(familiaSeleccionada, listaPermisosAAgregar_502ag)) throw new Exception("La familia que estas editando ya tiene relación con una de las patentes que deseas agregar");


                        //verificar que no hayan patentes repetidas en la lista
                        List<SE_Perfil_502ag> listaPermisosAAgregarAux_502ag = new List<SE_Perfil_502ag>(listaPermisosAAgregar_502ag);
                        if (!serFamilia_502ag.PatenteRepetida_502ag(familiaSeleccionada, listaPermisosAAgregarAux_502ag)) { throw new Exception("No se puede realizar la operación, hay patentes repetidas"); }
                        serFamilia_502ag.AsignarPermisosAFamilia_502ag(familiaSeleccionada, listaPermisosAAgregar_502ag);
                        MessageBox.Show("Permisos asignados");
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado"); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("Sí o sí tiene que tener por lo menos un permiso"); }
                        SE_Familia_502ag perfilSeleccionado_502ag = serPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());

                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            string nombre_502ag = itemchecked_502ag.ToString();
                            if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                            {
                                SE_Familia_502ag subFamilia = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                if (!serFamilia_502ag.CompararFamiliaPadreEHijos(perfilSeleccionado_502ag, subFamilia)) throw new Exception("Se rompe la jerarquía");
                            }
                        }
                        List<SE_Perfil_502ag> listaPermisosAAgregar_502ag = new List<SE_Perfil_502ag>();
                        foreach (var itemchecked_502ag in cLBPermisos_502ag.CheckedItems)
                        {
                            if (!perfilSeleccionado_502ag.lista_502ag.Any(x => x.Nombre_502ag == itemchecked_502ag.ToString()))
                            {
                                string nombre_502ag = itemchecked_502ag.ToString();
                                if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                                    listaPermisosAAgregar_502ag.Add(patente_502ag);
                                }
                                if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                                {
                                    SE_Familia_502ag familia_502ag = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                                    if (familia_502ag != null) { listaPermisosAAgregar_502ag.Add(familia_502ag); }
                                }
                            }
                        }

                        //evitar que se asigne una familia que tiene como subfamilia la misma familia que tiene el perfil
                        List<SE_Perfil_502ag> listaPermisosAAgregarAux_502ag = new List<SE_Perfil_502ag>(listaPermisosAAgregar_502ag);
                        if (!serPerfil_502ag.Verificacion(perfilSeleccionado_502ag, listaPermisosAAgregarAux_502ag)) throw new Exception("Imposible asignar, se repetirían permisos");
                        serPerfil_502ag.AsignarPermisosAPerfil_502ag(perfilSeleccionado_502ag, listaPermisosAAgregar_502ag);
                        MessageBox.Show("Permisos asignados");
                    }
                    MostrarPermisos_502ag(cLBPermisos_502ag);
                    MostrarFamilias_502ag();
                    MostrarPerfiles_502ag();
                    ActualizarComboBox_502ag();
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
                        SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
                        if (cBFamilia_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado"); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("No se puede desasignar todo"); }
                        SE_Familia_502ag familiaSeleccionada = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == cBFamilia_502ag.SelectedItem.ToString());
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
                        serFamilia_502ag.DesasignarPermisosAFamilia_502ag(familiaSeleccionada);
                        MessageBox.Show("Permisos desasignados");
                    }
                    if (rBPerfil_502ag.Checked)
                    {
                        SER_Perfil_502ag serPerfil_502ag = new SER_Perfil_502ag();
                        if (cBPerfil_502ag.SelectedItem == null) { throw new Exception("No hay nada seleccionado"); }
                        if (cLBPermisos_502ag.CheckedItems.Count <= 0) { throw new Exception("No se puede desasignar todo"); }
                        SE_Familia_502ag perfilSeleccionado_502ag = serPerfil_502ag.ObtenerListaPerfiles_502ag().Find(x => x.Nombre_502ag == cBPerfil_502ag.SelectedItem.ToString());
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
                        serPerfil_502ag.DesasignarPermisosAPerfil_502ag(perfilSeleccionado_502ag);
                        MessageBox.Show("Permisos desasignados");
                    }
                    MostrarPermisos_502ag(cLBPermisos_502ag);
                    MostrarFamilias_502ag();
                    MostrarPerfiles_502ag();
                    ActualizarComboBox_502ag();
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
            }
            catch(Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
           
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
        }

        private void ActualizarComboBoxSegunOpcion_502ag()
        {
            if(opcion_502ag == "Borrar")
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
            if(opcion_502ag == "Desasignar")
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
    }
}
