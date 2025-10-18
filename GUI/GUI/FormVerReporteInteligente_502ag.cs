using BLL_502ag;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class FormVerReporteInteligente_502ag : Form
    {
        public FormVerReporteInteligente_502ag()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(500, 200);
            InitializeComponent();
            rBFacturacionMensualPorCombustible_502ag.Checked = true;
            GraficoFactura_502ag();
        }


        private void GraficoFactura_502ag()
        {
            try
            {
                if (rBFacturacionMensualPorCombustible_502ag.Checked)
                {
                    chartFacturasCombustible_502ag.Series.Clear();
                    chartFacturasCombustible_502ag.Titles.Clear();
                    chartFacturasCombustible_502ag.ChartAreas[0].RecalculateAxesScale();
                    Series series_502ag = new Series("Facturación por Mes");
                    series_502ag.ChartType = SeriesChartType.Column;
                    series_502ag.ToolTip = "#VALY{C0}";
                    series_502ag.Color = Color.FromArgb(128, 255, 128);
                    series_502ag.BorderColor = Color.DarkGray;
                    series_502ag.BorderWidth = 1;
                    BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                    List<Tuple<string, decimal>> datos_502ag = bllFactura_502ag.FacturacionPorMes_502ag();
                    foreach (var dato_502ag in datos_502ag)
                    {
                        series_502ag.Points.AddXY(dato_502ag.Item1, dato_502ag.Item2);
                    }
                    chartFacturasCombustible_502ag.Series.Add(series_502ag);
                    chartFacturasCombustible_502ag.Titles.Add("Reporte Facturación Mensual por Carga de Combustible");
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisX.Title = "Mes";
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisY.Title = "Monto total ($)";
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisX.Interval = 1;
                }
                if (rBGanaciaPorCombustible_502ag.Checked)
                {
                    chartFacturasCombustible_502ag.Series.Clear();
                    chartFacturasCombustible_502ag.Titles.Clear();
                    Series series_502ag = new Series("Ganancia por Combustible");
                    series_502ag.ChartType = SeriesChartType.Pie;
                    series_502ag.ToolTip = "#VALY{C0}";
                    series_502ag.BorderWidth = 3;
                    BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                    List<Tuple<string, decimal>> datos_502ag = bllFactura_502ag.VentasPorCombustible_502ag();
                    foreach (var dato_502ag in datos_502ag)
                    {
                        series_502ag.Points.AddXY(dato_502ag.Item1, dato_502ag.Item2);
                    }
                    chartFacturasCombustible_502ag.Series.Add(series_502ag);
                    chartFacturasCombustible_502ag.Titles.Add("Reporte Ganancia por Combustible");
                }
                if (rBCargasPorHora_502ag.Checked)
                {
                    chartFacturasCombustible_502ag.Series.Clear();
                    chartFacturasCombustible_502ag.Titles.Clear();
                    chartFacturasCombustible_502ag.ChartAreas[0].RecalculateAxesScale();
                    Series series_502ag = new Series("Cantidad de Cargas por Horario");
                    series_502ag.ChartType = SeriesChartType.Column;
                    series_502ag.Color = Color.FromArgb(128, 255, 128);
                    series_502ag.BorderColor = Color.DarkGray;
                    series_502ag.BorderWidth = 1;
                    BLL_Factura_502ag bllFactura_502ag = new BLL_Factura_502ag();
                    List<Tuple<string, decimal>> datos_502ag = bllFactura_502ag.CargasPorHora_502ag();
                    foreach (var dato_502ag in datos_502ag)
                    {
                        series_502ag.Points.AddXY(dato_502ag.Item1, dato_502ag.Item2);
                    }
                    chartFacturasCombustible_502ag.Series.Add(series_502ag);
                    chartFacturasCombustible_502ag.Titles.Add("Reporte Cargas por Horario");
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisX.Title = "Rango Horario";
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisY.Title = "Cantidad de cargas";
                    chartFacturasCombustible_502ag.ChartAreas[0].AxisX.Interval = 1;
                }
            }
            catch(Exception ex) {MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void rBFacturacionMensualPorCombustible_502ag_CheckedChanged(object sender, EventArgs e)
        {
            GraficoFactura_502ag();
        }

        private void buttonVolverAlMenu_502ag_Click(object sender, EventArgs e)
        {
            FormMenu_502ag formMenu_502ag = new FormMenu_502ag();
            this.Hide();
            formMenu_502ag.Show();
        }

        private void buttonImprimirReporte_502ag_Click(object sender, EventArgs e)
        {
            ImprimirReporteInteligente_502ag(chartFacturasCombustible_502ag, chartFacturasCombustible_502ag.Titles[0].Text);
            MessageBox.Show("Reporte imprimido con éxito");
        }

        private void FormVerReporteInteligente_502ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void rBGanaciaPorCombustible_502ag_CheckedChanged(object sender, EventArgs e)
        {
            GraficoFactura_502ag();
        }

        private void rBCargasPorHora_502ag_CheckedChanged(object sender, EventArgs e)
        {
            GraficoFactura_502ag();
        }

        private void ImprimirReporteInteligente_502ag(Chart chartControl_502ag, string tituloReporte_502ag)
        {
            string carpeta_502ag = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ReportesInteligentes_502ag");
            if (!Directory.Exists(carpeta_502ag))
            {
                Directory.CreateDirectory(carpeta_502ag);
            }
            string nombreArchivo_502ag = $"{tituloReporte_502ag} - {DateTime.Now:dd-MM-yy HH-mm-ss}.pdf";
            string rutaFinal_502ag = Path.Combine(carpeta_502ag, nombreArchivo_502ag);

            using (var memoryStream_502ag = new MemoryStream())
            {
                chartControl_502ag.SaveImage(memoryStream_502ag, ChartImageFormat.Png);
                iTextSharp.text.Image chartImage_502ag = iTextSharp.text.Image.GetInstance(memoryStream_502ag.ToArray());

                Document doc_502ag = new Document(PageSize.A4.Rotate());
                PdfWriter.GetInstance(doc_502ag, new FileStream(rutaFinal_502ag, FileMode.Create));

                doc_502ag.Open();

                float availableWidth = doc_502ag.PageSize.Width - doc_502ag.LeftMargin - doc_502ag.RightMargin;
                float availableHeight = doc_502ag.PageSize.Height - doc_502ag.TopMargin - doc_502ag.BottomMargin - 20; 
                chartImage_502ag.ScaleToFit(availableWidth, availableHeight);
                chartImage_502ag.Alignment = Element.ALIGN_CENTER;

                doc_502ag.Add(chartImage_502ag);
                doc_502ag.Close();
            }
        }
    }
}
