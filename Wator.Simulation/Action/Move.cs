using Wator.Simulation.Cell;

namespace Wator.Organism
{
    internal class Move : IAction
    {
        public ICell Destination { get; }

        public Move(ICell destination)
        {
            Destination = destination;
        }
    }
}
