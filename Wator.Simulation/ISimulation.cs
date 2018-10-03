namespace Wator.Simulation
{
    public interface ISimulation
    {
        /// <summary>
        /// The maximum width of this simulation
        /// </summary>
        int Width { get; }
        
        /// <summary>
        /// The maximum height of this simulation
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Advances the simulation by one step
        /// </summary>
        void Step();
    }
}
