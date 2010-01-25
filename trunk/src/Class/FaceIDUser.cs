using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class FaceIDUser
    {
        public int EmployeeNumber { get; set; }
        public string Password { get; set; }
        public bool UserManagementAccess { get; set; }
        public bool TerminalManagementAccess { get; set; }
        public bool CompanyDepartmentManagementAccess { get; set; }
        public bool WorkingCalendarManagementAccess { get; set; }
        public bool EmployeeManagementAccess { get; set; }
        public bool AttendanceManagementAccess { get; set; }
    }
}
