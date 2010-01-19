using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testUcDepartmentForm
    {
        [Test]
        public void AddUpdateDeleteDepartmentTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            //Add a new department
            Department dept1 = new Department();
            dept1.Name = "Dept1";
            dept1.CompanyID = 4;
            dept1.SupDepartmentID = 0;

            dept1.ID = dtCtrl.AddDepartment(dept1);
            Assert.Greater(dept1.ID, 0);

            //Add a new sub-department
            Department dept2 = new Department();
            dept2.Name = "Dept2";
            dept2.CompanyID = 4;
            dept2.SupDepartmentID = dept1.ID;

            dept2.ID = dtCtrl.AddDepartment(dept2);
            Assert.Greater(dept2.ID, 0);

            //Add a empty named department
            Department dept3 = new Department();
            dept3.Name = "";
            dept3.CompanyID = 4;
            dept3.SupDepartmentID = 0;

            Assert.Less(dtCtrl.AddDepartment(dept3), 0);

            //Add a duplicated department
            Department dept4 = new Department();
            dept4.Name = "Dept1";
            dept4.CompanyID = 4;
            dept4.SupDepartmentID = 0;

            Assert.Less(dtCtrl.AddDepartment(dept4), 0);

            //Add a non-company department
            Department dept5 = new Department();
            dept5.Name = "Dept5";
            dept5.SupDepartmentID = 0;

            Assert.Less(dtCtrl.AddDepartment(dept5), 0);

            //Update an existing department
            Assert.AreEqual(true, dtCtrl.UpdateDepartment(dept1));

            //Update an exist department using an exist Name
            dept1.Name = "Dept2";
            Assert.AreEqual(false, dtCtrl.UpdateDepartment(dept1));

            //Update an exist department using an empty Name
            dept1.Name = "";
            Assert.AreEqual(false, dtCtrl.UpdateDepartment(dept1));

            //Delete exist departments
            Assert.AreEqual(true, dtCtrl.DeleteDepartment(dept2.ID));
            Assert.AreEqual(true, dtCtrl.DeleteDepartment(dept1.ID));
        }
    }
}
