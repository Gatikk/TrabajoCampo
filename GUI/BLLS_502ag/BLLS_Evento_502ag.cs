using DAL_502ag;
using SE_502ag;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BLLS_502ag
{
    public class BLLS_Evento_502ag
    {

        public void AltaEvento_502ag(string modulo_502ag, string eventoDesc_502ag, int criticidad_502ag)
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            string fecha_502ag = DateTime.Now.ToString("ddMMyy");
            string ultCodigo_502ag = dalBitacoraEvento_502ag.ObtenerUltimoCodigoDelDia_502ag(fecha_502ag);
            int numero_502ag = 1;
            if(!string.IsNullOrEmpty(ultCodigo_502ag))
            {
                numero_502ag = int.Parse(ultCodigo_502ag.Substring(fecha_502ag.Length)) + 1;
            }
            string cod_502ag = fecha_502ag + numero_502ag.ToString("D4");
            SE_Evento_502ag evento_502ag = new SE_Evento_502ag
                (
                cod_502ag,
                SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag,
                DateTime.Now,
                DateTime.Now.TimeOfDay,
                modulo_502ag,
                eventoDesc_502ag,
                criticidad_502ag
                );         
            dalBitacoraEvento_502ag.AltaEvento_502ag(evento_502ag);
        }

        public List<SE_Evento_502ag> ObtenerEventos_502ag()
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            return dalBitacoraEvento_502ag.ObtenerEventos_502ag();
        }

        public List<SE_Evento_502ag> ObtenerEventosFiltrado_502ag(string usuario_502ag, DateTime fechaDesde_502ag, DateTime fechaHasta_502ag, string modulo_502ag, string eventoDesc_502ag, string criticidad_502ag, bool filtrarPorFecha_502ag)
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            return dalBitacoraEvento_502ag.ObtenerEventosFiltrado_502ag(usuario_502ag, fechaDesde_502ag, fechaHasta_502ag, modulo_502ag, eventoDesc_502ag, criticidad_502ag, filtrarPorFecha_502ag);
        }

        public List<SE_Evento_502ag> ObtenerTodosLosEventos_502ag()
        {
            DAL_BitacoraEvento_502ag dalBitacoraEvento_502ag = new DAL_BitacoraEvento_502ag();
            return dalBitacoraEvento_502ag.ObtenerTodosLosEventos_502ag();
        }
        public void ImprimirEventos_502ag(List<SE_Evento_502ag> eventos_502ag)
        {
            string carpeta_502ag = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReportesEventos_502ag");
            if (!Directory.Exists(carpeta_502ag)) { Directory.CreateDirectory(carpeta_502ag); }
            string nombreArchivo_502ag = $"Eventos{DateTime.Now.ToString("ddMMyy_HHmmss")}_{SER_GestorSesion_502ag.GestorSesion_502ag.sesion_502ag.NombreUsuario_502ag}.pdf";
            string rutaFinal_502ag = Path.Combine(carpeta_502ag, nombreArchivo_502ag);
            string rutaImagen_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
            float rowHeight_502ag = 18f; 
            float headerHeight_502ag = 20f;
            float totalHeight_502ag = headerHeight_502ag + (eventos_502ag.Count * rowHeight_502ag) + 100f;
            Document doc_502ag = new Document(new Rectangle(PageSize.A4.Width, totalHeight_502ag), 20f, 20f, 20f, 20f);
            using (FileStream fs_502ag = new FileStream(rutaFinal_502ag, FileMode.Create))
            {
                PdfWriter.GetInstance(doc_502ag, fs_502ag);
                doc_502ag.Open();

                var fontTitulo_502ag = FontFactory.GetFont(FontFactory.HELVETICA, 16);
                var fontHeader_502ag = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.WHITE);
                var fontCell_502ag = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

                Paragraph titulo_502ag = new Paragraph("REPORTE DE EVENTOS DEL SISTEMA", fontTitulo_502ag);
                titulo_502ag.Alignment = Element.ALIGN_CENTER;
                doc_502ag.Add(titulo_502ag);
                doc_502ag.Add(new Paragraph(" "));

                PdfPTable tabla_502ag = new PdfPTable(7);
                tabla_502ag.WidthPercentage = 100;
                tabla_502ag.SetWidths(new float[] { 12, 15, 12, 10, 15, 26, 10 });

                string[] encabezados_502ag = { "Código", "Usuario", "Fecha", "Hora", "Módulo", "Evento", "Criticidad" };
                foreach (var encabezado_502ag in encabezados_502ag)
                {
                    PdfPCell celdaHeader_502ag = new PdfPCell(new Phrase(encabezado_502ag, fontHeader_502ag));
                    celdaHeader_502ag.BackgroundColor = BaseColor.DARK_GRAY;
                    celdaHeader_502ag.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaHeader_502ag.Padding = 5;
                    tabla_502ag.AddCell(celdaHeader_502ag);
                }

                foreach (var evento in eventos_502ag)
                {
                    tabla_502ag.AddCell(new Phrase(evento.Codigo_502ag, fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Usuario_502ag, fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Fecha_502ag.ToShortDateString(), fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Hora_502ag.ToString(@"hh\:mm"), fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Modulo_502ag, fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Evento_502ag, fontCell_502ag));
                    tabla_502ag.AddCell(new Phrase(evento.Criticidad_502ag.ToString(), fontCell_502ag));
                }

                doc_502ag.Add(tabla_502ag);
                doc_502ag.Close();
            }
        }
    }
}
