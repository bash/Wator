using System.Collections.Generic;
using Wator.Organism;

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

        public void SetCell(Position position, OrganismKind organismKind)
        {
            throw new System.NotImplementedException();
        }

        public void EmptyCell(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}
