using System.Collections.Generic;

namespace Wator.Simulation.OrganismEnvironment
{
    public interface IOrganismEnvironment
    {
        Position Position { get; }

        IEnumerable<Position> GetFreeNeighbours();

        IEnumerable<(Position, OrganismKind)> GetOccupiedNeighbours();
    }
}
