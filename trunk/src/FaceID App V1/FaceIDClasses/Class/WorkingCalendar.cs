using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class WorkingCalendar : MarshalByRefObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool WorkOnMonday { get; set; }
        public bool WorkOnTuesday { get; set; }
        public bool WorkOnWednesday { get; set; }
        public bool WorkOnThursday { get; set; }
        public bool WorkOnFriday { get; set; }
        public bool WorkOnSaturday { get; set; }
        public bool WorkOnSunday { get; set; }
        public DateTime RegularWorkingFrom { get; set; }
        public DateTime RegularWorkingTo { get; set; }
        public int PayPeriodID { get; set; }
        public int GraceForwardToEntry { get; set; }
        public int GraceBackwardToExit { get; set; }
        public int EarliestBeforeEntry { get; set; }
        public int LastestAfterExit { get; set; }
    }
}
