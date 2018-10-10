using System;

namespace Wator.Simulation.GridCell
{
    public interface IGridCell : IEquatable<IGridCell>
    {
        Position Position { get; }
    }
}
