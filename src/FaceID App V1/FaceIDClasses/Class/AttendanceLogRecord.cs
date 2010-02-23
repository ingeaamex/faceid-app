using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceLogRecord : MarshalByRefObject
    {
        private double _totalHour = -1;

        public int ID { get; set; }
        public int EmployeeNumber { get; set; }
        public string TimeLog { get; set; }
        public string Note { get; set; }
        public DateTime DateLog { get; set; }
        public string EmployeeName { get; set; }
        public double TotalHours
        {
            get { return _totalHour; }
            set { _totalHour = value; }
        }
    }
}