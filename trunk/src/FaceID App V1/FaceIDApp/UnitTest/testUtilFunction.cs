using System;
using System.Collections.Generic;
using System.Text;
using FaceIDAppVBEta.Data;
using NUnit.Framework;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testUtilFunction
    {
        [Test]
        public void TestRoundDateTime()
        {
            DateTime value = new DateTime(2222, 2, 2, 7, 03, 30);
            DateTime expected = new DateTime(2222, 2, 2, 7, 05, 00);
            DateTime actual = Util.RoundDateTime(value, 5);

            Assert.AreEqual(expected, actual);

            value = new DateTime(2222, 2, 2, 7, 02, 00);
            expected = new DateTime(2222, 2, 2, 7, 00, 00);
            actual = Util.RoundDateTime(value, 5);

            Assert.AreEqual(expected, actual);

            value = new DateTime(2222, 2, 2, 7, 02, 30);
            expected = new DateTime(2222, 2, 2, 7, 02, 00);
            actual = Util.RoundDateTime(value, 1);

            Assert.AreEqual(expected, actual);

            value = new DateTime(2222, 2, 2, 7, 02, 31);
            expected = new DateTime(2222, 2, 2, 7, 03, 00);
            actual = Util.RoundDateTime(value, 1);

            Assert.AreEqual(expected, actual);

            value = new DateTime(2222, 2, 2, 7, 02, 30);
            expected = new DateTime(2222, 2, 2, 7, 00, 00);
            actual = Util.RoundDateTime(value, 30);

            Assert.AreEqual(expected, actual);

            value = new DateTime(2222, 2, 2, 7, 15, 30);
            expected = new DateTime(2222, 2, 2, 7, 30, 00);
            actual = Util.RoundDateTime(value, 30);

            Assert.AreEqual(expected, actual);
        }
    }
}