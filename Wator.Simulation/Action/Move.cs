namespace Wator.Simulation.Action
{
    public class Move : IAction
    {
        public Position Destination { get; }

        public Move(Position destination)
        {
            Destination = destination;
        }
    }
}
