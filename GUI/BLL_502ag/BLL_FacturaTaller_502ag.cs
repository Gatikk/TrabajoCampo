using BE_502ag;
using BLLS_502ag;
using DAL_502ag;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SERVICIOS_502ag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_502ag
{
    public class BLL_FacturaTaller_502ag
    {
        public void GenerarFacturaTaller_502ag(BE_OrdenTrabajo_502ag ordenTrabajo_502ag, string metodoPago_502ag)
        {
            string codigo_502ag = ordenTrabajo_502ag.CodOrdenTrabajo_502ag;
            string dniCliente_502ag = ordenTrabajo_502ag.DNICliente_502ag;
            BLL_Cliente_502ag bllCliente_502ag = new BLL_Cliente_502ag();
            BE_Cliente_502ag cliente_502ag = bllCliente_502ag.ObtenerCliente_502ag(dniCliente_502ag);
            string nombreCliente_502ag = cliente_502ag.Nombre_502ag;
            string apellidoCliente_502ag = cliente_502ag.Apellido_502ag;
            BLL_DiagnosticoFinal_502ag bLL_DiagnosticoFinal_502ag= new BLL_DiagnosticoFinal_502ag();
            BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag = bLL_DiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(codigo_502ag);
            decimal monto_502ag = diagnosticoFinal_502ag.CostoManoObra_502ag + diagnosticoFinal_502ag.CostoRepuestos_502ag;
            
            BE_FacturaTaller_502ag factura_502ag = new BE_FacturaTaller_502ag(codigo_502ag, dniCliente_502ag, nombreCliente_502ag, apellidoCliente_502ag, metodoPago_502ag, monto_502ag, diagnosticoFinal_502ag.Descripcion_502ag);
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            dalFacturaTaller_502ag.GenerarFacturaTaller_502ag(factura_502ag);

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Taller", "Generar Factura", 3);
            BLL_DigitoVerificador_502ag bllDigitoVerificador_502ag = new BLL_DigitoVerificador_502ag();
            bllDigitoVerificador_502ag.ActualizarDigitoFacturaTaller_502ag();
        }

        public List<BE_FacturaTaller_502ag> ObtenerFacturasTaller_502ag()
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            return dalFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
        }

        public BE_FacturaTaller_502ag ObtenerFactura_502ag(string codigo_502ag)
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            return dalFacturaTaller_502ag.ObtenerFactura_502ag(codigo_502ag);
        }

        public string CalcularDVH_502ag()
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            List<BE_FacturaTaller_502ag> facturas_502ag = dalFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            foreach (BE_FacturaTaller_502ag factura_502ag in facturas_502ag)
            {
                string horizontal_502ag = "";
                horizontal_502ag = factura_502ag.CodFactura_502ag + factura_502ag.DNICliente_502ag + factura_502ag.NombreCliente_502ag + factura_502ag.ApellidoCliente_502ag + factura_502ag.MetodoPago_502ag + factura_502ag.Monto_502ag + factura_502ag.DescripcionFinal_502ag;
                horizontal_502ag = encryptador_502ag.EncryptadorIrreversible_502ag(horizontal_502ag);
                horizontales_502ag.Add(horizontal_502ag);
            }
            string dvh_502ag = "";
            foreach (string horizontal_502ag in horizontales_502ag)
            {
                dvh_502ag += horizontal_502ag;
            }
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvh_502ag);
        }

        public void GenerarFacturaTallerPDF_502ag(string codFactura_502ag)
        {
            BE_FacturaTaller_502ag factura_502ag = ObtenerFactura_502ag(codFactura_502ag);
            BE_OrdenTrabajo_502ag ordenTrabajo_502ag = new BLL_OrdenTrabajo_502ag().ObtenerOrdenDeTrabajo_502ag(codFactura_502ag);

            BLL_DiagnosticoFinal_502ag bllDiagnosticoFinal_502ag = new BLL_DiagnosticoFinal_502ag();
            BE_DiagnosticoFinal_502ag diagnosticoFinal_502ag = bllDiagnosticoFinal_502ag.ObtenerDiagnosticoFinal_502ag(codFactura_502ag);

            BLL_RepuestoOrdenTrabajo_502ag bllRepuestoOT_502ag = new BLL_RepuestoOrdenTrabajo_502ag();
            List<BE_RepuestoOrdenTrabajo_502ag> repuestosOT_502ag = bllRepuestoOT_502ag.ObtenerDatosIntermedia_502ag(codFactura_502ag);
            BLL_Repuesto_502ag bllRepuesto_502ag = new BLL_Repuesto_502ag();

            string carpeta_502ag = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas_502ag");
            if (!Directory.Exists(carpeta_502ag)) { Directory.CreateDirectory(carpeta_502ag); }
            string nombreArchivo_502ag = $"FacturaTaller_{factura_502ag.DNICliente_502ag}_Cod{factura_502ag.CodFactura_502ag}.pdf";
            string rutaFinal_502ag = Path.Combine(carpeta_502ag, nombreArchivo_502ag);
            string rutaImagen_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
            iTextSharp.text.Image logo_502ag = iTextSharp.text.Image.GetInstance(rutaImagen_502ag);

            Document doc_502ag = new Document(PageSize.A4, 40, 40, 40, 40);
            using (FileStream fs_502ag = new FileStream(rutaFinal_502ag, FileMode.Create))
            {
                PdfWriter writer_502ag = PdfWriter.GetInstance(doc_502ag, fs_502ag);
                doc_502ag.Open();

                var fontTitulo_502ag = FontFactory.GetFont(FontFactory.COURIER_BOLD, 18);
                var fontSubtitulo_502ag = FontFactory.GetFont(FontFactory.COURIER_BOLD, 14);
                var fontNormal_502ag = FontFactory.GetFont(FontFactory.COURIER, 12);
                var fontTabla_502ag = FontFactory.GetFont(FontFactory.COURIER, 11);
                var fontBold_502ag = FontFactory.GetFont(FontFactory.COURIER_BOLD, 12);

                logo_502ag.ScaleAbsolute(120f, 60f);
                logo_502ag.Alignment = Element.ALIGN_LEFT;
                doc_502ag.Add(logo_502ag);

                Paragraph titulo_502ag = new Paragraph("FACTURA TALLER", fontTitulo_502ag);
                titulo_502ag.Alignment = Element.ALIGN_CENTER;
                doc_502ag.Add(titulo_502ag);
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));

                doc_502ag.Add(new Paragraph($"Fecha: {factura_502ag.Fecha_502ag:dd/MM/yyyy} {factura_502ag.Hora_502ag:hh\\:mm}", fontNormal_502ag));
                doc_502ag.Add(new Paragraph($"Cliente: {factura_502ag.ApellidoCliente_502ag}, {factura_502ag.NombreCliente_502ag}", fontNormal_502ag));
                doc_502ag.Add(new Paragraph($"DNI: {factura_502ag.DNICliente_502ag}", fontNormal_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));
                doc_502ag.Add(new Paragraph(new string('-', 60), fontNormal_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));

                doc_502ag.Add(new Paragraph("Diagnóstico Final:", fontBold_502ag));
                doc_502ag.Add(new Paragraph(diagnosticoFinal_502ag.Descripcion_502ag, fontNormal_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));
                doc_502ag.Add(new Paragraph($"Costo Mano de Obra: {diagnosticoFinal_502ag.CostoManoObra_502ag + "$"}", fontSubtitulo_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));

                doc_502ag.Add(new Paragraph("Repuestos:", fontBold_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag)); 

                if (repuestosOT_502ag.Count > 0)
                {
                    PdfPTable tabla_502ag = new PdfPTable(3);
                    tabla_502ag.WidthPercentage = 80;
                    tabla_502ag.SetWidths(new float[] { 3, 1, 2 });

                    PdfPCell cellDesc_502ag = new PdfPCell(new Phrase("Descripción", fontTabla_502ag));
                    PdfPCell cellCant_502ag = new PdfPCell(new Phrase("Cantidad", fontTabla_502ag));
                    PdfPCell cellPrecioUnitario_502ag = new PdfPCell(new Phrase("Precio Unitario", fontTabla_502ag));
                    cellDesc_502ag.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellCant_502ag.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellPrecioUnitario_502ag.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla_502ag.AddCell(cellDesc_502ag);
                    tabla_502ag.AddCell(cellCant_502ag);
                    tabla_502ag.AddCell(cellPrecioUnitario_502ag);

                    foreach (BE_RepuestoOrdenTrabajo_502ag repuestoOT_502ag in repuestosOT_502ag)
                    {
                        BE_Repuesto_502ag repuesto_502ag = bllRepuesto_502ag.ObtenerRepuesto_502ag(repuestoOT_502ag.CodigoRepuesto_502ag);
                        tabla_502ag.AddCell(new PdfPCell(new Phrase(repuesto_502ag.Descripcion_502ag, fontTabla_502ag)));
                        tabla_502ag.AddCell(new PdfPCell(new Phrase("x"+repuestoOT_502ag.Cantidad_502ag.ToString(), fontTabla_502ag)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        tabla_502ag.AddCell(new PdfPCell(new Phrase(repuesto_502ag.Precio_502ag.ToString()+"$", fontTabla_502ag)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    }
                    doc_502ag.Add(tabla_502ag);
                    doc_502ag.Add(new Paragraph($"Total Repuestos: {diagnosticoFinal_502ag.CostoRepuestos_502ag + "$"}", fontSubtitulo_502ag));
                }
                else
                {
                    doc_502ag.Add(new Paragraph("No se utilizaron repuestos.", fontSubtitulo_502ag));
                }

                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));
                doc_502ag.Add(new Paragraph(new string('-', 60), fontNormal_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));

                doc_502ag.Add(new Paragraph($"Método de Pago: {factura_502ag.MetodoPago_502ag}", fontNormal_502ag));
                doc_502ag.Add(new Paragraph($"Total Factura: {factura_502ag.Monto_502ag + "$"}", fontSubtitulo_502ag));
                doc_502ag.Add(new Paragraph(" ", fontNormal_502ag));
                doc_502ag.Add(new Paragraph("Gracias por confiar en PetroStop", fontBold_502ag));
                doc_502ag.Close();
            }

            BLLS_Evento_502ag bllsEvento_502ag = new BLLS_Evento_502ag();
            bllsEvento_502ag.AltaEvento_502ag("Reporte", "Generar Factura Taller", 4);
        }
        public string CalcularDVV_502ag()
        {
            DAL_FacturaTaller_502ag dalFacturaTaller_502ag = new DAL_FacturaTaller_502ag();
            List<BE_FacturaTaller_502ag> facturas_502ag = dalFacturaTaller_502ag.ObtenerFacturasTaller_502ag();
            List<string> horizontales_502ag = new List<string>();
            Encryptador_502ag encryptador_502ag = new Encryptador_502ag();
            string codigos_502ag = "";
            string dnis_502ag = "";
            string nombres_502ag = "";
            string apellidos_502ag = "";
            string fechas_502ag = "";
            string horas_502ag = "";
            string metodosPago_502ag = "";
            string montos_502ag = "";
            string descripciones_502ag = "";

            foreach (BE_FacturaTaller_502ag factura_502ag in facturas_502ag)
            {
                codigos_502ag += factura_502ag.CodFactura_502ag;
                dnis_502ag += factura_502ag.DNICliente_502ag;
                nombres_502ag += factura_502ag.NombreCliente_502ag;
                apellidos_502ag += factura_502ag.ApellidoCliente_502ag;
                fechas_502ag += factura_502ag.Fecha_502ag;
                horas_502ag += factura_502ag.Hora_502ag;
                metodosPago_502ag += factura_502ag.MetodoPago_502ag;
                montos_502ag += factura_502ag.Monto_502ag;
                descripciones_502ag += factura_502ag.DescripcionFinal_502ag;
            }

            string dvv_502ag = codigos_502ag + dnis_502ag + nombres_502ag + apellidos_502ag + fechas_502ag + horas_502ag + metodosPago_502ag + montos_502ag + descripciones_502ag;
            return encryptador_502ag.EncryptadorIrreversible_502ag(dvv_502ag);
        }

    }
}
