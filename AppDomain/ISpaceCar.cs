namespace AppDomain
{
    public interface ISpaceCar
    {
        void GetMovementPlan();
        void Run(MapCoordinates mapCoordinate);
        void SetStartingPosition();
        void WriteRoverPosition();
    }
}