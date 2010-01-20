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
        private IDataController dtCtrl;
        public ucAttendanceLog()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
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
            DateTime endDate = dtpAttedanceTo.Value;

            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            List<AttendanceLog> attendanceLogs = dtCtrl.GetAttendanceRecordList_1(iCompany, iDepartment, beginDate, endDate);
            dgvAttendanceLog.AutoGenerateColumns = false;
            dgvAttendanceLog.DataSource = attendanceLogs;
        }

        private void btnAddNewAttendaceRecord_Click(object sender, EventArgs e)
        {
            frmAddUpdateAttendanceRecord frmAtt = new frmAddUpdateAttendanceRecord();
            frmAtt.ShowDialog(this);
        }

        private void BindCompany()
        {
            List<Company> companyList = dtCtrl.GetCompanyList();
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
                List<Department> departmentList = dtCtrl.GetDepartmentByCompany(CompanyID);
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

        private void dgvAttendanceLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((dgvAttendanceLog.Columns["AttDetail"].Index == e.ColumnIndex
                || dgvAttendanceLog.Columns["AttNote"].Index == e.ColumnIndex)
                && e.RowIndex >= 0)
            {
                List<AttendanceLog> attendanceLogs = (List<AttendanceLog>)dgvAttendanceLog.DataSource;
                AttendanceLog attendanceLog = attendanceLogs[e.RowIndex];

                using (
                    Brush gridBrush = new SolidBrush(this.dgvAttendanceLog.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
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
                        if (dgvAttendanceLog.Columns["AttDetail"].Index == e.ColumnIndex)
                        {
                            bool isIn = true;
                            foreach (TimeSpan time in attendanceLog.AttendanceDetail)
                            {
                                int y = (e.CellBounds.Y) + count * 20;
                                string timesp = (isIn ? "In " : "Out ") + (time.Hours < 10 ? "0" : "") + time.Hours + ":" + (time.Minutes < 10 ? "0" : "") + time.Minutes;
                                isIn = !isIn;
                                e.Graphics.DrawString(timesp, e.CellStyle.Font,
                                    Brushes.Black, e.CellBounds.X + 5,
                                    y + 5, StringFormat.GenericDefault);
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                count++;
                            }
                        }
                        else
                        {
                            foreach (string note in attendanceLog.Note)
                            {
                                int y = (e.CellBounds.Y) + count * 20;
                                e.Graphics.DrawString(note, e.CellStyle.Font,
                                    Brushes.Black, e.CellBounds.X + 5,
                                    y + 5, StringFormat.GenericDefault);
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                count++;
                            }
                        }
                        e.Handled = true;
                    }
                }
            }
        }

        private void dgvAttendanceLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvAttendanceLog.Columns["EmployeeName"].Index)
            {
                List<AttendanceLog> attendanceLogs = (List<AttendanceLog>)dgvAttendanceLog.DataSource;
                AttendanceLog attendanceLog = attendanceLogs[e.RowIndex];

                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", attendanceLog.FirstName, attendanceLog.LastName);
                dgvAttendanceLog.Rows[e.RowIndex].Height = 20 * (attendanceLog.AttendanceDetail.Count);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadAttdanceLog();
        }
    }
}
