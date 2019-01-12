using System;
using Wator.Simulation.Organism;

namespace Wator.Simulation.Grid
{
    public class GridCell
    {
        public GridCell(OrganismKind organismKind, IOrganism organism)
        {
            OrganismKind = organismKind;
            Organism = organism;
        }

        public OrganismKind OrganismKind { get; }

        public IOrganism Organism { get; }
    }
}
