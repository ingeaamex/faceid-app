using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Class
{
    public class Config : MarshalByRefObject
    {
        public static readonly DateTime MinDate = new DateTime(1899, 12, 30);

        public int ID { get; set; }
        public bool ScheduledBackup { get; set; }
        public int BackupPeriod { get; set; }
        public string BackupFolder { get; set; }
        public bool BackupRemind { get; set; }
        public int BackupRemindPeriod { get; set; }
        public bool RestoreFromLatest { get; set; }
        public string RestoreFromFile { get; set; }
    }
}
