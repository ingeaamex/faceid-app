using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using FaceIDAppVBEta.Class;
using System.Data;

namespace FaceIDAppVBEta.Data
{
    interface IDataController
    {
        #region Connection

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        #endregion Connection

        #region Company
        List<Company> GetCompanyList();

        Company GetCompany(int id);

        Company GetCompany(string name);

        int AddCompany(Company company);

        bool DeleteCompany(int id);

        bool UpdateCompany(Company company);
        #endregion Company

        #region Department
        List<Department> GetDepartmentList();

        List<Department> GetDepartmentByCompany(int id);

        Department GetDepartment(int id);

        int AddDepartment(Department department);

        bool UpdateDepartment(Department department);

        bool DeleteDepartment(int id);
        #endregion Department

        #region Employee

        Employee GetEmployee(int employeeId);

        List<Employee> GetEmployeeList();

        List<Employee> GetEmployeeList(int compantId, int departmentId);

        bool IsExistEmployeeNumber(int employeeNumber);
        
        int AddEmployee(Employee employee);

        bool DeleteEmployee(int employeeId);

        bool UpdateEmployee(Employee employee);

        bool IsNewEmployee(Employee employee);

        List<Employee> GetEmployeeListByTerminal(int terminalID);

        #endregion Employee

        #region Terminal
        List<Terminal> GetTerminalList();
		Terminal GetTerminal(int id);
        int AddTerminal(Terminal _terminal);
        bool DeleteTerminal(int id);
        bool UpdateTerminal(Terminal _terminal);
        #endregion Terminal

        #region EmployeeTerminal

        List<Terminal> GetTerminalListByEmployee(int employeeNumber);

        List<EmployeeTerminal> GetEmployeeTerminalList();

        int AddEmployeeTerminal(List<EmployeeTerminal> emplTerminals);

        bool DeleteEmployeeTerminalByEmployee(int employeeNumber);

        bool DeleteEmployeeTerminal(int terminalID);

        bool UpdateEmployeeTerminal(List<Terminal> terminals, int employeeNumber);

        #endregion EmployeeTerminal

        #region EmployeeNumber

        List<EmployeeNumber> GetEmployeeNumberList();

        int GetAvailEmployeeNumber();

        #endregion EmployeeNumber

        #region Working Calendar
        int AddWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate, PayPeriod payPeriod);
        
        List<WorkingCalendar> GetWorkingCalendarList();

        WorkingCalendar GetWorkingCalendar(int workingCalendarID);

        WorkingCalendar GetWorkingCalendarByEmployee(int employeeNumber);
        
        bool UpdateWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate, PayPeriod payPeriod);

        bool UpdateWorkingCalendar(WorkingCalendar wCal);

        PayPeriod GetPayPeriodByName(string payPeriodName);

        bool IsDuplicateWorkingCalendarName(string name);

        bool IsDuplicateWorkingCalendarName(string name, int workingCalendarID);

        bool DeleteWorkingCalendar(int workingCalendarID);

        #endregion

        #region PayPeriod
        PayPeriod GetPayPeriodByWorkingCalendar(int workingCalendarID);

        PayPeriod GetPayPeriod(int id);

        int AddPayPeriod(PayPeriod payPeriod);

        bool DeletePayPeriod(int id);

        #endregion

        #region PayPeriodType
        PayPeriodType GetPayPeriodType(int id);

        int AddPayPeriodType(PayPeriodType payPeriodType);

        bool DeletePayPeriodType(int id);

        bool UpdatePayPeriodType(PayPeriodType payPeriodType);
        #endregion

        #region Break
        Break GetBreak(int id);
        
        int AddBreak(Break _break);

        bool DeleteBreak(int id);

        bool UpdateBreak(Break _break);

        List<Break> GetBreakListByWorkingCalendar(int workingCalendarID);
        #endregion

        #region PaymentRate
        PaymentRate GetNonWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID);

        PaymentRate GetHolidayPaymentRateByWorkingCalendar(int workingCalendarID);

        PaymentRate GetWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID);

        PaymentRate GetPaymentRate(int id);

        int AddPaymentRate(PaymentRate paymentRate);

        bool DeletePaymentRate(int id);

        bool UpdatePaymentRate(PaymentRate paymentRate);
        #endregion

        #region Holiday
        List<Holiday> GetHolidayListByWorkingCalendar(int workingCalendarID);

        int AddHoliday(Holiday holiday);

        bool DeleteHoliday(int id);
        #endregion

        #region AttendanceRecord

        List<AttendanceLogReport> GetAttendanceReportList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate);

        List<AttendanceLogRecord> GetAttendanceRecordList(int iCompany, int iDepartment, DateTime beginDate, DateTime endDate);

        AttendanceRecord GetAttendanceRecord(int id);

        bool AddAttendanceRecord(AttendanceRecord attRecord);

        bool DeleteAttendanceRecord(int id);

        bool UpdateAttendanceRecord(AttendanceRecord attRecord);

        #endregion Attendance Record

        #region Attendance Report
        DataTable GetAttendanceReport(int companyID, int departmentID, DateTime dtFrom, DateTime dtTo);
        #endregion Attendance Report

        #region Face Data
        List<FaceData> GetFaceDataList();

        FaceData GetFaceData(int id);

        int AddFaceData(FaceData _faceData);

        bool DeleteFaceData(int id);

        bool UpdateFaceData(FaceData _faceData);
        #endregion
    }
}
