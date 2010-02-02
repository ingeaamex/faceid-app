using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Data
{
    class RemoteDataController : IDataController
    {
        private static RemoteDataController instance;
        private static readonly Object mutex = new Object();

        private RemoteDataController() { }

        public static RemoteDataController Instance
        {
            get
            {
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new RemoteDataController();
                    }
                }

                return instance;
            }
        }

        #region IDataController Members

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Company> GetCompanyList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Company GetCompany(string name)
        {
            throw new NotImplementedException();
        }

        public int AddCompany(FaceIDAppVBEta.Class.Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCompany(FaceIDAppVBEta.Class.Company company)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Department> GetDepartmentList()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Department> GetDepartmentByCompany(int id)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Department GetDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public int AddDepartment(FaceIDAppVBEta.Class.Department department)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDepartment(FaceIDAppVBEta.Class.Department department)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public int AddEmployee(FaceIDAppVBEta.Class.Employee employee, List<FaceIDAppVBEta.Class.Terminal> terminalList)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Employee GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Employee> GetEmployeeList()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Employee> GetEmployeeList(int compantId, int departmentId)
        {
            throw new NotImplementedException();
        }

        public bool IsExistEmployeeNumber(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(FaceIDAppVBEta.Class.Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool IsNewEmployee(FaceIDAppVBEta.Class.Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Employee> GetEmployeeListByTerminal(int terminalID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Employee GetEmployeeByEmployeeNumber(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Terminal> GetTerminalList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Terminal GetTerminal(int id)
        {
            throw new NotImplementedException();
        }

        public int AddTerminal(FaceIDAppVBEta.Class.Terminal _terminal)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTerminal(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTerminal(FaceIDAppVBEta.Class.Terminal _terminal)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Terminal> GetTerminalListByEmployee(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.EmployeeTerminal> GetEmployeeTerminalList()
        {
            throw new NotImplementedException();
        }

        public int AddEmployeeTerminal(List<FaceIDAppVBEta.Class.EmployeeTerminal> emplTerminals)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeeTerminalByEmployee(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeeTerminal(int terminalID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployeeTerminal(List<FaceIDAppVBEta.Class.Terminal> terminals, int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.EmployeeNumber> GetEmployeeNumberList()
        {
            throw new NotImplementedException();
        }

        public int GetAvailEmployeeNumber()
        {
            throw new NotImplementedException();
        }

        public int AddWorkingCalendar(FaceIDAppVBEta.Class.WorkingCalendar workingCalendar, List<FaceIDAppVBEta.Class.Break> breakList, List<FaceIDAppVBEta.Class.Holiday> holidayList, FaceIDAppVBEta.Class.PaymentRate workingDayPaymentRate, FaceIDAppVBEta.Class.PaymentRate nonWorkingDayPaymentRate, FaceIDAppVBEta.Class.PaymentRate holidayPaymentRate, FaceIDAppVBEta.Class.PayPeriod payPeriod)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.WorkingCalendar> GetWorkingCalendarList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.WorkingCalendar GetWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.WorkingCalendar GetWorkingCalendarByEmployee(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWorkingCalendar(FaceIDAppVBEta.Class.WorkingCalendar workingCalendar, List<FaceIDAppVBEta.Class.Break> breakList, List<FaceIDAppVBEta.Class.Holiday> holidayList, FaceIDAppVBEta.Class.PaymentRate workingDayPaymentRate, FaceIDAppVBEta.Class.PaymentRate nonWorkingDayPaymentRate, FaceIDAppVBEta.Class.PaymentRate holidayPaymentRate, FaceIDAppVBEta.Class.PayPeriod payPeriod)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWorkingCalendar(FaceIDAppVBEta.Class.WorkingCalendar wCal)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateWorkingCalendarName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateWorkingCalendarName(string name, int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PayPeriod GetPayPeriod(int id)
        {
            throw new NotImplementedException();
        }

        public int AddPayPeriod(FaceIDAppVBEta.Class.PayPeriod payPeriod)
        {
            throw new NotImplementedException();
        }

        public bool DeletePayPeriod(int id)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PayPeriodType GetPayPeriodType(int id)
        {
            throw new NotImplementedException();
        }

        public int AddPayPeriodType(FaceIDAppVBEta.Class.PayPeriodType payPeriodType)
        {
            throw new NotImplementedException();
        }

        public bool DeletePayPeriodType(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePayPeriodType(FaceIDAppVBEta.Class.PayPeriodType payPeriodType)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.Break GetBreak(int id)
        {
            throw new NotImplementedException();
        }

        public int AddBreak(FaceIDAppVBEta.Class.Break _break)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBreak(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBreak(FaceIDAppVBEta.Class.Break _break)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Break> GetBreakListByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PaymentRate GetNonWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PaymentRate GetHolidayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PaymentRate GetWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.PaymentRate GetPaymentRate(int id)
        {
            throw new NotImplementedException();
        }

        public int AddPaymentRate(FaceIDAppVBEta.Class.PaymentRate paymentRate)
        {
            throw new NotImplementedException();
        }

        public bool DeletePaymentRate(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePaymentRate(FaceIDAppVBEta.Class.PaymentRate paymentRate)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.Holiday> GetHolidayListByWorkingCalendar(int workingCalendarID)
        {
            throw new NotImplementedException();
        }

        public int AddHoliday(FaceIDAppVBEta.Class.Holiday holiday)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHoliday(int id)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.AttendanceLogRecord> GetAttendanceLogRecordList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.AttendanceRecord> GetAttendanceRecordList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.AttendanceRecord GetAttendanceRecord(int id)
        {
            throw new NotImplementedException();
        }

        public int AddAttendanceRecord(FaceIDAppVBEta.Class.AttendanceRecord attRecord)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAttendanceRecord(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAttendanceRecord(FaceIDAppVBEta.Class.AttendanceRecord attRecord)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllAttendanceRecord()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.AttendanceSummaryReport> GetAttendanceSummaryReport(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.AttendanceLogReport> GetAttendanceLogReportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.AttendanceReport> GetAttendanceReportList()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetAttendanceReport(int companyID, int departmentID, DateTime dtFrom, DateTime dtTo)
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.AttendanceReport GetAttendanceReportByAttendanceRecord(int attendanceRecordID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAttendanceReport(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllAttendanceReport()
        {
            throw new NotImplementedException();
        }

        public int AddAttendanceReport(FaceIDAppVBEta.Class.AttendanceReport attendanceReport, bool returnID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAttendanceReport(FaceIDAppVBEta.Class.AttendanceReport attendanceReport)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.FaceIDUser> GetFaceIDUserList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.FaceIDUser GetFaceIDUser(int id)
        {
            throw new NotImplementedException();
        }

        public int AddFaceIDUser(FaceIDAppVBEta.Class.FaceIDUser faceIDUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFaceIDUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFaceIDUser(FaceIDAppVBEta.Class.FaceIDUser faceIDUser)
        {
            throw new NotImplementedException();
        }

        public bool IsFaceIDUser(int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public void CalculateAttendanceRecord()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.UncalculatedAttendanceRecord> GetUncalculatedAttendanceRecordList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.UncalculatedAttendanceRecord GetUncalculatedAttendanceRecord(int id)
        {
            throw new NotImplementedException();
        }

        public int AddUncalculatedAttendanceRecord(FaceIDAppVBEta.Class.UncalculatedAttendanceRecord uncalculatedAttendanceRecord)
        {
            throw new NotImplementedException();
        }

        public bool AddUncalculatedAttendanceRecord(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUncalculatedAttendanceRecord(string attRcList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUncalculatedAttendanceRecord(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUncalculatedAttendanceRecord(FaceIDAppVBEta.Class.UncalculatedAttendanceRecord uncalculatedAttendanceRecord)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllUncalculatedAttendanceRecord()
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.UndeletedEmployeeNumber> GetUndeletedEmployeeNumberList()
        {
            throw new NotImplementedException();
        }

        public FaceIDAppVBEta.Class.UndeletedEmployeeNumber GetUndeletedEmployeeNumber(int employeeNumber, int terminalID)
        {
            throw new NotImplementedException();
        }

        public bool AddUndeletedEmployeeNumber(FaceIDAppVBEta.Class.UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUndeletedEmployeeNumber(FaceIDAppVBEta.Class.UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUndeletedEmployeeNumber(FaceIDAppVBEta.Class.UndeletedEmployeeNumber undeletedEmployeeNumber)
        {
            throw new NotImplementedException();
        }

        public List<FaceIDAppVBEta.Class.PayrollExport> GetPayrollExportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void RefreshConnection()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
