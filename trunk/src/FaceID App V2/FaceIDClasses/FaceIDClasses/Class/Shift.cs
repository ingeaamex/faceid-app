using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Shift : MarshalByRefObject
    {
        public int ID { get; set; }
        public int WorkingCalendarID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
