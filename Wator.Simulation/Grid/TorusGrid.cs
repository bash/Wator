using System;
using System.Collections.Generic;
using System.Linq;
using Wator.Simulation.Grid;

namespace Wator.Simulation
{
    /// <summary>
    /// A grid with its ends connected.
    /// </summary>
    public class TorusGrid : IGrid
    {
        public int Width { get; }

        public int Height { get; }

        private readonly Dictionary<Position, GridCell> occupiedCells = new Dictionary<Position, GridCell>();

        public TorusGrid(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "width must be greater than zero");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "height must be greater than zero");
            }

            Width = width;
            Height = height;
        }

        public IEnumerable<(Position, GridCell)> GetOccupiedCells()
        {
            return occupiedCells.Select(pair => (pair.Key, pair.Value));
        }

        public IEnumerable<(Position, GridCell?)> GetNeighbours(Position position)
        {
            throw new NotImplementedException();
        }

        public void SetCell(Position position, GridCell gridCell)
        {
            if (position.X >= Width || position.Y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "position must be inside grid");
            }

            occupiedCells.Add(position, gridCell);
        }

        public void EmptyCell(Position position) => occupiedCells.Remove(position);

        public void MoveCell(Position currentPosition, Position newPosition)
        {
            throw new NotImplementedException();
        }

        public GridCell? GetCell(Position position) => occupiedCells[position];
    }
}
