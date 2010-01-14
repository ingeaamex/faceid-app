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
    public partial class ucCompanyForm : UserControl
    {
        private IDataController dtCtrl;
        public ucCompanyForm()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            LoadData();
        }

        private void LoadData()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
            dgvCompany.AutoGenerateColumns = false;
            dgvCompany.DataSource = companyList;
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dgvCompany.Columns["btEdit"].Index && e.ColumnIndex != dgvCompany.Columns["btDelete"].Index)) return;

            string cName = dgvCompany[0, e.RowIndex].Value.ToString();

            Company company = dtCtrl.GetCompany(cName);

            if (e.ColumnIndex == dgvCompany.Columns["btEdit"].Index)
            {
                LoadForm(company.Name, company.ID);
            }
            else
            {
                DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dlogRs.ToString().Equals("Yes"))
                {
                    List<Department> departments = dtCtrl.GetDepartmentByCompany(company.ID);
                    //check employee!!!
                    if (departments != null && departments.Count > 0)
                    {
                        MessageBox.Show("Company is in used");
                    }
                    else
                    {
                        bool rs = dtCtrl.DeleteCompany(company.ID);
                        MessageBox.Show(rs ? "sucessfull" : "error");
                        if (rs)
                            LoadData();
                    }
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

            tbCompanyName.Text = name;
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
            string cName = tbCompanyName.Text;
            if (string.IsNullOrEmpty(cName))
            {
                errProviders.SetError(tbCompanyName, "Enter Company Name");
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
                int id = dtCtrl.AddCompany(company);
                if (id > 0)
                    acctionSucess = true;

                MessageBox.Show(id > 0 ? "sucessfull" : "error");
            }
            else
            {
                int id = (int)btSubmit.Tag;
                company.ID = id;
                bool rs = dtCtrl.UpdateCompany(company);
                if (rs)
                    acctionSucess = true;

                MessageBox.Show(rs ? "sucessfull" : "error");
            }
            if (acctionSucess)
            {
                LoadData();
                LoadForm("", 0);
            }
        }
    }
}
