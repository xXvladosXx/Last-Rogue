using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CastForTargetsSystem>());
            Add(systemFactory.Create<CollectTargetsIntervalSystem>());
            Add(systemFactory.Create<CleanupTargetBuffersSystem>());
        }
    }
}