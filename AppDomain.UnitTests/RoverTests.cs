using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.UnitTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Run_NullArg_Throws()
        {
            var service = new Rover("rover1",new ConsoleInputService(),new ConsoleOutputService(),new Direction());
            service.Run(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithNullInputService_Throws()
        {
            var service = new Rover("rover1", new ConsoleInputService(), null, new Direction());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WithNullOutputService_Throws()
        {
            var service = new Rover("rover1", null, null, new Direction());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NameIsStringOrEmpty_Throws()
        {
            var service = new Rover("", null, null, new Direction());
        }
        [TestMethod]
        public void Run_WrongArgumentForGetStepCount_WrongStepCount()
        {
            var mock = NSubstitute.Substitute.For<ISpaceCar>();
            var drmock = Substitute.For<IDirection>();

            var service = new Rover("rover1", new ConsoleInputService(), new ConsoleOutputService(), drmock);
            service.Movement = "M";
            RoverCoordinates c = new RoverCoordinates() { XPoint = 0, YPoint = 0, Heading='V'};
            service.roverCoordinate = c;
            service.Run(new MapCoordinates() { X = 1, Y = 1 });
            drmock.DidNotReceive().GetStepCount(Arg.Is<char>(x => x == 'V'));
           

        }
    }
}
