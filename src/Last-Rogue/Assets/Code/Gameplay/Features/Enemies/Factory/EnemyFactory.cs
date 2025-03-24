using System;
using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(IIdentifierService identifierService, 
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector2 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Unknown:
                    break;
                case EnemyTypeId.Goblin:
                    return CreateGoblin(EnemyTypeId.Goblin, at);
                case EnemyTypeId.ExplosiveGoblin:
                    return CreateSelfExplodingGoblin(at);
                case EnemyTypeId.FastGoblin:
                    return CreateGoblin(EnemyTypeId.Goblin, at);
                case EnemyTypeId.StrongGoblin:
                    return CreateGoblin(EnemyTypeId.StrongGoblin, at);
            }
            
            throw new ArgumentOutOfRangeException(nameof(typeId), typeId, null);
        }

        private GameEntity CreateSelfExplodingGoblin(Vector2 at)
        {
            return CreateGoblin(EnemyTypeId.ExplosiveGoblin, at)
                .With(x => x.isEnemySelfExploded = true);
        }

        private GameEntity CreateGoblin(EnemyTypeId enemyTypeId, Vector2 at)
        {
            var config = _staticDataService.GetEnemyConfig(enemyTypeId);
            
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.MaxHealth] = config.Health)
                .With(x => x[Stats.Speed] = config.Speed)
                .With(x => x[Stats.Damage] = config.Damage);
            
            return Code.Common.Entity.CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurrentHP(baseStats[Stats.MaxHealth])
                .AddMaxHP(baseStats[Stats.MaxHealth])
                .AddEffectSetups(config.EffectSetups)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .AddViewPrefab(config.ViewPrefab)
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}