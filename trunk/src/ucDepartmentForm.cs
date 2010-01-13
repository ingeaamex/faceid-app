using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDpp.Business;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
namespace FaceIDpp
{
    public partial class ucDepartmentForm : UserControl
    {
        private IDataController dtCtrl;
        private List<Department> departmentList;
        public ucDepartmentForm()
        {
            InitializeComponent();

            dtCtrl = LocalDataController.Instance;
            BindCompany();
            BindDepartment();
            BindTree();
        }

        private void BindTree()
        {
            tvDepartment.Nodes.Clear();
            List<Company> companyList = dtCtrl.GetCompanyList();
            departmentList = dtCtrl.GetDepartmentList();

            foreach (Company company in companyList)
            {
                string text = company.Name;
                int value = company.ID;
                TreeNode tnode = new TreeNode(text);
                tnode.Tag = value;
                BindNodes(value, tnode, true);
                tvDepartment.Nodes.Add(tnode);
            }
        }

        private void BindNodes(int parentValue, TreeNode parentNode, bool isFirst)
        {
            List<Department> departmentGroup = null;

            if(isFirst)
            departmentGroup = departmentList.FindAll(
                delegate(Department department)
                {
                    return department.CompanyID == parentValue && department.SupDepartmentID == 0;
                }
                );
            else
                departmentGroup = departmentList.FindAll(
                    delegate(Department department)
                    {
                        return department.SupDepartmentID == parentValue;
                    }
                    );
            foreach(Department department in departmentGroup)
            {
                string text = department.Name;
                int value = department.ID;
                TreeNode tnode = new TreeNode(text);
                tnode.Tag = value;
                BindNodes(value, tnode, false);
                parentNode.Nodes.Add(tnode);
            }
        }

        private void tvDepartment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = tvDepartment.GetNodeAt(e.Location);

                if (node != null && tvDepartment.SelectedNode.Parent != null)
                    cmsTreeAction.Show(tvDepartment, e.Location);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DepartmentID = (int)tvDepartment.SelectedNode.Tag;
            Department department = dtCtrl.GetDepartment(DepartmentID);
            if (department != null)
            {
                int CompanyID = department.CompanyID;
                int SupDepartmentID = department.SupDepartmentID;
                string DepartmentName = department.Name;
                LoadForm(DepartmentID, CompanyID, SupDepartmentID, DepartmentName);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DepartmentID = (int)tvDepartment.SelectedNode.Tag;
            bool rs = dtCtrl.DeleteDepartment(DepartmentID);
            BindTree();
            BindDepartment();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.CompanyID = (int)cbCompany.SelectedValue;
            department.SupDepartmentID = (int)cbDepartment.SelectedValue;
            department.Name = tbDepartmentName.Text;

            if (btSubmit.Tag == null)
            {
                int id = dtCtrl.AddDepartment(department);
            }
            else
            {
                int DepartmentID = (int)btSubmit.Tag;
                department.ID = DepartmentID;
                bool rs = dtCtrl.UpdateDepartment(department);
            }
            BindTree();
            BindDepartment();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadForm(0, (int)cbCompany.SelectedValue, 0, "");
        }

        private void BindCompany()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
            cbCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            int CompanyID = (int)cbCompany.SelectedValue;
            List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
            Department department= new Department();
            department.ID = 0;
            department.Name = "";
            departmentList.Insert(0, department);
            cbDepartment.DataSource = departmentList;
        }

        private void LoadForm(int DepartmentID, int CompanyID, int SupDepartmentID, string DepartmentName)
        {
            tbDepartmentName.Text = DepartmentName;
            if (DepartmentID > 0)
            {
                cbCompany.SelectedValue = CompanyID;
                cbDepartment.SelectedValue = SupDepartmentID;

                groupBoxDepartment.Text = "Update a Department";
                btSubmit.Text = "Update";
                btSubmit.Tag = DepartmentID;
            }
            else
            {
                groupBoxDepartment.Text = "Add a Department";
                btSubmit.Text = "Add";
                btSubmit.Tag = null;
            }
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }
    }
}