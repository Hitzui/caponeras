using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Mantenimiento;

public sealed class ReportMantenimientosRealizados : XtraReport
{
    public ReportMantenimientosRealizados()
    {
        Parameters.AddRange(new[]
        {
            new Parameter { Name = "parDesde", Type = typeof(DateTime), Visible = false },
            new Parameter { Name = "parHasta", Type = typeof(DateTime), Visible = false }
        });
        Margins = new DXMargins(35, 35, 30, 30);

        var header = new ReportHeaderBand { HeightF = 58F };
        header.Controls.Add(new XRLabel
        {
            Text = "REPORTE DE MANTENIMIENTOS REALIZADOS",
            Font = new DXFont("Segoe UI", 14F, DXFontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(730F, 28F)
        });
        var rango = new XRLabel
        {
            Font = new DXFont("Segoe UI", 9F),
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 30F),
            SizeF = new SizeF(730F, 22F)
        };
        rango.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text",
            "FormatString('Finalizados desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}', ?parDesde, ?parHasta)"));
        header.Controls.Add(rango);

        var tableHeader = new PageHeaderBand { HeightF = 27F };
        tableHeader.Controls.Add(CrearTabla(true));
        var detail = new DetailBand { HeightF = 58F, KeepTogether = true };
        detail.Controls.Add(CrearTabla(false));

        var footer = new PageFooterBand { HeightF = 22F };
        footer.Controls.Add(new XRPageInfo
        {
            PageInfo = PageInfo.NumberOfTotal,
            TextFormatString = "Página {0} de {1}",
            TextAlignment = TextAlignment.MiddleCenter,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(730F, 20F)
        });

        Bands.AddRange(new Band[]
        {
            new TopMarginBand { HeightF = 30F }, header, tableHeader, detail, footer,
            new BottomMarginBand { HeightF = 30F }
        });
        DataSource = typeof(ReporteMantenimientoDto);
    }

    private static XRTable CrearTabla(bool encabezado)
    {
        var table = new XRTable
        {
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(730F, encabezado ? 27F : 58F),
            Borders = BorderSide.All,
            Font = new DXFont("Segoe UI", encabezado ? 8.5F : 8F,
                encabezado ? DXFontStyle.Bold : DXFontStyle.Regular),
            BackColor = encabezado ? Color.FromArgb(226, 232, 240) : Color.White,
            Padding = new PaddingInfo(4, 4, 2, 2)
        };
        var row = new XRTableRow();
        var columns = new (string Caption, string Field, double Weight)[]
        {
            ("Fecha", "FechaFin", 1D),
            ("Caponera", "Caponera", 1D),
            ("Placa", "Placa", 1D),
            ("Tipo", "TipoMantenimiento", 1.2D),
            ("Trabajo / título", "Titulo", 1.4D),
            ("Descripción y observaciones", "Detalle", 2.4D)
        };

        foreach (var column in columns)
        {
            var cell = new XRTableCell
            {
                Text = encabezado ? column.Caption : string.Empty,
                Weight = column.Weight,
                Multiline = true,
                CanGrow = true,
                TextAlignment = encabezado ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };
            if (!encabezado)
            {
                var fieldExpression = column.Field switch
                {
                    "FechaFin" => "FormatString('{0:dd/MM/yyyy}', [FechaFin])",
                    "Detalle" => "Iif(IsNullOrEmpty([Descripcion]), [Observaciones], Iif(IsNullOrEmpty([Observaciones]), [Descripcion], [Descripcion] + '\n' + [Observaciones]))",
                    _ => $"[{column.Field}]"
                };
                cell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", fieldExpression));
            }
            row.Cells.Add(cell);
        }

        table.Rows.Add(row);
        return table;
    }
}
