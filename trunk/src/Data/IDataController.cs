using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.Data
{
    interface IDataController
    {
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

        bool UpdateEmployeeNumber(Employee employee);

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

        bool DeleteEmplTerminal(EmployeeTerminal emplTerminal);

        bool UpdateEmplTerminal(List<Terminal> terminals, int employeeNumber);

        #endregion EmployeeTerminal

        #region EmployeeNumber

        List<EmployeeNumber> GetEmployeeNumberList();

        int AddEmployeeNumber();

        #endregion EmployeeNumber
    }
}
