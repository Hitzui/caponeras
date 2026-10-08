namespace Caponeras.App.Views.Conductores
{
    partial class CustomAppointmentForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAppointmentForm));
            lblSubject = new DevExpress.XtraEditors.LabelControl();
            lblLocation = new DevExpress.XtraEditors.LabelControl();
            tbSubject = new DevExpress.XtraEditors.TextEdit();
            lblStartTime = new DevExpress.XtraEditors.LabelControl();
            lblEndTime = new DevExpress.XtraEditors.LabelControl();
            lblShowTimeAs = new DevExpress.XtraEditors.LabelControl();
            btnOk = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            edtStartDate = new DevExpress.XtraEditors.DateEdit();
            edtEndDate = new DevExpress.XtraEditors.DateEdit();
            tbLocation = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            tbDescription = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            txtZona = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtZona.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblSubject
            // 
            resources.ApplyResources(lblSubject, "lblSubject");
            lblSubject.Name = "lblSubject";
            // 
            // lblLocation
            // 
            resources.ApplyResources(lblLocation, "lblLocation");
            lblLocation.Name = "lblLocation";
            // 
            // tbSubject
            // 
            resources.ApplyResources(tbSubject, "tbSubject");
            tbSubject.Name = "tbSubject";
            tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            tbSubject.Properties.ReadOnly = true;
            // 
            // lblStartTime
            // 
            resources.ApplyResources(lblStartTime, "lblStartTime");
            lblStartTime.Name = "lblStartTime";
            // 
            // lblEndTime
            // 
            resources.ApplyResources(lblEndTime, "lblEndTime");
            lblEndTime.Name = "lblEndTime";
            // 
            // lblShowTimeAs
            // 
            resources.ApplyResources(lblShowTimeAs, "lblShowTimeAs");
            lblShowTimeAs.Name = "lblShowTimeAs";
            // 
            // btnOk
            // 
            resources.ApplyResources(btnOk, "btnOk");
            btnOk.Name = "btnOk";
            btnOk.Click += OnBtnOkClick;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.CausesValidation = false;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Name = "btnCancel";
            // 
            // edtStartDate
            // 
            resources.ApplyResources(edtStartDate, "edtStartDate");
            edtStartDate.Name = "edtStartDate";
            edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtStartDate.Properties.Buttons")) });
            edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartDate.Properties.MaxDate = new DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // edtEndDate
            // 
            resources.ApplyResources(edtEndDate, "edtEndDate");
            edtEndDate.Name = "edtEndDate";
            edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtEndDate.Properties.Buttons")) });
            edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndDate.Properties.MaxDate = new DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // tbLocation
            // 
            resources.ApplyResources(tbLocation, "tbLocation");
            tbLocation.Name = "tbLocation";
            tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            tbLocation.Properties.ReadOnly = true;
            // 
            // labelControl1
            // 
            resources.ApplyResources(labelControl1, "labelControl1");
            labelControl1.Name = "labelControl1";
            // 
            // tbDescription
            // 
            resources.ApplyResources(tbDescription, "tbDescription");
            tbDescription.Name = "tbDescription";
            tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            tbDescription.Properties.AccessibleRole = AccessibleRole.Client;
            tbDescription.Properties.ReadOnly = true;
            // 
            // labelControl2
            // 
            resources.ApplyResources(labelControl2, "labelControl2");
            labelControl2.Name = "labelControl2";
            // 
            // txtZona
            // 
            resources.ApplyResources(txtZona, "txtZona");
            txtZona.Name = "txtZona";
            txtZona.Properties.AccessibleName = resources.GetString("textEdit1.Properties.AccessibleName");
            txtZona.Properties.AccessibleRole = AccessibleRole.Client;
            txtZona.Properties.ReadOnly = true;
            // 
            // CustomAppointmentForm
            // 
            AcceptButton = btnOk;
            AccessibleRole = AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            Controls.Add(labelControl2);
            Controls.Add(txtZona);
            Controls.Add(labelControl1);
            Controls.Add(edtStartDate);
            Controls.Add(btnOk);
            Controls.Add(lblStartTime);
            Controls.Add(tbSubject);
            Controls.Add(lblLocation);
            Controls.Add(lblSubject);
            Controls.Add(tbLocation);
            Controls.Add(lblEndTime);
            Controls.Add(lblShowTimeAs);
            Controls.Add(btnCancel);
            Controls.Add(edtEndDate);
            Controls.Add(tbDescription);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("CustomAppointmentForm.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomAppointmentForm";
            ShowInTaskbar = false;
            Load += CustomAppointmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtZona.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.LabelControl lblShowTimeAs;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        private System.ComponentModel.IContainer components = null;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbDescription;
        protected DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtZona;
    }
}