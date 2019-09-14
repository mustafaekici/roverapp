using System.Collections.Generic;

namespace AppDomain
{
    public interface IInputService
    {
        string GetMovements(string inputs);
        RoverCoordinates SetRoverCoordinates(string inputs);
        string ReadCommand();
        MapCoordinates SetMapCoordinates(string inputs);
        string SplitInput(string inputs);
    }
}