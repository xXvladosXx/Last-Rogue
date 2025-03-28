using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Common.Geometry;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class ScheduledProcessForScatteringFireballSystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentsFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGeometryService _geometryService;

        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _armaments;
        private readonly List<GameEntity> _buffer = new(64);

        public ScheduledProcessForScatteringFireballSystem(
            GameContext game,
            IArmamentFactory armamentsFactory,
            IStaticDataService staticDataService,
            IAbilityUpgradeService abilityUpgradeService,
            IGeometryService geometryService)
        {
            _armamentsFactory = armamentsFactory;
            _staticDataService = staticDataService;
            _abilityUpgradeService = abilityUpgradeService;
            _geometryService = geometryService;

            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy,
                    GameMatcher.WorldPosition));

            _armaments = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Armament,
                    GameMatcher.ScatteringFireballArmament,
                    GameMatcher.WorldPosition,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                foreach (GameEntity armament in _armaments.GetEntities(_buffer))
                {
                    if (armament.TargetsBuffer.Contains(enemy.Id) || armament.ProcessedTargets.Contains(enemy.Id))
                    {
                        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.ScatteringFireball);
                        int projectileAmount = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireball, level)
                            .ChildProjectileSetup.ProjectileAmountPerShoot;
                        
                        Vector2[] directions = _geometryService.GetRadialDirections(projectileAmount).ToArray();

                        for (int i = 0; i < projectileAmount; i++)
                        {
                            var childFireball = _armamentsFactory.CreateChildFireball(level, enemy.WorldPosition)
                                .ReplaceDirection(directions[i])
                                .With(x => x.isMoving = true);
                            
                            childFireball.TargetsBuffer.Add(enemy.Id);
                            childFireball.ProcessedTargets.Add(enemy.Id);
                        }
                    }
                }
            }
        }
    }
}