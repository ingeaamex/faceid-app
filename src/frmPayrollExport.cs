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
    public partial class frmPayrollExport : Form
    {
        private int companyId;
        private int deparmentId;
        private DateTime dPayrollFrom;
        private DateTime dPayrollTo;
        public frmPayrollExport(int companyId, int deparmentId, DateTime dPayrollFrom, DateTime dPayrollTo)
        {
            InitializeComponent();
            this.companyId = companyId;
            this.deparmentId = deparmentId;
            this.dPayrollFrom = dPayrollFrom;
            this.dPayrollTo = dPayrollTo;
        }

        private void frmPayrollExport_Load(object sender, EventArgs e)
        {
            LocalDataController dtCtrl = LocalDataController.Instance;

            this.BindingSource.DataSource = dtCtrl.GetPayrollExportList(companyId, deparmentId, dPayrollFrom, dPayrollTo);

            List<Microsoft.Reporting.WinForms.ReportParameter> paramList = new List<Microsoft.Reporting.WinForms.ReportParameter>();

            paramList.Add(new Microsoft.Reporting.WinForms.ReportParameter("PayrollFrom", dPayrollFrom.ToString("d MMM yyyy"), false));
            paramList.Add(new Microsoft.Reporting.WinForms.ReportParameter("PayrollTo", dPayrollTo.ToString("d MMM yyyy"), false));

            reportViewer1.LocalReport.SetParameters(paramList);

            this.reportViewer1.RefreshReport();
        }
    }
}
