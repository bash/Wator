using System.Linq;
using Wator.Simulation.Action;
using Wator.Simulation.OrganismEnvironment;

namespace Wator.Simulation.Organism
{
    public class Fish : IOrganism
    {
        public Fish(IRandomElementPicker randomElementPicker)
        {
            this.RandomElementPicker = randomElementPicker;
        }

        private IRandomElementPicker RandomElementPicker { get; }

        private int StepsSinceLastReproduction { get; } = 0;

        public IAction? Step(OrganismKind ownKind, IOrganismEnvironment environment)
        {
            return Move(environment);
        }

        private IAction Move(IOrganismEnvironment environment)
        {
            var unoccupiedNeighbours = environment.GetFreeNeighbours().ToList();

            if (unoccupiedNeighbours.Count == 0)
            {
                return null;
            }

            var destination = RandomElementPicker.PickRandomElement(unoccupiedNeighbours);

            return new Move(destination);
        }
    }
}
