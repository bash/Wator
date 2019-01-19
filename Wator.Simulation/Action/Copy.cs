namespace Wator.Simulation.Action
{
    public class Copy
    {
        public Copy(Position destination)
        {
            Destination = destination;
        }

        public Position Destination { get; }
    }
}
