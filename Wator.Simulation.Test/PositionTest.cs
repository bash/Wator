using System;
using Xunit;

namespace Wator.Simulation.Test
{
    public class PositionTest
    {
        [Theory]
        [InlineData(-4, 0)]
        [InlineData(0, -4)]
        public void ConstructorThrowsForNegativeValues(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Position(x, y));
        }

        [Theory]
        [InlineData(234, 45)]
        [InlineData(0, 123)]
        public void ConstructorSetsValues(int x, int y)
        {
            var position = new Position(x, y);
            
            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }
    }
}
