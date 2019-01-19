using System;
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
        private const int StepsUntilReproduction = 3;

        [Theory]
        [InlineData(-1)]
        [InlineData(-135)]
        [InlineData(-14)]
        public void ConstructorThrowsIfStepsUntilReproductionIsNegative(int stepsUntilReproduction)
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Fish(randomElementPicker.Object, stepsUntilReproduction));

            mockRepository.Verify();
        }

        [Fact]
        public void DoesNotSpreadWhenAllNeighboursAreOccupied()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var environment = mockRepository.Create<IOrganismEnvironment>();
            var fish = new Fish(randomElementPicker.Object, StepsUntilReproduction);

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

            var fish = new Fish(randomElementPicker.Object, StepsUntilReproduction);

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

        [Fact]
        public void ReproducesToRandomNeighbour()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var randomElementPicker = mockRepository.Create<IRandomElementPicker>();
            var environment = mockRepository.Create<IOrganismEnvironment>();

            var fish = new Fish(randomElementPicker.Object, StepsUntilReproduction);
            var organismKind = OrganismKind.Fish;

            environment.SetupSequence(mock => mock.GetFreeNeighbours())
                .Returns(new List<Position> {new Position(1, 1)})
                .Returns(new List<Position> {new Position(1, 2)})
                .Returns(new List<Position> {new Position(1, 3)});

            randomElementPicker.Setup(mock => mock.PickRandomElement(new List<Position> {new Position(1, 1)}))
                .Returns(new Position(1, 1));
            
            randomElementPicker.Setup(mock => mock.PickRandomElement(new List<Position> {new Position(1, 2)}))
                .Returns(new Position(1, 2));
            
            randomElementPicker.Setup(mock => mock.PickRandomElement(new List<Position> {new Position(1, 3)}))
                .Returns(new Position(1, 3));
            
            Assert.Equal(new Move(new Position(1, 1)), fish.Step(organismKind, environment.Object));
            Assert.Equal(new Move(new Position(1, 2)), fish.Step(organismKind, environment.Object));

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
