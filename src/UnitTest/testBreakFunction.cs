using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;
using NUnit.Framework;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testBreakFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;
        
        private Break break1 = new Break();
        
        private void AddBreak()
        {
            break1.From = DateTime.Now;
            break1.To = DateTime.Now.AddHours(1);
            break1.Name = DateTime.Now.Ticks.ToString();
            break1.Paid = false;
            break1.WorkingCalendarID = _dtCtrl.GetWorkingCalendarList()[0].ID;

            break1.ID = _dtCtrl.AddBreak(break1);
        }

        private void DelBreak()
        {
            _dtCtrl.DeleteBreak(break1.ID);
        }

        [Test]
        public void TestAddBreak()
        {
            AddBreak();

            Assert.Greater(break1.ID, 0);

            DelBreak();
        }

        [Test]
        public void TestGetBreak()
        {
            AddBreak();

            Assert.AreEqual(break1.ID, _dtCtrl.GetBreak(break1.ID).ID);
            Assert.AreEqual(break1.Name, _dtCtrl.GetBreak(break1.ID).Name);

            DelBreak();
        }

        [Test]
        public void TestUpdateBreak()
        {
            AddBreak();

            break1.Name += "'";
            Assert.AreEqual(true, _dtCtrl.UpdateBreak(break1));
            Assert.AreEqual(break1.Name, _dtCtrl.GetBreak(break1.ID).Name);

            DelBreak();
        }

        [Test]
        public void TestDeleteBreak()
        {
            AddBreak();

            Assert.AreEqual(true, _dtCtrl.DeleteBreak(break1.ID));

            DelBreak();
        }

        [Test]
        public void TestGetBreakListByWorkingCalendar()
        {
            AddBreak();

            Assert.AreEqual(true, _dtCtrl.GetBreakListByWorkingCalendar(break1.WorkingCalendarID).Exists(delegate(Break _break)
                {
                    return _break.ID == break1.ID;
                })
                );

            DelBreak();
        }
    }
}
