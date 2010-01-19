using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using FaceIDAppVBEta.Class;

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

        List<Employee> GetEmployeeList(int compantId);

        List<Employee> GetEmployeeListByDep(int departmentId);

        int AddEmployee(Employee employee);

        bool DeleteEmployee(int employeeId);

        bool UpdateEmployee(Employee employee);

        #endregion Employee

        #region WorkingCalendar
        List<WorkingCalendar> GetWCalendarList();
        #endregion WorkingCalendar

        #region Terminal
        List<Terminal> GetTerminalList();
		Terminal GetTerminal(int id);
        int AddTerminal(Terminal _terminal);
        bool DeleteTerminal(int id);
        bool UpdateTerminal(Terminal _terminal);
        #endregion Terminal

        #region EmployeeTerminal

        List<Terminal> GetTerminalsByEmpl(int employeeNumber);

        List<EmployeeTerminal> GetEmplTerminalList();

        int AddEmplTerminal(List<EmployeeTerminal> emplTerminals);

        bool DeleteEmplTerminalByEmpl(int employeeNumber);

        bool DeleteEmplTerminal(int terminalID);

        bool UpdateEmplTerminal(List<Terminal> terminals, int employeeNumber);

        #endregion EmployeeTerminal

        #region EmployeeNumber

        List<EmployeeNumber> GetEmployeeNumberList();

        int GetAvailEmployeeNumber();

        #endregion EmployeeNumber

        #region Working Calendar
        WorkingCalendar GetWorkingCalendar(int workingCalendarID);

        List<Break> GetBreakByWorkingCalendar(int workingCalendarID);

        PaymentRate GetWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID);

        PaymentRate GetNonWorkingDayPaymentRateByWorkingCalendar(int workingCalendarID);

        PaymentRate GetHolidayPaymentRateByWorkingCalendar(int workingCalendarID);

        List<Holiday> GetHolidayListByWorkingCalendar(int workingCalendarID);

        PayPeriod GetPayPeriodByWorkingCalendar(int workingCalendarID);
        #endregion

        int AddWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate);

        bool UpdateWorkingCalendar(WorkingCalendar workingCalendar, List<Break> breakList, List<Holiday> holidayList, PaymentRate workingDayPaymentRate, PaymentRate nonWorkingDayPaymentRate, PaymentRate holidayPaymentRate);

        PayPeriod GetPayPeriodByName(string payPeriodName);

        bool IsDuplicatedWorkingCalendarName(string name);

        bool IsDuplicatedWorkingCalendarName(string name, int _workingCalendarID);
    }
}
