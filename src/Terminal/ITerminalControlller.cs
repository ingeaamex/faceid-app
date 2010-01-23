using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public interface ITerminalControlller
    {
        List<AttendanceRecord> GetAttendanceRecord(Terminal terminal, DateTime dtFrom, DateTime dtTo);

        bool AddEmployee(Terminal terminal, Employee employee);
        bool GetEmployee(Terminal terminal, int employeeID);
    }
}
