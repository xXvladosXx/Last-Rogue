using Code.Common.Cleanup;
using Code.Infrastructure.Progress;
using Code.Infrastructure.Progress.Systems;
using Code.Infrastructure.Systems;
using Code.Meta.Features.AfkGain.Configs;
using Code.Meta.Features.Simulation;
using Code.Meta.Features.Simulation.Systems;

namespace Code.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<EmitTickSystem>(AfkGainConfig.SIMULATION_TICK));

            Add(systemFactory.Create<SimulationFeature>());
            Add(systemFactory.Create<HomeUIFeature>());
            
            Add(systemFactory.Create<PeriodicallySaveProgressSystem>(AfkGainConfig.AUTOSAVE_PROGRESS_TIME));
            
            Add(systemFactory.Create<CleanupTickSystem>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}