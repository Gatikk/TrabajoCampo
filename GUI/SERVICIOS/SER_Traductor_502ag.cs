using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS_502ag
{
    public class SER_Traductor_502ag : ISubject_502ag
    {
        private static SER_Traductor_502ag instanciaTraductor_502ag;
        private List<IObserver_502ag> observers_502ag = new List<IObserver_502ag>();
        private Dictionary<string, string> traducciones_502ag = new Dictionary<string, string>();

        public static SER_Traductor_502ag GestorTraductor_502ag
        {
            get
            {
                if (instanciaTraductor_502ag == null)
                {
                    instanciaTraductor_502ag = new SER_Traductor_502ag();
                }
                return instanciaTraductor_502ag;
            }
        }

        public void Desuscribir_502ag(IObserver_502ag observer_502ag)
        {
            observers_502ag.Remove(observer_502ag);
        }

        public void Notificar_502ag()
        {
            foreach(var observer in observers_502ag)
            {
                observer.Actualizar_502ag(this);
            }
        }

        public void Suscribir_502ag(IObserver_502ag observer_502ag)
        {
            if(!observers_502ag.Contains(observer_502ag))
            {
                observers_502ag.Add(observer_502ag);
            }
        }

        public string Traducir_502ag(string clave_502ag)
        {
            return traducciones_502ag.ContainsKey(clave_502ag) ? traducciones_502ag[clave_502ag] : clave_502ag;
        }

        public List<string> DevolverListaIdiomas_502ag()
        {
            string rutaLenguajes_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes");
            string[] archivos_502ag = Directory.GetFiles(rutaLenguajes_502ag, "*.json");
            List<string> listaIdiomas_502ag = archivos_502ag.Select(archivo_502ag => Path.GetFileNameWithoutExtension(archivo_502ag)).ToList();
            return listaIdiomas_502ag;
        }

        public void CargarTraducciones_502ag()
        {
            traducciones_502ag.Clear();
            string rutaArchivo_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{SERVICIOS_502ag.SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.Idioma_502ag}.json");
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

    }
}
