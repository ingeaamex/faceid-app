﻿using System;
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

                            sWriter.WriteLine(string.Format("{0},Base Hourly,,,,,{1},{2}", attendanceSummaryReport.FullName, attendanceSummaryReport.DateLog.ToString("MM/dd/yyyy"), attendanceSummaryReport.TotalHour));
                        }

                        sWriter.Close();

                        MessageBox.Show("Export successfully");
                    }
                }

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again.");
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            //dtCtrl.CalculateAttendanceRecord();

            btnExportToMYOB.Enabled = true;

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
                        else if (e.ColumnIndex == 5)
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

