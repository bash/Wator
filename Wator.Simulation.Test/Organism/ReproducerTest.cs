using System;
using System.Collections.Generic;
using Moq;
using Wator.Simulation.Action;
using Wator.Simulation.Organism;
using Wator.Simulation.OrganismEnvironment;
using Xunit;

namespace Wator.Simulation.Test.Organism
{
    public class ReproducerTest
    {
        private const int StepsUntilReproduction = 3;

        [Theory]
        [InlineData(-1)]
        [InlineData(-135)]
        [InlineData(-14)]
        public void ConstructorThrowsIfStepsUntilReproductionIsNegative(int stepsUntilReproduction)
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var organism = mockRepository.Create<IReproducableOrganism>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Reproducer(organism.Object, randomElementPicker.Object, stepsUntilReproduction));

            mockRepository.Verify();
        }

        [Fact]
        public void ReproducesToRandomNeighbour()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var environment = mockRepository.Create<IOrganismEnvironment>();
            var organism = mockRepository.Create<IReproducableOrganism>();
            var organismKind = OrganismKind.Fish;

            organism.Setup(mock => mock.Step(organismKind, environment.Object)).Returns(null);

            environment.Setup(mock => mock.GetFreeNeighbours())
                .Returns(new List<Position> { new Position(1, 3) });

            randomElementPicker.Setup(mock => mock.PickRandomElement(new List<Position> { new Position(1, 3) }))
                .Returns(new Position(1, 3));

            var fish = new Reproducer(organism.Object, randomElementPicker.Object, StepsUntilReproduction);

            Assert.Null(fish.Step(organismKind, environment.Object));
            Assert.Null(fish.Step(organismKind, environment.Object));

            var action = fish.Step(organismKind, environment.Object);

            Assert.True(action is Copy);

            if (action is Copy copy)
            {
                Assert.Equal(organismKind, copy.OrganismKind);
                Assert.Equal(new Position(1, 3), copy.Destination);
            }
        }
    }
}
