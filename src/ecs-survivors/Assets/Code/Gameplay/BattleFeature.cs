using Code.Common.Cleanup;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<CollectTargetsFeature>());
            Add(systemFactory.Create<DamageApplicationFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}