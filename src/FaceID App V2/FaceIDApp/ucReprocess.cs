using System;
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
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
            
            InitializeComponent();

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
            workingCalendar.ID = -1;
            workingCalendar.Name = "All Working Calendar";
            workingCalendarList.Insert(0, workingCalendar);
            
            cbxWorkingCalendar.DataSource = workingCalendarList;
        }
        
        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            
            Company company = new Company();
            company.ID = -1;
            company.Name = "All Companies";
            companyList.Insert(0, company);
            company = new Company();
            
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
                else
                {
                    cbxDepartment.Enabled = true;
                    List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);

                    Department department = new Department();
                    department.ID = -1;
                    department.Name = "All Departments";
                    departmentList.Insert(0, department);

                    cbxDepartment.DataSource = departmentList;
                }
            }
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dtgRowCollection = dgvEmployee.SelectedRows;

            if (dtgRowCollection.Count == 0)
            {
                MessageBox.Show("No employee is selected.");
                return;
            }

            string employeeNumberList = "";
            foreach (DataGridViewRow dtgRow in dtgRowCollection)
            {
                employeeNumberList += dtgRow.Cells[0].Value + ",";
            }
            employeeNumberList = employeeNumberList.Trim(',');

            DateTime dReprocessFrom = dtpReprocessFrom.Value.Date;
            DateTime dReprocessTo = dtpReprocessTo.Value.Date;

            //go forward to 23:59:59
            dReprocessTo = dReprocessTo.AddDays(1).AddSeconds(-1);

            new frmReprocessStatus(employeeNumberList, dReprocessFrom, dReprocessTo).ShowDialog(this);
        }

        private void LoadData()
        {
            int companyID = (int)cbxCompany.SelectedValue;
            int departmentID = -1;
            
            if (cbxDepartment.Enabled)
                departmentID = (int)cbxDepartment.SelectedValue;

            int workingCalendarID = (int)cbxWorkingCalendar.SelectedValue;

            List<Employee> employeeList = _dtCtrl.GetEmployeeList(companyID, departmentID);
            List<WorkingCalendar> workingCalendarList = _dtCtrl.GetWorkingCalendarList();

            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeNumber");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("WorkingCalendar");

            foreach (Employee employee in employeeList)
            {
                if (workingCalendarID != -1 && employee.WorkingCalendarID != workingCalendarID)
                    continue;

                DataRow dr = dt.NewRow();
                dr["EmployeeNumber"] = employee.EmployeeNumber;
                dr["EmployeeName"] = string.Format("{0}, {1}", employee.LastName, employee.FirstName);

                WorkingCalendar workingCalendar = workingCalendarList.Find(delegate(WorkingCalendar wCal)
                {
                    return wCal.ID == employee.WorkingCalendarID;
                });

                if (workingCalendar != null)
                    dr["WorkingCalendar"] = workingCalendar.Name;

                dt.Rows.Add(dr);
            }

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.DataSource = dt;

            dgvEmployee.ClearSelection();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dgvEmployee.SelectAll();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
