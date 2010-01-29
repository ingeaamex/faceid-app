using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class PaymentRate : MarshalByRefObject
    {
        public int ID { get; set; }
        public double NumberOfRegularHours { get; set; }
        public double RegularRate { get; set; }
        public double NumberOfOvertime1 { get; set; }
        public double OvertimeRate1 { get; set; }
        public double NumberOfOvertime2 { get; set; }
        public double OvertimeRate2 { get; set; }
        public double NumberOfOvertime3 { get; set; }
        public double OvertimeRate3 { get; set; }
        public double NumberOfOvertime4 { get; set; }
        public double OvertimeRate4 { get; set; }
        public int DayTypeID { get; set; }
        public int WorkingCalendarID { get; set; }
    }
}
