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
    public partial class ucDepartmentForm : UserControl
    {
        private IDataController dtCtrl;
        private List<Department> departmentList;
        private string curExpandNodeName = null;

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
                tnode.Name = "c" + value.ToString();
                BindNodes(value, tnode, true);
                tvDepartment.Nodes.Add(tnode);
            }

            if (!string.IsNullOrEmpty(curExpandNodeName))
            {
                TreeNode[] nodes = tvDepartment.Nodes.Find(curExpandNodeName, true);
                if (nodes.Length > 0)
                {
                    TreeNode node = nodes[0];
                    node.Expand();
                    while (node.Parent != null)
                    {
                        node = node.Parent;
                        node.Expand();
                    }
                }
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
                tnode.Name = "d"+value.ToString();
                BindNodes(value, tnode, false);
                parentNode.Nodes.Add(tnode);
            }
        }

        private void tvDepartment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = tvDepartment.GetNodeAt(e.Location);
                if (node != null && node.Parent != null)
                {
                    node.TreeView.SelectedNode = node;
                    curExpandNodeName = node.Parent.Name;
                    cmsTreeAction.Show(tvDepartment, e.Location);
                }
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
            DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dlogRs.ToString().Equals("Yes"))
            {
                int DepartmentID = (int)tvDepartment.SelectedNode.Tag;
                if (DepartmentID == 1)
                {
                    MessageBox.Show("Can not delete default value!");
                    return;
                }
                bool rs = dtCtrl.DeleteDepartment(DepartmentID);
                if (rs)
                {
                    BindTree();
                    BindDepartment();
                }
            }
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Department department = GetDepartmentUserInput();
            if (department == null)
                return;

            bool acctionSucess = false;
            if (btSubmit.Tag == null)
            {
                int id = dtCtrl.AddDepartment(department);
                if (id > 0)
                    acctionSucess = true;

                MessageBox.Show(id > 1 ? "sucessfull" : "error");
            }
            else
            {
                int departmentID = (int)btSubmit.Tag;
                department.ID = departmentID;
                bool rs = dtCtrl.UpdateDepartment(department);
                if (rs)
                    acctionSucess = true;

                MessageBox.Show(rs ? "sucessfull" : "error");
            }
            if (acctionSucess)
            {
                LoadForm(0, (int)cbCompany.SelectedValue, 0, "");
                BindTree();
                BindDepartment();
            }
        }

        private Department GetDepartmentUserInput()
        {
            object oCompany = cbCompany.SelectedValue;
            object oDepartment = cbDepartment.SelectedValue;
            string departmentName = tbDepartmentName.Text;
            bool isValid = true;

            if (oCompany == null && oDepartment == null)
            {
                MessageBox.Show("Invalid user input");
                isValid = false;
            }

            if (string.IsNullOrEmpty(departmentName))
            {
                errProviders.SetError(tbDepartmentName, "Enter Department Name");
                isValid = false;
            }

            if (!isValid)
                return null;

            Department department = new Department();

            department.CompanyID = (int)oCompany;
            department.SupDepartmentID = (int)oDepartment;
            department.Name = departmentName;

            return department;
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
            if (cbCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbCompany.SelectedValue;
                List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
                Department department = new Department();
                department.ID = 0;
                department.Name = "Root";
                departmentList.Insert(0, department);
                cbDepartment.DataSource = departmentList;
            }
        }

        private void LoadForm(int DepartmentID, int CompanyID, int SupDepartmentID, string DepartmentName)
        {
            errProviders.Clear();

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

        private void tvDepartment_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            
        }

        private void tvDepartment_AfterExpand(object sender, TreeViewEventArgs e)
        {
            curExpandNodeName = e.Node.Name;
        }
    }
}