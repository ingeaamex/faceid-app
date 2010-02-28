using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using System.Threading;
using FaceIDAppVBEta.Data;
using System.Diagnostics;

namespace FaceIDApp
{
    class Test : Form
    {
        private Label label1;
        private TextBox txtDuration;
        private Button btnDelRecord;
        private TextBox txtProgress;
        private Label label2;
        private ProgressBar pgbProgress;
        private Button btnClearAttData;
        private Label label3;
        private NumericUpDown nudAdd;
        private Button btnStop;
        private Button btnAddTestData;
        private Button btnClearDB;
        private Button btnAddRecord;

        private void InitializeComponent()
        {
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnDelRecord = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.btnClearAttData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAdd = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnAddTestData = new System.Windows.Forms.Button();
            this.btnClearDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(12, 12);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(130, 23);
            this.btnAddRecord.TabIndex = 0;
            this.btnAddRecord.Text = "Generate AttRecords";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(69, 67);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(176, 20);
            this.txtDuration.TabIndex = 3;
            // 
            // btnDelRecord
            // 
            this.btnDelRecord.Location = new System.Drawing.Point(148, 12);
            this.btnDelRecord.Name = "btnDelRecord";
            this.btnDelRecord.Size = new System.Drawing.Size(130, 23);
            this.btnDelRecord.TabIndex = 5;
            this.btnDelRecord.Text = "Delete AttRecords";
            this.btnDelRecord.UseVisualStyleBackColor = true;
            this.btnDelRecord.Click += new System.EventHandler(this.btnDelRecord_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(69, 94);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(551, 142);
            this.txtProgress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Progress";
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 242);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(608, 15);
            this.pgbProgress.TabIndex = 8;
            // 
            // btnClearAttData
            // 
            this.btnClearAttData.Location = new System.Drawing.Point(284, 12);
            this.btnClearAttData.Name = "btnClearAttData";
            this.btnClearAttData.Size = new System.Drawing.Size(130, 23);
            this.btnClearAttData.TabIndex = 9;
            this.btnClearAttData.Text = "Clear Att Data";
            this.btnClearAttData.UseVisualStyleBackColor = true;
            this.btnClearAttData.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Records";
            // 
            // nudAdd
            // 
            this.nudAdd.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAdd.Location = new System.Drawing.Point(69, 40);
            this.nudAdd.Maximum = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            this.nudAdd.Name = "nudAdd";
            this.nudAdd.Size = new System.Drawing.Size(176, 20);
            this.nudAdd.TabIndex = 11;
            this.nudAdd.ThousandsSeparator = true;
            this.nudAdd.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(421, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnAddTestData
            // 
            this.btnAddTestData.Location = new System.Drawing.Point(284, 44);
            this.btnAddTestData.Name = "btnAddTestData";
            this.btnAddTestData.Size = new System.Drawing.Size(130, 23);
            this.btnAddTestData.TabIndex = 13;
            this.btnAddTestData.Text = "Generate Test Data";
            this.btnAddTestData.UseVisualStyleBackColor = true;
            this.btnAddTestData.Click += new System.EventHandler(this.btnAddTestData_Click);
            // 
            // btnClearDB
            // 
            this.btnClearDB.Location = new System.Drawing.Point(421, 44);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(75, 23);
            this.btnClearDB.TabIndex = 14;
            this.btnClearDB.Text = "Clear DB";
            this.btnClearDB.UseVisualStyleBackColor = true;
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // Test
            // 
            this.ClientSize = new System.Drawing.Size(632, 265);
            this.Controls.Add(this.btnClearDB);
            this.Controls.Add(this.btnAddTestData);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.nudAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClearAttData);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnDelRecord);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddRecord);
            this.Name = "Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public Test()
        {
            _dtCtrl = FaceIDAppVBEta.Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();
        }

        private Random _rand = new Random();

        private long _startPoint = 0;

        private List<AttendanceRecord> _attRecordList = new List<AttendanceRecord>();
        private List<Employee> _empList = new List<Employee>();

        private IDataController _dtCtrl;

        private Thread _thrAddAttRecords;
        private Thread _thrDelAttRecords;
        private Thread _thrClearAttData;

