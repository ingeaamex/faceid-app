using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class EmployeeTerminal : MarshalByRefObject
    {
        public int EmployeeNumber { get; set; }
        public int TerminalID { get; set; }
    }
}
