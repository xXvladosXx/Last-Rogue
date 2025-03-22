using Code.Common.Cleanup;
using Code.Gameplay.Meta.Features.AfkGain.Configs;
using Code.Gameplay.Meta.Features.Simulation;
using Code.Gameplay.Meta.Features.Simulation.Systems;
using Code.Infrastructure.Progress;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<EmitTickSystem>(AfkGainConfig.SIMULATION_TICK));

            Add(systemFactory.Create<SimulationFeature>());
            Add(systemFactory.Create<PeriodicallySaveProgressSystem>(AfkGainConfig.AUTOSAVE_PROGRESS_TIME));
            
            Add(systemFactory.Create<CleanupTickSystem>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}