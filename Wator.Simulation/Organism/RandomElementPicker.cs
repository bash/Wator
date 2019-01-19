using System;
using System.Collections.Generic;
using System.Linq;

namespace Wator.Simulation.Organism
{
    public class RandomElementPicker : IRandomElementPicker
    {
        public RandomElementPicker()
        {
            Rng = new Random();
        }

        private Random Rng { get; }

        public T PickRandomElement<T>(IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            var index = Rng.Next(0, list.Count);

            return list.ElementAt(index);
        }
    }
}
