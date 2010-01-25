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
    public partial class ucEmployeeForm : UserControl
    {
        private Point cellContext;
        private ITerminalController _terCtrl = new TerminalController();
        private IDataController _dtCtrl = LocalDataController.Instance;

        public ucEmployeeForm()
        {
            InitializeComponent();
            BindCompany();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            BindEmployee();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet");
        }

        private void btNewEmpl_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frmEmpl = new frmAddUpdateEmployee(-1);
            frmEmpl.ShowDialog(this);
        }

        private void cboxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void BindEmployee()
        {
            int iCompany = (int)cbCompany.SelectedValue;
            int iDepartment = -1;
            if (cbDepartment.Enabled)
                iDepartment = (int)cbDepartment.SelectedValue;

            List<Employee> employees = _dtCtrl.GetEmployeeList(iCompany, iDepartment);
            dgvEmpl.AutoGenerateColumns = false;
            dgvEmpl.DataSource = employees;
        }

        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            Company company = new Company();
            company.ID = -1;
            company.Name = "All companies";
            companyList.Insert(0, company);
            cbCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbCompany.SelectedValue;
                if (CompanyID == -1)
                {
                    cbDepartment.Enabled = false;
                    return;
                }
                cbDepartment.Enabled = true;
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);
                Department department = new Department();
                department.ID = -1;
                department.Name = "All departments";
                departmentList.Insert(0, department);
                cbDepartment.DataSource = departmentList;
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvEmpl.Rows[cellContext.X].Cells[4].Value;
            frmAddUpdateEmployee objForm = new frmAddUpdateEmployee(id);
            objForm.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object oId = dgvEmpl.Rows[cellContext.X].Cells[4].Value;
            DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dlogRs.ToString().Equals("Yes"))
            {
                Employee employee = _dtCtrl.GetEmployee((int)oId);
                _dtCtrl.BeginTransaction();
                bool brs1 = _dtCtrl.DeleteEmployee((int)oId);
                bool brs2 = _dtCtrl.DeleteEmployeeTerminalByEmployee(employee.EmployeeNumber);

                if (brs1 && brs2)
                {
                    _dtCtrl.CommitTransaction();
                    MessageBox.Show("sucessfull");
                    BindEmployee();
                }
                else
                {
                    _dtCtrl.RollbackTransaction();
                    MessageBox.Show("error");
                }
            }
        }

        private void dgvEmpl_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellContext = new Point(e.RowIndex, e.ColumnIndex);
        }

        private void dgvEmpl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvEmpl.Columns["EmployeeName"].Index)
            {
                List<Employee> employees = (List<Employee>)dgvEmpl.DataSource;
                Employee employee = employees[e.RowIndex];
                
                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", employee.LastName, employee.FirstName);
            }
            else if (e.ColumnIndex == dgvEmpl.Columns["Terminal"].Index)
            {
                List<Employee> employees = (List<Employee>)dgvEmpl.DataSource;
                Employee employee = employees[e.RowIndex];

                List<Terminal> terminals = _dtCtrl.GetTerminalListByEmployee(Convert.ToInt32(e.Value));

                string terminalNames = "";
                if (terminals.Count > 0)
                {
                    foreach (Terminal t in terminals)
                        terminalNames += t.Name + ", ";

                    terminalNames = terminalNames.Trim().TrimEnd(',');
                }

                e.FormattingApplied = true;
                e.Value = terminalNames;
                
            }
        }

        private void btnGetEmployeeFromTerminal_Click(object sender, EventArgs e)
        {
            GetEmployeeFromTerminal();
        }

        private void GetEmployeeFromTerminal()
        {
            try
            {
                List<Terminal> terminalList = _dtCtrl.GetTerminalList();

                foreach (Terminal terminal in terminalList)
                {
                    if (_terCtrl.IsTerminalConnected(terminal))
                    {
                        List<Employee> employeeList = _terCtrl.GetAllEmployee(terminal);

                        foreach (Employee employee in employeeList)
                        {
                            if (_dtCtrl.IsNewEmployee(employee))
                            {
                                if(_dtCtrl.AddEmployee(employee) < 0)
                                    throw new Exception("Cannot update employee " + employee.EmployeeNumber);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Cannot connect to terminal " + terminal.Name);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There has been an error: " + ex.Message + ". Please try again.");
                return;
            }

            MessageBox.Show("Employee data from terminals have been copied succesfully");
            BindEmployee();
        }

        private void btnSendEmployeeToTerminal_Click(object sender, EventArgs e)
        {
            SendEmployeeToTerminal();
        }

        private void SendEmployeeToTerminal()
        {
            try
            {
                List<Terminal> terminalList = _dtCtrl.GetTerminalList();

                foreach (Terminal terminal in terminalList)
                {
                    if (_terCtrl.IsTerminalConnected(terminal))
                    {
                        List<Employee> employeeList = _dtCtrl.GetEmployeeListByTerminal(terminal.ID);

                        foreach (Employee employee in employeeList)
                        {
                            if (_dtCtrl.IsNewEmployee(employee))
                            {
                                if (_dtCtrl.AddEmployee(employee) < 0)
                                    throw new Exception("Cannot update employee " + employee.EmployeeNumber + " on terminal " + terminal.Name);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Cannot connect to terminal " + terminal.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error: " + ex.Message + ". Please try again.");
                return;
            }

            MessageBox.Show("Employee data from terminals have been copied succesfully");
            BindEmployee();
        }
    }
}
