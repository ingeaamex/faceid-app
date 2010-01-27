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
    public partial class ucAttendanceLog : UserControl
    {
        private IDataController _dtCtrl;
        private Point _cellContext;
        private List<Point> _pData = null;
        public ucAttendanceLog()
        {
            InitializeComponent();
            _dtCtrl = LocalDataController.Instance;
            BindData();
        }

        private void BindData()
        {
            BindCompany();
            dtpAttendanceFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        private void LoadAttdanceLog()
        {
            DateTime beginDate = dtpAttendanceFrom.Value;
            DateTime endDate = dtpAttedanceTo.Value.Date.AddHours(23).AddMinutes(59);

            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            _pData = new List<Point>();

            List<AttendanceLogRecord> attendanceLogs = _dtCtrl.GetAttendanceRecordList(iCompany, iDepartment, beginDate, endDate);

            dgvAttendanceLog.AutoGenerateColumns = false;
            dgvAttendanceLog.DataSource = attendanceLogs;
        }

        private void btnAddNewAttendaceRecord_Click(object sender, EventArgs e)
        {
            frmAddUpdateAttendanceRecord frmAtt = new frmAddUpdateAttendanceRecord(0);
            frmAtt.ShowDialog(this);
        }

        private void BindCompany()
        {
            List<Company> companyList = _dtCtrl.GetCompanyList();
            Company company = new Company();
            company.ID = -1;
            company.Name = "All companies";
            companyList.Insert(0, company);
            cbxCompany.DataSource = companyList;
        }

        private void BindDepartment()
        {
            if (cbxCompany.SelectedValue != null)
            {
                int CompanyID = (int)cbxCompany.SelectedValue;
                if (CompanyID == -1)
                {
                    cbxDepartment.Enabled = false;
                    return;
                }
                cbxDepartment.Enabled = true;
                List<Department> departmentList = _dtCtrl.GetDepartmentByCompany(CompanyID);
                Department department = new Department();
                department.ID = -1;
                department.Name = "All departments";
                departmentList.Insert(0, department);
                cbxDepartment.DataSource = departmentList;
            }
        }

        private void cbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadAttdanceLog();
        }

        private int GetEditRecordID()
        {
            int min = 7 - dgvAttendanceLog.ColumnHeadersHeight;
            int max = dgvAttendanceLog.ColumnHeadersHeight - 16;
            int idx = _cellContext.Y;
            for (int i = 0; i < _pData.Count; i++)
            {
                if (_pData[i].Y - idx >= min && _pData[i].Y - idx <= max)
                {
                    return _pData[i].X;
                }
            }
            return -1;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RcID = GetEditRecordID();
            if (RcID == -1)
                return;

            frmAddUpdateAttendanceRecord attForm = new frmAddUpdateAttendanceRecord(RcID);
            attForm.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RcID = GetEditRecordID();
            if (RcID == -1)
                return;
            DialogResult dlogRs = MessageBox.Show(Form.ActiveForm, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dlogRs.ToString().Equals("Yes"))
            {
                bool ors = _dtCtrl.DeleteAttendanceRecord(RcID);
                MessageBox.Show(ors ? "sucessfull" : "error");
                if (ors)
                    LoadAttdanceLog();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                List<AttendanceLogRecord> attendanceLogs = (List<AttendanceLogRecord>)dgvAttendanceLog.DataSource;
                if (attendanceLogs == null)
                    return;
                AttendanceLogRecord attendanceLog = attendanceLogs[e.RowIndex];

                if (e.ColumnIndex == 1)
                {
                    int rHieght = attendanceLog.Note.Count * 20;
                    if (rHieght > 0)
                        dgvAttendanceLog.Rows[e.RowIndex].Height = rHieght;
                }
                if (e.ColumnIndex < 2)
                    return;

                using (Brush gridBrush = new SolidBrush(this.dgvAttendanceLog.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        int count = 0;
                        switch (e.ColumnIndex)
                        {
                            case 3:
                                List<object[]> sInOut = attendanceLog.InOutTime;
                                bool isIn = true;
                                foreach (object[] time in sInOut)
                                {
                                    int y = (e.CellBounds.Y) + count * 20;
                                    string timesp = (isIn ? "In " : "Out ") + time[1];
                                    isIn = !isIn;
                                    e.Graphics.DrawString(timesp, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 5,
                                        y + 5, StringFormat.GenericDefault);

                                    if (!_pData.Contains(new Point((int)time[0], y + 5)))
                                        _pData.Add(new Point((int)time[0], y + 5));

                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                    count++;
                                }
                                break;
                            case 2:
                                List<DateTime> dTime = attendanceLog.DateLog;
                                List<object[]> lTotalHour = attendanceLog.TotalHour;
                                int cellHeight2 = 0;
                                for (int i = 0; i < dTime.Count; i++)
                                {
                                    int numRs = (int)((object[])lTotalHour[i])[1];
                                    cellHeight2 += 20 * numRs;
                                    string timesp = dTime[i].ToString("d MMM yyyy");
                                    e.Graphics.DrawString(timesp, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 5,
                                        e.CellBounds.Y - 7 + cellHeight2 - (10 * numRs), StringFormat.GenericDefault);
                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Y + cellHeight2, e.CellBounds.Right, e.CellBounds.Y + cellHeight2);
                                }
                                break;
                            case 4:
                                List<object[]> lTotalHours = attendanceLog.TotalHour;
                                int cellHeight1 = 0;
                                for (int i = 0; i < lTotalHours.Count; i++)
                                {
                                    int numRs = (int)((object[])lTotalHours[i])[1];
                                    cellHeight1 += 20 * numRs;
                                    string timesp = lTotalHours[i][0].ToString();
                                    e.Graphics.DrawString(timesp, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 5,
                                        e.CellBounds.Y - 7 + cellHeight1 - (10 * numRs), StringFormat.GenericDefault);
                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Y + cellHeight1, e.CellBounds.Right, e.CellBounds.Y + cellHeight1);
                                }
                                break;
                            case 5:
                                count = 0;
                                List<string> sNote = attendanceLog.Note;
                                foreach (string note in sNote)
                                {
                                    int y = (e.CellBounds.Y) + count * 20;
                                    e.Graphics.DrawString(note, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 5,
                                        y + 5, StringFormat.GenericDefault);

                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                    count++;
                                }
                                break;
                        }
                        e.Handled = true;
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvAttendanceLog.Columns["EmployeeName1"].Index)
            {
                List<AttendanceLogRecord> attendanceLogs = (List<AttendanceLogRecord>)dgvAttendanceLog.DataSource;
                if (attendanceLogs == null)
                    return;
                AttendanceLogRecord attendanceLog = attendanceLogs[e.RowIndex];

                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", attendanceLog.LastName, attendanceLog.FirstName);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _cellContext = new Point(e.X, e.Y + dgvAttendanceLog.VerticalScrollingOffset);
            }
        }
    }
}
