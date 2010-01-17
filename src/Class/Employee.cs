using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Employee
    {
        public int PayrollNumber { get; set; }
        public int EmployeeNumber { get; set; }
        public int DepartmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WorkingCalendarID { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime LeftDate { get; set; }
        public DateTime Birthday { get; set; }
        public string JobDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PhotoData { get; set; }
        public bool Active { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
    }
}
