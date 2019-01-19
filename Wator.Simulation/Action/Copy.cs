namespace Wator.Simulation.Action
{
    public class Copy
    {
        public Position Destination { get; }

        public Copy(Position destination)
        {
            Destination = destination;
        }
    }
}
