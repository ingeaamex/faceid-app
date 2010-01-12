using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta.Data
{
    interface IDataController
    {
        int AddCompany(FaceIDAppVBEta.Class.Company company);

        bool DeleteCompany(FaceIDAppVBEta.Class.Company company);

        bool UpdateCompany(FaceIDAppVBEta.Class.Company company);

        int AddDepartment(FaceIDAppVBEta.Class.Department department);

        bool UpdateDepartment(FaceIDAppVBEta.Class.Department department);

        bool DeleteDepartment(FaceIDAppVBEta.Class.Department department);
    }
}
