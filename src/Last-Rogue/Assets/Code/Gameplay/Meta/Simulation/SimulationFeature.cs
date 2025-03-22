using Code.Gameplay.Meta.Features.AfkGain.Configs;
using Code.Gameplay.Meta.Simulation.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Meta.Simulation
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