using System.Collections.Generic;
using Wator.Simulation.Action;
using Wator.Simulation.OrganismEnvironment;

namespace Wator.Simulation.Organism.Reproduction
{
    public interface IReproducer
    {
        bool ShouldReproduce();

        IEnumerable<IAction> Reproduce(IReproducibleOrganism parent, OrganismKind ownKind,
            IOrganismEnvironment environment);
    }
}
