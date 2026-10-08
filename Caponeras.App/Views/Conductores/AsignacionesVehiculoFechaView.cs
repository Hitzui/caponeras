using Caponeras.App.ViewModels.Conductores;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.Dto;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

public partial class AsignacionesVehiculoFechaView : DevExpress.XtraEditors.XtraForm
{
    private AsignacionesVehiculoFechaViewModel _viewModel;
    private SvgImage _trashSvg;
    private SvgPalette _trashPalette;

    public AsignacionesVehiculoFechaView(AsignacionesVehiculoFechaViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        txtFecha.DateTime = DateTime.Now;
        _trashPalette = new SvgPalette();
        _trashSvg = SvgImage.FromFile("Resources/Images/trash.svg");
        ConfigurarBotonQuitarAsignacion();
    }

    private async void btnFiltrar_Click(object? sender, EventArgs eventArgs)
    {
        try
        {
            if (txtFecha.EditValue is null)
            {
                txtFecha.ErrorText = "Debe seleccionar una fecha.";
                return;
            }

            await _viewModel.LoadList(txtFecha.DateTime);
            await _viewModel.LoadVehiculos();
            await _viewModel.LoadZonas();
            conductorVehiculoDtoBindingSource.DataSource = _viewModel.ConductorVehiculoBindingList;
            vehiculosDtoBindingSource.DataSource = _viewModel.VehiculosBindingList;
            zonasBindingSource.DataSource = _viewModel.ZonasBindingList;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            gridViewAsignaciones.CloseEditor();
            gridViewAsignaciones.UpdateCurrentRow();

            var filas = _viewModel.ConductorVehiculoBindingList;

            var filasParaGuardar = filas
                .Where(x =>
                    x.IdVehiculo.HasValue &&
                    x.IdVehiculo > 0 &&
                    x.IdZona.HasValue &&
                    x.IdZona > 0)
                .ToList();

            if (filasParaGuardar.Count == 0)
            {
                XtraMessageBox.Show(
                    "No hay conductores con vehículo y zona asignados para guardar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Validar vehículos repetidos dentro del Grid
            if (!_viewModel.ValidarVehiculosDuplicados(filasParaGuardar)) return;

            await _viewModel.AsignarVehiculosPorDiaAsync(
                txtFecha.DateTime,
                filasParaGuardar);
        }
        catch (Exception ex)
        {
            await XtraMessageBox.ShowAsync(
                $"Error al guardar las asignaciones. {ex.Message}");
        }
    }

    private void ConfigurarBotonQuitarAsignacion()
    {
        _trashSvg = SvgImage.FromFile(
            "Resources/Images/trash.svg");

        _trashPalette = new SvgPalette();

        _trashPalette.Colors.Add(new SvgColor("st0", Color.FromArgb(220, 53, 69)));

        colAcciones.Caption = "Acciones";
        colAcciones.Width = 70;

        colAcciones.ColumnEdit = null;
        colAcciones.OptionsColumn.AllowEdit = false;
        colAcciones.OptionsColumn.ReadOnly = true;

        gridViewAsignaciones.CustomDrawCell += GridViewAsignaciones_CustomDrawCell;

        gridViewAsignaciones.RowCellClick += GridViewAsignaciones_RowCellClick;
    }

    private void GridViewAsignaciones_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
    {
        if (e.Column != colAcciones)
            return;

        e.Handled = true;

        e.Appearance.DrawBackground(e.Cache, e.Bounds);

        var fila = gridViewAsignaciones
            .GetRow(e.RowHandle) as ConductorVehiculoDto;

        if (fila?.IdVehiculo is null or <= 0)
            return;

        if (fila.IdZona is null or <= 0)
            return;

        const int size = 18;

        var x = e.Bounds.X + (e.Bounds.Width - size) / 2;
        var y = e.Bounds.Y + (e.Bounds.Height - size) / 2;

        var rect = new Rectangle(
            x,
            y,
            size,
            size);

        e.Cache.DrawSvgImage(
            _trashSvg,
            rect,
            _trashPalette);
    }

    private void GridViewAsignaciones_RowCellClick(
        object sender,
        RowCellClickEventArgs e)
    {
        if (e.Column != colAcciones)
            return;

        if (e.RowHandle < 0)
            return;

        var fila = gridViewAsignaciones
            .GetRow(e.RowHandle) as ConductorVehiculoDto;

        if (fila == null)
            return;

        BtnQuitarAsignacion(fila);
    }

    private async void BtnQuitarAsignacion(
        ConductorVehiculoDto fila)
    {
        try
        {
            if (txtFecha.EditValue is null)
            {
                txtFecha.ErrorText = "Debe indicar una fecha para continuar";
                return;
            }

            if (fila.IdVehiculo is null or <= 0)
                return;

            if (fila.IdZona is null or <= 0)
                return;

            var respuesta = XtraMessageBox.Show(
                $"¿Desea quitar la asignación del vehículo " +
                $"{fila.Placa} al conductor {fila.Nombre}?",
                "Quitar asignación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            // Aquí posteriormente:
            await _viewModel.QuitarAsignacionVehiculoPorDiaAsync(txtFecha.DateTime, fila);
            btnFiltrar_Click(null, EventArgs.Empty);
        }
        catch (Exception e)
        {
            await XtraMessageBox.ShowAsync(e.Message);
        }
    }
}