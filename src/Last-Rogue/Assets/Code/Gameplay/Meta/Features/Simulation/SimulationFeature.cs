using Code.Gameplay.Meta.Features.Simulation.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Meta.Features.Simulation
{
    public sealed class SimulationFeature : Feature
    {
        public SimulationFeature(ISystemFactory systems)
        {
            Add(systems.Create<BoosterDurationSystem>());
            Add(systems.Create<CalculateGoldGainSystem>());
            
            Add(systems.Create<AfkGoldGainSystem>());
            Add(systems.Create<UpdateSimulationTimeSystem>());
        }
    }
}