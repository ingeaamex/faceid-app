using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public interface ITerminalControlller
    {
        List<AttendanceRecord> GetAttendanceRecord(Terminal terminal);

        bool AddEmployee(Terminal terminal, Employee employee);
        bool GetEmployee(Terminal terminal, int employeeID);
    }
}
