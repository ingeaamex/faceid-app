using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testAttendanceRecordFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private AttendanceRecord attRecord = new AttendanceRecord();
        private Employee emp = new Employee();

        private void AddAttRecord()
        {
            emp = _dtCtrl.GetEmployeeList()[0];
            
            attRecord.EmployeeNumber = emp.EmployeeNumber;
            attRecord.Note = "";
            attRecord.PhotoData = "";
            attRecord.Time = DateTime.Now;

            attRecord.ID = _dtCtrl.AddAttendanceRecord(attRecord);
        }

        private void DelAttRecord()
        {
            _dtCtrl.DeleteAttendanceRecord(attRecord.ID);
        }

        [Test]
        public void TestGetAttendanceRecordList()
        {
            AddAttRecord();

            Assert.AreEqual(true, _dtCtrl.GetAttendanceRecordList().Count > 0);
            Assert.AreEqual(true, _dtCtrl.GetAttendanceRecordList().Exists(delegate(AttendanceRecord _attRecord)
            {
                return _attRecord.ID == attRecord.ID;
            }));

            DelAttRecord();
        }

        [Test]
        public void TestGetAttendanceRecord()
        {
            AddAttRecord();

            Assert.AreEqual(attRecord.ID, _dtCtrl.GetAttendanceRecord(attRecord.ID).ID);

            DelAttRecord();
        }

        [Test]
        public void TestAddAttendanceRecord()
        {
            AddAttRecord();

            Assert.AreEqual(true, attRecord.ID > 0);

            DelAttRecord();
        }

        [Test]
        public void TestDeleteAttendanceRecord()
        {
            AddAttRecord();

            Assert.AreEqual(true, _dtCtrl.DeleteAttendanceRecord(attRecord.ID));
            Assert.AreEqual(null, _dtCtrl.GetAttendanceRecord(attRecord.ID));

            DelAttRecord();
        }

        [Test]
        public void TestUpdateAttendanceRecord()
        {
            AddAttRecord();

            attRecord.Note += "'";
            Assert.AreEqual(true, _dtCtrl.UpdateAttendanceRecord(attRecord));

            DelAttRecord();
        }

        [Test]
        public void TestDeleteAllAttendanceRecord()
        {
            AddAttRecord();

            Assert.AreEqual(true, _dtCtrl.DeleteAllAttendanceRecord());
            Assert.AreEqual(0, _dtCtrl.GetAttendanceRecordList().Count);

            DelAttRecord();
        }
    }
}
