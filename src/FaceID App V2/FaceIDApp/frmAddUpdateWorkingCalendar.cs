﻿using System;
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
    public partial class frmAddUpdateWorkingCalendar : Form, ICustomRateCaller
    {
        private IDataController _dtCtrl;

        private static int _workingCalendarID = -1;

        private Control[] _listCtrlBreak1, _listCtrlBreak2, _listCtrlBreak3;
        private ComboBox[] _listCbxRate;

        private List<Holiday> _holidayList = new List<Holiday>();
        private List<Shift> _shiftList = new List<Shift>();

        private ComboBox _selectedComboBox = null;

        public frmAddUpdateWorkingCalendar() : this(-1) { }

        public frmAddUpdateWorkingCalendar(int workingCalendarID)
        {
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();
            
            _workingCalendarID = workingCalendarID;

            _listCtrlBreak1 = new Control[] { txtBreakName1, dtpBreakFrom1, dtpBreakTo1, chbBreakPaid1 };
            _listCtrlBreak2 = new Control[] { txtBreakName2, dtpBreakFrom2, dtpBreakTo2, chbBreakPaid2 };
            _listCtrlBreak3 = new Control[] { txtBreakName3, dtpBreakFrom3, dtpBreakTo3, chbBreakPaid3 };

            _listCbxRate = new ComboBox[]{cbxWorkDayRegularRate, cbxWorkDayOvertimeRate1, cbxWorkDayOvertimeRate2, cbxWorkDayOvertimeRate3, cbxWorkDayOvertimeRate4, 
                cbxNonWorkDayRegularRate, cbxNonWorkDayOvertimeRate1, cbxNonWorkDayOvertimeRate2, cbxNonWorkDayOvertimeRate3, cbxNonWorkDayOvertimeRate4, 
                cbxHolidayRegularRate, cbxHolidayOvertimeRate1, cbxHolidayOvertimeRate2, cbxHolidayOvertimeRate3, cbxHolidayOvertimeRate4,
                cbxFlexiHourWorkingDayRegularRate, cbxFlexiHourNonWorkingDayRegularRate, cbxFlexiHourHolidayRegularRate, cbxFlexiHourOvertimeRate1, cbxFlexiHourOvertimeRate2, cbxFlexiHourOvertimeRate3, cbxFlexiHourOvertimeRate4};

            BindWeekdays();
            BindData();
            SetState(workingCalendarID);
        }

        private void BindWeekdays()
        {
            List<ListItem> listItemList = new List<ListItem>();

            listItemList.Add(new ListItem(0, "Monday"));
            listItemList.Add(new ListItem(1, "Tuesday"));
            listItemList.Add(new ListItem(2, "Wednesday"));
            listItemList.Add(new ListItem(3, "Thursday"));
            listItemList.Add(new ListItem(4, "Friday"));
            listItemList.Add(new ListItem(5, "Saturday"));
            listItemList.Add(new ListItem(6, "Sunday"));

            Util.BindCombobox(cbxWeekStartsOn, listItemList, true);
        }

        private void BindData()
        {
            nudCustomPayPeriod.Maximum = 30;

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
            cbx.Items.Add(new Rate(100, "100%"));
            cbx.Items.Add(new Rate(125, "125%"));
            cbx.Items.Add(new Rate(150, "150%"));
            cbx.Items.Add(new Rate(200, "200%"));
            cbx.Items.Add(new Rate(300, "300%"));

            cbx.Items.Add(new Rate(-1, "Custom Rate"));

            cbx.SelectedIndex = 0;
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
            try
            {
                txtName.Text = workingCalendar.Name;
                
                #region Flexi Hours
                chbApplyFlexiHours.Checked = workingCalendar.ApplyFlexiHours;
                if (workingCalendar.ApplyFlexiHours)
                {
                    nudFlexiHours.Value = workingCalendar.FlexiHours;
                    cbxWeekStartsOn.SelectedIndex = workingCalendar.WeekStartsOn;
                }
                #endregion

                #region Set Working Days
                chbMonday.Checked = workingCalendar.WorkOnMonday;
                chbTuesday.Checked = workingCalendar.WorkOnTuesday;
                chbWednesday.Checked = workingCalendar.WorkOnWednesday;
                chbThursday.Checked = workingCalendar.WorkOnThursday;
                chbFriday.Checked = workingCalendar.WorkOnFriday;
                chbSaturday.Checked = workingCalendar.WorkOnSaturday;
                chbSunday.Checked = workingCalendar.WorkOnSunday;

                nudGraceForwardToEntry.Value = workingCalendar.GraceForwardToEntry;
                nudGraceBackwardToExit.Value = workingCalendar.GraceBackwardToExit;
                nudEarliestBeforeEntry.Value = workingCalendar.EarliestBeforeEntry;
                nudLastestAfterExit.Value = workingCalendar.LastestAfterExit;
                #endregion

                #region Set Shifts
                List<Shift> shiftList = _dtCtrl.GetShiftListByWorkingCalendar(workingCalendarID);
                if (shiftList.Count == 1) //one shift
                {
                    rbtOneShift.Checked = true;
                    dtpRegularWorkFrom.Value = shiftList[0].From;
                    dtpRegularWorkTo.Value = shiftList[0].To;
                }
                else //multi shifts
                {
                    rbtMultiShifts.Checked = true;
                    _shiftList = shiftList;
                    BindShift();
                }
                #endregion

                #region Set Break Times
                List<Break> breaks = _dtCtrl.GetBreakListByWorkingCalendar(workingCalendarID);

                if (breaks.Count >= 1)
                {
                    Break break1 = breaks[0];
                    EnableBreakControls1(true);
                    chbBreak1.Checked = true;

                    txtBreakName1.Text = break1.Name;
                    dtpBreakFrom1.Value = break1.From;
                    dtpBreakTo1.Value = break1.To;
                    chbBreakPaid1.Checked = break1.Paid;
                }

                if (breaks.Count >= 2)
                {
                    Break break2 = breaks[1];
                    EnableBreakControls2(true);
                    chbBreak2.Checked = true;

                    txtBreakName2.Text = break2.Name;
                    dtpBreakFrom2.Value = break2.From;
                    dtpBreakTo2.Value = break2.To;
                    chbBreakPaid2.Checked = break2.Paid;
                }

                if (breaks.Count >= 3)
                {
                    Break break3 = breaks[2];
                    EnableBreakControls3(true);
                    chbBreak3.Checked = true;

                    txtBreakName3.Text = break3.Name;
                    dtpBreakFrom3.Value = break3.From;
                    dtpBreakTo3.Value = break3.To;
                    chbBreakPaid3.Checked = break3.Paid;
                }
                #endregion

                #region Set Payment Rates
                if (workingCalendar.ApplyFlexiHours)
                {
                    PaymentRate workingDayPaymentRate = _dtCtrl.GetWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(workingDayPaymentRate);

                    nudFlexiHourRegularHour.Value = (int)workingDayPaymentRate.NumberOfRegularHours;
                    nudFlexiHourOvertimeHour1.Value = (int)workingDayPaymentRate.NumberOfOvertime1;
                    nudFlexiHourOvertimeHour2.Value = (int)workingDayPaymentRate.NumberOfOvertime2;
                    nudFlexiHourOvertimeHour3.Value = (int)workingDayPaymentRate.NumberOfOvertime3;
                    nudFlexiHourOvertimeHour4.Value = (int)workingDayPaymentRate.NumberOfOvertime4;

                    PaymentRate nonWorkingDayPaymentRate = _dtCtrl.GetNonWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(nonWorkingDayPaymentRate);

                    PaymentRate holidayPaymentRate = _dtCtrl.GetHolidayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(holidayPaymentRate);

                    Util.SetComboboxSelectedByValue(cbxFlexiHourWorkingDayRegularRate, workingDayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourNonWorkingDayRegularRate, nonWorkingDayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourHolidayRegularRate, holidayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourOvertimeRate1, workingDayPaymentRate.OvertimeRate3);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourOvertimeRate2, workingDayPaymentRate.OvertimeRate4);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourOvertimeRate3, workingDayPaymentRate.OvertimeRate4);
                    Util.SetComboboxSelectedByValue(cbxFlexiHourOvertimeRate4, workingDayPaymentRate.OvertimeRate4);

                }
                else
                {
                    PaymentRate workingDayPaymentRate = _dtCtrl.GetWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(workingDayPaymentRate);

                    nudWorkDayRegularHour.Value = (int)workingDayPaymentRate.NumberOfRegularHours;
                    nudWorkDayOvertimeHour1.Value = (int)workingDayPaymentRate.NumberOfOvertime1;
                    nudWorkDayOvertimeHour2.Value = (int)workingDayPaymentRate.NumberOfOvertime2;
                    nudWorkDayOvertimeHour3.Value = (int)workingDayPaymentRate.NumberOfOvertime3;
                    nudWorkDayOvertimeHour4.Value = (int)workingDayPaymentRate.NumberOfOvertime4;

                    Util.SetComboboxSelectedByValue(cbxWorkDayRegularRate, workingDayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate1, workingDayPaymentRate.OvertimeRate1);
                    Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate2, workingDayPaymentRate.OvertimeRate2);
                    Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate3, workingDayPaymentRate.OvertimeRate3);
                    Util.SetComboboxSelectedByValue(cbxWorkDayOvertimeRate4, workingDayPaymentRate.OvertimeRate4);

                    PaymentRate nonWorkingDayPaymentRate = _dtCtrl.GetNonWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(nonWorkingDayPaymentRate);

                    nudNonWorkDayRegularHour.Value = (int)nonWorkingDayPaymentRate.NumberOfRegularHours;
                    nudNonWorkDayOvertimeHour1.Value = (int)nonWorkingDayPaymentRate.NumberOfOvertime1;
                    nudNonWorkDayOvertimeHour2.Value = (int)nonWorkingDayPaymentRate.NumberOfOvertime2;
                    nudNonWorkDayOvertimeHour3.Value = (int)nonWorkingDayPaymentRate.NumberOfOvertime3;
                    nudNonWorkDayOvertimeHour4.Value = (int)nonWorkingDayPaymentRate.NumberOfOvertime4;

                    Util.SetComboboxSelectedByValue(cbxNonWorkDayRegularRate, nonWorkingDayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate1, nonWorkingDayPaymentRate.OvertimeRate1);
                    Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate2, nonWorkingDayPaymentRate.OvertimeRate2);
                    Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate3, nonWorkingDayPaymentRate.OvertimeRate3);
                    Util.SetComboboxSelectedByValue(cbxNonWorkDayOvertimeRate4, nonWorkingDayPaymentRate.OvertimeRate4);

                    PaymentRate holidayPaymentRate = _dtCtrl.GetHolidayPaymentRateByWorkingCalendar(workingCalendarID);
                    ImplementCustomRates(holidayPaymentRate);

                    nudHolidayRegularHour.Value = (int)holidayPaymentRate.NumberOfRegularHours;
                    nudHolidayOvertimeHour1.Value = (int)holidayPaymentRate.NumberOfOvertime1;
                    nudHolidayOvertimeHour2.Value = (int)holidayPaymentRate.NumberOfOvertime2;
                    nudHolidayOvertimeHour3.Value = (int)holidayPaymentRate.NumberOfOvertime3;
                    nudHolidayOvertimeHour4.Value = (int)holidayPaymentRate.NumberOfOvertime4;

                    Util.SetComboboxSelectedByValue(cbxHolidayRegularRate, holidayPaymentRate.RegularRate);
                    Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate1, holidayPaymentRate.OvertimeRate1);
                    Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate2, holidayPaymentRate.OvertimeRate2);
                    Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate3, holidayPaymentRate.OvertimeRate3);
                    Util.SetComboboxSelectedByValue(cbxHolidayOvertimeRate4, holidayPaymentRate.OvertimeRate4);
                }
                #endregion

                #region Set Holidays
                _holidayList = _dtCtrl.GetHolidayListByWorkingCalendar(workingCalendarID);
                BindHoliday();
                #endregion

                #region Set Pay Period
                PayPeriod payPeriod = _dtCtrl.GetPayPeriod(workingCalendar.PayPeriodID);
                PayPeriodType payPeriodType = _dtCtrl.GetPayPeriodType(payPeriod.PayPeriodTypeID);

                if (payPeriodType.ID == 5)//custom Pay Period
                {
                    rbtPayPeriodCustom.Checked = true;
                    nudCustomPayPeriod.Value = payPeriod.CustomPeriod;
                }
                else
                {
                    rbtPayPeriodWeekly.Checked = payPeriodType.ID == 1;
                    rbtPayPeriodBiweekly.Checked = payPeriodType.ID == 2;
                    rbtPayPeriodMonthly.Checked = payPeriodType.ID == 3;
                    rbtPayPeriodHalfmonthly.Checked = payPeriodType.ID == 4;
                }

                dtpPayPeriodStartFrom.Value = payPeriod.StartFrom;
                #endregion
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Faulty Working Calendar. Please delete it and add a new one.");
            }
        }

        private void BindShift()
        {
            //TODO fix this later
            dgvShift.DataSource = _shiftList;
        }

        private void EnableBreakControls1(bool enabled)
        {
            foreach (Control ctrl in _listCtrlBreak1)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls2(bool enabled)
        {
            foreach (Control ctrl in _listCtrlBreak2)
                ctrl.Enabled = enabled;
        }

        private void EnableBreakControls3(bool enabled)
        {
            foreach (Control ctrl in _listCtrlBreak3)
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
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage2;
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
                if (_dtCtrl.IsDuplicateWorkingCalendarName(name) == true)
                {
                    MessageBox.Show("This name has been used by another Working Calendar. Please choose a different name.");
                    return false;
                }
            }
            else
            {
                if (_dtCtrl.IsDuplicateWorkingCalendarName(name, _workingCalendarID) == true)
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
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage3;
        }

        private bool ValidateWorkingHour()
        {
            DateTime workFrom = dtpRegularWorkFrom.Value;
            DateTime workTo = dtpRegularWorkTo.Value;            

            int graceForwardEntry = (int)nudGraceForwardToEntry.Value;
            int graceBackwardExit = (int)nudGraceBackwardToExit.Value;

            int earliestBeforeEntry = (int)nudEarliestBeforeEntry.Value;
            int lastestAfterExit = (int)nudLastestAfterExit.Value;

            if (workTo < workFrom) //work over 24:00:00
                workTo = workTo.AddDays(1);

            if (graceForwardEntry > earliestBeforeEntry)
            {
                MessageBox.Show("'Grace Forward to Entry' value must be smaller than or equal to 'Earliest Before Entry allowed' value.");
                return false;
            }

            if (graceBackwardExit > lastestAfterExit)
            {
                MessageBox.Show("'Grace Backward to Exit' value must be smaller than or equal to 'Lastest After Exit allowed' value.");
                return false;
            }

            if (workTo.AddMinutes(lastestAfterExit) > workFrom.AddMinutes(-1 * earliestBeforeEntry).AddDays(1))
            {
                MessageBox.Show("A working day must not exceed 24 hours.");
                return false;
            }

            //TODO validate shifts
            
            return true;
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            if (ValidateBreaks())
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage4;
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
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again.");
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
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again.");
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
                    MessageBox.Show("Break time must be during working hours(" + dtpRegularWorkFrom.Value.ToShortTimeString() + " - " + dtpRegularWorkTo.Value.ToShortTimeString() + ". Please try again.");
                    return false;
                }
            }

            return true;
        }

        private void btnNext4_Click(object sender, EventArgs e)
        {
            //TODO validate flexi
            if (ValidateWorkingDayRate())
                if (ValidateNonWorkingDayRate())
                    if(ValidateHolidayRate())
                        tabAddUpdateWorkingCalendar.SelectedTab = tabPage5;
        }

        private bool ValidateWorkingDayRate()
        {
            return true;
        }

        private void btnNext5_Click(object sender, EventArgs e)
        {
            if (ValidateHoliday())
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage6;
        }

        private bool ValidateNonWorkingDayRate()
        {
            return true;
        }

        private bool ValidateHoliday()
        {
            return true;
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
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage1;
                return;
            }

            if (ValidateWorkingHour() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage2;
                return;
            }

            if (ValidateBreaks() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage3;
                return;
            }

            if (ValidateWorkingDayRate() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage4;
                return;
            }

            if (ValidateNonWorkingDayRate() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage4;
                return;
            }

            if (ValidateHolidayRate() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage4;
                return;
            }

            if (ValidateHoliday() == false)
            {
                tabAddUpdateWorkingCalendar.SelectedTab = tabPage5;
                return;
            }

            if (ValidatePayPeriod() == false)
            {
                return;
            }
            #endregion

            #region Create object and set properties
            WorkingCalendar workingCalendar = null;
            List<Shift> shiftList = new List<Shift>();
            List<Break> breakList = new List<Break>();
            List<Holiday> holidayList = new List<Holiday>();
            PaymentRate workingDayPaymentRate = new PaymentRate();
            PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            PaymentRate holidayPaymentRate = new PaymentRate();
            PayPeriod payPeriod = new PayPeriod();

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

            SetWorkingCalendarProperties(ref workingCalendar, ref shiftList, ref breakList, ref holidayList, ref workingDayPaymentRate, ref nonWorkingDayPaymentRate, ref holidayPaymentRate, ref payPeriod);

            #endregion

            #region insert/update in database
            if (_workingCalendarID < 0) //add
            {
                int workingCalendarID = _dtCtrl.AddWorkingCalendar(workingCalendar, shiftList, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

                if (workingCalendarID < 0)
                {
                    throw new Exception("Working Calendar could not be added.");
                }

                MessageBox.Show("Working Calendar added.");
                this.Close();
            }
            else //update
            {
                bool result = _dtCtrl.UpdateWorkingCalendar(workingCalendar, shiftList, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

                if (result != true)
                {
                    throw new Exception("Working Calendar could not be updated.");
                }

                MessageBox.Show("Working Calendar updated.");
                this.Close();
            }
            #endregion
        }

        private void ImplementCustomRates(PaymentRate paymentRate)
        {
            List<Rate> rateList = new List<Rate>();
            rateList.Add(new Rate(paymentRate.RegularRate));
            rateList.Add(new Rate(paymentRate.OvertimeRate1));
            rateList.Add(new Rate(paymentRate.OvertimeRate2));
            rateList.Add(new Rate(paymentRate.OvertimeRate3));
            rateList.Add(new Rate(paymentRate.OvertimeRate4));

            foreach (Rate rate in rateList)
            {
                if (cbxWorkDayRegularRate.FindString(rate.Name) < 0)
                {
                    foreach (ComboBox cbx in _listCbxRate)
                    {
                        AddNewRate(cbx, rate);
                    }
                }
            }
        }

        private void SetWorkingCalendarProperties(ref WorkingCalendar workingCalendar, ref List<Shift> shiftList, ref List<Break> breakList, ref List<Holiday> holidayList, ref PaymentRate workDayPaymentRate, ref PaymentRate nonWorkDayPaymentRate, ref PaymentRate holidayPaymentRate, ref PayPeriod payPeriod)
        {
            workingCalendar.Name = txtName.Text;

            #region Flexi Hours
            workingCalendar.ApplyFlexiHours = chbApplyFlexiHours.Checked;
            if (workingCalendar.ApplyFlexiHours)
            {
                workingCalendar.FlexiHours = (int)nudFlexiHours.Value;
                workingCalendar.WeekStartsOn = cbxWeekStartsOn.SelectedIndex;
            }
            #endregion

            #region Get Working Days
            workingCalendar.WorkOnMonday = chbMonday.Checked;
            workingCalendar.WorkOnTuesday = chbTuesday.Checked;
            workingCalendar.WorkOnWednesday = chbWednesday.Checked;
            workingCalendar.WorkOnThursday = chbThursday.Checked;
            workingCalendar.WorkOnFriday = chbFriday.Checked;
            workingCalendar.WorkOnSaturday = chbSaturday.Checked;
            workingCalendar.WorkOnSunday = chbSunday.Checked;

            workingCalendar.GraceForwardToEntry = (int)nudGraceForwardToEntry.Value;
            workingCalendar.GraceBackwardToExit = (int)nudGraceBackwardToExit.Value;
            workingCalendar.EarliestBeforeEntry = (int)nudEarliestBeforeEntry.Value;
            workingCalendar.LastestAfterExit = (int)nudLastestAfterExit.Value;
            #endregion

            #region Shift
            if (rbtOneShift.Checked)
            {
                Shift shift = new Shift();
                shift.From = dtpRegularWorkFrom.Value;
                shift.To = dtpRegularWorkTo.Value;

                shiftList.Add(shift);
            }
            else //multi-shifts
            {
                shiftList = _shiftList;
            }
            #endregion

            #region Get Break Times
            if (chbBreak1.Checked)
            {
                Break break1 = new Break();

                break1.Name = txtBreakName1.Text;
                break1.From = dtpBreakFrom1.Value;
                break1.To = dtpBreakTo1.Value;
                break1.Paid = chbBreakPaid1.Checked;

                breakList.Add(break1);
            }

            if (chbBreak2.Checked)
            {
                Break break2 = new Break();

                break2.Name = txtBreakName2.Text;
                break2.From = dtpBreakFrom2.Value;
                break2.To = dtpBreakTo2.Value;
                break2.Paid = chbBreakPaid2.Checked;

                breakList.Add(break2);
            }

            if (chbBreak3.Checked)
            {
                Break break3 = new Break();

                break3.Name = txtBreakName3.Text;
                break3.From = dtpBreakFrom3.Value;
                break3.To = dtpBreakTo3.Value;
                break3.Paid = chbBreakPaid3.Checked;

                breakList.Add(break3);
            }

            #endregion

            #region Get Payment Rates
            if (workingCalendar.ApplyFlexiHours)
            {
                workDayPaymentRate.NumberOfRegularHours = (int)nudFlexiHourRegularHour.Value;
                workDayPaymentRate.NumberOfOvertime1 = (int)nudFlexiHourOvertimeHour1.Value;
                workDayPaymentRate.NumberOfOvertime2 = (int)nudFlexiHourOvertimeHour2.Value;
                workDayPaymentRate.NumberOfOvertime3 = (int)nudFlexiHourOvertimeHour3.Value;
                workDayPaymentRate.NumberOfOvertime4 = (int)nudFlexiHourOvertimeHour4.Value;

                workDayPaymentRate.RegularRate = ((Rate)cbxFlexiHourWorkingDayRegularRate.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate1 = ((Rate)cbxHolidayOvertimeRate1.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate2 = ((Rate)cbxHolidayOvertimeRate2.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate3 = ((Rate)cbxHolidayOvertimeRate3.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate4 = ((Rate)cbxHolidayOvertimeRate4.SelectedItem).Value;

                nonWorkDayPaymentRate.RegularRate = ((Rate)cbxFlexiHourNonWorkingDayRegularRate.SelectedItem).Value;
                holidayPaymentRate.RegularRate = ((Rate)cbxFlexiHourHolidayRegularRate.SelectedItem).Value;
            }
            else
            {
                workDayPaymentRate.NumberOfRegularHours = (int)nudWorkDayRegularHour.Value;
                workDayPaymentRate.NumberOfOvertime1 = (int)nudWorkDayOvertimeHour1.Value;
                workDayPaymentRate.NumberOfOvertime2 = (int)nudWorkDayOvertimeHour2.Value;
                workDayPaymentRate.NumberOfOvertime3 = (int)nudWorkDayOvertimeHour3.Value;
                workDayPaymentRate.NumberOfOvertime4 = (int)nudWorkDayOvertimeHour4.Value;

                workDayPaymentRate.RegularRate = ((Rate)cbxWorkDayRegularRate.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate1 = ((Rate)cbxWorkDayOvertimeRate1.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate2 = ((Rate)cbxWorkDayOvertimeRate2.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate3 = ((Rate)cbxWorkDayOvertimeRate3.SelectedItem).Value;
                workDayPaymentRate.OvertimeRate4 = ((Rate)cbxWorkDayOvertimeRate4.SelectedItem).Value;

                nonWorkDayPaymentRate.NumberOfRegularHours = (int)nudNonWorkDayRegularHour.Value;
                nonWorkDayPaymentRate.NumberOfOvertime1 = (int)nudNonWorkDayOvertimeHour1.Value;
                nonWorkDayPaymentRate.NumberOfOvertime2 = (int)nudNonWorkDayOvertimeHour2.Value;
                nonWorkDayPaymentRate.NumberOfOvertime3 = (int)nudNonWorkDayOvertimeHour3.Value;
                nonWorkDayPaymentRate.NumberOfOvertime4 = (int)nudNonWorkDayOvertimeHour4.Value;

                nonWorkDayPaymentRate.RegularRate = ((Rate)cbxNonWorkDayRegularRate.SelectedItem).Value;
                nonWorkDayPaymentRate.OvertimeRate1 = ((Rate)cbxNonWorkDayOvertimeRate1.SelectedItem).Value;
                nonWorkDayPaymentRate.OvertimeRate2 = ((Rate)cbxNonWorkDayOvertimeRate2.SelectedItem).Value;
                nonWorkDayPaymentRate.OvertimeRate3 = ((Rate)cbxNonWorkDayOvertimeRate3.SelectedItem).Value;
                nonWorkDayPaymentRate.OvertimeRate4 = ((Rate)cbxNonWorkDayOvertimeRate4.SelectedItem).Value;

                holidayPaymentRate.NumberOfRegularHours = (int)nudHolidayRegularHour.Value;
                holidayPaymentRate.NumberOfOvertime1 = (int)nudHolidayOvertimeHour1.Value;
                holidayPaymentRate.NumberOfOvertime2 = (int)nudHolidayOvertimeHour2.Value;
                holidayPaymentRate.NumberOfOvertime3 = (int)nudHolidayOvertimeHour3.Value;
                holidayPaymentRate.NumberOfOvertime4 = (int)nudHolidayOvertimeHour4.Value;

                holidayPaymentRate.RegularRate = ((Rate)cbxHolidayRegularRate.SelectedItem).Value;
                holidayPaymentRate.OvertimeRate1 = ((Rate)cbxHolidayOvertimeRate1.SelectedItem).Value;
                holidayPaymentRate.OvertimeRate2 = ((Rate)cbxHolidayOvertimeRate2.SelectedItem).Value;
                holidayPaymentRate.OvertimeRate3 = ((Rate)cbxHolidayOvertimeRate3.SelectedItem).Value;
                holidayPaymentRate.OvertimeRate4 = ((Rate)cbxHolidayOvertimeRate4.SelectedItem).Value;
            }
            #endregion

            #region Get Holidays
            holidayList = _holidayList;
            #endregion

            #region Get Pay Period
            if (rbtPayPeriodCustom.Checked)//custom Pay Period
            {
                payPeriod.PayPeriodTypeID = 5;
                payPeriod.CustomPeriod = (int)nudCustomPayPeriod.Value;
            }
            else
            {
                if (rbtPayPeriodWeekly.Checked)
                    payPeriod.PayPeriodTypeID = 1;
                else if (rbtPayPeriodBiweekly.Checked)
                    payPeriod.PayPeriodTypeID = 2;
                else if (rbtPayPeriodMonthly.Checked)
                    payPeriod.PayPeriodTypeID = 3;
                else if (rbtPayPeriodHalfmonthly.Checked)
                    payPeriod.PayPeriodTypeID = 4;
            }

            payPeriod.StartFrom = dtpPayPeriodStartFrom.Value;
            #endregion
        }

        private bool ValidatePayPeriod()
        {
            return true;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabAddUpdateWorkingCalendar.SelectedTab = tabPage1;
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            tabAddUpdateWorkingCalendar.SelectedTab = tabPage2;
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            tabAddUpdateWorkingCalendar.SelectedTab = tabPage3;
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            tabAddUpdateWorkingCalendar.SelectedTab = tabPage4;
        }

        private void btnBack6_Click(object sender, EventArgs e)
        {
            tabAddUpdateWorkingCalendar.SelectedTab = tabPage5;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            CancelAddingUpdating();
        }

        private void CancelAddingUpdating()
        {
            if(Util.ConfirmCloseForm())
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

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            AddHoliday();
        }

        private void AddHoliday()
        {
            if (mclHoliday.SelectedDates.Count == 0)
            {
                MessageBox.Show("Please select a day.");
                return;
            }
            else
            {
                Holiday holiday = new Holiday();
                holiday.Date = mclHoliday.SelectedDates[0];
                holiday.Description = "";

                if (_holidayList.Find(delegate(Holiday hday)
                {
                    return hday.Date.Day == holiday.Date.Day && hday.Date.Month == holiday.Date.Month;
                }) != null)
                {
                    MessageBox.Show(holiday.Date.Day + @"/" + holiday.Date.Month + " has already been added. Please choose another day.");
                    return;
                }
                else
                {
                    new frmAddUpdateHoliday(ref holiday).ShowDialog(this);
                    if (holiday != null)
                    {
                        _holidayList.Add(holiday);
                        _holidayList.Sort(delegate(Holiday hday1, Holiday hday2)
                        {
                            if (hday1.Date.Month != hday2.Date.Month)
                                return hday1.Date.Month - hday2.Date.Month;
                            else
                                return hday1.Date.Day - hday2.Date.Day;
                        });

                        BindHoliday();
                    }
                }
            }
        }

        private void BindHoliday()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Holiday");
            dt.Columns.Add("Description");

            foreach (Holiday holiday in _holidayList)
            {
                DataRow dr = dt.NewRow();
                dr["Holiday"] = holiday.Date.Day + @"/" + holiday.Date.Month;
                dr["Description"] = holiday.Description;

                dt.Rows.Add(dr);
            }

            dgvHoliday.AutoGenerateColumns = true;
            dgvHoliday.Columns.Clear();

            dgvHoliday.DataSource = dt;
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
                _holidayList.RemoveAt(rowCollection[i].Index);
            }

            BindHoliday();
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

        private void dtpRegularWorkTo_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void dtpRegularWorkFrom_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void cbxFlexiHours_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideFlexiControls();
        }

        private void ShowHideFlexiControls()
        {
            bool applyFlexiHours = chbApplyFlexiHours.Checked;

            nudFlexiHours.Enabled = applyFlexiHours;
            cbxWeekStartsOn.Enabled = applyFlexiHours;

            ((Control)tpgFlexiHourRate).Enabled = applyFlexiHours;

            (tpgWorkingDayRate as Control).Enabled = !applyFlexiHours;
            ((Control)tpgNonWorkingDayRate).Enabled = !applyFlexiHours;
            ((Control)tpgHolidayRate).Enabled = !applyFlexiHours;
        }

        private void btnRemoveShifts_Click(object sender, EventArgs e)
        {
            List<Shift> selectedShifts = GetSelectedShifts();
            if (selectedShifts.Count == 0)
            {
                MessageBox.Show("No shift is selected.");
                return;
            }

            if (Util.Confirm("Are you sure you want to delete all selected shift(s)?"))
            {
                if (_dtCtrl.DeleteShifts(selectedShifts))
                {
                    MessageBox.Show("Shift(s) deleted.");
                }
                else
                {
                    MessageBox.Show("Shift(s) could not deleted. Please try again.");
                }

                _shiftList = _dtCtrl.GetShiftListByWorkingCalendar(_workingCalendarID);
                BindShift();
            }
        }

        private List<Shift> GetSelectedShifts()
        {
            //TODO fix this later
            List<Shift> selectedShifts = new List<Shift>();

            return selectedShifts;
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            int selectedShiftID = -1;
            List<Shift> selectedShifts = GetSelectedShifts();
            if (selectedShifts.Count != 1)
            {
                MessageBox.Show("Please select one shift to edit.");
                return;
            }

            selectedShiftID = selectedShifts[0].ID;

            new frmAddUpdateShift(selectedShiftID).ShowDialog(this);

            _shiftList = _dtCtrl.GetShiftListByWorkingCalendar(_workingCalendarID);
            BindShift();
        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            new frmAddUpdateShift(-1).ShowDialog(this);

            _shiftList = _dtCtrl.GetShiftListByWorkingCalendar(_workingCalendarID);
            BindShift();
        }
    }
}