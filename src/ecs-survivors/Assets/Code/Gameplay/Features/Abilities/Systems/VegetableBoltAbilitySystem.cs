using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;

        private readonly List<GameEntity> _buffer = new(4);
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public VegetableBoltAbilitySystem(GameContext game, IStaticDataService staticDataService,
            IArmamentFactory armamentFactory)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.VegetableBoltAbility,
                    GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            
            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                foreach (var hero in _heroes)
                {
                    if (_enemies.count <= 0)
                        continue;

                    _armamentFactory.CreateVegetableBolt(1, hero.WorldPosition)
                        .ReplaceDirection((GetNearestEnemy(hero.WorldPosition).WorldPosition - hero.WorldPosition).normalized)
                        .With(x => x.isMoving = true);
                }
                
                ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, 1).Cooldown);
            }
        }

        private GameEntity GetNearestEnemy(Vector3 heroPosition)
        {
            GameEntity nearestEnemy = null;
            float minSqrDistance = Mathf.Infinity;
    
            foreach (GameEntity enemy in _enemies)
            {
                float sqrDistance = (enemy.WorldPosition - heroPosition).sqrMagnitude;
                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    nearestEnemy = enemy;
                }
            }
            return nearestEnemy;
        }
    }
}