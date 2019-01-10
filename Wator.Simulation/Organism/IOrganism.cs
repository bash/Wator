using System.Collections.Generic;
using Wator.Simulation.Action;

namespace Wator.Simulation.Organism
{
    public interface IOrganism
    {
        OrganismKind OrganismKind { get; }

        IEnumerable<IAction> Step();
    }
}
