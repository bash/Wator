using System.Collections.Generic;
using Wator.Organism;
using Wator.Simulation.GridCell;

namespace Wator.Simulation
{
    public interface IGrid
    {
        /// <summary>
        /// The maximum width of this grid
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The maximum height of this grid
        /// </summary>
        int Height { get; }

        IEnumerable<IGridCell> GetNeighbours(Position position);

        IEnumerable<Occupied> GetOccupiedCells();

        void SetCell(Position position, IOrganism organism);

        void EmptyCell(Position position);
    }
}
