using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Task
{
    public interface ITaskDoer
    {
        void RemoveEmployeeFromTerminal();

        void BackupDatabase();

        void RemindBackupDatabase();
    }
}
