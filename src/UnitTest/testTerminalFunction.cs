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

        private void AddTerminal()
        {
            ter1.Name = DateTime.Now.Ticks.ToString();
            ter1.IPAddress = "10.0.0.101";
            ter1.ID = _dtCtrl.AddTerminal(ter1);
        }

        private void DeleteTerminal()
        {
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
    }
}
