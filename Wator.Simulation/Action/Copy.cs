using Wator.Simulation.Organism;

namespace Wator.Simulation.Action
{
    public class Copy
    {
        public Copy(Position destination, IOrganism organism, OrganismKind organismKind)
        {
            Destination = destination;
            Organism = organism;
            OrganismKind = organismKind;
        }

        public Position Destination { get; }

        public IOrganism Organism { get; }

        public OrganismKind OrganismKind { get; }
    }
}
