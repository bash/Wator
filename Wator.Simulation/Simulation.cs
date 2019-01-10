using System.Collections.Generic;
using Wator.Simulation.Organism;

namespace Wator.Simulation
{
    public class Simulation : ISimulation
    {
        public int Width { get; }

        public int Height { get; }

        public Simulation(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Step()
        {
            throw new System.NotImplementedException();
        }

        public void AddOrganism(Position position, IOrganism organism)
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
