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
        private Department dep1 = new Department();

        private void AddDepartment()
        {
            com1.Name = DateTime.Now.Ticks.ToString();
            com1.ID = _dtCtrl.AddCompany(com1);

            dep1.CompanyID = com1.ID;
            dep1.Name = DateTime.Today.Ticks.ToString();
            dep1.SupDepartmentID = 0; //root
            dep1.ID = _dtCtrl.AddDepartment(dep1);
        }

        private void DeleteDeparment()
        {
            _dtCtrl.DeleteDepartment(dep1.ID);
            _dtCtrl.DeleteCompany(com1.ID);
        }

        [Test]
        public void TestAddDepartment()
        {
            AddDepartment();

            Assert.Greater(dep1.ID, 0);

            DeleteDeparment();
        }

        [Test]
        public void TestGetDepartmentList()
        {
            AddDepartment();

            Assert.Greater(_dtCtrl.GetDepartmentList().Count, 0);

            DeleteDeparment();
        }

        [Test]
        public void TestGetDepartmentByCompany()
        {
            AddDepartment();

            Assert.Greater(_dtCtrl.GetDepartmentByCompany(com1.ID).Count, 0);
            Assert.AreEqual(0, _dtCtrl.GetDepartmentByCompany(-99).Count);

            DeleteDeparment();
        }

        [Test]
        public void TestGetDepartment()
        {
            AddDepartment();

            Assert.AreEqual(dep1.ID, _dtCtrl.GetDepartment(dep1.ID).ID);
            Assert.AreEqual(dep1.ID, _dtCtrl.GetDepartment(dep1.Name).ID);

            DeleteDeparment();
        }

        [Test]
        public void TestUpdateDepartment()
        {
            AddDepartment();

            dep1.Name = DateTime.Today.Ticks.ToString() + "'";
            Assert.AreEqual(true, _dtCtrl.UpdateDepartment(dep1));
            Assert.AreEqual(dep1.Name, _dtCtrl.GetDepartment(dep1.ID).Name);

            DeleteDeparment();
        }

        [Test]
        public void TestDeleteDeparment()
        {
            AddDepartment();

            Assert.AreEqual(true, _dtCtrl.DeleteDepartment(dep1.ID));

            DeleteDeparment();
        }
    }
}
