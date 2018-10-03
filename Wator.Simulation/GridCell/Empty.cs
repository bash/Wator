namespace Wator.Simulation.GridCell
{
    public class Empty : IGridCell
    {
        public Position Position { get; }

        public Empty(Position position)
        {
            Position = position;
        }
    }
}
