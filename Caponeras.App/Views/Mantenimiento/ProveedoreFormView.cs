using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Mantenimiento;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Mantenimiento
{
    public sealed partial class ProveedoreFormView : DevExpress.XtraEditors.XtraUserControl
    {
        private ProveedoreFormViewModel _viewModel;

        public ProveedoreFormView(ProveedoreFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
            dragDropEvents2.DragOver += DragDropEvents1_DragOver;
            dragDropEvents2.DragDrop += DragDropEvents1_DragDrop;
        }

        private void DragDropEvents1_DragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {
            if (e.Target is not GridView || e.Source is not GridView)
                return;

            var rowHandled = (int[])e.Data;

            foreach (var k in rowHandled)
            {
                if (gridViewProveedores.GetRow(k) is not ProveedoresDto proveedoresDto)
                    continue;

                // Validar si ya existe
                var existe = selectedProveedoresDtoBindingSource
                    .Cast<ProveedoresDto>()
                    .Any(x => x.IdProveedor == proveedoresDto.IdProveedor);

                if (!existe)
                {
                    selectedProveedoresDtoBindingSource.Add(proveedoresDto);
                }
            }
        }

        private void DragDropEvents1_DragOver(object sender, DevExpress.Utils.DragDrop.DragOverEventArgs e)
        {
            e.Default();
            Cursor.Current = Cursors.Default;
        }

        private async void ProveedoreFormView_Load(object sender, EventArgs e)
        {
            try
            {
                splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
                await _viewModel.LoadData();
                await _viewModel.LoadDataSelectedProveedores();
                selectedProveedoresDtoBindingSource.DataSource = _viewModel.SelectedProveedoresBindingList;
                proveedoresDtoBindingSource.DataSource = _viewModel.ProveedoresBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                var validarMonto =
                    _viewModel.SelectedProveedoresBindingList.Any(proveedoresDto => proveedoresDto.MontoManoObra <= 0);

                if (validarMonto)
                {
                    XtraMessageBox.Show(
                        "Mano de obra debe ser mayor de 0",
                        "Mano de obra",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var proveedoresSeleccionados = (_viewModel.SelectedProveedoresBindingList).ToList();
                await _viewModel.Save(proveedoresSeleccionados);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void gridViewSelectedProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            var handleRow = gridViewSelectedProveedores.FocusedRowHandle;
            if (handleRow < 0)
            {
                return;
            }

            selectedProveedoresDtoBindingSource.RemoveAt(handleRow);
        }
    }
}
