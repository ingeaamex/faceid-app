using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta.Task
{
    public class TaskDoer : ITaskDoer
    {
        private IDataController _dtCtrl;

        public TaskDoer()
        {
            _dtCtrl = LocalDataController.Instance;
        }

        #region ITaskDoer Members

        public bool RemoveEmployeeFromTerminal()
        {
            throw new NotImplementedException();
        }

        public bool CalculateAttendanceRecord()
        {
            throw new NotImplementedException();
        }

        public bool BackupDatabase()
        {
            throw new NotImplementedException();
        }

        public void RemindBackupDatabase()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
