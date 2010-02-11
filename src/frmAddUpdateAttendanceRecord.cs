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
    public partial class frmAddUpdateAttendanceRecord : Form
    {
        private IDataController _dtCtrl;
        private int _attRecordID = 0;
        private string _seperator = " - ";

        public frmAddUpdateAttendanceRecord(int attRecord)
        {
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();

            BindEmployeeNumber();

            SetState(attRecord);
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

        private void SetState(int attRecord)
        {
            if (attRecord <= 0)//add
            {
                this.Text = "Add New Attendance Record";
                lbHeaderAction.Text = "Add New Attendance Record";
                btnAdd.Visible = true;
                btnUpdate.Visible = false;

                InitEmployeeNameAutoComplete();
            }
            else//update
            {
                this.Text = "Update Attendance Record";
                lbHeaderAction.Text = "Update Attendance Record";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;

                cbxEmployeeNumber.Enabled = false;
                txtEmployeeName.Enabled = false;

                BindAttRecordData(attRecord);
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

        private AttendanceRecord GetAttRecordUserInput()
        {
            AttendanceRecord attRecord = new AttendanceRecord();
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

            DateTime dAttDate = (DateTime)dtpAttDate.Value;
            DateTime dAttTime = (DateTime)dtpAttTime.Value;

            dAttDate = new DateTime(dAttDate.Year, dAttDate.Month, dAttDate.Day, dAttTime.Hour, dAttTime.Minute, dAttTime.Second);
            string sNote = txtNote.Text;

            attRecord.EmployeeNumber = employeeNumber;
            attRecord.Note = sNote;
            attRecord.Time = dAttDate;

            return attRecord;
        }

        private void BindAttRecordData(int attRecord)
        {
            _attRecordID = attRecord;

            AttendanceRecord attendanceRecord = _dtCtrl.GetAttendanceRecord(attRecord);

            if (attendanceRecord == null)
            {
                MessageBox.Show("Record not found or has been deleted.");
                this.Close();
            }

            Employee employee = _dtCtrl.GetEmployeeByEmployeeNumber(attendanceRecord.EmployeeNumber);

            if (employee == null)
            {
                MessageBox.Show("Employee not found or has been deleted.");
                this.Close();
            }

            cbxEmployeeNumber.SelectedValue = employee.EmployeeNumber;
            txtEmployeeName.Text = employee.FirstName + " " + employee.LastName.ToUpper() + _seperator + employee.EmployeeNumber;

            txtNote.Text = attendanceRecord.Note;
            dtpAttDate.Value = attendanceRecord.Time;
            dtpAttTime.Value = attendanceRecord.Time;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AttendanceRecord attRecord = GetAttRecordUserInput();
            if (attRecord == null)
                return;

            //attRecord.PhotoData = "";
            bool ors = _dtCtrl.AddAttendanceRecord(attRecord) > 0;
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
            AttendanceRecord attRecord = GetAttRecordUserInput();

            if (attRecord == null)
                return;

            attRecord.ID = _attRecordID;

            bool ors = _dtCtrl.UpdateAttendanceRecord(attRecord);
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
