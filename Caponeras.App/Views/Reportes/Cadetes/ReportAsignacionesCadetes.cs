using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Cadetes;

public sealed class ReportAsignacionesCadetes : XtraReport
{
    public ReportAsignacionesCadetes()
    {
        Parameters.AddRange(new[]
        {
            new Parameter { Name = "parDesde", Type = typeof(DateTime), Visible = false },
            new Parameter { Name = "parHasta", Type = typeof(DateTime), Visible = false }
        });

        Margins = new DXMargins(45, 45, 35, 35);

        var reportHeader = new ReportHeaderBand { HeightF = 58F };
        reportHeader.Controls.Add(new XRLabel
        {
            Text = "REPORTE DE VEHÍCULOS ASIGNADOS",
            Font = new DXFont("Segoe UI", 14F, DXFontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, 28F)
        });
        var rango = new XRLabel
        {
            Font = new DXFont("Segoe UI", 9F),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 30F),
            SizeF = new SizeF(714F, 22F)
        };
        rango.ExpressionBindings.Add(new ExpressionBinding(
            "BeforePrint", "Text",
            "FormatString('Desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}', ?parDesde, ?parHasta)"));
        reportHeader.Controls.Add(rango);

        var pageHeader = new PageHeaderBand { HeightF = 25F };
        pageHeader.Controls.Add(CrearTabla(encabezados: true));

        var zonaHeader = new GroupHeaderBand
        {
            HeightF = 25F,
            RepeatEveryPage = true,
            KeepTogether = true
        };
        zonaHeader.GroupFields.Add(new GroupField("Zona", XRColumnSortOrder.Ascending));
        var zona = new XRLabel
        {
            BackColor = Color.FromArgb(25, 82, 105),
            ForeColor = Color.White,
            Font = new DXFont("Segoe UI", 9F, DXFontStyle.Bold),
            Padding = new PaddingInfo(7, 3, 0, 0),
            TextAlignment = TextAlignment.MiddleLeft,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, 24F)
        };
        zona.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'ZONA: ' + [Zona]"));
        zonaHeader.Controls.Add(zona);

        var detail = new DetailBand { HeightF = 22F, KeepTogether = true };
        detail.Controls.Add(CrearTabla(encabezados: false));

        var groupFooter = new GroupFooterBand { HeightF = 5F };
        groupFooter.Controls.Add(new XRLine
        {
            LineWidth = 1,
            ForeColor = Color.FromArgb(190, 198, 207),
            LocationFloat = new PointFloat(0, 2F),
            SizeF = new SizeF(714F, 2F)
        });

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
            zonaHeader,
            detail,
            groupFooter,
            pageFooter,
            new BottomMarginBand { HeightF = 35F }
        });
        DataSource = typeof(ReporteAsignacionCadeteDto);
    }

    private static XRTable CrearTabla(bool encabezados)
    {
        var tabla = new XRTable
        {
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, encabezados ? 25F : 24F),
            Borders = BorderSide.All,
            Font = new DXFont("Segoe UI", encabezados ? 8.5F : 8F,
                encabezados ? DXFontStyle.Bold : DXFontStyle.Regular),
            BackColor = encabezados ? Color.FromArgb(226, 232, 240) : Color.White,
            Padding = new PaddingInfo(4, 4, 0, 0)
        };

        var fila = new XRTableRow();
        var columnas = new (string Titulo, string Campo, double Peso)[]
        {
            ("Cadete", "Cadete", 1.6D),
            ("Identificación", "Identificacion", 1.1D),
            ("Código", "Codigo", 0.85D),
            ("Placa", "Placa", 0.9D),
            ("Desde", "FechaInicio", 0.9D),
            ("Hasta", "FechaFin", 0.9D)
        };

        for (var indice = 0; indice < columnas.Length; indice++)
        {
            var columna = columnas[indice];
            var celda = new XRTableCell
            {
                Text = encabezados ? columna.Titulo : string.Empty,
                Weight = columna.Peso,
                TextAlignment = encabezados
                    ? TextAlignment.MiddleCenter
                    : indice >= 4 ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };

            if (!encabezados)
            {
                celda.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{columna.Campo}]"));
                if (columna.Campo is "FechaInicio" or "FechaFin")
                    celda.TextFormatString = "{0:dd/MM/yyyy}";
            }

            fila.Cells.Add(celda);
        }

        tabla.Rows.Add(fila);
        return tabla;
    }
}
