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

        bool UpdateEmployee(Terminal terminal, Employee employee);
        bool RemoveEmployee(Terminal terminal, int employeeNumber);
        Employee GetEmployee(Terminal terminal, int employeeNumber);
        List<Employee> GetAllEmployee(Terminal terminal);

        bool IsTerminalConnected(Terminal terminal);
    }
}
