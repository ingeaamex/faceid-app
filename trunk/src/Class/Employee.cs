using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Employee : MarshalByRefObject
    {
        public Employee()
        {
            DepartmentID = 1; //default department

            Active = true;
            ActiveFrom = DateTime.Now;

            FirstName = "";
            LastName = "";
            JobDescription = "";
            PhoneNumber = "";
            Address = "";

            FaceData1 = "";
            FaceData2 = "";
            FaceData3 = "";
            FaceData4 = "";
            FaceData5 = "";
            FaceData6 = "";
            FaceData7 = "";
            FaceData8 = "";
            FaceData9 = "";
            FaceData10 = "";
            FaceData11 = "";
            FaceData12 = "";
            FaceData13 = "";
            FaceData14 = "";
            FaceData15 = "";
            FaceData16 = "";
            FaceData17 = "";
            FaceData18 = "";
        }

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
        public bool Active { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string FaceData1 { get; set; }
        public string FaceData2 { get; set; }
        public string FaceData3 { get; set; }
        public string FaceData4 { get; set; }
        public string FaceData5 { get; set; }
        public string FaceData6 { get; set; }
        public string FaceData7 { get; set; }
        public string FaceData8 { get; set; }
        public string FaceData9 { get; set; }
        public string FaceData10 { get; set; }
        public string FaceData11 { get; set; }
        public string FaceData12 { get; set; }
        public string FaceData13 { get; set; }
        public string FaceData14 { get; set; }
        public string FaceData15 { get; set; }
        public string FaceData16 { get; set; }
        public string FaceData17 { get; set; }
        public string FaceData18 { get; set; }
    }
}
