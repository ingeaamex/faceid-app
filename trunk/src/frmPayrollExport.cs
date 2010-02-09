﻿using System;
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
        private int companyId;
        private int deparmentId;
        private DateTime dPayrollFrom;
        private DateTime dPayrollTo;
        bool viewMinPayPeriod = false;
        int wcalID = 0;
        public frmPayrollExport(int companyId, int deparmentId, DateTime dPayrollFrom, DateTime dPayrollTo, int wcalID)
        {
            InitializeComponent();
            this.companyId = companyId;
            this.deparmentId = deparmentId;
            this.dPayrollFrom = dPayrollFrom;
            this.dPayrollTo = dPayrollTo;
            this.wcalID = wcalID;
            //this.viewMinPayPeriod = viewMinPayPeriod;
        }

        private void frmPayrollExport_Load(object sender, EventArgs e)
        {
            LocalDataController dtCtrl = LocalDataController.Instance;

            string errorNumber = "";
            List<PayrollExport> payrollExports = dtCtrl.GetPayrollExportList(companyId, deparmentId, dPayrollFrom, dPayrollTo, wcalID, ref errorNumber);

            this.BindingSource.DataSource = payrollExports;

            List<ReportParameter> paramList = new List<ReportParameter>();

            paramList.Add(new ReportParameter("PayrollFrom", dPayrollFrom.ToString("d MMM yyyy"), false));
            paramList.Add(new ReportParameter("PayrollTo", dPayrollTo.ToString("d MMM yyyy"), false));

            reportViewer1.LocalReport.SetParameters(paramList);

            this.reportViewer1.RefreshReport();
        }
    }
}
