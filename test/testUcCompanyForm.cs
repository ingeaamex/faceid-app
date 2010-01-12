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

            Assert.Greater(dtCtrl.AddCompany(company), 0);
            dtCtrl.DeleteCompany(company);
        }

        [Test]
        public void AddEmptyNamedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "";
            Company company = new Company();
            company.Name = companyName;

            Assert.Greater(dtCtrl.AddCompany(company), 0);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddDuplicatedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC";
            Company company = new Company();
            company.Name = companyName;

            dtCtrl.AddCompany(company);
            dtCtrl.AddCompany(company);
        }

        [Test]
        public void UpdateCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            Company company1 = new Company();
            company1.Name = "ABC";

            dtCtrl.AddCompany(company1);

            company1.Name = "123";

            Assert.AreEqual(dtCtrl.UpdateCompany(company1), true);
        }

        [Test]
        public void UpdateEmptyNamedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "";
            Company company = new Company();
            company.Name = companyName;

            Assert.AreEqual(dtCtrl.UpdateCompany(company), false);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void UpdateDuplicatedCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC";
            
            Company company1 = new Company();
            company1.Name = companyName;

            Company company2 = new Company();
            company2.Name = companyName;

            dtCtrl.UpdateCompany(company1);
            dtCtrl.UpdateCompany(company2);
        }

        [Test]
        public void DeleteCompanyTest()
        {
            IDataController dtCtrl = LocalDataController.Instance;

            string companyName = "ABC";

            Company company1 = new Company();
            company1.Name = companyName;

            dtCtrl.AddCompany(company1);
            Assert.AreEqual(dtCtrl.DeleteCompany(company1), true);
        }

        [Test]
        public void DeleteNotEmptiedCompanyTest()
        {
            //to be added later
        }
    }
}
