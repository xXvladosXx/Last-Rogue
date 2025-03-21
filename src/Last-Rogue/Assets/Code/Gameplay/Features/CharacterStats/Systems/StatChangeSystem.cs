using Code.Common.Entity;
using Code.Common.EntityIndices;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class StatChangeSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statOwners;

        public StatChangeSystem(GameContext game)
        {
            _game = game;
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Id,
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers));

        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                foreach (var stat in statOwner.BaseStats.Keys)
                {
                    statOwner.StatModifiers[stat] = 0;

                    foreach (var statChange in _game.TargetStatChanges(stat, statOwner.Id))
                    {
                        statOwner.StatModifiers[stat] += statChange.EffectValue;
                    }
                }
            }
        }

        public void Initialize()
        {
            CreateEntity.Empty()
                .AddTargetId(2)
                .AddStatChange(Stats.Speed)
                .AddEffectValue(3)
                .AddSelfDestructTime(5);
        }
    }
}