using System.Collections.Generic;
using Wator.Simulation.Action;

namespace Wator.Simulation.Organism
{
    public interface IOrganism
    {
        IEnumerable<IAction> Step();
    }
}
