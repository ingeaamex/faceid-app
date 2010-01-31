﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;
using Pabo.Calendar;

namespace FaceIDAppVBEta
{
    public partial class frmPreviewWorkingCalendar : Form
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private WorkingCalendar _workingCalendar;
        private List<Holiday> _holidayList;

        private Color _workDayColor = Color.White;
        private Color _nonWorkdayColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        private Color _holidayColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));

        public frmPreviewWorkingCalendar(int workingCalendarID)
        {
            InitializeComponent();

            SetColor();

            BindWorkingCalendar(workingCalendarID);
        }

        private void SetColor()
        {
            pbxWorkDay.BackColor = _workDayColor;
            pbxNonWorkDay.BackColor = _nonWorkdayColor;
            pbxHoliday.BackColor = _holidayColor;
        }

        private void BindWorkingCalendar(int workingCalendarID)
        {
            _workingCalendar = _dtCtrl.GetWorkingCalendar(workingCalendarID);

            if (_workingCalendar == null)
            {
                MessageBox.Show("Working Calendar not found or has been deleted.");
                this.Close();
            }

            lblWorkFrom.Text = GetTimeString(_workingCalendar.RegularWorkingFrom);
            lblWorkTo.Text = GetTimeString(_workingCalendar.RegularWorkingTo);

            //set payment rate
            PaymentRate workDayPaymentRate = _dtCtrl.GetWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);

            if (workDayPaymentRate == null)
            {
                //TODO
            }
            else
            {
                ucWorkingDayPaymentRate.SetPaymentRate(workDayPaymentRate);
            }

            PaymentRate nonWorkDayPaymentRate = _dtCtrl.GetNonWorkingDayPaymentRateByWorkingCalendar(workingCalendarID);

            if (nonWorkDayPaymentRate == null)
            {
                //TODO
            }
            else
            {
                ucNonWorkingDayPaymentRate.SetPaymentRate(nonWorkDayPaymentRate);
            }

            PaymentRate holidayRate = _dtCtrl.GetHolidayPaymentRateByWorkingCalendar(workingCalendarID);

            if (holidayRate == null)
            {
                //TODO
            }
            else
            {
                ucHolidayPaymentRate.SetPaymentRate(holidayRate);
            }

            //set break
            List<Break> breakList = _dtCtrl.GetBreakListByWorkingCalendar(workingCalendarID);

            if (breakList.Count >= 1)
            {
                lblBreak1.Text = GetTimeString(breakList[0].From) + " - " + GetTimeString(breakList[0].To);
            }
            else
            {
                lblBreak1.Text = "";
            }

            if (breakList.Count >= 2)
            {
                lblBreak2.Text = GetTimeString(breakList[1].From) + " - " + GetTimeString(breakList[0].To);
            }
            else
            {
                lblBreak2.Text = "";
            }

            if (breakList.Count >= 3)
            {
                lblBreak3.Text = GetTimeString(breakList[2].From) + " - " + GetTimeString(breakList[0].To);
            }
            else
            {
                lblBreak3.Text = "";
            }

            //set pay period
            PayPeriod payPeriod = _dtCtrl.GetPayPeriod(_workingCalendar.PayPeriodID);

            if (payPeriod == null)
            {
                //TODO
            }
            else
            {
                PayPeriodType payPeriodType = _dtCtrl.GetPayPeriodType(payPeriod.PayPeriodTypeID);

                if (payPeriodType == null)
                {
                    //TODO
                }
                else if (payPeriodType.ID == 5) //custom
                {
                    lblPayPeriod.Text = "Every " + payPeriod.CustomPeriod + " day(s)";
                }
                else
                {
                    lblPayPeriod.Text = payPeriodType.Name;
                }

                lblPayPeriodStartFrom.Text = payPeriod.StartFrom.ToShortDateString();

                //set calendar
                _holidayList = _dtCtrl.GetHolidayListByWorkingCalendar(workingCalendarID);

                WhatEverHere(DateTime.Today.Year, DateTime.Today.Month);
            }
        }

        List<int> formattedMonth = new List<int>();

        private void WhatEverHere(int year, int month)
        {
            WhatEverHere(year, month, true);
        }

        private void WhatEverHere(int year, int month, bool loop)
        {
            int yearMonth = Convert.ToInt32(year + "" + month);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            if (formattedMonth.Contains(yearMonth) == false)
            {
                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime date = new DateTime(year, month, i);

                    for (int j = _holidayList.Count - 1; j >= 0; j--)
                    {
                        Holiday holiday = _holidayList[j];

                        if (date.Month == holiday.Date.Month && date.Day == holiday.Date.Day)
                        {
                            _holidayList.RemoveAt(j);

                            DateItem dateItem = new DateItem();
                            dateItem.BackColor1 = _holidayColor;
                            dateItem.Date = date;

                            mclWorkingCalendar.AddDateInfo(dateItem);
                        }
                    }

                    if (IsNonWorkDay(date))
                    {
                        DateItem dateItem = new DateItem();
                        dateItem.BackColor1 = _nonWorkdayColor;
                        dateItem.Date = date;

                        mclWorkingCalendar.AddDateInfo(dateItem);
                    }
                }

                formattedMonth.Add(yearMonth);
            }

            if (loop)
            {
                if (month == 12)
                    WhatEverHere(year + 1, 1, false);
                else
                    WhatEverHere(year, month + 1, false);
                if (month == 1)
                    WhatEverHere(year - 1, 12, false);
                else
                    WhatEverHere(year, month - 1, false);
            }
        }

        private bool IsNonWorkDay(DateTime date)
        {
            if (_workingCalendar != null)
            {
                if (date.DayOfWeek == DayOfWeek.Monday && _workingCalendar.WorkOnMonday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Tuesday && _workingCalendar.WorkOnTuesday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Wednesday && _workingCalendar.WorkOnWednesday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Thursday && _workingCalendar.WorkOnThursday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Friday && _workingCalendar.WorkOnFriday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Saturday && _workingCalendar.WorkOnSaturday == false)
                    return true;

                if (date.DayOfWeek == DayOfWeek.Sunday && _workingCalendar.WorkOnSunday == false)
                    return true;

            }

            return false;
        }

        private string GetTimeString(DateTime dt)
        {
            return dt.ToShortTimeString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mclWorkingCalendar_MonthChanged(object sender, Pabo.Calendar.MonthChangedEventArgs e)
        {
            WhatEverHere(e.Year, e.Month);
        }
    }
}