using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    public class testPayPeriodFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        
        private PayPeriod payPeriod = new PayPeriod();

        private WorkingCalendar wCal = null;
        private int originalPayPeriodID;

        private void AddPayPeriod()
        {
            payPeriod.CustomPeriod = 5;
            payPeriod.PayPeriodTypeID = 5; //custom
            payPeriod.StartFrom = DateTime.Today;

            payPeriod.ID = _dtCtrl.AddPayPeriod(payPeriod);

            wCal = _dtCtrl.GetWorkingCalendarList()[0];
            originalPayPeriodID = wCal.PayPeriodID;
            wCal.PayPeriodID = payPeriod.ID;
            _dtCtrl.UpdateWorkingCalendar(wCal);
        }

        private void DelPeriod()
        {
            wCal.PayPeriodID = originalPayPeriodID;
            _dtCtrl.UpdateWorkingCalendar(wCal);

            _dtCtrl.DeletePayPeriod(payPeriod.ID);
        }

        [Test]
        public void TestAddPayPeriod()
        {
            AddPayPeriod();

            Assert.Greater(payPeriod.ID, 0);

            DelPeriod();
        }

        [Test]
        public void TestGetPayPeriod()
        {
            AddPayPeriod();

            Assert.AreEqual(payPeriod.ID, _dtCtrl.GetPayPeriod(payPeriod.ID).ID);

            DelPeriod();
        }

        [Test]
        public void TestGetPayPeriodByWorkingCalendar()
        {
            AddPayPeriod();

            Assert.AreEqual(payPeriod.ID, _dtCtrl.GetPayPeriod(payPeriod.ID).ID);

            DelPeriod();
        }

        [Test]
        public void TestDeletePayPeriod()
        {
            AddPayPeriod();

            wCal.PayPeriodID = originalPayPeriodID;
            _dtCtrl.UpdateWorkingCalendar(wCal);
            Assert.AreEqual(true, _dtCtrl.DeletePayPeriod(payPeriod.ID));

            DelPeriod();
        }
    }
}
