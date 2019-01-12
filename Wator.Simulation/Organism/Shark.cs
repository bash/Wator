using System.Collections.Generic;
using Wator.Simulation.Action;

namespace Wator.Simulation.Organism
{
    public class Shark : IOrganism
    {
        IEnumerable<IAction> IOrganism.Step()
        {
            throw new System.NotImplementedException();
        }
    }
}
