﻿using BE;
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
using BLL;
using System.Deployment.Internal;
using Microsoft.VisualBasic;

namespace GUI
{
    public partial class FormMenu : Form
    {
        BLL_Usuario bllUsuario;
        public FormMenu()
        {
            InitializeComponent();
            bllUsuario = new BLL_Usuario();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500,200);
            labelBienvenida.Text = $"Bienvenido @{SERVICIOS.SessionManager.GestorSessionManager().DevolverNombre()}";
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            SERVICIOS.SessionManager.GestorSessionManager().CerrarSesion();
            this.Hide();
            loginForm.Show();
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonABM_Click(object sender, EventArgs e)
        {
            FormABM abmForm = new FormABM();
            this.Hide();
            abmForm.Show(); 
        }

        private void buttonCambiarContraseña_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña cambiarContraseñaForm = new FormCambiarContraseña();
            this.Hide();
            cambiarContraseñaForm.Show();
        }
        private void buttonBitacora_Click(object sender, EventArgs e)
        {
            FormBitacora bitacoraForm = new FormBitacora();
            this.Hide();
            bitacoraForm.Show();
        }

    }
}
