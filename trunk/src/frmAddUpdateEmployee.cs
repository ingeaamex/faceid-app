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
        private IDataController _dtCtrl = LocalDataController.Instance;
        private int _employeeID = -1;
        bool _isAlert = true;
        private int _employeeNumber = -1;

        public frmAddUpdateEmployee(int employeeID)
        {
            InitializeComponent();
            this._employeeID = employeeID;
        }

        private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            BindData();

            SetState(_employeeID);
        }

        private void BindData()
        {
            BindCompany();
            //BindDepartment();
            BindWorkingCalendar();
        }

        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            if (companyList.Count < 1)
            {
                MessageBox.Show("The company created before creating a employee. Press OK to closed form", "", MessageBoxButtons.OK);
                _isAlert = false;
                this.Close();
            }
            cbxCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbxCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbxCompany.SelectedValue;
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);
                if (departmentList.Count < 1)
                {
                    MessageBox.Show("The department created before creating a employee. Press OK to closed form", "", MessageBoxButtons.OK);
                    _isAlert = false;
                    this.Close();
                }
                cbxDepartment.DataSource = departmentList;
            }
        }

        private void BindWorkingCalendar()
        {
            List<WorkingCalendar> workingCalendarList = _dtCtrl.GetWorkingCalendarList();
            if (workingCalendarList.Count < 1)
            {
                MessageBox.Show("The working calendar created before creating a employee. Press OK to closed form", "", MessageBoxButtons.OK);
                _isAlert = false;
                this.Close();
            }
            cbxWorkingCalendar.DataSource = workingCalendarList;
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
            Employee employee = _dtCtrl.GetEmployee(employeeID);
            if (employee == null)
            {
                MessageBox.Show("Employee not found or has been deleted.");
                this.Close();
            }
            _employeeID = employeeID;
            _employeeNumber = employee.EmployeeNumber;

            Department department = _dtCtrl.GetDepartment(employee.DepartmentID);

            cbxCompany.SelectedValue = department.CompanyID;
            cbxDepartment.SelectedValue = employee.DepartmentID;
            cbxWorkingCalendar.SelectedValue = employee.WorkingCalendarID;
            cbxWorkingCalendar.Enabled = (employee.WorkingCalendarID <= 0);
            
            tbFirstName.Text = employee.FirstName;
            tbLastName.Text = employee.LastName;
            tbPhoneNumber.Text = employee.PhoneNumber;
            tbAddress.Text = employee.Address;
            tbJobDesc.Text = employee.JobDescription;
            tbEmployeeNumber.Text = employee.EmployeeNumber.ToString();
            tbPayrollNumber.Text = employee.PayrollNumber.ToString();
            dtpBirthday.Value = employee.Birthday;
            dtpJoinedDate.Value = employee.HiredDate;
            dtpLeftDate.Value = employee.LeftDate;

            dtpBirthday.Checked = (employee.Birthday != Config.MinDate);
            dtpJoinedDate.Checked = (employee.HiredDate != Config.MinDate);
            dtpLeftDate.Checked = (employee.LeftDate != Config.MinDate);

            List<Terminal> terminals = _dtCtrl.GetTerminalListByEmployee(_employeeNumber);
            foreach (Terminal terminal in terminals)
            {
                lbxTerminal.Items.Add(terminal);
            }
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

            employee.ActiveFrom = DateTime.Now;
            employee.Active = true;

            try
            {
                List<Terminal> terminals = GetTerminalsUserInput();

                if (_dtCtrl.AddEmployee(employee, terminals) > 0)
                {
                    MessageBox.Show("Employee has been addded successfully.");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again");
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = GetEmployeeUserInput();
            if (employee == null)
                return;

            //TODO transaction here

            bool rs1 = _dtCtrl.UpdateEmployee(employee);

            MessageBox.Show(rs1 ? "successful" : "error");

            List<Terminal> terminals = GetTerminalsUserInput();

            bool rs2 = _dtCtrl.UpdateEmployeeTerminal(terminals, _employeeNumber);
            if (!rs2)
                MessageBox.Show("[terminal] error");

            if (rs1 && rs2)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {
            frmTerminalRegister objForm = new frmTerminalRegister(this);
            objForm.ShowDialog(this);
        }

        private Employee GetEmployeeUserInput()
        {
            //Employee employee = new Employee();
            Employee employee = _employeeID > 0 ? _dtCtrl.GetEmployee(_employeeID) : new Employee();

            object oDepartment = cbxDepartment.SelectedValue;
            object oWorkingCalendar = cbxWorkingCalendar.SelectedValue;
            string sFistName = tbFirstName.Text;
            string sLastName = tbLastName.Text;
            string sPhoneNumber = tbPhoneNumber.Text;
            string sAddress = tbAddress.Text;
            string sJobDesc = tbJobDesc.Text;

            DateTime dBirthday = dtpBirthday.Value;
            DateTime dJoinedDate = dtpJoinedDate.Value;
            DateTime dLeftDate = dtpLeftDate.Value;

            if (dtpBirthday.Checked == false)
                dBirthday = Config.MinDate;

            if (dtpJoinedDate.Checked == false)
                dJoinedDate = Config.MinDate;

            if (dtpLeftDate.Checked == false)
                dLeftDate = Config.MinDate;

            bool isValid = true;

            if (dLeftDate.Date.CompareTo(dJoinedDate.Date) != 1 && dLeftDate != Config.MinDate && dJoinedDate != Config.MinDate)
            {
                MessageBox.Show("Left date < Joined date");
                isValid = false;
            }

            if (dJoinedDate.Date.CompareTo(dBirthday.Date) != 1 && dJoinedDate != Config.MinDate && dBirthday != Config.MinDate)
            {
                MessageBox.Show("Joined date < birthday");
                isValid = false;
            }

            if (oDepartment == null || oWorkingCalendar == null)
            {
                MessageBox.Show("Invalid user input");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sFistName))
            {
                errProviders.SetError(tbFirstName, "Enter first name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sLastName))
            {
                errProviders.SetError(tbLastName, "Enter last name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sPhoneNumber))
            {
                errProviders.SetError(tbPhoneNumber, "Enter phone number");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sAddress))
            {
                errProviders.SetError(tbAddress, "Enter address");
                isValid = false;
            }
            if (string.IsNullOrEmpty(sJobDesc))
            {
                errProviders.SetError(tbJobDesc, "Enter job description");
                isValid = false;
            }


            if (!isValid)
                return null;

            employee.DepartmentID = (int)oDepartment;
            if (oWorkingCalendar != null)
                employee.WorkingCalendarID = (int)oWorkingCalendar;
            employee.FirstName = sFistName;
            employee.LastName = sLastName;
            employee.PhoneNumber = sPhoneNumber;
            employee.Address = sAddress;
            employee.JobDescription = sJobDesc;
            employee.Birthday = dBirthday;
            employee.HiredDate = dJoinedDate;
            employee.LeftDate = dLeftDate;

            return employee;
        }

        public List<Terminal> GetTerminalsUserInput()
        {
            ListBox.ObjectCollection oTerminals = lbxTerminal.Items;
            List<Terminal> terminals = new List<Terminal>();
            foreach (Object o in oTerminals)
            {
                terminals.Add((Terminal)o);
            }
            return terminals;
        }

        public void SetTerminalValues(List<Terminal> terminals)
        {
            lbxTerminal.Items.Clear();
            foreach (Terminal terminal in terminals)
            {
                lbxTerminal.Items.Add(terminal);
            }
        }

        private void frmAddUpdateEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isAlert)
            {
                Control[] ctr = this.Owner.Controls.Find("btView", true);
                if (ctr != null && ctr.Length > 0)
                {
                    Button btn = (Button)ctr[0];
                    btn.PerformClick();
                }
            }
        }
    }
}
