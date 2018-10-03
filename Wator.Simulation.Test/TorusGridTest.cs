using System;
using System.Data;
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
    }
}
