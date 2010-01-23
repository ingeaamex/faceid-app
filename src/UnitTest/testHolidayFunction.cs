using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testHolidayFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        private Holiday holiday = new Holiday();

        private void AddHoliday()
        {
            holiday.Date = DateTime.Today;
            holiday.Description = "";
            holiday.WorkingCalendarID = _dtCtrl.GetWorkingCalendarList()[0].ID;

            holiday.ID = _dtCtrl.AddHoliday(holiday);
        }

        private void DelHoliday()
        {
            _dtCtrl.DeleteHoliday(holiday.ID);
        }

        [Test]
        public void TestAddHoliday()
        {
            AddHoliday();

            Assert.Greater(holiday.ID, 0);

            DelHoliday();
        }

        [Test]
        public void TestGetHolidayListByWorkingCalendar()
        {
            AddHoliday();

            Assert.Greater(_dtCtrl.GetHolidayListByWorkingCalendar(holiday.WorkingCalendarID).Count, 0);

            DelHoliday();
        }

        [Test]
        public void TestDeleteHoliday()
        {
            AddHoliday();

            Assert.AreEqual(true, _dtCtrl.DeleteHoliday(holiday.ID));

            DelHoliday();
        }
    }
}
