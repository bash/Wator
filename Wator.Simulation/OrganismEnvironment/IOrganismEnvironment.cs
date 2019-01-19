using System.Collections.Generic;

namespace Wator.Simulation.OrganismEnvironment
{
    public interface IOrganismEnvironment
    {
        IEnumerable<Position> GetFreeNeighbours();

        IEnumerable<(Position, OrganismKind)> GetOccupiedNeighbours();
    }
}
