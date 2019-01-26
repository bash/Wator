using System;
using System.Collections.Generic;
using System.Text;

namespace Wator.Simulation.Organism
{
    public interface IReproducibleOrganism : IOrganism
    {
        IReproducibleOrganism Clone();
    }
}
