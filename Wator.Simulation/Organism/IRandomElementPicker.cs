using System.Collections.Generic;

namespace Wator.Simulation.Organism
{
    public interface IRandomElementPicker
    {
        T PickRandomElement<T>(IEnumerable<T> elements);
    }
}
