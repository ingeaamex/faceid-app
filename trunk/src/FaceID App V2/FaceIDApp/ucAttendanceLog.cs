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
        private List<AttendanceLogRecord> _attendanceLogRecordList;
        private AttendanceLogRecord _curAttendanceLogRecord = new AttendanceLogRecord();
        private bool _isOrderByAcs = true;
        private int _columnIndex = 0; //group by employee than by date

        public ucAttendanceLog()
        {
            InitializeComponent();
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
        }

        private void ucAttendanceLog_Load(object sender, EventArgs e)
        {
            BindData();
        }
           
        private void BindData()
        {
            BindCompany();
            dtpAttendanceFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void LoadAttdanceLog()
        {
            DateTime beginDate = dtpAttendanceFrom.Value;
            DateTime endDate = dtpAttedanceTo.Value.Date.AddHours(23).AddMinutes(59);

            int companyID = (int)cbxCompany.SelectedValue;
            int departmentID = -1;
            if (cbxDepartment.Enabled)
                departmentID = (int)cbxDepartment.SelectedValue;

            _attendanceLogRecordList = _dtCtrl.GetAttendanceLogRecordList(companyID, departmentID, beginDate, endDate, _columnIndex, _isOrderByAcs);

            if (_attendanceLogRecordList != null && _attendanceLogRecordList.Count == 0)
            {
                MessageBox.Show("There's no records within the selected range.");
            }

            dgvAttendanceLog.AutoGenerateColumns = false;
            dgvAttendanceLog.DataSource = _attendanceLogRecordList;
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
            frmAddUpdateAttendanceRecord attForm = null;

            if (_curAttendanceLogRecord.ID > 0)
            {
                attForm = new frmAddUpdateAttendanceRecord(_curAttendanceLogRecord.ID);
            }
            else
            {
                attForm = new frmAddUpdateAttendanceRecord(_curAttendanceLogRecord.DateLog, _curAttendanceLogRecord.EmployeeNumber);
            }

            attForm.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.Confirm("Are you sure you want to delete this record? This cannot be undone."))
            {
                if (_dtCtrl.DeleteAttendanceRecord(_curAttendanceLogRecord.ID))
                {
                    MessageBox.Show("Record deleted.");
                    LoadAttdanceLog();
                }
                else
                {
                    MessageBox.Show("Record could not be deleted. Please try again.");
                }
            }
        }

        private void dgvAttendanceLog_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _curAttendanceLogRecord.ID = _attendanceLogRecordList[e.RowIndex].ID;

                if (_curAttendanceLogRecord.ID == 0) //Out Miss
                {
                    _curAttendanceLogRecord.DateLog = GetAttDate(e.RowIndex);
                    _curAttendanceLogRecord.EmployeeNumber = GetEmployeeNumber(e.RowIndex);
                }
            }
        }

        private int GetEmployeeNumber(int index)
        {
            while (--index >= 0)
            {
                if (_attendanceLogRecordList[index].EmployeeNumber > 0)
                {
                    return _attendanceLogRecordList[index].EmployeeNumber;
                }
            }

            return -1;
        }

        private DateTime GetAttDate(int index)
        {
            while (--index >= 0)
            {
                if (_attendanceLogRecordList[index].DateLog.Equals(DateTime.MinValue) == false && _attendanceLogRecordList[index].DateLog.Equals(Config.MinDate) == false)
                {
                    return _attendanceLogRecordList[index].DateLog;
                }
            }

            return Config.MinDate;
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
                        
                        if (e.ColumnIndex == 0) //Employee Number
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
                        else if (e.ColumnIndex == 1) //Employee Name
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
                        else if (e.ColumnIndex == 2) //Date
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
                cmsAction.Show(dgvAttendanceLog, mousePosition);
            }
        }

        private void dgvAttendanceLog_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAttendanceLog.DataSource != null && (e.ColumnIndex == 0 || e.ColumnIndex == 2))
            {
                _columnIndex = e.ColumnIndex;
                _isOrderByAcs = !_isOrderByAcs;
                LoadAttdanceLog();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateAttendanceRecord attForm = null;

            if (_curAttendanceLogRecord.ID > 0)
            {
                attForm = new frmAddUpdateAttendanceRecord(0);
            }
            else
            {
                attForm = new frmAddUpdateAttendanceRecord(_curAttendanceLogRecord.DateLog, _curAttendanceLogRecord.EmployeeNumber);
            }

            attForm.ShowDialog(this);
        }
    }
}
