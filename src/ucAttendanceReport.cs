using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;
using System.IO;

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
            DateTime beginDate = dtpAttendanceFrom.Value;
            DateTime endDate = dtpAttedanceTo.Value.Date.AddHours(23).AddMinutes(59);

            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            frmPayrollExport formExport = new frmPayrollExport(iCompany, iDepartment, beginDate, endDate);
            formExport.ShowDialog(this);
        }

        private void btnCollectData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function has not been implemented yet.");
        }

        private void btnExportToMYOB_Click(object sender, EventArgs e)
        {
            ExportToMYOB();
        }

        private void ExportToMYOB()
        {
            try
            {
                List<AttendanceLogReport> attendanceLogReportList = (List<AttendanceLogReport>)dgvAttendanceReport.DataSource;
                SaveFileDialog sfdMyobFile = new SaveFileDialog();
                sfdMyobFile.Filter = "Text files (*.txt)|*.txt";
                sfdMyobFile.FileName = DateTime.Now.Ticks.ToString();

                if (sfdMyobFile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sWriter = new StreamWriter(sfdMyobFile.FileName, false);

                    sWriter.WriteLine("Emp. Co./Last Name,Emp. First Name,Payroll Category,Job,Cust. Co./Last Name,Cust. First Name,Notes,Date,Units");
                    foreach (AttendanceLogReport attendanceLogReport in attendanceLogReportList)
                    {

                        sWriter.WriteLine(string.Format("{0},Base Hourly,,,,,{1},{2}", attendanceLogReport.FullName, attendanceLogReport.WorkTo.ToString("MM/dd/yyyy"), attendanceLogReport.TotalHour));
                    }

                    sWriter.Close();

                    MessageBox.Show("Export successfully");
                }

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex.Message);
            }
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

            List<AttendanceLogReport> attendanceLogs = dtCtrl.GetAttendanceLogReportList(iCompany, iDepartment, beginDate, endDate);

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

                if (e.ColumnIndex == 3 || e.ColumnIndex == 5)
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
                                    List<string> lTime = new List<string>();
                                    lTime.Add("Regular Hour : " + attendanceLog.RegularHour.ToString());
                                    if (attendanceLog.OvertimeHour1 > 0)
                                        lTime.Add("Overtime Hour 1 : " + attendanceLog.OvertimeHour1.ToString());
                                    if (attendanceLog.OvertimeHour2 > 0)
                                        lTime.Add("Overtime Hour 2 : " + attendanceLog.OvertimeHour2.ToString());
                                    if (attendanceLog.OvertimeHour3 > 0)
                                        lTime.Add("Overtime Hour 3 : " + attendanceLog.OvertimeHour3.ToString());
                                    if (attendanceLog.OvertimeHour4 > 0)
                                        lTime.Add("Overtime Hour 4 : " + attendanceLog.OvertimeHour4.ToString());
                                    count = 0;
                                    foreach (string time in lTime)
                                    {
                                        int y = (e.CellBounds.Y) + count * 20;
                                        e.Graphics.DrawString(time, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 5, y + 5, StringFormat.GenericDefault);
                                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, y + 20, e.CellBounds.Right, y + 20);
                                        count++;
                                    }

                                    if (lTime.Count > 0)
                                        dgvAttendanceReport.Rows[e.RowIndex].Height = lTime.Count * 20;

                                    break;
                                case 5:
                                    break;
                            }
                            e.Handled = true;
                        }
                    }
                }
            }
        }

    }
}

