using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Wator.Organism;
using Wator.Simulation.GridCell;

namespace Wator.Simulation
{
    /// <summary>
    /// A grid with its ends connected.
    /// </summary>
    public class TorusGrid : IGrid
    {
        public int Width { get; }

        public int Height { get; }

        private readonly Dictionary<Position, IOrganism> occupiedCells = new Dictionary<Position, IOrganism>();

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

        public IEnumerable<IGridCell> GetNeighbours(Position position)
        {
            throw new NotImplementedException();
        }

        [Pure]
        public IEnumerable<Occupied> GetOccupiedCells()
        {
            return occupiedCells.Select(pair => new Occupied(pair.Key, pair.Value));
        }

        public void SetCell(Position position, IOrganism organism)
        {
            if (position.X >= Width || position.Y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "position must be inside grid");
            }

            occupiedCells.Add(position, organism);
        }

        public void EmptyCell(Position position)
        {
            occupiedCells.Remove(position);
        }
    }
}
