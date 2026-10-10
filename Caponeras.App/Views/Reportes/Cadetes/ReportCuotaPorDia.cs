using DevExpress.XtraReports.UI;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Caponeras.App.Views.Reportes.Cadetes
{
    public partial class ReportCuotaPorDia : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportCuotaPorDia()
        {
            InitializeComponent();
            Detail.HeightF = 44F;
            var ausencia = new XRLabel
            {
                Font = new DXFont("Segoe UI", 8F, DXFontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(153, 27, 27),
                LocationFloat = new PointFloat(4F, 25F),
                SizeF = new System.Drawing.SizeF(728F, 17F),
                Padding = new PaddingInfo(2F, 2F, 0F, 0F),
                CanGrow = true,
                CanShrink = true,
                TextAlignment = TextAlignment.MiddleLeft
            };
            ausencia.ExpressionBindings.Add(new ExpressionBinding(
                "BeforePrint", "Text",
                "Iif(IsNullOrEmpty([MotivoAusencia]), '', 'AUSENCIA: ' + [MotivoAusencia] + Iif(IsNullOrEmpty([DetalleAusencia]), '', ' — ' + [DetalleAusencia]))"));
            ausencia.ExpressionBindings.Add(new ExpressionBinding(
                "BeforePrint", "Visible", "Not IsNullOrEmpty([MotivoAusencia])"));
            Detail.Controls.Add(ausencia);
        }
    }
}
