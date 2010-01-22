﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceLogRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeNumber { get; set; }
        public List<object[]> InOutTime { get; set; }
        public List<string> Note { get; set; }
        public List<int[]> TotalHour { get; set; }
        public List<DateTime> DateLog { get; set; }
    }
}