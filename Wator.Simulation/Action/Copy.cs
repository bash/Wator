using Wator.Simulation.Organism;

namespace Wator.Simulation.Action
{
    [Equals]
    public class Copy : IAction
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
