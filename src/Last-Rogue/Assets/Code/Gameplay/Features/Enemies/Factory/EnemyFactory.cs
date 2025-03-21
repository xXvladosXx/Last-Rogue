using System;
using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector2 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Unknown:
                    break;
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }
            
            throw new ArgumentOutOfRangeException(nameof(typeId), typeId, null);
        }

        private GameEntity CreateGoblin(Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.MaxHealth] = 3)
                .With(x => x[Stats.Speed] = 1)
                .With(x => x[Stats.Damage] = 1);
            
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
                .AddEffectSetups(new List<EffectSetup> {new () {EffectTypeId = EffectTypeId.Damage, Value = baseStats[Stats.Damage]}})
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}