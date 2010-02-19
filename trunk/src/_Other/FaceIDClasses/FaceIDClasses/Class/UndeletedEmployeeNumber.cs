using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class UndeletedEmployeeNumber : MarshalByRefObject
    {
        public int EmployeeNumber { get; set; }
        public int TerminalID { get; set; }
    }
}
