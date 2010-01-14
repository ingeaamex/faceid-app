using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class frmAddUpdateEmployee : Form
    {
        public frmAddUpdateEmployee(int employeeID)
        {
            InitializeComponent();

            BindData();

            SetState(employeeID);
        }

        private void BindData()
        {
            BindCompany();
            BindDepartment();
            BindWorkingCalendar();
        }

        private void BindCompany()
        {
            throw new NotImplementedException();
        }

        private void BindDepartment()
        {
            throw new NotImplementedException();
        }

        private void BindWorkingCalendar()
        {
            throw new NotImplementedException();
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

        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTerminal_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveTerminal_Click(object sender, EventArgs e)
        {

        }
    }
}
