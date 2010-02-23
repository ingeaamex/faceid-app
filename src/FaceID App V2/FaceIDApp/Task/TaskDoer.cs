using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
using System.Windows.Forms;
using System.Threading;

namespace FaceIDAppVBEta.Task
{
    public class TaskDoer : Form
    {
        private IDataController _dtCtrl;
        private ITerminalController _terCtrl;

        private static TaskDoer _instance;
        private static readonly Object _mutex = new Object();

        private int _timeToSleep1 = Convert.ToInt32(TimeSpan.FromMinutes(1).TotalMilliseconds);
        private int _timeToSleep2 = Convert.ToInt32(TimeSpan.FromMinutes(15).TotalMilliseconds);
        private int _timetoSleep3 = Convert.ToInt32(TimeSpan.FromHours(23).TotalMilliseconds);

        private Thread _thrRemoveEmployee;
        private Thread _thrBackupDatabase;
        private Thread _thrRemindBackup;

        private TaskDoer() { }

        public static TaskDoer Instance
        {
            get
            {
                lock (_mutex)
                {
                    if (_instance == null)
                        _instance = new TaskDoer();
                }

                return _instance;
            }
        }

        private void RemoveEmployeeFromTerminal()
        {
            try
            {
                _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
                List<UndeletedEmployeeNumber> undelEmployeeNumberList = null;
                lock (_dtCtrl)
                {
                    undelEmployeeNumberList = _dtCtrl.GetUndeletedEmployeeNumberList();
                }

                foreach (UndeletedEmployeeNumber undelEmployeeNumber in undelEmployeeNumberList)
                {
                    Terminal terminal = null;

                    lock (_dtCtrl)
                    {
                        terminal = _dtCtrl.GetTerminal(undelEmployeeNumber.TerminalID);
                    }

                    _terCtrl = new TerminalController();
                    if (_terCtrl.RemoveEmployee(terminal, undelEmployeeNumber.EmployeeNumber))
                    {
                        bool deleted = false;
                        lock (_dtCtrl)
                        {
                            deleted = _dtCtrl.DeleteUndeletedEmployeeNumber(undelEmployeeNumber);
                        }

                        if (deleted == false)
                            throw new Exception();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                Thread.Sleep(_timeToSleep2);
                RemoveEmployeeFromTerminal();
            }
            catch
            {
                Thread.Sleep(_timeToSleep1);
                RemoveEmployeeFromTerminal();
            }
        }

        private void BackupDatabase()
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
                            string fileName = "FaceIDBK" + DateTime.Now.Ticks + ".mdb";

                            if (config.BackupFolder.EndsWith(@"\") == false)
                                config.BackupFolder += @"\";

                            string filePath = config.BackupFolder + fileName;

                            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
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

        private void RemindBackupDatabase()
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

        public void KillTasks()
        {
            try
            {
                _thrBackupDatabase.Abort();
            }
            catch { }
            try
            {
                _thrRemindBackup.Abort();
            }
            catch { }
            try
            {
                _thrRemoveEmployee.Abort();
            }
            catch { }
        }

        public void DoTasks()
        {
            if (Properties.Settings.Default.IsClient == false) //server only
            {
                _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

                if (isRunningThread(_thrBackupDatabase) == false)
                {
                    try
                    {
                        _thrBackupDatabase = new Thread(new ThreadStart(BackupDatabase));
                        _thrBackupDatabase.Start();
                    }
                    catch { }
                }
                if (isRunningThread(_thrRemindBackup) == false)
                {
                    try
                    {
                        _thrRemindBackup = new Thread(new ThreadStart(RemindBackupDatabase));
                        _thrRemindBackup.Start();
                    }
                    catch { }
                }

                if (isRunningThread(_thrRemoveEmployee) == false)
                {
                    try
                    {
                        _thrRemoveEmployee = new Thread(new ThreadStart(RemoveEmployeeFromTerminal));
                        _thrRemoveEmployee.Start();
                    }
                    catch { }
                }
            }
        }

        private bool isRunningThread(Thread thr)
        {
            if (thr == null) return false;
            else
                return thr.ThreadState == ThreadState.Running;
        }
    }
}
