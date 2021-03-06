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

        IEnumerable<(Position, GridCell)> GetOccupiedNeighbours(Position position);

        IEnumerable<Position> GetFreeNeighbours(Position position);

        IEnumerable<(Position, GridCell)> GetOccupiedCells();

        void SetCell(Position position, GridCell grid);

        void EmptyCell(Position position);

        void MoveCell(Position currentPosition, Position newPosition);

        GridCell GetCell(Position position);

        bool IsCellOccupied(Position position);
    }
}
