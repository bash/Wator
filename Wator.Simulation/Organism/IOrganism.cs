using Wator.Simulation.Action;
using Wator.Simulation.OrganismEnvironment;

namespace Wator.Simulation.Organism
{
    public interface IOrganism
    {
        IAction Step(OrganismKind ownKind, IOrganismEnvironment environment);
    }
}
