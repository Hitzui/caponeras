using System.IO;
using System.Net.Http;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Caponeras.App.Helpers;

public class HelperMethods
{
    public static bool ValidateRequired(Control control, string message, ErrorProvider errorProvider)
    {
        if (string.IsNullOrWhiteSpace(control.Text))
        {
            errorProvider.SetError(control, message);
            control.Focus();
            return false;
        }

        errorProvider.SetError(control, string.Empty);
        return true;
    }

    public static decimal ToDecimal(object? value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        var success = decimal.TryParse(value.ToString(), out var result);
        return success ? result : 0;
    }

    public static async Task<Image?> CargarImagenAsync(string? url, HttpClient client)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;

        try
        {
            var bytes = await client.GetByteArrayAsync(url);
            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);
            return new Bitmap(img);
        }
        catch
        {
            return null;
        }
    }

    public static void LoadReport(XtraReport report, string title = "Previsualizar Reporte")
    {
        try
        {
            var reportPrintTool = new ReportPrintTool(report);
            reportPrintTool.PreviewRibbonForm.Text = title;
            reportPrintTool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            reportPrintTool.AutoShowParametersPanel = false;
            report.RequestParameters = false;
            report.CreateDocument(false);
            reportPrintTool.ShowRibbonPreview();
            // Evento al cerrar la ventana de vista previa
            reportPrintTool.PreviewRibbonForm.FormClosed += (s, e) =>
            {
                // Liberar memoria del reporte y sus gráficos
                report.Dispose();

                // Forzar recolección de basura para limpiar GDI/GDI+ handles
                GC.Collect();
                GC.WaitForPendingFinalizers();
            };
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Error al mostrar el reporte:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}