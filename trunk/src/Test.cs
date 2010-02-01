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
        private Button btnClearAll;
        private Label label3;
        private NumericUpDown nudAdd;
        private Button btnStop;
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
            this.btnClearAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAdd = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
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
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(284, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(130, 23);
            this.btnClearAll.TabIndex = 9;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
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
            // Test
            // 
            this.ClientSize = new System.Drawing.Size(632, 265);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.nudAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnDelRecord);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddRecord);
            this.Name = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Test()
        {
            InitializeComponent();
        }

        private Random _rand = new Random();
        
        private long _startPoint = 0;

        private List<AttendanceRecord> _attRecordList = new List<AttendanceRecord>();
        private List<Employee> _empList = new List<Employee>();
        
        private IDataController _dtCtrl = LocalDataController.Instance;

        private Thread _thrAdd;
        private Thread _thrDel;
        private Thread _thrClear;

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            _thrAdd = new Thread(new ThreadStart(AddRecord));
            _thrAdd.Start();
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
                

                Invoke(new SetTextCallBack(AddText), new object[] { txtProgress, "Calculating" });

                _dtCtrl.CalculateAttendanceRecord();
                _dtCtrl.RefreshConnection();

                Invoke(new SetTextCallBack(AddText), new object[] { txtProgress, "DONE" });
                Invoke(new SetTextCallBack(SetText), new object[] { txtDuration, GetDuration() });

                MessageBox.Show(added + " records have been added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetState(0);
        }

        private int GetRandomEmployeeNumber()
        {
            if (_empList.Count == 0)
                _empList = _dtCtrl.GetEmployeeList();

            return _empList[_rand.Next(_empList.Count)].EmployeeNumber;
        }

        private DateTime GetRandomTime()
        {
            DateTime minDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0);

            if (DateTime.Today.Day == 1)
                minDate = minDate.AddDays(-30);

            int maxSeconds = (DateTime.Today.DayOfYear - minDate.DayOfYear) * 24 * 60 * 60;
            if (maxSeconds == 0) maxSeconds = 30 * 24 * 60 * 60;

            return minDate.AddSeconds(_rand.Next(maxSeconds));
        }

        private void btnDelRecord_Click(object sender, EventArgs e)
        {
            _thrDel = new Thread(new ThreadStart(DelRecord));
            _thrDel.Start();
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
            _thrClear = new Thread(new ThreadStart(ClearAll));
            _thrClear.Start();
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
                if (_dtCtrl.DeleteAllUncalculatedAttendanceRecord())
                    cleared++;

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
                _thrAdd.Abort();
            }
            catch { }
            try
            {
                _thrDel.Abort();
            }
            catch { }
            try
            {
                _thrClear.Abort();
            }
            catch { }

            SetState(0);
        }

        private void SetState(int state)
        {
            Invoke(new EnableButtonCallBack(EnableButton), new object[]{ btnStop, (state > 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnAddRecord, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnDelRecord, (state == 0) });
            Invoke(new EnableButtonCallBack(EnableButton), new object[] { btnClearAll, (state == 0) });
        }

        private void EnableButton(Button btn, bool enable)
        {
            btn.Enabled = enable;
        }

        //public delegate int Functotaldonetp(int total, int nDone);
        //int FunctotaldonetpMethod(int total, int nDone)
        //{
        //    return 1;
        //}
        //[DllImport("HwDevComm.dll")]
        //public static extern int HwDev_Execute(string pDevInfoBuf, int nDevInfoLen, string pSendBuf, int nSendLen, ref string pRecvBuf, ref int pRecvLen, Functotaldonetp pFuncTotalDone);
        ////int total = int.MinValue;
        ////int nDone = int.MinValue;

        //public Test()
        //{
        //    //Functotaldonetp functotaldonetp = new Functotaldonetp(FunctotaldonetpMethod);

        //    //string pDevInfoBuf = "DeviceInfo( dev_id = \"1\" comm_type = \"ip\" ip_adress = \"10.0.0.101\" )";
        //    //int nDevInfoLen = pDevInfoBuf.Length;
        //    //string pSendBuf = "InitDevice()";
        //    //int nSendLen = pSendBuf.Length;
        //    //string pRecvBuf = null;
        //    //int pRecvLen = 0;

        //    //int result = HwDev_Execute(pDevInfoBuf, nDevInfoLen, pSendBuf, nSendLen, ref  pRecvBuf, ref pRecvLen, functotaldonetp);

        //    string ip_addr = "10.0.0.101";

        //    string devInfo = "DeviceInfo( dev_id = \"1\" dev_type = \"HW_HDCP\" comm_type = \"ip\" ip_address = ";
        //    devInfo = devInfo + '"' + ip_addr + '"' + ")";

        //    //string cmdStr = "GetRecord(start_time=";
        //    //cmdStr = cmdStr + startData + " ";
        //    //cmdStr = cmdStr + startTime;
        //    //cmdStr = cmdStr + "end_Time=";
        //    //cmdStr = cmdStr + endData + " ";
        //    //cmdStr = cmdStr + endTime + ")";
        //    string cmdStr = "GetDeviceInfo()";

        //    string ret = null;
        //    int retlen = 0;

        //    int i = HwDev_Execute(devInfo, devInfo.Length, cmdStr, cmdStr.Length, ref ret, ref retlen, null);
        //    MessageBox.Show(ret);
        //}
    }
}
