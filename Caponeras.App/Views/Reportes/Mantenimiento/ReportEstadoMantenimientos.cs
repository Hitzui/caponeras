using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Mantenimiento;

public sealed class ReportEstadoMantenimientos : XtraReport
{
    public ReportEstadoMantenimientos()
    {
        Parameters.AddRange(new[]
        {
            new DevExpress.XtraReports.Parameters.Parameter { Name = "parDesde", Type = typeof(DateTime), Visible = false },
            new DevExpress.XtraReports.Parameters.Parameter { Name = "parHasta", Type = typeof(DateTime), Visible = false }
        });
        Margins = new DXMargins(35, 35, 30, 30);

        var header = ReportFactory.CreateHeader("ESTADO DE MANTENIMIENTOS", "Fechas del trabajo entre {0:dd/MM/yyyy} y {1:dd/MM/yyyy}");
        var pageHeader = new PageHeaderBand { HeightF = 27F };
        pageHeader.Controls.Add(CrearTabla(encabezado: true));
        var detail = new DetailBand { HeightF = 58F, KeepTogether = true };
        detail.Controls.Add(CrearTabla(encabezado: false));

        Bands.AddRange(new Band[]
        {
            new TopMarginBand { HeightF = 30F }, header, pageHeader, detail,
            ReportFactory.CreateFooter(730F), new BottomMarginBand { HeightF = 30F }
        });
        DataSource = typeof(ReporteEstadoMantenimientoDto);
    }

    private static XRTable CrearTabla(bool encabezado)
    {
        var columnas = new (string Titulo, string Campo, double Peso)[]
        {
            ("Caponera", "Caponera", 0.8D),
            ("Placa", "Placa", 0.9D),
            ("Tipo", "TipoMantenimiento", 1.1D),
            ("Trabajo", "Trabajo", 1.3D),
            ("Inicio", "FechaInicio", 1.1D),
            ("Fin", "FechaFin", 1.1D),
            ("Estado / proceso", "Estado", 1.3D),
            ("Detalle", "Detalle", 1.8D)
        };
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
        foreach (var columna in columnas)
        {
            var cell = new XRTableCell
            {
                Text = encabezado ? columna.Titulo : string.Empty,
                Weight = columna.Peso,
                Multiline = true,
                CanGrow = true,
                TextAlignment = encabezado ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };
            if (!encabezado)
            {
                var expression = columna.Campo switch
                {
                    "FechaInicio" => "FormatString('{0:dd/MM/yy HH:mm}', [FechaInicio])",
                    "FechaFin" => "FormatString('{0:dd/MM/yy HH:mm}', [FechaFin])",
                    "Detalle" => "Iif(IsNullOrEmpty([Descripcion]), [Observaciones], Iif(IsNullOrEmpty([Observaciones]), [Descripcion], [Descripcion] + '\n' + [Observaciones]))",
                    _ => $"[{columna.Campo}]"
                };
                cell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", expression));
                if (columna.Campo == "Estado")
                    cell.Font = new DXFont("Segoe UI", 8F, DXFontStyle.Bold);
            }
            row.Cells.Add(cell);
        }
        table.Rows.Add(row);
        return table;
    }
}
