using Caponeras.App.Helpers;
using DevExpress.Mvvm;
using DevExpress.Utils;
using DevExpress.Utils.Html;
using DevExpress.XtraBars.Alerter;
using System.IO;

namespace Caponeras.App.ViewModels;

public class BaseViewModel : ViewModelBase
{
    private object? _query;

    public object? Query
    {
        get => _query;
        set => SetProperty(ref _query, value, nameof(Query));
    }

    public void GetMessageAlert(TypeAlert type, string title, string body, Form form)
    {
        var templateHtml = new HtmlTemplate();
        templateHtml.Template = Load("Alert.html");
        templateHtml.Styles = string.Empty;
        Image? image;
        var svgTypeIcon = new SvgImageCollection
        {
            { "info", Properties.Resources.info },
            { "success", Properties.Resources.success },
            { "warning", Properties.Resources.warning },
            { "error", Properties.Resources.error },
        };
        switch (type)
        {
            case TypeAlert.Informacion:
                image = svgTypeIcon.GetImage("info");
                templateHtml.Styles = Load("AlertInfo.css");
                break;
            case TypeAlert.Success:
                image = svgTypeIcon.GetImage("success");
                templateHtml.Styles = Load("AlertSuccess.css");
                break;
            case TypeAlert.Warning:
                image = svgTypeIcon.GetImage("warning");
                templateHtml.Styles = Load("AlertWarning.css");
                break;
            case TypeAlert.Error:
                image = svgTypeIcon.GetImage("error");
                templateHtml.Styles = Load("AlertError.css");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        var svgImageItemCollection = new SvgImageCollection
        {
            { "message_close", Properties.Resources.message_close },
            { "message_icon", Properties.Resources.Glyph_Message }
        };
        svgImageItemCollection.ImageSize = new Size(16, 16);
        var alert = new AlertControl
        {
            AutoHeight = true,
            AutoFormDelay = 2000,
            HtmlImages = svgImageItemCollection
        };
        alert.HtmlTemplates.Add(templateHtml);
        alert.HtmlElementMouseClick += AlertControl1_HtmlElementMouseClick;
        alert.Show(form, title, body, "", image);
    }

    private static string Load(string fileName)
    {
        var directoryPath = Application.StartupPath;
        var filePath = $"{directoryPath}/Resources/Styles/{fileName}"; //Path.Combine(directoryPath, "Libraries/Style", fileName);
        return File.Exists(filePath) ? File.ReadAllText(filePath) : "";
    }
    private void AlertControl1_HtmlElementMouseClick(object sender, AlertHtmlElementMouseEventArgs e)
    {
        if (e.ElementId == "closeButton" || e.ParentHasId("closeButton") ||
            e.ElementId == "okButton" || e.ParentHasId("okButton"))
            e.HtmlPopup.Close();
        else
            e.HtmlPopup.Pinned = !e.HtmlPopup.Pinned;
    }
}