using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class PayPeriod : MarshalByRefObject
    {
        public int ID { get; set; }
        public int PayPeriodTypeID { get; set; }
        public DateTime StartFrom { get; set; }
        public int CustomPeriod { get; set; }
    }
}
