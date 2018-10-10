using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Wator.Organism;
using Wator.Simulation.GridCell;
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
            var organism = Substitute.For<IOrganism>();

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetCell(position, organism));
        }

        [Fact]
        public void OccupiedCellsReturnsAddedOrganisms()
        {
            var grid = new TorusGrid(100, 100);

            var organism1 = Substitute.For<IOrganism>();
            var position1 = new Position(30, 30);
            var organism2 = Substitute.For<IOrganism>();
            var position2 = new Position(10, 20);

            grid.SetCell(position1, organism1);
            grid.SetCell(position2, organism2);

            var occupiedCells = grid.GetOccupiedCells().ToList();
            var expected = new List<Occupied>(new Occupied[]
            {
                new Occupied(position1, organism1),
                new Occupied(position2, organism2),
            });

            Assert.Equal(expected, occupiedCells);
        }
    }
}
