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

        List<Employee> GetEmployeeList(int departmentId);

        int AddEmployee(Employee employee);

        bool DeleteEmployee(int id);

        bool UpdateEmployee(Employee employee);

        bool UpdateEmployeeNumber(Employee employee);

        #endregion Employee

        #region WorkingCalendar
        List<WorkingCalendar> GetWCalendarList();
        #endregion WorkingCalendar

        #region Terminal
        List<Terminal> GetTerminalList();
        #endregion Terminal


        #region EmployeeTerminal

        List<EmployeeTerminal> GetEmplTerminalList();

        int AddEmplTerminal(EmployeeTerminal emplTerminal);

        bool DeleteEmplTerminal(EmployeeTerminal emplTerminal);

        bool UpdateEmplTerminal(EmployeeTerminal emplTerminal);

        #endregion EmployeeTerminal
    }
}
