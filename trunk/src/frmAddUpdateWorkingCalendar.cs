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
    public partial class frmAddUpdateWorkingCalendar : Form, ICustomeRateCaller
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        private static int _workingCalendarID = -1;

        private Control[] _listBreak1, _listBreak2, _listBreak3;
        private ComboBox[] _listCbxRate;
        private List<Holiday> _holidayList = new List<Holiday>();

        private ComboBox _selectedComboBox = null;

        public frmAddUpdateWorkingCalendar() : this(-1) { }

        public frmAddUpdateWorkingCalendar(int workingCalendarID)
        {
            InitializeComponent();
            _workingCalendarID = workingCalendarID;

            _listBreak1 = new Control[] { txtBreakName1, dtpBreakFrom1, dtpBreakTo1, cbxBreakPaid1 };
            _listBreak2 = new Control[] { txtBreakName2, dtpBreakFrom2, dtpBreakTo2, cbxBreakPaid2 };
            _listBreak3 = new Control[] { txtBreakName3, dtpBreakFrom3, dtpBreakTo3, cbxBreakPaid3 };

            _listCbxRate = new ComboBox[]{cbxWorkDayRegularRate, cbxWorkDayOvertimeRate1, cbxWorkDayOvertimeRate2, cbxWorkDayOvertimeRate3, cbxWorkDayOvertimeRate4, 
                cbxNonWorkDayRegularRate, cbxNonWorkDayOvertimeRate1, cbxNonWorkDayOvertimeRate2, cbxNonWorkDayOvertimeRate3, cbxNonWorkDayOvertimeRate4, 
                cbxHolidayRegularRate, cbxHolidayOvertimeRate1, cbxHolidayOvertimeRate2, cbxHolidayOvertimeRate3, cbxHolidayOvertimeRate4};

            BindData();
            SetState(workingCalendarID);
        }

        private void BindData()
        {
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

            AddBreakPaid(cbxBreakPaid1);
            AddBreakPaid(cbxBreakPaid2);
            AddBreakPaid(cbxBreakPaid3);

            foreach (ComboBox cbx in _listCbxRate)
            {
                InitComboBoxRate(cbx);
                AddRate(cbx);
            }
        }

        private void InitComboBoxRate(ComboBox cbx)
        {
            cbx.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddRate(ComboBox cbx)
        {
            cbx.ValueMember = "Value";
            cbx.DisplayMember = "Name";

            cbx.Items.Add(new Rate(0.00, "0%"));
            cbx.Items.Add(new Rate(1.00, "100%"));
            cbx.Items.Add(new Rate(1.25, "125%"));
            cbx.Items.Add(new Rate(1.50, "150%"));
            cbx.Items.Add(new Rate(2.00, "200%"));
            cbx.Items.Add(new Rate(3.00, "300%"));

            cbx.Items.Add(new Rate(-1, "Custom Rate"));

            cbx.SelectedIndex = 0;
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
            WorkingCalendar workingCalendar = _dtCtrl.GetWorkingCalendar(workingCalendarID);

            if (workingCalendar == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                txtName.Text = workingCalendar.Name;

                #region Set Working Days
                chbMonday.Checked = workingCalendar.WorkOnMonday;
                chbTuesday.Checked = workingCalendar.WorkOnTuesday;
                chbWednesday.Checked = workingCalendar.WorkOnWednesday;
                chbThursday.Checked = workingCalendar.WorkOnThursday;
                chbFriday.Checked = workingCalendar.WorkOnFriday;
                chbSaturday.Checked = workingCalendar.WorkOnSaturday;
                chbSunday.Checked = workingCalendar.WorkOnSunday;

                dtpRegularWorkFrom.Value = workingCalendar.RegularWorkingFrom;
                dtpRegularWorkTo.Value = workingCalendar.RegularWorkingTo;
                #endregion

                #region Set Break Times
                List<Break> breaks = _dtCtrl.GetBreakByWorkingCalendar(workingCalendarID);

                if (breaks.Count >= 1)
                {
                    Break break1 = breaks[0];
                    EnableBreakControls1(true);

                    txtBreakName1.Text = break1.Name;
                    dtpBreakFrom1.Value = break1.From;
                    dtpBreakTo1.Value = break1.To;
                    chbBreak1.Checked = break1.Paid;
                }

                if (breaks.Count >= 2)
                {
                    Break break2 = breaks[1];
                    EnableBreakControls2(true);

                    txtBreakName2.Text = break2.Name;
                    dtpBreakFrom2.Value = break2.From;
                    dtpBreakTo2.Value = break2.To;
                    chbBreak2.Checked = break2.Paid;
                }

                if (breaks.Count >= 3)
                {
                    Break break3 = breaks[2];
                    EnableBreakControls3(true);

                    txtBreakName3.Text = break3.Name;
                    dtpBreakFrom3.Value = break3.From;
                    dtpBreakTo3.Value = break3.To;
                    chbBreak3.Checked = break3.Paid;
                }
                #endregion

                #region Set Payment Rates
                PaymentRate workingDayPaymentRate = _dtCtrl.GetWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);

                nudWorkDayRegularHour.Value = workingDayPaymentRate.NumberOfRegularHours;
                nudWorkDayOvertimeHour1.Value = workingDayPaymentRate.NumberOfOvertime1;
                nudWorkDayOvertimeHour2.Value = workingDayPaymentRate.NumberOfOvertime2;
                nudWorkDayOvertimeHour3.Value = workingDayPaymentRate.NumberOfOvertime3;
                nudWorkDayOvertimeHour4.Value = workingDayPaymentRate.NumberOfOvertime4;

                Util.SetComboboxSelectedByValue(cbxWorkDayRegularRate, workingDayPaymentRate.RegularRate);
                Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate1, workingDayPaymentRate.OvertimeRate1);
                Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate2, workingDayPaymentRate.OvertimeRate2);
                Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate3, workingDayPaymentRate.OvertimeRate3);
                Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate4, workingDayPaymentRate.OvertimeRate4);

                PaymentRate nonWorkingDayPaymentRate = _dtCtrl.GetNonWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);

                nudNonWorkDayRegularHour.Value = nonWorkingDayPaymentRate.NumberOfRegularHours;
                nudNonWorkDayOvertimeHour1.Value = nonWorkingDayPaymentRate.NumberOfOvertime1;
                nudNonWorkDayOvertimeHour2.Value = nonWorkingDayPaymentRate.NumberOfOvertime2;
                nudNonWorkDayOvertimeHour3.Value = nonWorkingDayPaymentRate.NumberOfOvertime3;
                nudNonWorkDayOvertimeHour4.Value = nonWorkingDayPaymentRate.NumberOfOvertime4;

                Util.SetComboboxSelectedByValue(cbxNonWorkDayRegularRate, nonWorkingDayPaymentRate.RegularRate);
                Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate1, nonWorkingDayPaymentRate.OvertimeRate1);
                Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate2, nonWorkingDayPaymentRate.OvertimeRate2);
                Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate3, nonWorkingDayPaymentRate.OvertimeRate3);
                Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate4, nonWorkingDayPaymentRate.OvertimeRate4);

                PaymentRate holidayPaymentRate = _dtCtrl.GetHolidayPaymentRateByWorkingCalendar(workingCalendarID);

                nudHolidayRegularHour.Value = holidayPaymentRate.NumberOfRegularHours;
                nudHolidayOvertimeHour1.Value = holidayPaymentRate.NumberOfOvertime1;
                nudHolidayOvertimeHour2.Value = holidayPaymentRate.NumberOfOvertime2;
                nudHolidayOvertimeHour3.Value = holidayPaymentRate.NumberOfOvertime3;
                nudHolidayOvertimeHour4.Value = holidayPaymentRate.NumberOfOvertime4;

                Util.SetComboboxSelectedByValue(cbxHolidayRegularRate, holidayPaymentRate.RegularRate);
                Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate1, holidayPaymentRate.OvertimeRate1);
                Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate2, holidayPaymentRate.OvertimeRate2);
                Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate3, holidayPaymentRate.OvertimeRate3);
                Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate4, holidayPaymentRate.OvertimeRate4);
                #endregion

                #region Set Holidays
                List<Holiday> holidayList = _dtCtrl.GetHolidayListByWorkingCalendar(workingCalendarID);
                dgvHoliday.AutoGenerateColumns = false;
                dgvHoliday.DataSource = holidayList;
                #endregion

                #region Set Pay Period
                PayPeriod payPeriod = _dtCtrl.GetPayPeriodByWorkingCalendar(workingCalendarID);
                if (payPeriod == null)//custom Pay Period
                {
                    rbtPayPeriodCustom.Checked = true;
                    nudCustomPayPeriod.Value = workingCalendar.CustomPayPeriod;
                }
                else
                {
                    rbtPayPeriodWeekly.Checked = payPeriod.Name.ToLower() == "weekly";
                    rbtPayPeriodBiweekly.Checked = payPeriod.Name.ToLower() == "bi-weekly";
                    rbtPayPeriodMonthly.Checked = payPeriod.Name.ToLower() == "monthly";
                    rbtPayPeriodHalfmonthly.Checked = payPeriod.Name.ToLower() == "half-monthly";
                }

                dtpPayPeriodStartFrom.Value = workingCalendar.PayPeriodStartFrom;
                #endregion
            }
        }

        private void EnableBreakControls1(bool enabled)
        {
            foreach (Control ctrl in _listBreak1)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls2(bool enabled)
        {
            foreach (Control ctrl in _listBreak2)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls3(bool enabled)
        {
            foreach (Control ctrl in _listBreak3)
                ctrl.Enabled = enabled;
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

        private void btnNext1_Click(object sender, EventArgs e)
        {
            if (ValidateName())
                tabPage2.Show();
        }

        private bool ValidateName()
        {
            string name = txtName.Text.Trim();

            if (name == "")
            {
                MessageBox.Show("Please enter a name for Working Calendar.");
                return false;
            }

            if (_workingCalendarID == -1) //add
            {
                if (_dtCtrl.IsDuplicatedWorkingCalendarName(name) == true)
                {
                    MessageBox.Show("This name has been used by another Working Calendar. Please choose a different name.");
                    return false;
                }
            }
            else
            {
                if (_dtCtrl.IsDuplicatedWorkingCalendarName(name, _workingCalendarID) == true)
                {
                    MessageBox.Show("This name has been used by another Working Calendar. Please choose a different name.");
                    return false;
                }
            }

            return true;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            if (ValidateWorkingHour())
                tabPage5.Show(); tabPage3.Show();
        }

        private bool ValidateWorkingHour()
        {
            return true;
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            if (ValidateBreaks())
                tabPage4.Show();
        }

        private bool ValidateBreaks()
        {
            DateTime dtFrom = dtpRegularWorkFrom.Value;
            DateTime dtTo = dtpRegularWorkTo.Value;

            if (dtFrom > dtTo)
            {
                dtTo.AddDays(1);
            }

            if (chbBreak1.Checked == true)
            {
                string breakName1 = txtBreakName1.Text.Trim();

                if (breakName1 == "")
                {
                    MessageBox.Show("Please enter a name for Break1.");
                    return false;
                }

                DateTime dtBreakFrom1 = dtpBreakFrom1.Value;

                DateTime dtBreakTo1 = dtpBreakTo1.Value;

                if (dtBreakFrom1 > dtBreakTo1)
                {
                    dtBreakTo1.AddDays(1);
                }

                if (dtBreakFrom1 < dtFrom || dtBreakTo1 > dtTo)
                {
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again");
                    return false;
                }
            }

            if (chbBreak2.Checked == true)
            {
                string breakName2 = txtBreakName2.Text.Trim();

                if (breakName2 == "")
                {
                    MessageBox.Show("Please enter a name for Break2.");
                    return false;
                }

                DateTime dtBreakFrom2 = dtpBreakFrom2.Value;

                DateTime dtBreakTo2 = dtpBreakTo2.Value;

                if (dtBreakFrom2 > dtBreakTo2)
                {
                    dtBreakTo2.AddDays(1);
                }

                if (dtBreakFrom2 < dtFrom || dtBreakTo2 > dtTo)
                {
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again");
                    return false;
                }
            }

            if (chbBreak3.Checked == true)
            {
                string breakName3 = txtBreakName3.Text.Trim();

                if (breakName3 == "")
                {
                    MessageBox.Show("Please enter a name for Break3.");
                    return false;
                }

                DateTime dtBreakFrom3 = dtpBreakFrom3.Value;

                DateTime dtBreakTo3 = dtpBreakTo3.Value;

                if (dtBreakFrom3 > dtBreakTo3)
                {
                    dtBreakTo3.AddDays(1);
                }

                if (dtBreakFrom3 < dtFrom || dtBreakTo3 > dtTo)
                {
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again");
                    return false;
                }
            }

            return true;
        }

        private void btnNext4_Click(object sender, EventArgs e)
        {
            if (ValidateWorkingDayRate())
                tabPage5.Show();
        }

        private bool ValidateWorkingDayRate()
        {
            return true;
        }

        private void btnNext5_Click(object sender, EventArgs e)
        {
            if (ValidateNonWorkingDayRate())
                tabPage5.Show();
        }

        private bool ValidateNonWorkingDayRate()
        {
            return true;
        }

        private void btnNext6_Click(object sender, EventArgs e)
        {
            if (ValidateHoliday())
                tabPage5.Show();
        }

        private bool ValidateHoliday()
        {
            return true;
        }

        private void btnNext7_Click(object sender, EventArgs e)
        {
            if (ValidateHolidayRate())
                tabPage5.Show();
        }

        private bool ValidateHolidayRate()
        {
            return true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            AddUpdateWorkingCalendar();
        }

        private void AddUpdateWorkingCalendar()
        {
            #region Validate inputs
            if (ValidateName() == false)
            {
                tabPage1.Show();
                return;
            }

            if (ValidateWorkingHour() == false)
            {
                tabPage2.Show();
                return;
            }

            if (ValidateBreaks() == false)
            {
                tabPage3.Show();
                return;
            }

            if (ValidateWorkingDayRate() == false)
            {
                tabPage4.Show();
                return;
            }

            if (ValidateNonWorkingDayRate() == false)
            {
                tabPage5.Show();
                return;
            }

            if (ValidateHoliday() == false)
            {
                tabPage6.Show();
                return;
            }

            if (ValidateHolidayRate() == false)
            {
                tabPage7.Show();
                return;
            }

            if (ValidatePayPeriod() == false)
            {
                return;
            }
            #endregion

            #region Create object and set properties
            WorkingCalendar workingCalendar = null;
            List<Break> breakList = new List<Break>();
            List<Holiday> holidayList = new List<Holiday>();
            PaymentRate workingDayPaymentRate = new PaymentRate();
            PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            PaymentRate holidayPaymentRate = new PaymentRate();

            if (_workingCalendarID < 0) //add
            {
                workingCalendar = new WorkingCalendar();
            }
            else //update
            {
                workingCalendar = _dtCtrl.GetWorkingCalendar(_workingCalendarID);
                if (workingCalendar == null)
                {
                    throw new NullReferenceException();
                }
            }

            SetWorkingCalendarProperties(ref workingCalendar, ref breakList, ref holidayList, ref workingDayPaymentRate, ref nonWorkingDayPaymentRate, ref holidayPaymentRate);

            #endregion

            #region insert/update in database
            if (_workingCalendarID < 0) //add
            {
                int workingCalendarID = _dtCtrl.AddWorkingCalendar(workingCalendar, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate);

                if (workingCalendarID < 0)
                {
                    throw new Exception();
                }
            }
            else //update
            {
                bool result = _dtCtrl.UpdateWorkingCalendar(workingCalendar, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate);

                if (result != true)
                {
                    throw new Exception();
                }
            }
            #endregion
        }

        private void SetWorkingCalendarProperties(ref WorkingCalendar workingCalendar, ref List<Break> breakList, ref List<Holiday> holidayList, ref PaymentRate workDayPaymentRate, ref PaymentRate nonWorkDayPaymentRate, ref PaymentRate holidayPaymentRate)
        {
            workingCalendar.Name = txtName.Text;

            #region Get Working Days
            workingCalendar.WorkOnMonday = chbMonday.Checked;
            workingCalendar.WorkOnTuesday = chbTuesday.Checked;
            workingCalendar.WorkOnWednesday = chbWednesday.Checked;
            workingCalendar.WorkOnThursday = chbThursday.Checked;
            workingCalendar.WorkOnFriday = chbFriday.Checked;
            workingCalendar.WorkOnSaturday = chbSaturday.Checked;
            workingCalendar.WorkOnSunday = chbSunday.Checked;

            workingCalendar.RegularWorkingFrom = dtpRegularWorkFrom.Value;
            workingCalendar.RegularWorkingTo = dtpRegularWorkTo.Value;

            #endregion

            #region Get Break Times
            if (chbBreak1.Checked)
            {
                Break break1 = new Break();

                break1.Name = txtBreakName1.Text;
                break1.From = dtpBreakFrom1.Value;
                break1.To = dtpBreakTo1.Value;
                break1.Paid = chbBreak1.Checked;

                breakList.Add(break1);
            }

            if (chbBreak2.Checked)
            {
                Break break2 = new Break();

                break2.Name = txtBreakName2.Text;
                break2.From = dtpBreakFrom2.Value;
                break2.To = dtpBreakTo2.Value;
                break2.Paid = chbBreak2.Checked;

                breakList.Add(break2);
            }

            if (chbBreak3.Checked)
            {
                Break break3 = new Break();

                break3.Name = txtBreakName3.Text;
                break3.From = dtpBreakFrom3.Value;
                break3.To = dtpBreakTo3.Value;
                break3.Paid = chbBreak3.Checked;

                breakList.Add(break3);
            }

            #endregion

            #region Get Payment Rates

            workDayPaymentRate.NumberOfRegularHours = (int)nudWorkDayRegularHour.Value;
            workDayPaymentRate.NumberOfOvertime1 = (int)nudWorkDayOvertimeHour1.Value;
            workDayPaymentRate.NumberOfOvertime2 = (int)nudWorkDayOvertimeHour2.Value;
            workDayPaymentRate.NumberOfOvertime3 = (int)nudWorkDayOvertimeHour3.Value;
            workDayPaymentRate.NumberOfOvertime4 = (int)nudWorkDayOvertimeHour4.Value;

            workDayPaymentRate.RegularRate = (int)cbxWorkDayRegularRate.SelectedValue;
            workDayPaymentRate.OvertimeRate1 = (int)cbxWorkDayOvertimeRate1.SelectedValue;
            workDayPaymentRate.OvertimeRate2 = (int)cbxWorkDayOvertimeRate2.SelectedValue;
            workDayPaymentRate.OvertimeRate3 = (int)cbxWorkDayOvertimeRate3.SelectedValue;
            workDayPaymentRate.OvertimeRate4 = (int)cbxWorkDayOvertimeRate4.SelectedValue;

            nonWorkDayPaymentRate.NumberOfRegularHours = (int)nudNonWorkDayRegularHour.Value;
            nonWorkDayPaymentRate.NumberOfOvertime1 = (int)nudNonWorkDayOvertimeHour1.Value;
            nonWorkDayPaymentRate.NumberOfOvertime2 = (int)nudNonWorkDayOvertimeHour2.Value;
            nonWorkDayPaymentRate.NumberOfOvertime3 = (int)nudNonWorkDayOvertimeHour3.Value;
            nonWorkDayPaymentRate.NumberOfOvertime4 = (int)nudNonWorkDayOvertimeHour4.Value;

            nonWorkDayPaymentRate.RegularRate = (int)cbxNonWorkDayRegularRate.SelectedValue;
            nonWorkDayPaymentRate.OvertimeRate1 = (int)cbxNonWorkDayOvertimeRate1.SelectedValue;
            nonWorkDayPaymentRate.OvertimeRate2 = (int)cbxNonWorkDayOvertimeRate2.SelectedValue;
            nonWorkDayPaymentRate.OvertimeRate3 = (int)cbxNonWorkDayOvertimeRate3.SelectedValue;
            nonWorkDayPaymentRate.OvertimeRate4 = (int)cbxNonWorkDayOvertimeRate4.SelectedValue;


            holidayPaymentRate.NumberOfRegularHours = (int)nudHolidayRegularHour.Value;
            holidayPaymentRate.NumberOfOvertime1 = (int)nudHolidayOvertimeHour1.Value;
            holidayPaymentRate.NumberOfOvertime2 = (int)nudHolidayOvertimeHour2.Value;
            holidayPaymentRate.NumberOfOvertime3 = (int)nudHolidayOvertimeHour3.Value;
            holidayPaymentRate.NumberOfOvertime4 = (int)nudHolidayOvertimeHour4.Value;

            holidayPaymentRate.RegularRate = (int)cbxHolidayRegularRate.SelectedValue;
            holidayPaymentRate.OvertimeRate1 = (int)cbxHolidayOvertimeRate1.SelectedValue;
            holidayPaymentRate.OvertimeRate2 = (int)cbxHolidayOvertimeRate2.SelectedValue;
            holidayPaymentRate.OvertimeRate3 = (int)cbxHolidayOvertimeRate3.SelectedValue;
            holidayPaymentRate.OvertimeRate4 = (int)cbxHolidayOvertimeRate4.SelectedValue;

            #endregion

            #region Get Holidays
            holidayList = _holidayList;
            #endregion

            #region Get Pay Period
            if (rbtPayPeriodCustom.Checked)//custom Pay Period
            {
                workingCalendar.CustomPayPeriod = (int)nudCustomPayPeriod.Value;
                workingCalendar.PayPeriodID = -1;
            }
            else
            {
                String payPeriodName = "";

                if (rbtPayPeriodWeekly.Checked)
                    payPeriodName = "Weekly";
                else if (rbtPayPeriodBiweekly.Checked)
                    payPeriodName = "Bi-Weekly";
                else if (rbtPayPeriodMonthly.Checked)
                    payPeriodName = "Monthly";
                else if (rbtPayPeriodHalfmonthly.Checked)
                    payPeriodName = "Half-Monthly";

                PayPeriod payPeriod = _dtCtrl.GetPayPeriodByName(payPeriodName);

                if (payPeriod == null)
                    throw new Exception();

                workingCalendar.PayPeriodID = payPeriod.ID;
            }

            workingCalendar.PayPeriodStartFrom = dtpPayPeriodStartFrom.Value;
            #endregion
        }

        private bool ValidatePayPeriod()
        {
            return true;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            tabPage2.Show();
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            tabPage3.Show();
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            tabPage4.Show();
        }

        private void btnBack6_Click(object sender, EventArgs e)
        {
            tabPage5.Show();
        }

        private void btnBack7_Click(object sender, EventArgs e)
        {
            tabPage6.Show();
        }

        private void btnBack8_Click(object sender, EventArgs e)
        {
            tabPage7.Show();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void CancelAddingUpdating()
        {
            if (Util.Confirm("Any unsaved data will be lost. Are you sure you want to close this form?"))
                this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel4_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel5_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel6_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel7_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnCancel8_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            AddHoliday();
        }

        private void AddHoliday()
        {
            Holiday holiday = new Holiday();
            holiday.Date = mcdHoliday.SelectionStart;

            _holidayList.Add(holiday);

            dgvHoliday.AutoGenerateColumns = false;
            dgvHoliday.DataSource = _holidayList;
        }

        private void btnRemoveHoliday_Click(object sender, EventArgs e)
        {
            RemoveHoliday();
        }

        private void RemoveHoliday()
        {
            DataGridViewSelectedRowCollection rowCollection = dgvHoliday.SelectedRows;

            for (int i = rowCollection.Count - 1; i >= 0; i--)
            {
                _holidayList.RemoveAt(i);
            }

            dgvHoliday.AutoGenerateColumns = false;
            dgvHoliday.DataSource = _holidayList;            
        }

        private void nudRegularWorkFromHour_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void nudRegularWorkFromMin_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void nudRegularWorkToHour_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void nudRegularWorkToMin_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void CheckWorkingHour()
        {
            DateTime dtFrom = dtpRegularWorkFrom.Value;

            DateTime dtTo = dtpRegularWorkTo.Value;

            lblNextDay.Visible = (dtFrom > dtTo);
        }

        #region ICustomeRateCaller Members

        public void ImplementNewRate(Rate newRate)
        {
            if (newRate == null) //user cancels
            {
                _selectedComboBox.SelectedIndex = 1;
            }
            else
            {
                foreach (ComboBox cbx in _listCbxRate)
                {
                    AddNewRate(cbx, newRate);

                    _selectedComboBox.SelectedIndex = _selectedComboBox.Items.IndexOf(newRate);
                }
            }
        }

        private void AddNewRate(ComboBox cbx, Rate newRate)
        {
            if(cbx.Items.Count > 0)
            {
                cbx.Items.RemoveAt(cbx.Items.Count - 1); //remove custom rate option
                cbx.Items.Add(newRate); //add new rate
                cbx.Items.Add(new Rate(-1, "Custom Rate")); //add custom rate option
            }
        }

        #endregion

        private void cbxWorkDayRegularRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxWorkDayOvertimeRate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxWorkDayOvertimeRate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxWorkDayOvertimeRate3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxWorkDayOvertimeRate4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxNonWorkDayRegularRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxNonWorkDayOvertimeRate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxNonWorkDayOvertimeRate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxNonWorkDayOvertimeRate3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxNonWorkDayOvertimeRate4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxHolidayRegularRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxHolidayOvertimeRate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxHolidayOvertimeRate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxHolidayOvertimeRate3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void cbxHolidayOvertimeRate4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedRate((ComboBox)sender);
        }

        private void CheckSelectedRate(ComboBox comboBox)
        {
            Rate selectedRate = (Rate)comboBox.SelectedItem;
            if (selectedRate != null)
            {
                if (selectedRate.Value == -1)
                {
                    _selectedComboBox = comboBox;

                    frmCustomRate frmCRate = new frmCustomRate(this);
                    frmCRate.ShowDialog(this);
                }
            }
        }
    }
}