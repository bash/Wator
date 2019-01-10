using Wator.Simulation.Cell;

namespace Wator.Simulation.Action
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
