using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppDomain
{
    public class MapCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
    public class RoverCoordinates
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }
        public char Heading { get; set; }

    }
    public class ConsoleInputService : IInputService
    {
        public MapCoordinates mapCoordinate;
        public string ReadCommand()
        {
            return (Console.ReadLine());
        }

        public MapCoordinates SetMapCoordinates(string input)
        {

            var values = SplitInput(input);
            if (values.Count() != 2)
                throw new ArgumentException("Wrong Map Coordinates, has to be X and Y values");

            string inputString = values[0].ToString();
            int MapX;
            if (!Int32.TryParse(inputString, out MapX))
                throw new FormatException("Map coordinates should be numbers!");

            inputString = values[1].ToString();

            int MapY;
            if (!Int32.TryParse(inputString, out MapY))
                throw new FormatException("Map coordinates should be numbers!");

            if(MapX<0 || MapY<0)
                throw new FormatException("Arguments can be negative!");

            mapCoordinate = new MapCoordinates { X = MapX, Y = MapY };
            return mapCoordinate;
        }

        public RoverCoordinates SetRoverCoordinates(string input)
        {
            var uservalues = SplitInput(input);
            if (uservalues.Count() != 3)
                throw new ArgumentException("Missed arguments! has to take 3 arguments.");

            int x;
            if (!Int32.TryParse(uservalues[0].ToString(), out x))
                throw new FormatException("X axis should be number!");

            int y;
            if (!Int32.TryParse(uservalues[1].ToString(), out y))
                throw new FormatException("Y axis should be number!");

            int h;
            if (Int32.TryParse(uservalues[2].ToString(), out h))
                throw new FormatException("Head should be should be N,S,W or E!");

            if (x > mapCoordinate.X)
            {
                throw new FormatException("X input cant be bigger than Map coordinate!");
            }

            if (y > mapCoordinate.Y)
            {
                throw new FormatException("Y input cant be bigger than Map coordinate!");
            }

            if (x < 0)
            {
                throw new FormatException("X cant be negative!");
            }

            if (y < 0)
            {
                throw new FormatException("Y cant be negative!");
            }

            var head = char.Parse(uservalues[2].ToString());

            return new RoverCoordinates { XPoint = x, YPoint = y, Heading = head };
        }

        public string GetMovements(string input)
        {
            return SplitInput(input);
        }

        public string SplitInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException(input, "Wrong arguments!");
            var t = input.Where(x => char.IsLetter(x) || char.IsNumber(x)).Select(x=>char.ToUpper(x)).ToArray();
            return new String(t);
            //return Regex.Split(input, @"\s+")
            //            .Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.ToUpper());
        }


    }
}
