using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Task
{
    public interface ITaskDoer
    {
        bool RemoveEmployeeFromTerminal();

        bool CalculateAttendanceRecord();
    }
}
