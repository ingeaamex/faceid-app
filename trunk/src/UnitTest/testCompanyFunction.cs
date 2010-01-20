using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;
using NUnit.Framework;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testCompanyFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private Company com1 = new Company();
        private Company com2 = new Company();

        [Test]
        public void TestAddCompany()
        {
            com1.Name = "Com1";
            com1.ID = _dtCtrl.AddCompany(com1);

            Assert.Greater(com1.ID, 0);

            //add again
            Assert.Less(_dtCtrl.AddCompany(com1), 0);

            //add null
            Assert.Less(_dtCtrl.AddCompany(null), 0);

            //add empty name
            com2.Name = "";
            Assert.Less(_dtCtrl.AddCompany(com2), 0);

            //add duplicate name
            com2.Name = "Com1";
            Assert.Less(_dtCtrl.AddCompany(com2), 0);
        }

        [Test]
        public void TestGetCompanyList()
        {
            Assert.Greater(_dtCtrl.GetCompanyList().Count, 0);
        }

        [Test]
        public void TestUpdateCompany()
        {
            Assert.AreEqual(true, _dtCtrl.UpdateCompany(com1));

            com1.Name = "Com1'";

            Assert.AreEqual(true, _dtCtrl.UpdateCompany(com1));
            Assert.AreEqual(com1.Name, _dtCtrl.GetCompany(com1.ID).Name);

            //update null
            Assert.AreEqual(false, _dtCtrl.UpdateCompany(null));

            //update non exist company
            Assert.AreEqual(false, _dtCtrl.UpdateCompany(com2));

            //update duplicate name
            com2.Name = "Com2";
            com2.ID = _dtCtrl.AddCompany(com2);
            com2.Name = com1.Name;
            Assert.AreEqual(false, _dtCtrl.UpdateCompany(com2));

            //update null name
            com2.Name = null;
            Assert.AreEqual(false, _dtCtrl.UpdateCompany(com2));

            //update empty name
            com2.Name = "";
            Assert.AreEqual(false, _dtCtrl.UpdateCompany(com2));
        }

        [Test]
        public void TestGetCompany()
        {
            Assert.AreEqual(com1.ID, _dtCtrl.GetCompany(com1.ID).ID);
            Assert.AreEqual(com1.ID, _dtCtrl.GetCompany(com1.Name).ID);

            Assert.AreEqual(null, _dtCtrl.GetCompany(-1));
            Assert.AreEqual(null, _dtCtrl.GetCompany(""));
            Assert.AreEqual(null, _dtCtrl.GetCompany(null));
            Assert.AreEqual(null, _dtCtrl.GetCompany("non exist"));
        }

        [Test]
        public void TestDeleteCompany()
        {
            Assert.AreEqual(true, _dtCtrl.DeleteCompany(com1.ID));
            Assert.AreEqual(true, _dtCtrl.DeleteCompany(com2.ID));

            Assert.AreEqual(null, _dtCtrl.GetCompany(com1.ID));
            
            //delete again
            Assert.AreEqual(false, _dtCtrl.DeleteCompany(com1.ID));
            Assert.AreEqual(false, _dtCtrl.DeleteCompany(-1));

            //delete non-empty company
            com1.ID = _dtCtrl.AddCompany(com1);
            
            Department dep1 = new Department();
            dep1.CompanyID = com1.ID;
            dep1.Name = "Dep1";
            dep1.SupDepartmentID = 0; //root

            dep1.ID = _dtCtrl.AddDepartment(dep1);

            Assert.AreEqual(false, _dtCtrl.DeleteCompany(com1.ID));

            _dtCtrl.DeleteDepartment(dep1.ID);

            Assert.AreEqual(true, _dtCtrl.DeleteCompany(com1.ID));
        }
    }
}
