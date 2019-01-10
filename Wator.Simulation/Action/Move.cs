namespace Wator.Simulation.Action
{
    internal class Move : IAction
    {
        public Position Destination { get; }

        public Move(Position destination)
        {
            Destination = destination;
        }
    }
}
