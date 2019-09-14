using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.UnitTests
{
    [TestClass]
    public class DirectionTests
    {
        Direction direction = new Direction();
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetDirection_InputNotInList_Throws()
        {
           
            var result = direction.GetDirection("xx");
            Assert.AreEqual(result, 'E');
        }

        [TestMethod]
        public void GetDirection_InputInList_GetHead()
        {
            var result = direction.GetDirection("NR");
            Assert.AreEqual(result, 'E');
        }

        [TestMethod]
        public void GetStepCount_NDirection_MoveForward()
        {
            var result = direction.GetStepCount('N');
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void GetStepCount_EDirection_MoveForward()
        {
            var result = direction.GetStepCount('E');
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void GetStepCount_WDirection_MoveBack()
        {
            var result = direction.GetStepCount('W');
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void GetStepCount_SDirection_MoveBack()
        {
            var result = direction.GetStepCount('S');
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void GetAxis_NDirection_MoveOnYCoordinate()
        {
            var result = direction.GetAxis('N');
            Assert.AreEqual(result, 'Y');
        }

        [TestMethod]
        public void GetAxis_SDirection_MoveOnYCoordinate()
        {
            var result = direction.GetAxis('S');
            Assert.AreEqual(result, 'Y');
        }

        [TestMethod]
        public void GetAxis_WDirection_MoveOnXCoordinate()
        {
            var result = direction.GetAxis('W');
            Assert.AreEqual(result, 'X');
        }

        [TestMethod]
        public void GetAxis_EDirection_MoveOnXCoordinate()
        {
            var result = direction.GetAxis('E');
            Assert.AreEqual(result, 'X');
        }
    }
}
