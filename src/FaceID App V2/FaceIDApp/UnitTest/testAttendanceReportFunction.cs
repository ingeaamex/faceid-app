using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testAttendanceReportFunction
    {
        private IDataController _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;
        
        private AttendanceReport attReport = new AttendanceReport();
        private PayPeriod payPeriod = new PayPeriod();

        private int attRecordID = 1;

        private void AddAttReport()
        {
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5;
            payPeriod.StartFrom = DateTime.Now;
            payPeriod.ID = _dtCtrl.AddPayPeriod(payPeriod);

            attReport.AttendanceRecordIDList = "{1}";
            attReport.DayTypeID = 1;
            attReport.EmployeeNumber = _dtCtrl.GetEmployeeList()[0].EmployeeNumber;
            attReport.OvertimeHour1 = 2;
            attReport.OvertimeHour2 = 2;
            attReport.OvertimeHour3 = 2;
            attReport.OvertimeHour4 = 2;
            attReport.OvertimeRate1 = 200;
            attReport.OvertimeRate2 = 200;
            attReport.OvertimeRate3 = 200;
            attReport.OvertimeRate4 = 200;
            attReport.PayPeriodID = payPeriod.ID;
            attReport.RegularHour = 8;
            attReport.RegularRate = 100;
            attReport.WorkFrom = DateTime.Now.AddHours(-8);
            attReport.WorkTo = DateTime.Now;

            attReport.ID = _dtCtrl.AddAttendanceReport(attReport, true);
        }

        private void DelAttReport()
        {
            _dtCtrl.DeleteAttendanceReport(attReport.ID);
        }

        [Test]
        public void TestGetAttendanceReportList()
        {
            AddAttReport();

            Assert.AreEqual(true, _dtCtrl.GetAttendanceReportList().Exists(delegate(AttendanceReport _attReport)
            {
                return _attReport.ID == attReport.ID;
            }));

            DelAttReport();
        }

        [Test]
        public void TestGetAttendanceReportByAttendanceRecord()
        {
            AddAttReport();

            Assert.AreEqual(attReport.WorkFrom, _dtCtrl.GetAttendanceReportByAttendanceRecord(attRecordID).WorkFrom);

            DelAttReport();
        }

        [Test]
        public void TestDeleteAttendanceReport()
        {
            AddAttReport();

            Assert.AreEqual(true, _dtCtrl.DeleteAttendanceReport(attReport.ID));
            Assert.AreEqual(null, _dtCtrl.GetAttendanceReportByAttendanceRecord(attRecordID));

            DelAttReport();
        }

        [Test]
        public void TestDeleteAllAttendanceReport()
        {
            AddAttReport();

            Assert.AreEqual(true, _dtCtrl.DeleteAllAttendanceReport());
            Assert.AreEqual(0, _dtCtrl.GetAttendanceReportList().Count);

            DelAttReport();
        }

        [Test]
        public void TestAddAttendanceReport()
        {
            AddAttReport();

            Assert.AreEqual(true, attReport.ID > 0);

            DelAttReport();
        }

        [Test]
        public void TestUpdateAttendanceReport()
        {
            AddAttReport();

            attReport.RegularHour -= 1;
            Assert.AreEqual(true, _dtCtrl.UpdateAttendanceReport(attReport));
            Assert.AreEqual(attReport.RegularHour, _dtCtrl.GetAttendanceReportByAttendanceRecord(attRecordID).RegularHour);

            DelAttReport();
        }

    }
}
