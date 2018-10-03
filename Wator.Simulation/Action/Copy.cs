using Wator.Simulation.Cell;

namespace Wator.Organism
{
    internal class Copy
    {
        public ICell Destination { get; }

        public Copy(ICell destination)
        {
            Destination = destination;
        }
    }
}
