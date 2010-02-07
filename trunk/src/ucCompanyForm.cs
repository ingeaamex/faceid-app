using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
using System.Collections;

namespace FaceIDAppVBEta
{
    public partial class ucCompanyForm : UserControl
    {
        private IDataController _dtCtrl;
        private int _rowIndex = -1;

        public ucCompanyForm()
        {
            InitializeComponent();
            _dtCtrl = LocalDataController.Instance;
            LoadData();
        }

        private void LoadData()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList(true);
            List<Department> departmentList = _dtCtrl.GetDepartmentList();
            List<Employee> employeeList = _dtCtrl.GetEmployeeList();

            DataTable dt = new DataTable();
            dt.Columns.Add("CompanyID");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("NoOfDepartments");
            dt.Columns.Add("NoOfEmployees");

            foreach (Company company in companyList)
            {
                DataRow dr = dt.NewRow();
                dr["CompanyID"] = company.ID;
                dr["CompanyName"] = company.Name;

                int noOfDeparments = 0, noOfEmployees = 0;
                GetCompanyDetails(company.ID, ref departmentList, ref employeeList, ref noOfDeparments, ref noOfEmployees);

                dr["NoOfDepartments"] = noOfDeparments;
                dr["NoOfEmployees"] = noOfEmployees;

                dt.Rows.Add(dr);
            }

            dgvCompany.AutoGenerateColumns = false;
            dgvCompany.DataSource = dt;
        }

        private void GetCompanyDetails(int companyID, ref List<Department> departmentList, ref List<Employee> employeeList, ref int noOfDeparments, ref int noOfEmployees)
        {
            Hashtable countedDepartmentList = new Hashtable();

            foreach (Department department in departmentList)
            {
                if (countedDepartmentList.ContainsKey(department.ID))
                    continue;

                if (department.CompanyID == companyID)
                {
                    noOfDeparments++;
                    countedDepartmentList.Add(department.ID, null);
                    GetNoOfEmployees(department.ID, ref employeeList, ref noOfEmployees);
                    CountSubDepartment(department.ID, departmentList, ref employeeList, ref noOfDeparments, ref noOfEmployees, ref countedDepartmentList);
                }
            }
        }

        private void CountSubDepartment(int supDepartmentID, List<Department> departmentList, ref List<Employee> employeeList, ref int noOfDeparments, ref int noOfEmployees, ref Hashtable countedDepartmentList)
        {
            foreach (Department department in departmentList)
            {
                if (countedDepartmentList.ContainsKey(department.ID))
                    continue;

                if (department.SupDepartmentID == supDepartmentID)
                {
                    noOfDeparments++;
                    countedDepartmentList.Add(department.ID, null);
                    GetNoOfEmployees(department.ID, ref employeeList, ref noOfEmployees);
                    CountSubDepartment(department.ID, departmentList, ref employeeList, ref noOfDeparments, ref noOfEmployees, ref countedDepartmentList);
                }
            }
        }

        private void GetNoOfEmployees(int deparmentID, ref List<Employee> employeeList, ref int noOfEmployees)
        {
            for (int i = employeeList.Count - 1; i >= 0; i--)
            {
                Employee employee = employeeList[i];
                if (employee.DepartmentID == deparmentID)
                {
                    employeeList.RemoveAt(i);
                    noOfEmployees++;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadForm("", 0);
        }

        private void LoadForm(string name, int id)
        {
            errProviders.Clear();

            txtCompanyName.Text = name;
            if (id > 0)
            {
                gBoxCompanyACtion.Text = "Update a Company";
                btSubmit.Text = "Update";
                btSubmit.Tag = id;
            }
            else
            {
                gBoxCompanyACtion.Text = "Add a new Company";
                btSubmit.Text = "Add";
                btSubmit.Tag = null;
            }
        }

        private Company GetCompanyUserInput()
        {
            string cName = txtCompanyName.Text;

            if (string.IsNullOrEmpty(cName))
            {
                errProviders.SetError(txtCompanyName, "Please enter company name");
                return null;
            }

            Company company = new Company();
            company.Name = cName;

            return company;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Company company = GetCompanyUserInput();

            if (company == null)
                return;

            bool acctionSucess = false;

            if (btSubmit.Tag == null)
            {
                int id = _dtCtrl.AddCompany(company);
                acctionSucess = id > 0;

                if (acctionSucess)
                {
                    MessageBox.Show("Company added.");
                }
                else
                {
                    MessageBox.Show("There has been an error. Please try again.");
                }
            }
            else
            {
                int id = (int)btSubmit.Tag;
                company.ID = id;
                acctionSucess = _dtCtrl.UpdateCompany(company);

                if (acctionSucess)
                {
                    MessageBox.Show("Company updated.");
                }
                else
                {
                    MessageBox.Show("There has been an error. Please try again.");
                }
            }
            if (acctionSucess)
            {
                LoadData();
                LoadForm("", 0);
            }
        }

        private void dgvCompany_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;

            if (_rowIndex >= 0 && _rowIndex < dgvCompany.Rows.Count)
            {
                dgvCompany.Rows[_rowIndex].Selected = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int companyID = GetSelectedCompanyID();

            if (companyID < 0)
            {
                MessageBox.Show("Please select a company to edit.");
            }

            Company company = _dtCtrl.GetCompany(companyID);

            if (company == null)
            {
                MessageBox.Show("Company not found or has been deleted.");
            }
            else
            {
                LoadForm(company.Name, company.ID);
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int companyID = GetSelectedCompanyID();
            
            if (companyID < 0)
            {
                MessageBox.Show("Please select a company to delete.");
                return;
            }

            //confim deleting company
            if (Util.Confirm("Are you sure you want to delete this company. This cannot be undone.") == false)
            {
                return;
            }

            //check is company is default company
            if (companyID == 1)
            {
                MessageBox.Show("Default company must not be deleted.");
                return;
            }

            //check if company is empty
            if (_dtCtrl.GetDepartmentByCompany(companyID,false).Count > 0)
            {
                MessageBox.Show("Company is in use and can not be deleted.");
                return;
            }

            if (_dtCtrl.DeleteCompany(companyID) == false)
            {
                MessageBox.Show("Company not found or has already been deleted.");
            }
            else
            {
                MessageBox.Show("Company deleted.");
            }

            LoadData();
        }

        private int GetSelectedCompanyID()
        {
            if (_rowIndex >= 0 && _rowIndex < dgvCompany.Rows.Count)
            {
                return Convert.ToInt16(dgvCompany[dgvCompany.Columns["CompanyID"].Index, _rowIndex].Value);
            }
            else
            {
                return -1;
            }
        }
    }
}
