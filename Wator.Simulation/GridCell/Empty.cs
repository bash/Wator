namespace Wator.Simulation.GridCell
{
    public class Empty : IGridCell
    {
        public Position Position { get; }

        public Empty(Position position)
        {
            Position = position;
        }

        public bool Equals(IGridCell other)
        {
            return Equals(other as object);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Empty)obj);
        }

        public override int GetHashCode()
        {
            return (Position != null ? Position.GetHashCode() : 0);
        }
        
        private bool Equals(Empty other)
        {
            return Equals(Position, other.Position);
        }
    }
}
