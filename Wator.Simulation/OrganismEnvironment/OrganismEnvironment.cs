using System.Collections.Generic;

namespace Wator.Simulation.OrganismEnvironment
{
    public class OrganismEnvironment : IOrganismEnvironment
    {
        public IEnumerable<Position> GetFreeNeighbours()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<(Position, OrganismKind)> GetOccupiedNeighbours()
        {
            throw new System.NotImplementedException();
        }
    }
}
