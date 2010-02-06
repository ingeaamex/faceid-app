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
        private List<AttendanceLogRecord> attendanceLogRecordList;
        private int editRecordId = 0;
        private bool isOrderByAcs = true;
        private int columnIndex = 0;
        public ucAttendanceLog()
        {
            InitializeComponent();
            _dtCtrl = LocalDataController.Instance;
        }

        private void ucAttendanceLog_Load(object sender, EventArgs e)
        {
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

            int companyID = (int)cbxCompany.SelectedValue;
            int departmentID = -1;
            if (cbxDepartment.Enabled)
                departmentID = (int)cbxDepartment.SelectedValue;

            attendanceLogRecordList = _dtCtrl.GetAttendanceLogRecordList(companyID, departmentID, beginDate, endDate, columnIndex, isOrderByAcs);

            if (attendanceLogRecordList != null && attendanceLogRecordList.Count == 0)
            {
                MessageBox.Show("There's no records within the selected range.");
            }

            dgvAttendanceLog.AutoGenerateColumns = false;
            dgvAttendanceLog.DataSource = attendanceLogRecordList;
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateAttendanceRecord attForm = new frmAddUpdateAttendanceRecord(editRecordId);
            attForm.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.Confirm("Are you sure?"))
            {
                bool ors = _dtCtrl.DeleteAttendanceRecord(editRecordId);
                MessageBox.Show(ors ? "successful" : "error");
                if (ors)
                    LoadAttdanceLog();
            }
        }

        private void dgvAttendanceLog_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                editRecordId = attendanceLogRecordList[e.RowIndex].ID;
        }

        private void dgvAttendanceLog_Scroll(object sender, ScrollEventArgs e)
        {
            dgvAttendanceLog.InvalidateColumn(0);
            dgvAttendanceLog.InvalidateColumn(1);
        }

        private void dgvAttendanceLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                using (Brush gridBrush = new SolidBrush(dgvAttendanceLog.GridColor), 
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor), 
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

                                Rectangle rec = dgvAttendanceLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
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

                                Rectangle rec = dgvAttendanceLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
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

                                Rectangle rec = dgvAttendanceLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
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

                                Rectangle rec = dgvAttendanceLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                    blackColorBrush, rec.Left + 5,
                                    rec.Top + 5, StringFormat.GenericDefault);
                            }
                        }
                    }
                }
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {

        }

        private void dgvAttendanceLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                if (e.Value.ToString() == "OutMistakes")
                {
                    e.FormattingApplied = true;
                    e.CellStyle.BackColor = Color.Red;
                    e.Value = "Out:";
                }
            }
        }

        private void dgvAttendanceLog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                Point mousePosition = dgvAttendanceLog.PointToClient(Control.MousePosition);
                editRecordId = attendanceLogRecordList[e.RowIndex].ID;
                cmsAction.Show(dgvAttendanceLog, mousePosition);
            }
        }

        private void dgvAttendanceLog_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAttendanceLog.DataSource!=null && (e.ColumnIndex == 0 || e.ColumnIndex == 2))
            {
                columnIndex = e.ColumnIndex;
                isOrderByAcs = !isOrderByAcs;
                LoadAttdanceLog();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateAttendanceRecord attForm = new frmAddUpdateAttendanceRecord(0);
            attForm.ShowDialog(this);
        }
    }
}
