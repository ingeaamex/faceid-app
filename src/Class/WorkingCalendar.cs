using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class WorkingCalendar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime RegularWorkingFrom { get; set; }
        public DateTime RegularWorkingTo { get; set; }
        public int PayPeriodID { get; set; }
        public DateTime PayPeriodStartFrom { get; set; }
        public int PayPeriod { get; set; }
    }
}
