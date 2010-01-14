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
    public partial class frmAddUpdateEmployee : Form
    {
        private IDataController dtCtrl;
        public frmAddUpdateEmployee(int employeeID)
        {
            InitializeComponent();

            dtCtrl = LocalDataController.Instance;

            BindData();

            SetState(employeeID);
        }

        private void BindData()
        {
            BindCompany();
            BindDepartment();
            BindWorkingCalendar();
            BindTerminal();
        }

        private void BindCompany()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
            cbxCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbxCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbxCompany.SelectedValue;
                List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
                cbxDepartment.DataSource = departmentList;
            }
        }

        private void BindWorkingCalendar()
        {
            List<WorkingCalendar> workingCalendarList = dtCtrl.GetWCalendarList();
            cbxWorkingCalendar.DataSource = workingCalendarList;
        }

        private void BindTerminal()
        {
            List<Terminal> terminalList = dtCtrl.GetTerminalList();
            lbxTerminal.DataSource = terminalList;
        }

        private void SetState(int employeeID)
        {
            if (employeeID <= 0)//add
            {
                this.Text = "Add New Employee";
                lblAddUpdateEmployee.Text = "Add New Employee";
                btnAddEmployee.Visible = true;
                btnUpdateEmployee.Visible = false;
            }
            else//update
            {
                this.Text = "Update Employee";
                lblAddUpdateEmployee.Text = "Update Employee";
                btnAddEmployee.Visible = false;
                btnUpdateEmployee.Visible = true;

                BindEmployeeData(employeeID);
            }
        }

        private void BindEmployeeData(int employeeID)
        {
            throw new NotImplementedException();
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = GetEmployeeUserInput();
            if (employee == null)
                return;

            EmployeeTerminal emplTerminal = new EmployeeTerminal();
            emplTerminal.TerminalID = (int)lbxTerminal.SelectedValue;

            employee.PhotoData = "";
            int id = dtCtrl.AddEmployee(employee);
            if (id > 0)
            {
                employee.PayrollNumber = id;
                employee.EmployeeNumber = id;
                bool rs = dtCtrl.UpdateEmployeeNumber(employee);
                emplTerminal.EmployeeID = id;
                id = dtCtrl.AddEmplTerminal(emplTerminal);

                if (rs && id > 0)
                {
                    MessageBox.Show("sucessfull");
                    this.Close();
                }
                else
                    MessageBox.Show("error");
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveTerminal_Click(object sender, EventArgs e)
        {

        }

        private Employee GetEmployeeUserInput()
        {
            Employee employee = new Employee();
            object oDepartment = cbxDepartment.SelectedValue;
            object oWorkingCalendar = cbxWorkingCalendar.SelectedValue;
            string sFistName = txtFirstName.Text;
            string sLastName = txtLastName.Text;
            bool isValid = true;
            if (oDepartment == null || oWorkingCalendar == null)
            {
                MessageBox.Show("Invalid user input");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sFistName))
            {
                errProviders.SetError(txtFirstName, "Enter First Name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sLastName))
            {
                errProviders.SetError(txtLastName, "Enter Last Name");
                isValid = false;
            }

            if (!isValid)
                return null;

            employee.DepartmentID = (int)oDepartment;
            employee.WorkingCalendarID = (int)oDepartment;
            employee.FirstName = sFistName;
            employee.LastName = sLastName;
            employee.PhoneNumber = txtPhoneNumber.Text;
            employee.Address = txtAddress.Text;
            employee.JobDescription = txtJobDesc.Text;
            employee.Birthday = dtpBirthday.Value;
            employee.HiredDate = dtpJoinedDate.Value;
            employee.LeftDate = dtpLeftDate.Value;

            return employee;
        }

        private void frmAddUpdateEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Control[] ctr = this.Owner.Controls.Find("btRefresh", true);
            if (ctr != null && ctr.Length > 0)
            {
                Button btn = (Button)ctr[0];
                btn.PerformClick();
            }
        }
    }
}
