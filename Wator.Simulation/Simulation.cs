using System.Collections.Generic;
using Wator.Simulation.Grid;
using Wator.Simulation.Organism;

namespace Wator.Simulation
{
    public class Simulation : ISimulation
    {
        public Simulation(IGrid grid)
        {
            Grid = grid;
        }

        private IGrid Grid { get; }

        public int Width => Grid.Width;

        public int Height => Grid.Height;

        public void Step()
        {
            throw new System.NotImplementedException();
        }

        public void AddOrganism(Position position, IOrganism organism, OrganismKind kind)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOrganism(Position position)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<(Position, IOrganism)> GetOrganisms()
        {
            throw new System.NotImplementedException();
        }
    }
}
