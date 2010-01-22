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
        private WorkingCalendar wCal1 = new WorkingCalendar();

        [Test]
        public void TestAddWorkingCalendar()
        {
            wCal1.Name = "Cal1";
            wCal1.RegularWorkingFrom = DateTime.Today;
            wCal1.RegularWorkingTo = DateTime.Today;

            List<Break> breakList = new List<Break>();
            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            PaymentRate holidayPaymentRate = new PaymentRate();

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = DateTime.Today;

            wCal1.ID = _dtCtrl.AddWorkingCalendar(wCal1, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod);

            Assert.Greater(wCal1.ID, 0);
        }

        [Test]
        public void TestGetWorkingCalendar()
        {
            Assert.AreEqual(wCal1.Name, _dtCtrl.GetWorkingCalendar(wCal1.ID).Name);
        }

        [Test]
        public void TestUpdateWorkingCalendar()
        {
            wCal1.Name = "Cal1+";
            wCal1.RegularWorkingFrom = DateTime.Today;
            wCal1.RegularWorkingTo = DateTime.Today;

            List<Break> breakList = new List<Break>();
            List<Holiday> holidayList = new List<Holiday>();

            PaymentRate workingDayPaymentRate = new PaymentRate();
            PaymentRate nonWorkingDayPaymentRate = new PaymentRate();
            PaymentRate holidayPaymentRate = new PaymentRate();

            PayPeriod payPeriod = new PayPeriod();
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = DateTime.Today;

            Assert.AreEqual(true, _dtCtrl.UpdateWorkingCalendar(wCal1, breakList, holidayList, workingDayPaymentRate, nonWorkingDayPaymentRate, holidayPaymentRate, payPeriod));
            Assert.AreEqual(wCal1.Name, _dtCtrl.GetWorkingCalendar(wCal1.ID).Name);
        }

        [Test]
        public void TestGetWorkingCalendarList()
        {
            List<WorkingCalendar> wCalList = _dtCtrl.GetWorkingCalendarList();
            Assert.Greater(wCalList.Count, 0);
        }

        [Test]
        public void TestGetWorkingCalendarByEmployee()
        {
            Company com = new Company();
            com.Name = "Com1";
            com.ID = _dtCtrl.AddCompany(com);

            Department dep = new Department();
            dep.Name = "Dep1";
            dep.CompanyID = com.ID;
            dep.SupDepartmentID = 0;
            dep.ID = _dtCtrl.AddDepartment(dep);

            Employee emp = new Employee();
            emp.Active = true;
            emp.ActiveFrom = DateTime.Today;
            emp.ActiveTo = DateTime.Today.AddDays(1);
            emp.Address = "";
            emp.Birthday = DateTime.Today.AddYears(-20);
            emp.DepartmentID = dep.ID;
            emp.EmployeeNumber = 1;
            emp.FirstName = "F";
            emp.HiredDate = DateTime.Today;
            emp.LeftDate = DateTime.Today.AddYears(1);
            emp.PhoneNumber = "";
            emp.PhotoData = "";
            emp.WorkingCalendarID = wCal1.ID;
            emp.PayrollNumber = _dtCtrl.AddEmployee(emp);

            Assert.AreEqual(wCal1.ID, _dtCtrl.GetWorkingCalendarByEmployee(emp.EmployeeNumber).ID);

            _dtCtrl.DeleteEmployee(emp.PayrollNumber);
            _dtCtrl.DeleteDepartment(dep.ID);
            _dtCtrl.DeleteCompany(com.ID);
        }

        [Test]
        public void TestIsDuplicatedWorkingCalendarName()
        {
            Assert.AreEqual(true, _dtCtrl.IsDuplicatedWorkingCalendarName(wCal1.Name));
            Assert.AreEqual(false, _dtCtrl.IsDuplicatedWorkingCalendarName("Cal2"));

            Assert.AreEqual(false, _dtCtrl.IsDuplicatedWorkingCalendarName(wCal1.Name, wCal1.ID));
            Assert.AreEqual(false, _dtCtrl.IsDuplicatedWorkingCalendarName("Cal2", wCal1.ID));
        }

        [Test]
        public void TestDeleteWorkingCalendar()
        {
            Assert.AreEqual(true, _dtCtrl.DeleteWorkingCalendar(wCal1.ID));
        }
    }
}
