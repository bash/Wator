namespace Wator.Simulation.Action
{
    [Equals]
    public class Move : IAction
    {
        public Move(Position destination)
        {
            Destination = destination;
        }

        public Position Destination { get; }
    }
}
