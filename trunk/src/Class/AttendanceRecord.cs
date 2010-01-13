using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceRecord
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Time { get; set; }
        public string PhotoData { get; set; }
    }
}
