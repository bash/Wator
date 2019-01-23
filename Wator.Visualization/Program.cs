using Autofac;
using Wator.Simulation.Grid;

namespace Wator.Visualization
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var container = BuildContainer();
            RunSimulation(container);
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            const int gridWidth = 200;
            const int gridHeight = 100;
            builder.Register(c => new TorusGrid(gridWidth, gridHeight)).As<IGrid>();

            builder.RegisterType<Simulation.Simulation>().As<Simulation.ISimulation>();

            return builder.Build();
        }

        private static void RunSimulation(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var simulation = scope.Resolve<Simulation.ISimulation>();
                simulation.Step();
            }
        }
    }
}
