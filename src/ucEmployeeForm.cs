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
        private IDataController dtCtrl;
        public ucEmployeeForm()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            BindCompany();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

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

        private void LoadData()
        {
            List<Employee> employees;
            if (!cbDepartment.Enabled || (int)cbDepartment.SelectedValue == -1)
            {
                int companyId = (int)cbCompany.SelectedValue;
                employees = dtCtrl.GetEmployeeList(companyId);
            }
            else
            {
                int departmentID = (int)cbDepartment.SelectedValue;
                employees = dtCtrl.GetEmployeeListByDep(departmentID);
            }
            dgvEmpl.AutoGenerateColumns = false;
            dgvEmpl.DataSource = employees;
        }

        private void BindCompany()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
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
                List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
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
                Employee employee = dtCtrl.GetEmployee((int)oId);
                dtCtrl.BeginTransaction();
                bool brs1 = dtCtrl.DeleteEmployee((int)oId);
                bool brs2 = dtCtrl.DeleteEmplTerminalByEmpl(employee.EmployeeNumber);
                if (brs1 && brs2)
                {
                    dtCtrl.CommitTransaction();
                    MessageBox.Show("sucessfull");
                    LoadData();
                }
                else
                {
                    dtCtrl.RollbackTransaction();
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
                e.Value = string.Format("{0}, {1}", employee.FirstName, employee.LastName);
            }
        }
    }
}
