using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyFreezeStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new (32);

        public ApplyFreezeStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Status,
                    GameMatcher.Freeze,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId,
                    GameMatcher.EffectValue)
                .NoneOf(GameMatcher.Effected));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                CreateEntity.Empty()
                    .AddStatChange(Stats.Speed)
                    .AddTargetId(status.TargetId)
                    .AddProducerId(status.ProducerId)
                    .AddEffectValue(status.EffectValue)
                    .AddApplierStatusLink(status.Id);
                
                status.isEffected = true;
            }
        }
    }
}