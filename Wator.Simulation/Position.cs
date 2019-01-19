using System;

namespace Wator.Simulation
{
    [Equals]
    public class Position : IEquatable<Position>
    {
        public Position(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "x must be positive");
            }

            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "y must be positive");
            }

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override string ToString()
        {
            return $"Position({X}, {Y})";
        }
    }
}
