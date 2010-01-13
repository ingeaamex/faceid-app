using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceRecord
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime Time { get; set; }
        public string PhotoData { get; set; }
    }
}
