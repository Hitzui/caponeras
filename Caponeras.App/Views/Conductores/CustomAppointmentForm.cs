using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using System.ComponentModel;
using System.Diagnostics;
using Caponeras.App.Dto;

namespace Caponeras.App.Views.Conductores
{
    public partial class CustomAppointmentForm : XtraForm, IDXManagerPopupMenu
    {
        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        private SchedulerControl control;
        SvgImage recurringSvgImage;
        SvgImage normalSvgImage;
        private AppointmentFormController controller;
        IDXMenuManager menuManager;
        private Appointment? _appointment;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }

        public CustomAppointmentForm(SchedulerControl control, Appointment apt)
            : this(control, apt, false)
        {
        }

        public CustomAppointmentForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage");
            Guard.ArgumentNotNull(apt, "apt");

            this.openRecurrenceForm = openRecurrenceForm;
            _appointment = apt;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.control = control;
            this.storage = control.DataStorage;

            SubscribeControllerEvents(Controller);
            SubscribeEditorsEvents();
        }

        protected override FormShowMode ShowMode
        {
            get { return FormShowMode.AfterInitialization; }
        }

        [Browsable(false)]
        public IDXMenuManager MenuManager
        {
            get { return this.menuManager; }
            private set { this.menuManager = value; }
        }

        protected internal AppointmentFormController Controller
        {
            get { return this.controller; }
        }

        protected internal SchedulerControl Control
        {
            get { return this.control; }
        }

        protected internal ISchedulerStorage Storage
        {
            get { return this.storage; }
        }

        protected internal bool IsNewAppointment
        {
            get { return this.controller != null ? this.controller.IsNewAppointment : true; }
        }

        protected internal SvgImage RecurringSvgImage
        {
            get { return this.recurringSvgImage; }
        }

        protected internal SvgImage NormalSvgImage
        {
            get { return this.normalSvgImage; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SvgImage SvgImage
        {
            get { return IconOptions.SvgImage; }
            set { IconOptions.SvgImage = value; }
        }


        [DXDescription("DevExpress.XtraScheduler.UI.AppointmentForm,ReadOnly")]
        [DXCategory(CategoryName.Behavior)]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }

        public virtual void LoadFormData(Appointment appointment)
        {
            //do nothing
        }

        public virtual bool SaveFormData(Appointment appointment)
        {
            this._appointment.End = edtEndDate.DateTime;
            this._appointment.Start = edtStartDate.DateTime;
            return true;
        }

        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }

        protected virtual void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(this.tbSubject, "Text", "Subject");
            BindProperties(this.tbLocation, "Text", "Location");
            BindProperties(this.tbDescription, "Text", "Description");
            BindProperties(this.edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(this.edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(this.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindToBoolPropertyAndInvert(this.btnOk, "Enabled", "ReadOnly");
        }

        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("SvgImage", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }

        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }

        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            var type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringSvgImage;
            else
                e.Value = NormalSvgImage;
        }

        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty,
            DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }

        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty,
            ConvertEventHandler objectToStringConverter)
        {
            var binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }

        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }

        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new AppointmentFormController(control, apt);
        }

        void SubscribeEditorsEvents()
        {
        }

        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }

        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }

        protected virtual void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }

            this.btnOk.Enabled = !Controller.ReadOnly;
        }

        List<Control> GetAllControls(Control rootControl)
        {
            var result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }

            return result;
        }

        protected internal virtual void LoadIcons()
        {
            var asm = typeof(ResourceImageLoader).Assembly;
            this.recurringSvgImage =
                ResourceImageHelper.CreateSvgImageFromResources(SchedulerSvgImageNames.NewRecurringAppointment, asm);
            this.normalSvgImage =
                ResourceImageHelper.CreateSvgImageFromResources(SchedulerSvgImageNames.NewAppointment, asm);
        }

        protected internal virtual void SubscribeControlsEvents()
        {
            this.edtStartDate.InvalidValue += OnEdtStartDateInvalidValue;
        }

        void OnBtnOkClick(object sender, EventArgs e)
        {
            OnOkButton();
        }

        protected internal virtual void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }

        protected internal virtual void OnOkButton()
        {
            if (!ValidateDateAndTime())
                return;
            _appointment.Start = edtStartDate.DateTime.Date;
            _appointment.End = edtEndDate.DateTime.Date;

            DialogResult = DialogResult.OK;
        }

        private bool ValidateDateAndTime()
        {
            this.edtEndDate.DoValidate();
            this.edtStartDate.DoValidate();

            return String.IsNullOrEmpty(this.edtEndDate.ErrorText) && String.IsNullOrEmpty(this.edtStartDate.ErrorText);
        }

        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons,
            MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }

        private void CustomAppointmentForm_Load(object sender, EventArgs e)
        {
            this.controller = CreateController(control, _appointment!);
            txtZona.Text = ((ZonasDto)_appointment.LabelKey).Nombre;
            SubscribeControlsEvents();
            DataBindings.Add("Text", Controller, "Caption");
            LoadFormData(Controller.EditedAppointmentCopy);
            LoadIcons();
            BindControllerToControls();
        }
    }
}