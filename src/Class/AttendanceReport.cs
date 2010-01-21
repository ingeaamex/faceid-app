using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceReport
    {
        public int AttendanceReportID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime WorkTo { get; set; }
        public int RegularHour { get; set; }
        public int RegularRate { get; set; }
        public int OvertimeHour1 { get; set; }
        public int OvertimeRate1 { get; set; }
        public int OvertimeHour2 { get; set; }
        public int OvertimeRate2 { get; set; }
        public int OvertimeHour3 { get; set; }
        public int OvertimeRate3 { get; set; }
        public int OvertimeHour4 { get; set; }
        public int OvertimeRate4 { get; set; }
        public int DayTypeID { get; set; }
        public int PayPeriodID { get; set; }
    }
}
