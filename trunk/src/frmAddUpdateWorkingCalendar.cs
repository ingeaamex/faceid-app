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
    public partial class frmAddUpdateWorkingCalendar : Form
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private static int _workingCalendarID = -1;
        private Control[] listBreak1, listBreak2, listBreak3;

        public frmAddUpdateWorkingCalendar() : this(-1) { }

        public frmAddUpdateWorkingCalendar(int workingCalendarID)
        {
            InitializeComponent();
            
            BindData();

            _workingCalendarID = workingCalendarID;
            SetState(workingCalendarID);

            listBreak1 = new Control[] { txtBreakName1, nudBreakFromHour1, nudBreakFromMin1, nudBreakToHour1, nudBreakToMin1, cbxBreakPaid1 };
            listBreak2 = new Control[] { txtBreakName2, nudBreakFromHour2, nudBreakFromMin2, nudBreakToHour2, nudBreakToMin2, cbxBreakPaid2 };
            listBreak3 = new Control[] { txtBreakName3, nudBreakFromHour3, nudBreakFromMin3, nudBreakToHour3, nudBreakToMin3, cbxBreakPaid3 };
        }

        private void BindData()
        {
            nudBreakFromHour1.Minimum = 0;
            nudBreakFromHour1.Maximum = 23;

            nudBreakFromHour2.Minimum = 0;
            nudBreakFromHour2.Maximum = 23;

            nudBreakFromHour3.Minimum = 0;
            nudBreakFromHour3.Maximum = 23;

            nudBreakFromMin1.Minimum = 0;
            nudBreakFromMin1.Maximum = 59;

            nudBreakFromMin2.Minimum = 0;
            nudBreakFromMin2.Maximum = 59;

            nudBreakFromMin3.Minimum = 0;
            nudBreakFromMin3.Maximum = 59;

            nudBreakToHour1.Minimum = 0;
            nudBreakToHour1.Maximum = 23;

            nudBreakToHour2.Minimum = 0;
            nudBreakToHour2.Maximum = 23;

            nudBreakToHour3.Minimum = 0;
            nudBreakToHour3.Maximum = 23;

            nudBreakToMin1.Minimum = 0;
            nudBreakToMin1.Maximum = 59;

            nudBreakToMin2.Minimum = 0;
            nudBreakToMin2.Maximum = 59;

            nudBreakToMin3.Minimum = 0;
            nudBreakToMin3.Maximum = 59;

            nudCustomPayPeriod.Minimum = 1;
            nudCustomPayPeriod.Maximum = 30;

            nudHolidayOvertimeHour1.Minimum = 0;
            nudHolidayOvertimeHour1.Maximum = 8;

            nudHolidayOvertimeHour2.Minimum = 0;
            nudHolidayOvertimeHour2.Maximum = 8;

            nudHolidayOvertimeHour3.Minimum = 0;
            nudHolidayOvertimeHour3.Maximum = 8;

            nudHolidayOvertimeHour4.Minimum = 0;
            nudHolidayOvertimeHour4.Maximum = 8;

            nudHolidayRegularHour.Minimum = 1;
            nudHolidayRegularHour.Minimum = 8;

            nudNonWorkDayOvertimeHour1.Minimum = 0;
            nudNonWorkDayOvertimeHour1.Maximum = 8;

            nudNonWorkDayOvertimeHour2.Minimum = 0;
            nudNonWorkDayOvertimeHour2.Maximum = 8;

            nudNonWorkDayOvertimeHour3.Minimum = 0;
            nudNonWorkDayOvertimeHour3.Maximum = 8;

            nudNonWorkDayOvertimeHour4.Minimum = 0;
            nudNonWorkDayOvertimeHour4.Maximum = 8;

            nudNonWorkDayRegularHour.Minimum = 1;
            nudNonWorkDayRegularHour.Minimum = 8;

            nudWorkDayOvertimeHour1.Minimum = 0;
            nudWorkDayOvertimeHour1.Maximum = 8;

            nudWorkDayOvertimeHour2.Minimum = 0;
            nudWorkDayOvertimeHour2.Maximum = 8;

            nudWorkDayOvertimeHour3.Minimum = 0;
            nudWorkDayOvertimeHour3.Maximum = 8;

            nudWorkDayOvertimeHour4.Minimum = 0;
            nudWorkDayOvertimeHour4.Maximum = 8;

            nudWorkDayRegularHour.Minimum = 1;
            nudWorkDayRegularHour.Minimum = 8;

            nudRegularWorkFromHour.Minimum = 0;
            nudRegularWorkFromHour.Maximum = 23;

            nudRegularWorkFromMin.Minimum = 0;
            nudRegularWorkFromMin.Maximum = 59;

            nudRegularWorkToHour.Minimum = 0;
            nudRegularWorkToHour.Maximum = 23;

            nudRegularWorkToMin.Minimum = 0;
            nudRegularWorkToMin.Maximum = 59;

            AddBreakPaid(cbxBreakPaid1);
            AddBreakPaid(cbxBreakPaid2);
            AddBreakPaid(cbxBreakPaid3);

            AddRate(cbxHolidayOvertimeRate1);
            AddRate(cbxHolidayOvertimeRate2);
            AddRate(cbxHolidayOvertimeRate3);
            AddRate(cbxHolidayOvertimeRate4);
            AddRate(cbxHolidayRegularRate);

            AddRate(cbxNonWorkDayOvertimeRate1);
            AddRate(cbxNonWorkDayOvertimeRate2);
            AddRate(cbxNonWorkDayOvertimeRate3);
            AddRate(cbxNonWorkDayOvertimeRate4);
            AddRate(cbxNonWorkDayRegularRate);

            AddRate(cbxWorkDayOvertimeRate1);
            AddRate(cbxWorkDayOvertimeRate2);
            AddRate(cbxWorkDayOvertimeRate3);
            AddRate(cbxWorkDayOvertimeRate4);
            AddRate(cbxWorkDayRegularRate);
        }

        private void AddRate(ComboBox cbx)
        {
            cbx.ValueMember = "Value";
            cbx.DisplayMember = "Name";
            
            cbx.Items.Add(new Rate(1.00, "100%"));
            cbx.Items.Add(new Rate(1.25, "125%"));
            cbx.Items.Add(new Rate(1.50, "150%"));
            cbx.Items.Add(new Rate(2.00, "200%"));
            cbx.Items.Add(new Rate(3.00, "300%"));

            cbx.Items.Add(new Rate(-1, "Custom"));
        }

        private void AddBreakPaid(ComboBox cbx)
        {
            cbx.Items.Add("Yes");
            cbx.Items.Add("No");
        }

        private void SetState(int workingCalendarID)
        {
            if (workingCalendarID <= 0)//add
            {
                this.Text = "Add New Working Calendar";
            }
            else//update
            {
                this.Text = "Update Working Calendar";

                BindWorkingCalendarData(workingCalendarID);
            }
        }

        private void BindWorkingCalendarData(int workingCalendarID)
        {
            throw new NotImplementedException();

            WorkingCalendar workingCalendar = _dtCtrl.GetWorkingCalendar(workingCalendarID);

            if (workingCalendar == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                txtName.Text = workingCalendar.Name;

                chbMonday.Checked = workingCalendar.WorkOnMonday;
                chbTuesday.Checked = workingCalendar.WorkOnTuesday;
                chbWednesday.Checked = workingCalendar.WorkOnWednesday;
                chbThursday.Checked = workingCalendar.WorkOnThursday;
                chbFriday.Checked = workingCalendar.WorkOnFriday;
                chbSaturday.Checked = workingCalendar.WorkOnSaturday;
                chbSunday.Checked = workingCalendar.WorkOnSunday;

                nudRegularWorkFromHour.Value = workingCalendar.RegularWorkingFrom.Hour;
                nudRegularWorkFromMin.Value = workingCalendar.RegularWorkingFrom.Minute;
                nudRegularWorkToHour.Value = workingCalendar.RegularWorkingTo.Hour;
                nudRegularWorkToMin.Value = workingCalendar.RegularWorkingTo.Minute;

                List<Break> breaks = _dtCtrl.GetBreakByWorkingCalendar(workingCalendarID);

                if (breaks.Count >= 1)
                {
                    Break break1 = breaks[0];
                    EnableBreakControls1(true);

                    txtBreakName1.Text = break1.Name;
                    nudBreakFromHour1.Value = break1.From.Hour;
                    nudBreakFromMin1.Value = break1.From.Minute;
                    nudBreakToHour1.Value = break1.To.Hour;
                    nudBreakToMin1.Value = break1.To.Minute;
                    chbBreak1.Checked = break1.Paid;
                }

                if (breaks.Count >= 2)
                {
                    Break break2 = breaks[1];
                    EnableBreakControls2(true);

                    txtBreakName2.Text = break2.Name;
                    nudBreakFromHour2.Value = break2.From.Hour;
                    nudBreakFromMin2.Value = break2.From.Minute;
                    nudBreakToHour2.Value = break2.To.Hour;
                    nudBreakToMin2.Value = break2.To.Minute;
                    chbBreak2.Checked = break2.Paid;
                }

                if (breaks.Count >= 3)
                {
                    Break break3 = breaks[2];
                    EnableBreakControls3(true);

                    txtBreakName3.Text = break3.Name;
                    nudBreakFromHour3.Value = break3.From.Hour;
                    nudBreakFromMin3.Value = break3.From.Minute;
                    nudBreakToHour3.Value = break3.To.Hour;
                    nudBreakToMin3.Value = break3.To.Minute;
                    chbBreak3.Checked = break3.Paid;
                }
            }
        }

        private void EnableBreakControls1(bool enabled)
        {
            foreach (Control ctrl in listBreak1)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls2(bool enabled)
        {
            foreach (Control ctrl in listBreak2)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls3(bool enabled)
        {
            foreach (Control ctrl in listBreak3)
                ctrl.Enabled = enabled;
        }

        private class Rate
        {
            public Rate(double value, string name)
            {
                this.Value = value;
                this.Name = name;
            }

            public double Value { get; set; }
            public String Name { get; set; }
        }

        private void chbBreak1_CheckedChanged(object sender, EventArgs e)
        {
            EnableBreakControls1(chbBreak1.Checked);
        }

        private void chbBreak2_CheckedChanged(object sender, EventArgs e)
        {
            EnableBreakControls2(chbBreak2.Checked);
        }

        private void chbBreak3_CheckedChanged(object sender, EventArgs e)
        {
            EnableBreakControls3(chbBreak3.Checked);
        }
    }
}
