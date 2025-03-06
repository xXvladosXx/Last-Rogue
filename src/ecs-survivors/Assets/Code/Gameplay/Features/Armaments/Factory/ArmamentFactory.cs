using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
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

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .AddEffectSetups(abilityLevel.EffectSetups)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TARGET_BUFFER_SIZE))
                .AddProcessedTargets(new List<int>(TARGET_BUFFER_SIZE))
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetContinuously = true)
                .With(x => x.isRotationAlongDirection = true)
                .With(x => x.AddTargetLimit(setup.Pierce))
                .AddSelfDestructTime(abilityLevel.ProjectileSetup.Lifetime);
        }
    }
}