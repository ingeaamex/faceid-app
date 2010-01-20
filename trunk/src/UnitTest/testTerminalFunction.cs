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
        private Terminal ter2 = new Terminal();

        [Test]
        public void TestAddTerminal()
        {
            ter1.Name = "Ter1";
            ter1.IPAddress = "10.0.0.101";
            ter1.ID = _dtCtrl.AddTerminal(ter1);

            Assert.Greater(ter1.ID, 0);

            //add again
            Assert.Less(_dtCtrl.AddTerminal(ter1), 0);

            //add null
            Assert.Less(_dtCtrl.AddTerminal(null), 0);

            //add empty name
            ter2.Name = "";
            ter2.IPAddress = "10.0.0.102";
            Assert.Less(_dtCtrl.AddTerminal(ter2), 0);

            //add duplicate name
            ter2.Name = "Ter1";
            ter2.IPAddress = "10.0.0.102";
            Assert.Less(_dtCtrl.AddTerminal(ter2), 0);

            //empty ip add
            ter2.Name = "Ter2";
            ter2.IPAddress = "";
            Assert.Less(_dtCtrl.AddTerminal(ter2), 0);

            //duplicate ip add
            ter2.Name = "Ter2";
            ter2.IPAddress = "10.0.0.101";
            Assert.Less(_dtCtrl.AddTerminal(ter2), 0);

            //invalid
            ter2.Name = "Ter2";
            ter2.IPAddress = "10.0.0.999";
            Assert.Less(_dtCtrl.AddTerminal(ter2), 0);
        }

        [Test]
        public void TestGetTerminalList()
        {
            Assert.Greater(_dtCtrl.GetTerminalList().Count, 0);
        }

        [Test]
        public void TestUpdateTerminal()
        {
            Assert.AreEqual(true, _dtCtrl.UpdateTerminal(ter1));

            ter1.Name = "Ter1'";
            ter1.IPAddress = "10.0.0.103";

            Assert.AreEqual(true, _dtCtrl.UpdateTerminal(ter1));
            Assert.AreEqual(ter1.Name, _dtCtrl.GetTerminal(ter1.ID).Name);
            Assert.AreEqual(ter1.IPAddress, _dtCtrl.GetTerminal(ter1.ID).IPAddress);

            //update null
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(null));

            //update non exist terminal
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(ter2));

            //update duplicate name
            ter2.Name = "Ter2";
            ter2.IPAddress = "10.0.0.102";
            ter2.ID = _dtCtrl.AddTerminal(ter2);
            
            ter2.Name = ter1.Name;
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(ter2));

            //empy name
            ter2.Name = "";
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(ter2));

            //update null ip add
            ter2.Name = "Ter2";
            ter2.IPAddress = null;
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(ter2));

            //update invalid ip add
            ter2.Name = "10.0.0.999";
            Assert.AreEqual(false, _dtCtrl.UpdateTerminal(ter2));
        }

        [Test]
        public void TestGetTerminal()
        {
            Assert.AreEqual(ter1.ID, _dtCtrl.GetTerminal(ter1.ID).ID);

            Assert.AreEqual(null, _dtCtrl.GetTerminal(-1));
        }

        [Test]
        public void TestDeleteTerminal()
        {
            Assert.AreEqual(true, _dtCtrl.DeleteTerminal(ter1.ID));
            Assert.AreEqual(true, _dtCtrl.DeleteTerminal(ter2.ID));

            Assert.AreEqual(null, _dtCtrl.GetTerminal(ter1.ID));

            //delete again
            Assert.AreEqual(false, _dtCtrl.DeleteTerminal(ter1.ID));
            Assert.AreEqual(false, _dtCtrl.DeleteTerminal(-1));

            //TODO
        }
    }
}
