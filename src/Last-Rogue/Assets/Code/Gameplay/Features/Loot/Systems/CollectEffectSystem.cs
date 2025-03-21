using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectEffectSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectEffectSystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _collected = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Collected,
                    GameMatcher.EffectSetups));
            
            _heroes = game.GetGroup(GameMatcher.
                AllOf(GameMatcher.Hero,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            {
                foreach (var hero in _heroes)
                {
                    foreach (var effectSetup in collected.EffectSetups)
                    {
                        _effectFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
                    }
                }
            }
        }
    }
    
    public class CollectStatusItemSystem : IExecuteSystem
    {
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectStatusItemSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _collected = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Collected,
                    GameMatcher.StatusSetups));
            
            _heroes = game.GetGroup(GameMatcher.
                AllOf(GameMatcher.Hero,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            {
                foreach (var hero in _heroes)
                {
                    foreach (var statusSetup in collected.StatusSetups)
                    {
                        _statusApplier.ApplyStatus(statusSetup, hero.Id, hero.Id);
                    }
                }
            }
        }
    }

}