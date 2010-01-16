using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class frmAddUpdateWorkingCalendar : Form
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        public frmAddUpdateWorkingCalendar() : this(-1) { }

        public frmAddUpdateWorkingCalendar(int workingCalendarID)
        {
            InitializeComponent();

            BindData();

            SetState(workingCalendarID);
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
    }
}
