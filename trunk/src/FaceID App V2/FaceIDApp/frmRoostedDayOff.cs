using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class frmRoostedDayOff : Form
    {
        private IDataController _dtCtrl;
        private int _rDayOffId = 0;
        private string _seperator = " - ";

        public frmRoostedDayOff(int rDayOffId)
        {
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();

            BindEmployeeNumber();

            SetState(rDayOffId);
        }

        private void BindEmployeeNumber()
        {
            List<Employee> employeeList = _dtCtrl.GetEmployeeList();

            cbxEmployeeNumber.DisplayMember = "EmployeeNumber";
            cbxEmployeeNumber.ValueMember = "EmployeeNumber";

            cbxEmployeeNumber.DataSource = employeeList;

            if (cbxEmployeeNumber.Items.Count > 0)
                cbxEmployeeNumber.SelectedIndex = 0;
        }

        private void SetState(int rDayOffId)
        {
            if (rDayOffId <= 0)//add
            {
                this.Text = "Add New Roosted days off";
                lbHeaderAction.Text = "Add New Roosted days off";
                btnAdd.Visible = true;
                btnUpdate.Visible = false;

                InitEmployeeNameAutoComplete();
            }
            else//update
            {
                this.Text = "Update Roosted days off";
                lbHeaderAction.Text = "Update Roosted days off";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;

                cbxEmployeeNumber.Enabled = false;
                txtEmployeeName.Enabled = false;

                BindRoostedDayOffData(rDayOffId);
            }
        }

        private void InitEmployeeNameAutoComplete()
        {
            List<Employee> employeeList = _dtCtrl.GetEmployeeList();

            txtEmployeeName.AutoCompleteCustomSource.Clear();

            foreach (Employee employee in employeeList)
            {
                txtEmployeeName.AutoCompleteCustomSource.Add(employee.FirstName + " " + employee.LastName.ToUpper() + _seperator + employee.EmployeeNumber);
                txtEmployeeName.AutoCompleteCustomSource.Add(employee.LastName.ToUpper() + " " + employee.FirstName + _seperator + employee.EmployeeNumber);
                txtEmployeeName.AutoCompleteCustomSource.Add(employee.EmployeeNumber + _seperator + employee.FirstName + " " + employee.LastName.ToUpper());
            }
        }

        private RoostedDayOff GetRoostedDayOffUserInput()
        {
            RoostedDayOff rDaysOff = new RoostedDayOff();
            int employeeNumber = 0;

            try
            {
                employeeNumber = Convert.ToInt32(cbxEmployeeNumber.SelectedValue);

                if (employeeNumber <= 0)
                    throw new Exception();
            }
            catch
            {
                errProviders.SetError(cbxEmployeeNumber, "Invalid Employee number.");
                return null;
            }

            DateTime dAttDate = (DateTime)dtpAttDate.Value.Date;
            int totalHours = Convert.ToInt32(txtTotalHours.Text);
            string sNote = txtNote.Text;

            rDaysOff.EmployeeNumber = employeeNumber;
            rDaysOff.Note = sNote;
            rDaysOff.Date = dAttDate;
            rDaysOff.TotalHours = totalHours;

            return rDaysOff;
        }

        private void BindRoostedDayOffData(int rDayOffId)
        {
            _rDayOffId = rDayOffId;

            RoostedDayOff rDayOff = _dtCtrl.GetRoostedDayOff(rDayOffId);

            if (rDayOff == null)
            {
                MessageBox.Show("Record not found or has been deleted.");
                this.Close();
            }

            Employee employee = _dtCtrl.GetEmployeeByEmployeeNumber(rDayOff.EmployeeNumber);

            if (employee == null)
            {
                MessageBox.Show("Employee not found or has been deleted.");
                this.Close();
            }

            cbxEmployeeNumber.SelectedValue = employee.EmployeeNumber;
            txtEmployeeName.Text = employee.FirstName + " " + employee.LastName.ToUpper() + _seperator + employee.EmployeeNumber;

            txtNote.Text = rDayOff.Note;
            dtpAttDate.Value = rDayOff.Date;
            txtTotalHours.Text = rDayOff.TotalHours.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoostedDayOff rDayOff = GetRoostedDayOffUserInput();
            if (rDayOff == null)
                return;
            if (_dtCtrl.IsExistDayRoostedDayOff(rDayOff.EmployeeNumber, rDayOff.Date, 0))
            {
                MessageBox.Show("exist day");

                return;
            }
            bool ors = _dtCtrl.AddRoostedDayOff(rDayOff) > 0;
            MessageBox.Show(ors ? "successful" : "error");
            if (ors)
            {
                RefeshOwner();
                this.Close();
            }
        }

        private void RefeshOwner()
        {
            //call back to parent form
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RoostedDayOff rDayOff = GetRoostedDayOffUserInput();

            if (rDayOff == null)
                return;

            rDayOff.ID = _rDayOffId;

            if (_dtCtrl.IsExistDayRoostedDayOff(rDayOff.EmployeeNumber, rDayOff.Date, rDayOff.ID))
            {
                MessageBox.Show("exist day");

                return;
            }

            bool ors = _dtCtrl.UpdateRoostedDayOff(rDayOff);
            MessageBox.Show(ors ? "successful" : "error");
            if (ors)
            {
                RefeshOwner();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Util.ConfirmCloseForm())
                this.Close();
        }

        private void cbxEmployeeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int employeeNumber = Convert.ToInt32(cbxEmployeeNumber.SelectedValue);
                Employee employee = _dtCtrl.GetEmployeeByEmployeeNumber(employeeNumber);

                if (employee != null)
                {
                    txtEmployeeName.Text = employee.FirstName + " " + employee.LastName;
                }
                else
                {
                    //TODO
                }
            }
            catch { }
        }

        private void txtEmployeeName_Leave(object sender, EventArgs e)
        {
            int iFrom, iTo, employeeNumber = 0;

            iFrom = 0;
            iTo = txtEmployeeName.Text.IndexOf(_seperator);

            try
            {
                employeeNumber = Convert.ToInt32(txtEmployeeName.Text.Substring(iFrom, iTo - iFrom));
            }
            catch { }

            if (employeeNumber == 0)
            {
                iFrom = txtEmployeeName.Text.IndexOf(_seperator);
                iFrom += _seperator.Length;

                iTo = txtEmployeeName.Text.Length;

                try
                {
                    employeeNumber = Convert.ToInt32(txtEmployeeName.Text.Substring(iFrom, iTo - iFrom));
                }
                catch { }
            }

            cbxEmployeeNumber.SelectedValue = employeeNumber;
        }
    }
}