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

        private void AddEmployee()
        {
            com.Name = DateTime.Now.Ticks.ToString();
            com.ID = _dtCtrl.AddCompany(com);

            dep.Name = DateTime.Now.Ticks.ToString();
            dep.CompanyID = com.ID;
            dep.SupDepartmentID = 0;
            dep.ID = _dtCtrl.AddDepartment(dep);

            wCal.Name = DateTime.Now.Ticks.ToString();
            wCal.RegularWorkingFrom = DateTime.Today;
            wCal.RegularWorkingTo = DateTime.Today;

            List<Break> breakList = new List<Break>();
            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            PaymentRate holidayPaymentRate = new PaymentRate();

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = DateTime.Today;

            wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

            Employee emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString();
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 1;
            emp.FirstName = DateTime.Now.Ticks.ToString();
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString();
            emp.PhotoData = DateTime.Now.Ticks.ToString();
            emp.WorkingCalendarID = wCal.ID;

            emp.PayrollNumber = _dtCtrl.AddEmployee(emp);
        }

        private void DeleteEmployee()
        {
            _dtCtrl.DeleteEmployee(emp.PayrollNumber);
            _dtCtrl.DeleteWorkingCalendar(wCal.ID);
            _dtCtrl.DeleteDepartment(dep.ID);
            _dtCtrl.DeleteCompany(com.ID);
        }

        [Test]
        public void TestAddEmployee()
        {
            AddEmployee();

            Assert.Greater(emp.PayrollNumber, 0);

            DeleteEmployee();
        }

        [Test]
        public void TestGetEmployee()
        {
        }

        [Test]
        public void TestGetEmployeeList()
        {
        }

        [Test]
        public void TestGetEmployeeListByDep()
        {
        }

        [Test]
        public void TestIsExistEmployeeNumber()
        {
        }

        [Test]
        public void TestUpdateEmployee()
        {
        }

        [Test]
        public void TestDeleteEmployee()
        {
        }
    }
}
