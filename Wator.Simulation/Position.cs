using System;

namespace Wator.Simulation
{
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

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"Position({X}, {Y})";
        }
    }
}
