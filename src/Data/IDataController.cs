using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.Data
{
    interface IDataController
    {
        List<Company> GetCompanyList();

        List<Department> GetDepartmentList();

        List<Department> GetDepartmentByCompany(int id);

        Department GetDepartment(int id);

        Company GetCompany(int id);

        int AddCompany(Company company);

        bool DeleteCompany(int id);

        bool UpdateCompany(Company company);

        int AddDepartment(Department department);

        bool UpdateDepartment(Department department);

        bool DeleteDepartment(int id);
    
    }
}
