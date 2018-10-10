using System;
using System.Collections;
using System.Collections.Generic;
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

        private Dictionary<Position, IOrganism> occupiedCells = new Dictionary<Position, IOrganism>();

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

        public IEnumerable<Occupied> GetOccupiedCells()
        {
            throw new NotImplementedException();
        }

        public void SetCell(Position position, IOrganism organism)
        {
            if (position.X >= Width || position.Y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "position must be inside grid");
            }

            throw new NotImplementedException();
        }

        public void EmptyCell(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
