using Wator.Simulation.Cell;

namespace Wator.Simulation.Action
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
