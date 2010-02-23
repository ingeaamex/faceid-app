using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Holiday : MarshalByRefObject
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int WorkingCalendarID { get; set; }
    }
}
