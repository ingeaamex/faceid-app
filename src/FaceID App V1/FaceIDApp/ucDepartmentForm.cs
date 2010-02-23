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
        private IDataController _dtCtrl;
        private List<Department> _departmentList;
        private string _curExpandNodeName = null;

        public ucDepartmentForm()
        {
            InitializeComponent();

            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
            BindCompany();
            BindDepartment();
            BindTree();

            LoadForm(0, (int)cbxCompany.SelectedValue, 0, "");
        }

        private void BindTree()
        {
            tvDepartment.Nodes.Clear();
            List<Company> companyList = _dtCtrl.GetCompanyList();
            _departmentList = _dtCtrl.GetDepartmentList();

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

            if (!string.IsNullOrEmpty(_curExpandNodeName))
            {
                TreeNode[] nodes = tvDepartment.Nodes.Find(_curExpandNodeName, true);
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

            if (isFirst)
                departmentGroup = _departmentList.FindAll(
                    delegate(Department department)
                    {
                        return department.CompanyID == parentValue && department.SupDepartmentID == 0;
                    }
                    );
            else
                departmentGroup = _departmentList.FindAll(
                    delegate(Department department)
                    {
                        return department.SupDepartmentID == parentValue;
                    }
                    );
            foreach (Department department in departmentGroup)
            {
                string text = department.Name;
                int value = department.ID;
                TreeNode tnode = new TreeNode(text);
                tnode.Tag = value;
                tnode.Name = "d" + value.ToString();
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
                    _curExpandNodeName = node.Parent.Name;
                    cmsTreeAction.Show(tvDepartment, e.Location);
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DepartmentID = (int)tvDepartment.SelectedNode.Tag;
            Department department = _dtCtrl.GetDepartment(DepartmentID);

            if (department != null)
            {
                int companyID = department.CompanyID;
                int supDepartmentID = department.SupDepartmentID;
                string departmentName = department.Name;
                LoadForm(DepartmentID, companyID, supDepartmentID, departmentName);
            }
            else
            {
                MessageBox.Show("Department not found or has been deleted.");
                BindTree();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.Confirm("Are you sure you want to delete this department? This cannot be undone.") == false)
            {
                return;
            }

            int departmentID = (int)tvDepartment.SelectedNode.Tag;
            Department department = _dtCtrl.GetDepartment(departmentID);
            if (department == null)
            {
                MessageBox.Show("Department not found.");
                BindTree();
                return;
            }

            //check if department is default
            if (departmentID == 1)
            {
                MessageBox.Show("Default department must not be deleted");
                return;
            }

            //check if department is empty
            if (_dtCtrl.GetEmployeeList(department.CompanyID, department.ID).Count > 0)
            {
                MessageBox.Show("Department is in use and can not be deleted.");
                return;
            }

            if (_dtCtrl.DeleteDepartment(departmentID) == false)
            {
                MessageBox.Show("Department not found or has already been deleted.");
                return;
            }
            else
            {
                MessageBox.Show("Department deleted.");
                BindTree();
                BindDepartment();
            }
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Department department = GetDepartmentUserInput();

            if (department == null)
                return;

            bool acctionSucess = false;

            if ((int)btnSubmit.Tag <= 0) //add
            {
                int id = _dtCtrl.AddDepartment(department);
                acctionSucess = id > 0;

                if (acctionSucess)
                {
                    MessageBox.Show("Department added.");
                }
                else
                {
                    MessageBox.Show("There has been an error. Please try again.");
                }
            }
            else //update
            {
                int departmentID = (int)btnSubmit.Tag;
                department.ID = departmentID;
                acctionSucess = _dtCtrl.UpdateDepartment(department);

                if (acctionSucess)
                {
                    MessageBox.Show("Department updated.");
                }
                else
                {
                    MessageBox.Show("There has been an error. Please try again.");
                }
            }

            if (acctionSucess)
            {
                LoadForm(0, (int)cbxCompany.SelectedValue, 0, "");
                BindTree();
                BindDepartment();
            }
        }

        private Department GetDepartmentUserInput()
        {
            object oCompanyID = cbxCompany.SelectedValue;
            object oSupDepartmentID = cbxSupDepartment.SelectedValue;
            string departmentName = txtDepartmentName.Text;

            if (oCompanyID == null && oSupDepartmentID == null)
            {
                MessageBox.Show("Please select company and department.");
                return null;
            }
            else //check sup deparment
            {
                if (btnSubmit.Tag != null)
                {
                    if ((int)oSupDepartmentID == (int)btnSubmit.Tag)
                    {
                        MessageBox.Show("Department can not be a subordinate of itself.");
                        return null;
                    }
                }
            }

            if (string.IsNullOrEmpty(departmentName)) //check empty name
            {
                errProviders.SetError(txtDepartmentName, "Please enter department name.");
                return null;
            }
            else //check duplicated name
            {
                Department depWithSameName = _dtCtrl.GetDepartment(departmentName);
                
                if (depWithSameName != null && btnSubmit.Tag != null)
                {
                    if (depWithSameName.ID != (int)btnSubmit.Tag)
                    {
                        MessageBox.Show("This name has been used by another Department. Please choose a different name.");
                        return null;
                    }
                }
            }

            Department department = new Department();

            department.CompanyID = (int)oCompanyID;
            department.SupDepartmentID = (int)oSupDepartmentID;
            department.Name = departmentName;

            return department;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            LoadForm(0, (int)cbxCompany.SelectedValue, 0, "");
        }

        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            cbxCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbxCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbxCompany.SelectedValue;
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);
                Department department = new Department();
                department.ID = 0;
                department.Name = "Root";
                departmentList.Insert(0, department);
                cbxSupDepartment.DataSource = departmentList;
            }
        }

        private void LoadForm(int departmentID, int companyID, int supDepartmentID, string departmentName)
        {
            errProviders.Clear();

            if (departmentID > 0) //update
            {
                cbxCompany.SelectedValue = companyID;
                cbxSupDepartment.SelectedValue = supDepartmentID;

                groupBoxDepartment.Text = "Update a Department";
                btnSubmit.Text = "Update";
                btnSubmit.Tag = departmentID;
                txtDepartmentName.Text = departmentName;
            }
            else //add
            {
                groupBoxDepartment.Text = "Add a Sub Department";
                btnSubmit.Text = "Add";
                btnSubmit.Tag = -1;
                txtDepartmentName.Text = "";
            }
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void tvDepartment_AfterExpand(object sender, TreeViewEventArgs e)
        {
            _curExpandNodeName = e.Node.Name;
        }
    }
}