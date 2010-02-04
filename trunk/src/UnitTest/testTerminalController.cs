using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;
using System.Windows.Forms;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testTerminalController
    {
        IDataController _dtCtrl = LocalDataController.Instance;
        ITerminalController _terCtrl = new TerminalController();
        
        private Terminal ter = new Terminal();
        private Employee emp;

        private void SetUp()
        {
            ter.IPAddress = "10.0.0.101";
            ter.Name = "Ter1";

            Department dep = _dtCtrl.GetDepartmentList()[0];
            Company com = _dtCtrl.GetCompany(dep.CompanyID);

            emp = _dtCtrl.GetEmployeeList(com.ID, dep.ID)[0];
        }

        private void CleanUp()
        {
            _dtCtrl.DeleteTerminal(ter.ID);
        }

        [Test]
        public void TestGetAttendanceRecord()
        {
            SetUp();

            Assert.AreEqual(true, _terCtrl.GetAttendanceRecord(ter, DateTime.Today.AddYears(-1), DateTime.Today).Count > 0);

            CleanUp();
        }

        [Test]
        public void TestDeleteAttendanceRecord()
        {
            SetUp();

            Assert.AreEqual(true, _terCtrl.DeleteAttendanceRecord(ter));
            Assert.AreEqual(0, _terCtrl.GetAttendanceRecord(ter, DateTime.Today.AddYears(-1), DateTime.Today).Count);

            CleanUp();
        }

        [Test]
        public void TestUpdateEmployee()
        {
            SetUp();

            Assert.AreEqual(true, _terCtrl.UpdateEmployee(ter, emp));
            Assert.AreEqual(emp.FirstName, _terCtrl.GetEmployee(ter, emp.EmployeeNumber).FirstName);

            CleanUp();
        }

        [Test]
        public void TestGetEmployee()
        {
            SetUp();

            Assert.AreEqual(emp.FirstName, _terCtrl.GetEmployee(ter, emp.EmployeeNumber).FirstName);

            CleanUp();
        }

        [Test]
        public void TestGetAllEmployee()
        {
            SetUp();

            Assert.AreEqual(true, _terCtrl.GetAllEmployee(ter).Count > 0);

            CleanUp();
        }

        [Test]
        public void TestRemoveEmployee()
        {
            SetUp();

            Assert.AreEqual(true, _terCtrl.RemoveEmployee(ter, emp.EmployeeNumber));
            Assert.AreEqual(null, _terCtrl.GetEmployee(ter, emp.EmployeeNumber));

            CleanUp();
        }
    }
}