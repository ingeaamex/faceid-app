using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class ucAttendanceReport : UserControl
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private DataTable _dtAttendanceReport = null;

        public ucAttendanceReport()
        {
            InitializeComponent();

            BindCompany();
            BindDepartment();
        }

        private void BindCompany()
        {
            cbxCompany.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxCompany.ValueMember = "ID";
            cbxCompany.DisplayMember = "Name";

            cbxCompany.Items.Clear();
            cbxCompany.Items.Add(new ListItem(-1, "All"));

            foreach (Company company in _dtCtrl.GetCompanyList())
            {
                cbxCompany.Items.Add(new ListItem(company.ID, company.Name));
            }
        }

        private void btnPayrollExport_Click(object sender, EventArgs e)
        {
            if (_dtAttendanceReport == null)
            {
                MessageBox.Show("Report must be created before exporting to payroll. Please click View to create a Report.");
            }
            else
            {
                frmPayrollExport frmPExport = new frmPayrollExport(_dtAttendanceReport, dtpAttendanceFrom.Value, dtpAttedanceTo.Value);
                frmPExport.ShowDialog(this);
            }
        }

        private void btnCollectData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet.");
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void BindDepartment()
        {
            cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxDepartment.ValueMember = "ID";
            cbxDepartment.DisplayMember = "Name";

            cbxDepartment.Items.Clear();
            cbxDepartment.Items.Add(new ListItem(-1, "All"));



            int companyID = (int)((ListItem)cbxCompany.SelectedItem).Value;
            if (companyID == -1) //all company
            {
                cbxDepartment.SelectedIndex = 0;
                cbxDepartment.Enabled = false;
            }
            else
            {
                foreach (Department department in _dtCtrl.GetDepartmentByCompany(companyID))
                {
                    cbxDepartment.Items.Add(new ListItem(department.ID, department.Name));
                }

                cbxDepartment.SelectedIndex = 0;
                cbxDepartment.Enabled = true;
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            int companyID = (int)((ListItem)cbxCompany.SelectedItem).Value;
            int departmentID = (int)((ListItem)cbxDepartment.SelectedItem).Value;

            _dtAttendanceReport = _dtCtrl.GetAttendanceReport(dtpAttendanceFrom.Value, dtpAttedanceTo.Value);

            dgvAttendanceReport.DataSource = _dtAttendanceReport;
        }
    }
}
