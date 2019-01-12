namespace Wator.Visualization
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var grid = new Simulation.TorusGrid(100, 100);
            var simulation = new Simulation.Simulation(grid);
        }
    }
}
