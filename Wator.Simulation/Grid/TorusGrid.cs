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
        private readonly Dictionary<Position, GridCell> occupiedCells = new Dictionary<Position, GridCell>();

        public TorusGrid(int width, int height)
        {
            if (width <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "width must be greater than one");
            }

            if (height <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "height must be greater than one");
            }

            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public IEnumerable<(Position, GridCell)> GetOccupiedNeighbours(Position position)
        {
            return GetNeighbourPositions(position)
                .Where(IsCellOccupied)
                .Select(neighbour => (neighbour, GetCell(neighbour)));
        }

        public IEnumerable<Position> GetFreeNeighbours(Position position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(Position, GridCell)> GetOccupiedCells()
        {
            return occupiedCells.Select(pair => (pair.Key, pair.Value));
        }

        public void SetCell(Position position, GridCell gridCell)
        {
            if (!IsPositionWithinGrid(position))
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be inside grid");
            }

            occupiedCells.Add(position, gridCell);
        }

        private bool IsPositionWithinGrid(Position position)
        {
            return position.X < Width && position.Y < Height;
        }

        public void EmptyCell(Position position) => occupiedCells.Remove(position);

        public void MoveCell(Position currentPosition, Position newPosition)
        {
            var cell = occupiedCells[currentPosition];
            occupiedCells.Add(newPosition, cell);
            occupiedCells.Remove(currentPosition);
        }

        public GridCell GetCell(Position position) => occupiedCells[position];

        public bool IsCellOccupied(Position position) => occupiedCells.ContainsKey(position);

        private IEnumerable<Position> GetNeighbourPositions(Position position)
        {
            return new List<Position>
            {
                GetPositionWithRespectToTorus(position.X - 1, position.Y - 1),
                GetPositionWithRespectToTorus(position.X, position.Y - 1),
                GetPositionWithRespectToTorus(position.X + 1, position.Y - 1),
                GetPositionWithRespectToTorus(position.X - 1, position.Y),
                GetPositionWithRespectToTorus(position.X + 1, position.Y),
                GetPositionWithRespectToTorus(position.X - 1, position.Y + 1),
                GetPositionWithRespectToTorus(position.X, position.Y + 1),
                GetPositionWithRespectToTorus(position.X + 1, position.Y + 1),
            };
        }

        private Position GetPositionWithRespectToTorus(int x, int y)
        {
            var correctedX = GetComponentWithRespectToTorusSize(x, Width);
            var correctedY = GetComponentWithRespectToTorusSize(y, Height);

            return new Position(correctedX, correctedY);
        }

        private int GetComponentWithRespectToTorusSize(int component, int maximum)
        {
            switch (component)
            {
                case var _ when component < 0:
                    return maximum + component;
                case var _ when component >= maximum:
                    return maximum - component;
                default:
                    return component;
            }
        }
    }
}
