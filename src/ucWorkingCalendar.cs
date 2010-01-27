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
            //dgvWorkingCalendar.Rows.Clear();

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

        private void btnUpdateWorkingCalendar_Click(object sender, EventArgs e)
        {
            int workingCalendarID = Convert.ToInt16(dgvWorkingCalendar.SelectedRows[0].Cells[0].Value);

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

        private void btnDeleteWorkingCalendar_Click(object sender, EventArgs e)
        {
            try
            {
                int workingCalendarID = Convert.ToInt16(dgvWorkingCalendar.SelectedRows[0].Cells[0].Value);
                if (workingCalendarID < 0)
                {
                    MessageBox.Show("No working calendar is selected.");
                }
                else
                {
                    _dtCtrl.DeleteWorkingCalendar(workingCalendarID);

                    MessageBox.Show("Working Calendar has been deleted successfully.");
                    BindWorkingCalendar();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again");
            }
        }

        private void dgvWorkingCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
