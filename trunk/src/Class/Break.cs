using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Break
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Paid { get; set; }
        public int WorkingCalendarID { get; set; }
    }
}
