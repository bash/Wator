using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Wator.Simulation.Grid;
using Wator.Simulation.Organism;
using Xunit;

namespace Wator.Simulation.Test
{
    public class TorusGridTest
    {
        [Theory]
        [InlineData(-10, 4)]
        [InlineData(4, -10)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
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
            var gridCell = new GridCell(OrganismKind.Fish, Substitute.For<IOrganism>());

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetCell(position, gridCell));
        }

        [Fact]
        public void OccupiedCellsReturnsAddedOrganisms()
        {
            var grid = new TorusGrid(100, 100);

            var cell1 = new GridCell(OrganismKind.Fish, Substitute.For<IOrganism>());
            var position1 = new Position(30, 30);
            var cell2 = new GridCell(OrganismKind.Fish, Substitute.For<IOrganism>());
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
            var cell = new GridCell(OrganismKind.Fish, Substitute.For<IOrganism>());

            grid.SetCell(new Position(42, 42), cell);
            grid.EmptyCell(new Position(42, 42));

            Assert.Equal(0, grid.GetOccupiedCells().Count());
        }
    }
}
