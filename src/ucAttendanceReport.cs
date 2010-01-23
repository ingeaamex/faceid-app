using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class ucAttendanceReport : UserControl
    {
        private IDataController dtCtrl;

        public ucAttendanceReport()
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

        private void btnPayrollExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report must be created before exporting to payroll. Please click View to create a Report.");
        }

        private void btnCollectData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet.");
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            DateTime beginDate = dtpAttendanceFrom.Value;
            DateTime endDate = dtpAttedanceTo.Value.Date.AddHours(23).AddMinutes(59);

            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            List<AttendanceLogReport> attendanceLogs = dtCtrl.GetAttendanceReportList(iCompany, iDepartment, beginDate, endDate);

            dgvAttendanceReport.AutoGenerateColumns = false;
            dgvAttendanceReport.DataSource = attendanceLogs;
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

        private void dgvAttendanceReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                List<AttendanceLogReport> attendanceLogs = (List<AttendanceLogReport>)dgvAttendanceReport.DataSource;
                if (attendanceLogs == null)
                    return;
                AttendanceLogReport attendanceLog = attendanceLogs[e.RowIndex];

                if (e.ColumnIndex == 1)
                {
                    int rHieght = attendanceLog.Note.Count * 20;
                    if (rHieght > 20)
                        dgvAttendanceReport.Rows[e.RowIndex].Height = rHieght;
                }

                if (e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    using (Brush gridBrush = new SolidBrush(this.dgvAttendanceReport.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
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
                                    List<TimeSpan> sInOut = attendanceLog.AttendanceDetail;
                                    bool isIn = true;
                                    foreach (TimeSpan time in sInOut)
                                    {
                                        int y = (e.CellBounds.Y) + count * 20;
                                        string timesp = (isIn ? "In " : "Out ") + time.Hours + ":" + time.Minutes;
                                        isIn = !isIn;
                                        e.Graphics.DrawString(timesp, e.CellStyle.Font,
                                            Brushes.Black, e.CellBounds.X + 5,
                                            y + 5, StringFormat.GenericDefault);

                                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                        count++;
                                    }
                                    break;
                                case 6:
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
        }

        private void dgvAttendanceReport_CellPainting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvAttendanceReport.Columns["EmployeeName"].Index)
            {
                List<AttendanceLogReport> attendanceLogs = (List<AttendanceLogReport>)dgvAttendanceReport.DataSource;
                if (attendanceLogs == null)
                    return;
                AttendanceLogReport attendanceLog = attendanceLogs[e.RowIndex];

                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", attendanceLog.FirstName, attendanceLog.LastName);
            }
        }
    }
}