        private Thread _thrAddTestData;
        private Thread _thrClearDB;

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            _thrAddAttRecords = new Thread(new ThreadStart(AddRecord));
            _thrAddAttRecords.Start();
        }

        private delegate void InitProgressCallBack(int maxValue);
        private delegate void AddProgressCallBack(int value);

        private delegate void SetTextCallBack(TextBox txtBox, string text);
        private delegate void AddTextCallBack(TextBox txtBox, string text);

        private delegate void EnableButtonCallBack(Button btn, bool enable);

        private void InitProgress(int maxValue)
        {
            pgbProgress.Value = 0;
            pgbProgress.Maximum = maxValue;
        }

        private void AddProgress(int addValue)
        {
            pgbProgress.Value += addValue;
        }

        private void SetText(TextBox txtBox, string text)
        {
            txtBox.Text = text + "\r\n";
        }

        private void AddText(TextBox txtBox, string text)
        {
            txtBox.Text += text + "\r\n";
        }

        private void AddRecord()
        {
            try
            {
                _startPoint = DateTime.Now.Ticks;

                SetState(1);
                int toBeAdded = (int)nudAdd.Value;

                Invoke(new InitProgressCallBack(InitProgress), new object[] { toBeAdded });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "" });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, "" });

                int added = 0;

                for (int i = 0; i < toBeAdded; i++)
                {
                    AttendanceRecord attRecord = new AttendanceRecord();
                    attRecord.EmployeeNumber = GetRandomEmployeeNumber();
                    attRecord.Time = GetRandomTime();

                    attRecord.ID = _dtCtrl.AddAttendanceRecord(attRecord);

                    if (attRecord.ID > 0)
                    {
                        added++;
                        _attRecordList.Add(attRecord);
                    }

                    string textProgress = "Adding: " + (i + 1) + "/" + toBeAdded + " (Added: " + added + ")";

                    Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                    Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, textProgress });
                    Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });
                }


                //Invoke(new SetTextCallBack(AddText), new object[] { txtProgress, "Calculating" });

                //_dtCtrl.CalculateAttendanceRecord();
                //_dtCtrl.RefreshConnection();

                //Invoke(new SetTextCallBack(AddText), new object[] { txtProgress, "DONE" });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });

                MessageBox.Show(added + " records have been added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("[" + ex.Message + "]" + ex.StackTrace);
            }

            SetState(0);
        }

        private int GetRandomEmployeeNumber()
        {
            if (_empList.Count == 0)
                _empList = _dtCtrl.GetEmployeeList();

            if (_empList.Count == 0)
                throw new Exception("There's no employee.");

            return _empList[_rand.Next(_empList.Count)].EmployeeNumber;
        }

        private DateTime GetRandomTime()
        {
            DateTime minDate = DateTime.Now.AddDays(-30);

            int maxSeconds = (DateTime.Today.DayOfYear - minDate.DayOfYear) * 24 * 60 * 60;
            if (maxSeconds == 0) maxSeconds = 30 * 24 * 60 * 60;

            return minDate.AddSeconds(_rand.Next(maxSeconds));
        }

        private void btnDelRecord_Click(object sender, EventArgs e)
        {
            _thrDelAttRecords = new Thread(new ThreadStart(DelRecord));
            _thrDelAttRecords.Start();
        }

        private void DelRecord()
        {
            try
            {
                _startPoint = DateTime.Now.Ticks;

                SetState(1);
                int toBeDeleted = _attRecordList.Count;

                Invoke(new InitProgressCallBack(InitProgress), new object[] { toBeDeleted });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "" });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, "" });

                int deleteing = 0;
                int deleted = 0;

                for (int i = toBeDeleted - 1; i >= 0; i--)
                {
                    AttendanceRecord attRecord = _attRecordList[i];

                    deleteing++;
                    if (_dtCtrl.DeleteAttendanceRecord(attRecord.ID))
                    {
                        _attRecordList.RemoveAt(i);
                        deleted++;
                    }

                    string textProgress = "Deleting: " + deleteing + "/" + toBeDeleted + " (Deleted: " + deleted + ")";

                    Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                    Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, textProgress });
                    Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });
                }

                MessageBox.Show(deleted + " records have been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetState(0);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            _thrClearAttData = new Thread(new ThreadStart(ClearAll));
            _thrClearAttData.Start();
        }

        private void ClearAll()
        {
            try
            {
                _startPoint = DateTime.Now.Ticks;

                SetState(1);

                int toBeCleared = 3;

                Invoke(new InitProgressCallBack(InitProgress), new object[] { toBeCleared });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "" });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, "" });

                int clearing = 0;
                int cleared = 0;

                clearing++;

                string textProgress = "Clearing: " + clearing + "/" + toBeCleared + " (Cleared: " + cleared + ")";

                Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, textProgress });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });

                clearing++;
                if (_dtCtrl.DeleteAllAttendanceRecord())
                    cleared++;

                textProgress = "Clearing: " + clearing + "/" + toBeCleared + " (Cleared: " + cleared + ")";

                Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, textProgress });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });

                clearing++;
                if (_dtCtrl.DeleteAllAttendanceReport())
                    cleared++;

                textProgress = "Clearing: " + clearing + "/" + toBeCleared + " (Cleared: " + cleared + ")";

                Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, textProgress });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });

                MessageBox.Show(cleared + " table(s) have been cleared");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetState(0);
        }

        private string GetDuration()
        {
            TimeSpan timeSpan = TimeSpan.FromTicks(DateTime.Now.Ticks - _startPoint);

            int min = timeSpan.Minutes;
            int sec = timeSpan.Seconds;
            int mil = timeSpan.Milliseconds;

            string text = "";

            if (min.ToString().Length < 2) text += "0";
            text += min.ToString() + ":";

            if (sec.ToString().Length < 2) text += "0";
            text += sec.ToString() + ":";

            if (mil.ToString().Length < 2) text += "00";
            else if (mil.ToString().Length < 3) text += "0";
            text += mil.ToString();

            return text;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _thrAddAttRecords.Abort();
            }
            catch { }
            try
            {
                _thrDelAttRecords.Abort();
            }
            catch { }
            try
            {
                _thrClearAttData.Abort();
            }
            catch { }

            SetState(0);
        }

        private void SetState(int state)
        {
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnStop, (state > 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnAddRecord, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnDelRecord, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnClearAttData, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnAddTestData, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnClearDB, (state == 0) });
        }


        private void EnableButton(Button btn, bool enable)
        {
            btn.Enabled = enable;
        }

        private void btnAddTestData_Click(object sender, EventArgs e)
        {
            _thrAddTestData = new Thread(new ThreadStart(AddTestData));
            _thrAddTestData.Start();
        }

        private void AddTestData()
        {
            _dtCtrl.BeginTransaction();

            try
            {
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "Adding ..." });

                AddTestOneShiftNonFlexi(ref _dtCtrl);

                AddTestOneShiftFlexi(ref _dtCtrl);

                AddTestMultiShiftNonFlexi(ref _dtCtrl);

                _dtCtrl.CommitTransaction();

                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "Adding Complete." });
            }
            catch (Exception ex)
            {
                _dtCtrl.RollbackTransaction();
                Invoke(new AddTextCallBack(SetText), new object[] { txtProgress, "Error: " + ex.Message });
            }
        }

        private void AddTestMultiShiftNonFlexi(ref IDataController _dtCtrl)
        {
            #region add test company
            Company com = new Company();
            com.Name = DateTime.Now.Ticks.ToString();
            com.ID = _dtCtrl.AddCompany(com);
            #endregion

            #region add test department
            Department dep = new Department();
            dep.CompanyID = com.ID;
            dep.Name = DateTime.Now.Ticks.ToString();
            dep.SupDepartmentID = 0; //root
            dep.ID = _dtCtrl.AddDepartment(dep);
            #endregion

            #region add test working calendar
            WorkingCalendar wCal = new WorkingCalendar();

            wCal.Name = DateTime.Now.Ticks.ToString();

            wCal.WorkOnMonday = true;
            wCal.WorkOnTuesday = true;
            wCal.WorkOnWednesday = true;
            wCal.WorkOnThursday = true;
            wCal.WorkOnFriday = true;

            wCal.GraceForwardToEntry = 30;
            wCal.GraceBackwardToExit = 30;
            wCal.EarliestBeforeEntry = 60;
            wCal.LastestAfterExit = 60;

            List<Shift> shiftList = new List<Shift>();
            Shift shift1 = new Shift();
            shift1.From = new DateTime(2000, 2, 2, 8, 0, 0);
            shift1.To = new DateTime(2000, 2, 2, 12, 0, 0);
            shiftList.Add(shift1);

            Shift shift2 = new Shift();
            shift2.From = new DateTime(2000, 2, 2, 14, 0, 0);
            shift2.To = new DateTime(2000, 2, 2, 18, 0, 0);
            shiftList.Add(shift2);

            Shift shift3 = new Shift();
            shift3.From = new DateTime(2000, 2, 2, 20, 0, 0);
            shift3.To = new DateTime(2000, 2, 3, 0, 0, 0);
            shiftList.Add(shift3);

            List<Break> breakList = new List<Break>();
            Break break1 = new Break();
            break1.From = new DateTime(2000, 2, 2, 12, 0, 0);
            break1.To = new DateTime(2000, 2, 2, 13, 0, 0);
            break1.Name = "break1";
            break1.Paid = true;

            breakList.Add(break1);

            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            workingDayPaymentRate.NumberOfRegularHours = 4;
            workingDayPaymentRate.RegularRate = 100;
            workingDayPaymentRate.NumberOfOvertime1 = 1;
            workingDayPaymentRate.OvertimeRate1 = 200;
            workingDayPaymentRate.NumberOfOvertime1 = 1;
            workingDayPaymentRate.OvertimeRate1 = 200;
            workingDayPaymentRate.NumberOfOvertime1 = 1;
            workingDayPaymentRate.OvertimeRate1 = 200;
            workingDayPaymentRate.NumberOfOvertime1 = 1;
            workingDayPaymentRate.OvertimeRate1 = 200;

            PaymentRate nonWorkingDayPaymentRate = workingDayPaymentRate;
            PaymentRate holidayPaymentRate = workingDayPaymentRate;

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = new DateTime(2010, 1, 1);

            wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, shiftList, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);
            #endregion

            #region add test employee
            Employee emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString();
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 0;
            emp.FirstName = DateTime.Now.Ticks.ToString();
            emp.JobDescription = DateTime.Now.Ticks.ToString();
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp.WorkingCalendarID = wCal.ID;
            emp.PayrollNumber = _dtCtrl.AddEmployee(emp, new List<Terminal>());
            #endregion

            #region add test att records 1
            //att1 : expected totalHours: 4
            AttendanceRecord att11 = new AttendanceRecord();
            att11.EmployeeNumber = emp.EmployeeNumber;
            att11.Time = new DateTime(2010, 1, 1, 8, 0, 0);
            att11.ID = _dtCtrl.AddAttendanceRecord(att11);

            AttendanceRecord att12 = new AttendanceRecord();
            att12.EmployeeNumber = emp.EmployeeNumber;
            att12.Time = new DateTime(2010, 1, 1, 12, 0, 0);
            att12.ID = _dtCtrl.AddAttendanceRecord(att12);

            //att2 : expected totalHours: 4
            AttendanceRecord att13 = new AttendanceRecord();
            att13.EmployeeNumber = emp.EmployeeNumber;
            att13.Time = new DateTime(2010, 1, 1, 14, 0, 0);
            att13.ID = _dtCtrl.AddAttendanceRecord(att13);

            AttendanceRecord att14 = new AttendanceRecord();
            att14.EmployeeNumber = emp.EmployeeNumber;
            att14.Time = new DateTime(2010, 1, 1, 18, 0, 0);
            att14.ID = _dtCtrl.AddAttendanceRecord(att14);

            //att3 : expected totalHours: 4
            AttendanceRecord att21 = new AttendanceRecord();
            att21.EmployeeNumber = emp.EmployeeNumber;
            att21.Time = new DateTime(2010, 1, 1, 20, 0, 0);
            att21.ID = _dtCtrl.AddAttendanceRecord(att21);

            AttendanceRecord att22 = new AttendanceRecord();
            att22.EmployeeNumber = emp.EmployeeNumber;
            att22.Time = new DateTime(2010, 1, 2, 0, 0, 0);
            att22.ID = _dtCtrl.AddAttendanceRecord(att22);

            //att4 : expected totalHours: 3
            AttendanceRecord att31 = new AttendanceRecord();
            att31.EmployeeNumber = emp.EmployeeNumber;
            att31.Time = new DateTime(2010, 1, 2, 8, 15, 0);
            att31.ID = _dtCtrl.AddAttendanceRecord(att31);

            AttendanceRecord att32 = new AttendanceRecord();
            att32.EmployeeNumber = emp.EmployeeNumber;
            att32.Time = new DateTime(2010, 1, 2, 11, 0, 0);
            att32.ID = _dtCtrl.AddAttendanceRecord(att32);

            //att4 : expected totalHours: 4 + 1 over
            AttendanceRecord att41 = new AttendanceRecord();
            att41.EmployeeNumber = emp.EmployeeNumber;
            att41.Time = new DateTime(2010, 1, 2, 14, 00, 0);
            att41.ID = _dtCtrl.AddAttendanceRecord(att41);

            AttendanceRecord att42 = new AttendanceRecord();
            att42.EmployeeNumber = emp.EmployeeNumber;
            att42.Time = new DateTime(2010, 1, 2, 19, 0, 0);
            att42.ID = _dtCtrl.AddAttendanceRecord(att42);

            //att4 : expected totalHours: 
            AttendanceRecord att51 = new AttendanceRecord();
            att51.EmployeeNumber = emp.EmployeeNumber;
            att51.Time = new DateTime(2010, 1, 2, 20, 06, 0);
            att51.ID = _dtCtrl.AddAttendanceRecord(att51);

            AttendanceRecord att52 = new AttendanceRecord();
            att52.EmployeeNumber = emp.EmployeeNumber;
            att52.Time = new DateTime(2010, 1, 2, 23, 2, 0);
            att52.ID = _dtCtrl.AddAttendanceRecord(att52);

            //att5 : expected totalHours: 
            AttendanceRecord att61 = new AttendanceRecord();
            att61.EmployeeNumber = emp.EmployeeNumber;
            att61.Time = new DateTime(2010, 1, 3, 9, 0, 0);
            att61.ID = _dtCtrl.AddAttendanceRecord(att61);

            AttendanceRecord att62 = new AttendanceRecord();
            att62.EmployeeNumber = emp.EmployeeNumber;
            att62.Time = new DateTime(2010, 1, 3, 12, 0, 0);
            att62.ID = _dtCtrl.AddAttendanceRecord(att62);

            //att6 : expected totalHours: 4 
            AttendanceRecord att63 = new AttendanceRecord();
            att63.EmployeeNumber = emp.EmployeeNumber;
            att63.Time = new DateTime(2010, 1, 3, 14, 30, 0);
            att63.ID = _dtCtrl.AddAttendanceRecord(att63);

            AttendanceRecord att64 = new AttendanceRecord();
            att64.EmployeeNumber = emp.EmployeeNumber;
            att64.Time = new DateTime(2010, 1, 3, 18, 30, 0);
            att64.ID = _dtCtrl.AddAttendanceRecord(att64);

            //att7 : expected totalHours: 4 + 1
            AttendanceRecord att65 = new AttendanceRecord();
            att65.EmployeeNumber = emp.EmployeeNumber;
            att65.Time = new DateTime(2010, 1, 3, 20, 0, 0);
            att65.ID = _dtCtrl.AddAttendanceRecord(att65);

            AttendanceRecord att66 = new AttendanceRecord();
            att66.EmployeeNumber = emp.EmployeeNumber;
            att66.Time = new DateTime(2010, 1, 3, 22, 00, 0);
            att66.ID = _dtCtrl.AddAttendanceRecord(att66);

            AttendanceRecord att67 = new AttendanceRecord();
            att67.EmployeeNumber = emp.EmployeeNumber;
            att67.Time = new DateTime(2010, 1, 3, 22, 30, 0);
            att67.ID = _dtCtrl.AddAttendanceRecord(att67);

            AttendanceRecord att68 = new AttendanceRecord();
            att68.EmployeeNumber = emp.EmployeeNumber;
            att68.Time = new DateTime(2010, 1, 4, 0, 45, 0);
            att68.ID = _dtCtrl.AddAttendanceRecord(att68);

            #endregion  
        }

        private void AddTestOneShiftFlexi(ref IDataController _dtCtrl)
        {
            #region add test company
            Company com = new Company();
            com.Name = DateTime.Now.Ticks.ToString();
            com.ID = _dtCtrl.AddCompany(com);
            #endregion

            #region add test department
            Department dep = new Department();
            dep.CompanyID = com.ID;
            dep.Name = DateTime.Now.Ticks.ToString();
            dep.SupDepartmentID = 0; //root
            dep.ID = _dtCtrl.AddDepartment(dep);
            #endregion

            #region add test working calendar
            List<Break> breakList = new List<Break>();
            Break break1 = new Break();
            break1.From = new DateTime(2000, 2, 2, 12, 0, 0);
            break1.To = new DateTime(2000, 2, 2, 13, 0, 0);
            break1.Name = "break1";
            break1.Paid = true;

            breakList.Add(break1);

            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            workingDayPaymentRate.NumberOfRegularHours = 7;
            workingDayPaymentRate.RegularRate = 100;
            workingDayPaymentRate.NumberOfOvertime1 = 8;
            workingDayPaymentRate.OvertimeRate1 = 200;

            PaymentRate nonWorkingDayPaymentRate = workingDayPaymentRate;
            PaymentRate holidayPaymentRate = workingDayPaymentRate;

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = new DateTime(2010, 1, 1);

            WorkingCalendar wCal = new WorkingCalendar();
            wCal.Name = DateTime.Now.Ticks.ToString();
            wCal.ApplyFlexiHours = true;
            wCal.FlexiHours = 40;
            wCal.WeekStartsOn = 3; //Thursday

            List<Shift> shiftList = new List<Shift>();
            Shift shift1 = new Shift();
            shift1.From = new DateTime(2000, 2, 2, 9, 0, 0);
            shift1.To = new DateTime(2000, 2, 2, 18, 0, 0);
            shiftList.Add(shift1);

            wCal.WorkOnMonday = true;
            wCal.WorkOnTuesday = true;
            wCal.WorkOnWednesday = true;
            wCal.WorkOnThursday = true;
            wCal.WorkOnFriday = true;

            wCal.GraceForwardToEntry = 30;
            wCal.GraceBackwardToExit = 30;
            wCal.EarliestBeforeEntry = 60;
            wCal.LastestAfterExit = 180;

            wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, shiftList, new List<Break>(), holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);
            #endregion

            #region add test employee
            Employee emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString();
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 0;
            emp.FirstName = DateTime.Now.Ticks.ToString();
            emp.JobDescription = DateTime.Now.Ticks.ToString();
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp.WorkingCalendarID = wCal.ID;
            emp.PayrollNumber = _dtCtrl.AddEmployee(emp, new List<Terminal>());
            #endregion

            #region add test att records 2
            //att7 : expected regHour: 10
            AttendanceRecord att71 = new AttendanceRecord();
            att71.EmployeeNumber = emp.EmployeeNumber;
            att71.Time = new DateTime(2010, 1, 7, 9, 0, 0);
            att71.ID = _dtCtrl.AddAttendanceRecord(att71);

            AttendanceRecord att72 = new AttendanceRecord();
            att72.EmployeeNumber = emp.EmployeeNumber;
            att72.Time = new DateTime(2010, 1, 7, 19, 0, 0);
            att72.ID = _dtCtrl.AddAttendanceRecord(att72);

            //att8 : expected regHour: 8
            AttendanceRecord att81 = new AttendanceRecord();
            att81.EmployeeNumber = emp.EmployeeNumber;
            att81.Time = new DateTime(2010, 1, 8, 9, 0, 0);
            att81.ID = _dtCtrl.AddAttendanceRecord(att81);

            AttendanceRecord att82 = new AttendanceRecord();
            att82.EmployeeNumber = emp.EmployeeNumber;
            att82.Time = new DateTime(2010, 1, 8, 17, 0, 0);
            att82.ID = _dtCtrl.AddAttendanceRecord(att82);

            //att9 : expected regHour: 8
            AttendanceRecord att91 = new AttendanceRecord();
            att91.EmployeeNumber = emp.EmployeeNumber;
            att91.Time = new DateTime(2010, 1, 9, 9, 0, 0);
            att91.ID = _dtCtrl.AddAttendanceRecord(att91);

            AttendanceRecord att92 = new AttendanceRecord();
            att92.EmployeeNumber = emp.EmployeeNumber;
            att92.Time = new DateTime(2010, 1, 9, 17, 0, 0);
            att92.ID = _dtCtrl.AddAttendanceRecord(att92);

            //att10 : expected regHour: 8
            AttendanceRecord att101 = new AttendanceRecord();
            att101.EmployeeNumber = emp.EmployeeNumber;
            att101.Time = new DateTime(2010, 1, 10, 9, 00, 0);
            att101.ID = _dtCtrl.AddAttendanceRecord(att101);

            AttendanceRecord att102 = new AttendanceRecord();
            att102.EmployeeNumber = emp.EmployeeNumber;
            att102.Time = new DateTime(2010, 1, 10, 17, 0, 0);
            att102.ID = _dtCtrl.AddAttendanceRecord(att102);

            //att11 : expected regHour: 4
            AttendanceRecord att111 = new AttendanceRecord();
            att111.EmployeeNumber = emp.EmployeeNumber;
            att111.Time = new DateTime(2010, 1, 11, 9, 0, 0);
            att111.ID = _dtCtrl.AddAttendanceRecord(att111);

            AttendanceRecord att112 = new AttendanceRecord();
            att112.EmployeeNumber = emp.EmployeeNumber;
            att112.Time = new DateTime(2010, 1, 11, 13, 0, 0);
            att112.ID = _dtCtrl.AddAttendanceRecord(att112);

            //att12 : expected regHour: 2 overHour: 2
            AttendanceRecord att121 = new AttendanceRecord();
            att121.EmployeeNumber = emp.EmployeeNumber;
            att121.Time = new DateTime(2010, 1, 12, 9, 0, 0);
            att121.ID = _dtCtrl.AddAttendanceRecord(att121);

            AttendanceRecord att122 = new AttendanceRecord();
            att122.EmployeeNumber = emp.EmployeeNumber;
            att122.Time = new DateTime(2010, 1, 12, 13, 0, 0);
            att122.ID = _dtCtrl.AddAttendanceRecord(att122);

            //att13 : expected overHour: 2
            AttendanceRecord att131 = new AttendanceRecord();
            att131.EmployeeNumber = emp.EmployeeNumber;
            att131.Time = new DateTime(2010, 1, 13, 9, 0, 0);
            att131.ID = _dtCtrl.AddAttendanceRecord(att131);

            AttendanceRecord att132 = new AttendanceRecord();
            att132.EmployeeNumber = emp.EmployeeNumber;
            att132.Time = new DateTime(2010, 1, 13, 11, 0, 0);
            att132.ID = _dtCtrl.AddAttendanceRecord(att132);
            #endregion
        }

        private void AddTestOneShiftNonFlexi(ref IDataController _dtCtrl)
        {
            #region add test company
            Company com = new Company();
            com.Name = DateTime.Now.Ticks.ToString();
            com.ID = _dtCtrl.AddCompany(com);
            #endregion

            #region add test department
            Department dep = new Department();
            dep.CompanyID = com.ID;
            dep.Name = DateTime.Now.Ticks.ToString();
            dep.SupDepartmentID = 0; //root
            dep.ID = _dtCtrl.AddDepartment(dep);
            #endregion

            #region add test working calendar
            WorkingCalendar wCal = new WorkingCalendar();

            wCal.Name = DateTime.Now.Ticks.ToString();

            wCal.WorkOnMonday = true;
            wCal.WorkOnTuesday = true;
            wCal.WorkOnWednesday = true;
            wCal.WorkOnThursday = true;
            wCal.WorkOnFriday = true;

            wCal.GraceForwardToEntry = 30;
            wCal.GraceBackwardToExit = 30;
            wCal.EarliestBeforeEntry = 60;
            wCal.LastestAfterExit = 180;

            List<Shift> shiftList = new List<Shift>();
            Shift shift1 = new Shift();
            shift1.From = new DateTime(2000, 2, 2, 9, 0, 0);
            shift1.To = new DateTime(2000, 2, 2, 18, 0, 0);
            shiftList.Add(shift1);

            List<Break> breakList = new List<Break>();
            Break break1 = new Break();
            break1.From = new DateTime(2000, 2, 2, 12, 0, 0);
            break1.To = new DateTime(2000, 2, 2, 13, 0, 0);
            break1.Name = "break1";
            break1.Paid = true;

            breakList.Add(break1);

            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            workingDayPaymentRate.NumberOfRegularHours = 7;
            workingDayPaymentRate.RegularRate = 100;
            workingDayPaymentRate.NumberOfOvertime1 = 8;
            workingDayPaymentRate.OvertimeRate1 = 200;

            PaymentRate nonWorkingDayPaymentRate = workingDayPaymentRate;
            PaymentRate holidayPaymentRate = workingDayPaymentRate;

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = new DateTime(2010, 1, 1);

            wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, shiftList, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);
            #endregion

            #region add test employee
            Employee emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString();
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 0;
            emp.FirstName = DateTime.Now.Ticks.ToString();
            emp.JobDescription = DateTime.Now.Ticks.ToString();
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp.WorkingCalendarID = wCal.ID;
            emp.PayrollNumber = _dtCtrl.AddEmployee(emp, new List<Terminal>());
            #endregion

            #region add test att records 1
            //att1 : expected totalHours: 9
            AttendanceRecord att11 = new AttendanceRecord();
            att11.EmployeeNumber = emp.EmployeeNumber;
            att11.Time = new DateTime(2010, 1, 1, 9, 0, 0);
            att11.ID = _dtCtrl.AddAttendanceRecord(att11);

            AttendanceRecord att12 = new AttendanceRecord();
            att12.EmployeeNumber = emp.EmployeeNumber;
            att12.Time = new DateTime(2010, 1, 1, 18, 0, 0);
            att12.ID = _dtCtrl.AddAttendanceRecord(att12);

            AttendanceRecord att13 = new AttendanceRecord();
            att13.EmployeeNumber = emp.EmployeeNumber;
            att13.Time = new DateTime(2010, 1, 1, 12, 0, 0);
            att13.ID = _dtCtrl.AddAttendanceRecord(att13);

            AttendanceRecord att14 = new AttendanceRecord();
            att14.EmployeeNumber = emp.EmployeeNumber;
            att14.Time = new DateTime(2010, 1, 1, 13, 0, 0);
            att14.ID = _dtCtrl.AddAttendanceRecord(att14);

            //att2 : expected totalHours: 9
            AttendanceRecord att21 = new AttendanceRecord();
            att21.EmployeeNumber = emp.EmployeeNumber;
            att21.Time = new DateTime(2010, 1, 2, 8, 45, 0);
            att21.ID = _dtCtrl.AddAttendanceRecord(att21);

            AttendanceRecord att22 = new AttendanceRecord();
            att22.EmployeeNumber = emp.EmployeeNumber;
            att22.Time = new DateTime(2010, 1, 2, 18, 15, 0);
            att22.ID = _dtCtrl.AddAttendanceRecord(att22);

            //att3 : expected totalHours: 9.75
            AttendanceRecord att31 = new AttendanceRecord();
            att31.EmployeeNumber = emp.EmployeeNumber;
            att31.Time = new DateTime(2010, 1, 3, 8, 15, 0);
            att31.ID = _dtCtrl.AddAttendanceRecord(att31);

            AttendanceRecord att32 = new AttendanceRecord();
            att32.EmployeeNumber = emp.EmployeeNumber;
            att32.Time = new DateTime(2010, 1, 3, 18, 0, 0);
            att32.ID = _dtCtrl.AddAttendanceRecord(att32);

            //att4 : expected totalHours: 0 + out mistake alert
            AttendanceRecord att41 = new AttendanceRecord();
            att41.EmployeeNumber = emp.EmployeeNumber;
            att41.Time = new DateTime(2010, 1, 4, 7, 00, 0);
            att41.ID = _dtCtrl.AddAttendanceRecord(att41);

            AttendanceRecord att42 = new AttendanceRecord();
            att42.EmployeeNumber = emp.EmployeeNumber;
            att42.Time = new DateTime(2010, 1, 4, 18, 0, 0);
            att42.ID = _dtCtrl.AddAttendanceRecord(att42);

            //att5 : expected totalHours: 8.8x
            AttendanceRecord att51 = new AttendanceRecord();
            att51.EmployeeNumber = emp.EmployeeNumber;
            att51.Time = new DateTime(2010, 1, 5, 9, 06, 0);
            att51.ID = _dtCtrl.AddAttendanceRecord(att51);

            AttendanceRecord att52 = new AttendanceRecord();
            att52.EmployeeNumber = emp.EmployeeNumber;
            att52.Time = new DateTime(2010, 1, 5, 18, 2, 0);
            att52.ID = _dtCtrl.AddAttendanceRecord(att52);

            //att6 : expected totalHours: 8.5
            AttendanceRecord att61 = new AttendanceRecord();
            att61.EmployeeNumber = emp.EmployeeNumber;
            att61.Time = new DateTime(2010, 1, 6, 9, 0, 0);
            att61.ID = _dtCtrl.AddAttendanceRecord(att61);

            AttendanceRecord att62 = new AttendanceRecord();
            att62.EmployeeNumber = emp.EmployeeNumber;
            att62.Time = new DateTime(2010, 1, 6, 18, 0, 0);
            att62.ID = _dtCtrl.AddAttendanceRecord(att62);

            AttendanceRecord att63 = new AttendanceRecord();
            att63.EmployeeNumber = emp.EmployeeNumber;
            att63.Time = new DateTime(2010, 1, 6, 12, 30, 0);
            att63.ID = _dtCtrl.AddAttendanceRecord(att63);

            AttendanceRecord att64 = new AttendanceRecord();
            att64.EmployeeNumber = emp.EmployeeNumber;
            att64.Time = new DateTime(2010, 1, 6, 13, 30, 0);
            att64.ID = _dtCtrl.AddAttendanceRecord(att64);
            #endregion
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            _thrClearDB = new Thread(new ThreadStart(ClearDB));
            _thrClearDB.Start();
        }

        private void ClearDB()
        {
            _dtCtrl.BeginTransaction();
            try
            {
                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "Clearing..." });

                //clear undel employee
                foreach (UndeletedEmployeeNumber undelEmp in _dtCtrl.GetUndeletedEmployeeNumberList())
                    _dtCtrl.DeleteUndeletedEmployeeNumber(undelEmp);

                //clear uncal att records
                _dtCtrl.DeleteAllUncalculatedAttendanceRecord();

                //clear att reports
                _dtCtrl.DeleteAllAttendanceReport();

                //clear att records
                _dtCtrl.DeleteAllAttendanceRecord();

                //clear employee
                foreach (Employee emp in _dtCtrl.GetEmployeeList())
                {
                    //clear employee terminal
                    _dtCtrl.DeleteEmployeeTerminalByEmployee(emp.EmployeeNumber);

                    _dtCtrl.DeleteEmployee(emp.PayrollNumber);
                }

                //clear employee number

                //clear department
                foreach (Department dep in _dtCtrl.GetDepartmentList())
                {
                    if (dep.ID != 1)
                        _dtCtrl.DeleteDepartment(dep.ID);
                }

                //clear company
                foreach (Company com in _dtCtrl.GetCompanyList())
                {
                    if (com.ID != 1)
                        _dtCtrl.DeleteCompany(com.ID);
                }

                //clear working calendar
                foreach (WorkingCalendar wCal in _dtCtrl.GetWorkingCalendarList())
                {
                    List<Shift> shiftList = _dtCtrl.GetShiftListByWorkingCalendar(wCal.ID);

                    foreach (Shift shift in shiftList)
                        _dtCtrl.DeleteShift(shift.ID);

                    _dtCtrl.DeleteWorkingCalendar(wCal.ID);
                }

                //clear pay period

                _dtCtrl.CommitTransaction();

                Invoke(new SetTextCallBack(SetText), new object[] { txtProgress, "Clearing Complete." });
            }
            catch (Exception ex)
            {
                _dtCtrl.RollbackTransaction();
                Invoke(new AddTextCallBack(SetText), new object[] { txtProgress, "Error: " + ex.Message });
            }
        }
    }
}