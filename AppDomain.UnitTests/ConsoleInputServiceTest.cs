using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AppDomain.UnitTests
{
    [TestClass]
    public class ConsoleInputServiceTest
    {
        [TestMethod]
        public void SplitInput_CorrectInputs_WillbeSplited()
        {
            var service = new ConsoleInputService();
            var result = service.SplitInput("HELLO WORLD Hello").ToList();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitInput_EmptyInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SplitInput(string.Empty).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitInput_NullInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SplitInput(null).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetMapCoordinates_NullInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetMapCoordinates_EmptyInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetMapCoordinates_NotEqual2Inputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates("a b c");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetMapCoordinates_NotNumberInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates("A B");
        }

        [TestMethod]
        public void SetMapCoordinates_CorrectInputs_WontThrow()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates("5 5");
            Assert.AreEqual(result.X, 5);
            Assert.AreEqual(result.Y, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetMapCoordinates_NegativeNumberInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetMapCoordinates("-1 2");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetRoverCoordinates_NullInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetRoverCoordinates(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetRoverCoordinates_EmptyInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetRoverCoordinates(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetRoverCoordinates_NotEqual3Inputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetRoverCoordinates("a b");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetRoverCoordinates_NotNumberInputs_Throws()
        {
            var service = new ConsoleInputService();
            var result = service.SetRoverCoordinates("A B C");
        }

        [TestMethod]
        public void SetRoverCoordinates_CorrectInputs_WontThrow()
        {
            var service = new ConsoleInputService();
            service.mapCoordinate = new MapCoordinates();
            service.mapCoordinate.X = 5;
            service.mapCoordinate.Y = 5;

            var result = service.SetRoverCoordinates("4 4 N");
            Assert.AreEqual(result.XPoint, 4);
            Assert.AreEqual(result.YPoint, 4);
            Assert.AreEqual(result.Heading, 'N');
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetRoverCoordinates_OutOfMapInputs_Throw()
        {
            var service = new ConsoleInputService();
            service.mapCoordinate = new MapCoordinates();
            service.mapCoordinate.X = 0;
            service.mapCoordinate.Y = 0;

            var result = service.SetRoverCoordinates("4 4 N");
            Assert.AreEqual(result.XPoint, 4);
            Assert.AreEqual(result.YPoint, 4);
            Assert.AreEqual(result.Heading, 'N');
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetRoverCoordinates_WrongHeadArgument_Throw()
        {
            var service = new ConsoleInputService();
            var result = service.SetRoverCoordinates("5 5 2");
       
        }
    }
}
