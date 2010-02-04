using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
using System.IO;
using System.Collections;
using System.Globalization;

namespace FaceIDAppVBEta
{
    public partial class ucEmployeeForm : UserControl
    {
        private Point _cellContext;
        private ITerminalController _terCtrl = new TerminalController();
        private IDataController _dtCtrl = LocalDataController.Instance;

        public ucEmployeeForm()
        {
            InitializeComponent();
            BindCompany();

        }

        private void btView_Click(object sender, EventArgs e)
        {
            BindEmployee();
            btnExportToFile.Enabled = true;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;
            frmEmployeeReport frmEmpl = new frmEmployeeReport(iCompany, iDepartment);
            frmEmpl.ShowDialog(this);
        }

        private void btNewEmpl_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frmEmpl = new frmAddUpdateEmployee(-1);
            frmEmpl.ShowDialog(this);
        }

        private void cboxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        private void BindEmployee()
        {
            int iCompany = (int)cbxCompany.SelectedValue;
            int iDepartment = -1;
            if (cbxDepartment.Enabled)
                iDepartment = (int)cbxDepartment.SelectedValue;

            List<Employee> employees = _dtCtrl.GetEmployeeList(iCompany, iDepartment);
            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.DataSource = employees;
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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvEmployee.Rows[_cellContext.X].Cells[dgvEmployee.Columns["PayrollNumber"].Index].Value;
            frmAddUpdateEmployee objForm = new frmAddUpdateEmployee(id);
            objForm.ShowDialog(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object employeeID = dgvEmployee.Rows[_cellContext.X].Cells[dgvEmployee.Columns["PayrollNumber"].Index].Value;

            if (Util.Confirm("Are you sure?"))
            {
                Employee employee = _dtCtrl.GetEmployee((int)employeeID);

                if (employee == null)
                    throw new NullReferenceException("Employee not found or has been deleted");

                _dtCtrl.BeginTransaction();
                try
                {
                    _dtCtrl.DeleteEmployee((int)employeeID);
                    _dtCtrl.DeleteEmployeeTerminalByEmployee(employee.EmployeeNumber);

                    RemoveEmployeeFromTerminal(employee);

                    _dtCtrl.CommitTransaction();

                    MessageBox.Show("Employee deleted successfully.");
                    BindEmployee();
                }
                catch (Exception ex)
                {
                    _dtCtrl.RollbackTransaction();
                    MessageBox.Show("There has been an error: " + ex.Message + ". Please try again.");
                }
            }
        }

        private void RemoveEmployeeFromTerminal(Employee employee)
        {
            List<Terminal> terminalList = _dtCtrl.GetTerminalListByEmployee(employee.EmployeeNumber);

            foreach (Terminal terminal in terminalList)
            {
                bool employeeRemoved = false;

                if (_terCtrl.IsTerminalConnected(terminal))
                {
                    throw new Exception("Do not do this yet. It is painful to add an employee using the terminal you know.");

                    if (_terCtrl.RemoveEmployee(terminal, employee) == false)
                        throw new Exception("Cannot remove employee " + employee.EmployeeNumber);
                }

                if (employeeRemoved == false)
                {
                    UndeletedEmployeeNumber undeletedEmployeeNumber = new UndeletedEmployeeNumber();
                    undeletedEmployeeNumber.EmployeeNumber = employee.EmployeeNumber;
                    undeletedEmployeeNumber.TerminalID = terminal.ID;

                    if (_dtCtrl.AddUndeletedEmployeeNumber(undeletedEmployeeNumber))
                        throw new Exception("User could not be deleted");
                }
            }
        }

        private void dgvEmpl_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _cellContext = new Point(e.RowIndex, e.ColumnIndex);
        }

