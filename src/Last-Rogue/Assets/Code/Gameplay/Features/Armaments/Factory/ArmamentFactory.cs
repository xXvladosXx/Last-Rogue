using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Armaments.Extensions;
using Code.Gameplay.Features.Enchants;
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
                .AddWorldPosition(Vector3.zero)
                .AddName("Aura");
        }
        
        public GameEntity CreateShovelBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ShovelRadialStrike, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.ShovelRadialStrike)
                .AddAngleSpeed(setup.AngleSpeed)
                .With(x => x.isRotatesAroundCenter = true)
                .With(x => x.isShovelRadialStrikeAbility = true);
        }

        public GameEntity CreateMainFireball(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireball, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;
      
            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.ScatteringFireball)
                .With(x => x.isScatteringFireballArmament = true);
        }

        public GameEntity CreateChildFireball(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireballChild, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.ScatteringFireball);
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
                .AddSelfDestructTime(setup.Lifetime)
                .AddName("Projectile");
        }

        public GameEntity CreateExplosion(int producerId, Vector3 at)
        {
            var config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddTargetsBuffer(new List<int>(TARGET_BUFFER_SIZE))
                .AddRadius(config.Radius)
                .With(x => x.AddEffectSetups(config.EffectSetups), !config.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(config.StatusSetups), !config.StatusSetups.IsNullOrEmpty())
                .AddViewPrefab(config.ViewPrefab)
                .AddWorldPosition(at)
                .AddProducerId(producerId)
                .With(x => x.isReadyToCollectTargets = true)
                .AddSelfDestructTime(1)
                .AddName("Explosion");
        }
    }
}