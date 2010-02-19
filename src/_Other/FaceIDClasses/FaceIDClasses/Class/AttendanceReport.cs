using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceReport : MarshalByRefObject
    {
        public int ID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime WorkFrom { get; set; }
        public DateTime WorkTo { get; set; }
        public double RegularHour { get; set; }
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
}
