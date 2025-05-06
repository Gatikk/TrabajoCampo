using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SERVICIOS_502ag
{
    public class Traductor_502ag : ISubject_502ag
    {
        private static Traductor_502ag instanciaTraductor_502ag;
        private List<IObserver_502ag> listaObserver_502ag = new List<IObserver_502ag>();
        private Dictionary<string, string> traducciones_502ag = new Dictionary<string, string>();
        
        public static Traductor_502ag GestorTraductor_502ag
        {
            get
            {
                if (instanciaTraductor_502ag == null)
                {
                    instanciaTraductor_502ag = new Traductor_502ag();
                }
                return instanciaTraductor_502ag;
            }
        }
        public void Suscribir_502ag(IObserver_502ag observer)
        {
            if (!listaObserver_502ag.Contains(observer))
            {
                listaObserver_502ag.Add(observer);
            }
        }
        public void Desuscribir_502ag(IObserver_502ag observer)
        {
            listaObserver_502ag.Remove(observer);
        }
        public void Notificar_502ag()
        {
            foreach (var observer in listaObserver_502ag)
            {
                observer.Actualizar_502ag(GestorTraductor_502ag);
            }
        }
        public void CargarIdioma_502ag()
        {
            string rutaArchivo_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Idioma_502ag}.json");
            if (File.Exists(rutaArchivo_502ag))
            {
                string json_502ag = File.ReadAllText(rutaArchivo_502ag);
                traducciones_502ag = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_502ag);
            }
            else
            {
                traducciones_502ag.Clear();
            }
            Notificar_502ag();
        }
        public List<string> DevolverListaIdiomas_502ag()
        {
            string rutaLenguajes_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes");
            string[] archivos_502ag = Directory.GetFiles(rutaLenguajes_502ag, "*.json");
            List<string> listaIdiomas_502ag = archivos_502ag.Select(archivo_502ag => Path.GetFileNameWithoutExtension(archivo_502ag)).ToList();
            return listaIdiomas_502ag;
        }

        public string Traducir_502ag(string clave)
        {
            return traducciones_502ag.ContainsKey(clave) ? $"{traducciones_502ag[clave]}" : $"{clave}";
        }

        public void CambiarIdioma_502ag()
        {
            CargarIdioma_502ag();
            Notificar_502ag();
            traducciones_502ag.Clear();
        }

    }
}
