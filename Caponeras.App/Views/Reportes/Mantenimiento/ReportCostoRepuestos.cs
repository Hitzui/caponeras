using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Mantenimiento;

public sealed class ReportCostoRepuestos : XtraReport
{
    public ReportCostoRepuestos()
    {
        Parameters.AddRange(new[]
        {
            new Parameter { Name = "parDesde", Type = typeof(DateTime), Visible = false },
            new Parameter { Name = "parHasta", Type = typeof(DateTime), Visible = false }
        });
        Margins = new DXMargins(35, 35, 30, 30);

        var header = ReportFactory.CreateHeader("COSTO DE MANTENIMIENTOS POR REPUESTOS", "Mantenimientos finalizados entre {0:dd/MM/yyyy} y {1:dd/MM/yyyy}");
        var pageHeader = new PageHeaderBand { HeightF = 27F };
        pageHeader.Controls.Add(ReportFactory.CreateTable(true, 730F, 27F,
            ("Fecha", "", 0.9D), ("Caponera", "", 0.8D), ("Placa", "", 0.9D),
            ("Trabajo", "", 1.2D), ("Repuesto", "", 1.5D), ("Origen", "", 1.2D),
            ("Cant.", "", 0.6D), ("Costo unit.", "", 0.9D), ("Costo total", "", 1D)));

        var detail = new DetailBand { HeightF = 30F, KeepTogether = true };
        detail.Controls.Add(ReportFactory.CreateTable(false, 730F, 30F,
            ("", "FechaMantenimiento", 0.9D), ("", "Caponera", 0.8D), ("", "Placa", 0.9D),
            ("", "Trabajo", 1.2D), ("", "Repuesto", 1.5D), ("", "Origen", 1.2D),
            ("", "Cantidad", 0.6D), ("", "CostoUnitario", 0.9D), ("", "CostoTotal", 1D)));

        var reportFooter = new ReportFooterBand { HeightF = 32F };
        var total = new XRLabel
        {
            Font = new DXFont("Segoe UI", 10F, DXFontStyle.Bold),
            TextAlignment = TextAlignment.MiddleRight,
            Borders = BorderSide.Top | BorderSide.Bottom,
            Padding = new PaddingInfo(5, 8, 2, 2),
            LocationFloat = new PointFloat(0, 3F),
            SizeF = new SizeF(730F, 27F)
        };
        total.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text",
            "FormatString('TOTAL DE REPUESTOS: {0:n2}', sumSum([CostoTotal]))"));
        reportFooter.Controls.Add(total);

        Bands.AddRange(new Band[]
        {
            new TopMarginBand { HeightF = 30F }, header, pageHeader, detail, reportFooter,
            ReportFactory.CreateFooter(730F), new BottomMarginBand { HeightF = 30F }
        });
        DataSource = typeof(ReporteCostoRepuestoDto);
    }
}
