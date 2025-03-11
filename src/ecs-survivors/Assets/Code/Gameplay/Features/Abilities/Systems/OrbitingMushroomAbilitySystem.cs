using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class OrbitingMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;

        private readonly List<GameEntity> _buffer = new(4);
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public OrbitingMushroomAbilitySystem(GameContext game, IStaticDataService staticDataService,
            IArmamentFactory armamentFactory)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.OrbitingMushroomAbility,
                    GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                foreach (var hero in _heroes)
                {
                    var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, 1);
                    var projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

                    for (int i = 0; i < projectileCount; i++)
                    {
                        var phase = 2 * Mathf.PI * i / projectileCount;
                        CreateProjectile(hero, phase);
                    }
                    
                    ability.PutOnCooldown(abilityLevel.Cooldown);
                }
            }
        }

        private void CreateProjectile(GameEntity hero, float phase)
        {
            _armamentFactory.CreateOrbitalMushroom(1, hero.WorldPosition + Vector3.up, phase)
                .AddProducerId(hero.Id)
                .AddOrbitCenterPosition(hero.WorldPosition)
                .AddOrbitCenterFollowTarget(hero.Id)
                .isMoving = true;
        }
    }
}