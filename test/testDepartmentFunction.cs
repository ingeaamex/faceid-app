using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testDepartmentFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        private Company com1 = new Company();
        private Company com2 = new Company();
        private Department dep1 = new Department();
        private Department dep2 = new Department();
        private Department dep3 = new Department();

        [Test]
        public void TestAddDepartment()
        {
            com1.ID = _dtCtrl.AddCompany(com1);

            dep1.CompanyID = com1.ID;
            dep1.Name = "Dep1";
            dep1.SupDepartmentID = 0; //root
            dep1.ID = _dtCtrl.AddDepartment(dep1);

            Assert.Greater(dep1.ID, 0);

            //again
            Assert.Less(_dtCtrl.AddDepartment(dep1), 0);

            //non company
            dep2.CompanyID = 0;
            dep2.Name = "Dep2";
            dep2.SupDepartmentID = 0; //root;
            dep2.ID = _dtCtrl.AddDepartment(dep2);

            Assert.Less(dep2.ID, 0);

            //empty name
            dep2.CompanyID = com1.ID;
            dep2.Name = "";
            dep2.SupDepartmentID = 0; //root;
            dep2.ID = _dtCtrl.AddDepartment(dep2);

            Assert.Less(dep2.ID, 0);

            //duplicate name
            dep2.CompanyID = com1.ID;
            dep2.Name = "Dep1";
            dep2.SupDepartmentID = 0; //root;
            dep2.ID = _dtCtrl.AddDepartment(dep2);

            Assert.Less(dep2.ID, 0);

            //sub deparment
            dep2.CompanyID = com1.ID;
            dep2.Name = "Dep2";
            dep2.SupDepartmentID = dep1.ID;
            dep2.ID = _dtCtrl.AddDepartment(dep2);

            Assert.Greater(dep2.ID, 0);

            //sub deparment, duplicate name
            dep3.CompanyID = com1.ID;
            dep3.Name = "Dep1";
            dep3.SupDepartmentID = dep1.ID;
            dep3.ID = _dtCtrl.AddDepartment(dep3);

            Assert.Less(dep3.ID, 0);

            //diff company, duplicate name
            com2.Name = "Com2";
            com2.ID = _dtCtrl.AddCompany(com2);

            dep3.CompanyID = com2.ID;
            dep3.Name = "Dep1";
            dep3.SupDepartmentID = 0; //root
            dep3.ID = _dtCtrl.AddDepartment(dep3);

            Assert.Greater(dep3.ID, 0);

            //null
            Assert.Less(_dtCtrl.AddDepartment(null), 0);
        }

        [Test]
        public void TestGetDepartmentList()
        {
            Assert.Greater(_dtCtrl.GetDepartmentList().Count, 0);
        }

        [Test]
        public void TestGetDepartmentByCompany()
        {
            Assert.AreEqual(2, _dtCtrl.GetDepartmentByCompany(com1.ID).Count);
            Assert.AreEqual(0, _dtCtrl.GetDepartmentByCompany(-1).Count);
        }

        [Test]
        public void TestGetDepartment()
        {
            Assert.AreEqual(dep1.ID, _dtCtrl.GetDepartment(dep1.ID).ID);
            Assert.AreEqual(dep2.ID, _dtCtrl.GetDepartment(dep2.ID).ID);
            Assert.AreEqual(dep3.ID, _dtCtrl.GetDepartment(dep3.ID).ID);
        }

        [Test]
        public void TestUpdateDepartment()
        {
            dep1.Name = "Dep1'";
            Assert.AreEqual(true, _dtCtrl.UpdateDepartment(dep1));
            Assert.AreEqual(dep1.Name, _dtCtrl.GetDepartment(dep1.ID).Name);

            //empty name
            dep1.Name = "";
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(dep1));

            //null name
            dep1.Name = null;
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(dep1));

            //duplicate name, same company
            dep2.Name = dep1.Name;
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(dep2));

            //duplicate name, diff company
            dep3.Name = dep1.Name;
            Assert.AreEqual(true, _dtCtrl.UpdateDepartment(dep3));

            //change company, same name
            dep3.CompanyID = dep1.CompanyID;
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(dep3));

            //change company, diff name
            dep3.Name = "Dep3";
            Assert.AreEqual(true, _dtCtrl.UpdateDepartment(dep3));

            //non exist department
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(new Department()));

            //null
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(null));

            //non company
            dep1.CompanyID = -1;
            Assert.AreEqual(false, _dtCtrl.UpdateDepartment(dep1));
        }

        [Test]
        public void TestDeleteDeparment()
        {
            //non empty dep
            Assert.AreEqual(false, _dtCtrl.DeleteDepartment(dep1.ID));

            Assert.AreEqual(true, _dtCtrl.DeleteDepartment(dep2.ID));
            Assert.AreEqual(null, _dtCtrl.GetDepartment(dep2.ID));

            Assert.AreEqual(true, _dtCtrl.DeleteDepartment(dep1.ID));
            Assert.AreEqual(true, _dtCtrl.DeleteDepartment(dep3.ID));

            //again
            Assert.AreEqual(false, _dtCtrl.DeleteDepartment(dep1.ID));
            Assert.AreEqual(false, _dtCtrl.DeleteDepartment(-1));

            _dtCtrl.DeleteCompany(com1.ID);
            _dtCtrl.DeleteCompany(com2.ID);
        }
    }
}
