using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppDomain
{
    public class Mars
    {
        private MapCoordinates mapCoordinate { get; set; }
        public List<ISpaceCar> Rovers { get; private set; }
        private IInputService inputService;
        private IOutputService outputService;
        private IDirection direction;
        public Mars(IInputService inputService, IOutputService outputService,IDirection direction)
        {
            this.inputService = inputService;
            this.outputService = outputService;
            this.direction = direction;
        }

        public void CreateMap()
        {

            bool failed = true;
            while (failed)
                try
                {
                    outputService.WriteMessage("Enter Graph Upper Right Coordinate:");
                    var input = inputService.ReadCommand();
                    mapCoordinate = inputService.SetMapCoordinates(input);
                    failed = false;
                }
                catch (Exception m)
                {
                    failed = true;
                    outputService.PrintOutput(m.Message);
                }

        }
        public void GenerateRovers()
        {
            Rovers = new List<ISpaceCar>();
            Rovers.Add(new Rover("Rover 1", this.inputService, this.outputService,direction));
            Rovers.Add(new Rover("Rover 2", this.inputService, this.outputService,direction));
        }

        public void RunRovers()
        {
            foreach (var rover in Rovers)
            {
                bool failed = true;
                while (failed)
                    try
                    {
                        rover.SetStartingPosition();
                        rover.GetMovementPlan();
                        rover.Run(mapCoordinate);
                        rover.WriteRoverPosition();
                        failed = false;
                    }
                    catch (Exception m)
                    {
                        failed = true;
                        outputService.PrintOutput(m.Message);
                    }
            }

            outputService.WriteMessage("Done!");
        }
    }



}
