using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Mantenimiento;

public sealed class ReportManoObraPagada : XtraReport
{
    public ReportManoObraPagada()
    {
        Parameters.AddRange(new[]
        {
            new Parameter { Name = "parDesde", Type = typeof(DateTime), Visible = false },
            new Parameter { Name = "parHasta", Type = typeof(DateTime), Visible = false }
        });
        Margins = new DXMargins(40, 40, 30, 30);

        var header = ReportFactory.CreateHeader("REPORTE DE MANO DE OBRA PAGADA", "Pagos registrados entre {0:dd/MM/yyyy} y {1:dd/MM/yyyy}");
        var pageHeader = new PageHeaderBand { HeightF = 27F };
        pageHeader.Controls.Add(ReportFactory.CreateTable(true, 730F, 27F,
            ("Fecha pago", "", 1D), ("Caponera", "", 1D), ("Placa", "", 1D),
            ("Proveedor", "", 1.7D), ("Trabajo", "", 1.8D), ("Monto pagado", "", 1.1D)));

        var detail = new DetailBand { HeightF = 28F, KeepTogether = true };
        detail.Controls.Add(ReportFactory.CreateTable(false, 730F, 28F,
            ("", "FechaPago", 1D), ("", "Caponera", 1D), ("", "Placa", 1D),
            ("", "Proveedor", 1.7D), ("", "Trabajo", 1.8D), ("", "MontoPagado", 1.1D)));
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
            "FormatString('TOTAL PAGADO: {0:n2}', sumSum([MontoPagado]))"));
        reportFooter.Controls.Add(total);
        var footer = ReportFactory.CreateFooter(730F);
        Bands.AddRange(new Band[] { new TopMarginBand { HeightF = 30F }, header, pageHeader, detail, reportFooter, footer, new BottomMarginBand { HeightF = 30F } });
        DataSource = typeof(ReporteManoObraPagadaDto);
    }
}

internal static class ReportFactory
{
    internal static ReportHeaderBand CreateHeader(string title, string rangeFormat)
    {
        var header = new ReportHeaderBand { HeightF = 58F };
        header.Controls.Add(new XRLabel
        {
            Text = title,
            Font = new DXFont("Segoe UI", 14F, DXFontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(730F, 28F)
        });
        var range = new XRLabel
        {
            Font = new DXFont("Segoe UI", 9F),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 30F),
            SizeF = new SizeF(730F, 22F)
        };
        range.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text",
            $"FormatString('{rangeFormat}', ?parDesde, ?parHasta)"));
        header.Controls.Add(range);
        return header;
    }

    internal static PageFooterBand CreateFooter(float width)
    {
        var footer = new PageFooterBand { HeightF = 22F };
        footer.Controls.Add(new XRPageInfo
        {
            PageInfo = PageInfo.NumberOfTotal,
            TextFormatString = "Página {0} de {1}",
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(width, 20F)
        });
        return footer;
    }

    internal static XRTable CreateTable(bool header, float width, float height,
        params (string Caption, string Field, double Weight)[] columns)
    {
        var table = new XRTable
        {
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(width, height),
            Borders = BorderSide.All,
            Font = new DXFont("Segoe UI", header ? 8.5F : 8F, header ? DXFontStyle.Bold : DXFontStyle.Regular),
            BackColor = header ? Color.FromArgb(226, 232, 240) : Color.White,
            Padding = new PaddingInfo(4, 4, 1, 1)
        };
        var row = new XRTableRow();
        foreach (var column in columns)
        {
            var cell = new XRTableCell
            {
                Text = header ? column.Caption : string.Empty,
                Weight = column.Weight,
                Multiline = true,
                CanGrow = true,
                TextAlignment = header ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };
            if (!header)
            {
                cell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{column.Field}]"));
                if (column.Field is "FechaPago" or "FechaMantenimiento")
                    cell.TextFormatString = "{0:dd/MM/yyyy}";
                if (column.Field is "MontoPagado" or "CostoUnitario" or "CostoTotal")
                    cell.TextFormatString = "{0:n2}";
            }
            row.Cells.Add(cell);
        }
        table.Rows.Add(row);
        return table;
    }
}
