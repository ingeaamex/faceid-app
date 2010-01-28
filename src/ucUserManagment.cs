using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class ucUserManagment : UserControl
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private int _rowIndex = 0;
        private bool _update = false;

        public ucUserManagment()
        {
            InitializeComponent();
            BindUser();
            BindEmployeeNumber();

            SetState(-1);
        }

        private void BindUser()
        {
            dgvUser.AutoGenerateColumns = false;
            dgvUser.DataSource = _dtCtrl.GetFaceIDUserList();
        }

        private void BindEmployeeNumber()
        {
            List<EmployeeNumber> employeeNumberList = _dtCtrl.GetEmployeeNumberList();

            if (employeeNumberList.Count == 0)
            {
                btnAddUpdateUser.Enabled = false;
                MessageBox.Show("There's no employee to be added as user. Please add an employee first.");
            }
            else
            {
                cbxEmployeeNumber.DisplayMember = "Name";
                cbxEmployeeNumber.ValueMember = "Value";

                foreach (EmployeeNumber employeeNumber in employeeNumberList)
                {
                    ListItem listItem = new ListItem(employeeNumber.ID, employeeNumber.ID);
                    cbxEmployeeNumber.Items.Add(listItem);
                }

                cbxEmployeeNumber.SelectedIndex = 1;
            }
        }

        private void SetState(int employeeNumber)
        {
            if (employeeNumber <= 0) //add
            {
                _update = false;
                cbxEmployeeNumber.Enabled = true;
                if (cbxEmployeeNumber.Items.Count > 0)
                    cbxEmployeeNumber.SelectedIndex = 1;
                else
                    cbxEmployeeNumber.SelectedIndex = -1;

                txtPassword.Text = "";
                txtRetypePassword.Text = "";
                chbAttendanceManagement.Checked = false;
                chbCompanyDepartmentManagement.Checked = false;
                chbEmployeeManagement.Checked = false;
                chbTerminalManagement.Checked = false;
                chbUserManagement.Checked = false;
                chbWorkingCalendarManagement.Checked = false;

                gbxAddUpdateUser.Text = "Add new User";
                btnAddUpdateUser.Text = "Add";


            }
            else //update
            {
                _update = true;
                cbxEmployeeNumber.Enabled = false;

                gbxAddUpdateUser.Text = "Update User";
                btnAddUpdateUser.Text = "Update";

                LoadUserData(employeeNumber);
            }
        }

        private void LoadUserData(int employeeNumber)
        {
            FaceIDUser fUser = _dtCtrl.GetFaceIDUser(employeeNumber);

            if (fUser == null)
            {
                MessageBox.Show("User does not exist or has been deleted. Please try again.");
            }
            else
            {
                cbxEmployeeNumber.SelectedIndex = cbxEmployeeNumber.FindString(employeeNumber.ToString());

                txtPassword.Text = fUser.Password;
                txtRetypePassword.Text = fUser.Password;

                chbAttendanceManagement.Checked = fUser.AttendanceManagementAccess;
                chbCompanyDepartmentManagement.Checked = fUser.CompanyDepartmentManagementAccess;
                chbEmployeeManagement.Checked = fUser.EmployeeManagementAccess;
                chbTerminalManagement.Checked = fUser.TerminalManagementAccess;
                chbUserManagement.Checked = fUser.UserManagementAccess;
                chbWorkingCalendarManagement.Checked = fUser.WorkingCalendarManagementAccess;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Util.Confirm("Any unsaved data will be lost. Are you sure you want to cancel?"))
                SetState(-1);
        }

        private void GetUserProperies(ref FaceIDUser fUser)
        {
            fUser.EmployeeNumber = Convert.ToInt32(((ListItem)cbxEmployeeNumber.SelectedItem).Value);

            fUser.Password = txtPassword.Text;

            fUser.AttendanceManagementAccess = chbAttendanceManagement.Checked;
            fUser.CompanyDepartmentManagementAccess = chbCompanyDepartmentManagement.Checked;
            fUser.EmployeeManagementAccess = chbEmployeeManagement.Checked;
            fUser.TerminalManagementAccess = chbTerminalManagement.Checked;
            fUser.UserManagementAccess = chbUserManagement.Checked;
            fUser.WorkingCalendarManagementAccess = chbWorkingCalendarManagement.Checked;
        }

        private void btnAddUpdateUser_Click(object sender, EventArgs e)
        {
            AddUpdateUser();
        }

        private void AddUpdateUser()
        {
            try
            {
                if (ValidatePassword() == false)
                {
                    return;
                }

                FaceIDUser fUser = new FaceIDUser();
                GetUserProperies(ref fUser);

                if (_update == false) //add
                {
                    if (_dtCtrl.IsFaceIDUser(fUser.EmployeeNumber))
                    {
                        throw new Exception("This employee has already been added as an user");
                    }

                    if (_dtCtrl.AddFaceIDUser(fUser) > 0)
                    {
                        MessageBox.Show("This employee has been added as an user successfully.");
                    }
                }
                else
                {
                    if (_dtCtrl.UpdateFaceIDUser(fUser))
                    {
                        MessageBox.Show("This user has been updated successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There's been an error: " + ex.Message + ". Please try again.");
                return;
            }

            BindUser();
        }

        private void DeleteUser(int employeeNumber)
        {
            try
            {
                if (Util.Confirm("Are you sure you want to delete this user? This can not be undone."))
                {
                    if (_dtCtrl.DeleteFaceIDUser(employeeNumber))
                    {
                        MessageBox.Show("User has been deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There's been an error: " + ex.Message + ". Please try again.");
                return;
            }

            BindUser();
            
        }

        private bool ValidatePassword()
        {
            string password = txtPassword.Text.Trim();
            string retypePassword = txtRetypePassword.Text.Trim();

            if(string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password");
                return false;
            }
            if(password != retypePassword)
            {
                MessageBox.Show("Your re-typed password does not match. Please try again.");
                return false;
            }

            return true;
        }

        private void dgvUser_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeNumber = Convert.ToInt32(dgvUser.Rows[_rowIndex].Cells[0].Value);
            SetState(employeeNumber);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeNumber = Convert.ToInt32(dgvUser.Rows[_rowIndex].Cells[0].Value);
            DeleteUser(employeeNumber);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmsDgvUser.Close();
        }
    }
}
