using System.Collections.Generic;

namespace Wator.Organism
{
    public interface IOrganism
    {
        OrganismKind OrganismKind { get; }

        IEnumerable<IAction> Step();
    }
}
