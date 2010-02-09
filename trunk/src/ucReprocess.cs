﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
namespace FaceIDAppVBEta
{
    public partial class ucReprocess : UserControl
    {
        private IDataController _dtCtrl;
        public ucReprocess()
        {
            InitializeComponent();
            _dtCtrl = LocalDataController.Instance;
            BindData();
        }

        private void BindData()
        {
            BindCompany();
            BindWorkCalendar();
        }

        private void BindWorkCalendar()
        {
            List<WorkingCalendar> workingCalendarList = _dtCtrl.GetWorkingCalendarList();
            WorkingCalendar workingCalendar = new WorkingCalendar();
            workingCalendar.ID = 0;
            workingCalendar.Name = "Select Working Calendar";
            workingCalendarList.Insert(0, workingCalendar);
            cbxWorkingCalendar.DataSource = workingCalendarList;
        }
        
        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            Company company = new Company();
            company.ID = -1;
            company.Name = "All companies";
            companyList.Insert(0, company);
            company = new Company();
            company.ID = 0;
            company.Name = "Select Company";
            companyList.Insert(0, company);
            cbxCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbxCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbxCompany.SelectedValue;
                if (CompanyID == -1)
                {
                    cbxDepartment.Enabled = false;
                    return;
                }
                cbxDepartment.Enabled = true;
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);
                Department department = new Department();
                department.ID = -1;
                department.Name = "All departments";
                departmentList.Insert(0, department);
                department = new Department();
                department.ID = 0;
                department.Name = "Select Department";
                departmentList.Insert(0, department);
                cbxDepartment.DataSource = departmentList;
            }
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            bool oErr = false;
            if ((int)cbxCompany.SelectedValue == 0)
            {
                errProviders.SetError(cbxCompany, "Select Company");
                oErr = true;
            }
            if (cbxDepartment.Enabled && (int)cbxDepartment.SelectedValue == 0)
            {
                errProviders.SetError(cbxDepartment, "Select Department");
                oErr = true;
            }
            if ((int)cbxWorkingCalendar.SelectedValue == 0)
            {
                errProviders.SetError(cbxWorkingCalendar, "Select Working Calendar");
                oErr = true;
            }
            if (dtpReprocessFrom.Value.CompareTo(dtpReprocessTo.Value)==1)
            {
                errProviders.SetError(dtpReprocessFrom, "Not valid. reprocess time from > to");
                oErr = true;
            }
            if (oErr)
                return;

            string employeeNumberList = "";
            DataGridViewSelectedRowCollection dtgRowCollection = dgvEmployee.SelectedRows;
            foreach (DataGridViewRow dtgRow in dtgRowCollection)
            {
                employeeNumberList += dtgRow.Cells[0].Value + ",";
            }
            employeeNumberList = employeeNumberList.Trim(',');
            if (employeeNumberList == "")
            {
                MessageBox.Show(this, "Select employee to continue");
                return;
            }
            DateTime dReprocessFrom = dtpReprocessFrom.Value.Date;
            DateTime dReprocessTo = dtpReprocessTo.Value.Date;

            //go forward to 23:59:59
            dReprocessTo = dReprocessTo.AddDays(1).AddSeconds(-1);

            new frmReprocessStatus(employeeNumberList, dReprocessFrom, dReprocessTo).ShowDialog(this);
        }

        private void LoadData()
        {
            DateTime beginDate = dtpReprocessFrom.Value;
            DateTime endDate = dtpReprocessTo.Value.Date.AddHours(23).AddMinutes(59);

            int companyID = (int)cbxCompany.SelectedValue;
            int departmentID = -1;
            if (cbxDepartment.Enabled)
                departmentID = (int)cbxDepartment.SelectedValue;

            List<Employee> employees = _dtCtrl.GetEmployeeList(companyID, departmentID);
            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.DataSource = employees;
        }

        private void cbxDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvEmployee.Columns["EmployeeName"].Index)
            {
                List<Employee> employees = (List<Employee>)dgvEmployee.DataSource;
                Employee employee = employees[e.RowIndex];

                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", employee.LastName, employee.FirstName);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dgvEmployee.SelectAll();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();
        }

        private void cbxDepartment_EnabledChanged(object sender, EventArgs e)
        {
            if (!cbxDepartment.Enabled)
                LoadData();
        }
    }
}