using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wator.Simulation.Action;
using Wator.Simulation.OrganismEnvironment;

namespace Wator.Simulation.Organism
{
    public class Reproducer : IOrganism
    {
        public Reproducer(IReproducableOrganism organism, IRandomElementPicker randomElementPicker, int stepsUntilReproduction)
        {
            if (stepsUntilReproduction < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stepsUntilReproduction),
                    "stepsUntilReproduction should not be negative");
            }

            Organism = organism;
            RandomElementPicker = randomElementPicker;
            StepsUntilReproduction = stepsUntilReproduction;
        }

        private IRandomElementPicker RandomElementPicker { get; }

        private int StepsSinceLastReproduction { get; set; } = 0;

        private int StepsUntilReproduction { get; }

        private IReproducableOrganism Organism { get; }

        public IAction? Step(OrganismKind ownKind, IOrganismEnvironment environment)
        {
            StepsSinceLastReproduction += 1;

            if (ShouldReproduce())
            {
                return Reproduce(ownKind, environment);
            }

            return Organism.Step(ownKind, environment);
        }

        private IAction? Reproduce(OrganismKind ownKind, IOrganismEnvironment environment)
        {
            var unoccupiedNeighbours = environment.GetFreeNeighbours().ToList();

            if (unoccupiedNeighbours.Count == 0)
            {
                return null;
            }

            var destination = RandomElementPicker.PickRandomElement(unoccupiedNeighbours);
            var clone = Organism.Clone();

            return new Copy(destination, clone, ownKind);
        }

        private bool ShouldReproduce()
        {
            return StepsSinceLastReproduction >= StepsUntilReproduction;
        }
    }
}
