using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceLogReport : MarshalByRefObject
    {
        public int ID { get; set; }
        public int PayrollNumber { get; set; }
        public int EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string JobDescription { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime WorkTo { get; set; }
        public double RegularHour { get; set; }
        public double WorkingHour { get; set; }
        public double TotalHour { get; set; }
        public double RegularRate { get; set; }
        public double OvertimeHour1 { get; set; }
        public double OvertimeRate1 { get; set; }
        public double OvertimeHour2 { get; set; }
        public double OvertimeRate2 { get; set; }
        public double OvertimeHour3 { get; set; }
        public double OvertimeRate3 { get; set; }
        public double OvertimeHour4 { get; set; }
        public double OvertimeRate4 { get; set; }
        public int DayTypeID { get; set; }
        public int PayPeriodID { get; set; }
        public string AttendanceRecordIDList { get; set; }
    }

    public class AttendanceSummaryReport
    {
        private double _totalHour = -1;

        public int EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateLog { get; set; }
        public string WorkingHour { get; set; }
        public double TotalHour { get { return _totalHour; } set { _totalHour = value; } }
        public double[] ChartData { get; set; }
    }
}