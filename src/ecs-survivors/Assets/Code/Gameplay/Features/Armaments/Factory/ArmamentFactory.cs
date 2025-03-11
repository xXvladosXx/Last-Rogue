using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;
        
        private const int TARGET_BUFFER_SIZE = 16;

        public ArmamentFactory(IIdentifierService identifierService,
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.VegetableBolt)
                .With(x => x.isRotationAlongDirection = true);
        }
        
        public GameEntity CreateOrbitalMushroom(int level, Vector3 at, float phase)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.OrbitingMushroom)
                .AddOrbitPhase(phase)
                .AddOrbitRadius(setup.OrbitRadius);
        }

        public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
            var setup = abilityLevel.AuraSetup;

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddParentAbility(parentAbilityId)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), !abilityLevel.StatusSetups.IsNullOrEmpty())
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddTargetsBuffer(new List<int>(TARGET_BUFFER_SIZE))
                .AddProducerId(producerId)
                .AddRadius(setup.Radius)
                .AddCollectTargetsInterval(setup.Interaval)
                .AddCollectTargetsTimer(0)
                .With(x => x.isFollowingProducer = true)
                .AddWorldPosition(Vector3.zero);
        }
        
        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), !abilityLevel.EffectSetups.IsNullOrEmpty()) 
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), !abilityLevel.StatusSetups.IsNullOrEmpty())
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TARGET_BUFFER_SIZE))
                .AddProcessedTargets(new List<int>(TARGET_BUFFER_SIZE))
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetContinuously = true)
                .With(x => x.AddTargetLimit(setup.Pierce), setup.Pierce > 0)
                .AddSelfDestructTime(abilityLevel.ProjectileSetup.Lifetime);
        }
    }
}