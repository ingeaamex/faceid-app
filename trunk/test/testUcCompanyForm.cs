using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testUcCompanyForm
    {
        [Test]
        public void AddCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC";
            Company company = new Company();
            company.Name = companyName;
            company.ID = dtCtrl.AddCompany(company);
            Assert.Greater(company.ID, 0);
            dtCtrl.DeleteCompany(company.ID);
        }

        [Test]
        public void AddEmptyNamedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "";
            Company company = new Company();
            company.Name = companyName;

            Assert.Less(dtCtrl.AddCompany(company), 0);
        }

        [Test]
        public void AddDuplicatedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC";
            Company company = new Company();
            company.Name = companyName;

            dtCtrl.AddCompany(company);
            Assert.Less(dtCtrl.AddCompany(company), 0);
        }

        [Test]
        public void UpdateCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            Company company1 = new Company();
            company1.Name = "ABC123";

            company1.ID = dtCtrl.AddCompany(company1);

            company1.Name = "A123456";

            Assert.AreEqual(true, dtCtrl.UpdateCompany(company1));
        }

        [Test]
        public void UpdateEmptyNamedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "";
            Company company = new Company();
            company.Name = companyName;

            Assert.AreEqual(false, dtCtrl.UpdateCompany(company));
        }

        [Test]
        public void UpdateDuplicatedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC1";
            Company company1 = new Company();
            company1.Name = companyName;
            company1.ID = dtCtrl.AddCompany(company1);

            companyName = "ABC2";
            Company company2 = new Company();
            company2.Name = companyName;
            company2.ID = dtCtrl.AddCompany(company2);
            company2.Name = company1.Name;

            Assert.AreEqual(false, dtCtrl.UpdateCompany(company2));
        }

        [Test]
        public void DeleteCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABCs";

            Company company1 = new Company();
            company1.Name = companyName;
            company1.ID = dtCtrl.AddCompany(company1);

            Assert.AreEqual(true, dtCtrl.DeleteCompany(company1.ID));
        }

        [Test]
        public void DeleteNotEmptiedCompanyTest()
        {
            //to be added later
        }
    }
}
