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
    public partial class ucWorkingCalendar : UserControl
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private int _rowIndex = -1;

        public ucWorkingCalendar()
        {
            InitializeComponent();

            BindWorkingCalendar();
        }

        private void BindWorkingCalendar()
        {
            List<WorkingCalendar> workingCalendarList = _dtCtrl.GetWorkingCalendarList();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Work on");
            dt.Columns.Add("Working hour");

            foreach (WorkingCalendar workingCalendar in workingCalendarList)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = workingCalendar.ID;
                dr["Name"] = workingCalendar.Name;
                dr["Work on"] = GetWorkOnStr(workingCalendar);
                dr["Working hour"] = workingCalendar.RegularWorkingFrom.ToShortTimeString() + " - " + workingCalendar.RegularWorkingTo.ToShortTimeString();

                dt.Rows.Add(dr);
            }

            dgvWorkingCalendar.AutoGenerateColumns = true;
            dgvWorkingCalendar.Columns.Clear();

            dgvWorkingCalendar.DataSource = dt;
            dgvWorkingCalendar.Columns[0].Visible = false;
        }

        private String GetWorkOnStr(WorkingCalendar workingCalendar)
        {
            string workOnStr = "";

            if (workingCalendar.WorkOnMonday)
                workOnStr += "Mon";
            if (workingCalendar.WorkOnTuesday)
                workOnStr += "Tue";
            if (workingCalendar.WorkOnWednesday)
                workOnStr += "Wed";
            if (workingCalendar.WorkOnThursday)
                workOnStr += "Thu";
            if (workingCalendar.WorkOnFriday)
                workOnStr += "Fri";
            if (workingCalendar.WorkOnSaturday)
                workOnStr += "Sat";
            if (workingCalendar.WorkOnSunday)
                workOnStr += "Sun";

            return workOnStr;
        }

        private void btnAddWorkingCalendar_Click(object sender, EventArgs e)
        {
            new frmAddUpdateWorkingCalendar().ShowDialog(this);
            BindWorkingCalendar();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int workingCalendarID = GetSelectedWorkingCalendarID(); ;
            UpdateWorkingCalendar(workingCalendarID);
        }

        private void UpdateWorkingCalendar(int workingCalendarID)
        {
            if (workingCalendarID < 0)
            {
                MessageBox.Show("No working calendar is selected.");
            }
            else
            {
                new frmAddUpdateWorkingCalendar(workingCalendarID).ShowDialog(this);
                BindWorkingCalendar();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int workingCalendarID = GetSelectedWorkingCalendarID(); ;
            DeleteWorkingCalendar(workingCalendarID);
        }

        private void DeleteWorkingCalendar(int workingCalendarID)
        {
            try
            {
                if (workingCalendarID < 0)
                {
                    MessageBox.Show("Please select a working calendar to delete.");
                    return;
                }

                if (Util.Confirm("Are you sure you want to delete this working calendar? This can not be undone.") == false)
                    return;

                //check if worknig calendar is in use
                if (_dtCtrl.IsWorkingCalendarInUse(workingCalendarID))
                {
                    MessageBox.Show("Please select a working calendar to delete.");
                    return;
                }

                if (_dtCtrl.DeleteWorkingCalendar(workingCalendarID))
                {
                    MessageBox.Show("Working Calendar deleted.");
                }
                else
                {
                    MessageBox.Show("Working Calendar not found or has been deleted.");
                }

                BindWorkingCalendar();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There has been an error. Please try again later. Error detail: " + ex.Message);
            }
        }

        private void dgvWorkingCalendar_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex <= dgvWorkingCalendar.Rows.Count)
            {
                dgvWorkingCalendar.Rows[e.RowIndex].Selected = true;
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int workingCalendarID = GetSelectedWorkingCalendarID(); ;
            PreviewWorkingCalendar(workingCalendarID);
        }

        private int GetSelectedWorkingCalendarID()
        {
            if (_rowIndex >= 0 && _rowIndex < dgvWorkingCalendar.Rows.Count)
                return Convert.ToInt16(dgvWorkingCalendar[dgvWorkingCalendar.Columns["ID"].Index, _rowIndex].Value);
            else
                return -1;
        }

        private void PreviewWorkingCalendar(int workingCalendarID)
        {
            try
            {
                if (workingCalendarID < 0)
                {
                    MessageBox.Show("No working calendar is selected.");
                }
                else
                {
                    new frmPreviewWorkingCalendar(workingCalendarID).ShowDialog(this);
                    BindWorkingCalendar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again.");
            }
        }
    }
}
