using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public interface ITerminalController
    {
        List<AttendanceRecord> GetAttendanceRecord(Terminal terminal, DateTime dtFrom, DateTime dtTo);
        bool DeleteAttendanceRecord(Terminal terminal);

        bool AddUpdateEmployee(Terminal terminal, Employee employee);
        bool RemoveEmployee(Terminal terminal, Employee employee);
        Employee GetEmployee(Terminal terminal, int employeeID);
        List<Employee> GetAllEmployee(Terminal terminal);
    }
}
