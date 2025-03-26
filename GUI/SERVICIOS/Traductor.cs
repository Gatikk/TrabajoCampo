using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SERVICIOS
{
    public class Traductor : ISubject
    {
        private static Traductor instanciaTraductor;
        private List<IObserver> listaObserver = new List<IObserver>();
        private Dictionary<string, string> traducciones = new Dictionary<string, string>();
        
        public static Traductor GestorTraductor
        {
            get
            {
                if (instanciaTraductor == null)
                {
                    instanciaTraductor = new Traductor();
                }
                return instanciaTraductor;
            }
        }

        public void CargarIdioma()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{SessionManager.GestorSessionManager.sesion.Idioma}.json");
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                traducciones = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                traducciones.Clear();
            }
            Notificar();
        }
        public List<string> DevolverListaIdiomas()
        {
            string rutaLenguajes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes");
            string[] archivos = Directory.GetFiles(rutaLenguajes, "*.json");
            List<string> listaIdiomas = archivos.Select(archivo => Path.GetFileNameWithoutExtension(archivo)).ToList();
            return listaIdiomas;
        }

        public string Traducir(string clave)
        {
            return traducciones.ContainsKey(clave) ? $"{traducciones[clave]}" : $"{clave}";
        }

        public void CambiarIdioma()
        {
            CargarIdioma();
            Notificar();
            traducciones.Clear();
        }

        public void Suscribir(IObserver observer)
        {
            if (!listaObserver.Contains(observer))
            {
                listaObserver.Add(observer);
            }
        }

        public void Desuscribir(IObserver observer)
        {
            listaObserver.Remove(observer);
        }

        public void Notificar()
        {
            foreach (var observer in listaObserver)
            {
                observer.Actualizar(this);
            }
        }
    }
}
