using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Terminal : MarshalByRefObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
    }
}
