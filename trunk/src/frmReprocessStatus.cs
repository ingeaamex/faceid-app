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
        Thread _thrReprocess;

        private string _employeeNumberList;
        private DateTime _dReprocessFrom;
        private DateTime _dReprocessTo;
        private IDataController _dtCtrl;
        List<AttendanceRecord> attendanceRecordList = null;

        public frmReprocessStatus(string employeeNumberList, DateTime dReprocessFrom, DateTime dReprocessTo)
        {
            _dtCtrl = LocalDataController.Instance;

            InitializeComponent();

            _employeeNumberList = employeeNumberList;
            _dReprocessFrom = dReprocessFrom;
            _dReprocessTo = dReprocessTo;
        }

        private delegate void InitProgressCallBack(int maxValue);
        private delegate void AddProgressCallBack(int value);
        private delegate void SetTextCallBack(Label lbl, string text);
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

        private void SetText(Label lbl, string text)
        {
            lbl.Text = text;
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

        private void Reprocess()
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
                MessageBox.Show(updated + " attendance records reprocessed.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
            }

            SetState(0);
        }

        private void frmReprocessStatus_Load(object sender, EventArgs e)
        {
            attendanceRecordList = _dtCtrl.GetReprocessAttendanceReport(_employeeNumberList, _dReprocessFrom, _dReprocessTo);
            if (attendanceRecordList == null || attendanceRecordList.Count == 0)
            {
                MessageBox.Show("There's no records of selected employees within the seleted range.");
                this.Close();
            }
            else
            {
                _thrReprocess = new Thread(new ThreadStart(Reprocess));
                _thrReprocess.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _thrReprocess.Abort();
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
