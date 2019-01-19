using System.Collections.Generic;
using Moq;
using NSubstitute;
using Wator.Simulation.Action;
using Wator.Simulation.Organism;
using Wator.Simulation.OrganismEnvironment;
using Xunit;

namespace Wator.Simulation.Test.Organism
{
    public class FishTest
    {
        [Fact]
        public void DoesNotSpreadWhenAllNeighboursAreOccupied()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var environment = mockRepository.Create<IOrganismEnvironment>();
            var fish = new Fish(randomElementPicker.Object);

            environment.Setup(mock => mock.GetFreeNeighbours()).Returns(new List<Position>());

            var action = fish.Step(OrganismKind.Fish, environment.Object);

            Assert.Null(action);

            mockRepository.Verify();
        }

        [Fact]
        public void SpreadsToRandomNeighbour()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var environment = mockRepository.Create<IOrganismEnvironment>();

            var fish = new Fish(randomElementPicker.Object);
            
            var position = new Position(3, 4);
            var neighbours = new List<Position>
            {
                new Position(1, 1),
                position,
                new Position(3, 5),
            };

            environment.Setup(mock => mock.GetFreeNeighbours()).Returns(neighbours);
            randomElementPicker.Setup(mock => mock.PickRandomElement(neighbours)).Returns(position);

            var expectedAction = new Move(position);
            Assert.Equal(expectedAction, fish.Step(OrganismKind.Fish, environment.Object));

            mockRepository.Verify();
        }
    }
}
