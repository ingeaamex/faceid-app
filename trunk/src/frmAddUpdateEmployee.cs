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

        public frmAddUpdateEmployee(int employeeID)
        {
            InitializeComponent();

            BindData();
            SetState(employeeID);
        }

        private void BindData()
        {
            BindCompany();

            BindWorkingCalendar();
        }

        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList(false);
            if (companyList.Count < 1)
            {
                MessageBox.Show("At least one Company must be added before adding employees.");

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
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID, false);
                if (departmentList.Count < 1)
                {
                    MessageBox.Show("At least one Department must be added before adding employees.");

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
                MessageBox.Show("At least one Working Calendar must be added before adding employees.");

                _isAlert = false;
                this.Close();
            }
            cbxWorkingCalendar.DataSource = workingCalendarList;
        }

        private void SetState(int employeeID)
        {
            if (employeeID <= 0)//add
            {
                _employeeID = -1;

                this.Text = "Add New Employee";
                lblAddUpdateEmployee.Text = "Add New Employee";
                btnSubmit.Text = "Add";

                tbEmployeeNumber.Text = "Auto";
                tbPayrollNumber.Text = "Auto";

                dtpBirthday.Value = DateTime.Today.AddYears(-16);
                dtpJoinedDate.Value = DateTime.Today;
                dtpLeftDate.Value = DateTime.Today.AddYears(50);
            }
            else//update
            {
                _employeeID = employeeID;

                this.Text = "Update Employee";
                lblAddUpdateEmployee.Text = "Update Employee";
                btnSubmit.Text = "Update";

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

            Department department = _dtCtrl.GetDepartment(employee.DepartmentID);

            cbxCompany.SelectedValue = department.CompanyID;
            cbxDepartment.SelectedValue = employee.DepartmentID;
            cbxWorkingCalendar.SelectedValue = employee.WorkingCalendarID;
            //cbxWorkingCalendar.Enabled = (employee.WorkingCalendarID <= 0);

            tbFirstName.Text = employee.FirstName;
            tbLastName.Text = employee.LastName;
            tbPhoneNumber.Text = employee.PhoneNumber;
            tbAddress.Text = employee.Address;
            tbJobDesc.Text = employee.JobDescription;
            tbEmployeeNumber.Text = employee.EmployeeNumber.ToString();
            tbPayrollNumber.Text = employee.PayrollNumber.ToString();

            if (employee.Birthday != Config.MinDate)
            {
                dtpBirthday.Value = employee.Birthday;
                dtpBirthday.Checked = false;
            }
            else
            {
                dtpBirthday.Value = DateTime.Today;
                dtpBirthday.Checked = true;
            }

            if (employee.HiredDate != Config.MinDate)
            {
                dtpJoinedDate.Value = employee.HiredDate;
                dtpJoinedDate.Checked = false;
            }
            else
            {
                dtpJoinedDate.Value = DateTime.Today;
                dtpJoinedDate.Checked = true;
            }

            if (employee.LeftDate != Config.MinDate)
            {
                dtpLeftDate.Value = employee.LeftDate;
                dtpLeftDate.Checked = false;
            }
            else
            {
                dtpLeftDate.Value = DateTime.Today.AddYears(50);
                dtpLeftDate.Checked = true;
            }

            List<Terminal> terminals = _dtCtrl.GetTerminalListByEmployee(employee.EmployeeNumber);
            foreach (Terminal terminal in terminals)
            {
                lbxTerminal.Items.Add(terminal);
            }
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = GetEmployeeUserInput();
                if (employee == null) //invalid input
                    return;

                if (_employeeID == -1) //add
                {
                    List<Terminal> terminals = GetTerminalsUserInput();

                    if (_dtCtrl.AddEmployee(employee, terminals) > 0)
                    {
                        if (Util.Confirm("Employee added. Do you want to add another employee?"))
                        {
                            SetState(-1);
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        throw new Exception("Employee could not be added.");
                    }
                }
                else //update
                {
                    _dtCtrl.BeginTransaction();

                    try
                    {
                        if (_dtCtrl.UpdateEmployee(employee) == false)
                            throw new Exception("Employee could not be updated.");

                        List<Terminal> terminals = GetTerminalsUserInput();

                        if (_dtCtrl.UpdateEmployeeTerminal(terminals, employee.EmployeeNumber) == false)
                            throw new Exception("Employee's Terminal Info could not be updated.");

                        _dtCtrl.CommitTransaction();
                        MessageBox.Show("Employee updated.");
                        this.Close();
                    }
                    catch
                    {
                        _dtCtrl.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Util.ConfirmCloseForm())
            {
                this.Close();
            }
        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {
            frmTerminalRegister objForm = new frmTerminalRegister(this);
            objForm.ShowDialog(this);
        }

        private Employee GetEmployeeUserInput()
        {
            Employee employee = _employeeID > 0 ? _dtCtrl.GetEmployee(_employeeID) : new Employee();

            object departmentID = cbxDepartment.SelectedValue;
            object workingCalendarID = cbxWorkingCalendar.SelectedValue;
            string fistName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string address = tbAddress.Text;
            string jobDesc = tbJobDesc.Text;

            DateTime birthday = dtpBirthday.Value;
            DateTime joinedDate = dtpJoinedDate.Value;
            DateTime leftDate = dtpLeftDate.Value;

            if (dtpBirthday.Checked == false)
                birthday = Config.MinDate;

            if (dtpJoinedDate.Checked == false)
                joinedDate = Config.MinDate;

            if (dtpLeftDate.Checked == false)
                leftDate = Config.MinDate;

            bool isValid = true;

            if (leftDate.Date.CompareTo(joinedDate.Date) != 1 && leftDate != Config.MinDate && joinedDate != Config.MinDate)
            {
                MessageBox.Show("Left date < Joined date.");
                return null;
            }

            if (joinedDate.Date.CompareTo(birthday.Date) < 0 && joinedDate != Config.MinDate && birthday != Config.MinDate)
            {
                MessageBox.Show("Joined date < Birthday.");
                return null;
            }

            if (departmentID == null || workingCalendarID == null)
            {
                MessageBox.Show("Please select Company, Department and Working Calendar");
                return null;
            }
            if (string.IsNullOrEmpty(fistName))
            {
                errProviders.SetError(tbFirstName, "Enter first name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(lastName))
            {
                errProviders.SetError(tbLastName, "Enter last name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(jobDesc))
            {
                errProviders.SetError(tbJobDesc, "Enter job description");
                isValid = false;
            }

            if (!isValid)
                return null;

            employee.DepartmentID = (int)departmentID;
            employee.WorkingCalendarID = (int)workingCalendarID;
            employee.FirstName = fistName;
            employee.LastName = lastName;
            employee.PhoneNumber = phoneNumber;
            employee.Address = address;
            employee.JobDescription = jobDesc;
            employee.Birthday = birthday;
            employee.HiredDate = joinedDate;
            employee.LeftDate = leftDate;

            return employee;
        }

        public List<Terminal> GetTerminalsUserInput()
        {
            ListBox.ObjectCollection oTerminals = lbxTerminal.Items;
            List<Terminal> terminalList = new List<Terminal>();

            foreach (Object obj in oTerminals)
            {
                terminalList.Add((Terminal)obj);
            }
            return terminalList;
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
                //Call back to parent form
            }
        }
    }
}
