using Wator.Simulation.Organism;

namespace Wator.Simulation.Cell
{
    public class Organism : ICell
    {
        public OrganismKind OrganismKind { get; }

        public Organism(OrganismKind organismKind)
        {
            OrganismKind = organismKind;
        }
    }
}
