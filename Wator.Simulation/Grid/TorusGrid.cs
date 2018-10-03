using System;
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Occupied> GetOccupiedCells()
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
    }
}
