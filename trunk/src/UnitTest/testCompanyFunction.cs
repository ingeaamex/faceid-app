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
        private IDataController _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
        private Company com1 = new Company();

        private void AddCompany()
        {
            com1.Name = DateTime.Now.Ticks.ToString();
            com1.ID = _dtCtrl.AddCompany(com1);
        }

        private void DeleteCompany()
        {
            _dtCtrl.DeleteCompany(com1.ID);
        }

        [Test]
        public void TestAddCompany()
        {
            AddCompany();

            Assert.Greater(com1.ID, 0);

            DeleteCompany();
        }

        [Test]
        public void TestGetCompanyList()
        {
            AddCompany();

            Assert.Greater(_dtCtrl.GetCompanyList().Count, 0);

            DeleteCompany();
        }

        [Test]
        public void TestUpdateCompany()
        {
            AddCompany();

            com1.Name += "'";

            Assert.AreEqual(true, _dtCtrl.UpdateCompany(com1));
            Assert.AreEqual(com1.Name, _dtCtrl.GetCompany(com1.ID).Name);

            DeleteCompany();
        }

        [Test]
        public void TestGetCompany()
        {
            AddCompany();

            Assert.AreEqual(com1.ID, _dtCtrl.GetCompany(com1.ID).ID);
            Assert.AreEqual(com1.ID, _dtCtrl.GetCompany(com1.Name).ID);

            Assert.AreEqual(null, _dtCtrl.GetCompany(-1));
            Assert.AreEqual(null, _dtCtrl.GetCompany(""));
            Assert.AreEqual(null, _dtCtrl.GetCompany("non exist"));

            DeleteCompany();
        }

        [Test]
        public void TestDeleteCompany()
        {
            AddCompany();

            Assert.AreEqual(true, _dtCtrl.DeleteCompany(com1.ID));

            DeleteCompany();
        }
    }
}
