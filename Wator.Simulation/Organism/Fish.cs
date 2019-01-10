using System.Collections.Generic;
using Wator.Simulation.Action;

namespace Wator.Simulation.Organism
{
    internal class Fish : IOrganism
    {
        public OrganismKind OrganismKind => OrganismKind.Fish;

        public IEnumerable<IAction> Step()
        {
            throw new System.NotImplementedException();
        }
    }
}
