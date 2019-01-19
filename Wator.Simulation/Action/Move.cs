namespace Wator.Simulation.Action
{
    public class Move : IAction
    {
        public Move(Position destination)
        {
            Destination = destination;
        }

        public Position Destination { get; }
    }
}
