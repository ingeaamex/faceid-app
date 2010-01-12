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
            dept1.CompanyID = 1;

            dept1.ID = dtCtrl.AddDepartment(dept1);
            Assert.Greater(dept1.ID, 0);

            //Add a new sub-department
            Department dept2 = new Department();
            dept2.Name = "Dept2";
            dept2.CompanyID = 1;
            dept2.SupDepartmentID = dept1.ID;

            dept2.ID = dtCtrl.AddDepartment(dept2);
            Assert.Greater(dept2.ID, 0);

            //Add a empty named department
            Department dept3 = new Department();
            dept3.Name = "";
            dept3.CompanyID = 1;

            Assert.Less(dtCtrl.AddDepartment(dept3), 0);

            //Add a duplicated department
            Department dept4 = new Department();
            dept4.Name = "Dept1";
            dept4.CompanyID = 1;

            Assert.Less(dtCtrl.AddDepartment(dept4), 0);

            //Add a non-company department
            Department dept5 = new Department();
            dept5.Name = "Dept5";

            Assert.Less(dtCtrl.AddDepartment(dept5), 0);

            //Update an existing department
            Assert.AreEqual(dtCtrl.UpdateDepartment(dept1), true);

            //Update an exist department using an exist Name
            dept1.Name = "Dept2";
            Assert.AreEqual(dtCtrl.UpdateDepartment(dept1), false);

            //Update an exist department using an empty Name
            dept1.Name = "";
            Assert.AreEqual(dtCtrl.UpdateDepartment(dept1), false);

            //Delete exist departments
            Assert.AreEqual(dtCtrl.DeleteDepartment(dept1), true);
            Assert.AreEqual(dtCtrl.DeleteDepartment(dept2), true);
        }
    }
}
