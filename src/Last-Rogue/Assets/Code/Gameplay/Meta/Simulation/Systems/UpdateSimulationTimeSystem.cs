using Code.Infrastructure.Progress.Provider;
using Entitas;

namespace Code.Gameplay.Meta.Simulation.Systems
{
    public class UpdateSimulationTimeSystem : IExecuteSystem
    {
        private readonly IProgressProvider _progressProvider;
        private readonly IGroup<MetaEntity> _tick;

        public UpdateSimulationTimeSystem(MetaContext metaContext, 
            IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
            _tick = metaContext.GetGroup(MetaMatcher.Tick);
        }

        public void Execute()
        {
            foreach (var tick in _tick)
            {
                _progressProvider.ProgressData.LastSimulationTickTime = 
                    _progressProvider.ProgressData.LastSimulationTickTime.AddSeconds(tick.Tick);
            }
        }
    }
}