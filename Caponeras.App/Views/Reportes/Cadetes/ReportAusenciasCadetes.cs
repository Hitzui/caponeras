using Caponeras.App.Dto;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Cadetes;

public sealed class ReportAusenciasCadetes : XtraReport
{
    public ReportAusenciasCadetes()
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
            Text = "REPORTE DE AUSENCIAS DE CADETES",
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

        var fechaHeader = new GroupHeaderBand
        {
            HeightF = 25F,
            RepeatEveryPage = true,
            KeepTogether = true
        };
        fechaHeader.GroupFields.Add(new GroupField("Fecha", XRColumnSortOrder.Ascending));
        var fechaLabel = new XRLabel
        {
            BackColor = Color.FromArgb(25, 82, 105),
            ForeColor = Color.White,
            Font = new DXFont("Segoe UI", 9F, DXFontStyle.Bold),
            Padding = new PaddingInfo(7, 3, 0, 0),
            TextAlignment = TextAlignment.MiddleLeft,
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, 24F)
        };
        fechaLabel.ExpressionBindings.Add(new ExpressionBinding(
            "BeforePrint", "Text", "FormatString('FECHA: {0:dd/MM/yyyy}', [Fecha])"));
        fechaHeader.Controls.Add(fechaLabel);

        var detail = new DetailBand { HeightF = 30F, KeepTogether = true };
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
            fechaHeader,
            detail,
            pageFooter,
            new BottomMarginBand { HeightF = 35F }
        });
        DataSource = typeof(AusenciaCadeteDto);
    }

    private static XRTable CrearTabla(bool encabezados)
    {
        var tabla = new XRTable
        {
            LocationFloat = new PointFloat(0, 0),
            SizeF = new SizeF(714F, encabezados ? 25F : 30F),
            Borders = BorderSide.All,
            Font = new DXFont("Segoe UI", encabezados ? 8.5F : 8F,
                encabezados ? DXFontStyle.Bold : DXFontStyle.Regular),
            BackColor = encabezados ? Color.FromArgb(226, 232, 240) : Color.White,
            Padding = new PaddingInfo(4, 4, 1, 1)
        };
        var fila = new XRTableRow();
        var columnas = new (string Titulo, string Campo, double Peso)[]
        {
            ("Zona", "Zona", 1.1D),
            ("Cadete", "Cadete", 1.5D),
            ("Vehículo", "Vehiculo", 1.2D),
            ("Motivo", "Motivo", 1.5D),
            ("Detalle", "Detalle", 2.4D)
        };

        foreach (var columna in columnas)
        {
            var celda = new XRTableCell
            {
                Text = encabezados ? columna.Titulo : string.Empty,
                Weight = columna.Peso,
                Multiline = true,
                CanGrow = true,
                TextAlignment = encabezados ? TextAlignment.MiddleCenter : TextAlignment.MiddleLeft
            };
            if (!encabezados)
                celda.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{columna.Campo}]"));
            fila.Cells.Add(celda);
        }

        tabla.Rows.Add(fila);
        return tabla;
    }
}
