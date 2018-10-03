using System.Collections.Generic;

namespace Wator.Organism
{
    internal class Fish : IOrganism
    {
        public OrganismKind OrganismKind => OrganismKind.Fish;

        public IEnumerable<IAction> Step()
        {
            yield return new Die();
        }
    }
}
