using Wator.Organism;

namespace Wator.Simulation.GridCell
{
    public class Occupied : IGridCell
    {
        public Position Position { get; }

        public IOrganism Organism { get; }

        public Occupied(Position position, IOrganism organism)
        {
            Position = position;
            Organism = organism;
        }

        public bool Equals(IGridCell other)
        {
            return Equals(other as object);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Occupied)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Position.GetHashCode() * 397) ^ Organism.GetHashCode();
            }
        }
        
        private bool Equals(Occupied other)
        {
            return Position.Equals(other.Position) && Organism.Equals(other.Organism);
        }
    }
}
