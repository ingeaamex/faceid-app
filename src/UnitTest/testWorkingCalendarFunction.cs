using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    public class testWorkingCalendarFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private WorkingCalendar wCal = new WorkingCalendar();

        Company com = new Company();
        Department dep = new Department();
        Employee emp = new Employee();

        List<Break> breakList = new List<Break>();
        List<Holiday> holidayList = new List<Holiday>();

        PaymentRate workingDayPaymentRate = new PaymentRate();
        PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
        PaymentRate holidayPaymentRate = new PaymentRate();

        PayPeriod payPeriod = new PayPeriod();

        private void AddWCal()
        {
            wCal.Name = DateTime.Now.Ticks.ToString(); ;
            wCal.RegularWorkingFrom = DateTime.Today;
            wCal.RegularWorkingTo = DateTime.Today;
            
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = DateTime.Today;

            wCal.ID = _dtCtrl.AddWorkingCalendar(wCal, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

            com.Name = DateTime.Now.Ticks.ToString(); ;
            com.ID = _dtCtrl.AddCompany(com);
            
            dep.Name = DateTime.Now.Ticks.ToString(); ;
            dep.CompanyID = com.ID;
            dep.SupDepartmentID = 0;
            dep.ID = _dtCtrl.AddDepartment(dep);

            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = DateTime.Now.Ticks.ToString(); ;
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 1;
            emp.FirstName = DateTime.Now.Ticks.ToString(); ;
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.LastName = DateTime.Now.Ticks.ToString();
            emp.PhoneNumber = DateTime.Now.Ticks.ToString(); ;
            emp.WorkingCalendarID = wCal.ID;
            emp.PayrollNumber = _dtCtrl.AddEmployee(emp);
        }

        private void DelWCal()
        {
            _dtCtrl.DeleteWorkingCalendar(wCal.ID);
            _dtCtrl.DeleteEmployee(emp.PayrollNumber);
            _dtCtrl.DeleteDepartment(dep.ID);
            _dtCtrl.DeleteCompany(com.ID);
        }

        [Test]
        public void TestAddWorkingCalendar()
        {
            AddWCal();

            Assert.Greater(wCal.ID, 0);

            DelWCal();
        }

        [Test]
        public void TestGetWorkingCalendar()
        {
            AddWCal();

            Assert.AreEqual(wCal.Name, _dtCtrl.GetWorkingCalendar(wCal.ID).Name);

            DelWCal();
        }

        [Test]
        public void TestUpdateWorkingCalendar()
        {
            AddWCal();

            wCal.Name += "'";

            Assert.AreEqual(true, _dtCtrl.UpdateWorkingCalendar(wCal, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod));
            Assert.AreEqual(wCal.Name, _dtCtrl.GetWorkingCalendar(wCal.ID).Name);

            DelWCal();
        }

        [Test]
        public void TestGetWorkingCalendarList()
        {
            AddWCal();

            List<WorkingCalendar> wCalList = _dtCtrl.GetWorkingCalendarList();
            Assert.Greater(wCalList.Count, 0);

            DelWCal();
        }

        [Test]
        public void TestGetWorkingCalendarByEmployee()
        {
            AddWCal();

            Assert.AreEqual(wCal.ID, _dtCtrl.GetWorkingCalendarByEmployee(emp.EmployeeNumber).ID);

            DelWCal();
        }

        [Test]
        public void TestIsDuplicateWorkingCalendarName()
        {
            AddWCal();

            Assert.AreEqual(true, _dtCtrl.IsDuplicateWorkingCalendarName(wCal.Name));
            Assert.AreEqual(false, _dtCtrl.IsDuplicateWorkingCalendarName("Cal2"));

            Assert.AreEqual(false, _dtCtrl.IsDuplicateWorkingCalendarName(wCal.Name, wCal.ID));
            Assert.AreEqual(false, _dtCtrl.IsDuplicateWorkingCalendarName("Cal2", wCal.ID));

            DelWCal();
        }

        [Test]
        public void TestDeleteWorkingCalendar()
        {
            AddWCal();

            Assert.AreEqual(true, _dtCtrl.DeleteWorkingCalendar(wCal.ID));

            DelWCal();
        }
    }
}
