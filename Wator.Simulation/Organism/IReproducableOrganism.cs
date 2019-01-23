using System;
using System.Collections.Generic;
using System.Text;

namespace Wator.Simulation.Organism
{
    public interface IReproducableOrganism : IOrganism
    {
        IReproducableOrganism Clone();
    }
}
