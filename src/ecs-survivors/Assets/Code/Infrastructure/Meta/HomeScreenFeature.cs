using Code.Common.Cleanup;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}