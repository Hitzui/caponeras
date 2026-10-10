using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Cadetes;

public sealed class ReportLicenciasCadetes : XtraReport
{
    public ReportLicenciasCadetes()
    {
        Margins = new DXMargins(45, 45, 35, 35);

        var reportHeader = new ReportHeaderBand { HeightF = 42F };
        reportHeader.Controls.Add(new XRLabel
        {
            Text = "REPORTE DE LICENCIAS DE CADETES",
            Font = new DXFont("Segoe UI", 14F, DXFontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, 32F)
        });

        var pageHeader = new PageHeaderBand { HeightF = 28F };
        pageHeader.Controls.Add(CrearTabla(encabezados: true));

        var detail = new DetailBand { HeightF = 25F, KeepTogether = true };
        detail.Controls.Add(CrearTabla(encabezados: false));

        var pageFooter = new PageFooterBand { HeightF = 22F };
        pageFooter.Controls.Add(new XRPageInfo
        {
            PageInfo = PageInfo.NumberOfTotal,
            TextFormatString = "Página {0} de {1}",
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, 20F)
        });

        Bands.AddRange(new Band[]
        {
            new TopMarginBand { HeightF = 35F },
            reportHeader,
            pageHeader,
            detail,
            pageFooter,
            new BottomMarginBand { HeightF = 35F }
        });
        DataSource = typeof(ReporteLicenciaCadeteDto);
    }

    private static XRTable CrearTabla(bool encabezados)
    {
        var tabla = new XRTable
        {
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, encabezados ? 28F : 25F),
            Borders = BorderSide.All,
            Font = new DXFont("Segoe UI", encabezados ? 8.5F : 8F,
                encabezados ? DXFontStyle.Bold : DXFontStyle.Regular),
            BackColor = encabezados ? Color.FromArgb(226, 232, 240) : Color.White,
            Padding = new PaddingInfo(4, 4, 1, 1)
        };
        var fila = new XRTableRow();
        var columnas = new (string Titulo, string Campo, double Peso)[]
        {
            ("Cadete", "Cadete", 2.2D),
            ("Categoría", "Categoria", 0.9D),
            ("N.º de licencia", "NumeroLicencia", 1.4D),
            ("Fecha de emisión", "FechaEmision", 1.2D),
            ("Fecha de vencimiento", "FechaVencimiento", 1.4D),
            ("Estado", "EstadoLicencia", 1.1D)
        };

        foreach (var columna in columnas)
        {
            var celda = new XRTableCell
            {
                Text = encabezados ? columna.Titulo : string.Empty,
                Weight = columna.Peso,
                Multiline = true,
                TextAlignment = encabezados ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };
            if (!encabezados)
            {
                celda.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{columna.Campo}]"));
                if (columna.Campo is "FechaEmision" or "FechaVencimiento")
                    celda.TextFormatString = "{0:dd/MM/yyyy}";
                if (columna.Campo == "EstadoLicencia")
                    celda.Font = new DXFont("Segoe UI", 8F, DXFontStyle.Bold);
            }
            fila.Cells.Add(celda);
        }

        tabla.Rows.Add(fila);
        return tabla;
    }
}
