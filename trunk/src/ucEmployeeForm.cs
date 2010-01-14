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
        private IDataController dtCtrl;
        public ucEmployeeForm()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            BindCompany();
            LoadData();
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
            //frmAddUpdateEmployee frmEmpl = new frmAddUpdateEmployee();
            //frmEmpl.ShowDialog(this);
        }

        private void cboxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void LoadData()
        {
            if (cbDepartment.SelectedValue == null)
                return;
            int departmentID = (int)cbDepartment.SelectedValue;
            List<Employee> employees = dtCtrl.GetEmployeeList(departmentID);
            dgvEmpl.AutoGenerateColumns = false;
            dgvEmpl.DataSource = employees;
        }

        private void BindCompany()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
            cbCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbCompany.SelectedValue;
                List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
                cbDepartment.DataSource = departmentList;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
