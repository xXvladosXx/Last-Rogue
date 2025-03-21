﻿using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyEffectsOnTargetsSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyEffectsOnTargetsSystem(GameContext gameContext, 
            IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.EffectSetups,
                    GameMatcher.TargetsBuffer));
        }
        
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                foreach (var targetId in entity.TargetsBuffer)
                {
                    foreach (var effectSetup in entity.EffectSetups)
                    {
                        _effectFactory.CreateEffect(effectSetup, ProducerId(entity), targetId);
                    }
                }
            }
        }

        private int ProducerId(GameEntity entity) => 
            entity.hasProducerId ? entity.ProducerId : entity.Id;
    }
}