using System;
using System.Linq;
using Wator.Simulation.Action;
using Wator.Simulation.OrganismEnvironment;

namespace Wator.Simulation.Organism
{
    public class Fish : IOrganism
    {
        private delegate IAction UnoccupiedCellMapper(Position destination);

        public Fish(IRandomElementPicker randomElementPicker, int stepsUntilReproduction)
        {
            if (stepsUntilReproduction < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stepsUntilReproduction),
                    "stepsUntilReproduction should not be negative");
            }

            RandomElementPicker = randomElementPicker;
            StepsUntilReproduction = stepsUntilReproduction;
        }

        private IRandomElementPicker RandomElementPicker { get; }

        private int StepsSinceLastReproduction { get; set; } = 0;

        private int StepsUntilReproduction { get; }

        public IAction? Step(OrganismKind ownKind, IOrganismEnvironment environment)
        {
            StepsSinceLastReproduction += 1;

            if (ShouldReproduce())
            {
                return Reproduce(ownKind, environment);
            }

            return Move(environment);
        }

        private IAction? Reproduce(OrganismKind ownKind, IOrganismEnvironment environment)
        {
            return WithRandomUnoccupiedCell(environment, destination =>
            {
                StepsSinceLastReproduction = 0;

                return new Copy(destination, Clone(), ownKind);
            });
        }

        private IAction? Move(IOrganismEnvironment environment)
        {
            return WithRandomUnoccupiedCell(environment, destination => new Move(destination));
        }

        private IAction? WithRandomUnoccupiedCell(IOrganismEnvironment environment,
            UnoccupiedCellMapper unoccupiedCellMapper)
        {
            var unoccupiedNeighbours = environment.GetFreeNeighbours().ToList();

            if (unoccupiedNeighbours.Count == 0)
            {
                return null;
            }

            var destination = RandomElementPicker.PickRandomElement(unoccupiedNeighbours);

            return unoccupiedCellMapper(destination);
        }

        private bool ShouldReproduce()
        {
            return StepsSinceLastReproduction >= StepsUntilReproduction;
        }

        private Fish Clone()
        {
            return new Fish(RandomElementPicker, StepsUntilReproduction);
        }
    }
}
