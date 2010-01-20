using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.UnitTest
{
    [TestFixture]
    class testEmployeeFunction
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        private Employee emp1 = new Employee();
        private Employee emp2 = new Employee();

        [Test]
        public void TestAddEmployee()
        {
        }

        [Test]
        public void TestGetEmployee()
        {
        }

        [Test]
        public void TestGetEmployeeList()
        {
        }

        [Test]
        public void TestGetEmployeeListByDep()
        {
        }

        [Test]
        public void TestIsExistEmployeeNumber()
        {
        }

        [Test]
        public void TestUpdateEmployee()
        {
        }

        [Test]
        public void TestDeleteEmployee()
        {
        }
    }
}
