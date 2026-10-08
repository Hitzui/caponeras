using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Mantenimiento;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Mantenimiento
{
    public partial class RepuestosFormView : XtraForm
    {
        private RepuestosFormViewModel _viewModel;
        private INavigationService _navigationService;
        private Appointment? _appointment;

        public RepuestosFormView(RepuestosFormViewModel viewModel, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            _appointment = _navigationService.Query as Appointment;
            InitializeComponent();
            dragDropEventsRepuestos.DragOver += DragDropEventsRepuestos_DragOver;
            dragDropEventsRepuestos.DragDrop += DragDropEventsProductos_DragDrop;
        }

        private async void RepuestosFormView_Load(object sender, EventArgs e)
        {
            _viewModel.Load();
            await LoadProductos();
            await LoadListaRepuestos();
            if (_appointment is not null)
            {
                lblTitulo.Text = @$"Repuestos: {_appointment.Subject}";
            }
        }

        private async Task LoadProductos()
        {
            await _viewModel.LoadProductos();
            productoDtoBindingSource.DataSource = _viewModel.ProductosBindingList;
        }

        private async Task LoadListaRepuestos()
        {
            if (_appointment is null)
            {
                mantenimientoRepuestoDtoBindingSource.DataSource = _viewModel.RepuestosBindingList;
                return;
            }

            await _viewModel.LoadRepuestos((int)_appointment.Id);
            mantenimientoRepuestoDtoBindingSource.DataSource = _viewModel.RepuestosBindingList;
        }

        private void DragDropEventsRepuestos_DragOver(object sender, DragOverEventArgs e)
        {
            e.Default();
            Cursor.Current = Cursors.Default;
        }

        private async void DragDropEventsProductos_DragDrop(object sender, DragDropEventArgs e)
        {
            try
            {
                if (e.Target is not GridView || e.Source is not GridView)
                    return;

                var rowHandled = (int[])e.Data;

                foreach (var k in rowHandled)
                {
                    if (gridViewProductos.GetRow(k) is not ProductoDto row)
                        continue;

                    // Los productos externos no consumen existencias de la bodega.
                    if (row.Inventariable && row.StockActual <= 0)
                    {
                        _viewModel.GetMessageAlert(
                            TypeAlert.Warning,
                            "Stock insuficiente",
                            $"El producto '{row.Nombre}' no tiene stock disponible.",
                            _navigationService.MainView
                        );
                        continue;
                    }

                    // VALIDACIÓN 2: No duplicados
                    var yaExiste = _viewModel.RepuestosBindingList
                        .Any(x => x.IdProducto == row.IdProducto);

                    if (yaExiste)
                    {
                        _viewModel.GetMessageAlert(
                            TypeAlert.Warning,
                            "Producto duplicado",
                            $"El producto '{row.Nombre}' ya fue agregado.",
                            _navigationService.MainView
                        );
                        continue;
                    }

                    var stockActual = row.StockActual;
                    var observaciones = string.Empty;
                    if (!row.Inventariable)
                    {
                        var formProductoNoInventariable = _navigationService.ShowDialog<ProductoExtraInventariableFormView>(
                            query: (row, (int)_appointment.Id));
                        formProductoNoInventariable.SetProducto(row);
                        var result = formProductoNoInventariable.DialogResult;
                        if (result != DialogResult.OK) continue;
                        stockActual = formProductoNoInventariable.Cantidad;
                        observaciones = $"Proveedor externo #{formProductoNoInventariable.IdProveedorSeleccionado}; " +
                                        $"costo unitario {formProductoNoInventariable.PrecioUnitarioSeleccionado.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                    }

                    // Agregar con cantidad inicial válida
                    var repuesto = new MantenimientoRepuestoDto
                    {
                        IdMantenimientoRepuestos = 0,
                        IdMantenimiento = (int)_appointment.Id,
                        IdProducto = row.IdProducto,
                        Cantidad = stockActual,
                        IdUnidadMedida = row.IdUnidadMedida ?? 0,
                        Observaciones = observaciones,
                        ProductoNombre = row.Nombre,
                        UnidadMedidaNombre = "",
                        UnidadMedidaSimbolo = "",
                        StockDisponible = stockActual
                    };

                    _viewModel.RepuestosBindingList.Add(repuesto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void gridViewRepuestos_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;

            if (view.FocusedColumn.FieldName != "Cantidad")
                return;

            var row = view.GetFocusedRow() as MantenimientoRepuestoDto;

            if (row == null)
                return;

            decimal nuevaCantidad;

            if (!decimal.TryParse(e.Value?.ToString(), out nuevaCantidad))
            {
                e.Valid = false;
                e.ErrorText = "Cantidad inválida.";
                return;
            }

            if (nuevaCantidad > row.StockDisponible)
            {
                e.Valid = false;
                e.ErrorText = $"La cantidad no puede ser mayor al stock disponible ({row.StockDisponible}).";
            }

            if (nuevaCantidad <= 0)
            {
                e.Valid = false;
                e.ErrorText = "La cantidad debe ser mayor que cero.";
            }
        }

        private async void btnAplicar_Click(object sender, EventArgs e)
        {
            if (_appointment is null)
            {
                return;
            }

            btnAplicar.Enabled = false;
            try
            {
                await _viewModel.Save(_appointment);
            }
            finally
            {
                btnAplicar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewRepuestos_PopupMenuShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridViewRepuestos.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.Row)
            {
                e.ShowCustomMenu(popupMenu1);
            }
        }

        private void barButtonItemDeleteRepuesto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRow();
        }

        private void gridViewRepuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteRow();
            }
        }

        private void DeleteRow()
        {
            var index = gridViewRepuestos.GetDataSourceRowIndex(gridViewRepuestos.FocusedRowHandle);
            if (index >= 0 && index < _viewModel.RepuestosBindingList.Count)
                _viewModel.RepuestosBindingList.RemoveAt(index);
        }

        private void gridViewRepuestos_ShowingEditor(object sender, CancelEventArgs e)
        {
            // Validar que sea la columna Cantidad
            if (gridViewRepuestos.FocusedColumn != colCantidad) return;
            if (gridViewRepuestos.GetFocusedRow() is not MantenimientoRepuestoDto row) return;
            var producto = _viewModel.ProductosBindingList.FirstOrDefault(p => p.IdProducto == row.IdProducto);
            if(producto is not null)
                e.Cancel = !producto.Inventariable; // 🔒 bloquea la edición
        }
    }
}
