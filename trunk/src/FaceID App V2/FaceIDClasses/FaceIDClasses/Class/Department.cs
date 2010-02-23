using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Department : MarshalByRefObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public int SupDepartmentID { get; set; }
    }
}
