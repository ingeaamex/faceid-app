using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class PaymentRate
    {
        public int ID { get; set; }
        public int NumberOfRegularHours { get; set; }
        public int RegularRate { get; set; }
        public int NumberOfOvertime1 { get; set; }
        public int OvertimeRate1 { get; set; }
        public int NumberOfOvertime2 { get; set; }
        public int OvertimeRate2 { get; set; }
        public int NumberOfOvertime3 { get; set; }
        public int OvertimeRate3 { get; set; }
        public int NumberOfOvertime4 { get; set; }
        public int OvertimeRate4 { get; set; }
        public int DayTypeID { get; set; }
    }
}
