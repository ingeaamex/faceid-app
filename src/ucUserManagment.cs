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
        private int _employeeNumber = -1;

        public ucUserManagment()
        {
            InitializeComponent();
            BindEmployeeNumber();
            BindUser();

            SetState(-1);
        }

        private void BindUser()
        {
            throw new NotImplementedException();
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
                cbxEmployeeNumber.DisplayMember = "ID";
                cbxEmployeeNumber.ValueMember = "ID";

                foreach (EmployeeNumber employeeNumber in employeeNumberList)
                {
                    ListItem listItem = new ListItem(employeeNumber.ID, employeeNumber.ID);
                    cbxEmployeeNumber.Items.Add(listItem);
                }
            }
        }

        private void SetState(int employeeNumber)
        {
            if (employeeNumber <= 0) //add
            {
                gbxAddUpdateUser.Text = "Add new User";
                btnAddUpdateUser.Text = "Add";
            }
            else //update
            {
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
            AddUpdateUser(_employeeNumber);
        }

        private void AddUpdateUser(int employeeNumber)
        {
            try
            {
                if (ValidatePassword() == false)
                {
                    return;
                }

                FaceIDUser fUser = new FaceIDUser();
                GetUserProperies(ref fUser);

                if (employeeNumber <= 0) //add
                {
                    if (_dtCtrl.IsFaceIDUser(employeeNumber))
                    {
                        throw new Exception("This employee has already been added as an user");
                        return;
                    }

                    if (_dtCtrl.AddFaceIDUser(fUser) > 0)
                    {
                        MessageBox.Show("This employee has been added as an user succesfully.");
                    }
                }
                else
                {
                    fUser.EmployeeNumber = employeeNumber;

                    if (_dtCtrl.UpdateFaceIDUser(fUser))
                    {
                        MessageBox.Show("This user has been updated succesfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There's been an error: " + ex.Message + ". Please try again.");
            }

            BindUser();
        }

        private bool ValidatePassword()
        {
            throw new NotImplementedException();
        }
    }
}
