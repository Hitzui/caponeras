using DevExpress.XtraReports.UI;
using Caponeras.App.Dto;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Cadetes
{
    public partial class ReportCuotaPorRango : DevExpress.XtraReports.UI.XtraReport
    {
        private XRTableRow _filaTotalGeneral = null!;

        public ReportCuotaPorRango()
        {
            InitializeComponent();
            AgregarTotalGeneral();
        }

        private void AgregarTotalGeneral()
        {
            var tabla = new XRTable
            {
                LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F),
                SizeF = new System.Drawing.SizeF(714F, 27F),
                Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold),
                BackColor = System.Drawing.Color.FromArgb(226, 232, 240),
                Borders = DevExpress.XtraPrinting.BorderSide.All,
                Padding = new DevExpress.XtraPrinting.PaddingInfo(4F, 4F, 0F, 0F)
            };
            var fila = new XRTableRow();
            fila.Cells.Add(CrearCeldaTotal("TOTAL GENERAL", "", 2D, DevExpress.XtraPrinting.TextAlignment.MiddleLeft));
            fila.Cells.Add(CrearCeldaTotal("0.00", "", 1D));
            fila.Cells.Add(CrearCeldaTotal("0.00", "", 1D));
            fila.Cells.Add(CrearCeldaTotal("0.00", "", 1D));
            fila.Cells.Add(CrearCeldaTotal("0.00%", "", 1D, DevExpress.XtraPrinting.TextAlignment.MiddleRight, ""));
            tabla.Rows.Add(fila);
            _filaTotalGeneral = fila;
            ReportFooter.Controls.Add(tabla);
            ReportFooter.HeightF = 61F;
            xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34F);
        }

        public void CargarDatos(IReadOnlyCollection<ReporteCuotaDto> datos)
        {
            DataSource = datos;
            var cuotaEsperada = datos.Sum(x => x.CuotaEsperada);
            var totalEntregado = datos.Sum(x => x.TotalEntregado);
            _filaTotalGeneral.Cells[1].Text = cuotaEsperada.ToString("N2");
            _filaTotalGeneral.Cells[2].Text = totalEntregado.ToString("N2");
            _filaTotalGeneral.Cells[3].Text = (cuotaEsperada - totalEntregado).ToString("N2");
            _filaTotalGeneral.Cells[4].Text = cuotaEsperada == 0m
                ? "0.00%"
                : $"{totalEntregado / cuotaEsperada:P2}";
        }

        private static XRTableCell CrearCeldaTotal(
            string texto,
            string expresion,
            double peso,
            DevExpress.XtraPrinting.TextAlignment alineacion = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
            string formato = "{0:N2}")
        {
            var celda = new XRTableCell
            {
                Text = texto,
                Weight = peso,
                TextAlignment = alineacion,
                TextFormatString = formato
            };
            if (!string.IsNullOrEmpty(expresion))
                celda.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", expresion));
            return celda;
        }
    }
}
