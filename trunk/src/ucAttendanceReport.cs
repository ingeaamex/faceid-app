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
        private List<AttendanceSummaryReport> attendanceLogs;

        public ucAttendanceReport()
        {
            InitializeComponent();
            dtCtrl = LocalDataController.Instance;
            BindData();
        }

        private void BindData()
        {
            if (!cbxShowChart.Checked)
            {
                TotalHours.Width = 188 + 98;
                Chart.Visible = false;
            }
            BindCompany();
            dtpAttendanceFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        private void btnPayrollExport_Click(object sender, EventArgs e)
        {
            DateTime dPayrollFrom = dtpAttendanceFrom.Value.Date;
            DateTime dPayrollTo = dtpAttedanceTo.Value.Date;

            if (dPayrollFrom.CompareTo(dPayrollTo) == 1)
            {
                MessageBox.Show(this, "beginDate>endDate");
                return;
            }

            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            string errorNumber = "";
            int wcalID = 0;
            List<PayrollExport> payrollExports = dtCtrl.GetPayrollExportList(iCompany, iDepartment, dPayrollFrom, dPayrollTo, wcalID, ref errorNumber);
            //List<WorkingCalendar> workingCalendars = new List<WorkingCalendar>();
            //bool payrollExports = dtCtrl.ExistPayrollExportList(iCompany, iDepartment, dPayrollFrom, dPayrollTo, ref errorNumber, ref workingCalendars);
            //if (payrollExports == false)
            //{
            //    string msgAlert = "";
            //    switch (errorNumber)
            //    {
            //        case "AM01":
            //            if (workingCalendars.Count > 1)
            //            {
            //                frmChooseWorkingCalendar _frmChooseWorkingCalendar = new frmChooseWorkingCalendar(workingCalendars, dPayrollFrom, dPayrollTo, iCompany, iDepartment);
            //                DialogResult diag = _frmChooseWorkingCalendar.ShowDialog(this);
            //            }
            //            return;
            //        case "AM00":
            //        default:
            //            msgAlert = "Not match";
            //            MessageBox.Show(this, msgAlert);
            //            return;
            //    }
            //}

            if (payrollExports.Count > 0)
            {
                frmPayrollExport formExport = new frmPayrollExport(iCompany, iDepartment, dPayrollFrom, dPayrollTo, 0);
                formExport.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(this, "Not match");
            }
        }

        private void btnExportToMYOB_Click(object sender, EventArgs e)
        {
            ExportToMYOB();
        }

        private void ExportToMYOB()
        {
            try
            {
                if (dgvAttendanceReport.DataSource == null)
                {
                    MessageBox.Show("There's no data to export"); 
                    return;
                }
                else
                {

                    List<AttendanceSummaryReport> attendanceSummaryReportList = (List<AttendanceSummaryReport>)dgvAttendanceReport.DataSource;

                    if (attendanceSummaryReportList.Count == 0)
                    {
                        MessageBox.Show("There's no data to export");
                        return;
                    }

                    SaveFileDialog sfdMyobFile = new SaveFileDialog();
                    sfdMyobFile.Filter = "Text files (*.txt)|*.txt";
                    sfdMyobFile.FileName = DateTime.Now.Ticks.ToString();

                    if (sfdMyobFile.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sWriter = new StreamWriter(sfdMyobFile.FileName, false);

                        sWriter.WriteLine("Emp. Co./Last Name,Emp. First Name,Payroll Category,Job,Cust. Co./Last Name,Cust. First Name,Notes,Date,Units");
                        foreach (AttendanceSummaryReport attendanceSummaryReport in attendanceSummaryReportList)
                        {
                            if (attendanceSummaryReport.TotalHour < 0) continue;
                            sWriter.WriteLine(string.Format("{0},Base Hourly,,,,,{1},{2}", attendanceSummaryReport.FullName, attendanceSummaryReport.DateLog.ToString("MM/dd/yyyy"), attendanceSummaryReport.TotalHour));
                        }

                        sWriter.Close();

                        MessageBox.Show("Data exported.");
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            btnExportToMYOB.Enabled = true;
            if (!cbxShowChart.Checked)
            {
                TotalHours.Width = 188 + 98;
            }
            else
            {
                TotalHours.Width = 98;
            }
            Chart.Visible = cbxShowChart.Checked;
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

            attendanceLogs = dtCtrl.GetAttendanceSummaryReport(iCompany, iDepartment, beginDate, endDate);

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
            if (e.RowIndex >= 0 && (e.ColumnIndex != 3 && e.ColumnIndex != -1))
            {
                using (Brush gridBrush = new SolidBrush(dgvAttendanceReport.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor),
                    grayColorBrush = new SolidBrush(Color.LightGray),
                    redColorBrush = new SolidBrush(Color.Red),
                    greenColorBrush = new SolidBrush(Color.LimeGreen),
                    blackColorBrush = new SolidBrush(Color.Black))
                {
                    using (Pen gridLinePen = new Pen(gridBrush), backColorPen = new Pen(backColorBrush))
                    {
                        Rectangle recCell = e.CellBounds;
                        recCell.Height -= 1;
                        e.Graphics.FillRectangle(backColorBrush, recCell);

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        e.Graphics.DrawLine(backColorPen, e.CellBounds.Left,
                            e.CellBounds.Top - 1, e.CellBounds.Right - 2,
                            e.CellBounds.Top - 1);

                        if (e.ColumnIndex == 0)
                        {
                            if ((int)e.Value != 0)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                    e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                    e.CellBounds.Top - 1);

                                Rectangle rec = dgvAttendanceReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                    blackColorBrush, rec.Left + 5,
                                    rec.Top + 5, StringFormat.GenericDefault);
                            }
                        }
                        else if (e.ColumnIndex == 1)
                        {
                            if (e.Value != null)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                    e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                    e.CellBounds.Top - 1);

                                Rectangle rec = dgvAttendanceReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                    blackColorBrush, rec.Left + 5,
                                    rec.Top + 5, StringFormat.GenericDefault);
                            }
                        }
                        else if (e.ColumnIndex == 2)
                        {
                            if (Convert.ToDateTime(e.Value).Equals(DateTime.MinValue) == false)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                    e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                    e.CellBounds.Top - 1);

                                Rectangle rec = dgvAttendanceReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                e.Graphics.DrawString(Convert.ToDateTime(e.Value).ToString("d MMM yyyy"), e.CellStyle.Font,
                                    blackColorBrush, rec.Left + 5,
                                    rec.Top + 5, StringFormat.GenericDefault);
                            }
                        }
                        else if (e.ColumnIndex == 4)
                        {
                            if ((double)e.Value != -1)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                    e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                    e.CellBounds.Top - 1);

                                Rectangle rec = dgvAttendanceReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                    blackColorBrush, rec.Left + 5,
                                    rec.Top + 5, StringFormat.GenericDefault);
                            }
                        }
                        else if (cbxShowChart.Checked && e.ColumnIndex == 5)
                        {
                            if (e.Value != null)
                            {
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                    e.CellBounds.Top - 1, e.CellBounds.Right - 1,
                                    e.CellBounds.Top - 1);

                                Rectangle rec = dgvAttendanceReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                float fx =rec.Left + 5;
                                float fy = rec.Top + 2;

                                float regWidth = 60;

                                double[] chartData = (double[])e.Value;

                                double regHour = chartData[0];
                                double workHour = chartData[1];
                                double overHour = chartData[2];

                                float fWidth = Convert.ToSingle(regWidth * workHour / regHour);
                                float fOverWidth = Convert.ToSingle(regWidth * overHour / regHour);

                                e.Graphics.FillRectangle(grayColorBrush, fx, fy, regWidth, 16);
                                e.Graphics.FillRectangle(greenColorBrush, fx, fy, fWidth, 16);
                                e.Graphics.DrawString(workHour.ToString() + " hrs", e.CellStyle.Font, blackColorBrush, fx + 5, fy + 2, StringFormat.GenericDefault);
                                if (fOverWidth > 0)
                                {
                                    e.Graphics.FillRectangle(redColorBrush, fx + fWidth, fy, fOverWidth, 16);
                                    e.Graphics.DrawString(overHour.ToString() + " hrs", e.CellStyle.Font, blackColorBrush, fx + fWidth + 5, fy + 2, StringFormat.GenericDefault);
                                }
                            }
                        }
                    }
                }
                e.Handled = true;
            }
        }

        private void dgvAttendanceReport_Scroll(object sender, ScrollEventArgs e)
        {
            dgvAttendanceReport.InvalidateColumn(0);
            dgvAttendanceReport.InvalidateColumn(1);
            dgvAttendanceReport.InvalidateColumn(2);
            dgvAttendanceReport.InvalidateColumn(4);
            dgvAttendanceReport.InvalidateColumn(5);
        }
    }
}

