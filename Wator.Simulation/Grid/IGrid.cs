using System.Collections.Generic;

namespace Wator.Simulation.Grid
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

        IEnumerable<(Position, GridCell?)> GetNeighbours(Position position);

        IEnumerable<(Position, GridCell)> GetOccupiedCells();

        void SetCell(Position position, GridCell grid);

        void EmptyCell(Position position);

        void MoveCell(Position currentPosition, Position newPosition);
    }
}
