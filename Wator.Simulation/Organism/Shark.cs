using System.Collections.Generic;
using Wator.Simulation.Action;

namespace Wator.Simulation.Organism
{
    internal class Shark : IOrganism
    {
        public OrganismKind OrganismKind => OrganismKind.Shark;

        IEnumerable<IAction> IOrganism.Step()
        {
            throw new System.NotImplementedException();
        }
    }
}
