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
        private IDataController dtCtrl;
        private int iAttendanceRecordID = 0;
        public frmAddUpdateAttendanceRecord(int attRecord)
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            SetState(attRecord);
        }

        private void SetState(int attRecord)
        {
            if (attRecord <= 0)//add
            {
                this.Text = "Add New Attendance Record";
                lbHeaderAction.Text = "Add New Attendance Record";
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
            else//update
            {
                this.Text = "Update Attendance Record";
                lbHeaderAction.Text = "Update Attendance Record";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                nudEmployeeNumber.Enabled = false;
                txtEmployeeName.Enabled = false;
                BindAttRecordData(attRecord);
            }
        }

        private AttendanceRecord GetAttRecordUserInput()
        {
            AttendanceRecord attRecord = new AttendanceRecord();
            int iEmployeeNumber = Convert.ToInt16(nudEmployeeNumber.Value);

            if (iEmployeeNumber == 0
                || !dtCtrl.IsExistEmployeeNumber(iEmployeeNumber))
            {
                errProviders.SetError(nudEmployeeNumber, "Employee number does not exist");
                return null;
            }

            DateTime dAttDate = (DateTime)dtpAttDate.Value;
            int hour = Convert.ToInt16(nudAttHour.Value);
            int minute = Convert.ToInt16(nudAttMin.Value);
            int second = Convert.ToInt16(nudAttSec.Value);
            dAttDate = new DateTime(dAttDate.Year, dAttDate.Month, dAttDate.Day, hour, minute, second);
            string sNote = txtNote.Text;

            attRecord.EmployeeNumber = iEmployeeNumber;
            attRecord.Note = sNote;
            attRecord.Time = dAttDate;
            return attRecord;
        }

        private void BindAttRecordData(int attRecord)
        {
            iAttendanceRecordID = attRecord;
            AttendanceRecord attendanceRecord = dtCtrl.GetAttendanceRecord(attRecord);
            nudEmployeeNumber.Value = attendanceRecord.EmployeeNumber;
            txtNote.Text = attendanceRecord.Note;
            DateTime dt = attendanceRecord.Time;
            dtpAttDate.Value = dt;
            nudAttHour.Value = dt.Hour;
            nudAttMin.Value = dt.Minute;
            nudAttSec.Value = dt.Second;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AttendanceRecord attRecord = GetAttRecordUserInput();
            if (attRecord == null)
                return;

            attRecord.PhotoData = "";
            bool ors = dtCtrl.AddAttendanceRecord(attRecord);
            MessageBox.Show(ors ? "successful" : "error");
            if (ors)
            {
                RefeshOwner();
                this.Close();
            }
        }

        private void RefeshOwner()
        {
            Control[] ctr = this.Owner.Controls.Find("btnView", true);
            if (ctr != null && ctr.Length > 0)
            {
                Button btn = (Button)ctr[0];
                btn.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AttendanceRecord attRecord = GetAttRecordUserInput();
            if (attRecord == null)
                return;

            attRecord.ID = iAttendanceRecordID;

            bool ors = dtCtrl.UpdateAttendanceRecord(attRecord);
            MessageBox.Show(ors ? "successful" : "error");
            if (ors)
            {
                RefeshOwner();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            //txtEmployeeName.Text;
        }
    }
}
