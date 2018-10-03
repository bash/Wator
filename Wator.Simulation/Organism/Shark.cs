using System.Collections.Generic;

namespace Wator.Organism
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
