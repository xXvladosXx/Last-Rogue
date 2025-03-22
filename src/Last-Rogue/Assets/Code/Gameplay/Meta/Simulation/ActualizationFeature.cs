using Code.Common.Cleanup;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Meta.Simulation
{
    public sealed class ActualizationFeature : Feature
    {
        public ActualizationFeature(ISystemFactory systems)
        {
            Add(systems.Create<SimulationFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}