using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class RoostedDayOff : MarshalByRefObject
    {
        public int ID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime Date { get; set; }
        public int TotalHours { get; set; }
        public string Note { get; set; }
    }
}
