using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class EmployeeReport : MarshalByRefObject
    {
        private DateTime _hiredDate = DateTime.MaxValue;
        public int EmployeeNo { get; set; }
        public string DepartmentName { get; set; }
        public string FullName { get; set; }
        public string JobDescription { get; set; }
        public DateTime HiredDate { set { _hiredDate = value; } get { return _hiredDate; } }
    }
}