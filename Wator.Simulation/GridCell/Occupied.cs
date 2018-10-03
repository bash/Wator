using Wator.Organism;

namespace Wator.Simulation.GridCell
{
    public class Occupied : IGridCell
    {
        public Position Position { get; }

        public IOrganism Organism { get; }

        public Occupied(Position position, IOrganism organism)
        {
            Position = position;
            Organism = organism;
        }
    }
}
