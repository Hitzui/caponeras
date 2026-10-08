using System;
using System.Linq;

namespace Caponeras.App.Views.Layouts
{
    public partial class FormLayout : DevExpress.XtraEditors.XtraForm
    {
        protected bool ResultDialog;
        public FormLayout()
        {
            ResultDialog = false;
            InitializeComponent();
        }

        public bool GetResult()
        {
            return ResultDialog;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ResultDialog = false;
            Close();
        }
    }
}