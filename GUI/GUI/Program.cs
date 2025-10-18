using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culturaForzada_502ag = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentCulture = culturaForzada_502ag;
            Thread.CurrentThread.CurrentUICulture = culturaForzada_502ag;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin_502ag());
            
        }
    }
}
