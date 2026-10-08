using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Conductores;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NLog;
using System;
using System.Linq;

namespace Caponeras.App.Views.Conductores;

public partial class ConductoresView : XtraForm
{
    private readonly ConductoresViewModel _viewModel;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public ConductoresView(ConductoresViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
    }

    private async void ConductoresView_Load(object sender, EventArgs e)
    {
        try
        {
            await _viewModel.LoadAsync();
            conductoresDtoBindingSource.DataSource = _viewModel.Conductores;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error al cargar conductores.");
        }
    }

    private void gridViewConductores_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }
    }

    private void gridViewConductores_FocusedRowChanged(object sender,
        DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        if (gridViewConductores.GetRow(e.FocusedRowHandle) is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }
    }

    private void gridViewConductores_PopupMenuShowing(object sender,
        DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
        if (e.MenuType != GridMenuType.Row) return;
        e.ShowCustomMenu(popupMenu1);
    }

    private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        _viewModel.SetSelectedItem(new ConductoresDto());
        _viewModel.ShowForm();
    }

    private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }

        _viewModel.ShowForm();
    }

    private async void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is not ConductoresDto conductor)
        {
            XtraMessageBox.Show("Seleccione un cadete para inactivarlo.", "Inactivar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _viewModel.SetSelectedItem(conductor);
        var result = XtraMessageBox.Show(
            $"¿Desea cambiar el estado de {conductor.Nombre} a INACTIVO? Se conservarán sus cuotas, asignaciones y demás registros.",
            "Inactivar cadete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
        {
            return;
        }

        await _viewModel.Delete();
    }

    private void barButtonItemLicencia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }

        _viewModel.ShowFormLicencia();
    }

    private void barButtonItemIdentificacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }

        _viewModel.ShowFormIdentificacion();
    }

    private void barButtonItemInfoReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (gridViewConductores.GetFocusedRow() is ConductoresDto conductor)
        {
            _viewModel.SetSelectedItem(conductor);
        }

        _viewModel.ShowReporteCadete();
    }
}
