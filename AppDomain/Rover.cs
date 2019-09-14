using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain
{
    public class Rover : ISpaceCar
    {
        public RoverCoordinates roverCoordinate { get; set; }
        public string Movement { get; set; }
        private string Name { get; set; }

        private IInputService inputService;
        private IOutputService outputService;
        private IDirection direction;
        public Rover(string name, IInputService inputService, IOutputService outputService,IDirection direction)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Set Rover name!");
            Name = name;
            this.inputService = inputService ?? throw new ArgumentNullException();
            this.outputService = outputService ?? throw new ArgumentNullException();
            this.direction = direction;
        }
        public void SetStartingPosition()
        {
            outputService.WriteMessage(Name + " Starting Position:");
            var inputs = inputService.ReadCommand();
            roverCoordinate= inputService.SetRoverCoordinates(inputs);
        }

        public void GetMovementPlan()
        {
            outputService.WriteMessage(Name + " Movement Plan:");
            var inputs = inputService.ReadCommand();
            Movement = inputService.GetMovements(inputs); 
        }

        public void Run(MapCoordinates mapCoordinate)
        {
            if (mapCoordinate == null)
                throw new ArgumentNullException();

            foreach (var move in this.Movement)
            {
                if ((roverCoordinate.XPoint < mapCoordinate.X || roverCoordinate.YPoint < mapCoordinate.Y) 
                    && roverCoordinate.XPoint >= 0 || roverCoordinate.YPoint >= 0)
                {
                    if (move == 'M')
                    {
                        if (roverCoordinate.Heading == 'N' || roverCoordinate.Heading == 'E' || roverCoordinate.Heading == 'W' || roverCoordinate.Heading == 'S')
                        {
                            var stepcount = direction.GetStepCount(roverCoordinate.Heading);
                            if (direction.GetAxis(roverCoordinate.Heading) == 'Y')
                                roverCoordinate.YPoint = roverCoordinate.YPoint + stepcount;
                            else if (direction.GetAxis(roverCoordinate.Heading) == 'X')
                                roverCoordinate.XPoint = roverCoordinate.XPoint + stepcount;
                        }
                    }
                }

                roverCoordinate.Heading = direction.GetDirection(roverCoordinate.Heading.ToString() + move.ToString());
            }
        }
        public void WriteRoverPosition()
        {
            outputService.PrintOutput($"{Name} Output: {roverCoordinate.XPoint} {roverCoordinate.YPoint} {roverCoordinate.Heading}");
        }
    }
}
