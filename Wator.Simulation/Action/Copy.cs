namespace Wator.Simulation.Action
{
    internal class Copy
    {
        public Position Destination { get; }

        public Copy(Position destination)
        {
            Destination = destination;
        }
    }
}
