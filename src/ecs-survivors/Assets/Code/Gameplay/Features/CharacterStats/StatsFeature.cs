using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<StatChangeSystem>());
            Add(systemFactory.Create<ApplySpeedFromStatsSystem>());
        }
    }
}