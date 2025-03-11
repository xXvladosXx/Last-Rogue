﻿using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(1);
        private readonly IGroup<GameEntity> _heroes;

        public GarlicAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GarlicAuraAbility)
                .NoneOf(GameMatcher.Active));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                foreach (var hero in _heroes)
                {
                    _armamentFactory.CreateEffectAura(AbilityId.GarlicAura, hero.Id, 1);
                    ability.isActive = true;   
                }
            }
        }
    }
}