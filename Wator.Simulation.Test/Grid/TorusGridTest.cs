using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Wator.Simulation.Grid;
using Wator.Simulation.Organism;
using Xunit;

namespace Wator.Simulation.Test.Grid
{
    public class TorusGridTest
    {
        [Theory]
        [InlineData(-10, 4)]
        [InlineData(4, -10)]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(1, 1)]
        [InlineData(4, 1)]
        [InlineData(1, 4)]
        public void ConstructorThrowsForInvalidValues(int width, int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TorusGrid(width, height));
        }

        [Theory]
        [InlineData(101, 1)]
        [InlineData(4, 103)]
        [InlineData(3, 100)]
        [InlineData(100, 3)]
        public void SetCellThrowsForOutOfInvalidPositions(int x, int y)
        {
            var grid = new TorusGrid(100, 100);
            var position = new Position(x, y);
            var gridCell = GetGridCell();

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetCell(position, gridCell));
        }

        [Fact]
        public void OccupiedCellsReturnsAddedOrganisms()
        {
            var grid = new TorusGrid(100, 100);

            var cell1 = GetGridCell();
            var position1 = new Position(30, 30);
            var cell2 = GetGridCell();
            var position2 = new Position(10, 20);

            grid.SetCell(position1, cell1);
            grid.SetCell(position2, cell2);

            var occupiedCells = grid.GetOccupiedCells().ToList();
            var expected = new List<(Position, GridCell)>(new[]
            {
                (position1, cell1),
                (position2, cell2),
            });

            Assert.Equal(expected, occupiedCells);
        }

        [Fact]
        public void EmptyCellWorks()
        {
            var grid = new TorusGrid(100, 100);
            var cell = GetGridCell();

            grid.SetCell(new Position(42, 42), cell);
            grid.EmptyCell(new Position(42, 42));

            Assert.Equal(0, grid.GetOccupiedCells().Count());
        }

        [Fact]
        public void MoveCellWorks()
        {
            var grid = new TorusGrid(100, 100);
            var cell = GetGridCell();
            var firstPosition = new Position(30, 30);
            var secondPosition = new Position(10, 10);

            grid.SetCell(firstPosition, cell);
            Assert.Equal(cell, grid.GetCell(firstPosition));

            grid.MoveCell(firstPosition, secondPosition);
            Assert.False(grid.IsCellOccupied(firstPosition));
            Assert.Equal(cell, grid.GetCell(secondPosition));
        }

        [Fact]
        public void SettingAndRetrievingCellWorks()
        {
            var grid = new TorusGrid(100, 100);
            var cell = GetGridCell();
            var position = new Position(20, 32);

            grid.SetCell(position, cell);
            Assert.Equal(cell, grid.GetCell(position));
            Assert.True(grid.IsCellOccupied(position));
        }

        [Theory]
        [InlineData(49, 49)]
        [InlineData(49, 50)]
        [InlineData(49, 51)]
        [InlineData(50, 49)]
        [InlineData(50, 51)]
        [InlineData(51, 49)]
        [InlineData(51, 50)]
        [InlineData(51, 51)]
        public void GetOccupiedNeighboursReturnsNeighbouringCellsFromAllSides(int neighbourX, int neighbourY)
        {
            var grid = new TorusGrid(100, 100);
            var position = new Position(50, 50);
            var neighbourPosition = new Position(neighbourX, neighbourY);
            var neighbourCell = GetGridCell();

            grid.SetCell(neighbourPosition, neighbourCell);

            var actualNeighbours = grid.GetOccupiedNeighbours(position).ToList();
            var expectedNeighbours = new List<(Position, GridCell)> {(neighbourPosition, neighbourCell)};

            Assert.Equal(expectedNeighbours, actualNeighbours);
        }

        [Theory]
        [InlineData(99, 40, 0, 40)]
        [InlineData(0, 40, 99, 40)]
        public void GetOccupiedNeighboursIncludesCellFromOppositeSideOfGrid(int x, int y, int neighbourX,
            int neighbourY)
        {
            var grid = new TorusGrid(100, 100);
            var position = new Position(x, y);
            var neighbourPosition = new Position(neighbourX, neighbourY);
            var neighbourCell = GetGridCell();

            grid.SetCell(neighbourPosition, neighbourCell);

            var expectedNeighbours = new List<(Position, GridCell)> {(neighbourPosition, neighbourCell)};
            var actualNeighbours = grid.GetOccupiedNeighbours(position);

            Assert.Equal(expectedNeighbours, actualNeighbours);
        }

        [Theory]
        [InlineData(0, 40)]
        [InlineData(99, 40)]
        [InlineData(12, 10)]
        public void GetOccupiedNeighboursDoesNotIncludeCellsFarAway(int neighbourX, int neighbourY)
        {
            var grid = new TorusGrid(100, 100);
            var position = new Position(10, 10);
            var neighbourPosition = new Position(neighbourX, neighbourY);
            var neighbourCell = GetGridCell();

            grid.SetCell(neighbourPosition, neighbourCell);
            grid.SetCell(position, GetGridCell());

            Assert.Equal(0, grid.GetOccupiedNeighbours(position).Count());
        }

        [Fact]
        public void GetFreeNeighboursReturnsAllNeighbours()
        {
            var grid = new TorusGrid(6, 3);
            var position = new Position(2, 1);

            var expectedNeighbours = new List<Position>
            {
                new Position(1, 0),
                new Position(2, 0),
                new Position(3, 0),
                new Position(1, 1),
                new Position(3, 1),
                new Position(1, 2),
                new Position(2, 2),
                new Position(3, 2),
            };

            Assert.Equal(expectedNeighbours, grid.GetFreeNeighbours(position).ToList());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(0, 1)]
        [InlineData(2, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public void GetFreeNeighboursDoesNotReturnOccupiedNeighbours(int occupiedX, int occupiedY)
        {
            var occupiedPosition = new Position(occupiedX, occupiedY);

            var grid = new TorusGrid(3, 3);
            grid.SetCell(new Position(occupiedX, occupiedY), GetGridCell());

            var expectedNeighbours = new List<Position>
            {
                new Position(0, 0),
                new Position(1, 0),
                new Position(2, 0),
                new Position(0, 1),
                new Position(2, 1),
                new Position(0, 2),
                new Position(1, 2),
                new Position(2, 2),
            };

            expectedNeighbours.Remove(occupiedPosition);

            var actualNeighbours = grid.GetFreeNeighbours(new Position(1, 1)).ToList();

            Assert.Equal(expectedNeighbours, actualNeighbours);
        }

        private static GridCell GetGridCell() => new GridCell(OrganismKind.Fish, new Mock<IOrganism>().Object);
    }
}
