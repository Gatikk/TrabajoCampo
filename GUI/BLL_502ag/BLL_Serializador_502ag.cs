using BE_502ag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL_502ag
{
    public class BLL_Serializador_502ag
    {
        public void SerializarXML_502ag(string ruta_502ag, List<BE_Cliente_502ag> clientes_502ag)
        {
            using (FileStream fs_502ag = new FileStream(ruta_502ag, FileMode.Create))
            {
                XmlSerializer serializador_502ag = new XmlSerializer(typeof(List<BE_Cliente_502ag>));
                serializador_502ag.Serialize(fs_502ag, clientes_502ag);
            }
        }

        public List<BE_Cliente_502ag> DeserializarXML_502ag(string ruta_502ag)
        {
            using (FileStream fs_502ag = new FileStream(ruta_502ag, FileMode.Open))
            {
                XmlSerializer serializador_502ag = new XmlSerializer(typeof(List<BE_Cliente_502ag>));
                return (List<BE_Cliente_502ag>)serializador_502ag.Deserialize(fs_502ag);
            }
        }

        public string SerializarEnMemoria_502ag(List<BE_Cliente_502ag> listaClientes_502ag)
        {
            XmlSerializer serializador_502ag = new XmlSerializer(typeof(List<BE_Cliente_502ag>));
            using (StringWriter writer_502ag = new StringWriter())
            {
                serializador_502ag.Serialize(writer_502ag, listaClientes_502ag);
                return writer_502ag.ToString();
            }
        }

    }
}
