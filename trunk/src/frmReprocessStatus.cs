using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class frmReprocessStatus : Form
    {
        Thread _thrUpdateReport;

        private string employeeNumberList;
        private DateTime dReprocessFrom;
        private DateTime dReprocessTo;
        private IDataController _dtCtrl = LocalDataController.Instance;
        List<AttendanceRecord> attendanceRecordList = null;
        public frmReprocessStatus(string _employeeNumberList, DateTime _dReprocessFrom, DateTime _dReprocessTo)
        {
            InitializeComponent();

            employeeNumberList = _employeeNumberList;
            dReprocessFrom = _dReprocessFrom;
            dReprocessTo = _dReprocessTo;
        }

        private delegate void InitProgressCallBack(int maxValue);
        private delegate void AddProgressCallBack(int value);
        private delegate void SetTextCallBack(Label lbel, string text);
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

        private void SetText(Label lbel, string text)
        {
            lbel.Text = text;
        }

        private void SetState(int state)
        {
            Invoke(new EnableButtonCallBack(VisibleButton), new object[] { btnClose, (state == 0) });
            Invoke(new EnableButtonCallBack(VisibleButton), new object[] { btnStop, (state > 0) });
        }

        private void VisibleButton(Button btn, bool visible)
        {
            btn.Visible = visible;
        }

        private void UpdateReport()
        {
            try
            {
                SetState(1);

                int toBeUpdate = attendanceRecordList.Count;

                Invoke(new InitProgressCallBack(InitProgress), new object[] { toBeUpdate });

                int updating = 0;
                int updated = 0;

                foreach (AttendanceRecord attRc in attendanceRecordList)
                {
                    updating++;
                    if (_dtCtrl.ReProcessAttendanceReport(attRc))
                        updated++;

                    string textProgress = "Processing: " + updating + "/" + toBeUpdate + " records (Processed: " + updated + ")";

                    Invoke(new AddProgressCallBack(AddProgress), new object[] { 1 });
                    Invoke(new SetTextCallBack(SetText), new object[] { lProcessStatus, textProgress });
                }
                MessageBox.Show(updated + " attendance records have been updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetState(0);
        }

        private void frmReprocessStatus_Load(object sender, EventArgs e)
        {
            attendanceRecordList = _dtCtrl.GetReprocessAttendanceReport(employeeNumberList, dReprocessFrom, dReprocessTo);
            if (attendanceRecordList == null || attendanceRecordList.Count == 0)
            {
                MessageBox.Show(this, "no attendance report in process");
                this.Close();
            }
            else
            {
                _thrUpdateReport = new Thread(new ThreadStart(UpdateReport));
                _thrUpdateReport.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _thrUpdateReport.Abort();
            }
            catch { }

            SetState(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
