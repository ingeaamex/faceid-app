using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class PayrollExport : MarshalByRefObject
    {
        public int PayrollNumber { get; set; }
        public int EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string JobDescription { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double RegularHour { get; set; }
        public string OvertimeHour { get; set; }
        public double TotalHours { get; set; }
        public double TotalHoursWithRate { get; set; }
        public double TotalOvertimeHours { get; set; }
    }
}
