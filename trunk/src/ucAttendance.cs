using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class ucAttendance : UserControl
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private ITerminalController _terCtrl = new TerminalController();

        public ucAttendance()
        {
            InitializeComponent();
        }

        private void ucAttendanceLog1_Load(object sender, EventArgs e)
        {
        }

        private void btnCollectAttendanceData_Click(object sender, EventArgs e)
        {
            CollectAttendanceData();
        }

        private void CollectAttendanceData()
        {
            try
            {
                List<Terminal> terminalList = _dtCtrl.GetTerminalList();

                foreach (Terminal terminal in terminalList)
                {
                    if (_terCtrl.IsTerminalConnected(terminal))
                    {
                        DateTime thisMoment = DateTime.Now;
                        DateTime lastMoment = thisMoment;

                        while (true)
                        {
                            if (lastMoment.Equals(thisMoment))
                                lastMoment = thisMoment.AddYears(-10);
                            else
                                lastMoment = thisMoment;

                            thisMoment = DateTime.Now;
                            List<AttendanceRecord> attRecordList = _terCtrl.GetAttendanceRecord(terminal, lastMoment, thisMoment);

                            if (attRecordList.Count > 0)
                            {
                                foreach (AttendanceRecord attRecord in attRecordList)
                                {
                                    attRecord.CheckIn = true;
                                    attRecord.Note = "";
                                    attRecord.PhotoData = "";

                                    if (_dtCtrl.AddAttendanceRecord(attRecord) <= 0)
                                    {
                                        throw new Exception("Cannot save attendance records to database");
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        //TODO add this later
                        //_terCtrl.DeleteAttendanceRecord(terminal);
                    }
                    else
                    {
                        throw new Exception("Cannot connect to terminal " + terminal.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
                return;
            }

            MessageBox.Show("Attendance records from terminals have been copied successfully");
        }
    }
}