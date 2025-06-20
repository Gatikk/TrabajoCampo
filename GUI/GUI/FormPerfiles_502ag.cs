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
        public FormPerfiles_502ag(FormMenu_502ag formMenu_502ag)
        {
            InitializeComponent();
            MostrarPermisos_502ag(cLBPermisos_502ag);
            MostrarFamilias_502ag();
            menu_502ag = formMenu_502ag;
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
                foreach (var hijo_502ag in familia_502ag.lista_502ag)
                {
                    JerarquiaNodos_502ag(hijo_502ag, nodo_502ag.Nodes);
                }
            }
            else
            {
                nodo_502ag = null;
            }
                nodos_502ag.Add(nodo_502ag);
        }

        private void buttonCrear_502ag_Click(object sender, EventArgs e)
        {
            try
            {
                SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
                SER_Patente_502ag serPatente_502ag = new SER_Patente_502ag();
                
                if (rBFamilia_502ag.Checked) 
                {
                    //familia no puede estar vacía
                    if(string.IsNullOrWhiteSpace(tBNombre_502ag.Text)) { throw new Exception("El nombre de la familia no puede estar vacío"); }
                    //familia con ese nombre = rip
                    if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == tBNombre_502ag.Text) != null){throw new Exception("Ya existe una familia con ese nombre");}
                    //familia sin patentes ni familias = rip
                    if (cLBPermisos_502ag.CheckedItems.Count <= 0){ throw new Exception("No se puede dar de alta una familia sin permisos asignados"); }
                    SE_Familia_502ag nuevaFamilia_502ag = new SE_Familia_502ag(tBNombre_502ag.Text);
                    //revisar que la familia no sea padre de la familia a la que se quiere agregar
                    
                    
                    
                    //discriminador de familias y patentes
                    foreach (var item_502ag in cLBPermisos_502ag.CheckedItems)
                    {
                        string nombre_502ag = item_502ag.ToString();
                        //se corrobora si el item checkeado es patente 
                        if (serPatente_502ag.ObtenerListaPatentes_502ag().Find(x => x.Nombre_502ag == nombre_502ag)!= null)
                        {
                            SE_Perfil_502ag patente_502ag = new SE_Patente_502ag(nombre_502ag);
                            //agrega patentes dentro de la familia
                            nuevaFamilia_502ag.Agregar_502ag(patente_502ag);
                        }
                        //se corrobora si el item checkeado es familia
                        if (serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag) != null)
                        {
                            SE_Familia_502ag familiaExistente = serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag().Find(x => x.Nombre_502ag == nombre_502ag);
                            if (familiaExistente != null) { nuevaFamilia_502ag.Agregar_502ag(familiaExistente); }
                        }
                    }


                    var listaPerfiles = new List<SE_Perfil_502ag>();
                    listaPerfiles.Clear();
                    if (!serFamilia_502ag.PatenteOFamiliaRepetido(nuevaFamilia_502ag, listaPerfiles)) { throw new Exception("No se puede dar de alta"); }


                    //se da de alta la familia con sus patentes y familias correspondientes
                    serFamilia_502ag.AltaFamilia_502ag(nuevaFamilia_502ag);
                    MessageBox.Show("Familia creada");
                    MostrarPermisos_502ag(cLBPermisos_502ag);
                    MostrarFamilias_502ag();
                }
            }
            catch(Exception ex) {MessageBox.Show($"Error: {ex.Message}");}
        }

        private void FormPerfiles_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FormPerfiles_502ag_Activated(object sender, EventArgs e)
        {
            SER_Familia_502ag serFamilia_502ag = new SER_Familia_502ag();
            cBFamilia_502ag.Items.Clear();
            foreach (SE_Familia_502ag familia_502ag in serFamilia_502ag.ObtenerListaFamiliasCompleta_502ag())
            {
                cBFamilia_502ag.Items.Add(familia_502ag.Nombre_502ag);
            }
            cBFamilia_502ag.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cBFamilia_502ag_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
