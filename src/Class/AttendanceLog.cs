using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceLog
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeNumber { get; set; }
        public List<string> AttendanceDetail { get; set; }
        public int TotalHour { get; set; }
        public List<string> Note { get; set; }
        public DateTime DateLog { get; set; }
    }
}