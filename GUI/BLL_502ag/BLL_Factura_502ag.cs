using BE_502ag;
using DAL_502ag;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL_502ag
{
    public class BLL_Factura_502ag
    {
        #region DefinicionFactura
        //AltaFactura
        public BE_Factura_502ag AltaFactura_502ag(string codCombustible_502ag, string nomCombustible_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            BE_Factura_502ag factura_502ag = new BE_Factura_502ag(0, int.Parse(codCombustible_502ag), nomCombustible_502ag);
            factura_502ag.IsFacturado_502ag = false;
            factura_502ag.EstadoFactura_502ag = 1;
            factura_502ag.Fecha_502ag = DateTime.Now.Date;
            factura_502ag.Hora_502ag = DateTime.Now.TimeOfDay;
            return dalFactura_502ag.AltaFactura_502ag(factura_502ag);
            
        }
        //CargaFinalizada
        public void ActualizarFacturaCargaFinalizada_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaRecienCargada_502ag(factura_502ag);
        }
        //ClienteIdentificado
        public void ActualizarFacturaClienteIdentificado_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaClienteIdentificado_502ag(factura_502ag);
        }
        //FacturaFinalizada
        public void ActualizarFacturaFinalizada_502ag(BE_Factura_502ag factura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.ActualizarFacturaFinalizada_502ag(factura_502ag);
        }
        #endregion
        public List<BE_Factura_502ag> ObtenerListaFacturasNoFacturadas_502ag()
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerListaFacturasNoFacturadas_502ag();
        }
        public BE_Factura_502ag ObtenerFactura_502ag(int codFactura_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerFactura_502ag(codFactura_502ag);
        }
        public List<BE_Factura_502ag> ObtenerListaFacturas_502ag()
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            return dalFactura_502ag.ObtenerListaFacturas_502ag();
        }
        public void EliminarFacturasEstadoPendienteDeCarga_502ag(int codCombustible_502ag)
        {
            DAL_Factura_502ag dalFactura_502ag = new DAL_Factura_502ag();
            dalFactura_502ag.EliminarFacturasEstadoPendienteDeCarga_502ag(codCombustible_502ag);
        }

        public void GenerarFactura_502ag(BE_Factura_502ag factura_502ag) 
        {
            string carpeta_502ag = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas_502ag");
            if (!Directory.Exists(carpeta_502ag)) { Directory.CreateDirectory(carpeta_502ag); }
            string nombreArchivo_502ag = $"Factura_{factura_502ag.DNICliente_502ag}_Cod{factura_502ag.CodFactura_502ag}.pdf";
            string rutaFinal_502ag = Path.Combine(carpeta_502ag, nombreArchivo_502ag);
            string rutaImagen_502ag = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
            iTextSharp.text.Image logo_502ag = iTextSharp.text.Image.GetInstance(rutaImagen_502ag);

            float ancho_502ag = Utilities.MillimetersToPoints(80);
            float alto_502ag = Utilities.MillimetersToPoints(150);
            Document doc_502ag = new Document(new Rectangle(ancho_502ag, alto_502ag),10f,10f,10f,10f);
            using(FileStream fs_502ag = new FileStream(rutaFinal_502ag, FileMode.Create))
            {
                PdfWriter writer_502ag = PdfWriter.GetInstance(doc_502ag, fs_502ag);
                doc_502ag.Open();
                logo_502ag.ScaleAbsolute(75f, 37f);
                logo_502ag.SetAbsolutePosition(doc_502ag.LeftMargin, doc_502ag.PageSize.Height - logo_502ag.ScaledHeight - doc_502ag.TopMargin);
                doc_502ag.Add(logo_502ag);
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph(" "));
                Paragraph titulo_502ag = new Paragraph($"FACTURA", FontFactory.GetFont(FontFactory.COURIER_BOLD, 16));
                titulo_502ag.Alignment = Element.ALIGN_CENTER;
                doc_502ag.Add(titulo_502ag);
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph($"Fecha: {factura_502ag.Fecha_502ag.ToShortDateString()} {factura_502ag.Hora_502ag.ToString(@"hh\:mm")}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph($"Cliente: {factura_502ag.ApellidoCliente_502ag}, {factura_502ag.NombreCliente_502ag}", FontFactory.GetFont(FontFactory.COURIER, 10))); 
                doc_502ag.Add(new Paragraph($"DNI: {factura_502ag.DNICliente_502ag}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph("----------------------------------", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph($"Producto: {factura_502ag.NombreCombustible_502ag}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph($"Litros: {factura_502ag.CantCargada_502ag:F2} litros", FontFactory.GetFont(FontFactory.COURIER, 10)));
                decimal precioPorLitro_502ag = factura_502ag.Monto_502ag / factura_502ag.CantCargada_502ag;
                doc_502ag.Add(new Paragraph($"Precio x Litro: {precioPorLitro_502ag:F2}$", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph($"Importe: {factura_502ag.Monto_502ag:F2}$", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph("----------------------------------", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph($"Total: {factura_502ag.Monto_502ag:F2}$", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph($"Método: {factura_502ag.MetodoPago_502ag}", FontFactory.GetFont(FontFactory.COURIER, 10)));
                doc_502ag.Add(new Paragraph($"Total pagado: {factura_502ag.Monto_502ag:F2}$", FontFactory.GetFont(FontFactory.COURIER_BOLD, 12)));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph(" "));
                doc_502ag.Add(new Paragraph("Gracias por confiar en PetroStop :P", FontFactory.GetFont(FontFactory.COURIER_BOLD, 8)));
                

                doc_502ag.Close();

            }
        }
    }
}