        private void dgvEmpl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvEmployee.Columns["EmployeeName"].Index)
            {
                List<Employee> employees = (List<Employee>)dgvEmployee.DataSource;
                Employee employee = employees[e.RowIndex];

                e.FormattingApplied = true;
                e.Value = string.Format("{0}, {1}", employee.LastName, employee.FirstName);
            }
            else if (e.ColumnIndex == dgvEmployee.Columns["Terminal"].Index)
            {
                List<Employee> employees = (List<Employee>)dgvEmployee.DataSource;
                Employee employee = employees[e.RowIndex];

                List<Terminal> terminals = _dtCtrl.GetTerminalListByEmployee(Convert.ToInt32(e.Value));

                string terminalNames = "";
                if (terminals.Count > 0)
                {
                    foreach (Terminal t in terminals)
                        terminalNames += t.Name + ", ";

                    terminalNames = terminalNames.Trim().TrimEnd(',');
                }

                e.FormattingApplied = true;
                e.Value = terminalNames;
            }
            else if (e.ColumnIndex == dgvEmployee.Columns["WorkingCalendar"].Index)
            {
                int workingCalendarID = Convert.ToInt32(dgvEmployee[dgvEmployee.Columns["WorkingCalendarID"].Index, e.RowIndex].Value);
                e.Value = GetWorkingCalendarName(workingCalendarID);
            }
        }

        private Hashtable _htbWorkingCalendar = new Hashtable();

        private string GetWorkingCalendarName(int workingCalendarID)
        {
            if (workingCalendarID <= 0)
                return "";

            if (_htbWorkingCalendar.Contains(workingCalendarID))
            {
                return _htbWorkingCalendar[workingCalendarID].ToString();
            }
            else
            {
                WorkingCalendar workingCalendar = _dtCtrl.GetWorkingCalendar(workingCalendarID);
                if (workingCalendar != null)
                {
                    _htbWorkingCalendar.Add(workingCalendarID, workingCalendar.Name);
                    return workingCalendar.Name;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        private void btnGetEmployeeFromTerminal_Click(object sender, EventArgs e)
        {
            GetEmployeeFromTerminal();
        }

        private void GetEmployeeFromTerminal()
        {
            try
            {
                List<Terminal> terminalList = _dtCtrl.GetTerminalList();

                foreach (Terminal terminal in terminalList)
                {
                    if (_terCtrl.IsTerminalConnected(terminal))
                    {
                        List<Employee> employeeList = _terCtrl.GetAllEmployee(terminal);

                        foreach (Employee employee in employeeList)
                        {
                            if (_dtCtrl.IsNewEmployee(employee))
                            {
                                employee.Active = true;
                                employee.Address = "";
                                employee.DepartmentID = 1;
                                employee.JobDescription = "";
                                employee.LastName = "";
                                employee.PhoneNumber = "";

                                if (_dtCtrl.AddEmployee(employee, new List<Terminal>() { terminal }) < 0)
                                    throw new Exception("Cannot update employee " + employee.EmployeeNumber);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Cannot connect to terminal " + terminal.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error: " + ex.Message + ". Please try again.");
                return;
            }

            MessageBox.Show("Employee data from terminals have been copied successfully");
            BindEmployee();
        }

        private void btnSendEmployeeToTerminal_Click(object sender, EventArgs e)
        {
            SendEmployeeToTerminal();
        }

        private void SendEmployeeToTerminal()
        {
            try
            {
                List<Terminal> terminalList = _dtCtrl.GetTerminalList();

                foreach (Terminal terminal in terminalList)
                {
                    if (_terCtrl.IsTerminalConnected(terminal))
                    {
                        List<Employee> employeeList = _dtCtrl.GetEmployeeListByTerminal(terminal.ID);

                        foreach (Employee employee in employeeList)
                        {
                            if (_terCtrl.UpdateEmployee(terminal, employee) == false)
                                throw new Exception("Cannot update employee " + employee.EmployeeNumber + " on terminal " + terminal.Name);
                        }
                    }
                    else
                    {
                        throw new Exception("Cannot connect to terminal " + terminal.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error: " + ex.Message + ". Please try again.");
                return;
            }

            MessageBox.Show("Employee data from terminals have been copied successfully");
            BindEmployee();
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            ExportToFile();
        }

        private void ExportToFile()
        {
            SaveFileDialog sfdExport = new SaveFileDialog();
            sfdExport.Filter = "Text files (*.txt)|*.txt";
            sfdExport.FileName = DateTime.Now.Ticks.ToString();

            if (sfdExport.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdExport.FileName;
                StreamWriter sWrite = new StreamWriter(filePath, false);

                try
                {
                    if (dgvEmployee.DataSource == null)
                    {
                        MessageBox.Show("Please select company/department and click View for a list of employee first");
                        return;
                    }

                    List<Employee> employeeList = (List<Employee>)dgvEmployee.DataSource;

                    if (employeeList.Count == 0)
                    {
                        MessageBox.Show("There is no employee to export. Please try again.");
                        return;
                    }

                    foreach (Employee employee in employeeList)
                    {
                        sWrite.WriteLine("Return(result=\"success\" ");
                        sWrite.WriteLine(string.Format("id=\"{0}\" name=\"{1}\" calid=\"\" card_num=\"0Xffffff\" authority=\"0X0\" check_type=\"face&card\" opendoor_type=\"face&card\" ", employee.EmployeeNumber, employee.FirstName));

                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData1));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData2));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData3));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData4));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData5));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData6));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData7));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData8));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData9));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData10));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData11));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData12));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData13));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData14));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData15));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData16));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData17));
                        sWrite.WriteLine(string.Format("face_data=\"{0}\" ", employee.FaceData18));
                        sWrite.WriteLine(")");
                    }

                    MessageBox.Show("Export successfully.");
                }
                catch (Exception ex)
                {
                    Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again.");
                }
                finally
                {
                    sWrite.Close();
                }
            }
        }

        private void dgvEmpl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEmployee.Columns["WorkingCalendar"].Index && e.RowIndex >= 0)
            {
                List<Employee> employeeList = (List<Employee>)dgvEmployee.DataSource;
                Employee employee = employeeList[e.RowIndex];

                if (employee != null)
                {
                    frmPreviewWorkingCalendar form = new frmPreviewWorkingCalendar(employee.WorkingCalendarID);
                    form.ShowDialog(this);
                }
            }
        }

        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            StreamReader sReader = null;
            try
            {
                OpenFileDialog ofdImport = new OpenFileDialog();
                ofdImport.Filter = "Text files (*.txt)|*.txt";

                if (ofdImport.ShowDialog() == DialogResult.OK)
                {
                    sReader = new StreamReader(ofdImport.FileName);

                    string line = "";
                    List<Employee> employeeList = new List<Employee>();

                    while ((line = sReader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Co./Last Name,First Name")) //is header
                            continue; //go to next line
                        else
                        {
                            Employee employee = new Employee();
                            GetEmployeeData(line, ref employee);

                            employeeList.Add(employee);
                        }
                    }

                    foreach (Employee employee in employeeList)
                    {
                        if (_dtCtrl.AddEmployee(employee, new List<Terminal>()) <= 0)
                            throw new Exception("Can not import employee " + employee.EmployeeNumber);
                    }

                    
                    MessageBox.Show("Import successfully");
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage("There has been an error: " + ex.Message + ". Please try again.");
            }
            finally
            {
                try
                {
                    sReader.Close();
                }
                catch { }
            }
        }

        private void GetEmployeeData(string line, ref Employee employee)
        {
            try
            {
                string[] data = line.Split(',');

                employee.Active = true;
                employee.Address = data[4] + " " + data[5] + " " + data[6] + " " + data[7];
                employee.Birthday = data[108] != "" ? Convert.ToDateTime(data[108], new CultureInfo("en-US")) : Config.MinDate;
                employee.DepartmentID = 1; //default department
                employee.EmployeeNumber = Convert.ToInt32(data[2]);
                employee.FirstName = data[1];
                employee.HiredDate = data[110] != "" ? Convert.ToDateTime(data[110], new CultureInfo("en-US")) : Config.MinDate;
                employee.LastName = data[0];
                employee.PhoneNumber = data[12];
                employee.WorkingCalendarID = -1;
            }
            catch (FormatException)
            {
                throw new Exception("Employee's CardID must be in number only");
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("File format not supported");
            }
        }
    }
}
