using Code.Common.Cleanup.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.Cleanup
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SelfDestructTimerSystem>());
            Add(systemFactory.Create<CleanupGameDestructedViewsSystem>());
            Add(systemFactory.Create<CleanupGameDestructedSystem>());
        }
    }
}