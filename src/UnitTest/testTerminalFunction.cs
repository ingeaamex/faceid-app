using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;
using NUnit.Framework;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testTerminalFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        
        private Terminal ter1 = new Terminal();
        private Employee emp1 = new Employee();

        private void AddTerminal()
        {
            ter1.Name = DateTime.Now.Ticks.ToString();
            ter1.IPAddress = "10.0.0.199";
            
            ter1.ID = _dtCtrl.AddTerminal(ter1);

            emp1 = new Employee();
            emp1.Active = true;
            emp1.ActiveFrom = DateTime.Today;
            emp1.ActiveTo = DateTime.Today.AddDays(1);
            emp1.Address = DateTime.Now.Ticks.ToString();
            emp1.Birthday = DateTime.Today.AddYears(-20);
            emp1.DepartmentID = _dtCtrl.GetDepartmentList()[0].ID;
            emp1.EmployeeNumber = 0;
            emp1.FirstName = DateTime.Now.Ticks.ToString();
            emp1.JobDescription = DateTime.Now.Ticks.ToString();
            emp1.HiredDate = DateTime.Today;
            emp1.LeftDate = DateTime.Today.AddYears(1);
            emp1.LastName = DateTime.Now.Ticks.ToString();
            emp1.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp1.WorkingCalendarID = _dtCtrl.GetWorkingCalendarList()[0].ID;
            emp1.FaceData1 = "";
            emp1.FaceData2 = "";
            emp1.FaceData3 = "";
            emp1.FaceData4 = "";
            emp1.FaceData5 = "";
            emp1.FaceData6 = "";
            emp1.FaceData7 = "";
            emp1.FaceData8 = "";
            emp1.FaceData9 = "";
            emp1.FaceData10 = "";
            emp1.FaceData11 = "";
            emp1.FaceData12 = "";
            emp1.FaceData13 = "";
            emp1.FaceData14 = "";
            emp1.FaceData15 = "";
            emp1.FaceData16 = "";
            emp1.FaceData17 = "";
            emp1.FaceData18 = "";

            emp1.PayrollNumber = _dtCtrl.AddEmployee(emp1, new List<Terminal>() { ter1 });
            
        }

        private void DeleteTerminal()
        {
            _dtCtrl.DeleteEmployee(emp1.PayrollNumber);
            _dtCtrl.DeleteTerminal(ter1.ID);
        }

        [Test]
        public void TestAddTerminal()
        {
            AddTerminal();

            Assert.Greater(ter1.ID, 0);
            
            DeleteTerminal();
        }

        [Test]
        public void TestGetTerminalList()
        {
            AddTerminal();

            Assert.Greater(_dtCtrl.GetTerminalList().Count, 0);

            DeleteTerminal();
        }

        [Test]
        public void TestUpdateTerminal()
        {
            AddTerminal();

            ter1.Name = "Ter1'";
            ter1.IPAddress = "10.0.0.103";

            Assert.AreEqual(true, _dtCtrl.UpdateTerminal(ter1));
            Assert.AreEqual(ter1.Name, _dtCtrl.GetTerminal(ter1.ID).Name);
            Assert.AreEqual(ter1.IPAddress, _dtCtrl.GetTerminal(ter1.ID).IPAddress);

            DeleteTerminal();
        }

        [Test]
        public void TestGetTerminal()
        {
            AddTerminal();

            Assert.AreEqual(ter1.ID, _dtCtrl.GetTerminal(ter1.ID).ID);

            Assert.AreEqual(null, _dtCtrl.GetTerminal(-1));

            DeleteTerminal();
        }

        [Test]
        public void TestDeleteTerminal()
        {
            AddTerminal();

            Assert.AreEqual(true, _dtCtrl.DeleteTerminal(ter1.ID));
            Assert.AreEqual(null, _dtCtrl.GetTerminal(ter1.ID));

            DeleteTerminal();
        }

        [Test]
        public void TestGetTerminalListByEmployee()
        {
            AddTerminal();

            Assert.AreEqual(true, _dtCtrl.GetTerminalListByEmployee(emp1.EmployeeNumber).Exists(delegate(Terminal _ter)
            {
                return _ter.ID == ter1.ID;
            }));

            DeleteTerminal();
        }

        [Test]
        public void TestIsDuplicateTerminal()
        {
            AddTerminal();

            Assert.AreEqual(true, _dtCtrl.IsDuplicateTerminal(ter1, false));
            Assert.AreEqual(false, _dtCtrl.IsDuplicateTerminal(ter1, true));

            DeleteTerminal();
        }
    }
}
