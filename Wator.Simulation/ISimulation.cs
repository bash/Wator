using System.Collections.Generic;
using Wator.Simulation.Organism;

namespace Wator.Simulation
{
    public interface ISimulation
    {
        /// <summary>
        /// The maximum width of this simulation
        /// </summary>
        int Width { get; }
        
        /// <summary>
        /// The maximum height of this simulation
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Advances the simulation by one step
        /// </summary>
        void Step();

        void AddOrganism(Position position, IOrganism organism, OrganismKind kind);

        void RemoveOrganism(Position position);

        IEnumerable<(Position, IOrganism)> GetOrganisms();
    }
}
