using DevExpress.XtraScheduler.UI;

namespace Caponeras.App.Views.Mantenimiento
{
    partial class MantenimientoFormView
    {

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoFormView));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            bvPrint = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            appointmentBackstageControl = new DevExpress.XtraScheduler.Design.AppointmentBackstageControl();
            bvtPrint = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            bvbSave = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            bvbSaveAs = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            bvbClose = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            barLabel = new DevExpress.XtraBars.BarEditItem();
            riAppointmentLabel = new RepositoryItemAppointmentLabel();
            barStatus = new DevExpress.XtraBars.BarEditItem();
            riAppointmentStatus = new RepositoryItemAppointmentStatus();
            btnSave = new DevExpress.XtraBars.BarButtonItem();
            btnNext = new DevExpress.XtraBars.BarButtonItem();
            btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            btnTimeZones = new DevExpress.XtraBars.BarButtonItem();
            rpAppointment = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgOptions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            riAppointmentResource = new RepositoryItemAppointmentResource();
            riDuration = new RepositoryItemDuration();
            lblStartTime = new DevExpress.XtraEditors.LabelControl();
            edtStartDate = new DevExpress.XtraEditors.DateEdit();
            tbLocation = new DevExpress.XtraEditors.TextEdit();
            edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            lblEndTime = new DevExpress.XtraEditors.LabelControl();
            edtEndDate = new DevExpress.XtraEditors.DateEdit();
            edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            lblLocation = new DevExpress.XtraEditors.LabelControl();
            panel1 = new DevExpress.XtraEditors.PanelControl();
            edtResource = new AppointmentResourceEdit();
            edtResources = new AppointmentResourcesEdit();
            lblResource = new DevExpress.XtraEditors.LabelControl();
            chkAllDay = new DevExpress.XtraEditors.CheckEdit();
            tbSubject = new DevExpress.XtraEditors.TextEdit();
            lblSubject = new DevExpress.XtraEditors.LabelControl();
            panelMain = new Panel();
            tbDescription = new DevExpress.XtraEditors.MemoEdit();
            panelDescription = new Panel();
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            gridControlVehiculos = new DevExpress.XtraGrid.GridControl();
            vehiculosDtoBindingSource = new BindingSource(components);
            gridViewVehiculos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdvehiculo = new DevExpress.XtraGrid.Columns.GridColumn();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlaca = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            colMarca = new DevExpress.XtraGrid.Columns.GridColumn();
            colModelo = new DevExpress.XtraGrid.Columns.GridColumn();
            tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            tabNavigationPageDatosMantenimiento = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            tabNavigationPageProveedores = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backstageViewControl1).BeginInit();
            backstageViewControl1.SuspendLayout();
            bvPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)riAppointmentLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentResource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.ResourcesCheckedListBoxControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
            tabPane1.SuspendLayout();
            tabNavigationPageDatosMantenimiento.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ApplicationButtonDropDownControl = backstageViewControl1;
            ribbonControl1.AutoSizeItems = true;
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, btnSaveAndClose, btnDelete, barLabel, barStatus, btnSave, btnNext, btnPrevious, btnTimeZones });
            resources.ApplyResources(ribbonControl1, "ribbonControl1");
            ribbonControl1.MaxItemId = 2;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpAppointment });
            ribbonControl1.QuickToolbarItemLinks.Add(btnSave);
            ribbonControl1.QuickToolbarItemLinks.Add(btnPrevious);
            ribbonControl1.QuickToolbarItemLinks.Add(btnNext);
            ribbonControl1.QuickToolbarItemLinks.Add(btnDelete);
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { riAppointmentLabel, riAppointmentResource, riAppointmentStatus, riDuration });
            ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            ribbonControl1.ApplicationButtonClick += ribbonControl1_ApplicationButtonClick;
            // 
            // backstageViewControl1
            // 
            backstageViewControl1.Controls.Add(bvPrint);
            backstageViewControl1.Items.Add(bvtPrint);
            backstageViewControl1.Items.Add(bvbSave);
            backstageViewControl1.Items.Add(bvbSaveAs);
            backstageViewControl1.Items.Add(bvbClose);
            resources.ApplyResources(backstageViewControl1, "backstageViewControl1");
            backstageViewControl1.Name = "backstageViewControl1";
            backstageViewControl1.Office2013StyleOptions.HeaderBackColor = SystemColors.Control;
            backstageViewControl1.OwnerControl = ribbonControl1;
            backstageViewControl1.SelectedTab = bvtPrint;
            backstageViewControl1.SelectedTabIndex = 0;
            backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013;
            // 
            // bvPrint
            // 
            bvPrint.Controls.Add(appointmentBackstageControl);
            resources.ApplyResources(bvPrint, "bvPrint");
            bvPrint.Name = "bvPrint";
            // 
            // appointmentBackstageControl
            // 
            resources.ApplyResources(appointmentBackstageControl, "appointmentBackstageControl");
            appointmentBackstageControl.Name = "appointmentBackstageControl";
            appointmentBackstageControl.PrintClick += schedulerPrint_PrintClick;
            appointmentBackstageControl.PrintOptionsClick += schedulerPrint_PrintOptionsClick;
            // 
            // bvtPrint
            // 
            resources.ApplyResources(bvtPrint, "bvtPrint");
            bvtPrint.ContentControl = bvPrint;
            bvtPrint.Name = "bvtPrint";
            bvtPrint.Selected = true;
            // 
            // bvbSave
            // 
            resources.ApplyResources(bvbSave, "bvbSave");
            bvbSave.Name = "bvbSave";
            bvbSave.ItemClick += bvbSave_ItemClick;
            // 
            // bvbSaveAs
            // 
            resources.ApplyResources(bvbSaveAs, "bvbSaveAs");
            bvbSaveAs.Name = "bvbSaveAs";
            bvbSaveAs.ItemClick += bvbSaveAs_ItemClick;
            // 
            // bvbClose
            // 
            resources.ApplyResources(bvbClose, "bvbClose");
            bvbClose.Name = "bvbClose";
            bvbClose.ItemClick += bvbClose_ItemClick;
            // 
            // btnSaveAndClose
            // 
            resources.ApplyResources(btnSaveAndClose, "btnSaveAndClose");
            btnSaveAndClose.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnSaveAndClose.Id = 3;
            btnSaveAndClose.ImageOptions.Image = (Image)resources.GetObject("btnSaveAndClose.ImageOptions.Image");
            btnSaveAndClose.ImageOptions.LargeImage = (Image)resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage");
            btnSaveAndClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage");
            btnSaveAndClose.Name = "btnSaveAndClose";
            btnSaveAndClose.ItemClick += btnSaveAndClose_ItemClick;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnDelete.Id = 4;
            btnDelete.ImageOptions.Image = (Image)resources.GetObject("btnDelete.ImageOptions.Image");
            btnDelete.ImageOptions.LargeImage = (Image)resources.GetObject("btnDelete.ImageOptions.LargeImage");
            btnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDelete.ImageOptions.SvgImage");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += barButtonDelete_ItemClick;
            // 
            // barLabel
            // 
            resources.ApplyResources(barLabel, "barLabel");
            barLabel.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            barLabel.Edit = riAppointmentLabel;
            barLabel.Id = 8;
            barLabel.Name = "barLabel";
            // 
            // riAppointmentLabel
            // 
            resources.ApplyResources(riAppointmentLabel, "riAppointmentLabel");
            riAppointmentLabel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentLabel.Buttons")) });
            riAppointmentLabel.Name = "riAppointmentLabel";
            // 
            // barStatus
            // 
            resources.ApplyResources(barStatus, "barStatus");
            barStatus.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            barStatus.Edit = riAppointmentStatus;
            barStatus.Id = 11;
            barStatus.Name = "barStatus";
            // 
            // riAppointmentStatus
            // 
            resources.ApplyResources(riAppointmentStatus, "riAppointmentStatus");
            riAppointmentStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentStatus.Buttons")) });
            riAppointmentStatus.Name = "riAppointmentStatus";
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnSave.Id = 1;
            btnSave.ImageOptions.Image = (Image)resources.GetObject("btnSave.ImageOptions.Image");
            btnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSave.ImageOptions.SvgImage");
            btnSave.Name = "btnSave";
            btnSave.ItemClick += btnSave_ItemClick;
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnNext.Id = 3;
            btnNext.ImageOptions.Image = (Image)resources.GetObject("btnNext.ImageOptions.Image");
            btnNext.ImageOptions.LargeImage = (Image)resources.GetObject("btnNext.ImageOptions.LargeImage");
            btnNext.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnNext.ImageOptions.SvgImage");
            btnNext.Name = "btnNext";
            btnNext.ItemClick += btnNext_ItemClick;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(btnPrevious, "btnPrevious");
            btnPrevious.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnPrevious.Id = 4;
            btnPrevious.ImageOptions.Image = (Image)resources.GetObject("btnPrevious.ImageOptions.Image");
            btnPrevious.ImageOptions.LargeImage = (Image)resources.GetObject("btnPrevious.ImageOptions.LargeImage");
            btnPrevious.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnPrevious.ImageOptions.SvgImage");
            btnPrevious.Name = "btnPrevious";
            btnPrevious.ItemClick += btnPrevious_ItemClick;
            // 
            // btnTimeZones
            // 
            btnTimeZones.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(btnTimeZones, "btnTimeZones");
            btnTimeZones.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnTimeZones.Id = 1;
            btnTimeZones.ImageOptions.Image = (Image)resources.GetObject("btnTimeZones.ImageOptions.Image");
            btnTimeZones.ImageOptions.LargeImage = (Image)resources.GetObject("btnTimeZones.ImageOptions.LargeImage");
            btnTimeZones.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnTimeZones.ImageOptions.SvgImage");
            btnTimeZones.Name = "btnTimeZones";
            btnTimeZones.ItemClick += btnTimeZones_ItemClick;
            // 
            // rpAppointment
            // 
            rpAppointment.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgActions, rpgOptions });
            rpAppointment.Name = "rpAppointment";
            resources.ApplyResources(rpAppointment, "rpAppointment");
            // 
            // rpgActions
            // 
            rpgActions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            rpgActions.ItemLinks.Add(btnSaveAndClose);
            rpgActions.ItemLinks.Add(btnDelete);
            rpgActions.Name = "rpgActions";
            resources.ApplyResources(rpgActions, "rpgActions");
            // 
            // rpgOptions
            // 
            rpgOptions.AllowTextClipping = false;
            rpgOptions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            rpgOptions.ItemLinks.Add(barLabel);
            rpgOptions.ItemLinks.Add(barStatus);
            rpgOptions.Name = "rpgOptions";
            resources.ApplyResources(rpgOptions, "rpgOptions");
            // 
            // riAppointmentResource
            // 
            resources.ApplyResources(riAppointmentResource, "riAppointmentResource");
            riAppointmentResource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentResource.Buttons")) });
            riAppointmentResource.Name = "riAppointmentResource";
            // 
            // riDuration
            // 
            resources.ApplyResources(riDuration, "riDuration");
            riDuration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riDuration.Buttons")) });
            riDuration.Name = "riDuration";
            riDuration.ShowEmptyItem = true;
            // 
            // lblStartTime
            // 
            resources.ApplyResources(lblStartTime, "lblStartTime");
            lblStartTime.Name = "lblStartTime";
            // 
            // edtStartDate
            // 
            tablePanel1.SetColumn(edtStartDate, 2);
            resources.ApplyResources(edtStartDate, "edtStartDate");
            edtStartDate.Name = "edtStartDate";
            edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtStartDate.Properties.Buttons")) });
            edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartDate.Properties.MaxDate = new DateTime(4000, 1, 1, 0, 0, 0, 0);
            tablePanel1.SetRow(edtStartDate, 3);
            // 
            // tbLocation
            // 
            tablePanel1.SetColumn(tbLocation, 2);
            tablePanel1.SetColumnSpan(tbLocation, 2);
            resources.ApplyResources(tbLocation, "tbLocation");
            tbLocation.Name = "tbLocation";
            tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            tablePanel1.SetRow(tbLocation, 1);
            // 
            // edtStartTime
            // 
            tablePanel1.SetColumn(edtStartTime, 3);
            resources.ApplyResources(edtStartTime, "edtStartTime");
            edtStartTime.Name = "edtStartTime";
            edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartTime.Properties.Mask.EditMask = resources.GetString("edtStartTime.Properties.Mask.EditMask");
            tablePanel1.SetRow(edtStartTime, 3);
            // 
            // lblEndTime
            // 
            resources.ApplyResources(lblEndTime, "lblEndTime");
            tablePanel1.SetColumn(lblEndTime, 0);
            lblEndTime.Name = "lblEndTime";
            tablePanel1.SetRow(lblEndTime, 4);
            // 
            // edtEndDate
            // 
            tablePanel1.SetColumn(edtEndDate, 2);
            resources.ApplyResources(edtEndDate, "edtEndDate");
            edtEndDate.Name = "edtEndDate";
            edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtEndDate.Properties.Buttons")) });
            edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndDate.Properties.MaxDate = new DateTime(4000, 1, 1, 0, 0, 0, 0);
            tablePanel1.SetRow(edtEndDate, 4);
            // 
            // edtEndTime
            // 
            tablePanel1.SetColumn(edtEndTime, 3);
            resources.ApplyResources(edtEndTime, "edtEndTime");
            edtEndTime.Name = "edtEndTime";
            edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndTime.Properties.Mask.EditMask = resources.GetString("edtEndTime.Properties.Mask.EditMask");
            tablePanel1.SetRow(edtEndTime, 4);
            // 
            // lblLocation
            // 
            resources.ApplyResources(lblLocation, "lblLocation");
            tablePanel1.SetColumn(lblLocation, 0);
            lblLocation.Name = "lblLocation";
            tablePanel1.SetRow(lblLocation, 1);
            // 
            // panel1
            // 
            panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            tablePanel1.SetColumn(panel1, 6);
            panel1.Controls.Add(edtResource);
            panel1.Controls.Add(edtResources);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            tablePanel1.SetRow(panel1, 1);
            // 
            // edtResource
            // 
            resources.ApplyResources(edtResource, "edtResource");
            edtResource.Name = "edtResource";
            edtResource.Properties.AccessibleRole = AccessibleRole.ComboBox;
            edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtResource.Properties.Buttons")) });
            // 
            // edtResources
            // 
            resources.ApplyResources(edtResources, "edtResources");
            edtResources.Name = "edtResources";
            edtResources.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtResources.Properties.Buttons")) });
            // 
            // 
            // 
            edtResources.ResourcesCheckedListBoxControl.Location = (Point)resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location");
            edtResources.ResourcesCheckedListBoxControl.Name = "";
            edtResources.ResourcesCheckedListBoxControl.TabIndex = (int)resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex");
            // 
            // lblResource
            // 
            resources.ApplyResources(lblResource, "lblResource");
            tablePanel1.SetColumn(lblResource, 4);
            lblResource.Name = "lblResource";
            tablePanel1.SetRow(lblResource, 1);
            // 
            // chkAllDay
            // 
            tablePanel1.SetColumn(chkAllDay, 4);
            tablePanel1.SetColumnSpan(chkAllDay, 3);
            resources.ApplyResources(chkAllDay, "chkAllDay");
            chkAllDay.Name = "chkAllDay";
            chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName");
            chkAllDay.Properties.AccessibleRole = AccessibleRole.CheckButton;
            chkAllDay.Properties.AutoWidth = true;
            chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption");
            tablePanel1.SetRow(chkAllDay, 3);
            // 
            // tbSubject
            // 
            tablePanel1.SetColumn(tbSubject, 2);
            tablePanel1.SetColumnSpan(tbSubject, 6);
            resources.ApplyResources(tbSubject, "tbSubject");
            tbSubject.Name = "tbSubject";
            tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            tablePanel1.SetRow(tbSubject, 0);
            // 
            // lblSubject
            // 
            resources.ApplyResources(lblSubject, "lblSubject");
            tablePanel1.SetColumn(lblSubject, 0);
            lblSubject.Name = "lblSubject";
            tablePanel1.SetRow(lblSubject, 0);
            // 
            // panelMain
            // 
            resources.ApplyResources(panelMain, "panelMain");
            panelMain.Name = "panelMain";
            // 
            // tbDescription
            // 
            tablePanel1.SetColumn(tbDescription, 0);
            tablePanel1.SetColumnSpan(tbDescription, 8);
            resources.ApplyResources(tbDescription, "tbDescription");
            tbDescription.Name = "tbDescription";
            tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            tbDescription.Properties.AccessibleRole = AccessibleRole.Client;
            tablePanel1.SetRow(tbDescription, 7);
            // 
            // panelDescription
            // 
            resources.ApplyResources(panelDescription, "panelDescription");
            panelDescription.Name = "panelDescription";
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F) });
            tablePanel1.Controls.Add(gridControlVehiculos);
            tablePanel1.Controls.Add(tbDescription);
            tablePanel1.Controls.Add(panel1);
            tablePanel1.Controls.Add(lblSubject);
            tablePanel1.Controls.Add(lblResource);
            tablePanel1.Controls.Add(lblEndTime);
            tablePanel1.Controls.Add(chkAllDay);
            tablePanel1.Controls.Add(edtEndDate);
            tablePanel1.Controls.Add(lblStartTime);
            tablePanel1.Controls.Add(edtEndTime);
            tablePanel1.Controls.Add(tbSubject);
            tablePanel1.Controls.Add(lblLocation);
            tablePanel1.Controls.Add(edtStartDate);
            tablePanel1.Controls.Add(tbLocation);
            tablePanel1.Controls.Add(edtStartTime);
            resources.ApplyResources(tablePanel1, "tablePanel1");
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 16F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F) });
            // 
            // gridControlVehiculos
            // 
            tablePanel1.SetColumn(gridControlVehiculos, 0);
            tablePanel1.SetColumnSpan(gridControlVehiculos, 8);
            gridControlVehiculos.DataSource = vehiculosDtoBindingSource;
            resources.ApplyResources(gridControlVehiculos, "gridControlVehiculos");
            gridControlVehiculos.MainView = gridViewVehiculos;
            gridControlVehiculos.MenuManager = ribbonControl1;
            gridControlVehiculos.Name = "gridControlVehiculos";
            tablePanel1.SetRow(gridControlVehiculos, 8);
            gridControlVehiculos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewVehiculos });
            // 
            // vehiculosDtoBindingSource
            // 
            vehiculosDtoBindingSource.DataSource = typeof(Dto.VehiculosDto);
            // 
            // gridViewVehiculos
            // 
            gridViewVehiculos.Appearance.FocusedRow.BackColor = Color.FromArgb(192, 64, 0);
            gridViewVehiculos.Appearance.FocusedRow.BorderColor = Color.FromArgb(192, 0, 0);
            gridViewVehiculos.Appearance.FocusedRow.ForeColor = Color.White;
            gridViewVehiculos.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewVehiculos.Appearance.FocusedRow.Options.UseBorderColor = true;
            gridViewVehiculos.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewVehiculos.Appearance.SelectedRow.BackColor = Color.FromArgb(192, 64, 0);
            gridViewVehiculos.Appearance.SelectedRow.Options.UseBackColor = true;
            gridViewVehiculos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdvehiculo, colCodigo, colPlaca, colDescripcion, colTipo, colMarca, colModelo });
            gridViewVehiculos.GridControl = gridControlVehiculos;
            gridViewVehiculos.Name = "gridViewVehiculos";
            gridViewVehiculos.OptionsBehavior.Editable = false;
            // 
            // colIdvehiculo
            // 
            colIdvehiculo.FieldName = "Idvehiculo";
            colIdvehiculo.Name = "colIdvehiculo";
            // 
            // colCodigo
            // 
            colCodigo.FieldName = "Codigo";
            colCodigo.Name = "colCodigo";
            resources.ApplyResources(colCodigo, "colCodigo");
            // 
            // colPlaca
            // 
            colPlaca.FieldName = "Placa";
            colPlaca.Name = "colPlaca";
            resources.ApplyResources(colPlaca, "colPlaca");
            // 
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            resources.ApplyResources(colDescripcion, "colDescripcion");
            // 
            // colTipo
            // 
            colTipo.FieldName = "Tipo";
            colTipo.Name = "colTipo";
            resources.ApplyResources(colTipo, "colTipo");
            // 
            // colMarca
            // 
            colMarca.FieldName = "Marca";
            colMarca.Name = "colMarca";
            resources.ApplyResources(colMarca, "colMarca");
            // 
            // colModelo
            // 
            colModelo.FieldName = "Modelo";
            colModelo.Name = "colModelo";
            resources.ApplyResources(colModelo, "colModelo");
            // 
            // tabPane1
            // 
            tabPane1.Controls.Add(tabNavigationPageDatosMantenimiento);
            tabPane1.Controls.Add(tabNavigationPageProveedores);
            resources.ApplyResources(tabPane1, "tabPane1");
            tabPane1.Name = "tabPane1";
            tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { tabNavigationPageDatosMantenimiento, tabNavigationPageProveedores });
            tabPane1.RegularSize = new Size(755, 370);
            tabPane1.SelectedPage = tabNavigationPageDatosMantenimiento;
            // 
            // tabNavigationPageDatosMantenimiento
            // 
            resources.ApplyResources(tabNavigationPageDatosMantenimiento, "tabNavigationPageDatosMantenimiento");
            tabNavigationPageDatosMantenimiento.Controls.Add(tablePanel1);
            tabNavigationPageDatosMantenimiento.Name = "tabNavigationPageDatosMantenimiento";
            // 
            // tabNavigationPageProveedores
            // 
            resources.ApplyResources(tabNavigationPageProveedores, "tabNavigationPageProveedores");
            tabNavigationPageProveedores.Name = "tabNavigationPageProveedores";
            // 
            // MantenimientoFormView
            // 
            AccessibleRole = AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabPane1);
            Controls.Add(backstageViewControl1);
            Controls.Add(ribbonControl1);
            Name = "MantenimientoFormView";
            Ribbon = ribbonControl1;
            ShowInTaskbar = false;
            Load += MantenimientoFormView_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)backstageViewControl1).EndInit();
            backstageViewControl1.ResumeLayout(false);
            bvPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)riAppointmentLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentResource).EndInit();
            ((System.ComponentModel.ISupportInitialize)riDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.ResourcesCheckedListBoxControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
            tabPane1.ResumeLayout(false);
            tabNavigationPageDatosMantenimiento.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAppointment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOptions;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarEditItem barLabel;
        private RepositoryItemAppointmentLabel riAppointmentLabel;
        private RepositoryItemAppointmentResource riAppointmentResource;
        private DevExpress.XtraBars.BarEditItem barStatus;
        private RepositoryItemAppointmentStatus riAppointmentStatus;
        private RepositoryItemDuration riDuration;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.TimeEdit edtStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TimeEdit edtEndTime;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.PanelControl panel1;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected AppointmentResourceEdit edtResource;
        protected AppointmentResourcesEdit edtResources;
        protected DevExpress.XtraEditors.CheckEdit chkAllDay;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected DevExpress.XtraEditors.LabelControl lblSubject;
        private System.Windows.Forms.Panel panelMain;
        protected DevExpress.XtraEditors.MemoEdit tbDescription;
        private System.Windows.Forms.Panel panelDescription;

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSave;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSaveAs;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbClose;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnTimeZones;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl bvPrint;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtPrint;
        private DevExpress.XtraScheduler.Design.AppointmentBackstageControl appointmentBackstageControl;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControlVehiculos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVehiculos;
        private BindingSource vehiculosDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaca;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colMarca;
        private DevExpress.XtraGrid.Columns.GridColumn colModelo;
        private DevExpress.XtraGrid.Columns.GridColumn colIdvehiculo;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageDatosMantenimiento;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageProveedores;
    }
}