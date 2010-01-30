using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testEmployeeFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        private Employee emp = new Employee();

        private Company com = new Company();
        private Department dep = new Department();
        private WorkingCalendar wCal = new WorkingCalendar();
        private Terminal ter = new Terminal();

        private void AddEmployee()
        {
            //com.Name = DateTime.Now.Ticks.ToString();
            //com.ID = _dtCtrl.AddCompany(com);

            //dep.Name = DateTime.Now.Ticks.ToString();
            //dep.CompanyID = com.ID;
            //dep.SupDepartmentID = 0;
            //dep.ID = _dtCtrl.AddDepartment(dep);

            //wCal.Name = DateTime.Now.Ticks.ToString();
            //wCal.RegularWorkingFrom = DateTime.Today;
            //wCal.RegularWorkingTo = DateTime.Today;

            //List<Break> breakList = new List<Break>();
            //List<Holiday> holidayList = new List<Holiday>();

            //PaymentRate workingDayPaymentRate = new PaymentRate();
            //PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            //PaymentRate holidayPaymentRate = new PaymentRate();

            //PayPeriod payPeriod = new PayPeriod();
            //payPeriod.CustomPeriod = 5;
            //payPeriod.PayPeriodTypeID = 5; //custom
            //payPeriod.StartFrom = DateTime.Today;

            //wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

            dep = _dtCtrl.GetDepartmentList()[0];
            com = _dtCtrl.GetCompany(dep.CompanyID);
            wCal = _dtCtrl.GetWorkingCalendarList()[0];
            ter = _dtCtrl.GetTerminalList()[0];

            emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString();
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 0;
            emp.FirstName = DateTime.Now.Ticks.ToString();
            emp.JobDescription = DateTime.Now.Ticks.ToString();
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp.WorkingCalendarID = wCal.ID;
            emp.FaceData1 = "";
            emp.FaceData2 = "";
            emp.FaceData3 = "";
            emp.FaceData4 = "";
            emp.FaceData5 = "";
            emp.FaceData6 = "";
            emp.FaceData7 = "";
            emp.FaceData8 = "";
            emp.FaceData9 = "";
            emp.FaceData10 = "";
            emp.FaceData11 = "";
            emp.FaceData12 = "";
            emp.FaceData13 = "";
            emp.FaceData14 = "";
            emp.FaceData15 = "";
            emp.FaceData16 = "";
            emp.FaceData17 = "";
            emp.FaceData18 = "";

            emp.PayrollNumber = _dtCtrl.AddEmployee(emp, new List<Terminal>(){ter});
        }

        private void DeleteEmployee()
        {
            _dtCtrl.DeleteEmployee(emp.PayrollNumber);
            //_dtCtrl.DeleteWorkingCalendar(wCal.ID);
            //_dtCtrl.DeleteDepartment(dep.ID);
            //_dtCtrl.DeleteCompany(com.ID);
        }

        [Test]
        public void TestAddEmployee()
        {
            AddEmployee();

            Assert.Greater(emp.PayrollNumber, 0);
            Assert.AreEqual(true, _dtCtrl.GetEmployee(emp.PayrollNumber).Active);

            DeleteEmployee();
        }

        [Test]
        public void TestGetEmployee()
        {
            AddEmployee();

            Assert.AreEqual(emp.EmployeeNumber, _dtCtrl.GetEmployee(emp.PayrollNumber).EmployeeNumber);
            Assert.AreEqual(emp.FirstName, _dtCtrl.GetEmployee(emp.PayrollNumber).FirstName);

            DeleteEmployee();
        }

        [Test]
        public void TestGetEmployeeList()
        {
            AddEmployee();

            Assert.Greater(_dtCtrl.GetEmployeeList(com.ID, dep.ID).Count, 0);

            DeleteEmployee();
        }

        [Test]
        public void TestIsExistEmployeeNumber()
        {
            AddEmployee();

            Assert.AreEqual(true, _dtCtrl.IsExistEmployeeNumber(emp.EmployeeNumber));

            DeleteEmployee();
        }

        [Test]
        public void TestUpdateEmployee()
        {
            AddEmployee();

            emp.FirstName += "'";
            Assert.AreEqual(true, _dtCtrl.UpdateEmployee(emp));
            Assert.AreEqual(emp.FirstName, _dtCtrl.GetEmployee(emp.PayrollNumber).FirstName);

            DeleteEmployee();
        }

        [Test]
        public void TestDeleteEmployee()
        {
            AddEmployee();

            Assert.AreEqual(true, _dtCtrl.DeleteEmployee(emp.PayrollNumber));
            Assert.AreEqual(false, _dtCtrl.GetEmployee(emp.PayrollNumber).Active);

            DeleteEmployee();
        }

        [Test]
        public void TestIsNewEmployee()
        {
            AddEmployee();

            Assert.AreEqual(false, _dtCtrl.IsNewEmployee(emp));

            DeleteEmployee();
        }

        [Test]
        public void TestGetEmployeeListByTerminal()
        {
            AddEmployee();

            Assert.AreEqual(true, _dtCtrl.GetEmployeeListByTerminal(ter.ID).Exists(delegate(Employee _emp)
            {
                return _emp.PayrollNumber == emp.PayrollNumber;
            }));

            DeleteEmployee();
        }
    }
}
