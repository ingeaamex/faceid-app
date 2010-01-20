using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class AttendanceRecord
    {
        public int ID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime Time { get; set; }
        public bool CheckIn { get; set; }
        public string PhotoData { get; set; }
        public string Note { get; set; }
    }
}
