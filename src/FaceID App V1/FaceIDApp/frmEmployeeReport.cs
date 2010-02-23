using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;


namespace FaceIDAppVBEta
{
    public partial class frmEmployeeReport : Form
    {
        int companyId;
        int deparmentId;
        public frmEmployeeReport(int _companyId, int _deparmentId)
        {
            InitializeComponent();
            companyId = _companyId;
            deparmentId = _deparmentId;
        }

        private void frmEmployeeReport_Load(object sender, EventArgs e)
        {
            IDataController dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
            this.BindingSource.DataSource = dtCtrl.GetEmployeeReportList(companyId, deparmentId);
            this.reportViewer1.RefreshReport();
        }
    }
}
