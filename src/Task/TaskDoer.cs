using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
using System.Windows.Forms;
using System.Threading;

namespace FaceIDAppVBEta.Task
{
    public class TaskDoer : Form, ITaskDoer
    {
        private IDataController _dtCtrl;
        private ITerminalController _terCtrl;

        private int _timeToSleep1 = Convert.ToInt32(TimeSpan.FromMinutes(1).TotalMilliseconds);
        private int _timeToSleep2 = Convert.ToInt32(TimeSpan.FromMinutes(15).TotalMilliseconds);
        private int _timetoSleep3 = Convert.ToInt32(TimeSpan.FromHours(23).TotalMilliseconds);

        public TaskDoer()
        {
            
        }

        #region ITaskDoer Members

        public void RemoveEmployeeFromTerminal()
        {
            try
            {
                _dtCtrl = LocalDataController.Instance;
                List<UndeletedEmployeeNumber> undelEmployeeNumberList = null;
                lock (_dtCtrl)
                {
                    _dtCtrl.GetUndeletedEmployeeNumberList();
                }

                foreach (UndeletedEmployeeNumber undelEmployeeNumber in undelEmployeeNumberList)
                {
                    Terminal terminal = null;

                    lock(_dtCtrl)
                    {
                        terminal = _dtCtrl.GetTerminal(undelEmployeeNumber.TerminalID);
                    }

                    _terCtrl = new TerminalController();
                    if (_terCtrl.RemoveEmployee(terminal, undelEmployeeNumber.EmployeeNumber))
                    {
                        bool deleted = false;
                        lock(_dtCtrl)
                        {
                            deleted = _dtCtrl.DeleteUndeletedEmployeeNumber(undelEmployeeNumber);
                        }

                        Thread.Sleep(_timeToSleep2);
                        RemoveEmployeeFromTerminal();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                Thread.Sleep(_timeToSleep1);
                RemoveEmployeeFromTerminal();
            }
        }

        public void BackupDatabase()
        {
            try
            {
                Config config = _dtCtrl.GetConfig();

                if (config.ScheduledBackup)
                {
                    if (config.BackupPeriod == 1 || config.BackupPeriod == 7 && (int)DateTime.Today.DayOfWeek == config.BackupDay)
                    {
                        int timeDiff = Util.CompareTime(config.BackupTime, DateTime.Now);

                        if (timeDiff <= Config.TimeBound) //in allowed range
                        {
                            string fileName = "FaceIDBK" + DateTime.Now.Ticks;

                            if (config.BackupFolder.EndsWith(@"\") == false)
                                config.BackupFolder += @"\";

                            string filePath = config.BackupDay + fileName;
                            
                            _dtCtrl = LocalDataController.Instance;
                            lock (_dtCtrl)
                            {
                                _dtCtrl.BackupDatabase(filePath);
                            }

                            //sleep for 23 hours
                            Thread.Sleep(_timetoSleep3);
                            BackupDatabase();
                        }
                        else //sleep until the right time
                        {
                            if (timeDiff < 0)
                                timeDiff += TimeSpan.FromDays(1).Seconds;

                            Thread.Sleep(Convert.ToInt32(TimeSpan.FromSeconds(timeDiff).TotalMilliseconds));
                            BackupDatabase();
                        }
                    }
                }
            }
            catch
            {
                //TODO
                //Exception: another process is accessing db at the time
                
                Thread.Sleep(_timeToSleep1);
                BackupDatabase();
            }
        }

        public void RemindBackupDatabase()
        {
            try
            {
                Config config = _dtCtrl.GetConfig();

                if (config.BackupRemind)
                {
                    int dateDiff = Util.CompareDate(config.LastestBackup, DateTime.Now);

                    if (dateDiff > config.BackupRemindPeriod)
                    {
                        MessageBox.Show("Your database has not been updated for " + dateDiff + " days.");
                    }
                }

                throw new Exception();
            }
            catch
            {
                Thread.Sleep(_timeToSleep2);
                RemindBackupDatabase();
            }
        }

        #endregion
    }
}
