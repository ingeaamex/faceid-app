using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class frmPayrollExport : Form
    {
        private int _companyID;
        private int _deparmentID;
        private DateTime _dPayrollFrom;
        private DateTime _dPayrollTo;
        //bool viewMinPayPeriod = false;
        int _workingCalendarID = 0;

        public frmPayrollExport(int companyID, int deparmentID, DateTime dPayrollFrom, DateTime dPayrollTo, int workingCalendarID)
        {
            InitializeComponent();
            this._companyID = companyID;
            this._deparmentID = deparmentID;
            this._dPayrollFrom = dPayrollFrom;
            this._dPayrollTo = dPayrollTo;
            this._workingCalendarID = workingCalendarID;
            //this.viewMinPayPeriod = viewMinPayPeriod;
        }

        private void frmPayrollExport_Load(object sender, EventArgs e)
        {
            LocalDataController dtCtrl = LocalDataController.Instance;

            string errorNumber = "";
            List<PayrollExport> payrollExports = dtCtrl.GetPayrollExportList(_companyID, _deparmentID, _dPayrollFrom, _dPayrollTo, _workingCalendarID, ref errorNumber);

            this.BindingSource.DataSource = payrollExports;

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("PayrollFrom", _dPayrollFrom.ToString("d MMM yyyy"), false));
            paramList.Add(new ReportParameter("PayrollTo", _dPayrollTo.ToString("d MMM yyyy"), false));

            reportViewer1.LocalReport.SetParameters(paramList);

            this.reportViewer1.RefreshReport();
        }
    }
}
