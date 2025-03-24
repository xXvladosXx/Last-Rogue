using Code.Infrastructure.Progress.Provider;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
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